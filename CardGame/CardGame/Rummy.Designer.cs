namespace CardGame
{
    partial class Rummy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rummy));
            this.label1 = new System.Windows.Forms.Label();
            this.PicGame = new System.Windows.Forms.PictureBox();
            this.lblControl = new System.Windows.Forms.Label();
            this.lblMk = new System.Windows.Forms.Label();
            this.CmdCall = new System.Windows.Forms.Button();
            this.CmdPfd = new System.Windows.Forms.Button();
            this.CmdPfs = new System.Windows.Forms.Button();
            this.CmdPcb = new System.Windows.Forms.Button();
            this.CmbCC = new System.Windows.Forms.ComboBox();
            this.lblRc = new System.Windows.Forms.Label();
            this.CmdMenu = new System.Windows.Forms.Button();
            this.btnTNN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicGame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rummy";
            // 
            // PicGame
            // 
            this.PicGame.BackColor = System.Drawing.Color.Transparent;
            this.PicGame.Location = new System.Drawing.Point(50, 43);
            this.PicGame.Name = "PicGame";
            this.PicGame.Size = new System.Drawing.Size(485, 360);
            this.PicGame.TabIndex = 1;
            this.PicGame.TabStop = false;
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.BackColor = System.Drawing.Color.Transparent;
            this.lblControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.Location = new System.Drawing.Point(572, 35);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(127, 20);
            this.lblControl.TabIndex = 2;
            this.lblControl.Text = "Control Pannel";
            // 
            // lblMk
            // 
            this.lblMk.AutoSize = true;
            this.lblMk.BackColor = System.Drawing.Color.Transparent;
            this.lblMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMk.Location = new System.Drawing.Point(724, 392);
            this.lblMk.Name = "lblMk";
            this.lblMk.Size = new System.Drawing.Size(34, 13);
            this.lblMk.TabIndex = 3;
            this.lblMk.Text = "Mk III";
            // 
            // CmdCall
            // 
            this.CmdCall.BackColor = System.Drawing.Color.Red;
            this.CmdCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmdCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCall.Location = new System.Drawing.Point(598, 69);
            this.CmdCall.Name = "CmdCall";
            this.CmdCall.Size = new System.Drawing.Size(78, 43);
            this.CmdCall.TabIndex = 4;
            this.CmdCall.Text = "Call";
            this.CmdCall.UseVisualStyleBackColor = false;
            this.CmdCall.Click += new System.EventHandler(this.CmdCall_Click);
            // 
            // CmdPfd
            // 
            this.CmdPfd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPfd.Location = new System.Drawing.Point(545, 149);
            this.CmdPfd.Name = "CmdPfd";
            this.CmdPfd.Size = new System.Drawing.Size(75, 46);
            this.CmdPfd.TabIndex = 5;
            this.CmdPfd.Text = "Pick from Deck";
            this.CmdPfd.UseVisualStyleBackColor = true;
            this.CmdPfd.Click += new System.EventHandler(this.CmdPfd_Click);
            // 
            // CmdPfs
            // 
            this.CmdPfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPfs.Location = new System.Drawing.Point(651, 149);
            this.CmdPfs.Name = "CmdPfs";
            this.CmdPfs.Size = new System.Drawing.Size(75, 46);
            this.CmdPfs.TabIndex = 6;
            this.CmdPfs.Text = "Pick from Stack";
            this.CmdPfs.UseVisualStyleBackColor = true;
            this.CmdPfs.Click += new System.EventHandler(this.CmdPfs_Click);
            // 
            // CmdPcb
            // 
            this.CmdPcb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPcb.Location = new System.Drawing.Point(626, 298);
            this.CmdPcb.Name = "CmdPcb";
            this.CmdPcb.Size = new System.Drawing.Size(100, 45);
            this.CmdPcb.TabIndex = 7;
            this.CmdPcb.Text = "Put Card in Stack";
            this.CmdPcb.UseVisualStyleBackColor = true;
            this.CmdPcb.Click += new System.EventHandler(this.CmdPcb_Click);
            // 
            // CmbCC
            // 
            this.CmbCC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCC.FormattingEnabled = true;
            this.CmbCC.Location = new System.Drawing.Point(580, 247);
            this.CmbCC.Name = "CmbCC";
            this.CmbCC.Size = new System.Drawing.Size(121, 24);
            this.CmbCC.TabIndex = 8;
            // 
            // lblRc
            // 
            this.lblRc.AutoSize = true;
            this.lblRc.BackColor = System.Drawing.Color.Transparent;
            this.lblRc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRc.Location = new System.Drawing.Point(577, 214);
            this.lblRc.Name = "lblRc";
            this.lblRc.Size = new System.Drawing.Size(99, 18);
            this.lblRc.TabIndex = 9;
            this.lblRc.Text = "Return Card";
            // 
            // CmdMenu
            // 
            this.CmdMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdMenu.Location = new System.Drawing.Point(4, 9);
            this.CmdMenu.Margin = new System.Windows.Forms.Padding(1);
            this.CmdMenu.Name = "CmdMenu";
            this.CmdMenu.Size = new System.Drawing.Size(68, 30);
            this.CmdMenu.TabIndex = 10;
            this.CmdMenu.Text = "Menu";
            this.CmdMenu.UseVisualStyleBackColor = true;
            this.CmdMenu.Click += new System.EventHandler(this.CmdMenu_Click);
            // 
            // btnTNN
            // 
            this.btnTNN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTNN.Location = new System.Drawing.Point(545, 377);
            this.btnTNN.Name = "btnTNN";
            this.btnTNN.Size = new System.Drawing.Size(131, 23);
            this.btnTNN.TabIndex = 11;
            this.btnTNN.Text = "Train Neural Network";
            this.btnTNN.UseVisualStyleBackColor = false;
            this.btnTNN.Click += new System.EventHandler(this.btnTNN_Click);
            // 
            // Rummy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(765, 423);
            this.Controls.Add(this.btnTNN);
            this.Controls.Add(this.CmdMenu);
            this.Controls.Add(this.lblRc);
            this.Controls.Add(this.CmbCC);
            this.Controls.Add(this.CmdPcb);
            this.Controls.Add(this.CmdPfs);
            this.Controls.Add(this.CmdPfd);
            this.Controls.Add(this.CmdCall);
            this.Controls.Add(this.lblMk);
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.PicGame);
            this.Controls.Add(this.label1);
            this.Name = "Rummy";
            this.Text = "Rummy";
            ((System.ComponentModel.ISupportInitialize)(this.PicGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicGame;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.Label lblMk;
        private System.Windows.Forms.Button CmdCall;
        private System.Windows.Forms.Button CmdPfd;
        private System.Windows.Forms.Button CmdPfs;
        private System.Windows.Forms.Button CmdPcb;
        private System.Windows.Forms.Label lblRc;
        private System.Windows.Forms.ComboBox CmbCC;
        private System.Windows.Forms.Button CmdMenu;
        private System.Windows.Forms.Button btnTNN;
    }
}