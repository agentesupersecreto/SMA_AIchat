using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000050 RID: 80
	public sealed class CerrableAttribute : Attribute
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00007149 File Offset: 0x00005349
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00007151 File Offset: 0x00005351
		public CerrableAttribute.Accion accion { get; set; }

		// Token: 0x0200016E RID: 366
		public enum Accion
		{
			// Token: 0x0400047B RID: 1147
			destruir,
			// Token: 0x0400047C RID: 1148
			ocultar
		}
	}
}
