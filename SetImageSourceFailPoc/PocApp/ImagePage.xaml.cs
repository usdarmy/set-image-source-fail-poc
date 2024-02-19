using Microsoft.UI.Xaml.Controls;

namespace PocApp;

public sealed partial class ImagePage : Page
{
    private ImageViewModel ViewModel { get; } = new();

    public ImagePage()
    {
        InitializeComponent();
    }
}
