using VariacaoAtivo.API.Interfaces;
using VariacaoAtivo.API.Repositories;
using VariacaoAtivo.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>();

builder.Services.AddScoped<IGetDataApiService, GetDataApiService>();
builder.Services.AddScoped<IPriceVariationAggregator, PriceVariationAggregator>();
builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddScoped<IAssetValueRepositorie, AssetValueRepositorie>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
