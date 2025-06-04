using Silk.NET.OpenGL;

namespace Hectix.Renderer.OpenGL;

public class OpenGLRenderer(GL gl)
{
    private readonly GL gl = gl;

    public void Initialize()
    {
        gl.Enable(GLEnum.Blend);
        // enables alpha blending and transparancy
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
    public void BeginFrame(float deltaTime)
    {
        
    }

    public void EndFrame()
    {
        
    }
}