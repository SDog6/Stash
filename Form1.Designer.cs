
namespace Stash
{
    partial class Form1
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
            this.UpFearHunger = new System.Windows.Forms.Button();
            this.DownFearHunger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpFearHunger
            // 
            this.UpFearHunger.Location = new System.Drawing.Point(533, 51);
            this.UpFearHunger.Name = "UpFearHunger";
            this.UpFearHunger.Size = new System.Drawing.Size(75, 23);
            this.UpFearHunger.TabIndex = 0;
            this.UpFearHunger.Text = "Upload";
            this.UpFearHunger.UseVisualStyleBackColor = true;
            this.UpFearHunger.Click += new System.EventHandler(this.UpFearHunger_Click);
            // 
            // DownFearHunger
            // 
            this.DownFearHunger.Location = new System.Drawing.Point(664, 51);
            this.DownFearHunger.Name = "DownFearHunger";
            this.DownFearHunger.Size = new System.Drawing.Size(75, 23);
            this.DownFearHunger.TabIndex = 1;
            this.DownFearHunger.Text = "Download";
            this.DownFearHunger.UseVisualStyleBackColor = true;
            this.DownFearHunger.Click += new System.EventHandler(this.DownFearHunger_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DownFearHunger);
            this.Controls.Add(this.UpFearHunger);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpFearHunger;
        private System.Windows.Forms.Button DownFearHunger;
    }
}

