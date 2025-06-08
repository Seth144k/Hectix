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

using Hectix.Engine.Entities;
using Hectix.ImGui;

namespace Hectix.Editor.Panels;

public class HierarchyPanel(HectixEditorApp editor) : IPanel
{
    public GameObject? SelectedGameObject { get; set; }

    public void Render()
    {
        bool clicked = false;

        HectixImGui.SetNextWindowPosition(new System.Numerics.Vector2(0, 20));
        HectixImGui.SetNextWindowSize(new System.Numerics.Vector2(250, 690));
        HectixImGui.Begin("Hierarchy", HectixImGuiWindowFlags.NoMove | HectixImGuiWindowFlags.NoResize | HectixImGuiWindowFlags.NoCollapse);

        if (HectixImGui.BeginPopupContextWindow("context menu", HectixImGuiPopupFlags.MouseButtonRight))
        {
            if (HectixImGui.MenuItem("Add GameObject"))
            {
                editor.CurrentScene.AddGameObject("New GameObject");
            }
            HectixImGui.EndPopup();
        }

        if (editor.CurrentScene.GameObjects != null)
        {
            foreach (var go in editor.CurrentScene.GameObjects)
            {
                bool selected = go == SelectedGameObject;
                if (HectixImGui.Selectable(go.Name, selected))
                {
                    SelectedGameObject = go;
                    editor.SelectedGameObject = go;
                    clicked = true;
                }
            }

            if (HectixImGui.IsWindowHovered() && HectixImGui.IsMouseClicked(HectixImGuiMouseButton.LEFT) && !clicked)
            {
                SelectedGameObject = null;
                editor.SelectedGameObject = null;
            }
        }

        HectixImGui.End();
    }
}
