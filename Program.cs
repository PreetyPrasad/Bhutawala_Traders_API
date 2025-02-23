using Bhutawala_Traders_API.ApplicationContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(o =>
    o.UseSqlServer("Data Source=.;Initial Catalog=Bhutawal_Traders_API;Integrated Security=True;Trust Server Certificate=True"));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()    // Allows requests from any domain
                   .AllowAnyMethod()    // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
                   .AllowAnyHeader();   // Allows all headers
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Apply the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
