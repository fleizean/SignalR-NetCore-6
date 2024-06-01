using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
        private readonly SignalRContext _context;

        public SignalRHub(SignalRContext context)
        {
            _context = context;
        }

        public async Task TakeDashboardCounts()
        {
            var categoryCount = await _context.Categories.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var bookingCount = await _context.Bookings.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var contactCount = await _context.Contacts.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var productCount = await _context.Products.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var discountCount = await _context.Discounts.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var socialMediaCount = await _context.SocialMedias.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var testimonialCount = await _context.Testimonials.AsNoTracking().Where(a => a.Status == true).CountAsync();
            var featureCount = await _context.Features.AsNoTracking().Where(a => a.Status == true).CountAsync();

            var dashboardCounts = new
            {
                CategoryCount = categoryCount,
                BookingCount = bookingCount,
                ContactCount = contactCount,
                ProductCount = productCount,
                DiscountCount = discountCount,
                SocialMediaCount = socialMediaCount,
                TestimonialCount = testimonialCount,
                FeatureCount = featureCount,
            };

            await Clients.Caller.SendAsync("ReceiveDashboardCounts", dashboardCounts);
        }

       
    }
}

