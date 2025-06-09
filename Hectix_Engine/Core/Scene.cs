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
        // prevents duplicates
        if (GameObjects.Any(go => go.Name == name))
        {
            int count = 1;
            string baseName = name;
            while (GameObjects.Any(go => go.Name == name))
            {
                name = $"{baseName} ({count++})";
            }
        }
        GameObjects.AddLast(new GameObject(name));
    }

    public void AddGameObject(GameObject newGameObject)
    {
        // prevents duplicates
        if (GameObjects.Any(go => go.Name == newGameObject.Name))
        {
            int count = 1;
            string baseName = newGameObject.Name;
            while (GameObjects.Any(go => go.Name == newGameObject.Name))
            {
                newGameObject.Name = $"{baseName} ({count++})";
            }
        }
        GameObjects.AddLast(newGameObject);
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

    public void Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Scene file not found", path);

        string json = File.ReadAllText(path);
        var loaded = JsonSerializer.Deserialize<Scene>(json);

        if (loaded == null)
            throw new Exception("Failed to deserialize scene.");

        // Copy loaded data into current instance
        GameObjects = loaded.GameObjects;
    }
}