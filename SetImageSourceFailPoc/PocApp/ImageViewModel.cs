using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;

namespace PocApp;

public partial class ImageViewModel : ObservableObject
{
    [ObservableProperty]
    private State state = State.None;

    [ObservableProperty]
    private string mainImageSource = string.Empty;

    private readonly Dictionary<State, string> _imageSources = new()
    {
        { State.Intro, "/Assets/quiz_intro_main.png" },
        { State.Conditions, "/Assets/quiz_conditions_main.png" },
    };

    public ImageViewModel()
    {
        State = State.Intro;
    }

    partial void OnStateChanged(State value)
    {
        if (_imageSources.TryGetValue(value, out string source) is false)
        {
            return;
        }

        MainImageSource = source;
    }

    [RelayCommand]
    // This auto-generates a "SwapStateCommand".
    private void SwapState()
    {
        State = State switch
        {
            State.Intro => State.Conditions,
            State.Conditions => State.Intro,
            _ => State.None,
        };
    }
}
