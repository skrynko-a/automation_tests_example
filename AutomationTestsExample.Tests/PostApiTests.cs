using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AutomationTestsExample.Tests
{
    [TestFixture]
    public class PostApiTests
    {
        private ResponsePost _responseObj;
        
        [OneTimeSetUp]
        public async Task Setup()
        {
            // Системный класс распространяет уведомление о том, что операции следует отменить.
            CancellationToken ct = new CancellationToken();
   
            // универсальный код ресурса (URI) - куда нужно отправлять запрос
            var baseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
            
            // генерируем body для POST запроса
            RequestPost request = new RequestPost("POST request", 12345, "I hope, it’s gonna be work");
            
            // инициализируем класс для отправки http запросов
            // using указывает на то, что после выполнения данного участка кода в {} нужно освободить ресурсы, которые захватил объект
            using (var client = new HttpClient { BaseAddress = baseAddress })
            {
                // Отправка запроса POST по указанному URI в качестве асинхронной операции.
                var result = await client.PostAsJsonAsync(baseAddress, request, ct);
                
                // Конвертируем содержимое ответа (result) в строку
                var responseString = await result.Content.ReadAsStringAsync(ct);

                // Парсим строку в json (Получаем экзепляр класса ResponsePost, в который помещаются все данные из полученного json)
                _responseObj = JsonConvert.DeserializeObject<ResponsePost>(responseString);
            }

            // Проверка, что вообще есть какой-то ответ и есть смысл выполнять проверки
            if (_responseObj == null) {Assert.Fail("Ответ от api = null, выполнение следующих проверок не имеет смысла");
            }
        }

        [Test]
        public async Task CheckIdFromPostResponseTesting()
        {
            Assert.AreEqual(101, _responseObj.Id, "полученный Id некорректен");
        }
    }
}