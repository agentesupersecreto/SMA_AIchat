using System;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x0200000E RID: 14
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class DescriptionAttribute : TValleUILocalTextAttribute
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002A5A File Offset: 0x00000C5A
		public DescriptionAttribute()
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002A62 File Offset: 0x00000C62
		public DescriptionAttribute(string text)
			: base(text)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002A6B File Offset: 0x00000C6B
		public DescriptionAttribute(string text, Language localizationID)
			: base(text, localizationID)
		{
		}
	}
}
