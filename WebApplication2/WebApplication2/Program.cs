var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    if (context.Request.Path == "/postuser")
    {
        int n = 0;
        string res;
        var form = context.Request.Form;
        int first = Convert.ToInt32( form["first"]);
        if(first==2)
        {
            n++;
        }
        int second =Convert.ToInt32( form["second"]);
        if (second == 3)
        {
            n++;
        }
        int third =Convert.ToInt32( form["third"]);
        if (third == 6)
        {
            n++;
        }
        if(n>2)
        {
            res = "good";
        }
        else if(n>1) 
        {
            res = "not bad";
        }
        else
        {
            res = "bed";
        }
        await context.Response.WriteAsync($"<div> <p>Кількість балів: {n}<br>{res}</p></div>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }

});

app.Run();
