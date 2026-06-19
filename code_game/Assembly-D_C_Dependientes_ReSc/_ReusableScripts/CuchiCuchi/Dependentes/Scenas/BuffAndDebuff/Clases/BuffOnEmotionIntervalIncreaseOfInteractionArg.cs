using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000BB RID: 187
	public class BuffOnEmotionIntervalIncreaseOfInteractionArg : DisplayableArgumentoDeEfecto<BuffOnEmotionIntervalIncreaseOfInteractionArg>, IInteractionArg
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00015F3D File Offset: 0x0001413D
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return this.emo.ParseToCategory();
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x00015F4A File Offset: 0x0001414A
		IReadOnlyList<IDataOfInteractionArg> IInteractionArg.data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00015F54 File Offset: 0x00014154
		public void InyectData(IReadOnlyList<IDataOfInteractionArg> inyected)
		{
			List<BuffOnEmotionIntervalIncreaseOfInteractionArg.Data> list = new List<BuffOnEmotionIntervalIncreaseOfInteractionArg.Data>(this.data);
			for (int i = 0; i < inyected.Count; i++)
			{
				IDataOfInteractionArg dataOfInteractionArg = inyected[i];
				IDataOfInteractionArg newInteractionDataInstance = this.GetNewInteractionDataInstance();
				newInteractionDataInstance.tipo = dataOfInteractionArg.tipo;
				newInteractionDataInstance.direccion = dataOfInteractionArg.direccion;
				newInteractionDataInstance.estiulante = dataOfInteractionArg.estiulante;
				newInteractionDataInstance.estimuladas = dataOfInteractionArg.estimuladas;
				list.Add((BuffOnEmotionIntervalIncreaseOfInteractionArg.Data)newInteractionDataInstance);
			}
			this.data = list.ToArray();
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00015FD5 File Offset: 0x000141D5
		public IDataOfInteractionArg GetNewInteractionDataInstance()
		{
			return new BuffOnEmotionIntervalIncreaseOfInteractionArg.Data();
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00015FDC File Offset: 0x000141DC
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return "gain Interval Increase " + this.increase.ToString() + "×" + (this.changedByFatigue ? (" then " + this.substractedByFatigue.ToString() + "×") : string.Empty);
		}

		// Token: 0x0400036A RID: 874
		public float increase;

		// Token: 0x0400036B RID: 875
		public ReaccionHumana emo;

		// Token: 0x0400036C RID: 876
		public BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo tipo;

		// Token: 0x0400036D RID: 877
		public BuffOnEmotionIntervalIncreaseOfInteractionArg.Data[] data = Array.Empty<BuffOnEmotionIntervalIncreaseOfInteractionArg.Data>();

		// Token: 0x0400036E RID: 878
		public bool changedByFatigue = true;

		// Token: 0x0400036F RID: 879
		public float substractedByFatigue;

		// Token: 0x020000BC RID: 188
		public enum Tipo
		{
			// Token: 0x04000371 RID: 881
			minMax,
			// Token: 0x04000372 RID: 882
			min,
			// Token: 0x04000373 RID: 883
			max
		}

		// Token: 0x020000BD RID: 189
		[Serializable]
		public class Data : IDataOfInteractionArg
		{
			// Token: 0x170000CD RID: 205
			// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00016046 File Offset: 0x00014246
			// (set) Token: 0x060003E9 RID: 1001 RVA: 0x0001604E File Offset: 0x0001424E
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

			// Token: 0x170000CE RID: 206
			// (get) Token: 0x060003EA RID: 1002 RVA: 0x00016057 File Offset: 0x00014257
			// (set) Token: 0x060003EB RID: 1003 RVA: 0x0001605F File Offset: 0x0001425F
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

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x060003EC RID: 1004 RVA: 0x00016068 File Offset: 0x00014268
			// (set) Token: 0x060003ED RID: 1005 RVA: 0x00016070 File Offset: 0x00014270
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

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x060003EE RID: 1006 RVA: 0x00016079 File Offset: 0x00014279
			// (set) Token: 0x060003EF RID: 1007 RVA: 0x00016081 File Offset: 0x00014281
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

			// Token: 0x04000374 RID: 884
			public TipoDeEstimulo tipo;

			// Token: 0x04000375 RID: 885
			public DireccionDeEstimulo direccion;

			// Token: 0x04000376 RID: 886
			public ParteQuePuedeEstimular estiulante;

			// Token: 0x04000377 RID: 887
			public ParteDelCuerpoHumano[] estimuladas = Array.Empty<ParteDelCuerpoHumano>();
		}
	}
}
