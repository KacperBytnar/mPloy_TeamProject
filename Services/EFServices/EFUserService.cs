
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
using Microsoft.EntityFrameworkCore;

namespace mPloy_TeamProjectG5.Services.EFServices
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
        //public async Task<AppUser> EditUser(AppUser user)
        //{
        //    context.AppUsers.Attach(user); // Attach the user object
        //    context.Entry(user).State = EntityState.Modified; // Set state to Modified
        //    await userManager.UpdateAsync(user);
        //    await context.SaveChangesAsync();
        //    return user;
        //}
        public void EditUser(AppUser user)
        {
            Models.AppUser tempUser = context.AppUsers.FirstOrDefault(u => u.Id == user.Id);
            if (tempUser != null)
            {
                tempUser.FirstName = user.FirstName;
                tempUser.LastName = user.LastName;
                tempUser.Age = user.Age;
                tempUser.City = user.City;
                tempUser.ZipCode = user.ZipCode;
                tempUser.StreetAddress = user.StreetAddress;
                tempUser.Description = user.Description;
                tempUser.Email = user.Email;
                tempUser.PhoneNumber = user.PhoneNumber;

                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }


    }
}

