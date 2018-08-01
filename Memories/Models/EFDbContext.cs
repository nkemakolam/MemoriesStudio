using Memories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;


using System.Linq;
using System.Web;

namespace Memories.Models
{
  public class EFDbContext : DbContext
  {
    public DbSet<MemoryImage> Images { get; set; }

  }
}
