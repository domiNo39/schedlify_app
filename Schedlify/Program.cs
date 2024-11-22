using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schedlify.Data;
using System;
using System.Windows.Forms;
using Schedlify.WinForm;

var builder = WebApplication.CreateBuilder(args);

// Завантажуємо змінні середовища з .env.local
DotNetEnv.Env.Load(".env.local");

// Конфігурація Entity Framework для роботи з PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var host = Environment.GetEnvironmentVariable("DB_HOST");
    var port = Environment.GetEnvironmentVariable("DB_PORT");
    var database = Environment.GetEnvironmentVariable("DB_NAME");
    var username = Environment.GetEnvironmentVariable("DB_USER");
    var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

    var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

    options.UseNpgsql(connectionString);
});

var app = builder.Build();

// Перевірка, чи працює програма в інтерактивному режимі
if (Environment.UserInteractive)
{
    // Ініціалізація Windows Forms інтерфейсу
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    // Створення та запуск основної форми Windows Forms
    var mainForm = new MainForm();
    Application.Run(mainForm); // Запускаємо основну форму Windows Forms

    // Веб-додаток продовжує працювати після закриття форми (не обов'язково)
    // Якщо потрібно, можна додати додаткову логіку тут
}
else
{
    // Якщо не інтерактивний режим, запускаємо веб-застосунок
    app.Run(); // Запуск веб-додатку
}
