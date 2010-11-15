using System;
using System.Linq;
using System.Net;
using System.Net.Browser;
using System.Xml.Linq;
using SlickScrumy.Domain;

namespace SlickScrumy.Service
{
    public class TaskBoardService
    {
        public void FetchSprint(string username, string password)
        {
            HttpWebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp);
            var credential = new NetworkCredential(username, password);

            var webClient = new WebClient()
            {
                UseDefaultCredentials = false,
                Credentials = credential
            };

            var uri = new Uri(string.Format(@"https://scrumy.com/api/scrumies/{0}/sprints/current", username));

            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadCompleted);
            webClient.DownloadStringAsync(uri);
        }

        void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var root = XElement.Parse(e.Result);
            var stories = root.Element("stories");
            var sprint = new Sprint
            {
                Stories =
                    from story in stories.Elements("story")
                    select new Story {Title = story.Element("title").Value}
            };

            if (FetchCompleted != null)
                FetchCompleted(this, new FetchSprintEventArgs {Sprint = sprint});
        }

        public event EventHandler<FetchSprintEventArgs> FetchCompleted;
    }

    public class FetchSprintEventArgs : EventArgs
    {
        public Sprint Sprint { get; set; }
    }
}