using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "RateAPI";
    config.Title = "RateAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

//Swagger testing for development environments
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "RateAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

//map to /api/rates
var rateItems = app.MapGroup("/api/rates");
rateItems.MapGet("/", GetRates);

static async Task<IResult> GetRates(string? loanType = null, int? term = null)
{
    var rates = new List<Rate>
    {
        new() {
            LoanType = "owner-occupied",
            Term = 30
        },

        new() {
            LoanType = "shark",
            Term = 100000
        },

        new() {
            LoanType = "wow",
            Term = 1
        }

    };

    //Filters using query parameters

    //store rates as a list that can be queried
    var filtered = rates.AsQueryable();

    if (!string.IsNullOrEmpty(loanType))
    {
        filtered = filtered.Where(r => r.LoanType.Equals(loanType, StringComparison.OrdinalIgnoreCase));
    }

    if (term.HasValue)
    {
        filtered = filtered.Where(r => r.Term == term.Value);
    }

    return TypedResults.Ok(filtered.ToList());
}

app.Run();