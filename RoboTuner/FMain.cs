using Jerome;
using StorableFormState;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XmlConfigNS;
using JeromeModuleSettings;
using System.Threading;
using System.Threading.Tasks;

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
        public const int motorCount = 4;
        public const byte mcCount = 8;
        static readonly Dictionary<string, MCData> mcData = new Dictionary<string, MCData>
        {
            {
                "E", new MCData()
                {
                    aux = new MCAngle() {
                        relays = new MCElem[] { new MCElem() { mc = 0, elem = 2 }, new MCElem() { mc = 1, elem = 0 }, new MCElem() { mc = 2, elem = 2 }  },
                        motors = new MCElem[] { new MCElem() { mc = 1, elem = 1 }, new MCElem() { mc = 1, elem = 0 } }
                    },
                    angles = new Dictionary<int, MCAngle> {
                        { 330, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 0, elem = 0 }, new MCElem() { mc = 2, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 0, elem = 0 }, new MCElem() { mc = 2, elem = 1 }
                                }
                            }
                        },
                        { 150, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 2, elem = 0 }, new MCElem() { mc = 0, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 2, elem = 0 }, new MCElem() { mc = 0, elem = 1 }
                                }
                            }
                        },

                    }
                }
            },
            {
                "W", new MCData()
                {
                    aux = new MCAngle() {
                        relays = new MCElem[] { new MCElem() { mc = 6, elem = 2 }, new MCElem() { mc = 5, elem = 0 }, new MCElem() { mc = 4, elem = 2 }  },
                        motors = new MCElem[] { new MCElem() { mc = 5, elem = 0 }, new MCElem() { mc = 5, elem = 1 } }
                    },
                    angles = new Dictionary<int, MCAngle> {
                        { 330, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 6, elem = 0 }, new MCElem() { mc = 4, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 6, elem = 1 }, new MCElem() { mc = 4, elem = 1 }
                                }
                            }
                        },
                        { 150, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 4, elem = 0 }, new MCElem() { mc = 6, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 4, elem = 0 }, new MCElem() { mc = 6, elem = 0 }
                                }
                            }
                        },

                    }
                }
            },
            {
                "N", new MCData()
                {
                    aux = new MCAngle() {
                        relays = new MCElem[] { new MCElem() { mc = 6, elem = 2 }, new MCElem() { mc = 7, elem = 0 }, new MCElem() { mc = 0, elem = 2 }  },
                        motors = new MCElem[] { new MCElem() { mc = 7, elem = 1 }, new MCElem() { mc = 7, elem = 0 } }
                    },
                    angles = new Dictionary<int, MCAngle> {
                        { 60, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 0, elem = 0 }, new MCElem() { mc = 6, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 0, elem = 0 }, new MCElem() { mc = 6, elem = 0 }
                                }
                            }
                        },
                        { 240, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 6, elem = 0 }, new MCElem() { mc = 0, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 6, elem = 1 }, new MCElem() { mc = 0, elem = 1 }
                                }
                            }
                        },

                    }
                }
            },
            {
                "S", new MCData()
                {
                    aux = new MCAngle() {
                        relays = new MCElem[] { new MCElem() { mc = 2, elem = 2 }, new MCElem() { mc = 3, elem = 0 }, new MCElem() { mc = 4, elem = 2 }  },
                        motors = new MCElem[] { new MCElem() { mc = 3, elem = 0 }, new MCElem() { mc = 3, elem = 1 } }
                    },
                    angles = new Dictionary<int, MCAngle> {
                        { 60, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 2, elem = 0 }, new MCElem() { mc = 4, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 2, elem = 0 }, new MCElem() { mc = 4, elem = 1 }
                                }
                            }
                        },
                        { 240, new MCAngle()
                            {
                                relays = new MCElem[] { new MCElem() { mc = 4, elem = 0 }, new MCElem() { mc = 2, elem = 1 } },
                                motors = new MCElem[]
                                {
                                    new MCElem() { mc = 4, elem = 0 }, new MCElem() { mc = 2, elem = 1 }
                                }
                            }
                        },

                    }
                }
            }



        };
        static readonly RemoteControllerTemplate remoteControllerTemplate = new RemoteControllerTemplate()
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
        static readonly AntennaeControllerTemplate antennaeControllerTemplate = new AntennaeControllerTemplate()
        {
            trLine = 14
        };
        

        JeromeController remoteCtrl;
        JeromeController antennaeCtrl;
        Dictionary<int, EncoderLine> encoderLines = new Dictionary<int, EncoderLine>();
        Dictionary<int, AntFreqPanel> antFreqPanels = new Dictionary<int, AntFreqPanel>();
        EncoderControl[] encoders = new EncoderControl[remoteControllerTemplate.encoders.Length];
        int currentFreq = 0;
        bool activeType = false;
        Color defColor;
        string currentDir;
        int currentAngle;
        AntFreqSettings curFreqSettings;
        System.Threading.Timer antennaePingTimer;
        MotorState[] motorsState = new MotorState[mcCount];
        SemaphoreSlim trSemaphore = new SemaphoreSlim(1);
        Label[] motorLabels = new Label[mcCount * 2];

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
                    if (currentFreq != freq)
                        setCurrentFreq( freq );
                };
            }
            for (int c = 0; c < mcCount * 2; c++)
            {
                motorLabels[c] = new Label();
                motorLabels[c].Text = "M" + (c + 1).ToString() + " 0";
                motorLabels[c].ForeColor = Color.Red;
                motorLabels[c].Left = 1;
                motorLabels[c].Top = 1 + motorLabels[c].Height * c;
                pMotors.Controls.Add(motorLabels[c]);
            }
            pTuning.Refresh();
            if (config.data.remoteJeromeParams != null)
                connectRemoteCtrl();
            else
                miRemoteConnect.Visible = false;
            if (config.data.antennaeJeromeParams != null)
                connectAntennaeCtrl();
            else
                miAntennaeConnect.Visible = false;
            tune(directions[0], angles[directions[0]][0]);
            antennaePingTimer = new System.Threading.Timer(obj => pingAntennae(), null, 1000, 1000);
        }

        private async void pingAntennae()
        {
            if (antennaeCtrl == null || !antennaeCtrl.connected)
                return;
            await trSemaphore.WaitAsync().ConfigureAwait(false);
            if ( antennaeCtrl != null && antennaeCtrl.connected)
                for (byte c = 0; c < mcCount; c++)
                    antennaeMsg(c, new byte[] { 0 } );
            antennaeCtrl.switchLine(antennaeControllerTemplate.trLine, 0);
            await Task.Delay(250);
            trSemaphore.Release();
            DoInvoke(() => {
                for (int c = 0; c < mcCount; c++)
                {
                    if (motorsState[c].updated)
                        for (int c0 = 0; c0 < 2; c0++)
                        {
                            motorLabels[c * 2 + c0].ForeColor = Color.Green;
                            motorLabels[c * 2 + c0].Text = "M" + (c * 2 + c0 + 1).ToString() + " " + motorsState[c].positions[c0].ToString();
                        }
                    else
                        for (int c0 = 0; c0 < 2; c0++)
                            motorLabels[c * 2 + c0].ForeColor = Color.Red;
                }
            });
        }

        private void setCurrentFreq( int freq )
        {
            if (currentFreq != 0 && currentFreq != freq)
                antFreqPanels[currentFreq].deactivate();
            currentFreq = freq;
            AntFreqSettings storedAFS = config.data.getFreqSettings( currentDir, currentAngle, freq );
            curFreqSettings = new AntFreqSettings()
            {
                freq = freq
            };
            Array.Copy(storedAFS.motors, curFreqSettings.motors, motorCount);
            AntFreqPanel afp = antFreqPanels[currentFreq];
            afp.setAllCaptions(curFreqSettings);
            if (!afp.active)
                afp.activate();
        }

        private async Task tune( string dir, int angle)
        {
            lAngle.Text = angle.ToString();
            lAntTitle.Text = antennaeTitles[dir];
            currentAngle = angle;
            currentDir = dir;
            await setActiveType(true);
            foreach (int freq in antFreqPanels.Keys )
            {
                AntFreqPanel afp = antFreqPanels[freq];
                AntFreqSettings freqSettings = config.data.getFreqSettings( dir, angle, freq );
                afp.setAllCaptions(freqSettings);
            }
            antFreqPanels[freqStart].activate();
            await setRelays();
        }

        private void createTuneMenuItem( string dir )
        {
            ToolStripMenuItem mi = new ToolStripMenuItem(antennaeTitles[dir]);
            foreach ( int angle in angles[dir] )
            {
                int a = angle;
                string d = dir;
                ToolStripMenuItem miAngle = new ToolStripMenuItem(angle.ToString());
                mi.DropDownItems.Add(miAngle);
                miAngle.Click += async delegate
                {
                    await tune(d, a);
                };
            }
            miTune.DropDownItems.Add(mi);
        }

        private void connectRemoteCtrl()
        {
            remoteCtrl = JeromeController.create( config.data.remoteJeromeParams );
            int encC = 0;
            foreach (EncoderTemplate encT in remoteControllerTemplate.encoders)
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
                enc.rotated += delegate (object sender, EncoderRotatedEventArgs e)
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

        private void connectAntennaeCtrl()
        {
            antennaeCtrl = JeromeController.create(config.data.antennaeJeromeParams);
            antennaeCtrl.usartBinaryMode = true;
            antennaeCtrl.onConnected += antennaeConnected;
            antennaeCtrl.onDisconnected += antennaeDisconnected;
            antennaeCtrl.usartBytesReceived += antennaeBytesReceived;
            antennaeCtrl.asyncConnect();
            miAntennaeConnectionSettings.Visible = false;
            miAntennaeConnect.Text = "Отключиться";
        }

        private void antennaeBytesReceived(object sender, AsyncConnectionNS.BytesReceivedEventArgs e)
        {
            foreach (byte b in e.bytes)
            {
                if (b == 0)
                    continue;
                int mc = ( b | (7 << 5) ) >> 5;
                MotorState ms = motorsState[mc];
                if ( ++ms.rcvd % 2 == 1)
                    ms.buf += b | 15;          
                else 
                {
                    ms.buf += (b | 31) - 1;
                    ms.positions[ms.rcvd / 2] = ms.buf;
                    ms.buf = 0;
                    if (ms.rcvd == 4)
                    {
                        ms.rcvd = 0;
                        ms.updated = true;
                    }
                }
            }
        }

        private void antennaeDisconnected(object sender, AsyncConnectionNS.DisconnectEventArgs e)
        {
            DoInvoke(() =>
            {
                processConnections();
                lAntennaeDisconnect.Visible = true;
            });
        }

        private async void antennaeConnected(object sender, EventArgs e)
        {
            antennaeCtrl.setLineMode(antennaeControllerTemplate.trLine, "out");
            antennaeCtrl.switchLine(antennaeControllerTemplate.trLine, 1);
            DoInvoke(() =>
            {
                processConnections();
                lAntennaeDisconnect.Visible = false;
            });
            await setRelays();
        }

        private void processConnections()
        {
            bool cs = (antennaeCtrl != null && antennaeCtrl.connected && remoteCtrl != null && remoteCtrl.connected);
            pTuning.Enabled = cs;
            miTune.Enabled = cs;
        }

        private void remoteDisconnected(object sender, AsyncConnectionNS.DisconnectEventArgs e)
        {
            DoInvoke(() =>
           {
               processConnections();
               lRemoteDisconnect.Visible = true;
           });
        }

        private async void encValueChange(int encC, EncoderRotatedEventArgs e)
        {
            int motorNo = encC;
            if (!activeType)
                motorNo += 2;
            curFreqSettings.motors[motorNo] += e.value;
            DoInvoke(() =>
          {
                antFreqPanels[currentFreq].setCaption(motorNo, curFreqSettings.motors[motorNo]);
          });
            MCElem mce = getMCAngle().motors[encC];
            await antennaeCmd(mce.mc, "motor", mce.elem, curFreqSettings.motors[motorNo]);
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
               processConnections();
               lRemoteDisconnect.Visible = false;
           });
        }

        private void miRemoteConnectionSettings_Click(object sender, EventArgs e)
        {
            bool wasNull = false;
            if (config.data.remoteJeromeParams == null)
            {
                wasNull = true;
                config.data.remoteJeromeParams = new JeromeConnectionParams();
                config.data.remoteJeromeParams.usartPort = 0;
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

        private async void lAngleAux_Click(object sender, EventArgs e )
        {
            await setActiveType(sender == lAngle);
        }

        private async Task setActiveType( bool type)
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
                await setRelays();
            }
        }

        private async Task setRelays()
        {
            MCElem[] relays = getMCAngle().relays;
            for (byte mc = 0; mc < mcCount; mc++)
            {
                byte args = 0;
                for (byte rc = 0; rc < relays.Length; rc++)
                    if (relays[rc].mc == mc)
                        args += Convert.ToByte( 1 << relays[rc].elem );
                await antennaeCmd(mc, "relays", args, 0);
            }
        }


        private async Task antennaeCmd( byte mc, string cmd, byte args, int extraArgs )
        {
            byte[] data = new byte[extraArgs == 0 ? 1 : 3];
            data[0] = 0;
            if (cmd == "relays")
                data[0] += 1 << 3;
            else if (cmd == "motor")
                data[0] += 2 << 3;
            data[0] += args;           
            if ( extraArgs != 0 )
            {
                data[1] = Convert.ToByte((extraArgs | (31 << 5)) >> 5 + 1);
                data[2] = Convert.ToByte(extraArgs | 31 + 32);
            }
            await trSemaphore.WaitAsync().ConfigureAwait(false);
            antennaeMsg(mc, data);
            trSemaphore.Release();
        }

        private void antennaeMsg( byte mc, byte[] data)
        {
            byte[] _data = new byte[data.Length];
            byte mcID = Convert.ToByte(mc << 5);
            for (int c = 0; c < data.Length; c++)
            {
                _data[c] = Convert.ToByte(mcID + data[c]);
                if (_data[c] == 0)
                    _data[c] = 1;
            }
            antennaeCtrl.usartSendBytes(_data);
        }

        public MCAngle getMCAngle()
        {
            return (activeType ? mcData[currentDir].angles[currentAngle] : mcData[currentDir].aux);
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

        private void disconnectAntennaeCtrl()
        {
            if (antennaeCtrl != null)
            {
                if (antennaeCtrl.active)
                    antennaeCtrl.disconnect();
                antennaeCtrl.onConnected -= remoteConnected;
                antennaeCtrl.lineStateChanged -= remoteLineStateChanged;
                antennaeCtrl.onDisconnected -= remoteDisconnected;
                antennaeCtrl = null;
            }
            miAntennaeConnect.Text = "Подключиться";
            miAntennaeConnectionSettings.Visible = true;
        }


        private async void bSave_Click(object sender, EventArgs e)
        {
            AntFreqSettings storedAFS = config.data.getFreqSettings(currentDir, currentAngle, currentFreq);
            Array.Copy( curFreqSettings.motors, storedAFS.motors, storedAFS.motors.Length );
            writeConfig();
            if (currentFreq < freqStart + freqStep * (freqCount - 1))
                setCurrentFreq(currentFreq + freqStep);
            else
            {
                int angleIdx = Array.IndexOf(angles[currentDir], currentAngle);
                if (angleIdx < angles[currentDir].Length - 1)
                    await tune(currentDir, angles[currentDir][angleIdx + 1]);
                else
                {
                    int dirIdx = Array.IndexOf(directions, currentDir);
                    string newDir = directions[0];
                    if (dirIdx < directions.Length - 1)
                        newDir = directions[dirIdx + 1];
                    await tune(newDir, angles[newDir][0]);
                }
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            setCurrentFreq(currentFreq);
        }


        private void miAntennaeConnectionSettings_Click(object sender, EventArgs e)
        {
            bool wasNull = false;
            if (config.data.antennaeJeromeParams == null)
            {
                wasNull = true;
                config.data.antennaeJeromeParams = new JeromeConnectionParams();
            }
            if (config.data.antennaeJeromeParams.edit())
                config.write();
            else if (wasNull)
                config.data.antennaeJeromeParams = null;
            miAntennaeConnect.Visible = config.data.antennaeJeromeParams != null;


        }

        private void miAntennaeConnect_Click(object sender, EventArgs e)
        {
            if (antennaeCtrl != null && antennaeCtrl.active)
                disconnectAntennaeCtrl();
            else
                connectAntennaeCtrl();
        }

        private void miJeromeSetup_Click(object sender, EventArgs e)
        {
            fModuleSettings fms = new fModuleSettings();
            fms.ShowDialog();
        }

    }

    public class EncoderRotatedEventArgs : EventArgs
    {
        public int value;
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
        public event EventHandler<EncoderRotatedEventArgs> rotated;

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
                rotated?.Invoke(this, new EncoderRotatedEventArgs() { value = dir });
            }

        }
    }

    public class EncoderTemplate
    {
        public int[] lines;
    }

    public class RemoteControllerTemplate
    {
        public EncoderTemplate[] encoders;
    }

    public class AntennaeControllerTemplate
    {
        public int trLine;
    }

    public class AntFreqSettings
    {
        public int freq;
        public int[] motors = new int[FMain.motorCount];
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

    public class MCElem
    {
        public byte mc;
        public byte elem;
    }

    public class MCAngle
    {
        public MCElem[] relays;
        public MCElem[] motors;
    }

    public class MCData
    {
        public MCAngle aux;
        public Dictionary<int, MCAngle> angles;
    }

    public class MotorState
    {
        public int[] positions = new int[] { -1, -1 };
        public int rcvd = 0;
        public int buf = 0;
        public bool updated = false;
    }

    public class RoboTunerConfig: StorableFormConfig
    {
        public JeromeConnectionParams remoteJeromeParams;
        public JeromeConnectionParams antennaeJeromeParams;
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
