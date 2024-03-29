using HRLeaveManagement.MVC.Contracts;
using HRLeaveManagement.MVC.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IClient, Client>(c1 => c1.BaseAddress = new Uri("https://localhost:7086"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
//builder.Services.AddScoped<ILeaveAllocationService,LeaveAllocationService>();
//builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();

builder.Services.AddSingleton<ILocalStorgeService, LocalStorageService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
