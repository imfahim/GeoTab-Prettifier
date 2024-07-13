using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prettifier.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddScoped<IPrettificationStrategy, TrillionPrettificationStrategy>();
builder.Services.AddScoped<IPrettificationStrategy, BillionPrettificationStrategy>();
builder.Services.AddScoped<IPrettificationStrategy, MillionPrettificationStrategy>();
builder.Services.AddScoped<IPrettificationStrategy, DefaultPrettificationStrategy>();
builder.Services.AddScoped<Prettifier.Service.Prettifier>();

builder.Services.AddFastEndpoints();

builder.WebHost.UseKestrel(options =>
{
	options.ListenAnyIP(5000);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseFastEndpoints();

app.Run();
