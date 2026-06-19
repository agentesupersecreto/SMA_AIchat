using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E2 RID: 482
	public abstract class SiendoCambiadoDePosePorCharacter<T_Estimulado> : EstimuledBy<EstimuloPorCambiarPose, Character, T_Estimulado> where T_Estimulado : MonoBehaviour, ICambioDePoseEnFrameDataCollector
	{
		// Token: 0x06000B7E RID: 2942 RVA: 0x0003808B File Offset: 0x0003628B
		public SiendoCambiadoDePosePorCharacter(T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool clearBeforeUpdating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000B80 RID: 2944 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float maxTimeWaitingAsyncUpdate
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool soloUnCalculoPorFrame
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool syncUpdate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x00002BE7 File Offset: 0x00000DE7
		protected override bool AsyncUpdating()
		{
			return false;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool EstimulanteCargadoEsValido(Character estimulante, int index)
		{
			return true;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnEstimulanteIgnorado(Character estimulante)
		{
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnEstimulanteDuplicado(Character estimulante, int index)
		{
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000B87 RID: 2951
		protected abstract EstimuloPorCambiarPose.Estado paraEstado { get; }

		// Token: 0x06000B88 RID: 2952 RVA: 0x000118D7 File Offset: 0x0000FAD7
		protected override object ParceEstimulante(object estimulante)
		{
			return estimulante;
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x000380B4 File Offset: 0x000362B4
		protected IReadOnlyList<CambioDePoseData> enFrameData
		{
			get
			{
				switch (this.paraEstado)
				{
				case EstimuloPorCambiarPose.Estado.None:
					throw new InvalidOperationException();
				case EstimuloPorCambiarPose.Estado.ejecutada:
					return base.estimulado.ejecutadasEnFrame;
				case EstimuloPorCambiarPose.Estado.detenida:
					return base.estimulado.detenidasEnFrame;
				default:
					throw new ArgumentOutOfRangeException(this.paraEstado.ToString());
				}
			}
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0003811D File Offset: 0x0003631D
		protected override bool OnUpdating()
		{
			return base.OnUpdating() && this.enFrameData.Count > 0;
		}

		// Token: 0x06000B8B RID: 2955
		protected abstract bool DataEsValida(ref CambioDePoseData data);

		// Token: 0x06000B8C RID: 2956 RVA: 0x00038138 File Offset: 0x00036338
		protected override void LoadEstimulantes(List<Character> resultado)
		{
			IReadOnlyList<CambioDePoseData> enFrameData = this.enFrameData;
			for (int i = 0; i < enFrameData.Count; i++)
			{
				CambioDePoseData cambioDePoseData = enFrameData[i];
				if (!(cambioDePoseData.por == null) && this.DataEsValida(ref cambioDePoseData))
				{
					resultado.Add(cambioDePoseData.por);
					if (this.m_dataDeChar.ContainsKey(cambioDePoseData.por))
					{
						this.m_dataDeChar[cambioDePoseData.por].Add(cambioDePoseData);
					}
					else
					{
						List<CambioDePoseData> item = this.m_poolDeListas.GetItem();
						item.Add(cambioDePoseData);
						this.m_dataDeChar.Add(cambioDePoseData.por, item);
					}
				}
			}
		}

		// Token: 0x06000B8D RID: 2957
		protected abstract TipoDeEstimulo ObtenerEstimulo(Character estimulante);

		// Token: 0x06000B8E RID: 2958
		protected abstract Transform ObtenerTransformEstimulante(Character estimulante);

		// Token: 0x06000B8F RID: 2959 RVA: 0x000381E8 File Offset: 0x000363E8
		protected override void PoblarEstimuloDeEstimulante(Character estimulante, EstimuloPorCambiarPose emptyEstimulo)
		{
			emptyEstimulo.tipoDeEstimulo = this.ObtenerEstimulo(estimulante);
			emptyEstimulo.DefinirReferencias(base.estimulado, base.prioridadesDeObjetoEstimulado, estimulante, this.ObtenerTransformEstimulante(estimulante), null);
			emptyEstimulo.side = Side.none;
			emptyEstimulo.tipo = DireccionDeEstimulo.recibida;
			emptyEstimulo.orden = this.paraEstado;
			this.Acumular(this.m_dataDeChar[estimulante], estimulante, emptyEstimulo);
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x00038250 File Offset: 0x00036450
		private void Acumular(List<CambioDePoseData> lista, Character estimulante, EstimuloPorCambiarPose result)
		{
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 position = result.transformEstimulante.position;
			bool flag = false;
			float num = 0f;
			for (int i = lista.Count - 1; i >= 0; i--)
			{
				CambioDePoseData cambioDePoseData = lista[i];
				if (!cambioDePoseData.ExponiendoPartesEsValido || cambioDePoseData.transformEstimulado == null)
				{
					lista.RemoveAt(i);
				}
				else
				{
					Vector3 position2 = cambioDePoseData.transformEstimulado.position;
					Vector3 vector3 = -(position2 - position).normalized;
					vector += position2;
					vector2 += vector3;
					result.AddPose(ref cambioDePoseData);
					flag |= cambioDePoseData.cambioConVelocidad;
					num += cambioDePoseData.velocidadDeCambio;
					result.esUnaVez |= cambioDePoseData.unaSolaVez;
				}
			}
			vector /= (float)lista.Count;
			vector2 = vector2.normalized;
			num /= (float)lista.Count;
			HumanBodyBones humanBodyBones = result.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).ParceToHumanBodyBones(Side.R);
			Transform boneTransform = base.estimulado.character.bodyAnimator.GetBoneTransform(humanBodyBones);
			result.DefinirTransformsYVectores(boneTransform, new Vector3?(vector2), new Vector3?(vector), null);
			result.cambioManualmente = flag;
			result.velocidadRelativaEmulada = num;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x000383A4 File Offset: 0x000365A4
		protected override void OnUpdated()
		{
			base.OnUpdated();
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x000383AC File Offset: 0x000365AC
		protected override void FinallyUpdated()
		{
			foreach (KeyValuePair<Character, List<CambioDePoseData>> keyValuePair in this.m_dataDeChar)
			{
				this.m_poolDeListas.ReturnItem(keyValuePair.Value);
			}
			this.m_dataDeChar.Clear();
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool Clearing()
		{
			return true;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void Cleared()
		{
		}

		// Token: 0x0400088D RID: 2189
		private Dictionary<Character, List<CambioDePoseData>> m_dataDeChar = new Dictionary<Character, List<CambioDePoseData>>();

		// Token: 0x0400088E RID: 2190
		private SimplePoolDeCollection<List<CambioDePoseData>, CambioDePoseData> m_poolDeListas = new SimplePoolDeCollection<List<CambioDePoseData>, CambioDePoseData>();
	}
}
