namespace GR_Minesweeper
{
    partial class Form2
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
            pnlBody = new Panel();
            Drapeau = new TextBox();
            Score = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.AutoSize = true;
            pnlBody.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBody.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlBody.Location = new Point(0, 82);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(0, 0);
            pnlBody.TabIndex = 0;
            // 
            // Drapeau
            // 
            Drapeau.BorderStyle = BorderStyle.FixedSingle;
            Drapeau.Location = new Point(20, 36);
            Drapeau.Name = "Drapeau";
            Drapeau.ReadOnly = true;
            Drapeau.Size = new Size(54, 23);
            Drapeau.TabIndex = 1;
            // 
            // Score
            // 
            Score.BorderStyle = BorderStyle.FixedSingle;
            Score.Location = new Point(151, 36);
            Score.Name = "Score";
            Score.ReadOnly = true;
            Score.Size = new Size(100, 23);
            Score.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Location = new Point(2, -1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 16);
            textBox1.TabIndex = 3;
            textBox1.Text = "Clic droit pour mettre une drapeau";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(563, 259);
            Controls.Add(textBox1);
            Controls.Add(Score);
            Controls.Add(Drapeau);
            Controls.Add(pnlBody);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBody;
        private TextBox Drapeau;
        private TextBox Score;
        private TextBox textBox1;
    }
}