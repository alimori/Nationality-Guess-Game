using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalityGuessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonNationalityController : ControllerBase
    {
        private static readonly PersonNationality[] FakePersonNationalities = new[]
        {
            PersonNationality.CreateInstance(1,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (1).jpg"),
            PersonNationality.CreateInstance(2,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (2).jpg"),
            PersonNationality.CreateInstance(3,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (3).jpg"),
            PersonNationality.CreateInstance(4,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (4).jpg"),
            PersonNationality.CreateInstance(5,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (5).jpg"),
            PersonNationality.CreateInstance(6,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (6).jpg"),
            PersonNationality.CreateInstance(7,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (7).jpg"),
            PersonNationality.CreateInstance(8,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (8).jpg"),
            PersonNationality.CreateInstance(9,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (9).jpg"),
            PersonNationality.CreateInstance(10,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (10).jpg"),
            PersonNationality.CreateInstance(11,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (11).jpg"),
            PersonNationality.CreateInstance(12,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (12).jpg"),
            PersonNationality.CreateInstance(13,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (13).jpg"),
            PersonNationality.CreateInstance(14,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (14).jpg"),
            PersonNationality.CreateInstance(15,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (15).jpg"),
            PersonNationality.CreateInstance(16,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (16).jpg"),
            PersonNationality.CreateInstance(17,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (17).jpg"),
            PersonNationality.CreateInstance(18,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (18).jpg"),
            PersonNationality.CreateInstance(19,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (19).jpg"),
            PersonNationality.CreateInstance(20,NationalityEnum.CHINESE, "../../assets/Chinese/Chinese (20).jpg"),

            PersonNationality.CreateInstance(101,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (1).jpg"),
            PersonNationality.CreateInstance(102,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (2).jpg"),
            PersonNationality.CreateInstance(103,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (3).jpg"),
            PersonNationality.CreateInstance(104,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (4).jpg"),
            PersonNationality.CreateInstance(105,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (5).jpg"),
            PersonNationality.CreateInstance(106,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (6).jpg"),
            PersonNationality.CreateInstance(107,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (7).jpg"),
            PersonNationality.CreateInstance(108,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (8).jpg"),
            PersonNationality.CreateInstance(109,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (9).jpg"),
            PersonNationality.CreateInstance(110,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (10).jpg"),
            PersonNationality.CreateInstance(111,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (11).jpg"),
            PersonNationality.CreateInstance(112,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (12).jpg"),
            PersonNationality.CreateInstance(113,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (13).jpg"),
            PersonNationality.CreateInstance(114,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (14).jpg"),
            PersonNationality.CreateInstance(115,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (15).jpg"),
            PersonNationality.CreateInstance(116,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (16).jpg"),
            PersonNationality.CreateInstance(117,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (17).jpg"),
            PersonNationality.CreateInstance(118,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (18).jpg"),
            PersonNationality.CreateInstance(119,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (19).jpg"),
            PersonNationality.CreateInstance(120,NationalityEnum.JAPANESE, "../../assets/Japanese/Japanese (20).jpg"),

            PersonNationality.CreateInstance(201,NationalityEnum.KOREAN,"../../assets/Korean/Korean (1).jpg"),
            PersonNationality.CreateInstance(202,NationalityEnum.KOREAN,"../../assets/Korean/Korean (2).jpg"),
            PersonNationality.CreateInstance(203,NationalityEnum.KOREAN,"../../assets/Korean/Korean (3).jpg"),
            PersonNationality.CreateInstance(204,NationalityEnum.KOREAN,"../../assets/Korean/Korean (4).jpg"),
            PersonNationality.CreateInstance(205,NationalityEnum.KOREAN,"../../assets/Korean/Korean (5).jpg"),
            PersonNationality.CreateInstance(206,NationalityEnum.KOREAN,"../../assets/Korean/Korean (6).jpg"),
            PersonNationality.CreateInstance(207,NationalityEnum.KOREAN,"../../assets/Korean/Korean (7).jpg"),
            PersonNationality.CreateInstance(208,NationalityEnum.KOREAN,"../../assets/Korean/Korean (8).jpg"),
            PersonNationality.CreateInstance(209,NationalityEnum.KOREAN,"../../assets/Korean/Korean (9).jpg"),
            PersonNationality.CreateInstance(210,NationalityEnum.KOREAN,"../../assets/Korean/Korean (10).jpg"),
            PersonNationality.CreateInstance(211,NationalityEnum.KOREAN,"../../assets/Korean/Korean (11).jpg"),
            PersonNationality.CreateInstance(212,NationalityEnum.KOREAN,"../../assets/Korean/Korean (12).jpg"),
            PersonNationality.CreateInstance(213,NationalityEnum.KOREAN,"../../assets/Korean/Korean (13).jpg"),
            PersonNationality.CreateInstance(214,NationalityEnum.KOREAN,"../../assets/Korean/Korean (14).jpg"),
            PersonNationality.CreateInstance(215,NationalityEnum.KOREAN,"../../assets/Korean/Korean (15).jpg"),
            PersonNationality.CreateInstance(216,NationalityEnum.KOREAN,"../../assets/Korean/Korean (16).jpg"),
            PersonNationality.CreateInstance(217,NationalityEnum.KOREAN,"../../assets/Korean/Korean (17).jpg"),
            PersonNationality.CreateInstance(218,NationalityEnum.KOREAN,"../../assets/Korean/Korean (18).jpg"),
            PersonNationality.CreateInstance(219,NationalityEnum.KOREAN,"../../assets/Korean/Korean (18).jpg"),
            PersonNationality.CreateInstance(220,NationalityEnum.KOREAN,"../../assets/Korean/Korean (20).jpg"),

            PersonNationality.CreateInstance(301,NationalityEnum.THAI, "../../assets/Thai/Thai (1).jpg"),
            PersonNationality.CreateInstance(302,NationalityEnum.THAI, "../../assets/Thai/Thai (2).jpg"),
            PersonNationality.CreateInstance(303,NationalityEnum.THAI, "../../assets/Thai/Thai (3).jpg"),
            PersonNationality.CreateInstance(304,NationalityEnum.THAI, "../../assets/Thai/Thai (4).jpg"),
            PersonNationality.CreateInstance(305,NationalityEnum.THAI, "../../assets/Thai/Thai (5).jpg"),
            PersonNationality.CreateInstance(306,NationalityEnum.THAI, "../../assets/Thai/Thai (6).jpg"),
            PersonNationality.CreateInstance(307,NationalityEnum.THAI, "../../assets/Thai/Thai (7).jpg"),
            PersonNationality.CreateInstance(308,NationalityEnum.THAI, "../../assets/Thai/Thai (8).jpg"),
            PersonNationality.CreateInstance(309,NationalityEnum.THAI, "../../assets/Thai/Thai (9).jpg"),
            PersonNationality.CreateInstance(310,NationalityEnum.THAI, "../../assets/Thai/Thai (10).jpg"),
            PersonNationality.CreateInstance(311,NationalityEnum.THAI, "../../assets/Thai/Thai (11).jpg"),
            PersonNationality.CreateInstance(312,NationalityEnum.THAI, "../../assets/Thai/Thai (12).jpg"),
            PersonNationality.CreateInstance(313,NationalityEnum.THAI, "../../assets/Thai/Thai (13).jpg"),
            PersonNationality.CreateInstance(314,NationalityEnum.THAI, "../../assets/Thai/Thai (14).jpg"),
            PersonNationality.CreateInstance(315,NationalityEnum.THAI, "../../assets/Thai/Thai (15).jpg"),
            PersonNationality.CreateInstance(316,NationalityEnum.THAI, "../../assets/Thai/Thai (16).jpg"),
            PersonNationality.CreateInstance(317,NationalityEnum.THAI, "../../assets/Thai/Thai (17).jpg"),
            PersonNationality.CreateInstance(318,NationalityEnum.THAI, "../../assets/Thai/Thai (18).jpg"),
            PersonNationality.CreateInstance(319,NationalityEnum.THAI, "../../assets/Thai/Thai (19).jpg"),
            PersonNationality.CreateInstance(320,NationalityEnum.THAI, "../../assets/Thai/Thai (20).jpg"),
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public PersonNationalityController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PersonNationality> Get()
        {
            Random random = new Random();
            var result = FakePersonNationalities.OrderBy(x => random.Next()).Take(10);
            return result;
        }
    }
}

