using AspNetCoreRateLimit;
using Checkmate.API.Middlewares;
using Checkmate.API.Services;
using Checkmate.BLL.Services;
using Checkmate.BLL.Services.Interfaces;
using Checkmate.DAL.Database;
using Checkmate.DAL.Repositories;
using Checkmate.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
	});

	// Permet d'ajouter le "cadenas" sur les routes
	// - Implémentation simple (Cadenas sur toutes les routes)
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
	// - Plus d'infos : 
	// https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#add-security-definitions-and-requirements
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region DbContext
// Add DB Context
builder.Services.AddDbContext<TournamentContext>(b =>
	b.UseSqlServer(builder.Configuration.GetConnectionString("Docker"))
);
#endregion

#region DAL Repositories
// Add Repositories
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
#endregion

#region BLL Services
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
#endregion

#region API Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddHttpClient<IGoogleCaptchaService, GoogleCaptchaService>();
#endregion

#region JWT Bearer Authentication

builder
	.Services.AddAuthentication(option =>
	{
		option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(option =>
	{
		option.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
			),

			ValidateIssuer = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],

			ValidateAudience = true,
			ValidAudience = builder.Configuration["Jwt:Audience"],

			ValidateLifetime = true,
		};
	});

#endregion

#region CORS

builder.Services.AddCors(service =>
{
	service.AddPolicy("FFA", policy =>
	{
		policy.AllowAnyOrigin();
		policy.AllowAnyMethod();
		policy.AllowAnyHeader();
	});

	// TODO : Add more CORS policies for production
});

#endregion

#region Rate Limiting
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseCors("FFA");

app.UseStaticFiles();

app.UseMiddleware<ExceptionMiddleware>(); // Register exception middleware

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
