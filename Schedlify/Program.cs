using Schedlify.WinForm;
namespace Schedlify;
using DotNetEnv;

public class Program
{
    public static void LoadEnv()
    {
        var projectDir = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        var envPath = Path.Combine(projectDir, ".env.local");
        Env.Load(envPath);

    }

    [STAThread] // Додаємо цей атрибут
    public static void Main(string[] args)
    {
      LoadEnv();
      if (args.Length > 0 && args[0] == "-s")
      {
            Console.WriteLine("Warning! -s is deprecated. Continuing as usual");
      }
      else
      {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);

          // Створення та запуск основної форми Windows Forms
          var mainForm = new MainForm();
          Application.Run(mainForm);
      }
    }
}
