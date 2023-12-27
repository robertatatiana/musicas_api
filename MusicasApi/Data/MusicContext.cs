using Microsoft.EntityFrameworkCore;
using MusicasApi.Models;

namespace MusicasApi.Data;

public class MusicContext : DbContext
{
    public MusicContext(DbContextOptions<MusicContext> opts) : base(opts)
    {
        
    }

    public DbSet<Music> Musicas { get; set; }
}
