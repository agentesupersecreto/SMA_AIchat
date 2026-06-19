using System;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x02000010 RID: 16
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false)]
	public class LabelAttribute : TValleUILocalTextAttribute
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00002A7E File Offset: 0x00000C7E
		public LabelAttribute()
		{
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A86 File Offset: 0x00000C86
		public LabelAttribute(string text)
			: base(text)
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A8F File Offset: 0x00000C8F
		public LabelAttribute(string text, Language localizationID)
			: base(text, localizationID)
		{
		}
	}
}
