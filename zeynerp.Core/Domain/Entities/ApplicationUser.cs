using Microsoft.AspNetCore.Identity;

namespace zeynerp.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public Guid? CompanyId { get; set; }

        // Navigation Properties
        public virtual Company? Company { get; set; }
    }
}