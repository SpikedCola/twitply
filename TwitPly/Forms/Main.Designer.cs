namespace TwitPly
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.configButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.replyTextBox = new System.Windows.Forms.TextBox();
            this.findTweetsButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.authorPictureBox = new System.Windows.Forms.PictureBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.tweetLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.postReplyButton = new System.Windows.Forms.Button();
            this.deleteTweetButton = new System.Windows.Forms.Button();
            this.tweetGroupBox = new System.Windows.Forms.GroupBox();
            this.replyLabel = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.searchToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.authorPictureBox)).BeginInit();
            this.tweetGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // configButton
            // 
            this.configButton.Location = new System.Drawing.Point(401, 41);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(81, 23);
            this.configButton.TabIndex = 0;
            this.configButton.Text = "Settings";
            this.configButton.UseVisualStyleBackColor = true;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Term:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(88, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(301, 20);
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.MouseHover += new System.EventHandler(this.searchTextBox_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reply Text:";
            // 
            // replyTextBox
            // 
            this.replyTextBox.Location = new System.Drawing.Point(88, 70);
            this.replyTextBox.Multiline = true;
            this.replyTextBox.Name = "replyTextBox";
            this.replyTextBox.Size = new System.Drawing.Size(301, 72);
            this.replyTextBox.TabIndex = 4;
            this.replyTextBox.TextChanged += new System.EventHandler(this.replyTextBox_TextChanged);
            // 
            // findTweetsButton
            // 
            this.findTweetsButton.Location = new System.Drawing.Point(401, 95);
            this.findTweetsButton.Name = "findTweetsButton";
            this.findTweetsButton.Size = new System.Drawing.Size(81, 23);
            this.findTweetsButton.TabIndex = 5;
            this.findTweetsButton.Text = "Find Tweets";
            this.findTweetsButton.UseVisualStyleBackColor = true;
            this.findTweetsButton.Click += new System.EventHandler(this.findTweetsButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(401, 12);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(81, 23);
            this.helpButton.TabIndex = 6;
            this.helpButton.Text = "Help!";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 367);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(470, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 8;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(12, 347);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(470, 13);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "- Status -";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Enabled = false;
            this.locationTextBox.Location = new System.Drawing.Point(88, 38);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(301, 20);
            this.locationTextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "@username will be automatically added to reply.";
            // 
            // authorPictureBox
            // 
            this.authorPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.authorPictureBox.Location = new System.Drawing.Point(10, 19);
            this.authorPictureBox.Name = "authorPictureBox";
            this.authorPictureBox.Size = new System.Drawing.Size(70, 70);
            this.authorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.authorPictureBox.TabIndex = 13;
            this.authorPictureBox.TabStop = false;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorLabel.Location = new System.Drawing.Point(91, 19);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(0, 15);
            this.authorLabel.TabIndex = 14;
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tweetLabel
            // 
            this.tweetLabel.Location = new System.Drawing.Point(99, 42);
            this.tweetLabel.Name = "tweetLabel";
            this.tweetLabel.Size = new System.Drawing.Size(245, 45);
            this.tweetLabel.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Reply:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // postReplyButton
            // 
            this.postReplyButton.Enabled = false;
            this.postReplyButton.Location = new System.Drawing.Point(401, 246);
            this.postReplyButton.Name = "postReplyButton";
            this.postReplyButton.Size = new System.Drawing.Size(81, 23);
            this.postReplyButton.TabIndex = 18;
            this.postReplyButton.Text = "Post Reply";
            this.postReplyButton.UseVisualStyleBackColor = true;
            this.postReplyButton.Click += new System.EventHandler(this.postReplyButton_Click);
            // 
            // deleteTweetButton
            // 
            this.deleteTweetButton.Enabled = false;
            this.deleteTweetButton.Location = new System.Drawing.Point(401, 211);
            this.deleteTweetButton.Name = "deleteTweetButton";
            this.deleteTweetButton.Size = new System.Drawing.Size(81, 23);
            this.deleteTweetButton.TabIndex = 19;
            this.deleteTweetButton.Text = "Ignore Tweet";
            this.deleteTweetButton.UseVisualStyleBackColor = true;
            this.deleteTweetButton.Click += new System.EventHandler(this.deleteTweetButton_Click);
            // 
            // tweetGroupBox
            // 
            this.tweetGroupBox.Controls.Add(this.authorPictureBox);
            this.tweetGroupBox.Controls.Add(this.authorLabel);
            this.tweetGroupBox.Controls.Add(this.tweetLabel);
            this.tweetGroupBox.Location = new System.Drawing.Point(24, 190);
            this.tweetGroupBox.Name = "tweetGroupBox";
            this.tweetGroupBox.Size = new System.Drawing.Size(358, 100);
            this.tweetGroupBox.TabIndex = 22;
            this.tweetGroupBox.TabStop = false;
            this.tweetGroupBox.Text = "Tweet -- / --";
            // 
            // replyLabel
            // 
            this.replyLabel.Location = new System.Drawing.Point(70, 296);
            this.replyLabel.Name = "replyLabel";
            this.replyLabel.Size = new System.Drawing.Size(312, 45);
            this.replyLabel.TabIndex = 16;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // searchToolTip
            // 
            this.searchToolTip.AutoPopDelay = 20000;
            this.searchToolTip.InitialDelay = 500;
            this.searchToolTip.ReshowDelay = 300;
            this.searchToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.searchToolTip.ToolTipTitle = "Some Helpful Search Tips:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 399);
            this.Controls.Add(this.replyLabel);
            this.Controls.Add(this.tweetGroupBox);
            this.Controls.Add(this.deleteTweetButton);
            this.Controls.Add(this.postReplyButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.findTweetsButton);
            this.Controls.Add(this.replyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.configButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TwitPly";
            ((System.ComponentModel.ISupportInitialize)(this.authorPictureBox)).EndInit();
            this.tweetGroupBox.ResumeLayout(false);
            this.tweetGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox replyTextBox;
        private System.Windows.Forms.Button findTweetsButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox authorPictureBox;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label tweetLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button postReplyButton;
        private System.Windows.Forms.Button deleteTweetButton;
        private System.Windows.Forms.GroupBox tweetGroupBox;
        private System.Windows.Forms.Label replyLabel;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ToolTip searchToolTip;
    }
}

