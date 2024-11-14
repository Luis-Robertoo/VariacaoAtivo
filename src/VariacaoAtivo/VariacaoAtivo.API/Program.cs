using Refit;
using VariacaoAtivo.API.Integration;
using VariacaoAtivo.API.Interfaces;
using VariacaoAtivo.API.Repositories;
using VariacaoAtivo.API.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

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


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddRefitClient<IFinanceAsset>().ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(configuration.GetValue<string>("UrlBase"));
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<DataBaseContext>();

    services.AddScoped<IGetDataApiService, GetDataApiService>();
    services.AddScoped<IPriceVariationAggregator, PriceVariationAggregator>();
    services.AddScoped<IDataService, DataService>();
    services.AddScoped<IAssetValueRepositorie, AssetValueRepositorie>();

}

