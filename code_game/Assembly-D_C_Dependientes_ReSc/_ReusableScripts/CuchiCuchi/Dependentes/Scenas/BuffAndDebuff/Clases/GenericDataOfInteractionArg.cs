using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A2 RID: 162
	[Serializable]
	public class GenericDataOfInteractionArg : IDataOfInteractionArg
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000368 RID: 872 RVA: 0x000141B0 File Offset: 0x000123B0
		// (set) Token: 0x06000369 RID: 873 RVA: 0x000141B8 File Offset: 0x000123B8
		TipoDeEstimulo IDataOfInteractionArg.tipo
		{
			get
			{
				return this.tipo;
			}
			set
			{
				this.tipo = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600036A RID: 874 RVA: 0x000141C1 File Offset: 0x000123C1
		// (set) Token: 0x0600036B RID: 875 RVA: 0x000141C9 File Offset: 0x000123C9
		DireccionDeEstimulo IDataOfInteractionArg.direccion
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

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600036C RID: 876 RVA: 0x000141D2 File Offset: 0x000123D2
		// (set) Token: 0x0600036D RID: 877 RVA: 0x000141DA File Offset: 0x000123DA
		ParteQuePuedeEstimular IDataOfInteractionArg.estiulante
		{
			get
			{
				return this.estiulante;
			}
			set
			{
				this.estiulante = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600036E RID: 878 RVA: 0x000141E3 File Offset: 0x000123E3
		// (set) Token: 0x0600036F RID: 879 RVA: 0x000141EB File Offset: 0x000123EB
		ParteDelCuerpoHumano[] IDataOfInteractionArg.estimuladas
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

		// Token: 0x04000331 RID: 817
		public TipoDeEstimulo tipo;

		// Token: 0x04000332 RID: 818
		public DireccionDeEstimulo direccion;

		// Token: 0x04000333 RID: 819
		public ParteQuePuedeEstimular estiulante;

		// Token: 0x04000334 RID: 820
		public ParteDelCuerpoHumano[] estimuladas;
	}
}
