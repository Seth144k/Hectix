using Hectix.Input;
using Hectix.Renderer.OpenGL;
using Hectix.Window;

namespace Hectix.Editor;

using Hectix.Renderer;

public class EditorApp
{
    private readonly IHectixWindow window;
    private IHectixRenderer? renderer;

    public EditorApp(IHectixWindow window)
    {
        this.window = window;
        window.OnLoad += OnLoad;
        window.OnRender += OnRender;
        window.OnClosing += OnClosing;
    }

    public void Run() => window.Run();

    private void OnLoad()
    {

        var gl = window.GetGL();
        renderer = new OpenGLRenderer(gl);
        renderer.Initialize();

        Console.WriteLine("Editor Loaded!");
    }

    private void OnRender(float deltaTime)
    {
        var size = window.Size;
        renderer!.SetViewPort(0, 0, (uint)size.Width, (uint)size.Height);
        renderer.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);

        renderer.BeginFrame(deltaTime);

        renderer.EndFrame();
    }

    private void OnClosing()
    {
        
    }
}