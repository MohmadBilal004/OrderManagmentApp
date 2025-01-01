using API.GraphQL;
using Core.Interfaces;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<OMAContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDb");
});
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        AllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

// GraphQL
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddFiltering();

var app = builder.Build();

// Enable CORS
app.UseCors(AllowSpecificOrigins);

// GraphQL endpoint
app.MapGraphQL();

// GraphQL Voyager endpoint for exploring the GraphQL API
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions { GraphQLEndPoint = "/graphql" });

app.Run();
