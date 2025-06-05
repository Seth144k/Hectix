using Silk.NET.Core.Contexts;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

namespace Hectix.ImGui.Backends.OpenGL;

public class ImGuiOpenGL
{
    private ImGuiController? controller;

    public void Initialize(IGLContextSource window, IInputContext input)
    {
        var gl = GL.GetApi(window);
        controller = new ImGuiController(gl, (IView)window, input);
    }

    public void BeginFrame(float deltaTime)
    {
        controller?.Update(deltaTime);
    }

    public void EndFrame()
    {
        controller?.Render();
    }
}