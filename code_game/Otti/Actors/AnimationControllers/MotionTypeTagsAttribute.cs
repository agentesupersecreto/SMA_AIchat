using System;
using System.Linq;
using com.ootii.Helpers;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E2 RID: 226
	public class MotionTypeTagsAttribute : Attribute
	{
		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x00034DE9 File Offset: 0x00032FE9
		public string Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x00034DF1 File Offset: 0x00032FF1
		public MotionTypeTagsAttribute(string rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00034E00 File Offset: 0x00033000
		public static string GetTypeTags(Type rType)
		{
			string text = "";
			MotionTypeTagsAttribute attribute = ReflectionHelper.GetAttribute<MotionTypeTagsAttribute>(rType);
			if (attribute != null)
			{
				text = attribute.Value;
			}
			return text;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00034E28 File Offset: 0x00033028
		public static bool Contains(Type rType, string rTypeTag)
		{
			MotionTypeTagsAttribute attribute = ReflectionHelper.GetAttribute<MotionTypeTagsAttribute>(rType);
			return attribute != null && attribute.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Contains(rTypeTag, StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x040005F8 RID: 1528
		protected string mValue;
	}
}
