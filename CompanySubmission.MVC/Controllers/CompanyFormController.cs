using CompanySubmission.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanySubmission.MVC.Controllers
{
    public class CompanyFormController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CompanyFormController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> Submit(CompanyFormModel model)
        {
            if (!model.AllowAccessAfterClosing)
            {
                ModelState.AddModelError("AllowAccessAfterClosing", "You must agree before continuing.");
            }

            if (!ModelState.IsValid)
                return View("Index", model);

            var client = _clientFactory.CreateClient();

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(model.CompanyName), "CompanyName");
            content.Add(new StringContent(model.NPWP), "NPWP");
            content.Add(new StringContent(model.DirectorName), "DirectorName");
            content.Add(new StringContent(model.PICName), "PICName");
            content.Add(new StringContent(model.Email), "Email");
            content.Add(new StringContent(model.PhoneNumber), "PhoneNumber");
            content.Add(new StringContent(model.AllowAccessAfterClosing.ToString()), "AllowAccessAfterClosing");

            if (model.NPWPFile != null)
                content.Add(new StreamContent(model.NPWPFile.OpenReadStream()), "npwpFile", model.NPWPFile.FileName);

            if (model.PowerOfAttorneyFile != null)
                content.Add(new StreamContent(model.PowerOfAttorneyFile.OpenReadStream()), "powerFile", model.PowerOfAttorneyFile.FileName);

            var response = await client.PostAsync("https://localhost:7206/api/company", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API ERROR RESPONSE:");
                Console.WriteLine(errorBody);

                ModelState.AddModelError("", $"API error: {errorBody}");
                return View("Index", model);
            }
            else
            {
                TempData["Success"] = "Form submitted successfully.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Success() => View();
    }
}
