using System;
using ColorCode;
using ColorCode.Common;
using ColorCode.Compilation.Languages;
using ColorCodeToXaml.Common;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Portable.Xaml;

namespace ColorCodeToXaml;

[INotifyPropertyChanged]
public partial class MainViewModel
{
	[ObservableProperty]
	private string code;

    [ObservableProperty]
    private FormattedString outputFormattedString;

    [ObservableProperty]
    private string output;

    [ObservableProperty]
    private ILanguage language = ColorCode.Languages.Xml;

	[RelayCommand]
	void Convert()
	{
        var formatter = new FormattedStringFormatter();
        var fs = new FormattedString();
        formatter.FormatString(Code, Language, fs);

        Output = XamlServices.Save(fs);

        OutputFormattedString = fs;
    }

    [RelayCommand]
    void Copy()
    {
        Clipboard.SetTextAsync(Output);
        Toast.Make("Copied", ToastDuration.Short, 18).Show();
    }
}

