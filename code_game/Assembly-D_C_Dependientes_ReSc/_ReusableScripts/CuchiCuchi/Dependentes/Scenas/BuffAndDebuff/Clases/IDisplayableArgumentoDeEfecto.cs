using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A4 RID: 164
	public interface IDisplayableArgumentoDeEfecto
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600037C RID: 892
		// (set) Token: 0x0600037D RID: 893
		bool AlwaysUpdateNonLocalizedText { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600037E RID: 894
		// (set) Token: 0x0600037F RID: 895
		bool flagUpdateNonLocalizedTextV2 { get; set; }

		// Token: 0x06000380 RID: 896
		string NonLocalizedText(DisplayableBuff buff);
	}
}
