using System.Runtime.InteropServices;
using Hectix.ImGui;

namespace Hectix.Editor;

public class MenuBar
{
    public void Render()
    {
        IMGUI.BeginMainMenuBar();
        if (IMGUI.BeginMenu("Scene"))
        {
            if (IMGUI.MenuItem("New Scene"))
            {
            }
            IMGUI.EndMenu();
        }
        if (IMGUI.BeginMenu("Project"))
        {
            if (IMGUI.MenuItem("New Project"))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    
                }
                {
                    return;
                }
            }
            IMGUI.EndMenu();
        }
        if (IMGUI.BeginMenu("Editor"))
        {

        }
        IMGUI.EndMainMenuBar();
    }
}