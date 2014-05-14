using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using ReactiveUI;

namespace Reactive_Learning_App
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                    AccessToken = ConfigurationManager.AppSettings["accessToken"],
                    AccessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"]
                }
            };

            var twitterCtx = new TwitterContext(auth);
            Tweets = new ReactiveList<TweetViewModel>(twitterCtx.Status.Where(f => f.Type == StatusType.Home).Select(f => new TweetViewModel(f.User.Name,f.Text)));
        }

        private ReactiveList<TweetViewModel> _tweets;
        public ReactiveList<TweetViewModel> Tweets
        {
            get { return _tweets; }
            set { this.RaiseAndSetIfChanged(ref _tweets, value); }
        }
    }
}
