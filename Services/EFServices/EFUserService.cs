
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;

namespace mPloy_FinalProject_group5.Services.EFServices
{
    public class EFUserService : IUserService
    {
        private AppDbContext context;
        private readonly UserManager<AppUser> userManager;
        public EFUserService(AppDbContext userContext, UserManager<AppUser> userManager)
        {
            context = userContext;
            this.userManager = userManager;
        }

        //public void CreateUser(AppUser user)
        //{
        //    //context.AppUsers.Add(user);
        //    context.SaveChanges();
        //}

        public List<AppUser> GetAllUsers()
        {
            return userManager.Users.ToList();
        }

        public AppUser GetUserById(int id)
        {
            return context.Users.Where(t => t.Id == id).FirstOrDefault(t => t.Id == id);
        }

        public async Task<AppUser> EditUser(AppUser user)
        {
            //context.AppUsers.Update(user);
            //var tempUser = userManager.Users.Where(t => t.Id == user.Id).FirstOrDefault();
            var tempUser = await userManager.FindByIdAsync(user.Id.ToString());
            if (tempUser != null)
            {
                tempUser.Id = user.Id;
                tempUser.FirstName = user.FirstName;
                tempUser.LastName = user.LastName;
                tempUser.Age = user.Age;
                tempUser.City = user.City;
                tempUser.ZipCode = user.ZipCode;
                tempUser.StreetAddress = user.StreetAddress;
                tempUser.Description = user.Description;
                tempUser.Email = user.Email;
                tempUser.PhoneNumber = user.PhoneNumber;
                await userManager.UpdateAsync(tempUser);
                context.SaveChanges();
                return tempUser;
            }
            else
                return tempUser;
        }

        public void UpdateUser(AppUser user)
        {
            userManager.UpdateAsync(user);
            EditUser(user);
        }
    }
}
