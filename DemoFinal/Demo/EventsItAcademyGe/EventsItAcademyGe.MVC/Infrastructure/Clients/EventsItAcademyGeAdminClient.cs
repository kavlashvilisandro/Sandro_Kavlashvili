using EventsItAcademyGe.MVC.Infrastructure.Models;
using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.MVC.Infrastructure.Clients.Models;
using System.Text.Json;

namespace EventsItAcademyGe.MVC.Infrastructure.Clients
{
    public class EventsItAcademyGeAdminClient
    {
        private readonly HttpClient _adminClient;
        private readonly IConfiguration _configuration;
        public EventsItAcademyGeAdminClient(HttpClient client, IConfiguration config)
        {
            this._adminClient = client;
            this._configuration = config;
        }

        public async Task<string> LoginAdmin(AdminDTO admin, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                response = await _adminClient.PostAsJsonAsync(_configuration.GetValue<string>("AdminLoginURL"), admin, token);
            }
            catch (Exception ex)
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

        public async Task<List<EventResponseModel>> GetPendingEvents(string jwt,CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                _adminClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _adminClient.GetAsync(_configuration.GetValue<string>("PendingEventsURL"),token);
            }
            catch (Exception ex)
            {
                throw new APIRequestError("API is down", 500);
            }
            string responseBody = await response.Content.ReadAsStringAsync(token);
            if ((int)response.StatusCode == 200)
            {
                return JsonSerializer.Deserialize<List<EventResponseModel>>(responseBody, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                APIExceptionResponseModel error = JsonSerializer.Deserialize<APIExceptionResponseModel>(responseBody);
                throw new APIRequestError(error.Error, error.StatusCode);
            }
        }

        public async Task ActivateEvent(string jwt,int EventID,CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                _adminClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _adminClient.PatchAsync(_configuration.GetValue<string>("ActivateEventURL") + EventID,null,token);
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

        public async Task ChangeUpdateTimeLimit(string jwt, int TimeLimit, CancellationToken token)
        {
            //api/Admin/ChangeEventUpdateTimeLimit/{Daysamount} POST
            HttpResponseMessage response;
            try
            {
                _adminClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _adminClient.PostAsync(_configuration.GetValue<string>("ChangeEventUpdateTimeLimitURL") + TimeLimit, null, token);
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
        public async Task SetAsModerator(string jwt, int UserID, CancellationToken token)
        {
            HttpResponseMessage response;
            try
            {
                _adminClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                response = await _adminClient.PatchAsync(_configuration.GetValue<string>("SetAsModeratorURL") + UserID, null, token);
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
