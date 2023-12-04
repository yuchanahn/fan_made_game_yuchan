using System;

namespace SJJ.GoogleSheetsDatabase
{
	public class PageNameAttribute : Attribute
	{
		public readonly string name;

		public PageNameAttribute(string name)
		{
			this.name = name;
		}
	}
}
