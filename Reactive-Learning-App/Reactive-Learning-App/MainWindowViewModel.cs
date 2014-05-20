using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using ReactiveUI;

namespace Reactive_Learning_App
{
    public class MainWindowViewModel : ReactiveObject
    {
        public TwitterContext TwitterContext { get; set; }

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

            TwitterContext = new TwitterContext(auth);

            ReloadTweetsCommand = new ReactiveCommand();
            ReloadTweetsCommand.RegisterAsyncTask(_ => ReloadTweets());

            Observable.Interval(TimeSpan.FromMinutes(15), RxApp.TaskpoolScheduler).InvokeCommand(ReloadTweetsCommand);

            NewTweetCommand =
                new ReactiveCommand(this.WhenAnyValue(f => f.NewTweetText.Length,count => count > 0 && count <= 140));
            NewTweetCommand.RegisterAsyncTask(_ => SendTweet());
        }

        public ReactiveCommand ReloadTweetsCommand { get; private set; }
        public ReactiveCommand NewTweetCommand { get; private set; }

        private async Task ReloadTweets()
        {
            var tweets =
                TwitterContext.Status.Where(f => f.Type == StatusType.Home)
                    .Select(f => new TweetViewModel(f.User.Name, f.Text, f.User.ProfileImageUrl))
                    .ToListAsync();
            Tweets = await tweets;
        }

        private async Task SendTweet()
        {
            var text = NewTweetText;
            NewTweetText = "";
            await TwitterContext.TweetAsync(text);
            await ReloadTweets();
        }

        private List<TweetViewModel> _tweets;
        public List<TweetViewModel> Tweets
        {
            get { return _tweets; }
            set { this.RaiseAndSetIfChanged(ref _tweets, value); }
        }

        private string _newTweetText;
        public string NewTweetText
        {
            get { return _newTweetText; }
            set { this.RaiseAndSetIfChanged(ref _newTweetText, value); }
        }
    }
}
