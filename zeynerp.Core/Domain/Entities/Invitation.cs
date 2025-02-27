using zeynerp.Core.Domain.Entities.Base;

namespace zeynerp.Core.Domain.Entities
{
    public class Invitation : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public Guid Token { get; set; }
        public bool IsAccepted { get; set; }
        public Guid CompanyId { get; set; }

        // Navigation Properties
        public Company Company { get; set; }
    }
}