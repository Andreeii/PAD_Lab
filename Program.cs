using WebApp1;
using WebApp1.DBAcces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(_ =>
{
	var keyIvrDbContext = new MoviesContext();
	builder.Services.BuildServiceProvider();
	return keyIvrDbContext;
});

builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
