using System.Text.Json.Serialization;

namespace CreateUser
{
	public class CreateUserInGroupOKResponse
	{
		public string Id { get; set; }
		public string Status { get; set; }
		public DateTime Created { get; set; }
		public DateTime Activated { get; set; }
		public DateTime StatusChanged { get; set; }
		public object LastLogin { get; set; }
		public DateTime LastUpdated { get; set; }
		public object PasswordChanged { get; set; }
		public Type Type { get; set; }
		public Profile2 Profile { get; set; }
		public Credentials Credentials { get; set; }

		[JsonPropertyName("_links")]
		public Links2 Links { get; set; }
	}

	public class Links2
	{
		public Activate Suspend { get; set; }
		public Activate Schema { get; set; }
		public Activate ResetPassword { get; set; }
		public Activate Reactivate { get; set; }
		public Activate Self { get; set; }
		public Type Type { get; set; }
		public Activate Deactivate { get; set; }
	}
}