using MilmomStore_DataAccessObject;
using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MilmomSystemContext>(p
    => p.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
        (b) => b.MigrationsAssembly("MilmomStore.Server")));
//
builder.Services.AddIdentity<AccountApplication, IdentityRole>()
    .AddEntityFrameworkStores<MilmomSystemContext>().AddDefaultTokenProviders();
//

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
