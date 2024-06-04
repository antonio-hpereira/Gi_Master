using AutoMapper;
using GI_Master_FrontEnd.Config;
using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.Services.Concrete;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IEmpregadosServices, EmpregadosServices>(c =>
                   c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EmpregadosAPI"])
               );
builder.Services.AddHttpClient<IEmpresasServices, EmpresasServices>(c =>
                   c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EmpresasAPI"])
               );
builder.Services.AddHttpClient<IDepartamentoServices, DeparamentosServices>(c =>
                   c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:DepartamentoAPI"])
               );


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
                     .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                     .AddOpenIdConnect("oidc", options =>
                     {
                         options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
                         options.GetClaimsFromUserInfoEndpoint = true;
                         options.ClientId = "gi_master";
                         options.ClientSecret = "my_super_secret";
                         options.ResponseType = "code";
                         options.ClaimActions.MapJsonKey("role", "role", "role");
                         options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                         options.TokenValidationParameters.NameClaimType = "name";
                         options.TokenValidationParameters.RoleClaimType = "role";
                         options.Scope.Add("gi_master");
                         options.SaveTokens = true;
                     }
         );



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
