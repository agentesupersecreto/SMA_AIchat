using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos.Clases
{
	// Token: 0x0200038F RID: 911
	public abstract class SiendoDesvestido<T_Estimulado> : EstimuledBy<EstimuloPorDesvestir, Character, T_Estimulado> where T_Estimulado : MonoBehaviour, IRopaLoaderFrameData
	{
		// Token: 0x060013DF RID: 5087 RVA: 0x00056457 File Offset: 0x00054657
		public SiendoDesvestido(T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool clearBeforeUpdating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060013E1 RID: 5089 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float maxTimeWaitingAsyncUpdate
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060013E2 RID: 5090 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool soloUnCalculoPorFrame
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060013E3 RID: 5091 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool syncUpdate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool AsyncUpdating()
		{
			return false;
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool EstimulanteCargadoEsValido(Character estimulante, int index)
		{
			return true;
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnEstimulanteIgnorado(Character estimulante)
		{
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnEstimulanteDuplicado(Character estimulante, int index)
		{
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override object ParceEstimulante(object estimulante)
		{
			return estimulante;
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x00056477 File Offset: 0x00054677
		protected override bool OnUpdating()
		{
			return base.OnUpdating() && base.estimulado.enRemoverFrame.Count > 0;
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0005649C File Offset: 0x0005469C
		protected override void LoadEstimulantes(List<Character> resultado)
		{
			for (int i = 0; i < base.estimulado.enRemoverFrame.Count; i++)
			{
				SiendoDesvestidoFrameData siendoDesvestidoFrameData = base.estimulado.enRemoverFrame[i];
				if (!(siendoDesvestidoFrameData.por == null))
				{
					resultado.Add(siendoDesvestidoFrameData.por);
					if (this.m_dataDeChar.ContainsKey(siendoDesvestidoFrameData.por))
					{
						this.m_dataDeChar[siendoDesvestidoFrameData.por].Add(siendoDesvestidoFrameData);
					}
					else
					{
						List<SiendoDesvestidoFrameData> item = this.m_poolDeListas.GetItem();
						item.Add(siendoDesvestidoFrameData);
						this.m_dataDeChar.Add(siendoDesvestidoFrameData.por, item);
					}
				}
			}
		}

		// Token: 0x060013EB RID: 5099
		protected abstract TipoDeEstimulo ObtenerEstimulo(Character estimulante);

		// Token: 0x060013EC RID: 5100
		protected abstract Transform ObtenerTransformEstimulante(Character estimulante);

		// Token: 0x060013ED RID: 5101 RVA: 0x00056558 File Offset: 0x00054758
		protected override void PoblarEstimuloDeEstimulante(Character estimulante, EstimuloPorDesvestir emptyEstimulo)
		{
			List<SiendoDesvestidoFrameData> list = this.m_dataDeChar[estimulante];
			emptyEstimulo.tipoDeEstimulo = this.ObtenerEstimulo(estimulante);
			emptyEstimulo.DefinirReferencias(base.estimulado, base.prioridadesDeObjetoEstimulado, estimulante, this.ObtenerTransformEstimulante(estimulante), null);
			emptyEstimulo.side = Side.none;
			emptyEstimulo.tipo = DireccionDeEstimulo.recibida;
			this.Acumular(list, estimulante, emptyEstimulo);
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x000565B8 File Offset: 0x000547B8
		private void Acumular(List<SiendoDesvestidoFrameData> lista, Character estimulante, EstimuloPorDesvestir result)
		{
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 position = result.transformEstimulante.position;
			IRopaManager manager = base.estimulado.manager;
			for (int i = lista.Count - 1; i >= 0; i--)
			{
				SiendoDesvestidoFrameData siendoDesvestidoFrameData = lista[i];
				Vector3 vector3 = base.estimulado.character.rootBoneTransform.TransformPoint(siendoDesvestidoFrameData.puntoLocalDePiezaDesdeRoot);
				Vector3 vector4 = -(vector3 - position).normalized;
				vector += vector3;
				vector2 += vector4;
				if (siendoDesvestidoFrameData.partesExpuestas == RopaCubre.None)
				{
					RopaCubre ropaCubre = manager.CurrentPiezaCubreFlags(siendoDesvestidoFrameData.piezaID, true);
					result.AddPieza(siendoDesvestidoFrameData.piezaID, ropaCubre, Sexo.femenino);
				}
				else
				{
					result.AddPieza(siendoDesvestidoFrameData.piezaID, siendoDesvestidoFrameData.partesExpuestas, Sexo.femenino);
				}
				result.parcial |= siendoDesvestidoFrameData.parcial;
				result.esUnaVez |= siendoDesvestidoFrameData.soloUnaVez;
			}
			vector /= (float)lista.Count;
			vector2 = vector2.normalized;
			HumanBodyBones humanBodyBones = result.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).ParceToHumanBodyBones(Side.R);
			Transform boneTransform = base.estimulado.character.bodyAnimator.GetBoneTransform(humanBodyBones);
			result.DefinirTransformsYVectores(boneTransform, new Vector3?(vector2), new Vector3?(vector), null);
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x00025C04 File Offset: 0x00023E04
		protected override void OnUpdated()
		{
			base.OnUpdated();
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x00056724 File Offset: 0x00054924
		protected override void FinallyUpdated()
		{
			foreach (KeyValuePair<Character, List<SiendoDesvestidoFrameData>> keyValuePair in this.m_dataDeChar)
			{
				this.m_poolDeListas.ReturnItem(keyValuePair.Value);
			}
			this.m_dataDeChar.Clear();
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool Clearing()
		{
			return true;
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Cleared()
		{
		}

		// Token: 0x0400107F RID: 4223
		private Dictionary<Character, List<SiendoDesvestidoFrameData>> m_dataDeChar = new Dictionary<Character, List<SiendoDesvestidoFrameData>>();

		// Token: 0x04001080 RID: 4224
		private SimplePoolDeCollection<List<SiendoDesvestidoFrameData>, SiendoDesvestidoFrameData> m_poolDeListas = new SimplePoolDeCollection<List<SiendoDesvestidoFrameData>, SiendoDesvestidoFrameData>();
	}
}
