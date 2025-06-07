using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.Windowing.Sdl;

namespace Hectix.Window.SDL;

public class SDLWindow : IHectixWindow
{
    private Silk.NET.Windowing.IWindow _window;
    private GL? gl;

    public event Action<float>? OnRender;
    public event Action? OnLoad;
    public event Action? OnClosing;

    public string Title
    {
        get => _window.Title;
        set => _window.Title = value;
    }

    public Size Size => new(_window.Size.X, _window.Size.Y);

    public SDLWindow(int width = 1920, int height = 1080, string title = "Hectix Engine")
    {
        SdlWindowing.Use();

        var options = WindowOptions.Default with
        {
            Size = new Silk.NET.Maths.Vector2D<int>(width, height),
            Title = title,
            API = new GraphicsAPI(
                ContextAPI.OpenGL,
                ContextProfile.Core,
                ContextFlags.Default,
                new APIVersion(3, 3)
            )
        };

        _window = Silk.NET.Windowing.Window.Create(options);

        // Hook Silk.NET events and forward them
        _window.Load += () =>
        {
            gl = GL.GetApi(_window);
            OnLoad?.Invoke();
        };

        _window.Render += delta =>
        {
            OnRender?.Invoke((float)delta);
        };

        _window.Closing += () =>
        {
            OnClosing?.Invoke();
        };
    }

    public void Run()
    {
        _window.Run();
    }

    public object GetContext()
    {
        return _window;
    }

    public object GetInput()
    {
        return _window.CreateInput();
    }

    public GL GetGL()
    {
        return gl!;
    }
}