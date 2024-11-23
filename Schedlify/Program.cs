using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schedlify.Data;
using System;
using System.Windows.Forms;
using Schedlify.WinForm;
using Schedlify.Tests;


namespace Schedlify;
using DotNetEnv;
using System.Runtime.InteropServices;

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
      if (args.Length > 0 && args[0] == "-t")
      {
          Tests.RepoTests.Run();
      }
      else
      {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);

          // Створення та запуск основної форми Windows Forms
          var mainForm = new MainForm();
          Application.Run(mainForm);
          RepoTests.Run();
      }
    }
}
