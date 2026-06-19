using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x0200005E RID: 94
	public class AplicaAConjuntoDePersonalidadAttribute : Attribute
	{
		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00010635 File Offset: 0x0000E835
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x0001063D File Offset: 0x0000E83D
		public string para { get; set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00010646 File Offset: 0x0000E846
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0001064E File Offset: 0x0000E84E
		public int weigth { get; set; } = 1;
	}
}
