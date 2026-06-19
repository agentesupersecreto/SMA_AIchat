using System;
using System.Xml;

namespace com.ootii.Helpers
{
	// Token: 0x02000039 RID: 57
	public class XMLHelper
	{
		// Token: 0x060002AB RID: 683 RVA: 0x0000CB1A File Offset: 0x0000AD1A
		public static void SetAttribute(XmlNode rXML, string rName, string rValue)
		{
			if (rXML == null)
			{
				return;
			}
			((XmlElement)rXML).SetAttribute(rName, rValue);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000CB30 File Offset: 0x0000AD30
		public static T GetAttribute<T>(XmlNode rXML, string rName)
		{
			T t = default(T);
			if (rXML == null)
			{
				return t;
			}
			XmlElement xmlElement = (XmlElement)rXML;
			if (!xmlElement.HasAttribute(rName))
			{
				return t;
			}
			return (T)((object)Convert.ChangeType(xmlElement.GetAttribute(rName), typeof(T)));
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		public static string GetAttribute(string rXML, string rName)
		{
			int num = rXML.IndexOf("t=\"");
			if (num >= 0)
			{
				int num2 = rXML.IndexOf("\"", num + 3);
				if (num2 >= 0)
				{
					return rXML.Substring(num + 3, num2 - (num + 3));
				}
			}
			return "";
		}
	}
}
