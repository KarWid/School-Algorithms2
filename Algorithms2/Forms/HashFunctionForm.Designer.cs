namespace Algorithms2.Forms
{
    partial class HashFunctionForm
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
            this.MemberBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ValueTb = new System.Windows.Forms.TextBox();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MemberBtn
            // 
            this.MemberBtn.Location = new System.Drawing.Point(167, 133);
            this.MemberBtn.Name = "MemberBtn";
            this.MemberBtn.Size = new System.Drawing.Size(133, 23);
            this.MemberBtn.TabIndex = 7;
            this.MemberBtn.Text = "Member";
            this.MemberBtn.UseVisualStyleBackColor = true;
            this.MemberBtn.Click += new System.EventHandler(this.MemberBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(167, 104);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(133, 23);
            this.DeleteBtn.TabIndex = 6;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ValueTb
            // 
            this.ValueTb.Location = new System.Drawing.Point(167, 45);
            this.ValueTb.Name = "ValueTb";
            this.ValueTb.Size = new System.Drawing.Size(133, 20);
            this.ValueTb.TabIndex = 5;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Location = new System.Drawing.Point(167, 75);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(133, 23);
            this.InsertBtn.TabIndex = 4;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // HashFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 217);
            this.Controls.Add(this.MemberBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.ValueTb);
            this.Controls.Add(this.InsertBtn);
            this.Name = "HashFunctionForm";
            this.Text = "HashFunctionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MemberBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TextBox ValueTb;
        private System.Windows.Forms.Button InsertBtn;
    }
}