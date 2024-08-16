using OrderingAPI;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;


var builder = WebApplication.CreateBuilder(args);
//Add service to the container
 
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);
var app = builder.Build();


//configure HTTP request pipeline
app.UseApiServices();
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
