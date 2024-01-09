﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Friend> Friends { get; set; } = new List<Friend>();
    }
}
