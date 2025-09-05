using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaTemplate.Views;

public partial class SelectionView : UserControl
{
    public const string ViewName = nameof(SelectionView);

    public SelectionView()
    {
        InitializeComponent();
    }

    private void NavigateTo_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button { Tag: string tag })
        {
            return;
        }

        App.Instance.Messenger.Send(new NavigationRequestMessage(tag));
    }
}
