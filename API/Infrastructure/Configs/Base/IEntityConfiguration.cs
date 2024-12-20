using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Configs.Base
{
    public interface IEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
