using System.Reflection;
using AutoMapper;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
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
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IFooterService, FooterManager>();
builder.Services.AddScoped<IFooterDal, EfFooterDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

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

