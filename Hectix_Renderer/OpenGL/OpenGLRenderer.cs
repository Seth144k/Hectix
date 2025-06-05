using Silk.NET.OpenGL;
using Hectix.Renderer;

namespace Hectix.Renderer.OpenGL;

public class OpenGLRenderer : IHectixRenderer
{
    private readonly GL gl;


    public OpenGLRenderer(GL gl)
    {
        this.gl = gl;
    }

    public void Initialize()
    {
        gl.Enable(GLEnum.Blend);
        gl.BlendFunc(GLEnum.SrcAlpha, GLEnum.OneMinusSrcAlpha);
    }

    public void SetViewPort(int x, int y, uint sizeX, uint sizeY)
    {
        gl.Viewport(x, y, sizeX, sizeY);
    }

    public void ClearColor(float r, float g, float b, float a)
    {
        gl.ClearColor(r, g, b, a);
        gl.Clear((uint)ClearBufferMask.ColorBufferBit);
    }

    public void BeginFrame(float deltaTime) { }

    public void EndFrame() { }

    public GL GetGL() => gl!;
}