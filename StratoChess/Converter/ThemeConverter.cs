using System;
using StratoChess.Enums;

namespace StratoChess.Converter
{
	public static class ThemeConverter
	{
		public static string ConvertColor(PrismTemplate type)
		{
			var hexColor = type switch
            {
                PrismTemplate.Omega => "#000",
                PrismTemplate.Delta => "#fff",
                PrismTemplate.Mu => "#888",
                PrismTemplate.Alpha => "#f00",
                PrismTemplate.Gamma => "#0f0",
                PrismTemplate.Beta => "#00f",
                PrismTemplate.Theta => "#0ff",
                PrismTemplate.Phi => "#f0f",
                PrismTemplate.Lambda => "#ff0",
                PrismTemplate.Sigma => "#f80",
                PrismTemplate.Epsilon => "#f08",
                PrismTemplate.Psi => "#80f",
                _ => throw new NotImplementedException()
            };
            return hexColor;
		}
	}
}

