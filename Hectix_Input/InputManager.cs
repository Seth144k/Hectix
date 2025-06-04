using Silk.NET.Input;
using System.Numerics;

namespace Hectix.Input;

public class InputManager
{
    private readonly IKeyboard keyboard;
    private readonly IMouse mouse;

    private readonly HashSet<Key> currentKeys = [];
    private HashSet<Key> lastKeys = [];

    private readonly HashSet<MouseButton> currentMouseButtons = [];
    private HashSet<MouseButton> lastMouseButtons = [];

    private Vector2 mousePosition;
    private float scrollDelta;

    public InputManager(IInputContext input)
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
