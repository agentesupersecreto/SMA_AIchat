using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000AE RID: 174
	[Serializable]
	public class BuffOnDeshieloDeEstimuloEnPartesArg : ArgumentoDeEfecto<BuffOnDeshieloDeEstimuloEnPartesArg>, IInteractionArg
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0001500D File Offset: 0x0001320D
		IReadOnlyList<IDataOfInteractionArg> IInteractionArg.data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00015018 File Offset: 0x00013218
		public void InyectData(IReadOnlyList<IDataOfInteractionArg> inyected)
		{
			List<BuffOnDeshieloDeEstimuloEnPartesArg.Data> list = new List<BuffOnDeshieloDeEstimuloEnPartesArg.Data>(this.data);
			for (int i = 0; i < inyected.Count; i++)
			{
				IDataOfInteractionArg dataOfInteractionArg = inyected[i];
				IDataOfInteractionArg newInteractionDataInstance = this.GetNewInteractionDataInstance();
				newInteractionDataInstance.tipo = dataOfInteractionArg.tipo;
				newInteractionDataInstance.direccion = dataOfInteractionArg.direccion;
				newInteractionDataInstance.estiulante = dataOfInteractionArg.estiulante;
				newInteractionDataInstance.estimuladas = dataOfInteractionArg.estimuladas;
				list.Add((BuffOnDeshieloDeEstimuloEnPartesArg.Data)newInteractionDataInstance);
			}
			this.data = list.ToArray();
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00015099 File Offset: 0x00013299
		public IDataOfInteractionArg GetNewInteractionDataInstance()
		{
			return new BuffOnDeshieloDeEstimuloEnPartesArg.Data();
		}

		// Token: 0x0400034E RID: 846
		public float value;

		// Token: 0x0400034F RID: 847
		public BuffOnDeshieloDeEstimuloEnPartesArg.Data[] data = Array.Empty<BuffOnDeshieloDeEstimuloEnPartesArg.Data>();

		// Token: 0x020000AF RID: 175
		[Serializable]
		public class Data : IDataOfInteractionArg
		{
			// Token: 0x170000B9 RID: 185
			// (get) Token: 0x060003A1 RID: 929 RVA: 0x000150B3 File Offset: 0x000132B3
			// (set) Token: 0x060003A2 RID: 930 RVA: 0x000150BB File Offset: 0x000132BB
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

			// Token: 0x170000BA RID: 186
			// (get) Token: 0x060003A3 RID: 931 RVA: 0x000150C4 File Offset: 0x000132C4
			// (set) Token: 0x060003A4 RID: 932 RVA: 0x000150CC File Offset: 0x000132CC
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

			// Token: 0x170000BB RID: 187
			// (get) Token: 0x060003A5 RID: 933 RVA: 0x000150D5 File Offset: 0x000132D5
			// (set) Token: 0x060003A6 RID: 934 RVA: 0x000150DD File Offset: 0x000132DD
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

			// Token: 0x170000BC RID: 188
			// (get) Token: 0x060003A7 RID: 935 RVA: 0x000150E6 File Offset: 0x000132E6
			// (set) Token: 0x060003A8 RID: 936 RVA: 0x000150EE File Offset: 0x000132EE
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

			// Token: 0x04000350 RID: 848
			public TipoDeEstimulo tipo;

			// Token: 0x04000351 RID: 849
			public DireccionDeEstimulo direccion;

			// Token: 0x04000352 RID: 850
			public ParteQuePuedeEstimular estiulante;

			// Token: 0x04000353 RID: 851
			public ParteDelCuerpoHumano[] estimuladas = Array.Empty<ParteDelCuerpoHumano>();
		}
	}
}
