using InventoryAspireSample.API.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSqlServerDbContext<AppDbContext>("sql");




builder.Services.AddControllers();

builder.AddServiceDefaults();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("DevCors", p =>
        p.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod());
});

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseCors("DevCors");


app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    }
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
