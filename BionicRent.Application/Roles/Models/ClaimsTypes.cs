using System.Collections.Generic;

namespace BionicRent.Application.Roles.Models {
    public class ClaimsTypes {
        public string Function { get; set; }
        public IList<Permissions> Permissions { get; set; } = new List<Permissions> ();
    }

    public class Permissions {
        public string PermissionType { get; set; }
        public bool Value { get; set; }
    }
}