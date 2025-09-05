using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Metadata;

namespace AvaloniaTemplate.Views.SettingsComponent;

public class SettingsBlock : TemplatedControl
{
    public static readonly StyledProperty<object?> ContentProperty =
        ContentControl.ContentProperty.AddOwner<Panel>();

    public static readonly StyledProperty<string?> BlockTitleProperty =
        AvaloniaProperty.Register<SettingsBlock, string?>(nameof(BlockTitle));

    [Content]
    public object? Content {
        get => GetValue(ContentProperty);
        set {
            if (GetValue(ContentProperty) is ILogical oldLogical) LogicalChildren.Remove(oldLogical);
            SetValue(ContentProperty, value);
            if (value is ILogical newLogical) LogicalChildren.Add(newLogical);
        }
    }

    public string? BlockTitle
    {
        get => GetValue(BlockTitleProperty);
        set => SetValue(BlockTitleProperty, value);
    }
}
