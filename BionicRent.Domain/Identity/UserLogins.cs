﻿/*
 * @CreateTime: Apr 25, 2019 3:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:11 PM
 * @Description: Modify Here, Please 
 */

using Microsoft.AspNetCore.Identity;

namespace BionicRent.Domain.Identity {
    public class UserLogins : IdentityUserLogin<string> {
        public ApplicationUser User { get; set; }
    }
}