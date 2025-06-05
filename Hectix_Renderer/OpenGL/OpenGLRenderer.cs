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

using Silk.NET.OpenGL;
using Hectix.Renderer;

namespace Hectix.Renderer.OpenGL;

public class OpenGLRenderer : IHectixRenderer
{
    private readonly GL gl;


    public OpenGLRenderer(GL gl)
    {
        this.gl = gl;
    }

    public void Initialize()
    {
        gl.Enable(GLEnum.Blend);
        gl.BlendFunc(GLEnum.SrcAlpha, GLEnum.OneMinusSrcAlpha);
    }

    public void SetViewPort(int x, int y, uint sizeX, uint sizeY)
    {
        gl.Viewport(x, y, sizeX, sizeY);
    }

    public void ClearColor(float r, float g, float b, float a)
    {
        gl.ClearColor(r, g, b, a);
        gl.Clear((uint)ClearBufferMask.ColorBufferBit);
    }

    public void BeginFrame(float deltaTime) { }

    public void EndFrame() { }

    public GL GetGL() => gl!;
}