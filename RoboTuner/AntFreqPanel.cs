using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboTuner
{
    public partial class AntFreqPanel : UserControl
    {
        private int _freq;
        private bool _active = false;
        public event EventHandler activated;
        private Label[] labels;
        private Color defColor;
        public bool active => _active;
        public int freq => _freq;

        public void deactivate()
        {
            _active = false;
            ForeColor = defColor;
        }


        public void setCaption( int type, int val)
        {
            labels[type].Text = val.ToString();
        }

        public void setAllCaptions( AntFreqSettings settings)
        {
            for ( int c = 0; c < settings.motors.Length; c++)
                setCaption(c, settings.motors[c]);
        }

        public AntFreqPanel( int freq )
        {
            _freq = freq;
            InitializeComponent();
            lFreq.Text = _freq.ToString();
            labels = new Label[]
            {
                lD, lR, lL, lC
            };
            defColor = ForeColor;
            foreach (Control c in Controls)
                c.Click += AntFreqPanel_Click;
        }

        private void AntFreqPanel_Click(object sender, EventArgs e)
        {
            if (!_active)
            {
                activate();
            }
        }

        public void activate()
        {
            _active = true;
            ForeColor = Color.Red;
            activated?.Invoke(this, EventArgs.Empty);
        }
    }
}
