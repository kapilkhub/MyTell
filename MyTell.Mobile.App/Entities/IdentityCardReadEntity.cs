namespace MyTell.Mobile.App.Entities
{
	public class IdentityCardReadEntity
	{
        public string? Name { get; set; }
        public string? EmiratesId { get; set; } 
		public string? Nationality { get; set; }
        public string? Gender { get; set; } 
		public DateOnly? BirthDate { get; set; }
	}
}
