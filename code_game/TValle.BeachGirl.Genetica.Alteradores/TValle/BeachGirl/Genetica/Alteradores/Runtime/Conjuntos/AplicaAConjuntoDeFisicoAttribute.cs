using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x0200005D RID: 93
	public class AplicaAConjuntoDeFisicoAttribute : Attribute
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x00010604 File Offset: 0x0000E804
		// (set) Token: 0x0600045F RID: 1119 RVA: 0x0001060C File Offset: 0x0000E80C
		public string para { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x00010615 File Offset: 0x0000E815
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x0001061D File Offset: 0x0000E81D
		public int weigth { get; set; } = 1;
	}
}
