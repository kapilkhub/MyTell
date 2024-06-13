using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CreateUser
{
    public class CreateUserWithoutCredentialsBadRequestResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorSummary { get; set; }
        public string ErrorLink { get; set; }
        public string ErrorId { get; set; }
        public List<ErrorCauses> ErrorCauses { get; set; }
    }

    public class ErrorCauses
    {
        public string ErrorSummary { get; set; }
    }
}