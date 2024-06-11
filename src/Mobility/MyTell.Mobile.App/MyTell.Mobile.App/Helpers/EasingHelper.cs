using MyTell.Mobile.App.Animations.Base;

namespace MyTell.Mobile.App.Helpers
{
	public static class EasingHelper
	{
#pragma warning disable CS8603 // Possible null reference return.
		public static Easing GetEasing(EasingType type) => type switch
		{
			EasingType.BounceIn => Easing.BounceIn,
			EasingType.BounceOut => Easing.BounceOut,
			EasingType.CubicIn => Easing.CubicIn,
			EasingType.CubicInOut => Easing.CubicInOut,
			EasingType.CubicOut => Easing.CubicOut,
			EasingType.Linear => Easing.Linear,
			EasingType.SinIn => Easing.SinIn,
			EasingType.SinInOut => Easing.SinInOut,
			EasingType.SinOut => Easing.SinOut,
			EasingType.SpringIn => Easing.SpringIn,
			EasingType.SpringOut => Easing.SpringOut,
			_ => null,
		};
#pragma warning restore CS8603 // Possible null reference return.
	}
}
