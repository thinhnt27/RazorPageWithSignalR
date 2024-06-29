using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Business;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Models;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp.Pages.MessageHub;

namespace NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp.Pages.TicketPage
{
    public class CreateModel : PageModel
    {
        private readonly TicketBusiness _ticketBusiness;
        private readonly IHubContext<TicketHub> _hubContext;

        public CreateModel(TicketBusiness ticketBusiness, IHubContext<TicketHub> hubContext)
        {
            _ticketBusiness = ticketBusiness;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var createdTicket = await _ticketBusiness.CreateTicketAsync(Ticket);
            await _hubContext.Clients.All.SendAsync("ReceiveTicketCreate", createdTicket);

            return RedirectToPage("./Index");
        }
    }
}
