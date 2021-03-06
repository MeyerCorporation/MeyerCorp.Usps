﻿namespace MeyerCorp.Usps.Core.Models
{
	public struct EnumerationDefinition
	{
		public string Enumeration { get; set; }
		public string Definition { get; set; }

		public override string ToString()
		{
			return $"{Enumeration} - {Definition}";
		}
	}
}
