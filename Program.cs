using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Implementations.Repositories;
using SMS_MVCDTO.Implementations.Service;
using SMS_MVCDTO.Implementations.Services;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//if you dont want to it your decision
builder.Services.AddControllersWithViews();
var configuration = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(configuration, ServerVersion.AutoDetect(configuration)));


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAttendantRepository, AttendantRepository>();
builder.Services.AddScoped<IAttendantService, AttendantService>();
builder.Services.AddScoped<ISalesManagerService, SalesManagerService>();
builder.Services.AddScoped<ISalesManagerRepository, SalesManagerRepository>();
builder.Services.AddScoped<ISuperAdminRepository, SuperAdminRepository>();
builder.Services.AddScoped<ISuperAdminService, SuperAdminService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IBankDetailRepository, BankDetailRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));

//builder.Services.AddScoped<IBankDetailService, BankDetailService>();
//builder.Services.AddScoped<IAddressService, AddressService>();  
//builder.Services.AddFluentEmail("treehays90@gmail.com","Abdulsalam AHmad");
//builder.Services.AddSmtpSender("smtp.gmail.com");
builder.Services
        .AddFluentEmail("postmaster@sandbox2e6052c24ced4a088a011daf8707cca1.mailgun.org")
        .AddMailGunSender("http://localhost:7113/", "pubkey-b5f040806c4bedbcacc0fededc2faa42", FluentEmail.Mailgun.MailGunRegion.USA);
//.AddRazorRenderer()
//.AddMailGunSender("domainname.com", " bb744daa8eab96ab3f3cc6121b50e80f-7764770b-2c634ca4", FluentEmail.Mailgun.MailGunRegion.USA);
//.AddSmtpSender("smtp.gmail.com", 587, "clhprojecttest@gmail.com","CLH12345");
//.AddFluentEmail("fromemail@test.test")


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
    {
        config.LoginPath = "/Home/Login";
        config.LogoutPath = "/Home/Login";
        config.Cookie.Name = "SMSREX";
    });
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UseResponseCompression();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
