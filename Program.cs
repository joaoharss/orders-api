using Microsoft.EntityFrameworkCore;
using orders_api.Data;
using orders_api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbManager>(options =>
    options.UseInMemoryDatabase("OrdersDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/orders", async (DbManager db) => await db.Orders.ToListAsync());

app.MapGet("/orders/{id}", async (DbManager db, Guid id) => await db.Orders.FindAsync(id));

app.MapPost("/orders/create", async (Order order, DbManager db) =>
{
    db.Orders.Add(order);
    await db.SaveChangesAsync();

    return Results.Created($"/orders{order.Id}", order);
});

app.Run();