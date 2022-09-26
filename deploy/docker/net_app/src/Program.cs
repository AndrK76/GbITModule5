using Microsoft.Extensions.Options;
using WebApplicationCh06_04;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .AddJsonFile("person.json")
    .AddXmlFile("person.xml")
    ;

builder.Services.Configure<Person>(builder.Configuration);

builder.Services.Configure<Person>(configureOptions: opt => { opt.Age = 10; opt.Name = "Иван"; });

var app = builder.Build();



//var tom = new Person();
//app.Configuration.Bind(tom);
//app.Run(async (context) => {
//    context.Response.ContentType = "text/html; charset=utf-8";
//    string name = $"<p>Name: {tom.Name}</p>";
//    string age = $"<p>Age: {tom.Age}</p>";
//    string company = $"<p>Company: {tom.Company?.Title}</p>";
//    string langs = "<p>Languages:</p><ul>";
//    foreach (var lang in tom.Languages)
//    {
//        langs += $"<li><p>{lang}</p></li>";
//    }
//    langs += "</ul>";

//    await context.Response.WriteAsync($"{name}{age}{company}{langs}");
//});

//app.Map("/", (IOptions<Person> options) =>
//{
//    Person person = options.Value;  // получаем переданные через Options объект Person
//    return person;
//});

app.UseMiddleware<PersonMiddleware>();

app.Run();
