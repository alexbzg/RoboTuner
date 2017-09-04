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
        private AntFreqSettings _settings;
        private bool _active = false;
        public event EventHandler activated;
        private Dictionary<string, Label> labels;
        private Color defColor;
        public bool active => _active;

        public void deactivate()
        {
            _active = false;
            ForeColor = defColor;
        }


        public void setCaption( string type, int val)
        {
            labels[type].Text = val.ToString();
        }

        public AntFreqPanel( AntFreqSettings settings )
        {
            _settings = new AntFreqSettings() { freq = settings.freq };
            InitializeComponent();
            labels = new Dictionary<string, Label>()
            {
                { "D", lD }, { "R", lR }, { "L", lL }, { "C", lC }
            };
            defColor = ForeColor;
        }

        private void AntFreqPanel_Click(object sender, EventArgs e)
        {
            if (!_active)
            {
                _active = true;
                ForeColor = Color.Red;
                activated?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
