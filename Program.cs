
using CHMR_DMP_PPR_Charlie_Docker.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
//var connectionString = builder.Configuration.GetConnectionString("DMP-MVP-Bravo") ?? "Data Source=DMP-MVP-Bravo.db";
////builder.Services.AddSqlite<PizzaDb>(connectionString);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

IConfiguration appSettings = ConfigurationPoco.AppSettings;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
