using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.Communication.Common;

public class GenericRequestBuilder : IGenericRequestBuilder
{
	private HttpClient Client { get; }

	public GenericRequestBuilder(HttpClient client)
	{
		this.Client = client;
	}

	public async Task<TResponseModel> CreateRequest<TResponseModel>(GenericRequestModel model) where TResponseModel : class
	{
		try
		{
			var requestMessage = new HttpRequestMessage();
			requestMessage.RequestUri = new Uri(model.Url);
			requestMessage.Method = new HttpMethod(model.Method);
			requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(model.ContentType));

			model.Headers.ForEach(x =>
			{
				requestMessage.Headers.Add(x.Name, x.Value);
			});

			if (requestMessage.Method == HttpMethod.Post)
			{
				requestMessage.Content = new StringContent(JsonConvert.SerializeObject(model.Body, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Ignore,
				}), Encoding.UTF8, model.ContentType);
			}

			var response = await this.Client.SendAsync(requestMessage);

			var jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TResponseModel>(jsonResponse)!;
		}
		catch (Exception e)
		{
			return Activator.CreateInstance<TResponseModel>();
		}
	}
}
