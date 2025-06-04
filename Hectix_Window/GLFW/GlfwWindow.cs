
namespace Hectix.Window.GLFW;

public class GlfwWindow : IHectixWindow
{
    public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Size Size => throw new NotImplementedException();

    public event Action<float>? OnRender;
    public event Action? OnLoad;
    public event Action? OnClosing;

    public object GetContext()
    {
        throw new NotImplementedException();
    }

    public object GetInput()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}