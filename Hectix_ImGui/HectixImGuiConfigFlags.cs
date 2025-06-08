using ImGuiNET;

namespace Hectix.ImGui;

public static class HectixImGuiConfigFlags
{
    public static ImGuiConfigFlags None => ImGuiConfigFlags.None;
    public static ImGuiConfigFlags NavEnableKeyboard => ImGuiConfigFlags.NavEnableKeyboard;
    public static ImGuiConfigFlags NavEnableGamepad => ImGuiConfigFlags.NavEnableGamepad;
    public static ImGuiConfigFlags DockingEnable => ImGuiConfigFlags.DockingEnable;
    public static ImGuiConfigFlags ViewportsEnable => ImGuiConfigFlags.ViewportsEnable;
    public static ImGuiConfigFlags DpiEnableScaleViewports => ImGuiConfigFlags.DpiEnableScaleViewports;
    public static ImGuiConfigFlags DpiEnableScaleFonts => ImGuiConfigFlags.DpiEnableScaleFonts;
    public static ImGuiConfigFlags IsSRGB => ImGuiConfigFlags.IsSRGB;
    public static ImGuiConfigFlags IsTouchScreen => ImGuiConfigFlags.IsTouchScreen;
}