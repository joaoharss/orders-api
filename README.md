# orders-api

Order management REST API built with ASP.NET Core, EF Core and SQL Server.

> 🚧 **Work in progress** — personal study project. I'm building it step by step to practice modern .NET back-end development.

## Planned flow

Client creates an order → API saves it to SQL Server → publishes an `OrderCreated` event to RabbitMQ → a worker consumes it and updates the order status.

## Tech stack

- .NET 8 / ASP.NET Core
- Entity Framework Core + SQL Server
- xUnit (planned)
- Docker & docker-compose (planned)
- GitHub Actions (planned)
- RabbitMQ (planned)

## Roadmap

- [ ] Products and Orders CRUD with EF Core
- [ ] Validation, error handling (ProblemDetails), Swagger, pagination
- [ ] Report endpoint using Dapper / stored procedure
- [ ] Unit tests for business rules
- [ ] Integration test with WebApplicationFactory
- [ ] Dockerfile + docker-compose (API + SQL Server)
- [ ] CI pipeline with GitHub Actions
- [ ] RabbitMQ producer + Worker Service consumer

## How to run

_Coming soon._
