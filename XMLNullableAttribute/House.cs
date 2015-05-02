using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLNullableAttribute
{
	public class House
	{
		[XmlElement]
		public List<Room> rooms = new List<Room>();
	}

	public class Room
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlIgnore]
		public int? NumberOfWindows { get; set; }

		[XmlAttribute(AttributeName = "windows")]
		public string WindowsSerializable
		{
			get
			{
				if (NumberOfWindows != null)
				{
					return NumberOfWindows.ToString();
				}
				else
				{
					return "";
				}
			}
			set
			{
				if (WindowsSerializable != null)
				{
					NumberOfWindows = int.Parse(WindowsSerializable);
				}
			}
		}
		public bool ShouldSerializeWindowsSerializable()
		{
			return NumberOfWindows.HasValue;
		}
	}
}
