using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace DependencyInjection.Controllers;

public class GetPersonRequest
{
    [SwaggerSchema(Description = "Name of the user")]
    [DefaultValue("John Smith")]
    public required string Name { get; set; }

    [SwaggerSchema(Description = "Date Of Birth")]
    [DefaultValue("1985-05-15T00:00:00Z")]
    public required DateTime DateOfBirth { get; set; }    
}