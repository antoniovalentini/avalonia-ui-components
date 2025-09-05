using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaTemplate.Views;

public partial class RallyMaterialView : UserControl
{
    public const string ViewName = nameof(RallyMaterialView);

    public RallyMaterialView()
    {
        InitializeComponent();
        AccountsList.ItemsSource = Accounts;
    }

    private void NavigateBack_OnClick(object? sender, RoutedEventArgs e)
    {
        App.Instance.Messenger.Send(new NavigationRequestMessage(SelectionView.ViewName));
    }

    private List<Account> Accounts { get; } =
    [
        new("Checking", "- - - - - - 1234", "$ 2,215.13"),
        new("Home Savings", "- - - - - - 5678", "$ 8,676.88"),
        new("Car Savings", "- - - - - - 9012", "$ 987.48"),
        new("Vacation", "- - - - - - 3456", "$ 253.00")
    ];
}

public record Account(string Name, string Number, string Amount);

