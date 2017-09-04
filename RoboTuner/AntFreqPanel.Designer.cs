namespace RoboTuner
{
    partial class AntFreqPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lFreq = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lR = new System.Windows.Forms.Label();
            this.lL = new System.Windows.Forms.Label();
            this.lD = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lFreq
            // 
            this.lFreq.AutoSize = true;
            this.lFreq.Location = new System.Drawing.Point(12, 8);
            this.lFreq.Name = "lFreq";
            this.lFreq.Size = new System.Drawing.Size(45, 20);
            this.lFreq.TabIndex = 0;
            this.lFreq.Text = "3520";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(69, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // lR
            // 
            this.lR.AutoSize = true;
            this.lR.Location = new System.Drawing.Point(127, 8);
            this.lR.Name = "lR";
            this.lR.Size = new System.Drawing.Size(36, 20);
            this.lR.TabIndex = 2;
            this.lR.Text = "360";
            // 
            // lL
            // 
            this.lL.AutoSize = true;
            this.lL.Location = new System.Drawing.Point(179, 8);
            this.lL.Name = "lL";
            this.lL.Size = new System.Drawing.Size(36, 20);
            this.lL.TabIndex = 3;
            this.lL.Text = "360";
            // 
            // lD
            // 
            this.lD.AutoSize = true;
            this.lD.Location = new System.Drawing.Point(77, 8);
            this.lD.Name = "lD";
            this.lD.Size = new System.Drawing.Size(36, 20);
            this.lD.TabIndex = 4;
            this.lD.Text = "360";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(119, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(171, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(223, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // lC
            // 
            this.lC.AutoSize = true;
            this.lC.Location = new System.Drawing.Point(231, 8);
            this.lC.Name = "lC";
            this.lC.Size = new System.Drawing.Size(36, 20);
            this.lC.TabIndex = 8;
            this.lC.Text = "360";
            // 
            // AntFreqPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lD);
            this.Controls.Add(this.lL);
            this.Controls.Add(this.lR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lFreq);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AntFreqPanel";
            this.Size = new System.Drawing.Size(274, 35);
            this.Click += new System.EventHandler(this.AntFreqPanel_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lR;
        private System.Windows.Forms.Label lL;
        private System.Windows.Forms.Label lD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lC;
    }
}
