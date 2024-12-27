using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace govno_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonentController : ControllerBase
    {
        public async Task<List<Record>> SearchAsync(string searchTerm)
        {
            // Convert the user's search term into a SQL LIKE pattern
            var likePattern = searchTerm
                .Replace('*', '%') // Replace '*' with '%'
                .Replace('?', '_'); // Replace '?' with '_'

            // Build the query
            var query = _context.Records
                .Where(record =>
                    EF.Functions.Like(record.LastName, likePattern) ||
                    EF.Functions.Like(record.FirstName, likePattern) ||
                    EF.Functions.Like(record.Email, likePattern) ||
                    EF.Functions.Like(record.PhoneNumber, likePattern) ||
                    EF.Functions.Like(record.Address, likePattern));

            // Execute and return results
            return await query.ToListAsync();
        }

    }
}
