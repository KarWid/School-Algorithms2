namespace Algorithms2.Forms
{
    partial class KMPForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTextTb = new System.Windows.Forms.TextBox();
            this.MainTextLbl = new System.Windows.Forms.Label();
            this.PatternLbl = new System.Windows.Forms.Label();
            this.PatternTb = new System.Windows.Forms.TextBox();
            this.FindBtn = new System.Windows.Forms.Button();
            this.ResultLbl = new System.Windows.Forms.Label();
            this.ResultTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MainTextTb
            // 
            this.MainTextTb.Location = new System.Drawing.Point(273, 41);
            this.MainTextTb.Name = "MainTextTb";
            this.MainTextTb.Size = new System.Drawing.Size(100, 20);
            this.MainTextTb.TabIndex = 0;
            this.MainTextTb.Text = "Ala ma kota";
            // 
            // MainTextLbl
            // 
            this.MainTextLbl.AutoSize = true;
            this.MainTextLbl.Location = new System.Drawing.Point(107, 44);
            this.MainTextLbl.Name = "MainTextLbl";
            this.MainTextLbl.Size = new System.Drawing.Size(163, 13);
            this.MainTextLbl.TabIndex = 1;
            this.MainTextLbl.Text = "Tekst w którym szukamy wzorca:";
            // 
            // PatternLbl
            // 
            this.PatternLbl.AutoSize = true;
            this.PatternLbl.Location = new System.Drawing.Point(218, 75);
            this.PatternLbl.Name = "PatternLbl";
            this.PatternLbl.Size = new System.Drawing.Size(52, 13);
            this.PatternLbl.TabIndex = 3;
            this.PatternLbl.Text = "Wzorzec:";
            // 
            // PatternTb
            // 
            this.PatternTb.Location = new System.Drawing.Point(273, 72);
            this.PatternTb.Name = "PatternTb";
            this.PatternTb.Size = new System.Drawing.Size(100, 20);
            this.PatternTb.TabIndex = 2;
            this.PatternTb.Text = "ma";
            // 
            // FindBtn
            // 
            this.FindBtn.Location = new System.Drawing.Point(273, 123);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(100, 23);
            this.FindBtn.TabIndex = 4;
            this.FindBtn.Text = "Szukaj";
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // ResultLbl
            // 
            this.ResultLbl.AutoSize = true;
            this.ResultLbl.Location = new System.Drawing.Point(230, 100);
            this.ResultLbl.Name = "ResultLbl";
            this.ResultLbl.Size = new System.Drawing.Size(40, 13);
            this.ResultLbl.TabIndex = 5;
            this.ResultLbl.Text = "Wynik:";
            // 
            // ResultTb
            // 
            this.ResultTb.Enabled = false;
            this.ResultTb.Location = new System.Drawing.Point(273, 97);
            this.ResultTb.Name = "ResultTb";
            this.ResultTb.Size = new System.Drawing.Size(100, 20);
            this.ResultTb.TabIndex = 6;
            // 
            // KMPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 216);
            this.Controls.Add(this.ResultTb);
            this.Controls.Add(this.ResultLbl);
            this.Controls.Add(this.FindBtn);
            this.Controls.Add(this.PatternLbl);
            this.Controls.Add(this.PatternTb);
            this.Controls.Add(this.MainTextLbl);
            this.Controls.Add(this.MainTextTb);
            this.Name = "KMPForm";
            this.Text = "KMPForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MainTextTb;
        private System.Windows.Forms.Label MainTextLbl;
        private System.Windows.Forms.Label PatternLbl;
        private System.Windows.Forms.TextBox PatternTb;
        private System.Windows.Forms.Button FindBtn;
        private System.Windows.Forms.Label ResultLbl;
        private System.Windows.Forms.TextBox ResultTb;
    }
}