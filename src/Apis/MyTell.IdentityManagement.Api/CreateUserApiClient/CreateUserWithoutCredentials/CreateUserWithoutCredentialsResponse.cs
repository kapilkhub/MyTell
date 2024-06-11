using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CreateUser
{
    public class CreateUserWithoutCredentialsResponse
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public object Activated { get; set; }
        public object StatusChanged { get; set; }
        public object LastLogin { get; set; }
        public DateTime LastUpdated { get; set; }
        public object PasswordChanged { get; set; }
        public Type Type { get; set; }
        public Profile2 Profile { get; set; }
        public Credentials Credentials { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public class Profile2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object MobilePhone { get; set; }
        public object SecondEmail { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }

    public class Links
    {
        public Activate Schema { get; set; }
        public Activate Activate { get; set; }
        public Activate Self { get; set; }
        public Type Type { get; set; }
    }

    public class Emails
    {
        public string Value { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }

    public class Activate
    {
        public string Href { get; set; }
        public string Method { get; set; }
    }

    public class Credentials
    {
        public List<Emails> Emails { get; set; }
        public Provider Provider { get; set; }
    }

    public class Provider
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class Type
    {
        public string Id { get; set; }
        public string Href { get; set; }
    }
}