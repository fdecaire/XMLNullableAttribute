using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace XMLNullableAttribute
{
	class Program
	{
		static void Main(string[] args)
		{
			var document = new House();

			// populate the data
			document.rooms.Add(new Room { 
				Name = "kitchen",
				NumberOfWindows = 2
			});

			document.rooms.Add(new Room
			{
				Name = "bathroom",
				NumberOfWindows = 0
			});

			document.rooms.Add(new Room
			{
				Name = "closet",
				NumberOfWindows = null
			});

			// serialize the xml output
			XmlSerializer ser = new XmlSerializer(typeof(House));
			using (TextWriter writer = new StreamWriter(@"c:\testxml.xml"))
			{
				ser.Serialize(writer, document);
			}
		}
	}
}
