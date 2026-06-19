using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000053 RID: 83
	public sealed class ConfirmablePreguntaAttribute : FontAttribute
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x00007183 File Offset: 0x00005383
		public ConfirmablePreguntaAttribute()
		{
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000718B File Offset: 0x0000538B
		public ConfirmablePreguntaAttribute(string text)
			: base(text)
		{
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00007194 File Offset: 0x00005394
		public ConfirmablePreguntaAttribute(string text, string localizationID)
			: base(text, localizationID)
		{
		}
	}
}
