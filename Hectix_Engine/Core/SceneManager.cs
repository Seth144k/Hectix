namespace Hectix.Engine.Core;

public class SceneManager
{
    public static Scene? CurrentScene { get; set; }

    public static void LoadScene(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Scene file not found", path);

        CurrentScene = Scene.Load(path);
    }

}