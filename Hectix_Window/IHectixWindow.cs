using Silk.NET.OpenGL;

namespace Hectix.Window;

public interface IHectixWindow
{
    event Action<float>? OnRender;
    event Action? OnLoad;
    event Action? OnClosing;

    string Title { get; set; }
    void Run();
    Size Size { get; }

    object GetContext();
    object GetInput();
    GL GetGL();
}