using Jerome;
using StorableFormState;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XmlConfigNS;

namespace RoboTuner
{
    public partial class FMain : FormWStorableState<RoboTunerConfig>
    {
        public static readonly int freqStart = 3520;
        public static readonly int freqStep = 30;
        public static readonly int freqCount = 10;
        static readonly string[] directions = new string[] { "E", "W", "N", "S" };
        static readonly Dictionary<string, string> antennaeTitles = new Dictionary<string, string>
        {
            { "E", "Восточная" }, { "W", "Западная" }, { "N", "Северная" }, { "S", "Южная" },
        };
        static readonly Dictionary<string, int[]> angles = new Dictionary<string, int[]> {
            { "E", new int[] { 330, 150 } },
            { "W", new int[] { 330, 150 } },
            { "N", new int[] { 60, 240 } },
            { "S", new int[] { 60, 240 } },
        };
        static readonly ControllerTemplate controllerTemplate = new ControllerTemplate()
        {
            encoders = new EncoderTemplate[] {
                new EncoderTemplate()
                {
                    lines = new int[] { 5, 6 }
                },
                new EncoderTemplate()
                {
                    lines = new int[] { 1, 2 }
                }

            }
        };

        JeromeController remoteCtrl;
        Dictionary<int, EncoderLine> encoderLines = new Dictionary<int, EncoderLine>();
        Dictionary<int, AntFreqPanel> antFreqPanels = new Dictionary<int, AntFreqPanel>();
        EncoderControl[] encoders = new EncoderControl[controllerTemplate.encoders.Length];
        int currentFreq = 0;
        bool activeType = false;
        Color defColor;
        string currentDir;
        int currentAngle;
        AntFreqSettings curFreqSettings;

        public FMain()
        {
            config = new XmlConfig<RoboTunerConfig>();
            InitializeComponent();
            defColor = ForeColor;
            foreach (string dir in directions)
                createTuneMenuItem(dir);
            for (int c = 0; c < freqCount; c++ )
            {
                int freq = freqStart + freqStep * c;
                AntFreqPanel afp = new AntFreqPanel(freq);
                afp.Top = 70 + ( afp.Height - 1 ) * c;
                afp.Left = -1;
                pTuning.Controls.Add(afp);
                afp.Visible = true;
                antFreqPanels[freq] = afp;
                afp.activated += delegate (object sender, EventArgs e)
                {
                    if (currentFreq != 0)
                        antFreqPanels[currentFreq].deactivate();
                    setCurrentFreq( freq );
                };
            }
            pTuning.Refresh();
            if (config.data.remoteJeromeParams != null)
                connectRemoteCtrl();
            else
                miRemoteConnect.Visible = false;
            tune(directions[0], angles[directions[0]][0]);
        }

        private void setCurrentFreq( int freq )
        {
            currentFreq = freq;
            AntFreqSettings storedAFS = config.data.getFreqSettings( currentDir, currentAngle, freq );
            curFreqSettings = new AntFreqSettings()
            {
                freq = freq,
                D = storedAFS.D,
                R = storedAFS.R,
                L = storedAFS.L,
                C = storedAFS.C
            };
        }

        private void tune( string dir, int angle)
        {
            lAngle.Text = angle.ToString();
            lAntTitle.Text = antennaeTitles[dir];
            currentAngle = angle;
            currentDir = dir;
            setActiveType(true);
            foreach (int freq in antFreqPanels.Keys )
            {
                AntFreqPanel afp = antFreqPanels[freq];
                AntFreqSettings freqSettings = config.data.getFreqSettings( dir, angle, freq );
                afp.setCaption("D", freqSettings.D);
                afp.setCaption("R", freqSettings.R);
                afp.setCaption("L", freqSettings.L);
                afp.setCaption("C", freqSettings.C);
            }
            antFreqPanels[freqStart].activate();
        }

        private void createTuneMenuItem( string dir )
        {
            ToolStripMenuItem mi = new ToolStripMenuItem(dir);
            foreach ( int angle in angles[dir] )
            {
                int a = angle;
                string d = dir;
                ToolStripMenuItem miAngle = new ToolStripMenuItem(angle.ToString());
                mi.DropDownItems.Add(miAngle);
                miAngle.Click += delegate {
                    tune(d, a);
                };
            }
            miTune.DropDownItems.Add(mi);
        }

