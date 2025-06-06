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

using Silk.NET.Input;
using System.Numerics;

namespace Hectix.Input;

public class SilkInput
{
    private readonly IKeyboard keyboard;
    private readonly IMouse mouse;

    private readonly HashSet<Key> currentKeys = [];
    private HashSet<Key> lastKeys = [];

    private readonly HashSet<MouseButton> currentMouseButtons = [];
    private HashSet<MouseButton> lastMouseButtons = [];

    private Vector2 mousePosition;
    private float scrollDelta;

    public SilkInput(IInputContext input)
    {
        keyboard = input.Keyboards[0];
        mouse = input.Mice[0];

        keyboard.KeyDown += (keyboard, key, scancode) => currentKeys.Add(key);
        keyboard.KeyUp += (keyboard, key, scancode) => currentKeys.Remove(key);

        mouse.MouseDown += (m, b) => currentMouseButtons.Add(b);
        mouse.MouseUp += (m, b) => currentMouseButtons.Remove(b);
        mouse.MouseMove += (m, pos) => mousePosition = pos;
        mouse.Scroll += (m, offset) => scrollDelta = offset.Y;
    }

    public void Update()
    {
        lastKeys = [.. currentKeys];
        lastMouseButtons = [.. currentMouseButtons];
        scrollDelta = 0;
    }

    public bool IsKeyDown(Key key) => currentKeys.Contains(key);
    public bool WasKeyPressed(Key key) => currentKeys.Contains(key) && !lastKeys.Contains(key);
    public bool WasKeyReleased(Key key) => !currentKeys.Contains(key) && lastKeys.Contains(key);

    public bool IsMouseButtonDown(MouseButton button) => currentMouseButtons.Contains(button);
    public bool WasMousePressed(MouseButton button) => currentMouseButtons.Contains(button) && !lastMouseButtons.Contains(button);
    public bool WasMouseReleased(MouseButton button) => !currentMouseButtons.Contains(button) && lastMouseButtons.Contains(button);
    public Vector2 GetMousePosition() => mousePosition;
    public float GetScrollDelta() => scrollDelta;
}
