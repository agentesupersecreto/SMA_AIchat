using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x0200029F RID: 671
	public abstract class EstimuledBy
	{
		// Token: 0x06000ED7 RID: 3799 RVA: 0x00045278 File Offset: 0x00043478
		protected EstimuledBy(MonoBehaviour estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
		{
			if (estimulado == null)
			{
				throw new ArgumentNullException("estimulado", "estimulado null reference.");
			}
			if (PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("PrioridadesDeObjetoEstimulado", "PrioridadesDeObjetoEstimulado null reference.");
			}
			this.m_objetoEstimulado = estimulado;
			this.m_prioridadesDeObjetoEstimulado = PrioridadesDeObjetoEstimulado;
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x000452C5 File Offset: 0x000434C5
		public MonoBehaviour objetoEstimulado
		{
			get
			{
				return this.m_objetoEstimulado;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x000452CD File Offset: 0x000434CD
		public IParteDelCuerpoHumanoPrioridades prioridadesDeObjetoEstimulado
		{
			get
			{
				return this.m_prioridadesDeObjetoEstimulado;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000EDA RID: 3802
		public abstract int cantidadDeEstimulantes { get; }

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000EDB RID: 3803
		protected abstract IList objetosEstimulantes { get; }

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000EDC RID: 3804
		protected abstract IList objetosEstimulos { get; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000EDD RID: 3805
		protected abstract IDictionary estimulosDeObjetosEstimulante { get; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000EDE RID: 3806
		protected abstract bool soloUnCalculoPorFrame { get; }

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000EDF RID: 3807
		protected abstract bool clearBeforeUpdating { get; }

		// Token: 0x06000EE0 RID: 3808
		protected abstract object ObtenerEstimulante(int index);

		// Token: 0x06000EE1 RID: 3809 RVA: 0x000452D5 File Offset: 0x000434D5
		[Obsolete]
		public void UpdateIf()
		{
			Debug.Log("OBSOLETO");
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06000EE2 RID: 3810 RVA: 0x000452E4 File Offset: 0x000434E4
		// (remove) Token: 0x06000EE3 RID: 3811 RVA: 0x0004531C File Offset: 0x0004351C
		public event Action<EstimuledBy> updating;

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06000EE4 RID: 3812 RVA: 0x00045354 File Offset: 0x00043554
		// (remove) Token: 0x06000EE5 RID: 3813 RVA: 0x0004538C File Offset: 0x0004358C
		public event Action<EstimuledBy> updated;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000EE6 RID: 3814 RVA: 0x000453C4 File Offset: 0x000435C4
		// (remove) Token: 0x06000EE7 RID: 3815 RVA: 0x000453FC File Offset: 0x000435FC
		public event Action<EstimuledBy> finallyUpdated;

		// Token: 0x06000EE8 RID: 3816 RVA: 0x00045431 File Offset: 0x00043631
		public void Update_()
		{
			this.OnUpdate();
		}

		// Token: 0x06000EE9 RID: 3817
		protected abstract void OnUpdate();

		// Token: 0x06000EEA RID: 3818 RVA: 0x00045439 File Offset: 0x00043639
		protected virtual bool OnUpdating()
		{
			Action<EstimuledBy> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			return true;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0004544E File Offset: 0x0004364E
		protected void OnFinallyUpdatedEvent()
		{
			Action<EstimuledBy> action = this.finallyUpdated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00045461 File Offset: 0x00043661
		protected virtual void OnUpdated()
		{
			Action<EstimuledBy> action = this.updated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000EED RID: 3821
		protected abstract bool Clearing();

		// Token: 0x06000EEE RID: 3822
		protected abstract void Cleared();

		// Token: 0x06000EEF RID: 3823
		protected abstract void Clear();

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00045474 File Offset: 0x00043674
		protected T_estimulo GetEstimuloDeObjetoEstimulante<T_estimulo>(object estimulante) where T_estimulo : InteracionEstimulanteBasica
		{
			if (this.estimulosDeObjetosEstimulante.Contains(estimulante))
			{
				return (T_estimulo)((object)this.estimulosDeObjetosEstimulante[estimulante]);
			}
			return default(T_estimulo);
		}

		// Token: 0x06000EF1 RID: 3825
		protected abstract object ParceEstimulante(object estimulante);

		// Token: 0x06000EF2 RID: 3826 RVA: 0x000454AA File Offset: 0x000436AA
		public bool ContieneEstimulosV3<T_estimulo>(ICharacter estimulante, List<T_estimulo> estimulosResultado) where T_estimulo : InteracionEstimulanteBasica
		{
			return (estimulante == null || estimulante.loaded) && this.ContieneEstimulosV3<T_estimulo>(estimulante, estimulosResultado);
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x000454C4 File Offset: 0x000436C4
		public bool ContieneEstimulosV3<T_estimulo>(IPertenecibleDeCharacter estimulante, List<T_estimulo> estimulosResultado) where T_estimulo : InteracionEstimulanteBasica
		{
			ICharacter character = ((estimulante != null) ? estimulante.GetRootOwner() : null);
			return (character == null || character.loaded) && this.ContieneEstimulosV3<T_estimulo>(estimulante, estimulosResultado);
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x000454F4 File Offset: 0x000436F4
		public bool ContieneEstimulosV3<T_estimulo>(object estimulante, List<T_estimulo> estimulosResultado) where T_estimulo : InteracionEstimulanteBasica
		{
			estimulante = this.ParceEstimulante(estimulante);
			if (this.estimulosDeObjetosEstimulante.Contains(estimulante))
			{
				T_estimulo t_estimulo = (T_estimulo)((object)this.estimulosDeObjetosEstimulante[estimulante]);
				if (t_estimulo != null)
				{
					estimulosResultado.Add(t_estimulo);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x0004553C File Offset: 0x0004373C
		public bool ContieneEstimuloV3<T_estimulo>(IPertenecibleDeCharacter estimulante, out T_estimulo estimulo) where T_estimulo : InteracionEstimulanteBasica
		{
			ICharacter character = ((estimulante != null) ? estimulante.GetRootOwner() : null);
			if (character != null && !character.loaded)
			{
				estimulo = default(T_estimulo);
				return false;
			}
			return this.ContieneEstimuloV3<T_estimulo>(estimulante, out estimulo);
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00045572 File Offset: 0x00043772
		public bool ContieneEstimuloV3<T_estimulo>(ICharacter estimulante, out T_estimulo estimulo) where T_estimulo : InteracionEstimulanteBasica
		{
			if (estimulante != null && !estimulante.loaded)
			{
				estimulo = default(T_estimulo);
				return false;
			}
			return this.ContieneEstimuloV3<T_estimulo>(estimulante, out estimulo);
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x00045590 File Offset: 0x00043790
		public bool ContieneEstimuloV3<T_estimulo>(object estimulante, out T_estimulo estimulo) where T_estimulo : InteracionEstimulanteBasica
		{
			estimulante = this.ParceEstimulante(estimulante);
			if (estimulante == null)
			{
				estimulo = default(T_estimulo);
				return false;
			}
			if (this.estimulosDeObjetosEstimulante.Contains(estimulante))
			{
				estimulo = (T_estimulo)((object)this.estimulosDeObjetosEstimulante[estimulante]);
				return true;
			}
			estimulo = default(T_estimulo);
			return false;
		}

		// Token: 0x04000C9F RID: 3231
		protected IParteDelCuerpoHumanoPrioridades m_prioridadesDeObjetoEstimulado;

		// Token: 0x04000CA0 RID: 3232
		private MonoBehaviour m_objetoEstimulado;

		// Token: 0x04000CA1 RID: 3233
		protected ForcedUpdateId m_id;
	}
}
