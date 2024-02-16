using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace PocApp;

public sealed partial class ImagePage : Page
{
    public ImagePage()
    {
        InitializeComponent();
        PointerPressed += ImagePage_PointerPressed;
        ImageViewModel model = (ImageViewModel)DataContext;
    }

    private void ImagePage_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        ImageViewModel model = (ImageViewModel)DataContext;
        model.PointerPressed();
    }
}
