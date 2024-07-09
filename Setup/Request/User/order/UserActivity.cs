﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.order
{
    public class UserActivityRequest
    {
        [Required(ErrorMessage ="UserID Required !")]
        public string? UserId { get; set; }
    }
}