        private void connectRemoteCtrl()
        {
            remoteCtrl = JeromeController.create( config.data.remoteJeromeParams );
            int encC = 0;
            foreach (EncoderTemplate encT in controllerTemplate.encoders)
            {
                EncoderControl enc = new EncoderControl(remoteCtrl, encT);
                encoders[encC] = enc;
                for (int c = 0; c < encT.lines.Length; c++)
                {
                    int line = encT.lines[c];
                    encoderLines[line] = new EncoderLine() { dir = c == 0 ? -1 : 1, enc = enc };
                    remoteCtrl.setLineMode(line, "in");
                }
                encoderLines[encT.lines[1]] = new EncoderLine() { dir = 1, enc = enc };
                int _encC = encC;
                enc.valueChange += delegate (object sender, EncoderValueChangeEventArgs e)
                {
                    encValueChange(_encC, e);
                };
                encC++;
            }
            remoteCtrl.onConnected += remoteConnected;
            remoteCtrl.lineStateChanged += remoteLineStateChanged;
            remoteCtrl.onDisconnected += remoteDisconnected;
            remoteCtrl.asyncConnect();
            miRemoteConnectionSettings.Visible = false;
            miRemoteConnect.Text = "Отключиться";
        }

        private void remoteDisconnected(object sender, AsyncConnectionNS.DisconnectEventArgs e)
        {
            DoInvoke(() =>
           {
               Text = "RoboTuner - Нет соединения с пультом";
               pTuning.Enabled = false;
           });
        }

        private void encValueChange(int encC, EncoderValueChangeEventArgs e)
        {
            DoInvoke(() =>
          {
              string cptType;
              if (activeType)
              {
                  if (encC == 0)
                  {
                      cptType = "D";
                      curFreqSettings.D = e.newValue;
                  }
                  else
                  {
                      cptType = "R";
                      curFreqSettings.R = e.newValue;
                  }
              } else
              {
                  if (encC == 0)
                  {
                      cptType = "L";
                      curFreqSettings.L = e.newValue;
                  }
                  else
                  {
                      cptType = "C";
                      curFreqSettings.C = e.newValue;
                  }
              }
              antFreqPanels[currentFreq].setCaption(cptType, e.newValue);
              //label1.Text = e.newValue.ToString();
          });
        }

        private void remoteLineStateChanged(object sender, LineStateChangedEventArgs e)
        {
            if (encoderLines.ContainsKey(e.line))
            {
                EncoderLine encL = encoderLines[e.line];
                encL.enc.lineChange(encL.dir, e.state);
            }
        }


        private void remoteConnected(object sender, EventArgs e)
        {
            remoteCtrl.readlines();
            DoInvoke(() =>
           {
               Text = "RoboTuner";
               pTuning.Enabled = true;
           });
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

        private void lAngleAux_Click(object sender, EventArgs e )
        {
            setActiveType(sender == lAngle);
        }

        private void setActiveType( bool type)
        {
            if (type != activeType)
            {
                if (type)
                {
                    lAngle.ForeColor = Color.Red;
                    lAux.ForeColor = defColor;
                }
                else
                {
                    lAngle.ForeColor = defColor;
                    lAux.ForeColor = Color.Red;
                }
                activeType = type;
            }
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

        private void bSave_Click(object sender, EventArgs e)
        {
            AntFreqSettings storedAFS = config.data.getFreqSettings(currentDir, currentAngle, currentFreq);
            storedAFS.D = curFreqSettings.D;
            storedAFS.R = curFreqSettings.R;
            storedAFS.L = curFreqSettings.L;
            storedAFS.C = curFreqSettings.C;
            writeConfig();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            setCurrentFreq(currentFreq);
        }
    }

    public class EncoderValueChangeEventArgs : EventArgs
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

    public class AntID
    {
        public string dir;
        public int angle;
    }

    public class AntSettings
    {
        public AntID antID;
        public List<AntFreqSettings> settings = new List<AntFreqSettings>();

    }

    public class RoboTunerConfig: StorableFormConfig
    {
        public JeromeConnectionParams remoteJeromeParams;
        public List<AntSettings> antennaeSettings = new List<AntSettings>();

        public AntFreqSettings getFreqSettings(string dir, int angle, int freq )
        {
            AntSettings settings = antennaeSettings.Find(x => x.antID.dir == dir && x.antID.angle == angle);
            if (settings == null)
            {
                settings = new AntSettings()
                {
                    antID = new AntID { dir = dir, angle = angle },
                };
                antennaeSettings.Add(settings);
            }
            AntFreqSettings afs = settings.settings.Find(x => x.freq == freq);
            if (afs == null)
            {
                afs = new AntFreqSettings() { freq = freq };
                settings.settings.Add(afs);
            }
            return afs;
        }
    }
}
