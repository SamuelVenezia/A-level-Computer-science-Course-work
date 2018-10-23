namespace CardGame
{
    partial class MMenu
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
            this.CmdStart = new System.Windows.Forms.Button();
            this.lblTitleCard = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdStart
            // 
            this.CmdStart.BackColor = System.Drawing.Color.Transparent;
            this.CmdStart.Location = new System.Drawing.Point(131, 272);
            this.CmdStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CmdStart.Name = "CmdStart";
            this.CmdStart.Size = new System.Drawing.Size(200, 55);
            this.CmdStart.TabIndex = 0;
            this.CmdStart.Text = "Start";
            this.CmdStart.UseVisualStyleBackColor = false;
            this.CmdStart.Click += new System.EventHandler(this.CmdStart_Click);
            // 
            // lblTitleCard
            // 
            this.lblTitleCard.AutoSize = true;
            this.lblTitleCard.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleCard.Location = new System.Drawing.Point(112, 44);
            this.lblTitleCard.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTitleCard.Name = "lblTitleCard";
            this.lblTitleCard.Size = new System.Drawing.Size(219, 83);
            this.lblTitleCard.TabIndex = 1;
            this.lblTitleCard.Text = "Menu";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(131, 406);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "How to play";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardGame.Properties.Resources.image_b9cc1717_d17c_4309_bf3a_109081bafc4c_large;
            this.ClientSize = new System.Drawing.Size(491, 647);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitleCard);
            this.Controls.Add(this.CmdStart);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "MMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdStart;
        private System.Windows.Forms.Label lblTitleCard;
        private System.Windows.Forms.Button button1;
    }
}

