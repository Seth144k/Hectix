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

using Hectix.Window.SILK;
using Hectix.Editor;
using Hectix.Window.SDL;

using System;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;

class SilkWindow
{
    private IWindow _window = null!;
    private GL _gl = null!;

    public SilkWindow()
    {
        var options = WindowOptions.Default;
        options.Size = new Silk.NET.Maths.Vector2D<int>(800, 600);
        options.Title = "Test Silk.NET Window";

        _window = Window.Create(options);

        _window.Load += OnLoad;
        _window.Render += OnRender;
        _window.Closing += OnClosing;
    }

    private void OnLoad()
    {
        // Initialize OpenGL context
        _gl = GL.GetApi(_window);

        // Setup clear color (optional)
        _gl.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    }

    private void OnRender(double delta)
    {
        // Clear the screen each frame
        _gl.Clear((uint)ClearBufferMask.ColorBufferBit);
    }

    private void OnClosing()
    {
        Console.WriteLine("Window is closing!");
    }

    public void Run()
    {
        _window.Run();
    }
}

class Program
{
    private static void Main()
    {
        var window = new HectixSilkWindow();
        var app = new EditorApp(window);
        app.Run();
    }
}
