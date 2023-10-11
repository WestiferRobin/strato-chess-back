using System;
using StratoChess.Enums;

namespace StratoChess.Converter
{
	public static class PrismConverter
	{
		public static PrismTemplate ConvertStringToTemplate(string strTemplate)
		{
            var result = strTemplate switch
            {
                "Mu" => PrismTemplate.Mu,
                "Delta" => PrismTemplate.Delta,
                "Omega" => PrismTemplate.Omega,
                "Alpha" => PrismTemplate.Alpha,
                "Gamma" => PrismTemplate.Gamma,
                "Beta" => PrismTemplate.Beta,
                "Theta" => PrismTemplate.Theta,
                "Phi" => PrismTemplate.Phi,
                "Lambda" => PrismTemplate.Lambda,
                "Sigma" => PrismTemplate.Sigma,
                "Epsilon" => PrismTemplate.Epsilon,
                "Psi" => PrismTemplate.Phi,
                _ => throw new ArgumentException(
                    $"{strTemplate} is not a valid template name"
                )
            };
            return result;
		}
	}
}

