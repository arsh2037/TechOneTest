
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechOneTest2.Services;

namespace NumberToWords.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INumberToWordsService _numberToWordsService;

        public IndexModel(INumberToWordsService numberToWordsService)
        {
            _numberToWordsService = numberToWordsService;
        }

        [BindProperty]
        public string InputNumber { get; set; }

        public string OutputWords { get; set; }

        public void OnPost()
        {
            OutputWords = _numberToWordsService.ConvertNumberToWords(InputNumber);
        }
    }
}
