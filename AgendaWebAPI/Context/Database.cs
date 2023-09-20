using AgendaWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AgendaWebAPI.Context;

public class Database : DbContext
{
    public DbSet<Agenda> Agendas { get; set; }

    public Database(DbContextOptions<Database> options) : base(options)
    {
    }
}