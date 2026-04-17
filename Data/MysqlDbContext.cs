using GentionDeDeportes.Models;
using Microsoft.EntityFrameworkCore;

namespace GentionDeDeportes.Data;

public class MysqlDbContext: DbContext
{
    public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Eventos> Eventos { get; set; }
}