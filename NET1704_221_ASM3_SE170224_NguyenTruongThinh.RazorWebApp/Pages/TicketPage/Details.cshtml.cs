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
    public class DetailsModel : PageModel
    {
        private readonly TicketBusiness _ticketBusiness;

        public DetailsModel(TicketBusiness ticketBusiness)
        {
            _ticketBusiness = ticketBusiness;
        }

        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketBusiness.GetTicketByIdAsync(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                Ticket = ticket;
            }
            return Page();
        }
    }
}
