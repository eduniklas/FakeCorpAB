using Microsoft.AspNetCore.Identity;

namespace FakeCorpAB.Models
{
    public class AdminViewModel
    {
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set; }
    }
}
