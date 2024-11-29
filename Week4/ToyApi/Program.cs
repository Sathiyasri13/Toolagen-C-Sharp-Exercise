using Microsoft.EntityFrameworkCore;
using ToyApi.Data;
using ToyApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext service to use SQLite (you can use SQL Server as an alternative)
builder.Services.AddDbContext<ToyDbContext>(options =>
    options.UseSqlite("Data Source=toys.db"));

// Add services to the container.
builder.Services.AddControllers();  // Add services for controllers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();  // Map API controllers to endpoints

app.Run();
