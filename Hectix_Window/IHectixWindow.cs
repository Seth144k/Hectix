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

using Silk.NET.Core.Contexts;
using Silk.NET.Input;
using Silk.NET.OpenGL;

namespace Hectix.Window;

public interface IHectixWindow
{
    event Action<float>? OnRender;
    event Action? OnLoad;
    event Action? OnClosing;

    string Title { get; set; }
    void Run();
    Size Size { get; }

    IGLContextSource GetContext();
    IInputContext GetInput();
    GL GetGL();
}