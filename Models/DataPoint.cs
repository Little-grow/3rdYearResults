using System.Runtime.Serialization;

namespace ThirdYear.Models
{
	[DataContract]
	public class DataPoint
	{
		[DataMember(Name = "label")]
		public string Label = "";

		[DataMember(Name = "y")]
		public int Y;

		public DataPoint(string label, int y)
		{
			Label = label;
			Y = y;
		}
	}
}
