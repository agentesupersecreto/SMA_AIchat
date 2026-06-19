using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000058 RID: 88
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public sealed class DescripcionAttribute : FontAttribute
	{
		// Token: 0x060002EB RID: 747 RVA: 0x00007602 File Offset: 0x00005802
		public DescripcionAttribute()
		{
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000760A File Offset: 0x0000580A
		public DescripcionAttribute(string text)
			: base(text)
		{
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00007613 File Offset: 0x00005813
		public DescripcionAttribute(string text, string localizationID)
			: base(text, localizationID)
		{
		}
	}
}
