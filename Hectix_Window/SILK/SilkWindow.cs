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

using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Core.Contexts;

namespace Hectix.Window.SILK;

public class SilkWindow : IHectixWindow
{
    public event Action<float>? OnRender;
    public event Action? OnLoad;
    public event Action? OnClosing;
    private GL? gl;

    public string Title { get; set; } = "Hectix Engine";

    private IWindow? window;
    private IInputContext? input;

    public void Run()
    {
        var options = WindowOptions.Default with
        {
            Title = Title,
            Size = new Vector2D<int>(1920, 1080),
            API = new GraphicsAPI(
                ContextAPI.OpenGL,
                ContextProfile.Compatability,
                ContextFlags.Default,
                new APIVersion(3, 3)
            ),
        };

        window = Silk.NET.Windowing.Window.Create(options);

        window.Load += HandleLoad;
        window.Render += delta => OnRender?.Invoke((float)delta);
        window.Closing += () => OnClosing?.Invoke();

        window.Run();
    }

    private void HandleLoad()
    {
        input = window!.CreateInput();
        gl = GL.GetApi(window);
        OnLoad?.Invoke();
    }

    public Size Size => new(window!.Size.X, window!.Size.Y);
    Size IHectixWindow.Size => Size;

    public object GetContext() => window!;
    public object GetInput() => input!;
    public GL GetGL() => gl!;
    public IGLContextSource GetGLContextSource() => window!;
}