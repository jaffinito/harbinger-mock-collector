using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Harbinger.Models.Connect
{
    public class ConnectMethodRequest
    {
        [JsonProperty("pid")]
        public long Pid { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("display_host")]
        public string DisplayHost { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("app_name")]
        public string[] AppName { get; set; }

        [JsonProperty("agent_version")]
        public string AgentVersion { get; set; }

        [JsonProperty("agent_version_timestamp")]
        public long AgentVersionTimestamp { get; set; }

        [JsonProperty("security_settings")]
        public SecuritySettings SecuritySettings { get; set; }

        [JsonProperty("high_security")]
        public bool HighSecurity { get; set; }

        [JsonProperty("event_harvest_config")]
        public EventHarvestConfig EventHarvestConfig { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("labels")]
        public object[] Labels { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("utilization")]
        public Utilization Utilization { get; set; }

        [JsonProperty("environment")]
        public List<List<object>> Environment { get; set; }
    }

    public class EventHarvestConfig
    {
        [JsonProperty("harvest_limits")]
        public HarvestLimits HarvestLimits { get; set; }
    }

    public class HarvestLimits
    {
        [JsonProperty("analytic_event_data")]
        public long AnalyticEventData { get; set; }

        [JsonProperty("custom_event_data")]
        public long CustomEventData { get; set; }

        [JsonProperty("error_event_data")]
        public long ErrorEventData { get; set; }

        [JsonProperty("span_event_data")]
        public long SpanEventData { get; set; }

        [JsonProperty("log_event_data")]
        public long LogEventData { get; set; }
    }

    public class Metadata
    {
    }

    public class SecuritySettings
    {
        [JsonProperty("transaction_tracer")]
        public TransactionTracer TransactionTracer { get; set; }
    }

    public class TransactionTracer
    {
        [JsonProperty("record_sql")]
        public string RecordSql { get; set; }
    }

    public class Settings
    {
        [JsonProperty("agent.name")]
        public string AgentName { get; set; }

        [JsonProperty("agent.enabled")]
        public bool AgentEnabled { get; set; }

        [JsonProperty("agent.license_key.configured")]
        public bool AgentLicenseKeyConfigured { get; set; }

        [JsonProperty("agent.application_names")]
        public string[] AgentApplicationNames { get; set; }

        [JsonProperty("agent.application_names_source")]
        public string AgentApplicationNamesSource { get; set; }

        [JsonProperty("agent.auto_start")]
        public bool AgentAutoStart { get; set; }

        [JsonProperty("browser_monitoring.application_id")]
        public string BrowserMonitoringApplicationId { get; set; }

        [JsonProperty("browser_monitoring.auto_instrument")]
        public bool BrowserMonitoringAutoInstrument { get; set; }

        [JsonProperty("browser_monitoring.beacon_address")]
        public string BrowserMonitoringBeaconAddress { get; set; }

        [JsonProperty("browser_monitoring.error_beacon_address")]
        public string BrowserMonitoringErrorBeaconAddress { get; set; }

        [JsonProperty("browser_monitoring.javascript_agent.populated")]
        public bool BrowserMonitoringJavascriptAgentPopulated { get; set; }

        [JsonProperty("browser_monitoring.javascript_agent_file")]
        public string BrowserMonitoringJavascriptAgentFile { get; set; }

        [JsonProperty("browser_monitoring.loader")]
        public string BrowserMonitoringLoader { get; set; }

        [JsonProperty("browser_monitoring.loader_debug")]
        public bool BrowserMonitoringLoaderDebug { get; set; }

        [JsonProperty("browser_monitoring.monitoring_key.populated")]
        public bool BrowserMonitoringMonitoringKeyPopulated { get; set; }

        [JsonProperty("browser_monitoring.use_ssl")]
        public bool BrowserMonitoringUseSsl { get; set; }

        [JsonProperty("security.policies_token")]
        public string SecurityPoliciesToken { get; set; }

        [JsonProperty("security.policies_token_exists")]
        public bool SecurityPoliciesTokenExists { get; set; }

        [JsonProperty("agent.allow_all_request_headers")]
        public bool AgentAllowAllRequestHeaders { get; set; }

        [JsonProperty("agent.attributes_enabled")]
        public bool AgentAttributesEnabled { get; set; }

        [JsonProperty("agent.can_use_attributes_includes")]
        public bool AgentCanUseAttributesIncludes { get; set; }

        [JsonProperty("agent.can_use_attributes_includes_source")]
        public string AgentCanUseAttributesIncludesSource { get; set; }

        [JsonProperty("agent.attributes_include")]
        public string[] AgentAttributesInclude { get; set; }

        [JsonProperty("agent.attributes_exclude")]
        public string[] AgentAttributesExclude { get; set; }

        [JsonProperty("agent.attributes_default_excludes")]
        public string[] AgentAttributesDefaultExcludes { get; set; }

        [JsonProperty("transaction_events.attributes_enabled")]
        public bool TransactionEventsAttributesEnabled { get; set; }

        [JsonProperty("transaction_events.attributes_include")]
        public object[] TransactionEventsAttributesInclude { get; set; }

        [JsonProperty("transaction_events.attributes_exclude")]
        public object[] TransactionEventsAttributesExclude { get; set; }

        [JsonProperty("transaction_trace.attributes_enabled")]
        public bool TransactionTraceAttributesEnabled { get; set; }

        [JsonProperty("transaction_trace.attributes_include")]
        public object[] TransactionTraceAttributesInclude { get; set; }

        [JsonProperty("transaction_trace.attributes_exclude")]
        public object[] TransactionTraceAttributesExclude { get; set; }

        [JsonProperty("error_collector.attributes_enabled")]
        public bool ErrorCollectorAttributesEnabled { get; set; }

        [JsonProperty("error_collector.attributes_include")]
        public object[] ErrorCollectorAttributesInclude { get; set; }

        [JsonProperty("error_collector.attributes_exclude")]
        public object[] ErrorCollectorAttributesExclude { get; set; }

        [JsonProperty("browser_monitoring.attributes_enabled")]
        public bool BrowserMonitoringAttributesEnabled { get; set; }

        [JsonProperty("browser_monitoring.attributes_include")]
        public object[] BrowserMonitoringAttributesInclude { get; set; }

        [JsonProperty("browser_monitoring.attributes_exclude")]
        public object[] BrowserMonitoringAttributesExclude { get; set; }

        [JsonProperty("custom_parameters.enabled")]
        public bool CustomParametersEnabled { get; set; }

        [JsonProperty("custom_parameters.source")]
        public string CustomParametersSource { get; set; }

        [JsonProperty("collector.host")]
        public string CollectorHost { get; set; }

        [JsonProperty("collector.port")]
        public long CollectorPort { get; set; }

        [JsonProperty("collector.send_data_on_exit")]
        public bool CollectorSendDataOnExit { get; set; }

        [JsonProperty("collector.send_data_on_exit_threshold")]
        public double CollectorSendDataOnExitThreshold { get; set; }

        [JsonProperty("collector.send_environment_info")]
        public bool CollectorSendEnvironmentInfo { get; set; }

        [JsonProperty("collector.sync_startup")]
        public bool CollectorSyncStartup { get; set; }

        [JsonProperty("collector.timeout")]
        public long CollectorTimeout { get; set; }

        [JsonProperty("collector.max_payload_size_in_bytes")]
        public long CollectorMaxPayloadSizeInBytes { get; set; }

        [JsonProperty("agent.complete_transactions_on_thread")]
        public bool AgentCompleteTransactionsOnThread { get; set; }

        [JsonProperty("agent.compressed_content_encoding")]
        public string AgentCompressedContentEncoding { get; set; }

        [JsonProperty("agent.configuration_version")]
        public long AgentConfigurationVersion { get; set; }

        [JsonProperty("cross_application_tracer.enabled")]
        public bool CrossApplicationTracerEnabled { get; set; }

        [JsonProperty("distributed_tracing.enabled")]
        public bool DistributedTracingEnabled { get; set; }

        [JsonProperty("span_events.enabled")]
        public bool SpanEventsEnabled { get; set; }

        [JsonProperty("span_events.harvest_cycle")]
        public DateTimeOffset SpanEventsHarvestCycle { get; set; }

        [JsonProperty("span_events.attributes_enabled")]
        public bool SpanEventsAttributesEnabled { get; set; }

        [JsonProperty("span_events.attributes_include")]
        public object[] SpanEventsAttributesInclude { get; set; }

        [JsonProperty("span_events.attributes_exclude")]
        public object[] SpanEventsAttributesExclude { get; set; }

        [JsonProperty("infinite_tracing.trace_count_consumers")]
        public long InfiniteTracingTraceCountConsumers { get; set; }

        [JsonProperty("infinite_tracing.trace_observer_port")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long InfiniteTracingTraceObserverPort { get; set; }

        [JsonProperty("infinite_tracing.spans_queue_size")]
        public long InfiniteTracingSpansQueueSize { get; set; }

        [JsonProperty("infinite_tracing.spans_partition_count")]
        public long InfiniteTracingSpansPartitionCount { get; set; }

        [JsonProperty("infinite_tracing.spans_batch_size")]
        public long InfiniteTracingSpansBatchSize { get; set; }

        [JsonProperty("infinite_tracing.connect_timeout_ms")]
        public long InfiniteTracingConnectTimeoutMs { get; set; }

        [JsonProperty("infinite_tracing.send_data_timeout_ms")]
        public long InfiniteTracingSendDataTimeoutMs { get; set; }

        [JsonProperty("infinite_tracing.exit_timeout_ms")]
        public long InfiniteTracingExitTimeoutMs { get; set; }

        [JsonProperty("datastore_tracer.name_reporting_enabled")]
        public bool DatastoreTracerNameReportingEnabled { get; set; }

        [JsonProperty("datastore_tracer.query_parameters_enabled")]
        public bool DatastoreTracerQueryParametersEnabled { get; set; }

        [JsonProperty("error_collector.enabled")]
        public bool ErrorCollectorEnabled { get; set; }

        [JsonProperty("error_collector.capture_events_enabled")]
        public bool ErrorCollectorCaptureEventsEnabled { get; set; }

        [JsonProperty("error_collector.max_samples_stored")]
        public long ErrorCollectorMaxSamplesStored { get; set; }

        [JsonProperty("error_collector.harvest_cycle")]
        public DateTimeOffset ErrorCollectorHarvestCycle { get; set; }

        [JsonProperty("error_collector.max_per_period")]
        public long ErrorCollectorMaxPerPeriod { get; set; }

        [JsonProperty("error_collector.expected_classes")]
        public object[] ErrorCollectorExpectedClasses { get; set; }

        [JsonProperty("error_collector.expected_messages")]
        public Metadata ErrorCollectorExpectedMessages { get; set; }

        [JsonProperty("error_collector.expected_status_codes")]
        public object[] ErrorCollectorExpectedStatusCodes { get; set; }

        [JsonProperty("error_collector.expected_errors_config")]
        public Metadata ErrorCollectorExpectedErrorsConfig { get; set; }

        [JsonProperty("error_collector.ignore_errors_config")]
        public Dictionary<string, object[]> ErrorCollectorIgnoreErrorsConfig { get; set; }

        [JsonProperty("error_collector.ignore_classes")]
        public string[] ErrorCollectorIgnoreClasses { get; set; }

        [JsonProperty("error_collector.ignore_messages")]
        public Metadata ErrorCollectorIgnoreMessages { get; set; }

        [JsonProperty("agent.high_security_mode_enabled")]
        public bool AgentHighSecurityModeEnabled { get; set; }

        [JsonProperty("agent.custom_instrumentation_editor_enabled")]
        public bool AgentCustomInstrumentationEditorEnabled { get; set; }

        [JsonProperty("agent.custom_instrumentation_editor_enabled_source")]
        public string AgentCustomInstrumentationEditorEnabledSource { get; set; }

        [JsonProperty("agent.strip_exception_messages")]
        public bool AgentStripExceptionMessages { get; set; }

        [JsonProperty("agent.strip_exception_messages_source")]
        public string AgentStripExceptionMessagesSource { get; set; }

        [JsonProperty("agent.instance_reporting_enabled")]
        public bool AgentInstanceReportingEnabled { get; set; }

        [JsonProperty("agent.instrumentation_logging_enabled")]
        public bool AgentInstrumentationLoggingEnabled { get; set; }

        [JsonProperty("agent.metric_name_regex_rules")]
        public object[] AgentMetricNameRegexRules { get; set; }

        [JsonProperty("agent.new_relic_config_file_path")]
        public string AgentNewRelicConfigFilePath { get; set; }

        [JsonProperty("agent.app_settings_config_file_path")]
        public string AgentAppSettingsConfigFilePath { get; set; }

        [JsonProperty("proxy.host.configured")]
        public bool ProxyHostConfigured { get; set; }

        [JsonProperty("proxy.uri_path.configured")]
        public bool ProxyUriPathConfigured { get; set; }

        [JsonProperty("proxy.port.configured")]
        public bool ProxyPortConfigured { get; set; }

        [JsonProperty("proxy.username.configured")]
        public bool ProxyUsernameConfigured { get; set; }

        [JsonProperty("proxy.password.configured")]
        public bool ProxyPasswordConfigured { get; set; }

        [JsonProperty("proxy.domain.configured")]
        public bool ProxyDomainConfigured { get; set; }

        [JsonProperty("agent.put_for_data_sent")]
        public bool AgentPutForDataSent { get; set; }

        [JsonProperty("slow_sql.enabled")]
        public bool SlowSqlEnabled { get; set; }

        [JsonProperty("transaction_tracer.explain_threshold")]
        public DateTimeOffset TransactionTracerExplainThreshold { get; set; }

        [JsonProperty("transaction_tracer.explain_enabled")]
        public bool TransactionTracerExplainEnabled { get; set; }

        [JsonProperty("transaction_tracer.max_explain_plans")]
        public long TransactionTracerMaxExplainPlans { get; set; }

        [JsonProperty("transaction_tracer.max_sql_statements")]
        public long TransactionTracerMaxSqlStatements { get; set; }

        [JsonProperty("transaction_tracer.sql_traces_per_period")]
        public long TransactionTracerSqlTracesPerPeriod { get; set; }

        [JsonProperty("transaction_tracer.max_stack_trace_lines")]
        public long TransactionTracerMaxStackTraceLines { get; set; }

        [JsonProperty("error_collector.ignore_status_codes")]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] ErrorCollectorIgnoreStatusCodes { get; set; }

        [JsonProperty("agent.thread_profiling_methods_to_ignore")]
        public string[] AgentThreadProfilingMethodsToIgnore { get; set; }

        [JsonProperty("custom_events.enabled")]
        public bool CustomEventsEnabled { get; set; }

        [JsonProperty("custom_events.enabled_source")]
        public string CustomEventsEnabledSource { get; set; }

        [JsonProperty("custom_events.attributes_enabled")]
        public bool CustomEventsAttributesEnabled { get; set; }

        [JsonProperty("custom_events.attributes_include")]
        public object[] CustomEventsAttributesInclude { get; set; }

        [JsonProperty("custom_events.attributes_exclude")]
        public object[] CustomEventsAttributesExclude { get; set; }

        [JsonProperty("custom_events.max_samples_stored")]
        public long CustomEventsMaxSamplesStored { get; set; }

        [JsonProperty("custom_events.harvest_cycle")]
        public DateTimeOffset CustomEventsHarvestCycle { get; set; }

        [JsonProperty("agent.disable_samplers")]
        public bool AgentDisableSamplers { get; set; }

        [JsonProperty("thread_profiler.enabled")]
        public bool ThreadProfilerEnabled { get; set; }

        [JsonProperty("transaction_events.enabled")]
        public bool TransactionEventsEnabled { get; set; }

        [JsonProperty("transaction_events.max_samples_stored")]
        public long TransactionEventsMaxSamplesStored { get; set; }

        [JsonProperty("transaction_events.harvest_cycle")]
        public DateTimeOffset TransactionEventsHarvestCycle { get; set; }

        [JsonProperty("transaction_events.transactions_enabled")]
        public bool TransactionEventsTransactionsEnabled { get; set; }

        [JsonProperty("transaction_name.regex_rules")]
        public object[] TransactionNameRegexRules { get; set; }

        [JsonProperty("transaction_name.whitelist_rules")]
        public Metadata TransactionNameWhitelistRules { get; set; }

        [JsonProperty("transaction_tracer.apdex_f")]
        public DateTimeOffset TransactionTracerApdexF { get; set; }

        [JsonProperty("transaction_tracer.apdex_t")]
        public DateTimeOffset TransactionTracerApdexT { get; set; }

        [JsonProperty("transaction_tracer.transaction_threshold")]
        public DateTimeOffset TransactionTracerTransactionThreshold { get; set; }

        [JsonProperty("transaction_tracer.enabled")]
        public bool TransactionTracerEnabled { get; set; }

        [JsonProperty("transaction_tracer.max_segments")]
        public long TransactionTracerMaxSegments { get; set; }

        [JsonProperty("transaction_tracer.record_sql")]
        public string TransactionTracerRecordSql { get; set; }

        [JsonProperty("transaction_tracer.record_sql_source")]
        public string TransactionTracerRecordSqlSource { get; set; }

        [JsonProperty("transaction_tracer.stack_trace_threshold")]
        public DateTimeOffset TransactionTracerStackTraceThreshold { get; set; }

        [JsonProperty("transaction_tracer.max_stack_traces")]
        public long TransactionTracerMaxStackTraces { get; set; }

        [JsonProperty("agent.trusted_account_ids")]
        public object[] AgentTrustedAccountIds { get; set; }

        [JsonProperty("agent.server_side_config_enabled")]
        public bool AgentServerSideConfigEnabled { get; set; }

        [JsonProperty("agent.ignore_server_side_config")]
        public bool AgentIgnoreServerSideConfig { get; set; }

        [JsonProperty("agent.url_regex_rules")]
        public object[] AgentUrlRegexRules { get; set; }

        [JsonProperty("agent.request_path_exclusion_list")]
        public object[] AgentRequestPathExclusionList { get; set; }

        [JsonProperty("agent.web_transactions_apdex")]
        public Metadata AgentWebTransactionsApdex { get; set; }

        [JsonProperty("agent.wrapper_exception_limit")]
        public long AgentWrapperExceptionLimit { get; set; }

        [JsonProperty("utilization.detect_aws_enabled")]
        public bool UtilizationDetectAwsEnabled { get; set; }

        [JsonProperty("utilization.detect_azure_enabled")]
        public bool UtilizationDetectAzureEnabled { get; set; }

        [JsonProperty("utilization.detect_gcp_enabled")]
        public bool UtilizationDetectGcpEnabled { get; set; }

        [JsonProperty("utilization.detect_pcf_enabled")]
        public bool UtilizationDetectPcfEnabled { get; set; }

        [JsonProperty("utilization.detect_docker_enabled")]
        public bool UtilizationDetectDockerEnabled { get; set; }

        [JsonProperty("utilization.detect_kubernetes_enabled")]
        public bool UtilizationDetectKubernetesEnabled { get; set; }

        [JsonProperty("utilization.hostname")]
        public string UtilizationHostname { get; set; }

        [JsonProperty("utilization.full_hostname")]
        public string UtilizationFullHostname { get; set; }

        [JsonProperty("diagnostics.capture_agent_timing_enabled")]
        public bool DiagnosticsCaptureAgentTimingEnabled { get; set; }

        [JsonProperty("diagnostics.capture_agent_timing_frequency")]
        public long DiagnosticsCaptureAgentTimingFrequency { get; set; }

        [JsonProperty("agent.use_resource_based_naming_for_wcf_enabled")]
        public bool AgentUseResourceBasedNamingForWcfEnabled { get; set; }

        [JsonProperty("agent.event_listener_samplers_enabled")]
        public bool AgentEventListenerSamplersEnabled { get; set; }

        [JsonProperty("span_events.max_samples_stored")]
        public long SpanEventsMaxSamplesStored { get; set; }

        [JsonProperty("agent.payload_success_metrics_enabled")]
        public bool AgentPayloadSuccessMetricsEnabled { get; set; }

        [JsonProperty("agent.process_host_display_name")]
        public string AgentProcessHostDisplayName { get; set; }

        [JsonProperty("transaction_tracer.database_statement_cache_capacity")]
        public long TransactionTracerDatabaseStatementCacheCapacity { get; set; }

        [JsonProperty("agent.force_synchronous_timing_calculation_for_http_client")]
        public bool AgentForceSynchronousTimingCalculationForHttpClient { get; set; }

        [JsonProperty("agent.exclude_new_relic_header")]
        public bool AgentExcludeNewRelicHeader { get; set; }

        [JsonProperty("application_logging.enabled")]
        public bool ApplicationLoggingEnabled { get; set; }

        [JsonProperty("application_logging.metrics.enabled")]
        public bool ApplicationLoggingMetricsEnabled { get; set; }

        [JsonProperty("application_logging.forwarding.enabled")]
        public bool ApplicationLoggingForwardingEnabled { get; set; }

        [JsonProperty("application_logging.forwarding.max_samples_stored")]
        public long ApplicationLoggingForwardingMaxSamplesStored { get; set; }

        [JsonProperty("application_logging.harvest_cycle")]
        public DateTimeOffset ApplicationLoggingHarvestCycle { get; set; }

        [JsonProperty("application_logging.local_decorating.enabled")]
        public bool ApplicationLoggingLocalDecoratingEnabled { get; set; }

        [JsonProperty("agent.app_domain_caching_disabled")]
        public bool AgentAppDomainCachingDisabled { get; set; }

        [JsonProperty("agent.force_new_transaction_on_new_thread_enabled")]
        public bool AgentForceNewTransactionOnNewThreadEnabled { get; set; }

        [JsonProperty("agent.code_level_metrics_enabled")]
        public bool AgentCodeLevelMetricsEnabled { get; set; }

        [JsonProperty("agent.app_settings")]
        public Metadata AgentAppSettings { get; set; }

        public static ConnectMethodRequest[] FromJson(string json) => JsonConvert.DeserializeObject<ConnectMethodRequest[]>(json, Converter.Settings);
    }

    public class Utilization
    {
        [JsonProperty("metadata_version")]
        public long MetadataVersion { get; set; }

        [JsonProperty("logical_processors")]
        public long LogicalProcessors { get; set; }

        [JsonProperty("total_ram_mib")]
        public long TotalRamMib { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("full_hostname")]
        public string FullHostname { get; set; }

        [JsonProperty("ip_address")]
        public string[] IpAddress { get; set; }
    }

    public static class Serialize
    {
        public static string ToJson(this ConnectMethodRequest[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long[]);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (long[])untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }
}
