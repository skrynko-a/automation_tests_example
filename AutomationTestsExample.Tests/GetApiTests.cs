using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AutomationTestsExample.Tests
{
    [TestFixture]
    public class GetApiTests
    {
        private ResponseGet _responseObj;
        
        [OneTimeSetUp]
        public async Task Setup()
        {
            // Распространяет уведомление о том, что операции следует отменить.
            CancellationToken ct = new CancellationToken();

            // универсальный код ресурса (URI) - куда нужно отправлять запрос
            var baseAddress = new Uri("https://gorest.co.in/public-api/users");
            
            // инициализируем системный класс для отправки http запросов
            // using указывает на то, что после выполнения данного участка кода в {} нужно освободить ресурсы, которые захватил объект
            using (var client = new HttpClient { BaseAddress = baseAddress })
            {
                // Отправка запроса GET по указанному URI в качестве асинхронной операции.
                var result = await client.GetAsync(baseAddress, ct);
                
                // Конвертируем содержимое ответа (result) в строку
                var responseString = await result.Content.ReadAsStringAsync(ct);

                // Парсим строку в json (Получаем экзепляр класса ResponseGet, в который помещаются все данные из полученного json)
                _responseObj = JsonConvert.DeserializeObject<ResponseGet>(responseString);
                
                if (_responseObj == null) { Assert.Fail("Ответ от api = null, выполнение следующих проверок не имеет смысла"); }
            }
        }

        [Test]
        public async Task CheckResponseCodeFromGetRequestTesting()
        {
            Assert.AreEqual(_responseObj.Code,  200, "полученный code некорректен");
        }
        
        [Test]
        public async Task CheckResponseFieldTotalFromGetRequestTesting()
        {
            Assert.AreEqual(1524, _responseObj.Meta.Pagination.Total,  "полученное значение поля Total некорректено");
        }
    }
}