using System.Text.Json;
using System.Text.Json.Serialization;
using Hectix.Engine.Entities;

namespace Hectix.Engine.Core;

public class Scene
{
    [JsonInclude]
    public LinkedList<GameObject> GameObjects { get; set; } = new();

    public LinkedList<GameObject> GetGameObjects() => GameObjects;

    public void AddGameObject(string name)
    {
        GameObjects.AddLast(new GameObject(name));
    }

    public void Save(string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(path, json);
    }

    public static Scene Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Scene file not found", path);

        string json = File.ReadAllText(path);
        Scene? loadedScene = JsonSerializer.Deserialize<Scene>(json);

        if (loadedScene == null)
            throw new Exception("Failed to deserialize scene.");

        return loadedScene;
    }
}