using Schedlify.Tests;

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
    public static void Main(string[] args)
    {
        LoadEnv();
        RepoTests.Run();
    }
}

