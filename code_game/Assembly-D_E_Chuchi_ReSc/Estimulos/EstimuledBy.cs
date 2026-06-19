using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x0200029E RID: 670
	public abstract class EstimuledBy<T_InteracionEstimulanteBasica, T_Estimulante, T_Estimulado> : EstimuledBy where T_InteracionEstimulanteBasica : InteracionEstimulanteBasica, IClearable, new() where T_Estimulante : class where T_Estimulado : MonoBehaviour
	{
		// Token: 0x06000EC0 RID: 3776 RVA: 0x00044EEC File Offset: 0x000430EC
		protected EstimuledBy(T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
			this.m_poolDeEstimulos = new PoolDeInteraccionEstimulante<T_InteracionEstimulanteBasica>();
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x00044F53 File Offset: 0x00043153
		public T_Estimulado estimulado
		{
			get
			{
				return (T_Estimulado)((object)base.objetoEstimulado);
			}
		}

		// Token: 0x1700034A RID: 842
		public T_Estimulante this[int i]
		{
			get
			{
				if (this.m_listDeEstimulantes.Count > i)
				{
					return this.m_listDeEstimulantes[i];
				}
				return default(T_Estimulante);
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00044F91 File Offset: 0x00043191
		protected sealed override IList objetosEstimulantes
		{
			get
			{
				return this.m_listDeEstimulantes;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00044F99 File Offset: 0x00043199
		protected sealed override IList objetosEstimulos
		{
			get
			{
				return this.m_listaDeEstimulos;
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x00044FA1 File Offset: 0x000431A1
		protected sealed override IDictionary estimulosDeObjetosEstimulante
		{
			get
			{
				return this.m_estimulosDeEstimulante;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000EC6 RID: 3782
		protected abstract bool syncUpdate { get; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000EC7 RID: 3783
		protected abstract float maxTimeWaitingAsyncUpdate { get; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x00044FA9 File Offset: 0x000431A9
		public sealed override int cantidadDeEstimulantes
		{
			get
			{
				return this.m_listDeEstimulantes.Count;
			}
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00044FB6 File Offset: 0x000431B6
		protected sealed override object ObtenerEstimulante(int index)
		{
			return this[index];
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00044FC4 File Offset: 0x000431C4
		protected T_InteracionEstimulanteBasica GetEstimuloDeEstimulante(T_Estimulante estimulante)
		{
			T_InteracionEstimulanteBasica t_InteracionEstimulanteBasica;
			if (this.m_estimulosDeEstimulante.TryGetValue(estimulante, out t_InteracionEstimulanteBasica))
			{
				return t_InteracionEstimulanteBasica;
			}
			return default(T_InteracionEstimulanteBasica);
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00044FEC File Offset: 0x000431EC
		public bool AddToIgnore(T_Estimulante estimulante)
		{
			return estimulante != null && this.m_IgnoringEstimulantes.Add(estimulante);
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00045004 File Offset: 0x00043204
		public virtual bool EstaIgnorandoA(T_Estimulante estimulante)
		{
			return this.m_IgnoringEstimulantes.Contains(estimulante);
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00045018 File Offset: 0x00043218
		protected sealed override void OnUpdate()
		{
			if (this.syncUpdate)
			{
				this.m_waitingUpdate = true;
				this.DoUpdate();
				return;
			}
			if (Time.time - this.m_lastUpdateTime > this.maxTimeWaitingAsyncUpdate)
			{
				this.m_waitingUpdate = false;
			}
			if (this.m_waitingUpdate)
			{
				return;
			}
			if (this.AsyncUpdating())
			{
				this.m_waitingUpdate = true;
			}
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00045070 File Offset: 0x00043270
		protected void DoUpdate()
		{
			try
			{
				if (this.m_waitingUpdate)
				{
					this.m_lastUpdateTime = Time.time;
					if (!this.soloUnCalculoPorFrame || !this.m_id.IsCurrent())
					{
						this.m_id = ForcedUpdateId.current;
						if (this.clearBeforeUpdating)
						{
							this.Clear();
						}
						if (this.OnUpdating())
						{
							this.LoadEstimulantes(this.m_tempEstimulantes);
							for (int i = 0; i < this.m_tempEstimulantes.Count; i++)
							{
								T_Estimulante t_Estimulante = this.m_tempEstimulantes[i];
								if (this.EstaIgnorandoA(t_Estimulante))
								{
									this.OnEstimulanteIgnorado(t_Estimulante);
								}
								else if (this.m_tempEstimulantesDublicadosChecker.Add(t_Estimulante))
								{
									if (this.EstimulanteCargadoEsValido(t_Estimulante, i))
									{
										this.m_listDeEstimulantes.Add(t_Estimulante);
									}
								}
								else
								{
									this.OnEstimulanteDuplicado(t_Estimulante, i);
								}
							}
							for (int j = this.m_listDeEstimulantes.Count - 1; j >= 0; j--)
							{
								T_Estimulante t_Estimulante2 = this.m_listDeEstimulantes[j];
								T_InteracionEstimulanteBasica itemDefault = this.m_poolDeEstimulos.GetItemDefault();
								this.PoblarEstimuloDeEstimulante(t_Estimulante2, itemDefault);
								if (itemDefault == null)
								{
									this.m_listDeEstimulantes.RemoveAt(j);
								}
								else
								{
									itemDefault.GenerateNewID();
									this.m_listaDeEstimulos.Add(itemDefault);
									this.m_estimulosDeEstimulante.Add(t_Estimulante2, itemDefault);
								}
							}
							this.OnUpdated();
						}
					}
				}
			}
			finally
			{
				this.m_waitingUpdate = false;
				this.m_tempEstimulantes.Clear();
				this.m_tempEstimulantesDublicadosChecker.Clear();
				this.FinallyUpdated();
				base.OnFinallyUpdatedEvent();
			}
		}

		// Token: 0x06000ECF RID: 3791
		protected abstract bool AsyncUpdating();

		// Token: 0x06000ED0 RID: 3792
		protected abstract void LoadEstimulantes(List<T_Estimulante> resultado);

		// Token: 0x06000ED1 RID: 3793
		protected abstract bool EstimulanteCargadoEsValido(T_Estimulante estimulante, int index);

		// Token: 0x06000ED2 RID: 3794
		protected abstract void OnEstimulanteDuplicado(T_Estimulante estimulante, int index);

		// Token: 0x06000ED3 RID: 3795
		protected abstract void OnEstimulanteIgnorado(T_Estimulante estimulante);

		// Token: 0x06000ED4 RID: 3796
		protected abstract void PoblarEstimuloDeEstimulante(T_Estimulante estimulante, T_InteracionEstimulanteBasica emptyEstimulo);

		// Token: 0x06000ED5 RID: 3797
		protected abstract void FinallyUpdated();

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0004520C File Offset: 0x0004340C
		protected sealed override void Clear()
		{
			if (!this.Clearing())
			{
				return;
			}
			this.m_listDeEstimulantes.Clear();
			this.m_estimulosDeEstimulante.Clear();
			for (int i = 0; i < this.m_listaDeEstimulos.Count; i++)
			{
				this.m_poolDeEstimulos.ReturnItem(this.m_listaDeEstimulos[i]);
			}
			this.m_listaDeEstimulos.Clear();
			this.Cleared();
		}

		// Token: 0x04000C96 RID: 3222
		private PoolDeInteraccionEstimulante<T_InteracionEstimulanteBasica> m_poolDeEstimulos;

		// Token: 0x04000C97 RID: 3223
		private float m_lastUpdateTime;

		// Token: 0x04000C98 RID: 3224
		private bool m_waitingUpdate;

		// Token: 0x04000C99 RID: 3225
		private HashSetList<T_Estimulante> m_IgnoringEstimulantes = new HashSetList<T_Estimulante>();

		// Token: 0x04000C9A RID: 3226
		private List<T_InteracionEstimulanteBasica> m_listaDeEstimulos = new List<T_InteracionEstimulanteBasica>();

		// Token: 0x04000C9B RID: 3227
		private Dictionary<T_Estimulante, T_InteracionEstimulanteBasica> m_estimulosDeEstimulante = new Dictionary<T_Estimulante, T_InteracionEstimulanteBasica>();

		// Token: 0x04000C9C RID: 3228
		private List<T_Estimulante> m_listDeEstimulantes = new List<T_Estimulante>();

		// Token: 0x04000C9D RID: 3229
		private List<T_Estimulante> m_tempEstimulantes = new List<T_Estimulante>();

		// Token: 0x04000C9E RID: 3230
		private HashSet<T_Estimulante> m_tempEstimulantesDublicadosChecker = new HashSet<T_Estimulante>();
	}
}
