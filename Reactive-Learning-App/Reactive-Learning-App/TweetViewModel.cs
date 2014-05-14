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
        private string _TextBlock;
        public string TextBlock
        {
            get { return _TextBlock; }
            set { this.RaiseAndSetIfChanged(ref _TextBlock, value); }
        }

        public TweetViewModel(string text)
        {
            TextBlock = text;
        }
    }
}
