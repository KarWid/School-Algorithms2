namespace Algorithms2.Forms
{
    partial class Main
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
            this.ChessJumperProblemBtn = new System.Windows.Forms.Button();
            this.ChessBoardSizeLbl = new System.Windows.Forms.Label();
            this.ChessStartFieldRowLbl = new System.Windows.Forms.Label();
            this.ChessStartFieldColumnLbl = new System.Windows.Forms.Label();
            this.StartFieldLbl = new System.Windows.Forms.Label();
            this.ChessBoardSizeTb = new System.Windows.Forms.TextBox();
            this.ChessStartFieldRowTb = new System.Windows.Forms.TextBox();
            this.ChessStartFieldColumnTb = new System.Windows.Forms.TextBox();
            this.StartChessJumperProblemBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChessJumperProblemBtn
            // 
            this.ChessJumperProblemBtn.Location = new System.Drawing.Point(12, 12);
            this.ChessJumperProblemBtn.Name = "ChessJumperProblemBtn";
            this.ChessJumperProblemBtn.Size = new System.Drawing.Size(165, 41);
            this.ChessJumperProblemBtn.TabIndex = 0;
            this.ChessJumperProblemBtn.Text = "Problem skoczka szachowego";
            this.ChessJumperProblemBtn.UseVisualStyleBackColor = true;
            this.ChessJumperProblemBtn.Click += new System.EventHandler(this.ChessJumperProblemBtn_Click);
            // 
            // ChessBoardSizeLbl
            // 
            this.ChessBoardSizeLbl.AutoSize = true;
            this.ChessBoardSizeLbl.Location = new System.Drawing.Point(231, 12);
            this.ChessBoardSizeLbl.Name = "ChessBoardSizeLbl";
            this.ChessBoardSizeLbl.Size = new System.Drawing.Size(78, 13);
            this.ChessBoardSizeLbl.TabIndex = 2;
            this.ChessBoardSizeLbl.Text = "Rozmiar tablicy";
            // 
            // ChessStartFieldRowLbl
            // 
            this.ChessStartFieldRowLbl.AutoSize = true;
            this.ChessStartFieldRowLbl.Location = new System.Drawing.Point(231, 55);
            this.ChessStartFieldRowLbl.Name = "ChessStartFieldRowLbl";
            this.ChessStartFieldRowLbl.Size = new System.Drawing.Size(39, 13);
            this.ChessStartFieldRowLbl.TabIndex = 3;
            this.ChessStartFieldRowLbl.Text = "Wiersz";
            // 
            // ChessStartFieldColumnLbl
            // 
            this.ChessStartFieldColumnLbl.AutoSize = true;
            this.ChessStartFieldColumnLbl.Location = new System.Drawing.Point(231, 81);
            this.ChessStartFieldColumnLbl.Name = "ChessStartFieldColumnLbl";
            this.ChessStartFieldColumnLbl.Size = new System.Drawing.Size(48, 13);
            this.ChessStartFieldColumnLbl.TabIndex = 4;
            this.ChessStartFieldColumnLbl.Text = "Kolumna";
            // 
            // StartFieldLbl
            // 
            this.StartFieldLbl.AutoSize = true;
            this.StartFieldLbl.Location = new System.Drawing.Point(231, 40);
            this.StartFieldLbl.Name = "StartFieldLbl";
            this.StartFieldLbl.Size = new System.Drawing.Size(105, 13);
            this.StartFieldLbl.TabIndex = 5;
            this.StartFieldLbl.Text = "Pozycja początkowa";
            // 
            // ChessBoardSizeTb
            // 
            this.ChessBoardSizeTb.Location = new System.Drawing.Point(342, 12);
            this.ChessBoardSizeTb.Name = "ChessBoardSizeTb";
            this.ChessBoardSizeTb.Size = new System.Drawing.Size(35, 20);
            this.ChessBoardSizeTb.TabIndex = 6;
            // 
            // ChessStartFieldRowTb
            // 
            this.ChessStartFieldRowTb.Location = new System.Drawing.Point(342, 55);
            this.ChessStartFieldRowTb.Name = "ChessStartFieldRowTb";
            this.ChessStartFieldRowTb.Size = new System.Drawing.Size(35, 20);
            this.ChessStartFieldRowTb.TabIndex = 7;
            // 
            // ChessStartFieldColumnTb
            // 
            this.ChessStartFieldColumnTb.Location = new System.Drawing.Point(342, 81);
            this.ChessStartFieldColumnTb.Name = "ChessStartFieldColumnTb";
            this.ChessStartFieldColumnTb.Size = new System.Drawing.Size(35, 20);
            this.ChessStartFieldColumnTb.TabIndex = 8;
            // 
            // StartChessJumperProblemBtn
            // 
            this.StartChessJumperProblemBtn.Location = new System.Drawing.Point(398, 12);
            this.StartChessJumperProblemBtn.Name = "StartChessJumperProblemBtn";
            this.StartChessJumperProblemBtn.Size = new System.Drawing.Size(63, 20);
            this.StartChessJumperProblemBtn.TabIndex = 9;
            this.StartChessJumperProblemBtn.Text = "Uruchom";
            this.StartChessJumperProblemBtn.UseVisualStyleBackColor = true;
            this.StartChessJumperProblemBtn.Click += new System.EventHandler(this.StartChessJumperProblemBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.StartChessJumperProblemBtn);
            this.Controls.Add(this.ChessStartFieldColumnTb);
            this.Controls.Add(this.ChessStartFieldRowTb);
            this.Controls.Add(this.ChessBoardSizeTb);
            this.Controls.Add(this.StartFieldLbl);
            this.Controls.Add(this.ChessStartFieldColumnLbl);
            this.Controls.Add(this.ChessStartFieldRowLbl);
            this.Controls.Add(this.ChessBoardSizeLbl);
            this.Controls.Add(this.ChessJumperProblemBtn);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChessJumperProblemBtn;
        private System.Windows.Forms.Label ChessBoardSizeLbl;
        private System.Windows.Forms.Label ChessStartFieldRowLbl;
        private System.Windows.Forms.Label ChessStartFieldColumnLbl;
        private System.Windows.Forms.Label StartFieldLbl;
        private System.Windows.Forms.TextBox ChessBoardSizeTb;
        private System.Windows.Forms.TextBox ChessStartFieldRowTb;
        private System.Windows.Forms.TextBox ChessStartFieldColumnTb;
        private System.Windows.Forms.Button StartChessJumperProblemBtn;
    }
}

