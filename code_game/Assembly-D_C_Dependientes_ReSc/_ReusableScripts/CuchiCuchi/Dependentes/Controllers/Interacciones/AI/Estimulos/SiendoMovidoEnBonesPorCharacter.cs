using System;
using System.Collections.Generic;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E6 RID: 486
	public abstract class SiendoMovidoEnBonesPorCharacter<T_Estimulado> : EstimuledBy<EstimuloPorManipulacionDeBone, Character, T_Estimulado> where T_Estimulado : MonoBehaviour, IMovidoEnBonesEnFrameDataCollector
	{
		// Token: 0x06000B9F RID: 2975 RVA: 0x0003845B File Offset: 0x0003665B
		protected SiendoMovidoEnBonesPorCharacter(T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool clearBeforeUpdating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float maxTimeWaitingAsyncUpdate
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool soloUnCalculoPorFrame
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool syncUpdate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00002BE7 File Offset: 0x00000DE7
		protected override bool AsyncUpdating()
		{
			return false;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool EstimulanteCargadoEsValido(Character estimulante, int index)
		{
			return true;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnEstimulanteIgnorado(Character estimulante)
		{
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnEstimulanteDuplicado(Character estimulante, int index)
		{
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x000118D7 File Offset: 0x0000FAD7
		protected override object ParceEstimulante(object estimulante)
		{
			return estimulante;
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000BA9 RID: 2985
		protected abstract IReadOnlyList<ManipulacionDeBoneData> enFrameData { get; }

		// Token: 0x06000BAA RID: 2986 RVA: 0x0003847B File Offset: 0x0003667B
		protected override bool OnUpdating()
		{
			return base.OnUpdating() && this.enFrameData.Count > 0;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00038498 File Offset: 0x00036698
		protected override void LoadEstimulantes(List<Character> resultado)
		{
			IReadOnlyList<ManipulacionDeBoneData> enFrameData = this.enFrameData;
			for (int i = 0; i < enFrameData.Count; i++)
			{
				ManipulacionDeBoneData manipulacionDeBoneData = enFrameData[i];
				if (!(manipulacionDeBoneData.por == null))
				{
					resultado.Add(manipulacionDeBoneData.por);
					if (this.m_dataDeChar.ContainsKey(manipulacionDeBoneData.por))
					{
						this.m_dataDeChar[manipulacionDeBoneData.por].Add(manipulacionDeBoneData);
					}
					else
					{
						List<ManipulacionDeBoneData> item = this.m_poolDeListas.GetItem();
						item.Add(manipulacionDeBoneData);
						this.m_dataDeChar.Add(manipulacionDeBoneData.por, item);
					}
				}
			}
		}

		// Token: 0x06000BAC RID: 2988
		protected abstract TipoDeEstimulo ObtenerEstimulo(Character estimulante);

		// Token: 0x06000BAD RID: 2989
		protected abstract Transform ObtenerTransformEstimulante(Character estimulante);

		// Token: 0x06000BAE RID: 2990
		protected abstract float CalculeVelocidadRelativaEmulada();

		// Token: 0x06000BAF RID: 2991 RVA: 0x00038538 File Offset: 0x00036738
		protected override void PoblarEstimuloDeEstimulante(Character estimulante, EstimuloPorManipulacionDeBone emptyEstimulo)
		{
			emptyEstimulo.tipoDeEstimulo = this.ObtenerEstimulo(estimulante);
			emptyEstimulo.DefinirReferencias(base.estimulado, base.prioridadesDeObjetoEstimulado, estimulante, this.ObtenerTransformEstimulante(estimulante), null);
			emptyEstimulo.velocidadRelativaEmulada = this.CalculeVelocidadRelativaEmulada();
			GizmoDeBoneRMInfo boneInfo = base.estimulado.boneInfo;
			emptyEstimulo.side = boneInfo.side;
			emptyEstimulo.tipo = DireccionDeEstimulo.recibida;
			this.Acumular(this.m_dataDeChar[estimulante], estimulante, emptyEstimulo);
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x000385B8 File Offset: 0x000367B8
		private void Acumular(List<ManipulacionDeBoneData> lista, Character estimulante, EstimuloPorManipulacionDeBone result)
		{
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 position = result.transformEstimulante.position;
			for (int i = lista.Count - 1; i >= 0; i--)
			{
				ManipulacionDeBoneData manipulacionDeBoneData = lista[i];
				if (manipulacionDeBoneData.transformEstimulado == null)
				{
					lista.RemoveAt(i);
				}
				else
				{
					Vector3 position2 = manipulacionDeBoneData.transformEstimulado.position;
					Vector3 vector3 = -(position2 - position).normalized;
					vector += position2;
					vector2 += vector3;
					result.AddData(ref manipulacionDeBoneData);
				}
			}
			vector /= (float)lista.Count;
			vector2 = vector2.normalized;
			HumanBodyBones humanBodyBones = result.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).ParceToHumanBodyBones(Side.R);
			Transform boneTransform = base.estimulado.character.bodyAnimator.GetBoneTransform(humanBodyBones);
			result.DefinirTransformsYVectores(boneTransform, new Vector3?(vector2), new Vector3?(vector), null);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x000383A4 File Offset: 0x000365A4
		protected override void OnUpdated()
		{
			base.OnUpdated();
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x000386B0 File Offset: 0x000368B0
		protected override void FinallyUpdated()
		{
			foreach (KeyValuePair<Character, List<ManipulacionDeBoneData>> keyValuePair in this.m_dataDeChar)
			{
				this.m_poolDeListas.ReturnItem(keyValuePair.Value);
			}
			this.m_dataDeChar.Clear();
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool Clearing()
		{
			return true;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void Cleared()
		{
		}

		// Token: 0x0400088F RID: 2191
		private Dictionary<Character, List<ManipulacionDeBoneData>> m_dataDeChar = new Dictionary<Character, List<ManipulacionDeBoneData>>();

		// Token: 0x04000890 RID: 2192
		private SimplePoolDeCollection<List<ManipulacionDeBoneData>, ManipulacionDeBoneData> m_poolDeListas = new SimplePoolDeCollection<List<ManipulacionDeBoneData>, ManipulacionDeBoneData>();
	}
}
