using IWSProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IWSProject
{

    public class IWSHelper : RoleProvider
    {
        private RoleManager<IdentityRole> RoleManager;// =
                                                      //new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        private UserManager<ApplicationUser> UserManager;// = 
                                                         //new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        private UserStore<ApplicationUser> UserStore;// =
                                                     //new UserStore<ApplicationUser>(new ApplicationDbContext());

        private ApplicationUser User;
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddUserToRole(string userName, string roleName)
        {
            UserStore = new UserStore<ApplicationUser>(new ApplicationDbContext());

            var userManager = new UserManager<ApplicationUser>(UserStore);

            User = userManager.FindByName(userName);

            if (User != null)
                userManager.AddToRole(User.Id, roleName);
        }

        public override void AddUsersToRoles(string[] userNames, string[] roleNames)
        {
            if ((userNames != null) && (roleNames != null))
            {
                foreach (var user in userNames)
                {
                    foreach (var role in roleNames)
                    {
                        AddUserToRole(user, role);
                    }
                }
            }
        }
        public override void CreateRole(string roleName)
        {
            RoleManager = new RoleManager<IdentityRole>(
                            new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!RoleManager.RoleExists(roleName))
            {
                RoleManager.Create(new IdentityRole(roleName));
            }

        }
        public void CreateUser(string userName, string password)
        {
            UserManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            UserManager.Create(new ApplicationUser { UserName = userName }, password);
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            //var roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId));
            //var role = _db.Roles.Find(roleId);

            //foreach (var user in roleUsers)
            //{
            //    this.RemoveFromRole(user.Id, role.Name);
            //}
            //_db.Roles.Remove(role);
            //_db.SaveChanges();

            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return new string[] { };
            }

            RoleManager = new RoleManager<IdentityRole>(
                      new RoleStore<IdentityRole>(new ApplicationDbContext()));

            string[] roles = RoleManager.Roles.Select(r => r.Name).ToArray();

            return roles;
        }
        public override string[] GetRolesForUser(string userName)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return new string[] { };
            }

            UserManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));

            User = UserManager.FindByName(userName);

            string[] roles = UserManager.GetRoles(User.Id).ToArray();

            return roles;

        }
        public override string[] GetUsersInRole(string roleName)
        {
            UserManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));

            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] userRoles = GetRolesForUser(username);

            return userRoles.Contains(roleName);
        }
        public override void RemoveUsersFromRoles(string[] userNames, string[] roleNames)
        {
            UserManager = new UserManager<ApplicationUser>(
                            new UserStore<ApplicationUser>(new ApplicationDbContext()));

            if ((userNames != null) && (roleNames != null))
            {
                foreach (var user in userNames)
                {
                    UserManager.RemoveFromRoles(user, roleNames);
                }
            }
        }
        public void RemoveUserFromRole(string userName, string roleName)
        {
            UserManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));

            User = UserManager.FindByName(userName);
            UserManager.RemoveFromRole(User.Id, roleName);
        }
        public override bool RoleExists(string roleName)
        {
            RoleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));

            return RoleManager.RoleExists(roleName);
        }
    }
}