using System;

namespace UamTTA.GUI.Contracts
{
	public class Budget
	{
		public string Name { get; set; }

		public string Duration { get; set; }

		public DateTime ValidFrom { get; set; }

		public DateTime ValidTo { get; set; }
	}
}
