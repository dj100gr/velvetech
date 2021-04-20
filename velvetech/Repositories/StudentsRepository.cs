using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using velvetech.Infrastructure;
using velvetech.Models;

namespace velvetech.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly TzBdContex _context;

        public StudentsRepository(TzBdContex context)
        {
            _context = context;
        }

        public async Task<IStudent> SelectById(Guid id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id && !s.Removed.HasValue);

        }

        public async Task<IEnumerable<IStudent>> SelectAll()
        {
            return await _context.Students
                .Where(i => !i.Removed.HasValue)
                .ToListAsync();
        }

        public async Task<IEnumerable<IStudent>> SelectByAlias(string alias)
        {
            return await _context.Students
                .Where(s => !s.Removed.HasValue && s.Alias == alias)
                .ToListAsync();
        }

        public async Task Insert(IStudent entity)
        {
            var student = entity as Student ?? new Student();
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(IStudent entity)
        {
            var student = entity as Student ?? new Student();
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
