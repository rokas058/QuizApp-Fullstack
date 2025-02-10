using Microsoft.EntityFrameworkCore;
using QuizProject.Data;
using QuizProject.Initialize;
using QuizProject.Repositories;
using QuizProject.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AplicationDBContext>(options =>
    options.UseInMemoryDatabase("QuizDb"));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizResultRepository, QuizResultRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AplicationDBContext>();
    QuestionInitializer.Initialize(context);
}

app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
