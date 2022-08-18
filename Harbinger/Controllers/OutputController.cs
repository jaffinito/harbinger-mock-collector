using Harbinger.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Harbinger.Controllers
{
    [Route("output")]
	[ApiController]
	public class OutputController : ControllerBase
	{
		private readonly ILogger _logger;
		private DataStore _dataStore;

		public OutputController(ILogger<AgentListenerController> logger)
		{
			_logger = logger;
			_dataStore = DataStore.Instance;
		}

		[HttpGet, Route("get_raw_metrics")]
		public JsonResult GetRawMetrics()
		{
			var jsonResponse = JsonConvert.SerializeObject((_dataStore.RawMetricData.MetricData));
			return new JsonResult(jsonResponse);
		}

		[HttpGet, Route("unscoped_metric_exists")]
		public bool UnscopedMetrircExists([FromQuery] string metric)
		{
			return _dataStore.MetricData.UnscopedMetricExists(metric);
		}

		[HttpGet, Route("scoped_metric_exists")]
		public bool ScopedMetrircExists([FromQuery] string metric, [FromQuery] string scope)
		{
			return _dataStore.MetricData.ScopedMetricExists(metric, scope);
		}
	}
}
