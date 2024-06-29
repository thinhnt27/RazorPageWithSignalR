using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Business;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Models;

namespace NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp.Pages.TicketPage
{
    public class IndexModel : PageModel
    {
        private readonly TicketBusiness _ticketBusiness;

        public IndexModel(TicketBusiness ticketBusiness)
        {
            _ticketBusiness = ticketBusiness;
        }

        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();

        public async Task OnGetAsync()
        {
            Tickets = await _ticketBusiness.GetAllTicketsAsync();
        }
    }
}
