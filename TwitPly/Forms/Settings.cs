using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetSharp;

namespace TwitPly
{
    public partial class SettingsForm : Form
    {
        private Size sizeSmall = new Size(489, 298);
        private Size sizeLarge = new Size(489, 334);
        private static bool CanSave = false; // basically if the test has passed and any textboxes are filled in

        public SettingsForm()
        {
            InitializeComponent();

            this.Size = sizeSmall;
        }

        /* override showdialog to update any text fields before opening */
        public DialogResult ShowDialogA() 
        {
            consumerKeyTextBox.Text = TwitterSettings.ConsumerKey;
            consumerSecretTextBox.Text = TwitterSettings.ConsumerSecret;
            accessTokenTextBox.Text = TwitterSettings.AccessToken;
            accessTokenSecretTextBox.Text = TwitterSettings.AccessTokenSecret;
            tweetsPerRunTextBox.Text = TwitterSettings.Tweets.ToString();

            return base.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TwitterSettings.SaveCredentials(consumerKeyTextBox.Text, consumerSecretTextBox.Text, accessTokenTextBox.Text, accessTokenSecretTextBox.Text);

            int i;
            int.TryParse(tweetsPerRunTextBox.Text, out i);
            TwitterSettings.Tweets = i;

            TwitterSettings.SaveSettingsFile();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            testButton.Text = "Testing...";
            testButton.Enabled = false;
            cancelButton.Enabled = false;
            saveButton.Enabled = false;
            consumerKeyTextBox.Enabled = false;
            consumerSecretTextBox.Enabled = false;
            accessTokenTextBox.Enabled = false;
            accessTokenSecretTextBox.Enabled = false;

            this.Size = sizeLarge;

            progressBar1.Visible = true;

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompletedTestButton); // different handler for 
            bw.RunWorkerAsync();
        }

        private void credentialTextBoxChange(object sender, EventArgs e)
        {
            if (testButton.Text == "Success!")
            {
                testButton.Text = "Test";
            }

            testButton.Enabled = !(string.IsNullOrWhiteSpace(consumerKeyTextBox.Text) || string.IsNullOrWhiteSpace(consumerSecretTextBox.Text) ||
                    string.IsNullOrWhiteSpace(accessTokenTextBox.Text) || string.IsNullOrWhiteSpace(accessTokenSecretTextBox.Text)) && !bw.IsBusy;

            saveButton.Enabled = !string.IsNullOrEmpty(tweetsPerRunTextBox.Text) && CanSave;
        }

        private void tweetsPerRunTextBox_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = !string.IsNullOrEmpty(tweetsPerRunTextBox.Text) && CanSave;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            TwitterService service = new TwitterService(consumerKeyTextBox.Text, consumerSecretTextBox.Text, accessTokenTextBox.Text, accessTokenSecretTextBox.Text);

            TwitterUser user = service.VerifyCredentials();

            if (service.Response.InnerException != null)
            {
                TwitterError error = service.Deserialize<TwitterError>(service.Response.Response);
                if (!string.IsNullOrEmpty(error.ErrorMessage))
                {
                    e.Result = error; // return the error object on failure
                }
                else
                {
                    e.Result = null; // err, dunno. return null
                }
            }
            else if (user != null)
            {
                e.Result = user; // return user object on success
            }
            else
            {
                e.Result = null; // unknown error
            }
        }

        private void bw_RunWorkerCompletedTestButton(object sender, RunWorkerCompletedEventArgs e)
        {
            testButton.Text = "Test";
            testButton.Enabled = true;
            cancelButton.Enabled = true;
            saveButton.Enabled = CanSave;
            consumerKeyTextBox.Enabled = true;
            consumerSecretTextBox.Enabled = true;
            accessTokenTextBox.Enabled = true;
            accessTokenSecretTextBox.Enabled = true;

            progressBar1.Visible = false;

            this.Size = sizeSmall;

            if (e.Result == null) // failed
            {
                MessageBox.Show("Authentication Failed! Please check your credentials and try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result.GetType() == typeof(TwitterError))
            {
                TwitterError error = (TwitterError)e.Result;
                MessageBox.Show("Authentication Failed!\n\nThe Twitter API said: \"" + error.ErrorMessage + "\"\n\nPlease check your credentials and try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result.GetType() == typeof(TwitterUser))// passed
            {
                TwitterUser user = (TwitterUser)e.Result;
                AuthenticationSuccessful(user);
                //MessageBox.Show("Authentication was successful! You are logged in as \"" + user.ScreenName + "\".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AuthenticationSuccessful(TwitterUser user)
        {
            CanSave = true;
            usernameLabel.Text = user.ScreenName;
            saveButton.Enabled = !string.IsNullOrEmpty(tweetsPerRunTextBox.Text);
            saveButton.Text = "Save";
            testButton.Text = "Success!";
            testButton.Enabled = false;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent form from being closed if bw is running
            e.Cancel = bw.IsBusy;
        }

        private void tweetsPerRunTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
