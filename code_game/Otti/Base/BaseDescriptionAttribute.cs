using System;
using com.ootii.Helpers;

namespace com.ootii.Base
{
	// Token: 0x02000069 RID: 105
	public class BaseDescriptionAttribute : Attribute
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0001C34E File Offset: 0x0001A54E
		public string Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001C356 File Offset: 0x0001A556
		public BaseDescriptionAttribute(string rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001C368 File Offset: 0x0001A568
		public static string GetDescription(Type rType)
		{
			string text = "";
			BaseDescriptionAttribute attribute = ReflectionHelper.GetAttribute<BaseDescriptionAttribute>(rType);
			if (attribute != null)
			{
				text = attribute.Value;
			}
			return text;
		}

		// Token: 0x0400025A RID: 602
		protected string mValue;
	}
}
