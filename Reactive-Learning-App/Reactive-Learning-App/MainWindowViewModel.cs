using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Reactive_Learning_App
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            Tweets = new ReactiveList<TweetViewModel>();
            Tweets.Add(new TweetViewModel("Woftam1"));
            Tweets.Add(new TweetViewModel("Woftam2"));
            Tweets.Add(new TweetViewModel("Woftam3"));
            Tweets.Add(new TweetViewModel("Woftam4"));
            Tweets.Add(new TweetViewModel("Woftam5"));
        }

        private ReactiveList<TweetViewModel> _tweets;
        public ReactiveList<TweetViewModel> Tweets
        {
            get { return _tweets; }
            set { this.RaiseAndSetIfChanged(ref _tweets, value); }
        }
    }
}
