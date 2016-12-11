using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AzureAlphaBetaRouter.Routing.Models
{
    public class AzureWebsiteRoutingEntites
    {
        [DataContract]
        public class MetricsWrapper
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember]
            public object Activity { get; set; }
        }

        [DataContract]
        public class Metrics
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            public SiteHttpActivity Activity { get; set; }
        }


        /// <summary>
        /// Return information how to change TiP ramp up percentage.
        /// Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
        /// Either way MinRoutingPercentage and MaxRoutingPercentage set in API rule are in force
        /// </summary>
        [DataContract]
        public class ChangeDirectionResult
        {
            /// <summary>
            /// Step to change the Routing percentage. Positive number will increase it routing.
            /// Negative will decrease it.
            /// </summary>
            [DataMember(Name = "step")]
            public int? Step { get; set; }

            /// <summary>
            /// Hard routing percentage to set regardless of step.
            /// </summary>
            [DataMember(Name = "routingPercentage")]
            public int? RoutingPercentage { get; set; }
        }

        [DataContract]
        public class RerouteChangeRequest
        {
            [DataMember]
            public Dictionary<string, SiteHttpActivity> Metrics { get; set; }
        }

        [DataContract]
        public class SiteHttpActivity
        {
            [DataMember]
            public long Requests { get; set; }

            [DataMember]
            public long IncomingRequestResponseBytes { get; set; }

            [DataMember]
            public long IncomingRequestBytes { get; set; }

            [DataMember]
            public long OutgoingRequestResponseBytes { get; set; }

            [DataMember]
            public long OutgoingRequestBytes { get; set; }

            [DataMember]
            public long LocalReadBytes { get; set; }

            [DataMember]
            public long LocalWrittenBytes { get; set; }

            [DataMember]
            public long NetworkReadBytes { get; set; }

            [DataMember]
            public long NetworkWrittenBytes { get; set; }

            [DataMember]
            public int StopRequests { get; set; }

            [DataMember]
            public TimeSpan ProcessorTime { get; set; }

            [DataMember]
            public int Http2xx { get; set; }

            [DataMember]
            public int Http3xx { get; set; }

            [DataMember]
            public int Http401 { get; set; }

            [DataMember]
            public int Http403 { get; set; }

            [DataMember]
            public int Http404 { get; set; }

            [DataMember]
            public int Http406 { get; set; }

            [DataMember]
            public int Http4xx { get; set; }

            [DataMember]
            public int Http5xx { get; set; }

            [DataMember]
            public long CurrentMemoryWorkingSet { get; set; }

            [DataMember]
            public long MaxMemoryWorkingSet { get; set; }

            [DataMember]
            public long MinMemoryWorkingSet { get; set; }

            [DataMember]
            public double AverageMemoryWorkingSet { get; set; }

            [DataMember]
            public double AverageTimeTaken { get; set; }
        }
    }
}
