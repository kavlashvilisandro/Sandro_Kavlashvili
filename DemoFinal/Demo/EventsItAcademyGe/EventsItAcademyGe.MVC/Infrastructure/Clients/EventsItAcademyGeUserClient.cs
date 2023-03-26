using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.MVC.Infrastructure.Clients.Models;
using EventsItAcademyGe.MVC.Infrastructure.Models;
using System.Text.Json;

namespace EventsItAcademyGe.MVC.Infrastructure.Clients
{
    public class EventsItAcademyGeUserClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public EventsItAcademyGeUserClient(HttpClient client, IConfiguration config)
        {
            this._configuration = config;
            this._client = client;
        }

        public async Task BuyTicket(string jwt, int EventID, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _client.GetAsync(_configuration.GetValue<string>("BuyTicketURL") + EventID, token);
            }
            catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if ((int)response.StatusCode == 200)
            {
                return;

            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody);
                throw new APIRequestError(error.Error, error.StatusCode);
            }
        }

        public async Task ReserveTicket(string jwt, int EventID, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _client.PostAsync(_configuration.GetValue<string>("ReserveTicketURL") + EventID, null, token);
            }
            catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if ((int)response.StatusCode == 200)
            {
                return;
            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody);
                throw new APIRequestError(error.Error, error.StatusCode);
            }

        }

        public async Task AddEvent(RegisterEventDTO @event, string jwt, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _client.PostAsJsonAsync(_configuration.GetValue<string>("AddEventURL"), @event, token);
            }
            catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if ((int)response.StatusCode == 200)
            {
                return;
            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody);
                throw new APIRequestError(error.Error, error.StatusCode);
            }
        }
    }
}
