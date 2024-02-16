using System;
using System.ComponentModel;

namespace PocApp;

public class ImageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private State state = State.None;
    public State State { get => state; private set => SetState(value); }

    private string mainImageSource = null;
    public string MainImageSource
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

    private void SetState(State value)
    {
        if (value == state)
            return;

        state = value;

        switch (State)
        {
            case State.Intro:
                {
                    Uri uri = new("ms-appx:///Assets/quiz_intro_main.png");
                    MainImageSource = uri.AbsolutePath;
                }
                break;
            case State.Conditions:
                {
                    Uri uri = new("ms-appx:///Assets/quiz_conditions_main.png");
                    MainImageSource = uri.AbsolutePath;
                }
                break;
        }

        state = value;
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
