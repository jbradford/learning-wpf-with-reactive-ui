using ReactiveUI;
using ReactiveUI.Xaml;

namespace Reactive_Learning_App
{
    public class AppBootstrapper
    {
        public AppBootstrapper()
        {
            var resolver = RxApp.MutableResolver;

            resolver.Register(() => new TweetLine(), typeof (IViewFor<TweetViewModel>));

            ConfigureLogging();
            ConfigureIdentity();
            ConfigureServiceLocator();
        }

        private static void ConfigureLogging()
        {

        }

        private static void ConfigureIdentity()
        {

        }

        private static void ConfigureServiceLocator()
        {

        }

        public void Run()
        {
            var viewModel = new MainWindowViewModel();
            var view = new MainWindow() { ViewModel = viewModel };
            view.Show();
        }
    }
}