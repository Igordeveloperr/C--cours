
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

//app.UseWelcomePage(); // ����������� ���������� ���������� middleware

app.Run();
