using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CreateUser
{
    public class CreateUserWithPasswordParameters : IQueryParameters
    {
        public string Activate { get; set; }

        public Dictionary<string, string?> ToDictionary()
        {
            return new Dictionary<string, string?>
            {
                {
                    "activate",
                    Activate
                }
            };
        }
    }
}