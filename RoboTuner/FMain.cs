using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jerome;
using System.Threading;
using System.Collections.Concurrent;
using StorableFormState;
using XmlConfigNS;

namespace RoboTuner
{
    public partial class FMain : FormWStorableState<RoboTunerConfig>
    {
        static readonly int freqStart = 3520;
        static readonly int freqStep = 30;
        static readonly int freqCount = 10;
        static readonly string[] antennaes = new string[] { "E", "W", "N", "S" };
        static readonly ControllerTemplate controllerTemplate = new ControllerTemplate()
        {
            encoders = new EncoderTemplate[] {
                new EncoderTemplate()
                {
                    lines = new int[] { 7, 6 }
                }
            }
        };

        JeromeController remoteCtrl;
        Dictionary<int, EncoderLine> lines = new Dictionary<int, EncoderLine>();

        public FMain()
        {
            config = new XmlConfig<RoboTunerConfig>();
            InitializeComponent();
            foreach ( EncoderTemplate encT in controllerTemplate.encoders)
            {
                EncoderControl enc = new EncoderControl(remoteCtrl, encT);
                lines[encT.lines[0]] = new EncoderLine() { dir = -1, enc = enc };
                lines[encT.lines[1]] = new EncoderLine() { dir = 1, enc = enc };
                enc.valueChange += encValueChange;
            }
            if (config.data.remoteJeromeParams != null)
                connectRemoteCtrl();
            else
                miRemoteConnect.Visible = false;
        }

        private void connectRemoteCtrl()
        {
            remoteCtrl = JeromeController.create( config.data.remoteJeromeParams );
            remoteCtrl.onConnected += remoteConnected;
            remoteCtrl.lineStateChanged += remoteLineStateChanged;
            remoteCtrl.onDisconnected += remoteDisconnected;
            remoteCtrl.asyncConnect();
            miRemoteConnectionSettings.Visible = false;
            miRemoteConnect.Text = "Отключиться";
        }

        private void remoteDisconnected(object sender, AsyncConnectionNS.DisconnectEventArgs e)
        {
        }

        private void encValueChange(object sender, EncoderValueChangeEventArgs e)
        {
            DoInvoke(() =>
          {
              //label1.Text = e.newValue.ToString();
          });
        }

        private void remoteLineStateChanged(object sender, LineStateChangedEventArgs e)
        {
            if (lines.ContainsKey(e.line))
            {
                EncoderLine encL = lines[e.line];
                encL.enc.lineChange(encL.dir, e.state);
            }
        }


        private void remoteConnected(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("remote connected");
            remoteCtrl.readlines();
        }

        private void miRemoteConnectionSettings_Click(object sender, EventArgs e)
        {
            bool wasNull = false;
            if (config.data.remoteJeromeParams == null)
            {
                wasNull = true;
                config.data.remoteJeromeParams = new JeromeConnectionParams();
            }
            if (config.data.remoteJeromeParams.edit())
                config.write();
            else if (wasNull)
                config.data.remoteJeromeParams = null;
            miRemoteConnect.Visible = config.data.remoteJeromeParams != null;

        }

        private void miRemoteConnect_Click(object sender, EventArgs e)
        {
            if (remoteCtrl != null && remoteCtrl.active)
                disconnectRemoteCtrl();
            else
                connectRemoteCtrl();
        }

        private void disconnectRemoteCtrl()
        {
            if (remoteCtrl != null)
            {
                if (remoteCtrl.active)
                    remoteCtrl.disconnect();
                remoteCtrl.onConnected -= remoteConnected;
                remoteCtrl.lineStateChanged -= remoteLineStateChanged;
                remoteCtrl.onDisconnected -= remoteDisconnected;
                remoteCtrl = null;
            }
            miRemoteConnect.Text = "Подключиться";
            miRemoteConnectionSettings.Visible = true;
        }
    }

    public class EncoderValueChangeEventArgs
    {
        public int newValue;
    }

    public class EncoderLine
    {
        public int dir;
        public EncoderControl enc;
    }

    public class EncoderControl
    {
        private JeromeController _ctrl;
        private Dictionary<int, int> _lines = new Dictionary<int, int> { { -1, 0 }, { 1, 0 } };
        private int _value = 0;
        public int value => _value;
        public event EventHandler<EncoderValueChangeEventArgs> valueChange;

        public EncoderControl( JeromeController ctrl, EncoderTemplate tmplt )
        {
            _ctrl = ctrl;
            _lines[-1] = tmplt.lines[0];
            _lines[1] = tmplt.lines[1];
        }

        public void lineChange( int dir, int state )
        {
            int otherState = _ctrl.getLineState(_lines[-dir]);
            if (otherState != -1 && otherState != state)
            {
                _value += dir;
                valueChange?.Invoke(this, new EncoderValueChangeEventArgs() { newValue = _value });
            }

        }
    }

    public class EncoderTemplate
    {
        public int[] lines;
    }

    public class ControllerTemplate
    {
        public EncoderTemplate[] encoders;
    }

    public class AntFreqSettings
    {
        public int freq;
        public int D;
        public int R;
        public int L;
        public int C;
    }

    public class AntSettings
    {
        public string antennae;
        public List<AntFreqSettings> settings;
    }

    public class RoboTunerConfig: StorableFormConfig
    {
        public JeromeConnectionParams remoteJeromeParams;
        public List<AntSettings> antennaeSettings;
    }
}
