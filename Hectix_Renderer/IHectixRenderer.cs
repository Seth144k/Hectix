using Silk.NET.OpenGL;

namespace Hectix.Renderer;

public interface IHectixRenderer
{
    public void Initialize();
    public void BeginFrame(float deltaTime);
    public void EndFrame();
    public void SetViewPort(int x, int y, uint width, uint height);
    void ClearColor(float r, float g, float b, float a);
}