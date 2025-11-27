// using api.Data;
// using api.Interfaces.Repositories;
// using api.Models;
// using Microsoft.EntityFrameworkCore;

// namespace api.Repositories;

// public class DealershipRepository : IDealershipRepository
// {

//     private readonly BackEndAPIContext _context;

//     public DealershipRepository (BackEndAPIContext context)
//     {
//         _context = context;
//     }

//     public async Task<Dealership> Create(Dealership dealership)
//     {
//         _context.Dealership.Add(dealership);
//         await _context.SaveChangesAsync();
//         return dealership;
//     }

//     public async Task<bool> Delete(long id)
//     {
//         var entity = await GetById(id);
//         if (entity == null)
//         {
//             return false;
//         }

//         _context.Dealership.Remove(entity);
//         await _context.SaveChangesAsync();
//         return true;
//     }

//     public async Task<List<Dealership>> GetAll()
//     {
//         return await _context.Dealership
//                        .Include(d => d.Address)
//                        .ToListAsync();
//     }

//     public async Task<Dealership?> GetById(long id)
//     {
//         return await _context.Dealership
//                              .Include(d => d.Address)
//                              .FirstOrDefaultAsync(d => d.Id == id);
//     }

//     public async Task<Dealership> Save(Dealership dealership)
//     {
//         await _context.SaveChangesAsync();
//         return dealership;
//     }

//     public async Task<Dealership> Update(Dealership dealership)
//     {
//         _context.Dealership.Update(dealership);
//         await _context.SaveChangesAsync();
//         return dealership;
//     }
// }