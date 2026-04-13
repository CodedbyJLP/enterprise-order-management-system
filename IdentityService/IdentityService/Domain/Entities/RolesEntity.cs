using Microsoft.EntityFrameworkCore.Storage.Json;

namespace IdentityService.Domain.Entities
{
    public class RolesEntity
    {

        public required string Name { get; set; }
        public Guid Id { get;  set; }

      
    }
}
