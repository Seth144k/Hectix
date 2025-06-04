using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Input;

namespace Hectix.Window.SILK;

public class SilkWindow : IHectixWindow
{
    public event Action<float>? OnRender;
    public event Action? OnLoad;
    public event Action? OnClosing;

    public string Title { get; set; } = "Hectix Engine";

    private IWindow? window;
    private IInputContext? input;

    public void Run()
    {
        var options = WindowOptions.Default with
        {
            Title = Title,
            Size = new Vector2D<int>(1920, 1080),
        };

        window = Silk.NET.Windowing.Window.Create(options);

        window.Load += HandleLoad;
        window.Render += delta => OnRender?.Invoke((float)delta);
        window.Closing += () => OnClosing?.Invoke();

        window.Run();
    }

    private void HandleLoad()
    {
        input = window!.CreateInput();
        OnLoad?.Invoke();
    }

    public Size Size => new(window!.Size.X, window!.Size.Y);
    Size IHectixWindow.Size => throw new NotImplementedException();

    public object GetContext() => window!;
    public object GetInput() => input!;
}