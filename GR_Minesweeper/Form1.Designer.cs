namespace GR_Minesweeper
{
    partial class Niveau
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileSystemWatcher1 = new FileSystemWatcher();
            facile = new RadioButton();
            intermediaire = new RadioButton();
            Expert = new RadioButton();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // facile
            // 
            facile.AutoSize = true;
            facile.BackColor = SystemColors.Control;
            facile.Location = new Point(42, 46);
            facile.Name = "facile";
            facile.Size = new Size(55, 19);
            facile.TabIndex = 0;
            facile.Text = "Facile";
            facile.UseVisualStyleBackColor = false;
            facile.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // intermediaire
            // 
            intermediaire.AutoSize = true;
            intermediaire.Location = new Point(141, 46);
            intermediaire.Name = "intermediaire";
            intermediaire.Size = new Size(95, 19);
            intermediaire.TabIndex = 1;
            intermediaire.Text = "Intermédiaire";
            intermediaire.UseVisualStyleBackColor = true;
            intermediaire.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // Expert
            // 
            Expert.AutoSize = true;
            Expert.Location = new Point(278, 46);
            Expert.Name = "Expert";
            Expert.Size = new Size(58, 19);
            Expert.TabIndex = 2;
            Expert.Text = "Expert";
            Expert.UseVisualStyleBackColor = true;
            Expert.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(99, 105);
            button1.Name = "button1";
            button1.Size = new Size(176, 23);
            button1.TabIndex = 3;
            button1.Text = "Démarrer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Demarrer;
            // 
            // Niveau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 161);
            Controls.Add(button1);
            Controls.Add(Expert);
            Controls.Add(intermediaire);
            Controls.Add(facile);
            Name = "Niveau";
            Text = "Niveau de difficulté";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private RadioButton facile;
        private RadioButton Expert;
        private RadioButton intermediaire;
        private Button button1;
    }
}
