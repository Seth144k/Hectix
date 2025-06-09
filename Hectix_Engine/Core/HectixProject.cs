using Tomlyn;

namespace Hectix.Engine.Core;

public class HectixProject
{
    public string Name { get; private set; } = "";
    public string MainScene { get; private set; } = "";
    public string RootPath { get; private set; } = "";

    public static HectixProject Load(string projectFilePath)
    {
        var fileText = File.ReadAllText(projectFilePath);
        var model = Toml.ToModel(fileText);

        var project = new HectixProject
        {
            Name = (string)model["project_name"]!,
            MainScene = (string)model["main_scene"]!,
            // for relative paths
            RootPath = Path.GetDirectoryName(projectFilePath)!
        };

        return project;
    }
}