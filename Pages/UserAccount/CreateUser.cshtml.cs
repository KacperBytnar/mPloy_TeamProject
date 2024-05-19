using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using mPloy_FinalProject_group5.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mPloy_TeamProjectG5.Models;

namespace mPloy_TeamProjectG5.Pages.UserAccount
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel registerModel { get; set; }
        public string registerMessage { get; set; }


        

        public CreateUserModel()
        {
   
        }
        public void OnGet()
        {
        }

            }
        }
    


