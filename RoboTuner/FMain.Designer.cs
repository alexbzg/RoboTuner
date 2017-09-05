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
            this.lAntTitle = new System.Windows.Forms.Label();
            this.lR = new System.Windows.Forms.Label();
            this.lL = new System.Windows.Forms.Label();
            this.lC = new System.Windows.Forms.Label();
            this.lAux = new System.Windows.Forms.Label();
            this.lAngle = new System.Windows.Forms.Label();
            this.lD = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pTuning.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteToolStripMenuItem,
            this.miTune});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(275, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // remoteToolStripMenuItem
            // 
            this.remoteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRemoteConnectionSettings,
            this.miRemoteConnect});
            this.remoteToolStripMenuItem.Name = "remoteToolStripMenuItem";
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
            this.pTuning.Controls.Add(this.bCancel);
            this.pTuning.Controls.Add(this.bSave);
            this.pTuning.Controls.Add(this.lAntTitle);
            this.pTuning.Controls.Add(this.lR);
            this.pTuning.Controls.Add(this.lL);
            this.pTuning.Controls.Add(this.lC);
            this.pTuning.Controls.Add(this.lAux);
            this.pTuning.Controls.Add(this.lAngle);
            this.pTuning.Controls.Add(this.lD);
            this.pTuning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTuning.Enabled = false;
            this.pTuning.Location = new System.Drawing.Point(0, 24);
            this.pTuning.Name = "pTuning";
            this.pTuning.Size = new System.Drawing.Size(275, 378);
            this.pTuning.TabIndex = 1;
            // 
            // lAntTitle
            // 
            this.lAntTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lAntTitle.Location = new System.Drawing.Point(0, 0);
            this.lAntTitle.Name = "lAntTitle";
            this.lAntTitle.Size = new System.Drawing.Size(275, 27);
            this.lAntTitle.TabIndex = 6;
            this.lAntTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lR
            // 
            this.lR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lR.Location = new System.Drawing.Point(120, 49);
            this.lR.Name = "lR";
            this.lR.Size = new System.Drawing.Size(52, 22);
            this.lR.TabIndex = 5;
            this.lR.Text = "R";
            this.lR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lL
            // 
            this.lL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lL.Location = new System.Drawing.Point(170, 49);
            this.lL.Name = "lL";
            this.lL.Size = new System.Drawing.Size(54, 22);
            this.lL.TabIndex = 4;
            this.lL.Text = "L";
            this.lL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lC
            // 
            this.lC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lC.Location = new System.Drawing.Point(223, 49);
            this.lC.Name = "lC";
            this.lC.Size = new System.Drawing.Size(53, 22);
            this.lC.TabIndex = 3;
            this.lC.Text = "C";
            this.lC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lAux
            // 
            this.lAux.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lAux.Location = new System.Drawing.Point(171, 28);
            this.lAux.Name = "lAux";
            this.lAux.Size = new System.Drawing.Size(105, 22);
            this.lAux.TabIndex = 2;
            this.lAux.Text = "Согласован.";
            this.lAux.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lAux.Click += new System.EventHandler(this.lAngleAux_Click);
            // 
            // lAngle
            // 
            this.lAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lAngle.Location = new System.Drawing.Point(69, 28);
            this.lAngle.Name = "lAngle";
            this.lAngle.Size = new System.Drawing.Size(104, 22);
            this.lAngle.TabIndex = 1;
            this.lAngle.Text = "330";
            this.lAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lAngle.Click += new System.EventHandler(this.lAngleAux_Click);
            // 
            // lD
            // 
            this.lD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lD.Location = new System.Drawing.Point(69, 49);
            this.lD.Name = "lD";
            this.lD.Size = new System.Drawing.Size(52, 22);
            this.lD.TabIndex = 0;
            this.lD.Text = "D";
            this.lD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Location = new System.Drawing.Point(4, 347);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(168, 28);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(178, 347);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(94, 28);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 402);
            this.Controls.Add(this.pTuning);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "RoboTuner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pTuning.ResumeLayout(false);
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
        private System.Windows.Forms.Label lR;
        private System.Windows.Forms.Label lL;
        private System.Windows.Forms.Label lC;
        private System.Windows.Forms.Label lAux;
        private System.Windows.Forms.Label lAngle;
        private System.Windows.Forms.Label lD;
        private System.Windows.Forms.Label lAntTitle;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
    }
}

