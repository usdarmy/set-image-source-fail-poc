using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;

namespace PocApp;

public partial class App : Application
{
    private Window m_window;

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        Frame frame = new()
        {
            ContentTransitions =
            [
                new NavigationThemeTransition() { DefaultNavigationTransitionInfo = new SuppressNavigationTransitionInfo() }
            ]
        };
        frame.NavigationFailed += Frame_NavigationFailed;
        frame.Navigate(typeof(ImagePage), args.Arguments);
        m_window.Content = frame;
        m_window.Activate();
    }

    private void Frame_NavigationFailed(object sender, Microsoft.UI.Xaml.Navigation.NavigationFailedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
