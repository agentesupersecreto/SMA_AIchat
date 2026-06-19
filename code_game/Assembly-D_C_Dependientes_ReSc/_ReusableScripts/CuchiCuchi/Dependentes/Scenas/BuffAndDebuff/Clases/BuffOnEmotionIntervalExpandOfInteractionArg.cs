using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B8 RID: 184
	public class BuffOnEmotionIntervalExpandOfInteractionArg : DisplayableArgumentoDeEfecto<BuffOnEmotionIntervalExpandOfInteractionArg>, IInteractionArg
	{
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00015AD9 File Offset: 0x00013CD9
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return this.emo.ParseToCategory();
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00015AE6 File Offset: 0x00013CE6
		IReadOnlyList<IDataOfInteractionArg> IInteractionArg.data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00015AF0 File Offset: 0x00013CF0
		public void InyectData(IReadOnlyList<IDataOfInteractionArg> inyected)
		{
			List<BuffOnEmotionIntervalExpandOfInteractionArg.Data> list = new List<BuffOnEmotionIntervalExpandOfInteractionArg.Data>(this.data);
			for (int i = 0; i < inyected.Count; i++)
			{
				IDataOfInteractionArg dataOfInteractionArg = inyected[i];
				IDataOfInteractionArg newInteractionDataInstance = this.GetNewInteractionDataInstance();
				newInteractionDataInstance.tipo = dataOfInteractionArg.tipo;
				newInteractionDataInstance.direccion = dataOfInteractionArg.direccion;
				newInteractionDataInstance.estiulante = dataOfInteractionArg.estiulante;
				newInteractionDataInstance.estimuladas = dataOfInteractionArg.estimuladas;
				list.Add((BuffOnEmotionIntervalExpandOfInteractionArg.Data)newInteractionDataInstance);
			}
			this.data = list.ToArray();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00015B71 File Offset: 0x00013D71
		public IDataOfInteractionArg GetNewInteractionDataInstance()
		{
			return new BuffOnEmotionIntervalExpandOfInteractionArg.Data();
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00015B78 File Offset: 0x00013D78
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return "gain Interval Expand " + this.expand.ToString() + "×" + (this.changedByFatigue ? (" then " + this.substractedByFatigue.ToString() + "×") : string.Empty);
		}

		// Token: 0x04000361 RID: 865
		public float expand;

		// Token: 0x04000362 RID: 866
		public ReaccionHumana emo;

		// Token: 0x04000363 RID: 867
		public BuffOnEmotionIntervalExpandOfInteractionArg.Data[] data = Array.Empty<BuffOnEmotionIntervalExpandOfInteractionArg.Data>();

		// Token: 0x04000364 RID: 868
		public bool changedByFatigue = true;

		// Token: 0x04000365 RID: 869
		public float substractedByFatigue;

		// Token: 0x020000B9 RID: 185
		[Serializable]
		public class Data : IDataOfInteractionArg
		{
			// Token: 0x170000C7 RID: 199
			// (get) Token: 0x060003D5 RID: 981 RVA: 0x00015BE2 File Offset: 0x00013DE2
			// (set) Token: 0x060003D6 RID: 982 RVA: 0x00015BEA File Offset: 0x00013DEA
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

			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x060003D7 RID: 983 RVA: 0x00015BF3 File Offset: 0x00013DF3
			// (set) Token: 0x060003D8 RID: 984 RVA: 0x00015BFB File Offset: 0x00013DFB
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

			// Token: 0x170000C9 RID: 201
			// (get) Token: 0x060003D9 RID: 985 RVA: 0x00015C04 File Offset: 0x00013E04
			// (set) Token: 0x060003DA RID: 986 RVA: 0x00015C0C File Offset: 0x00013E0C
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

			// Token: 0x170000CA RID: 202
			// (get) Token: 0x060003DB RID: 987 RVA: 0x00015C15 File Offset: 0x00013E15
			// (set) Token: 0x060003DC RID: 988 RVA: 0x00015C1D File Offset: 0x00013E1D
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

			// Token: 0x04000366 RID: 870
			public TipoDeEstimulo tipo;

			// Token: 0x04000367 RID: 871
			public DireccionDeEstimulo direccion;

			// Token: 0x04000368 RID: 872
			public ParteQuePuedeEstimular estiulante;

			// Token: 0x04000369 RID: 873
			public ParteDelCuerpoHumano[] estimuladas = Array.Empty<ParteDelCuerpoHumano>();
		}
	}
}
