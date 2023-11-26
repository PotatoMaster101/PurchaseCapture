using Microsoft.EntityFrameworkCore;
using PurchaseCapture.Application.Customers;
using PurchaseCapture.Application.Customers.Commands;
using PurchaseCapture.Application.Interfaces.Commands;
using PurchaseCapture.Application.Interfaces.Persistence;
using PurchaseCapture.Application.Interfaces.Queries;
using PurchaseCapture.Application.Items;
using PurchaseCapture.Application.Items.Commands;
using PurchaseCapture.Application.Purchases;
using PurchaseCapture.Application.Purchases.Commands;
using PurchaseCapture.Application.Purchases.Queries;
using PurchaseCapture.Domain.Customers;
using PurchaseCapture.Domain.Items;
using PurchaseCapture.Domain.Purchases;
using PurchaseCapture.Persistence.Common;
using PurchaseCapture.Persistence.Purchases;
using PurchaseCapture.Presentation.Components;

var builder = WebApplication.CreateBuilder(args);
var conStr = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(o => o.UseNpgsql(conStr));
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Item>, Repository<Item>>();
builder.Services.AddScoped<IRepository<Purchase>, PurchaseRepository>();
builder.Services.AddScoped<ICommand<PurchaseModel>, CreatePurchase>();
builder.Services.AddScoped<ICommand<ItemModel>, CreateItem>();
builder.Services.AddScoped<ICommand<CustomerModel>, CreateCustomer>();
builder.Services.AddScoped<IQuery<PurchaseModel>, GetPurchases>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// apply DB migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync().ConfigureAwait(false);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
