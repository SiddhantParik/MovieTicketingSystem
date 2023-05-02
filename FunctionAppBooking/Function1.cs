using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketFunctionApp
{
  public static class Function1
  {
    [FunctionName("Function1")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
       [Sql("dbo.Booking", "SqlConnString")] IAsyncCollector<Bookings> booking,
        ILogger log)

    {
      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      Bookings dept = JsonConvert.DeserializeObject<Bookings>(requestBody);

      await booking.AddAsync(dept);
      await booking.FlushAsync();

      //log.LogInformation("C# HTTP trigger function processed a request.");

      //string name = req.Query["name"];

      //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      //dynamic data = JsonConvert.DeserializeObject(requestBody);
      //name = name ?? data?.name;

      //string responseMessage = string.IsNullOrEmpty(name)
      //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
      //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

      return new OkObjectResult("Booking Completed");
    }
  }
}
