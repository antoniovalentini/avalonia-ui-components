using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaTemplate.Views;

public partial class LoginView : UserControl
{
    public const string ViewName = nameof(LoginView);

    public LoginView()
    {
        InitializeComponent();
    }

    private void NavigateBack_OnClick(object? sender, RoutedEventArgs e)
    {
        App.Instance.Messenger.Send(new NavigationRequestMessage(SelectionView.ViewName));
    }
}
