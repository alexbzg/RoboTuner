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

namespace RoboTuner
{
    public partial class Form1 : Form
    {
        static readonly ControllerTemplate controllerTemplate = new ControllerTemplate()
        {
            encoders = new EncoderTemplate[] {
                new EncoderTemplate()
                {
                    lines = new int[] { 7, 6 }
                }
            }
        };

        JeromeController ctrl = JeromeController.create(new JeromeConnectionParams() { host = "192.168.0.101", name = "test" });
        Dictionary<int, EncoderLine> lines = new Dictionary<int, EncoderLine>();

        public Form1()
        {
            InitializeComponent();
            ctrl.onConnected += onConnected;
            ctrl.lineStateChanged += lineStateChanged;
            foreach ( EncoderTemplate encT in controllerTemplate.encoders)
            {
                EncoderControl enc = new EncoderControl(ctrl, encT);
                lines[encT.lines[0]] = new EncoderLine() { dir = -1, enc = enc };
                lines[encT.lines[1]] = new EncoderLine() { dir = 1, enc = enc };
                enc.valueChange += encValueChange;
            }
            ctrl.asyncConnect();
        }

        private void encValueChange(object sender, EncoderValueChangeEventArgs e)
        {
            Invoke((MethodInvoker)delegate
          {
              label1.Text = e.newValue.ToString();
          });
        }

        private void lineStateChanged(object sender, LineStateChangedEventArgs e)
        {
            if (lines.ContainsKey(e.line))
            {
                EncoderLine encL = lines[e.line];
                encL.enc.lineChange(encL.dir, e.state);
            }
        }


        private void onConnected(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("connected");
            ctrl.readlines();
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
}
