using Avalonia.Controls;
using AvaloniaTemplate.Views.SettingsComponent;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaTemplate.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        CurrentView.Content = new SelectionView();

        App.Instance.Messenger.Register<MainView, NavigationRequestMessage>(this, (_, message) =>
        {
            CurrentView.Content = message.ViewName switch
            {
                LoginView.ViewName => new LoginView(),
                RallyMaterialView.ViewName => new RallyMaterialView(),
                SettingsView.ViewName => new SettingsView(),
                _ => new SelectionView(),
            };
        });
    }
}

public record NavigationRequestMessage(string ViewName);
