using System.Security.Claims;

namespace AvioLine.Domain.DTO.Identity
{
    public abstract class ClaimDTO:UserDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class ReplaceClaimDTO : UserDTO
    {
        public Claim Claim { get; set; }

        public Claim NewClaim { get; set; }
    }

    public class RemoveClaimDTO : ClaimDTO
    {
    }

    public class AddClaimDTO : ClaimDTO
    {
    }
}
