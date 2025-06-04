namespace Hectix.Editor.Panels;

using Hectix.Engine.Entities;
using ImGuiNET;

public class HierarchyPanel : IPanel
{
    public LinkedList<GameObject>? GameObjects { get; set; }
    private readonly ImGuiWindowFlags WindowFlags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
    public void Render()
    {
        ImGui.Begin("Hierarchy", WindowFlags);

        ImGui.End();
    }
}