using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
	class Program
	{
		static void Main(string[] args)
		{
			RunAsync().Wait();
		}

		static async Task RunAsync()
		{
			// On the first entry, it retrieves a list of entries from the API
			// On subsequent calls, it retrieves the list if input value == 0 or otherwise the list again
			string InputId = string.Empty;
			int id = 0;

			do
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("http://localhost:3799/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					string url = "api/GreatApi";

					if (id != 0) url += $"/{id.ToString()}";

					using (HttpResponseMessage response = await client.GetAsync(url))
					{
						if (response.IsSuccessStatusCode)
						{
							if (id == 0)
							{
								IEnumerable<MyGreatTable> data = await response.Content.ReadAsAsync<IEnumerable<MyGreatTable>>();

								if (data != null && data.Count() > 0)
								{
									Console.WriteLine($"{data.Count().ToString()} great piece(s) of data retrieved!");

									foreach (MyGreatTable mgt in data)
									{
										Console.WriteLine($"{string.Format("{0,3:##0}", mgt.MyGreatTableId)}: {mgt.GreatField}");
									}
								}
								else
									Console.WriteLine("No data");
							}
							else
							{
								MyGreatTable data = await response.Content.ReadAsAsync<MyGreatTable>();
								if (data != null)
									Console.WriteLine($"{string.Format("{0,3:##0}", data.MyGreatTableId)}: {data.GreatField}");
								else
									Console.WriteLine("No data with that ID");
							}
						}
						else
						{
							Console.WriteLine($"Not a successful call: {response.StatusCode}: {response.ReasonPhrase}");
						}
					}
				}

				Console.Write("\r\nType an ID number for details, 0 for a new list, empty to quit: ");
				InputId = Console.ReadLine();

				if (!int.TryParse(InputId, out id))
					break;

			} while (!string.IsNullOrWhiteSpace(InputId));

			Console.WriteLine("Bye!");
			Console.ReadKey();
		}
	}
}
