using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace Weather
{
    // Properties for the underlying generated data from the proto file.
    // This partial class just adds extra properties for convenience.
    internal partial class WeatherForecast
    {
        public DateTime DateTime
        {
            get => Date.ToDateTime();
            set { Date= Timestamp.FromDateTime(value.ToUniversalTime());}
        }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    }
}
