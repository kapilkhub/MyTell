using CreateUser;
using FluentValidation;
using MyTell.IdentityManagement.Api.Endpoints.EndpointHandlers.UserHandlers.CreateUser;
using MyTell.IdentityManagement.Api.Endpoints.EndpointRouteBuilderExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateUserWithoutCredentialsRequestValidator));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddProblemDetails();
builder.Services.AddHttpClient<ICreateUserApiClient, CreateUserApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.RegisterUserCreateEndpoints();
app.Run();

