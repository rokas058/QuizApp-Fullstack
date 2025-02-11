using Microsoft.EntityFrameworkCore;
using QuizProject.Application.Interfaces;
using QuizProject.Application.Services;
using QuizProject.Infrastructure.Data;
using QuizProject.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseInMemoryDatabase("QuizDb"));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizResultRepository, QuizResultRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    QuestionInitializer.Initialize(context);
}

app.UseCors("AllowReactApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
