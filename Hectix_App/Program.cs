namespace Hectix.App;

using Hectix.Window.SILK;
using Hectix.Editor;

public class Program
{
    public static void Main(string[] args)
    {
        var window = new SilkWindow();
        var app = new EditorApp(window);
        app.Run();
    }
}