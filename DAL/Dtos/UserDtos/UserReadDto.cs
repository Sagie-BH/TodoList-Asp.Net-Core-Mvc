﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Dtos.UserDtos
{
    public class UserReadDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
