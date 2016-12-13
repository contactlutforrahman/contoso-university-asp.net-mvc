using Contoso.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Context
{
    public class ContosoUniversityContext : DbContext, IDbContext
    {
        public ContosoUniversityContext() : base("ContosoUniversityContext")
        {

        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public DbSet<Student> Students { get; set; }
    }
}
