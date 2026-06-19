using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas.Estimulos
{
	// Token: 0x02000162 RID: 354
	public abstract class TocadoPorSemenDeCharacter<T_Estimulante, T_Estimulado> : EstimuledBy<EstimuloTactilDeSemen, T_Estimulante, T_Estimulado> where T_Estimulante : class, ICharacter where T_Estimulado : MonoBehaviour
	{
		// Token: 0x0600080F RID: 2063 RVA: 0x000258B4 File Offset: 0x00023AB4
		protected TocadoPorSemenDeCharacter(TipoDeSemen paraTipo, T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, SkinSensibleASemen skin)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
			if (skin == null)
			{
				throw new ArgumentNullException("skin", "skin null reference.");
			}
			this.m_skin = skin;
			this.m_para = paraTipo;
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x00025913 File Offset: 0x00023B13
		public TipoDeSemen para
		{
			get
			{
				return this.m_para;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool clearBeforeUpdating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float maxTimeWaitingAsyncUpdate
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool soloUnCalculoPorFrame
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool syncUpdate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool AsyncUpdating()
		{
			return false;
		}

		// Token: 0x06000816 RID: 2070
		protected abstract bool TryGetParteDelCuerpoHumanoDeObjectoPenetrado(IPenetrable penetrado, out ParteDelCuerpoHumano parte);

		// Token: 0x06000817 RID: 2071 RVA: 0x00025922 File Offset: 0x00023B22
		protected override bool OnUpdating()
		{
			return base.OnUpdating() && this.m_skin.hits.Count > 0;
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00025944 File Offset: 0x00023B44
		protected override void LoadEstimulantes(List<T_Estimulante> resultado)
		{
			for (int i = 0; i < this.m_skin.hits.Count; i++)
			{
				SemenHit semenHit = this.m_skin.hits[i];
				if (semenHit.tipo == this.m_para)
				{
					T_Estimulante t_Estimulante = semenHit.pene.inmediateOwner as T_Estimulante;
					if (t_Estimulante != null)
					{
						if (!this.m_hitsDeCharacter.ContainsKey(t_Estimulante))
						{
							List<SemenHit> item = this.m_poolDeListas.GetItem();
							this.m_hitsDeCharacter.Add(t_Estimulante, item);
							item.Add(semenHit);
						}
						else
						{
							this.m_hitsDeCharacter[t_Estimulante].Add(semenHit);
						}
						if (!this.m_peneDeCharacter.ContainsKey(t_Estimulante))
						{
							this.m_peneDeCharacter.Add(t_Estimulante, semenHit.pene);
						}
						resultado.Add(t_Estimulante);
					}
				}
			}
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool EstimulanteCargadoEsValido(T_Estimulante estimulante, int index)
		{
			return true;
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnEstimulanteIgnorado(T_Estimulante estimulante)
		{
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnEstimulanteDuplicado(T_Estimulante estimulante, int index)
		{
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00025A1C File Offset: 0x00023C1C
		protected override void PoblarEstimuloDeEstimulante(T_Estimulante estimulante, EstimuloTactilDeSemen emptyEstimulo)
		{
			IPeneSimple peneSimple = this.m_peneDeCharacter[estimulante];
			ParteDelCuerpoHumano? parteDelCuerpoHumano = null;
			if (peneSimple.isPenetrating)
			{
				IPenetrable penetrable = peneSimple.TryGetPenetratingObject();
				if (penetrable != null)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano2;
					if (penetrable is IVagHole)
					{
						parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.vag);
					}
					else if (penetrable is IAnusHole)
					{
						parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.ano);
					}
					else if (penetrable is IBocaHole)
					{
						parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.bocaInterno);
					}
					else if (this.TryGetParteDelCuerpoHumanoDeObjectoPenetrado(penetrable, out parteDelCuerpoHumano2))
					{
						parteDelCuerpoHumano = new ParteDelCuerpoHumano?(parteDelCuerpoHumano2);
					}
					else
					{
						string text = "No se puedo determinar el tipo de hole: ";
						Type type = penetrable.GetType();
						Debug.LogError(text + ((type != null) ? type.ToString() : null), penetrable as Object);
					}
				}
			}
			emptyEstimulo.tipoDeEstimulo = TipoDeEstimulo.tactil;
			emptyEstimulo.DefinirReferencias(base.estimulado, base.prioridadesDeObjetoEstimulado, estimulante as Component, peneSimple.root, null);
			emptyEstimulo.side = this.m_skin.hitSkinBasica.side;
			emptyEstimulo.esUnaVez = true;
			emptyEstimulo.tipo = DireccionDeEstimulo.recibida;
			emptyEstimulo.pene = peneSimple;
			emptyEstimulo.penetrando = parteDelCuerpoHumano;
			emptyEstimulo.tipoDeSemen = this.m_para;
			this.Acumular(this.m_hitsDeCharacter[estimulante], emptyEstimulo);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00025B48 File Offset: 0x00023D48
		private void Acumular(List<SemenHit> lista, EstimuloTactilDeSemen result)
		{
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			for (int i = 0; i < lista.Count; i++)
			{
				SemenHit semenHit = lista[i];
				result.velocidadRelativaEmuladaMaxima = Mathf.Max(semenHit.velocidad, result.velocidadRelativaEmuladaMaxima);
				result.velocidadRelativaEmuladaTotal += semenHit.velocidad;
				result.AddParteEstimulada(semenHit.parteImpactada);
				vector += semenHit.intersection;
				vector2 += semenHit.normal;
			}
			vector /= (float)lista.Count;
			vector2 = vector2.normalized;
			result.DefinirTransformsYVectores(this.m_skin.hitSkinBasica.boneTarget, new Vector3?(vector2), new Vector3?(vector), null);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00025C04 File Offset: 0x00023E04
		protected override void OnUpdated()
		{
			base.OnUpdated();
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00025C0C File Offset: 0x00023E0C
		protected override void FinallyUpdated()
		{
			foreach (KeyValuePair<T_Estimulante, List<SemenHit>> keyValuePair in this.m_hitsDeCharacter)
			{
				this.m_poolDeListas.ReturnItem(keyValuePair.Value);
			}
			this.m_hitsDeCharacter.Clear();
			this.m_peneDeCharacter.Clear();
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool Clearing()
		{
			return true;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Cleared()
		{
		}

		// Token: 0x04000663 RID: 1635
		private TipoDeSemen m_para;

		// Token: 0x04000664 RID: 1636
		private SkinSensibleASemen m_skin;

		// Token: 0x04000665 RID: 1637
		private Dictionary<T_Estimulante, List<SemenHit>> m_hitsDeCharacter = new Dictionary<T_Estimulante, List<SemenHit>>();

		// Token: 0x04000666 RID: 1638
		private SimplePoolDeCollection<List<SemenHit>, SemenHit> m_poolDeListas = new SimplePoolDeCollection<List<SemenHit>, SemenHit>();

		// Token: 0x04000667 RID: 1639
		private Dictionary<T_Estimulante, IPeneSimple> m_peneDeCharacter = new Dictionary<T_Estimulante, IPeneSimple>();
	}
}
