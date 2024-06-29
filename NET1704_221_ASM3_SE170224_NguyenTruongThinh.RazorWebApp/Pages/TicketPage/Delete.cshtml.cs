﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Business;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Models;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp.Pages.MessageHub;

namespace NET1704_221_ASM3_SE170224_NguyenTruongThinh.RazorWebApp.Pages.TicketPage
{
    public class DeleteModel : PageModel
    {
        private readonly TicketBusiness _ticketBusiness;
        private readonly IHubContext<TicketHub> _hubContext;

        public DeleteModel(TicketBusiness ticketBusiness, IHubContext<TicketHub> hubContext)
        {
            _ticketBusiness = ticketBusiness;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

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

            Ticket = ticket;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool success = await _ticketBusiness.DeleteTicketAsync(id.Value);
            if (success)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveTicketDelete", id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
