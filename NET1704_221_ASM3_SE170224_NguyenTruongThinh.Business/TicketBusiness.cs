
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Models;
using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Repository;

namespace NET1704_221_ASM3_SE170224_NguyenTruongThinh.Business
{
    public class TicketBusiness
    {
        private readonly TicketRepository _ticketRepository;

        public TicketBusiness(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            await _ticketRepository.CreateAsync(ticket);
            return ticket;
        }

        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            await _ticketRepository.UpdateAsync(ticket);
            return true;
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket != null)
            {
                await _ticketRepository.RemoveAsync(ticket);
                return true;
            }
            return false;
        }
    }
}
