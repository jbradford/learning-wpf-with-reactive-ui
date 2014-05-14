using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Reactive_Learning_App
{
    public class TweetViewModel : ReactiveObject
    {
        private string _tweetText;
        public string TweetText
        {
            get { return _tweetText; }
            set { this.RaiseAndSetIfChanged(ref _tweetText, value); }
        }

        private string _user;
        public string User
        {
            get { return _user; }
            set { this.RaiseAndSetIfChanged(ref _user, value); }
        }

        public TweetViewModel(string user, string tweetText)
        {
            User = user;
            TweetText = tweetText;
        }
    }
}
