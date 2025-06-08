/*
 * Hectix Engine - 2D Game Engine
 * Copyright (C) 2025 Seth Israel
 *
 * This file is part of Hectix Engine.
 *
 * Hectix Engine is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Hectix Engine is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Hectix Engine.  If not, see <https://www.gnu.org/licenses/>.
 */

using Hectix.Editor.Panels;
using Hectix.ImGui;

namespace Hectix.Editor;

public class MainDockSpace(HectixEditorApp editor)
{
    unsafe private HectixImGuiIOPtr io = HectixImGui.GetIO();
    private readonly HierarchyPanel hierarchy = new(editor);
    private readonly InspectorPanel inspector = new();

    public void Render()
    {
        io?.AddFontFromFileTTF("res/fonts/InterVariable.ttf", 16.0f);
        hierarchy?.Render();
        inspector.Render();
    }
}

// TODO: MAP THIS IN MY IMGUI WRAPPER
/*
public void Render()
{
    !var windowFlags = ImGuiNET.ImGuiWindowFlags.MenuBar
    !                  | ImGuiNET.ImGuiWindowFlags.NoDocking
    !                  | ImGuiNET.ImGuiWindowFlags.NoTitleBar
    !                  | ImGuiNET.ImGuiWindowFlags.NoCollapse
    !                  | ImGuiNET.ImGuiWindowFlags.NoResize
    !                  | ImGuiNET.ImGuiWindowFlags.NoMove
    !                  | ImGuiNET.ImGuiWindowFlags.NoBringToFrontOnFocus
    !                  | ImGuiNET.ImGuiWindowFlags.NoNavFocus;

    var viewport = ImGuiNET.ImGui.GetMainViewport();
    !ImGuiNET.ImGui.SetNextWindowPos(viewport.Pos);
    !ImGuiNET.ImGui.SetNextWindowSize(viewport.Size);
    ImGuiNET.ImGui.SetNextWindowViewport(viewport.ID);
    ImGuiNET.ImGui.PushStyleVar(ImGuiNET.ImGuiStyleVar.WindowRounding, 0.0f);
    ImGuiNET.ImGui.PushStyleVar(ImGuiNET.ImGuiStyleVar.WindowBorderSize, 0.0f);

    ImGuiNET.ImGui.Begin("MainDockSpace", windowFlags);
    ImGuiNET.ImGui.PopStyleVar(2);

    var dockspaceId = ImGuiNET.ImGui.GetID("MainDockSpace");
    ImGuiNET.ImGui.DockSpace(dockspaceId);

    hierarchy.Render();

    ImGuiNET.ImGui.End();
}
*/