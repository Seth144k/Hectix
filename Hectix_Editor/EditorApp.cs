using Hectix.Engine.Core;
using Hectix.ImGui.Backends;
using Hectix.Input;
using Hectix.Renderer.OpenGL;
using Hectix.Window;
using Silk.NET.OpenGL;

namespace Hectix.Editor;

public class EditorApp
{
    public static SceneManager sceneManager = new();
    private readonly IHectixWindow window;
    private ImGuiOpenGL? imGuiOpenGL;
    private readonly MenuBar menuBar = new();
    private InputManager? input;
    private GL? gl;
    private OpenGLRenderer? renderer;

    public EditorApp(IHectixWindow window)
    {
        this.window = window;
        window.OnLoad += OnLoad;
        window.OnRender += OnRender;
        window.OnClosing += OnClosing;
    }

    public void Run()
    {
        window.Run();
    }

    private void OnLoad()
    {
        //gl = new(((GL)window.GetContext()).GL);
        //renderer = new(gl);
        //renderer.Initialize();
        input = new((Silk.NET.Input.IInputContext)window.GetInput());

        imGuiOpenGL = new();
        imGuiOpenGL.Initialize(
            (Silk.NET.Core.Contexts.IGLContextSource)window.GetContext(),
            (Silk.NET.Input.IInputContext)window.GetInput()
        );
    }

    private void OnRender(float deltaTime)
    {
        input!.Update();

        var size = window.Size;
        //renderer?.SetViewPort(0, 0, (uint)size.X, (uint)size.Y);
        renderer?.ClearColor(0, 0, 0, 1);

        imGuiOpenGL?.BeginFrame(deltaTime);
        menuBar.Render();
        imGuiOpenGL?.EndFrame();
    }

    private void OnClosing()
    {
        // Cleanup if needed
    }
}