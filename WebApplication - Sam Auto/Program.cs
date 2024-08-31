using DataAccessLayer;
using DataAccessLayer.InterfacesDAL;
using LogicLayer;
using LogicLayer.InterfacesLL;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();




//Add Authenthication trough cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/LogIn");
        options.AccessDeniedPath = new PathString("/Index");

    });
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<DataBaseConnection>();

builder.Services.AddTransient<IPeopleInterfaceDataManagerDataAccessLayer, PeopleDataManagerDataAccessLayer>(provider =>
{
    var connection = provider.GetRequiredService<DataBaseConnection>();
    return new PeopleDataManagerDataAccessLayer(connection);
});

builder.Services.AddTransient<IVehicleInterfaceDataAccessLayer, VehiclesDataManagerDataAccessLayer>(provider =>
{
    var connection = provider.GetRequiredService<DataBaseConnection>();
    return new VehiclesDataManagerDataAccessLayer(connection);
});

builder.Services.AddTransient<ISuggestionsInterfaceDataAccessLayer, SuggestionsDataManagerDataAccessLayer>(provider =>
{
    var connection = provider.GetRequiredService<DataBaseConnection>();
    return new SuggestionsDataManagerDataAccessLayer(connection);
});

builder.Services.AddTransient<IPeopleInterfaceLogicLayer, PeopleManager>();
builder.Services.AddTransient<IVehicleBasicInterfaceLogicLayer, VehicleManager>();
builder.Services.AddTransient<ISuggestionsInterfaceLogicLayer,SuggestionsManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
