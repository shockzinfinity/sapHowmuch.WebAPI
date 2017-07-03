using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http.Tracing;

namespace sapHowmuch.Api.Web.Infrastructure
{
	/// <summary>
	/// Log class based nLog package
	/// </summary>
	public class NLogger : ITraceWriter
	{
		private static readonly Logger _classLogger = LogManager.GetCurrentClassLogger();

		private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> _loggingMap = new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>>
		{
			{ TraceLevel.Info, _classLogger.Info },
			{ TraceLevel.Debug, _classLogger.Debug },
			{ TraceLevel.Error, _classLogger.Error },
			{ TraceLevel.Fatal, _classLogger.Fatal },
			{ TraceLevel.Warn, _classLogger.Warn }
		});

		private Dictionary<TraceLevel, Action<string>> _logger { get { return _loggingMap.Value; } }

		/// <summary>
		/// Trace log
		/// </summary>
		/// <param name="request"></param>
		/// <param name="category"></param>
		/// <param name="level"></param>
		/// <param name="traceAction"></param>
		public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
		{
			if (level != TraceLevel.Off)
			{
				if (traceAction != null && traceAction.Target != null)
				{
					category = category + Environment.NewLine + "Action Parameters: " + JsonConvert.SerializeObject(traceAction.Target);
				}

				var record = new TraceRecord(request, category, level);

				traceAction?.Invoke(record);

				Log(record);
			}
		}

		private void Log(TraceRecord record)
		{
			var message = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(record.Message))
			{
				message.Append("").AppendLine(record.Message);
			}

			if (record.Request != null)
			{
				if (record.Request.Method != null)
					message.AppendLine("Method: " + record.Request.Method);

				if (record.Request.RequestUri != null)
					message.Append("").AppendLine("URL: " + record.Request.RequestUri);

				if (record.Request.Headers != null &&
					record.Request.Headers.Contains("Authorization") &&
					record.Request.Headers.GetValues("Authorization") != null &&
					record.Request.Headers.GetValues("Authorization").FirstOrDefault() != null)
					message.Append("").AppendLine("Authorization: " + record.Request.Headers.GetValues("Authorization").FirstOrDefault());

				if (!string.IsNullOrWhiteSpace(record.Category))
					message.Append("").AppendLine(record.Category);

				if (!string.IsNullOrWhiteSpace(record.Operator))
					message.Append("").Append(record.Operator).Append("").AppendLine(record.Operation);

				if (record.Exception != null && !string.IsNullOrWhiteSpace(record.Exception.GetBaseException().Message))
				{
					var exceptionType = record.Exception.GetType();
					message.AppendLine("").AppendLine("Error: " + record.Exception.GetBaseException().Message);
				}

				_logger[record.Level](Convert.ToString(message) + Environment.NewLine);
			}
		}
	}
}