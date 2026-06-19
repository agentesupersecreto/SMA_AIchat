using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000054 RID: 84
	public sealed class AccionNameAttribute : Attribute
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0000719E File Offset: 0x0000539E
		public AccionNameAttribute(string v)
		{
			this.nombre = v;
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x000071AD File Offset: 0x000053AD
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x000071B5 File Offset: 0x000053B5
		public string nombre { get; set; }
	}
}
