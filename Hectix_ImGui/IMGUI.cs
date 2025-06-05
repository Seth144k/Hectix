namespace Hectix.ImGui;

using ImGuiNET;

public static class IMGUI
{
    // MainMenuBar
    public static bool BeginMainMenuBar() => ImGui.BeginMainMenuBar();
    public static void EndMainMenuBar() => ImGui.EndMainMenuBar();

    // Menus
    public static bool BeginMenu(string label) => ImGui.BeginMenu(label);
    public static void EndMenu() => ImGui.EndMenu();

    public static bool MenuItem(string label) => ImGui.MenuItem(label);

    // Windows
    public static bool Begin(string name, bool open = default, ImGuiWindowFlags flags = 0)
        => ImGui.Begin(name, ref open, flags);
    public static void End() => ImGui.End();

    // Text
    public static void Text(string text) => ImGui.Text(text);
    public static void TextColored(System.Numerics.Vector4 col, string text) => ImGui.TextColored(col, text);
    public static void TextWrapped(string text) => ImGui.TextWrapped(text);

    // Buttons
    public static bool Button(string label) => ImGui.Button(label);
    public static bool SmallButton(string label) => ImGui.SmallButton(label);

    // Input
    public static bool InputText(string label, ref string text, uint maxLength = 256, ImGuiInputTextFlags flags = 0)
        => ImGui.InputText(label, ref text, maxLength, flags);

    public static bool InputInt(string label, ref int value, int step = 1, int stepFast = 100, ImGuiInputTextFlags flags = 0)
        => ImGui.InputInt(label, ref value, step, stepFast, flags);

    public static bool InputFloat(string label, ref float value, float step = 0, float stepFast = 0, string format = "%.3f", ImGuiInputTextFlags flags = 0)
        => ImGui.InputFloat(label, ref value, step, stepFast, format, flags);

    // Checkboxes
    public static bool Checkbox(string label, ref bool value) => ImGui.Checkbox(label, ref value);

    // Sliders
    public static bool SliderFloat(string label, ref float value, float min, float max, string format = "%.3f", ImGuiSliderFlags flags = 0)
        => ImGui.SliderFloat(label, ref value, min, max, format, flags);

    public static bool SliderInt(string label, ref int value, int min, int max, string format = "%d", ImGuiSliderFlags flags = 0)
        => ImGui.SliderInt(label, ref value, min, max, format, flags);

    // Combo boxes
    public static bool BeginCombo(string label, string previewValue, ImGuiComboFlags flags = 0)
        => ImGui.BeginCombo(label, previewValue, flags);
    public static void EndCombo() => ImGui.EndCombo();

    // Selectable
    public static bool Selectable(string label, bool selected = false, ImGuiSelectableFlags flags = 0, System.Numerics.Vector2 size = default)
        => ImGui.Selectable(label, selected, flags, size);
    public static void EndChild() => ImGui.EndChild();

    // Columns
    public static void Columns(int count = 1, string? id = null, bool border = true)
        => ImGui.Columns(count, id, border);
    public static void NextColumn() => ImGui.NextColumn();

    // Tree nodes
    public static bool TreeNode(string label) => ImGui.TreeNode(label);
    public static void TreePop() => ImGui.TreePop();

    // Focus
    public static void SetKeyboardFocusHere(int offset = 0) => ImGui.SetKeyboardFocusHere(offset);

    // Misc
    public static void Separator() => ImGui.Separator();
    public static void SameLine(float offsetFromStartX = 0, float spacing = -1) => ImGui.SameLine(offsetFromStartX, spacing);
    public static void NewLine() => ImGui.NewLine();

    // Tooltip
    public static void BeginTooltip() => ImGui.BeginTooltip();
    public static void EndTooltip() => ImGui.EndTooltip();
    public static void SetTooltip(string text) => ImGui.SetTooltip(text);

    // Color editor
    public static bool ColorEdit3(string label, ref System.Numerics.Vector3 col, ImGuiColorEditFlags flags = 0)
        => ImGui.ColorEdit3(label, ref col, flags);
    public static bool ColorEdit4(string label, ref System.Numerics.Vector4 col, ImGuiColorEditFlags flags = 0)
        => ImGui.ColorEdit4(label, ref col, flags);
}