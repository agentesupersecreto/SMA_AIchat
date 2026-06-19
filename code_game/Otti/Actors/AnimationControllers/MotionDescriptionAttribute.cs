using System;
using com.ootii.Helpers;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E1 RID: 225
	public class MotionDescriptionAttribute : Attribute
	{
		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000B1E RID: 2846 RVA: 0x00034DAD File Offset: 0x00032FAD
		public string Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x00034DB5 File Offset: 0x00032FB5
		public MotionDescriptionAttribute(string rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x00034DC4 File Offset: 0x00032FC4
		public static string GetDescription(Type rType)
		{
			string text = "";
			MotionDescriptionAttribute attribute = ReflectionHelper.GetAttribute<MotionDescriptionAttribute>(rType);
			if (attribute != null)
			{
				text = attribute.Value;
			}
			return text;
		}

		// Token: 0x040005F7 RID: 1527
		protected string mValue;
	}
}
