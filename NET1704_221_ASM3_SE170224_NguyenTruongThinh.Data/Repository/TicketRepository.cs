

using NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Models;

namespace NET1704_221_ASM3_SE170224_NguyenTruongThinh.Data.Repository
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        public TicketRepository()
        {
        }

        public TicketRepository(ASM3_221_SE170224Context context) => _context = context;
    }
}
