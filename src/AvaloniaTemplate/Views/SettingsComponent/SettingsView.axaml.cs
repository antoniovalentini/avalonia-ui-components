using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaTemplate.Views.SettingsComponent;

public partial class SettingsView : UserControl
{
    public const string ViewName = nameof(SettingsView);

    public SettingsView()
    {
        InitializeComponent();
    }

    private void NavigateBack_OnClick(object? sender, RoutedEventArgs e)
    {
        App.Instance.Messenger.Send(new NavigationRequestMessage(SelectionView.ViewName));
    }
}
