using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000056 RID: 86
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class LabelAttribute : FontAttribute
	{
		// Token: 0x060002DE RID: 734 RVA: 0x0000744D File Offset: 0x0000564D
		public LabelAttribute()
		{
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00007455 File Offset: 0x00005655
		public LabelAttribute(string text)
			: base(text)
		{
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000745E File Offset: 0x0000565E
		public LabelAttribute(string text, string localizationID)
			: base(text, localizationID)
		{
		}
	}
}
