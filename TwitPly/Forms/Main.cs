using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetSharp;
using System.Reflection;

namespace TwitPly
{
    public partial class MainForm : Form
    {
        // width - 10
        Size sizeSmall = new Size(500, 200); // progressbar and tweet list hidden
        Size sizeMedium = new Size(500, 396); // progressbar and tweet list shown
        Size sizeLarge = new Size(500, 427); // progressbar hidden, status and tweet list shown

        SettingsForm sForm = new SettingsForm();

        List<TwitterSearchStatus> tweets = new List<TwitterSearchStatus>();

        public MainForm()
        {
            InitializeComponent();

            this.Size = sizeSmall;

            this.Text += " - v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            TwitterSettings.LoadSettings();

            if (!TwitterSettings.MissingCredential()) // means settings were loaded
            {
                // backgroundworker checks textbox text, so we dont overwrite something valid in twittersettings when we test values
                // this way we dont need to write a whole new dowork handler
                sForm.consumerKeyTextBox.Text = TwitterSettings.ConsumerKey;
                sForm.consumerSecretTextBox.Text = TwitterSettings.ConsumerSecret;
                sForm.accessTokenTextBox.Text = TwitterSettings.AccessToken;
                sForm.accessTokenSecretTextBox.Text = TwitterSettings.AccessTokenSecret;

                sForm.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompletedAutoLoaded); // attach new completed handler
                sForm.bw.RunWorkerAsync(); // validate them
            }
        }

        private void bw_RunWorkerCompletedAutoLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null) // failed
            {
                MessageBox.Show("Authentication Failed! Please check the credentials in your settings.xml file and try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result.GetType() == typeof(TwitterError))
            {
                TwitterError error = (TwitterError)e.Result;
                MessageBox.Show("Authentication Failed!\n\nThe Twitter API said: \"" + error.ErrorMessage + "\"\n\nPlease check the credentials in your settings.xml file and try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result.GetType() == typeof(TwitterUser))// passed
            {
                TwitterUser user = (TwitterUser)e.Result;
                sForm.AuthenticationSuccessful(user);
               // MessageBox.Show("Authentication was successful! You are logged in as \"" + user.ScreenName + "\".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void configButton_Click(object sender, EventArgs e)
        {
            sForm.ShowDialogA();
        }

        private void findTweetsButton_Click(object sender, EventArgs e)
        {
            if (TwitterSettings.MissingCredential())
            {
                MessageBox.Show("You are missing at least one API credential.\n\nPlease click \"Settings\" and make sure all the keys are filled in.",
                    "Missing API Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TwitterSettings.Tweets < 1)
            {
                MessageBox.Show("You haven't set the number of tweets to get per pass.\n\nPlease click \"Settings\" and fill it in.",
                    "Missing Tweets Per Pass", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                MessageBox.Show("You haven't set a search term!",
                    "Missing Search Term", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Size = sizeLarge;

                statusLabel.Text = "Searching Twitter For Tweets...";
                progressBar.Enabled = true;

                bw.RunWorkerAsync(TwitterSettings.Tweets);
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application will search Twitter for the given query, and make it easy for you to reply to all found Tweets with the given message. The message will automatically be prefixed by \"@username\".\n\n" +
                "To get started, click \"Settings\" and fill in your API credentials and the number of Tweets per pass to get (your settings will be remembered for next time). \"Test\", and then \"Save\".\n\n" +
                "Next, choose a search term to query Twitter for. Hit \"Find Tweets\" to start finding Tweets matching the search term.\n\n" +
                "Finally, enter a message to reply to found tweets with, and start clicking \"Post Reply\"!\n\n" +
                "Written by J Skoba <parkinglotlust@gmail.com>", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void postReplyButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteTweetButton_Click(object sender, EventArgs e)
        {
            string author = tweets[0].Author.ScreenName;
            tweets.RemoveAt(0); // remove first tweet

            if (tweets.Count > 0)
            {
                statusLabel.Text = "Deleted tweet by author \"" + author + "\".";

                UpdateTweetGroupBox("Tweet 1 / " + tweets.Count.ToString());
                ShowTweet(tweets[0]);
            }
            else
            {
                UpdateTweetGroupBox("Tweet -- / --");

                deleteTweetButton.Enabled = false;
                postReplyButton.Enabled = false;

                authorPictureBox.Image = null;
                authorLabel.Text = "";
                tweetLabel.Text = "";
                replyLabel.Text = "";

                statusLabel.Text = "All Tweets have been processed.";
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            TwitterService service = new TwitterService(TwitterSettings.ConsumerKey, TwitterSettings.ConsumerSecret);
            service.AuthenticateWith(TwitterSettings.AccessToken, TwitterSettings.AccessTokenSecret);

            TwitterSearchResult results = service.Search(searchTextBox.Text, Convert.ToInt16(e.Argument)); // max 1500 / 100 per page

            /* need to check for errors here, got a 503 "services overloaded" today */

            if (results.Statuses.Count() > 0)
            {
                tweets = new List<TwitterSearchStatus>(results.Statuses);
                UpdateTweetGroupBox("Tweet 1 / " + tweets.Count.ToString());
                ShowTweet(tweets[0]);

                e.Result = tweets.Count;
            }
            else
            {
                e.Result = null;
            }
        }

        private void ShowTweet(TwitterSearchStatus tweet)
        {
            if (authorLabel.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    authorLabel.Text = "@" + tweet.Author.ScreenName;
                });
            }
            else
            {
                authorLabel.Text = "@" + tweet.Author.ScreenName;
            }

            if (tweetLabel.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    tweetLabel.Text = tweet.Text;
                });
            }
            else
            {
                tweetLabel.Text = tweet.Text;
            }

            if (replyLabel.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    replyLabel.Text = "@" + tweet.Author.ScreenName + " " + replyTextBox.Text;
                });
            }
            else
            {
                replyLabel.Text = "@" + tweet.Author.ScreenName + " " + replyTextBox.Text;
            }

            if (authorPictureBox.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    authorPictureBox.Image = null;
                });
            }
            else
            {
                authorPictureBox.Image = null;
            }

            BackgroundWorker pictureBw = new BackgroundWorker();
            pictureBw.DoWork += new DoWorkEventHandler(pictureBw_DoWork);
            pictureBw.RunWorkerAsync(tweet);
        }

        void pictureBw_DoWork(object sender, DoWorkEventArgs e)
        {
            TwitterSearchStatus tweet = (TwitterSearchStatus)e.Argument;

            if (authorPictureBox.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    authorPictureBox.Load(tweet.Author.ProfileImageUrl);
                });
            }
            else
            {
                authorPictureBox.Load(tweet.Author.ProfileImageUrl);
            }
        }

        private void UpdateTweetGroupBox(string text)
        {
            if (tweetGroupBox.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    tweetGroupBox.Text = text;
                });
            }
            else
            {
                tweetGroupBox.Text = text;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Size = sizeMedium;

            if (e.Error != null)
            {
                statusLabel.Text = "Error!";
            }
            else if (e.Result == null)
            {
                statusLabel.Text = "No matching search results found.";
            }
            else
            {
                statusLabel.Text = "Finished searching Twitter! Found " + e.Result.ToString() + " tweet(s).";
                postReplyButton.Enabled = true;
                deleteTweetButton.Enabled = true;
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            findTweetsButton.Enabled = !string.IsNullOrWhiteSpace(searchTextBox.Text);
        }

        private void replyTextBox_TextChanged(object sender, EventArgs e)
        {
            replyLabel.Text = authorLabel.Text + " " + replyTextBox.Text;
        }

        private void searchTextBox_MouseHover(object sender, EventArgs e)
        {
            /* show some search tips */
            searchToolTip.Show("You can use AND and OR to further refine searches.\n\n" +
                "To exclude a keyword, prefix it with \"-\". Ex: to ignore \"bieber\", put \"-bieber\" (without quotes).\n\n" +
                "To search for an exact phrase, wrap it in quotes. Ex: \"Going on sale\" (with quotes) would match\n\"When are tickets going on sale\" but not \"When are tickets going to go on sale\".\n\n" + 
                "To search for retweets, put \"RT @UserName\" (with quotes).", searchTextBox);
        }
    }
}
