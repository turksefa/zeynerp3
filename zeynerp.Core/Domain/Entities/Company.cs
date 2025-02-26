using zeynerp.Core.Domain.Entities.Base;

namespace zeynerp.Core.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}