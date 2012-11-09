using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace TwitPly
{
    static class TwitterSettings
    {
        public static string ConsumerKey;
        public static string ConsumerSecret;
        public static string AccessToken;
        public static string AccessTokenSecret;
        public static int Tweets;

        public static string SettingsFile = Application.StartupPath + "/settings.xml";

        /* Attempt to load settings from settings file */
        public static void LoadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(SettingsFile);

                XmlNode consumerKeyNode = xmlDoc.SelectSingleNode("//Settings/Credentials/ConsumerKey");
                XmlNode consumerSecretNode = xmlDoc.SelectSingleNode("//Settings/Credentials/ConsumerSecret");
                XmlNode accessTokenNode = xmlDoc.SelectSingleNode("//Settings/Credentials/AccessToken");
                XmlNode accessTokenSecretNode = xmlDoc.SelectSingleNode("//Settings/Credentials/AccessTokenSecret");
                XmlNode tweetsNode = xmlDoc.SelectSingleNode("//Settings/Tweets");
                
                if (!(string.IsNullOrWhiteSpace(consumerKeyNode.InnerText) || string.IsNullOrWhiteSpace(consumerSecretNode.InnerText) 
                    || string.IsNullOrWhiteSpace(accessTokenNode.InnerText) || string.IsNullOrWhiteSpace(accessTokenSecretNode.InnerText)))
                {
                    SaveCredentials(consumerKeyNode.InnerText, consumerSecretNode.InnerText, accessTokenNode.InnerText, accessTokenSecretNode.InnerText);
                }

                if (!string.IsNullOrWhiteSpace(tweetsNode.InnerText))
                {
                    int i;
                    int.TryParse(tweetsNode.InnerText, out i);
                    Tweets = i;
                }

            }
            else
            {
                CreateDefaultSettingsFile();
            }
        }

        private static void CreateDefaultSettingsFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode settings = doc.CreateElement("Settings");
            doc.AppendChild(settings);

            // "credentials" node

            XmlNode creds = doc.CreateElement("Credentials");
            settings.AppendChild(creds);
            settings.InsertBefore(doc.CreateComment(" Fill in your Twitter Credentials here to have TweetPly auto-load them. "), creds);

            XmlNode consumerKey = doc.CreateElement("ConsumerKey");
            consumerKey.InnerText = ""; // <node></node> instead of <node />
            creds.AppendChild(consumerKey);

            XmlNode consumerSecret = doc.CreateElement("ConsumerSecret");
            consumerSecret.InnerText = ""; // <node></node> instead of <node />
            creds.AppendChild(consumerSecret);

            XmlNode accessToken = doc.CreateElement("AccessToken");
            accessToken.InnerText = ""; // <node></node> instead of <node />
            creds.AppendChild(accessToken);

            XmlNode accessTokenSecret = doc.CreateElement("AccessTokenSecret");
            accessTokenSecret.InnerText = ""; // <node></node> instead of <node />
            creds.AppendChild(accessTokenSecret);

            XmlNode tweets = doc.CreateElement("Tweets");
            tweets.InnerText = ""; // <node></node> instead of <node />
            settings.AppendChild(tweets);
            settings.InsertBefore(doc.CreateComment(" Number of Tweets to fetch (1-1500) "), tweets);

            using (StringWriter sw = new StringWriter())
            using (XmlTextWriter xtw = new XmlTextWriter(sw))
            {
                xtw.Formatting = Formatting.Indented; // for pretty code
                xtw.Indentation = 4;
                settings.WriteTo(xtw);
                File.WriteAllText(SettingsFile, sw.ToString(), Encoding.UTF8);
            }
        }

        public static void SaveSettingsFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode settings = doc.CreateElement("Settings");
            doc.AppendChild(settings);

            // "credentials" node

            XmlNode creds = doc.CreateElement("Credentials");
            settings.AppendChild(creds);
            settings.InsertBefore(doc.CreateComment(" Fill in your Twitter Credentials here to have TweetPly auto-load them. "), creds);

            XmlNode consumerKey = doc.CreateElement("ConsumerKey");
            consumerKey.InnerText = ConsumerKey; // <node></node> instead of <node />
            creds.AppendChild(consumerKey);

            XmlNode consumerSecret = doc.CreateElement("ConsumerSecret");
            consumerSecret.InnerText = ConsumerSecret; // <node></node> instead of <node />
            creds.AppendChild(consumerSecret);

            XmlNode accessToken = doc.CreateElement("AccessToken");
            accessToken.InnerText = AccessToken; // <node></node> instead of <node />
            creds.AppendChild(accessToken);

            XmlNode accessTokenSecret = doc.CreateElement("AccessTokenSecret");
            accessTokenSecret.InnerText = AccessTokenSecret; // <node></node> instead of <node />
            creds.AppendChild(accessTokenSecret);

            XmlNode tweets = doc.CreateElement("Tweets");
            tweets.InnerText = Tweets.ToString(); // <node></node> instead of <node />
            settings.AppendChild(tweets);
            settings.InsertBefore(doc.CreateComment(" Number of Tweets to fetch (1-1500) "), tweets);

            using (StringWriter sw = new StringWriter())
            using (XmlTextWriter xtw = new XmlTextWriter(sw))
            {
                xtw.Formatting = Formatting.Indented; // for pretty code
                xtw.Indentation = 4;
                settings.WriteTo(xtw);
                File.WriteAllText(SettingsFile, sw.ToString(), Encoding.UTF8);
            }
        }

        /* Returns true if a credential is empty */
        public static bool MissingCredential()
        {
            return (string.IsNullOrWhiteSpace(AccessToken) || string.IsNullOrWhiteSpace(AccessTokenSecret) ||
                string.IsNullOrWhiteSpace(ConsumerKey) || string.IsNullOrWhiteSpace(ConsumerSecret));
        }

        /* Just a quicker way to set all four credentials */
        public static void SaveCredentials(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
    }
}
