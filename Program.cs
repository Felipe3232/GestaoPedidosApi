using GestaoPedidosAPI.Data.Context;
using GestaoPedidosAPI.Data.Repository;
using GestaoPedidosAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<GestaoPedidosDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySQL(builder.Configuration.GetConnectionString("MYSQL_GESTAOPEDIDOS")));



builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ProtocoloRepository>();
builder.Services.AddScoped<SolicitacaoRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProtocoloService>();
builder.Services.AddScoped<SolicitacaoService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Gera a documentação da API
    app.UseSwaggerUI();  // Interface para visualizar e testar as APIs
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
