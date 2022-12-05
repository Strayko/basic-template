using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo.Controllers;

[ApiController]
[Route("api")]
public class TranslateController : ControllerBase
{
    [HttpPost("translate/json")]
    public IActionResult TranslateJson([FromBody]string requestXml)
    {

        Console.WriteLine("test");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(requestXml);
        
        string json = JsonConvert.SerializeXmlNode(doc);

        return Ok(json);
    }
}