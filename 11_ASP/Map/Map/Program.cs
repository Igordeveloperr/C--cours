var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// �������� �����
app.Map("/", () => "index");
app.Map("/about", ()=> "about");
app.Map("/see", () => "See");
app.Map("/user/{id:int}/{name}", (int id,string name) =>
{
    return $"User {name} have id: {id}";
});

// ��������� ���� �������� �����

app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.Run();
