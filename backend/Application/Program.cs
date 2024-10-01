using Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Context>();
builder.Services.AddScoped<PrecoRepository>();
builder.Services.AddScoped<EstacionamentoRepository>();

builder.Services.AddCors(config => config.AddPolicy("allow-all", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("allow-all");

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers().AllowAnonymous();

app.Run();
