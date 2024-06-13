namespace CreateUser
{
	public class CreateUserInGroupRequest
	{
		public Profile Profile { get; set; }
		public List<string> GroupIds { get; set; }
	}
}