using System.Collections.Generic;

namespace PlatformCTF.Domains.Entities.User
{
    public class ULoginResp
    {
        public bool Status { get; set; }

        public string StatusMsg { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}