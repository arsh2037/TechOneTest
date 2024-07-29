
using Microsoft.AspNetCore.Mvc;
using TechOneTest2.Models;
using TechOneTest2.Services;

namespace TechOneTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberToWordsController : ControllerBase
    {
        private readonly INumberToWordsService _numberToWordsService;

        public NumberToWordsController(INumberToWordsService numberToWordsService)
        {
            _numberToWordsService = numberToWordsService;
        }

        [HttpPost]
        public ActionResult<NumberConversionModel> ConvertNumberToWords([FromBody] NumberConversionModel model)
        {
            model.OutputWords = _numberToWordsService.ConvertNumberToWords(model.InputNumber);
            return Ok(model);
        }
    }
}
