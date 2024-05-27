using System.Collections.Generic;

namespace PlatformCTF.Domains.Entities.User
{
    public class AdminResp
    {
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
        public List<UDBTable> Users { get; set; }
    }
}