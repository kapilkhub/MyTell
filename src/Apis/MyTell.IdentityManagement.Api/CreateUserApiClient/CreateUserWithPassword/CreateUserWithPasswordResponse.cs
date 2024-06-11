using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CreateUser
{
    public class CreateUserWithPasswordResponse
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public object Activated { get; set; }
        public object StatusChanged { get; set; }
        public object LastLogin { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime PasswordChanged { get; set; }
        public Type Type { get; set; }
        public Profile2 Profile { get; set; }
        public Credentials3 Credentials { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public class Credentials3
    {
        public Password Password { get; set; }
        public List<Emails> Emails { get; set; }
        public Provider Provider { get; set; }
    }

    public class Password
    {
    }
}