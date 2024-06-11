using FluentValidation;

namespace CreateUser
{
	public class CreateUserWithoutCredentialsRequest
    {
        public Profile Profile { get; set; }
    }

    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
    }

    
}