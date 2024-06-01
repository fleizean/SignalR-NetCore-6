using System.Reflection;
using AutoMapper;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRApi.Extensions;
using SignalRApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SignalRContext>(); // yeni eklendi
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // "var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());" soldaki Mapper kodunun çalışması için

/* kodun katmanlar arasındaki bağımlılıklarını ayarlamak için kullanıyoruz api kullanımı için şart */

builder.Services.AddCors(opt =>
{
    // CORS (Cross-Origin Resource Sharing) politikalarını ekliyoruz
    opt.AddPolicy("CorsPolicy", builder =>
    {
        // Herhangi bir başlığa izin veriyoruz
        builder.AllowAnyHeader()
        // Herhangi bir HTTP metoduna (GET, POST, PUT, DELETE, vb.) izin veriyoruz
        .AllowAnyMethod()
        // İsteğin geldiği orijinin doğruluğunu belirlerken tüm orijinlere izin veriyoruz
        .SetIsOriginAllowed((host) => true)
        // Kimlik bilgileri (çerezler, HTTP kimlik doğrulaması, vb.) kullanımına izin veriyoruz
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

/* Yöntem 1 */
builder.Services.AddBusinessServices(); // yazdığımız extensions klasöründe olan bağımlılıkları dahil etme

/* ---------------------------------------------------------------------------------------------- */

// Add services to the container.

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// SignalR hub'ını "/signalrhub" uç noktası ile haritalandırıyoruz
app.MapHub<SignalRHub>("/signalrhub"); // localhost:1234/swagger/api/category/ => localhost:1234/siganlrhub istek buraya gider

app.Run();

