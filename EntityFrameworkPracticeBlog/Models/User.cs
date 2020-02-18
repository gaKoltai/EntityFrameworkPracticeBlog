﻿using System.Collections.Generic;

namespace EntityFrameworkPracticeBlog.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Post> Posts { get; set; }
    }
}