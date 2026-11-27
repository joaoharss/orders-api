using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orders_api.Data;
using orders_api.Models;
using System.Reflection.Metadata.Ecma335;

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

app.MapGet("/orders/{id}", async (DbManager db, Guid id) =>
{
    var order = await db.Orders.FindAsync(id);

    if (order == null)
        return Results.NotFound();

    return Results.Ok(order);
});

app.MapPost("/orders/", async (Order order, DbManager db) =>
{
    db.Orders.Add(order);
    await db.SaveChangesAsync();

    return Results.Created($"/orders{order.Id}", order);
});

app.MapPut("/orders/{id}", async (Order newOrder, Guid id, DbManager db) =>
{
    var oldOrder = await db.Orders.FindAsync(id);

    if (oldOrder == null)
        return Results.NotFound();

    oldOrder.CreateOrder = newOrder.CreateOrder;

    await db.SaveChangesAsync();

    return Results.Ok(oldOrder);
});

app.MapDelete("/orders/{id}", async (Guid id, DbManager db) =>
{
    var orderToDelete = await db.Orders.FindAsync(id);

    if (orderToDelete == null)
        return Results.NotFound();

    db.Orders.Remove(orderToDelete);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();