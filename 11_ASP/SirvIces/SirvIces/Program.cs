using SirvIces.middleware;
using SirvIces.services.math;
using SirvIces.services.time;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
// �������� ���� �������
services.AddTransient<ITimeService, LongTimeServise>();
services.AddTransient<IFunction, Straight>();
services.AddTransient<FunctionResult>();

var app = builder.Build();
// ��������� ���������� ������
FunctionResult result = app.Services.GetService<FunctionResult>();

app.UseMiddleware<ServiceMiddleware>(services);
app.UseMiddleware<FunctionMiddleware>(result);
app.UseMiddleware<DefaultMiddleware>();

app.Run();
