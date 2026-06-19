using System;
using com.ootii.Helpers;

namespace com.ootii.Base
{
	// Token: 0x02000068 RID: 104
	public class BaseNameAttribute : Attribute
	{
		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x0001C311 File Offset: 0x0001A511
		public string Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001C319 File Offset: 0x0001A519
		public BaseNameAttribute(string rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001C328 File Offset: 0x0001A528
		public static string GetName(Type rType)
		{
			string text = rType.Name;
			BaseNameAttribute attribute = ReflectionHelper.GetAttribute<BaseNameAttribute>(rType);
			if (attribute != null)
			{
				text = attribute.Value;
			}
			return text;
		}

		// Token: 0x04000259 RID: 601
		protected string mValue;
	}
}
