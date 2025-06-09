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

using Hectix.Renderer.OpenGL;
using Hectix.ImGui.Backends.OpenGL;
using Hectix.Engine.Core;
using Hectix.Window;
using Hectix.Editor.Panels;
using Hectix.Engine.Entities;
using Hectix.ImGui;

namespace Hectix.Editor;

public class HectixEditorApp
{
    public Scene CurrentScene { get; set; } = new Scene();
    private HectixImGuiIOPtr? io;
    public HectixProject CurrentProject { get; private set; } = null!;
    private readonly string? projectFilePath;
    private MainDockSpace? mainDockSpace;
    public GameObject? SelectedGameObject { get; set; }
    private readonly IHectixWindow window;
    private HectixImGuiOpenGL? imGuiOpenGL;
    private OpenGLRenderer? renderer;
    private readonly MenuBar menuBar = new();
    public HierarchyPanel hierarchyPanel;

    public HectixEditorApp(IHectixWindow window, string? projectFilePath)
    {
        this.window = window;
        this.projectFilePath = projectFilePath;
        window.Title = "Hectix Engine - Editor";
        window.OnLoad += OnLoad;
        window.OnRender += OnRender;
        window.OnClosing += OnClosing;
        hierarchyPanel = new(this);
    }

    public void Run() => window.Run();

    private void OnLoad()
    {
        HectixImGui.CreateContext();
        io = HectixImGui.GetIO();
        var gl = window.GetGL();
        mainDockSpace = new(this);
        io.ConfigFlags = HectixImGuiConfigFlags.DockingEnable;
        renderer = new OpenGLRenderer(gl);
        renderer.Initialize();
        imGuiOpenGL = new();
        imGuiOpenGL.Initialize(window.GetContext(), window.GetInput());
        //Scene temp = new();
        //CurrentScene = temp;
        if (!string.IsNullOrEmpty(projectFilePath))
        {
            CurrentScene.Load(projectFilePath);
        }

        Console.WriteLine("Editor Loaded!");
    }

    private void OnRender(float deltaTime)
    {
        var size = window.Size;
        renderer!.SetViewPort(0, 0, (uint)size.Width, (uint)size.Height);
        renderer.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
        renderer.BeginFrame(deltaTime);
        imGuiOpenGL?.BeginFrame(deltaTime);
        menuBar.Render();
        mainDockSpace?.Render();
        imGuiOpenGL?.EndFrame();
        renderer.EndFrame();
    }

    private void OnClosing()
    {

    }
}