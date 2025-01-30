// Models\WeatherModels.cs

namespace WeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class WeatherResponse
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("timeseries")]
        public List<TimeSeries> TimeSeries { get; set; }
    }

    public class TimeSeries
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("data")]
        public WeatherData Data { get; set; }
    }

    public class WeatherData
    {
        [JsonPropertyName("instant")]
        public InstantData Instant { get; set; }

        [JsonPropertyName("next_1_hours")]
        public SummaryData Next1Hours { get; set; }
    }

    public class InstantData
    {
        [JsonPropertyName("details")]
        public WeatherDetails Details { get; set; }
    }

    public class WeatherDetails
    {
        [JsonPropertyName("air_temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("relative_humidity")]
        public double Humidity { get; set; }
    }

    public class SummaryData
    {
        [JsonPropertyName("summary")]
        public WeatherSummary Summary { get; set; }
    }

    public class WeatherSummary
    {
        [JsonPropertyName("symbol_code")]
        public string SymbolCode { get; set; }
    }