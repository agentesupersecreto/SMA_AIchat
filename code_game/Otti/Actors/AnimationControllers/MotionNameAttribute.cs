using System;
using com.ootii.Helpers;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E0 RID: 224
	public class MotionNameAttribute : Attribute
	{
		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x00034D6E File Offset: 0x00032F6E
		public string Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00034D76 File Offset: 0x00032F76
		public MotionNameAttribute(string rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00034D88 File Offset: 0x00032F88
		public static string GetName(Type rType)
		{
			string text = "";
			MotionNameAttribute attribute = ReflectionHelper.GetAttribute<MotionNameAttribute>(rType);
			if (attribute != null)
			{
				text = attribute.Value;
			}
			return text;
		}

		// Token: 0x040005F6 RID: 1526
		protected string mValue;
	}
}
