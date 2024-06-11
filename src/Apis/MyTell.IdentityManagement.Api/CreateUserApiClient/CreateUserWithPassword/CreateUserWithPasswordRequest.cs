using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CreateUser
{
    public class CreateUserWithPasswordRequest
    {
        public Profile Profile { get; set; }
        public Credentials2 Credentials { get; set; }
    }

    public class Credentials2
    {
        public Emails Password { get; set; }
    }
}