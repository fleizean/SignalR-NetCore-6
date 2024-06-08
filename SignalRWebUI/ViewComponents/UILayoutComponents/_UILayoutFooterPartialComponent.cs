using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.FooterDtos;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.Models.Footer;
using SignalRWebUI.Models.Product;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutFooterPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Footer/1");
            var footer = new ResultFooterDto();
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                footer = JsonConvert.DeserializeObject<ResultFooterDto>(jsonData);
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7083/api/Contact/1");
            var contact = new ResultContactDto();
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                contact = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7083/api/SocialMedia");
            var socialmedia = new List<ResultSocialMediaDto>();
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                socialmedia = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            }

            var viewModel = new FooterandContactViewModel
            {
                Footer = footer,
                Contact = contact,
                SocialMedia = socialmedia
            };

            return View(viewModel);
        }
    }
}

