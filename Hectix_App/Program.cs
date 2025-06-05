namespace Hectix.App;

using Hectix.Window.SILK;
using Hectix.Editor;

public class Program
{
    public static void Main(string[] args)
    {
        var window = new SilkWindow();              // Your Silk implementation of IHectixWindow
        var app = new EditorApp(window);            // Injecting the abstraction
        app.Run();  
    }
}