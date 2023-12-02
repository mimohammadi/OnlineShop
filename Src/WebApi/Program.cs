using Common.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connetctionString = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connetctionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self';");
    await next();
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(new TimeSpan(24, 12, 1)));



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
