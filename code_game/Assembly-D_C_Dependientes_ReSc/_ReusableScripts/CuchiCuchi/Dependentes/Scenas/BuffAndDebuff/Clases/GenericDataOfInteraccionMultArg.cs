using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A0 RID: 160
	[Serializable]
	public class GenericDataOfInteraccionMultArg : IDataOfInteraccionMultArg
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00014139 File Offset: 0x00012339
		// (set) Token: 0x06000359 RID: 857 RVA: 0x00014141 File Offset: 0x00012341
		TipoDeEstimulo[] IDataOfInteraccionMultArg.tipos
		{
			get
			{
				return this.tipos;
			}
			set
			{
				this.tipos = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0001414A File Offset: 0x0001234A
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00014152 File Offset: 0x00012352
		DireccionDeEstimulo IDataOfInteraccionMultArg.direccion
		{
			get
			{
				return this.direccion;
			}
			set
			{
				this.direccion = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0001415B File Offset: 0x0001235B
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00014163 File Offset: 0x00012363
		ParteQuePuedeEstimular[] IDataOfInteraccionMultArg.estiulantes
		{
			get
			{
				return this.estiulantes;
			}
			set
			{
				this.estiulantes = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0001416C File Offset: 0x0001236C
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00014174 File Offset: 0x00012374
		ParteDelCuerpoHumano[] IDataOfInteraccionMultArg.estimuladas
		{
			get
			{
				return this.estimuladas;
			}
			set
			{
				this.estimuladas = value;
			}
		}

		// Token: 0x0400032A RID: 810
		public TipoDeEstimulo[] tipos;

		// Token: 0x0400032B RID: 811
		public DireccionDeEstimulo direccion;

		// Token: 0x0400032C RID: 812
		public ParteQuePuedeEstimular[] estiulantes;

		// Token: 0x0400032D RID: 813
		public ParteDelCuerpoHumano[] estimuladas;
	}
}
