using System.Windows;
using ReactiveUI;

namespace Reactive_Learning_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :  IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Tweets, v => v.Tweets.ItemsSource));
                d(this.Bind(ViewModel, vm => vm.NewTweetText, v => v.NewTweetText.Text));
                d(this.BindCommand(ViewModel, vm => vm.NewTweetCommand, v => v.SendTweet));
                ViewModel.ReloadTweetsCommand.Execute();
            });
        }

        public static readonly DependencyProperty ViewModelProperty;

        static MainWindow()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MainWindowViewModel), typeof(MainWindow));
        }

        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowViewModel)value; }
        }
    }
}
