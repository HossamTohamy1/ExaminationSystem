using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quizzes_System.Data;
using Quizzes_System.Models;
using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using System.Net.WebSockets;
namespace Quizzes_System.Repositories
{
    public class GeneralRepository <T> where T : BaseEntity
    {
        
        QuizzesDbContext _context;
        DbSet<T> _dbset;
        public GeneralRepository(QuizzesDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
            
        }

        public IQueryable<T> GetAll()
        {
            var res = _dbset.Where(x => !x.IsDeleted);
            return res;
        }
        public async Task <T> GetById(int id)
        {
            var res = await _dbset.Where(x => x.Id == id).FirstOrDefaultAsync();
            return res;

        }
        public IQueryable <T> Get(Expression<Func<T,bool>>expression)
        {
            var res = GetAll().Where(expression);
            return res;
        }
        public async Task<T> GetByIdWithTracking(int id)
        {
            var res = await _dbset.AsTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return res;
        }
        public async Task Add(T entity)
        {
            _dbset.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task  Delete (int id)
        {
            var res =  await GetByIdWithTracking(id);
            res.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateInclude(T entity, params string[] modifiedParams)
        {
            var existing = await _dbset.FindAsync(entity.Id);
            if (existing == null)
                return false;

            var entry = _context.Entry(existing);

            foreach (var prop in modifiedParams)
            {
                var newValue = entity.GetType().GetProperty(prop)?.GetValue(entity);
                entry.Property(prop).CurrentValue = newValue;
                entry.Property(prop).IsModified = true;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        //public async Task BulkUpdate(List<T> entities)
        //{
        //    if (entities == null || !entities.Any())
        //        return;

        //    var bulkConfig = new BulkConfig
        //    {
        //        UpdateByProperties = new List<string> { "Id" }, // from id we update the obj
        //        PropertiesToInclude = entities.First().GetType() // type of obj
        //                                  .GetProperties()       // get all properties for obj as{Name, Email, .... 
        //                                  .Where(p => p.Name != "Id" && p.Name != "IsDeleted") // after GetProperties we do not take id & isDelet for update
        //                                  .Select(p => p.Name)
        //                                  .ToList()
        //    };

        //    await _context.BulkUpdateAsync(entities, bulkConfig);
        //}


    }
}
