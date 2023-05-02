using System.Text.Json.Serialization;
using cinemaApi.Database;
using cinemaApi.Models;
using cinemaApi.Repositories.BaseRepo;
using cinemaApi.Repositories.CinemaRepo;
using cinemaApi.Services;
using cinemaApi.Services.CinemaService;
using Microsoft.AspNetCore.Rewrite;
using static cinemaApi.DTOs.CinemaDto;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        // Fix the JSON cycle issue
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<DataContext>();
// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IBaseService<Cinema, CinemaCreateDto, CinemaReadDto, CinemaUpdateDto>, BaseService<Cinema, CinemaCreateDto, CinemaReadDto, CinemaUpdateDto>>()
    .AddScoped<ICinemaRepo, CinemaRepo>()
    .AddScoped<IBaseRepo<Cinema>, BaseRepo<Cinema>>()
    .AddScoped<ICinemaService, CinemaService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));
}
// default, no below code
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));
}
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
