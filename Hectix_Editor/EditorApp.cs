using Hectix.Engine.Core;
using Hectix.ImGui.Backends;
using Hectix.Input;
using Hectix.Renderer;
using Silk.NET.OpenGL;

namespace Hectix.Editor;

public class EditorApp
{
    public static SceneManager sceneManager = new();
    private Window? window;
    private ImGuiOpenGL? imGuiOpenGL;
    private readonly MenuBar menuBar = new();
    private InputManager? input;
    private GL? gl;
    private OpenGLRenderer? renderer;

    public void Run()
    {
        window = new();
        window.OnEditorLoad += OnLoad;
        window.OnEditorRender += OnRender;
        window.OnEditorClosing += OnClosing;
        window.Run();
    }

    private void OnLoad()
    {
        gl = new(window?.GLContext.GLContext);
        renderer = new(gl);
        renderer.Initialize();
        input = new(window!.InputContext);
        imGuiOpenGL = new();
        imGuiOpenGL.Initialize(window.GLContext, window.InputContext);
    }

    private void OnRender(float deltaTime)
    {
        input!.Update();

        renderer?.SetViewPort(0, 0, (uint)window!.Size.X, (uint)window!.Size.Y);
        renderer?.ClearColor(0, 0, 0, 1);

        imGuiOpenGL?.BeginFrame(deltaTime);

        menuBar.Render();

        imGuiOpenGL?.EndFrame();
    }

    private void OnClosing()
    {
        
    }
}