using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PocApp;

public class ImageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private State state = State.None;
    public State State { get => state; private set => SetState(value); }

    private BitmapImage mainImageSource = null;
    public BitmapImage MainImageSource
    {
        get => mainImageSource;
        set
        {
            mainImageSource = value;
            OnPropertyChanged(nameof(MainImageSource));
        }
    }

    public ImageViewModel()
    {
        State = State.Intro;
    }

    public void PointerPressed()
    {
        switch (State)
        {
            case State.Intro:
                State = State.Conditions;
                break;
            case State.Conditions:
                State = State.Intro;
                break;
        }
    }

    private async void SetState(State value)
    {
        if (value == state)
            return;

        state = value;

        switch (State)
        {
            case State.Intro:
                MainImageSource = await GetImageSourceFromAssets("quiz_intro_main.png");
                break;
            case State.Conditions:
                MainImageSource = await GetImageSourceFromAssets("quiz_conditions_main.png");
                break;
        }

        state = value;
    }

    private static async Task<BitmapImage> GetImageSourceFromAssets(string path)
    {
        StorageFile file = await StorageFile.GetFileFromPathAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Assets\\{path}"));
        using IRandomAccessStream fileStream = await file.OpenReadAsync();
        BitmapImage bitmapImage = new();
        await bitmapImage.SetSourceAsync(fileStream);

        return bitmapImage;
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
