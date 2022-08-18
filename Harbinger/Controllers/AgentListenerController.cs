using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Harbinger.Controllers
{
	[Route("agent_listener")]
	[ApiController]
	internal class AgentListenerController : ControllerBase
	{
		//invoke_raw_method?method={method}&license_key={licensekey}&marshal_format=json&protocol_version={protocolversion}
		[HttpPost, Route("invoke_raw_method")]
		public async Task<string> AgentConnect([FromQuery] string method, [FromQuery] string license_key, [FromQuery] string protocol_version)
		{
			var payload = await PayloadHelpers.TryDecompress(HttpContext.Request.Body, HttpContext.Request.Headers["CONTENT-ENCODING"]);

			return JsonConvert.SerializeObject(ConnectMethodHandler.HandleConnection(method, license_key, protocol_version, payload));
		}
	}
}
