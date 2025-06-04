using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Core.Contexts;
using Silk.NET.Input;

namespace Hectix.Engine.Core;

public class Window
{
    public event Action<float>? OnEditorRender;
    public event Action? OnEditorLoad;
    public event Action? OnEditorClosing;
    public string Title { get; set; } = "Hectix Engine";
    public Scene scene = new();
    private IWindow? window;
    private IInputContext? input;

    public void Run()
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(1920, 1080);
        options.Title = Title;

        window = Silk.NET.Windowing.Window.Create(options);

        window.Load += OnLoad;
        window.Render += OnRender;
        window.Resize += OnResize;
        window.Closing += OnClosing;

        window.Run();
    }

    private void OnLoad()
    {
        input = window!.CreateInput();
        OnEditorLoad?.Invoke();
    }

    public void OnRender(double delta)
    {
        OnEditorRender?.Invoke((float)delta);
    }

    private void OnResize(Vector2D<int> newSize)
    {
    }

    private void OnClosing()
    {
        OnEditorClosing?.Invoke();
    }

    public IGLContextSource GLContext => window!;
    public IInputContext InputContext => input!;
    public Vector2D<int> Size => window!.Size;
}