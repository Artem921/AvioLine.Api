using System.Net.Http.Json;

namespace AvioLine.Clients.Base
{
    public class BaseClient:IDisposable
	{
		protected readonly HttpClient client;
		protected readonly string serviceAddress;

        protected BaseClient(string ServiceAddress) 
		{
			serviceAddress = ServiceAddress;

			var handler= new HttpClientHandler();

			handler.AllowAutoRedirect = false;

			client = new HttpClient(handler)
			{
				
			};

			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));	
		}
        /// <summary>
        /// Отправляет запрос к Api
        /// </summary>
        /// <typeparam name="T">возвращаемый тип ресурса</typeparam>
        /// <param name="url">адрес расположения Api</param>
        /// <returns></returns>
        /// 
  

        protected T Get<T>(string url) where T : new() => GetAsync<T>(url).Result;

        protected async Task<T> GetAsync<T>(string url) where T : new()
        {
            var response = await client.GetAsync(url);
       
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            return new T();
        }

        protected HttpResponseMessage Post<T>(string url, T item) => PostAsync(url, item).Result;
		protected async Task<HttpResponseMessage>PostAsync<T>(string url, T item)
        {
            var response = await client.PostAsJsonAsync(url, item);

			return response.EnsureSuccessStatusCode();
		}


        protected HttpResponseMessage Put<T>(string url, T item) => PutAsync(url, item).Result;
        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T item, CancellationToken cancel = default)
        {
            var response = await client.PutAsJsonAsync(url, item);
            return response.EnsureSuccessStatusCode();
        }


        protected HttpResponseMessage Delete(string url) =>DeleteAsync(url).Result;
        protected async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancel = default) => await client.DeleteAsync(url,cancel);
     
        #region IDisposable
        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool _disposed;

		protected virtual void	Dispose(bool disposing)
		{
			if (!_disposed || !disposing) return;
			_disposed = true;
			client.Dispose();
		}
        #endregion
    }
}
