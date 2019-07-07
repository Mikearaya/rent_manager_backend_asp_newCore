/*
 * @CreateTime: Jul 7, 2019 5:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 5:59 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicRent.Application.interfaces;
using BionicRent.Domain.Identity;

namespace BionicRent.Application.Security {
    public class SecurityManager {
        private readonly IBionicRentDatabaseService _securityDatabase;

        public SecurityManager (IBionicRentDatabaseService securityDatabase) {
            _securityDatabase = securityDatabase;
        }

        public AppUserAuth ValidateUser (ApplicationUser user) {

            AppUserAuth ret = new AppUserAuth ();
            ApplicationUser authUser = null;

            authUser = _securityDatabase.Users
                .Where (u => u.UserName.ToLower () == user.UserName.ToLower () && u.PasswordHash == user.PasswordHash)
                .FirstOrDefault ();

            if (authUser != null) {
                ret = BuildUserAuthObject (authUser);
            }
            return ret;
        }

        public List<UserClaims> GetUserClaims (ApplicationUser authUser) {
            List<UserClaims> list = new List<UserClaims> ();

            try {
                list = _securityDatabase.UserClaims
                    .Where (a => a.UserId == authUser.Id)
                    .ToList ();
            } catch (Exception) {

            }

            return list;

        }

        public AppUserAuth BuildUserAuthObject (ApplicationUser authUser) {
            AppUserAuth ret = new AppUserAuth ();
            List<UserClaims> claims = new List<UserClaims> ();

            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid ().ToString ();

            claims = GetUserClaims (authUser);

            foreach (UserClaims claim in claims) {

                try {
                    typeof (AppUserAuth).GetProperty (claim.ClaimType).SetValue (ret, Convert.ToBoolean (claim.ClaimValue), null);
                } finally {

                }

            }

            return ret;

        }

    }
}