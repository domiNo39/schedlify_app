namespace Schedlify.Tests;

using System;
using DotNetEnv;

public class EnvFixture : IDisposable
{
    public EnvFixture()
    {
        var projectDir = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        var envPath = Path.Combine("C:\\Users\\user\\source\\repos\\schedlify_app\\Schedlify", ".env.local");
        Env.Load(envPath);
    }
    public void Dispose()
    {
        // Clean up if needed
    }
}