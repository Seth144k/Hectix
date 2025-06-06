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
using Silk.NET.Core.Contexts;
using Silk.NET.Input;
using Hectix.Window;

namespace Hectix.Editor;

using Hectix.ImGui;
using Hectix.Renderer;

public class EditorApp
{
    private readonly IHectixWindow window;
    private HectixImGuiOpenGL? imGuiOpenGL;
    private IHectixRenderer? renderer;

    public EditorApp(IHectixWindow window)
    {
        this.window = window;
        window.OnLoad += OnLoad;
        window.OnRender += OnRender;
        window.OnClosing += OnClosing;
    }

    public void Run() => window.Run();

    private void OnLoad()
    {
        var gl = window.GetGL();
        renderer = new OpenGLRenderer(gl);
        renderer.Initialize();
        imGuiOpenGL = new();
        imGuiOpenGL.Initialize((IGLContextSource)window.GetContext(), (IInputContext)window.GetInput());

        Console.WriteLine("Editor Loaded!");
    }

    private void OnRender(float deltaTime)
    {
        var size = window.Size;
        renderer!.SetViewPort(0, 0, (uint)size.Width, (uint)size.Height);
        renderer.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
        renderer.BeginFrame(deltaTime);
        imGuiOpenGL?.BeginFrame(deltaTime);
        HectixImGui.Begin("Hi", true);
        HectixImGui.End();
        imGuiOpenGL?.EndFrame();
        renderer.EndFrame();
    }

    private void OnClosing()
    {

    }
}