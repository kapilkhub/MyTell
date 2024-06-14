using MyTell.Mobile.App.Enums;

namespace MyTell.Mobile.App.Entities
{
	public class IdentityCardReadEntity
	{
		public string? Name { get; set; }
		public string? EmiratesId { get; set; }
		public string? Nationality { get; set; }
		public Gender? Gender { get; set; }
		public DateOnly? BirthDate { get; set; }

		internal Gender? GetGender(string? gender)
		{
			return gender switch
			{
				"M" => Enums.Gender.Male,
				"m" => Enums.Gender.Male,
				"Male" => Enums.Gender.Male,
				"F" => Enums.Gender.Female,
				"f" => Enums.Gender.Female,
				"Female" => Enums.Gender.Female,
				_ => null
			};
		}
	}
}
