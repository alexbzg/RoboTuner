namespace RoboTuner
{
    partial class FMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.remoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoteConnectionSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoteConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.miTune = new System.Windows.Forms.ToolStripMenuItem();
            this.pTuning = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteToolStripMenuItem,
            this.miTune});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пультToolStripMenuItem
            // 
            this.remoteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRemoteConnectionSettings,
            this.miRemoteConnect});
            this.remoteToolStripMenuItem.Name = "пультToolStripMenuItem";
            this.remoteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.remoteToolStripMenuItem.Text = "Пульт";
            // 
            // miRemoteConnectionSettings
            // 
            this.miRemoteConnectionSettings.Name = "miRemoteConnectionSettings";
            this.miRemoteConnectionSettings.Size = new System.Drawing.Size(202, 22);
            this.miRemoteConnectionSettings.Text = "Настройки соединения";
            this.miRemoteConnectionSettings.Click += new System.EventHandler(this.miRemoteConnectionSettings_Click);
            // 
            // miRemoteConnect
            // 
            this.miRemoteConnect.Name = "miRemoteConnect";
            this.miRemoteConnect.Size = new System.Drawing.Size(202, 22);
            this.miRemoteConnect.Text = "Подключиться";
            this.miRemoteConnect.Click += new System.EventHandler(this.miRemoteConnect_Click);
            // 
            // miTune
            // 
            this.miTune.Name = "miTune";
            this.miTune.Size = new System.Drawing.Size(78, 20);
            this.miTune.Text = "Настройка";
            // 
            // pTuning
            // 
            this.pTuning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTuning.Location = new System.Drawing.Point(0, 24);
            this.pTuning.Name = "pTuning";
            this.pTuning.Size = new System.Drawing.Size(426, 378);
            this.pTuning.TabIndex = 1;
            this.pTuning.Enabled = false;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 402);
            this.Controls.Add(this.pTuning);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FMain";
            this.Text = "RoboTuner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem remoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miRemoteConnectionSettings;
        private System.Windows.Forms.ToolStripMenuItem miRemoteConnect;
        private System.Windows.Forms.ToolStripMenuItem miTune;
        private System.Windows.Forms.Panel pTuning;
    }
}

