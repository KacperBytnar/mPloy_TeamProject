﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mPloy_TeamProjectG5.Models;

namespace mPloy_TeamProjectG5.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<AppUser> AppUsers { get; set; }


    }
}
