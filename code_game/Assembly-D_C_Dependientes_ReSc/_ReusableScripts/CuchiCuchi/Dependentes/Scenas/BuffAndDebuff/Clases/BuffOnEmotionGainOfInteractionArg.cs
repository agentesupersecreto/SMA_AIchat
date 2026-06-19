using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B5 RID: 181
	public class BuffOnEmotionGainOfInteractionArg : DisplayableArgumentoDeEfecto<BuffOnEmotionGainOfInteractionArg>, IInteractionArg
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003BC RID: 956 RVA: 0x0001566E File Offset: 0x0001386E
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return this.emo.ParseToCategory();
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0001567B File Offset: 0x0001387B
		IReadOnlyList<IDataOfInteractionArg> IInteractionArg.data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00015684 File Offset: 0x00013884
		public void InyectData(IReadOnlyList<IDataOfInteractionArg> inyected)
		{
			List<BuffOnEmotionGainOfInteractionArg.Data> list = new List<BuffOnEmotionGainOfInteractionArg.Data>(this.data);
			for (int i = 0; i < inyected.Count; i++)
			{
				IDataOfInteractionArg dataOfInteractionArg = inyected[i];
				IDataOfInteractionArg newInteractionDataInstance = this.GetNewInteractionDataInstance();
				newInteractionDataInstance.tipo = dataOfInteractionArg.tipo;
				newInteractionDataInstance.direccion = dataOfInteractionArg.direccion;
				newInteractionDataInstance.estiulante = dataOfInteractionArg.estiulante;
				newInteractionDataInstance.estimuladas = dataOfInteractionArg.estimuladas;
				list.Add((BuffOnEmotionGainOfInteractionArg.Data)newInteractionDataInstance);
			}
			this.data = list.ToArray();
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00015705 File Offset: 0x00013905
		public IDataOfInteractionArg GetNewInteractionDataInstance()
		{
			return new BuffOnEmotionGainOfInteractionArg.Data();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0001570C File Offset: 0x0001390C
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return "gain " + this.gain.ToString() + "×" + (this.changedByFatigue ? (" then " + this.substractedByFatigue.ToString() + "×") : string.Empty);
		}

		// Token: 0x04000358 RID: 856
		public float gain;

		// Token: 0x04000359 RID: 857
		public ReaccionHumana emo;

		// Token: 0x0400035A RID: 858
		public BuffOnEmotionGainOfInteractionArg.Data[] data = Array.Empty<BuffOnEmotionGainOfInteractionArg.Data>();

		// Token: 0x0400035B RID: 859
		public bool changedByFatigue = true;

		// Token: 0x0400035C RID: 860
		public float substractedByFatigue;

		// Token: 0x020000B6 RID: 182
		[Serializable]
		public class Data : IDataOfInteractionArg
		{
			// Token: 0x170000C1 RID: 193
			// (get) Token: 0x060003C2 RID: 962 RVA: 0x00015776 File Offset: 0x00013976
			// (set) Token: 0x060003C3 RID: 963 RVA: 0x0001577E File Offset: 0x0001397E
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

			// Token: 0x170000C2 RID: 194
			// (get) Token: 0x060003C4 RID: 964 RVA: 0x00015787 File Offset: 0x00013987
			// (set) Token: 0x060003C5 RID: 965 RVA: 0x0001578F File Offset: 0x0001398F
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

			// Token: 0x170000C3 RID: 195
			// (get) Token: 0x060003C6 RID: 966 RVA: 0x00015798 File Offset: 0x00013998
			// (set) Token: 0x060003C7 RID: 967 RVA: 0x000157A0 File Offset: 0x000139A0
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

			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x060003C8 RID: 968 RVA: 0x000157A9 File Offset: 0x000139A9
			// (set) Token: 0x060003C9 RID: 969 RVA: 0x000157B1 File Offset: 0x000139B1
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

			// Token: 0x0400035D RID: 861
			public TipoDeEstimulo tipo;

			// Token: 0x0400035E RID: 862
			public DireccionDeEstimulo direccion;

			// Token: 0x0400035F RID: 863
			public ParteQuePuedeEstimular estiulante;

			// Token: 0x04000360 RID: 864
			public ParteDelCuerpoHumano[] estimuladas = Array.Empty<ParteDelCuerpoHumano>();
		}
	}
}
