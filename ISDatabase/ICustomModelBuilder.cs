using Microsoft.EntityFrameworkCore;

namespace KSHYDatabase
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
