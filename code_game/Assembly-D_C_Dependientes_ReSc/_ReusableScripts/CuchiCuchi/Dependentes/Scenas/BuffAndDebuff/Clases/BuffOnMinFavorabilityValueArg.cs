using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine.Serialization;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C1 RID: 193
	[Serializable]
	public class BuffOnMinFavorabilityValueArg : DisplayableArgumentoDeEfecto<BuffOnMinFavorabilityValueArg>, IExclusiveInteractionArg, IInteractionArg
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x000066D6 File Offset: 0x000048D6
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.favorability;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0001663E File Offset: 0x0001483E
		IReadOnlyList<IDataOfInteractionArg> IInteractionArg.data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00016648 File Offset: 0x00014848
		public void InyectData(IReadOnlyList<IDataOfInteractionArg> inyected)
		{
			List<BuffOnMinFavorabilityValueArg.Data> list = new List<BuffOnMinFavorabilityValueArg.Data>(this.data);
			for (int i = 0; i < inyected.Count; i++)
			{
				IDataOfInteractionArg dataOfInteractionArg = inyected[i];
				IDataOfInteractionArg newInteractionDataInstance = this.GetNewInteractionDataInstance();
				newInteractionDataInstance.tipo = dataOfInteractionArg.tipo;
				newInteractionDataInstance.direccion = dataOfInteractionArg.direccion;
				newInteractionDataInstance.estiulante = dataOfInteractionArg.estiulante;
				newInteractionDataInstance.estimuladas = dataOfInteractionArg.estimuladas;
				list.Add((BuffOnMinFavorabilityValueArg.Data)newInteractionDataInstance);
			}
			this.data = list.ToArray();
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000166C9 File Offset: 0x000148C9
		public IDataOfInteractionArg GetNewInteractionDataInstance()
		{
			return new BuffOnMinFavorabilityValueArg.Data();
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x000166D0 File Offset: 0x000148D0
		IReadOnlyList<IDataExlusiveOfInteractionArg> IExclusiveInteractionArg.dataExcluir
		{
			get
			{
				return this.dataExcluir;
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000166D8 File Offset: 0x000148D8
		public void InyectExclusiveData(IReadOnlyList<IDataExlusiveOfInteractionArg> inyected)
		{
			List<BuffOnMinFavorabilityValueArg.ExclusionData> list = new List<BuffOnMinFavorabilityValueArg.ExclusionData>(this.dataExcluir);
			for (int i = 0; i < inyected.Count; i++)
			{
				IDataExlusiveOfInteractionArg dataExlusiveOfInteractionArg = inyected[i];
				IDataExlusiveOfInteractionArg newInteractionDataExclusiveInstance = this.GetNewInteractionDataExclusiveInstance();
				newInteractionDataExclusiveInstance.tipo = dataExlusiveOfInteractionArg.tipo;
				newInteractionDataExclusiveInstance.direccion = dataExlusiveOfInteractionArg.direccion;
				newInteractionDataExclusiveInstance.estiulante = dataExlusiveOfInteractionArg.estiulante;
				newInteractionDataExclusiveInstance.estimuladas = dataExlusiveOfInteractionArg.estimuladas;
				newInteractionDataExclusiveInstance.weight = dataExlusiveOfInteractionArg.weight;
				list.Add((BuffOnMinFavorabilityValueArg.ExclusionData)newInteractionDataExclusiveInstance);
			}
			this.dataExcluir = list.ToArray();
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00016765 File Offset: 0x00014965
		public IDataExlusiveOfInteractionArg GetNewInteractionDataExclusiveInstance()
		{
			return new BuffOnMinFavorabilityValueArg.ExclusionData();
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001676C File Offset: 0x0001496C
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return "min. +" + this.added.ToString("0.0") + (this.changedByFatigue ? (" -" + this.substractedByFatigue.ToString()) : string.Empty);
		}

		// Token: 0x0400037A RID: 890
		[FormerlySerializedAs("data")]
		public BuffOnMinFavorabilityValueArg.Data[] data = Array.Empty<BuffOnMinFavorabilityValueArg.Data>();

		// Token: 0x0400037B RID: 891
		public BuffOnMinFavorabilityValueArg.ExclusionData[] dataExcluir = Array.Empty<BuffOnMinFavorabilityValueArg.ExclusionData>();

		// Token: 0x0400037C RID: 892
		public bool force;

		// Token: 0x0400037D RID: 893
		public bool changedByFatigue = true;

		// Token: 0x0400037E RID: 894
		public float added;

		// Token: 0x0400037F RID: 895
		public float substractedByFatigue;

		// Token: 0x020000C2 RID: 194
		[Serializable]
		public class Data : IDataOfInteractionArg
		{
			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x06000405 RID: 1029 RVA: 0x000167D1 File Offset: 0x000149D1
			// (set) Token: 0x06000406 RID: 1030 RVA: 0x000167D9 File Offset: 0x000149D9
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

			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x06000407 RID: 1031 RVA: 0x000167E2 File Offset: 0x000149E2
			// (set) Token: 0x06000408 RID: 1032 RVA: 0x000167EA File Offset: 0x000149EA
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

			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x06000409 RID: 1033 RVA: 0x000167F3 File Offset: 0x000149F3
			// (set) Token: 0x0600040A RID: 1034 RVA: 0x000167FB File Offset: 0x000149FB
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

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x0600040B RID: 1035 RVA: 0x00016804 File Offset: 0x00014A04
			// (set) Token: 0x0600040C RID: 1036 RVA: 0x0001680C File Offset: 0x00014A0C
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

			// Token: 0x04000380 RID: 896
			public TipoDeEstimulo tipo;

			// Token: 0x04000381 RID: 897
			public DireccionDeEstimulo direccion;

			// Token: 0x04000382 RID: 898
			public ParteQuePuedeEstimular estiulante;

			// Token: 0x04000383 RID: 899
			public ParteDelCuerpoHumano[] estimuladas = Array.Empty<ParteDelCuerpoHumano>();
		}

		// Token: 0x020000C3 RID: 195
		[Serializable]
		public class ExclusionData : BuffOnMinFavorabilityValueArg.Data, IDataExlusiveOfInteractionArg, IDataOfInteractionArg
		{
			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x0600040E RID: 1038 RVA: 0x00016828 File Offset: 0x00014A28
			// (set) Token: 0x0600040F RID: 1039 RVA: 0x00016830 File Offset: 0x00014A30
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

			// Token: 0x04000384 RID: 900
			public float weight = 1f;
		}
	}
}
