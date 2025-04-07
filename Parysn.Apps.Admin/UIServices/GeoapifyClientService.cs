using Newtonsoft.Json;

namespace Parysn.Apps.Admin.UIServices
{
    public class GeoapifyClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;

        public GeoapifyClientService(string? apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }
        public async Task<Root> GeocodeAddressAsync(string? address)
        {
            try
            {
                // Build the request URL
                string? url = $"https://api.geoapify.com/v1/geocode/search?text={Uri.EscapeDataString(address)}&format=json&apiKey={_apiKey}";

                // Send the GET request
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content as a string?
                string? jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into the Root object using Newtonsoft.Json
                Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

                return root;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network errors, invalid responses)
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
    public class Root
    {
        public List<Result>? Results { get; set; }
        public Query? Query { get; set; }
    }

    public class Result
    {
        public Datasource? Datasource { get; set; }
        public string? Country { get; set; }
        public string? Country_code { get; set; }
        public string? State { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
        public string? Street { get; set; }
        public string? Housenumber { get; set; }
        public string? Iso3166_2 { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string? State_code { get; set; }
        public string? Result_type { get; set; }
        public string? Formatted { get; set; }
        public string? Address_line1 { get; set; }
        public string? Address_line2 { get; set; }
        public string? Category { get; set; }
        public Timezone? Timezone { get; set; }
        public string? Plus_code { get; set; }
        public string? Plus_code_short { get; set; }
        public Rank? Rank { get; set; }
        public string? Place_id { get; set; }
        public Bbox? Bbox { get; set; }
    }

    public class Datasource
    {
        public string? Sourcename { get; set; }
        public string? Attribution { get; set; }
        public string? License { get; set; }
        public string? Url { get; set; }
    }

    public class Timezone
    {
        public string? Name { get; set; }
        public string? Offset_STD { get; set; }
        public int Offset_STD_seconds { get; set; }
        public string? Offset_DST { get; set; }
        public int Offset_DST_seconds { get; set; }
        public string? Abbreviation_STD { get; set; }
        public string? Abbreviation_DST { get; set; }
    }

    public class Rank
    {
        public double Importance { get; set; }
        public double Popularity { get; set; }
        public int Confidence { get; set; }
        public int Confidence_city_level { get; set; }
        public int Confidence_street_level { get; set; }
        public int Confidence_building_level { get; set; }
        public string? Match_type { get; set; }
    }

    public class Bbox
    {
        public double Lon1 { get; set; }
        public double Lat1 { get; set; }
        public double Lon2 { get; set; }
        public double Lat2 { get; set; }
    }

    public class Query
    {
        public string? Text { get; set; }
        public Parsed Parsed { get; set; }
    }

    public class Parsed
    {
        public string? Housenumber { get; set; }
        public string? Street { get; set; }
        public string? Postcode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Expected_type { get; set; }
    }
}
