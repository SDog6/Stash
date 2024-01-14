
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
            this.SaveFileLocTB = new System.Windows.Forms.TextBox();
            this.addGame = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonSteamApp = new System.Windows.Forms.RadioButton();
            this.radioButtonDocs = new System.Windows.Forms.RadioButton();
            this.radioButtonUserdataLoc = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.labelImage = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image";
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
            this.label3.Location = new System.Drawing.Point(10, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Exact path to save file";
            // 
            // SaveFileLocTB
            // 
            this.SaveFileLocTB.Location = new System.Drawing.Point(196, 220);
            this.SaveFileLocTB.Name = "SaveFileLocTB";
            this.SaveFileLocTB.Size = new System.Drawing.Size(564, 22);
            this.SaveFileLocTB.TabIndex = 5;
            // 
            // addGame
            // 
            this.addGame.Location = new System.Drawing.Point(232, 269);
            this.addGame.Name = "addGame";
            this.addGame.Size = new System.Drawing.Size(242, 57);
            this.addGame.TabIndex = 6;
            this.addGame.Text = "Add Game Info To Local File";
            this.addGame.UseVisualStyleBackColor = true;
            this.addGame.Click += new System.EventHandler(this.addGame_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Browse Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(31, 168);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(129, 21);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Steam/userdata";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonSteamApp
            // 
            this.radioButtonSteamApp.AutoSize = true;
            this.radioButtonSteamApp.Location = new System.Drawing.Point(231, 168);
            this.radioButtonSteamApp.Name = "radioButtonSteamApp";
            this.radioButtonSteamApp.Size = new System.Drawing.Size(142, 21);
            this.radioButtonSteamApp.TabIndex = 9;
            this.radioButtonSteamApp.TabStop = true;
            this.radioButtonSteamApp.Text = "Steam/steamapps";
            this.radioButtonSteamApp.UseVisualStyleBackColor = true;
            this.radioButtonSteamApp.CheckedChanged += new System.EventHandler(this.radioButtonSteamApp_CheckedChanged);
            // 
            // radioButtonDocs
            // 
            this.radioButtonDocs.AutoSize = true;
            this.radioButtonDocs.Location = new System.Drawing.Point(429, 168);
            this.radioButtonDocs.Name = "radioButtonDocs";
            this.radioButtonDocs.Size = new System.Drawing.Size(100, 21);
            this.radioButtonDocs.TabIndex = 10;
            this.radioButtonDocs.TabStop = true;
            this.radioButtonDocs.Text = "Documents";
            this.radioButtonDocs.UseVisualStyleBackColor = true;
            this.radioButtonDocs.CheckedChanged += new System.EventHandler(this.radioButtonDocs_CheckedChanged);
            // 
            // radioButtonUserdataLoc
            // 
            this.radioButtonUserdataLoc.AutoSize = true;
            this.radioButtonUserdataLoc.Location = new System.Drawing.Point(600, 168);
            this.radioButtonUserdataLoc.Name = "radioButtonUserdataLoc";
            this.radioButtonUserdataLoc.Size = new System.Drawing.Size(126, 21);
            this.radioButtonUserdataLoc.TabIndex = 11;
            this.radioButtonUserdataLoc.TabStop = true;
            this.radioButtonUserdataLoc.Text = "Userdata-Local";
            this.radioButtonUserdataLoc.UseVisualStyleBackColor = true;
            this.radioButtonUserdataLoc.CheckedChanged += new System.EventHandler(this.radioButtonUserdataLoc_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "General Path to save file";
            // 
            // labelImage
            // 
            this.labelImage.AutoSize = true;
            this.labelImage.Location = new System.Drawing.Point(327, 86);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(155, 17);
            this.labelImage.TabIndex = 13;
            this.labelImage.Text = "Image sucessfuly taken";
            this.labelImage.Visible = false;
            // 
            // AddGameToJSON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonUserdataLoc);
            this.Controls.Add(this.radioButtonDocs);
            this.Controls.Add(this.radioButtonSteamApp);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addGame);
            this.Controls.Add(this.SaveFileLocTB);
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
        private System.Windows.Forms.TextBox SaveFileLocTB;
        private System.Windows.Forms.Button addGame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonSteamApp;
        private System.Windows.Forms.RadioButton radioButtonDocs;
        private System.Windows.Forms.RadioButton radioButtonUserdataLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelImage;
    }
}