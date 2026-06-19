using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A3 RID: 163
	[Serializable]
	public class GenericDataExclusiveOfInteractionArg : IDataExlusiveOfInteractionArg, IDataOfInteractionArg
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000371 RID: 881 RVA: 0x000141F4 File Offset: 0x000123F4
		// (set) Token: 0x06000372 RID: 882 RVA: 0x000141FC File Offset: 0x000123FC
		float IDataExlusiveOfInteractionArg.weight
		{
			get
			{
				return this.weight;
			}
			set
			{
				this.weight = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00014205 File Offset: 0x00012405
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00014212 File Offset: 0x00012412
		public TipoDeEstimulo tipo
		{
			get
			{
				return this.data.tipo;
			}
			set
			{
				this.data.tipo = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00014220 File Offset: 0x00012420
		// (set) Token: 0x06000376 RID: 886 RVA: 0x0001422D File Offset: 0x0001242D
		public DireccionDeEstimulo direccion
		{
			get
			{
				return this.data.direccion;
			}
			set
			{
				this.data.direccion = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0001423B File Offset: 0x0001243B
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00014248 File Offset: 0x00012448
		public ParteQuePuedeEstimular estiulante
		{
			get
			{
				return this.data.estiulante;
			}
			set
			{
				this.data.estiulante = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00014256 File Offset: 0x00012456
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00014263 File Offset: 0x00012463
		public ParteDelCuerpoHumano[] estimuladas
		{
			get
			{
				return this.data.estimuladas;
			}
			set
			{
				this.data.estimuladas = value;
			}
		}

		// Token: 0x04000335 RID: 821
		public float weight;

		// Token: 0x04000336 RID: 822
		public GenericDataOfInteractionArg data = new GenericDataOfInteractionArg();
	}
}
