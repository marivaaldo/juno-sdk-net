using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests
{
    public class RequestContext
    {
        public IEnvironment Environment { get; set; }
        public HttpClient HttpClient { get; set; }
        public Credentials Credentials { get; set; }
        public AuthorizationToken AuthorizationToken { get; set; }
    }

    public abstract class AbstractRequest : AbstractRequest<string>
    {
        public AbstractRequest(RequestContext context)
            : base(context)
        {
        }
    }

    public abstract class AbstractRequest<Response> : AbstractRequest<string, Response>
        where Response : class
    {
        public AbstractRequest(RequestContext context)
            : base(context)
        {
        }

        public abstract Response Execute();

        public override sealed Response Execute(string param)
        {
            return Execute();
        }
    }

    public abstract class AbstractRequest<Request, Response>
        where Request : class
        where Response : class
    {
        private static readonly JsonSerializerOptions _JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        protected readonly RequestContext _Context;

        public AbstractRequest(RequestContext context)
        {
            _Context = context;
        }

        public abstract Response Execute(Request param);

        protected Response Post(string url, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Post<T>(string url, T param = null, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
            where T : class, new()
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = param != null ? new JsonContent<T>(param) : null
            };

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Put(string url, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Put, url);

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Put<T>(string url, T param = null, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
            where T : class, new()
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = param != null ? new JsonContent<T>(param) : null
            };

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Patch(string url, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Patch, url);

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Patch<T>(string url, T param = null, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
            where T : class, new()
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Patch, url)
            {
                Content = param != null ? new JsonContent<T>(param) : null
            };

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Get(string url, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected Response Delete(string url, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            url = GetUrl(url, baseUrl);

            using var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = SendRequest(request, resourceToken);

            return ReadResponse(response);
        }

        protected HttpResponseMessage SendRequest(HttpRequestMessage request, string resourceToken = null, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            if (baseUrl == EnvironmentUrl.Resources)
            {
                if (string.IsNullOrWhiteSpace(resourceToken))
                {
                    resourceToken = _Context.Credentials.PrivateToken;
                }

                if (_Context.AuthorizationToken == null || string.IsNullOrWhiteSpace(_Context.AuthorizationToken.AccessToken))
                {
                    throw new JunoRequestException("API is not authenticated", new JunoError(-1, "API is not authenticated"));
                }

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _Context.AuthorizationToken.AccessToken);
                request.Headers.TryAddWithoutValidation("X-Resource-Token", resourceToken);
            }
            else
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _Context.Credentials.Hash);
            }

            return _Context.HttpClient.Send(request);
        }

        public static string ReadPlainResponse(HttpResponseMessage responseMessage)
        {
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    {
                        return responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }
                case HttpStatusCode.NoContent:
                    {
                        return null;
                    }
                case HttpStatusCode.NotFound:
                    {
                        throw new JunoRequestException("Not found", new JunoError(404, "Not found"));
                    }
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.InternalServerError:
                default:
                    {
                        var contents = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                        var error = JsonSerializer.Deserialize<JunoError>(contents, _JsonSerializerOptions);

                        JunoRequestException exception = new JunoRequestException(error.Error, error);

                        throw exception;
                    }
            }
        }

        protected Response ReadResponse(HttpResponseMessage responseMessage)
        {
            var contents = ReadPlainResponse(responseMessage);

            if (string.IsNullOrWhiteSpace(contents))
                return null;
            else
                return JsonSerializer.Deserialize<Response>(contents, _JsonSerializerOptions);
        }

        protected string GetUrl(string resource, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            return _Context.Environment.GetUrl(resource, baseUrl);
        }

        #region Private Methods

        #endregion
    }
}
