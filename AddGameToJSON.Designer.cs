
namespace Stash
{
    partial class AddGameToJSON
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
            this.GameNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageNameTB = new System.Windows.Forms.TextBox();
            this.SaveFileLocTB = new System.Windows.Forms.TextBox();
            this.addGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameNameTB
            // 
            this.GameNameTB.Location = new System.Drawing.Point(186, 33);
            this.GameNameTB.Name = "GameNameTB";
            this.GameNameTB.Size = new System.Drawing.Size(100, 22);
            this.GameNameTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ImageName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "GameName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Save File location on PC";
            // 
            // ImageNameTB
            // 
            this.ImageNameTB.Location = new System.Drawing.Point(186, 83);
            this.ImageNameTB.Name = "ImageNameTB";
            this.ImageNameTB.Size = new System.Drawing.Size(100, 22);
            this.ImageNameTB.TabIndex = 4;
            // 
            // SaveFileLocTB
            // 
            this.SaveFileLocTB.Location = new System.Drawing.Point(198, 138);
            this.SaveFileLocTB.Name = "SaveFileLocTB";
            this.SaveFileLocTB.Size = new System.Drawing.Size(564, 22);
            this.SaveFileLocTB.TabIndex = 5;
            // 
            // addGame
            // 
            this.addGame.Location = new System.Drawing.Point(226, 188);
            this.addGame.Name = "addGame";
            this.addGame.Size = new System.Drawing.Size(242, 57);
            this.addGame.TabIndex = 6;
            this.addGame.Text = "Add Game Info To Local File";
            this.addGame.UseVisualStyleBackColor = true;
            this.addGame.Click += new System.EventHandler(this.addGame_Click);
            // 
            // AddGameToJSON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addGame);
            this.Controls.Add(this.SaveFileLocTB);
            this.Controls.Add(this.ImageNameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameNameTB);
            this.Name = "AddGameToJSON";
            this.Text = "AddGameToJSON";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GameNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ImageNameTB;
        private System.Windows.Forms.TextBox SaveFileLocTB;
        private System.Windows.Forms.Button addGame;
    }
}