using EventsItAcademyGe.MVC.Infrastructure.Models;
using EventsItAcademyGe.Domain.Exceptions;
using System.Text.Json;
using EventsItAcademyGe.MVC.Infrastructure.Clients.Models;

namespace EventsItAcademyGe.MVC.Infrastructure.Clients
{
    public class EventsItAcademyGePublicClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public EventsItAcademyGePublicClient(HttpClient client, IConfiguration config)
        {
            this._client = client;
            this._configuration = config;
        }
        public async Task<List<EventModel>> GetActiveEventsAsync(CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(_configuration.GetValue<string>("GetActiveEventsURL"), token);
            }
            catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if ((int)response.StatusCode == 200)
            {
                return JsonSerializer.Deserialize<List<EventModel>>(responseBody,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                throw new APIRequestError(error.Error, error.StatusCode);
            }
        }

        public async Task<EventModel> GetEventByID(int EventID, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(_configuration.GetValue<string>("GetEventByIDURL") + EventID, token);
            }
            catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if ((int)response.StatusCode == 200)
            {
                return JsonSerializer.Deserialize<EventModel>(responseBody,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody);
                throw new APIRequestError(error.Error, error.StatusCode);
            }
            
        }
    
        public async Task<string> LogIn(UserModelDTO user, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync(_configuration.GetValue<string>("LoginURL"), user, token);
            }catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if((int)response.StatusCode == 200)
            {
                return responseBody;
            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody);
                throw new APIRequestError(error.Error, error.StatusCode);
            }
        }
    
        public async Task Register(UserModelDTO user,CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync(_configuration.GetValue<string>("RegisterURL"), user, token);
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
