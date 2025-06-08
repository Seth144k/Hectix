using ImGuiNET;
using Silk.NET.OpenGL;
using System;

namespace Hectix.ImGui
{
    public class HectixImGuiIOPtr(ImGuiIOPtr io)
    {
        public ImGuiIOPtr io = io;

        public float DeltaTime
        {
            get => io.DeltaTime;
            set => io.DeltaTime = value;
        }

        public float Framerate => io.Framerate;

        public System.Numerics.Vector2 DisplaySize
        {
            get => io.DisplaySize;
            set => io.DisplaySize = value;
        }

        public bool WantCaptureKeyboard => io.WantCaptureKeyboard;
        public bool WantCaptureMouse => io.WantCaptureMouse;
        public bool WantTextInput => io.WantTextInput;

        public ImGuiConfigFlags ConfigFlags
        {
            get => io.ConfigFlags;
            set => io.ConfigFlags = value;
        }

        public void EnableDocking(bool enable = true)
        {
            if (enable)
                io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            else
                io.ConfigFlags &= ~ImGuiConfigFlags.DockingEnable;
        }

        public void EnableViewports(bool enable = true)
        {
            if (enable)
                io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
            else
                io.ConfigFlags &= ~ImGuiConfigFlags.ViewportsEnable;
        }

        /// <summary>
        /// Loads a font from file and optionally sets it as the default font.
        /// </summary>
        /// <param name="path">Path to the .ttf file</param>
        /// <param name="size">Font size in pixels</param>
        /// <param name="setAsDefault">Whether to set this as the default font</param>
        /// <returns>The ImFontPtr reference</returns>
        public ImFontPtr AddFontFromFileTTF(string path, float size)
        {
            // ✅ Explicitly cast io.Fonts to ImFontAtlasPtr
            ImFontAtlasPtr fonts = io.Fonts;

            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Font path cannot be null or empty.");

            return fonts.AddFontFromFileTTF(path, size);
        }
    }
}