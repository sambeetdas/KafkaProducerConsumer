using Kafka.Manager.Contracts;
using Kafka.Manager.Implements;
using Service.Manager.Contracts;
using Service.Manager.Implements;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddTransient<IProducerContract, ProducerHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
