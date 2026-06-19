using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200047C RID: 1148
	public abstract class CalculoDeEstimuloPor<T_ICalculoDeEstimulo, TEstimulosCollection, TEstimulosCollectionItem, TConfig, TEstimuloEnFrameCollecor> : CalculoDeEstimuloEnFrame<TConfig, TEstimuloEnFrameCollecor>, ICalculadorDeEstimulo<T_ICalculoDeEstimulo>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimuloClasificable, ICalculadorDeEstimuloOnCalculoCallbacks<T_ICalculoDeEstimulo> where T_ICalculoDeEstimulo : class, IClearable, ICalculoDeEstimulo, new() where TEstimulosCollection : ICollection<TEstimulosCollectionItem> where TConfig : new() where TEstimuloEnFrameCollecor : MonoBehaviour
	{
		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06001954 RID: 6484 RVA: 0x00067372 File Offset: 0x00065572
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		T_ICalculoDeEstimulo ICalculadorDeEstimulo<T_ICalculoDeEstimulo>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06001955 RID: 6485 RVA: 0x0006737A File Offset: 0x0006557A
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06001956 RID: 6486 RVA: 0x00067387 File Offset: 0x00065587
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count > 0;
			}
		}

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06001957 RID: 6487 RVA: 0x00067397 File Offset: 0x00065597
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.m_dataGenerada.Count;
			}
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x000673A4 File Offset: 0x000655A4
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.GetCalculoEnFrame(index);
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06001959 RID: 6489 RVA: 0x000673B2 File Offset: 0x000655B2
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count;
			}
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x000673BF File Offset: 0x000655BF
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x000673CD File Offset: 0x000655CD
		public T_ICalculoDeEstimulo GetCalculoEnFrame(int index)
		{
			return this.m_dataGenerada[index];
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x000673DB File Offset: 0x000655DB
		public T_ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[index];
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x000673E9 File Offset: 0x000655E9
		public bool TryInstantiateCalculo(out T_ICalculoDeEstimulo calculo)
		{
			calculo = new T_ICalculoDeEstimulo();
			return true;
		}

		// Token: 0x0600195E RID: 6494 RVA: 0x000673F8 File Offset: 0x000655F8
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			T_ICalculoDeEstimulo t_ICalculoDeEstimulo;
			bool flag = this.TryInstantiateCalculo(out t_ICalculoDeEstimulo);
			calculo = t_ICalculoDeEstimulo;
			return flag;
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x0600195F RID: 6495 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06001960 RID: 6496
		public abstract DireccionDeEstimulo direccionDeEstimulo { get; }

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06001961 RID: 6497 RVA: 0x00004252 File Offset: 0x00002452
		public virtual bool esGolpe
		{
			get
			{
				return false;
			}
		}

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x06001962 RID: 6498 RVA: 0x00067418 File Offset: 0x00065618
		// (remove) Token: 0x06001963 RID: 6499 RVA: 0x00067450 File Offset: 0x00065650
		public event CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo> preCalculadoDeEstimulo;

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x06001964 RID: 6500 RVA: 0x00067488 File Offset: 0x00065688
		// (remove) Token: 0x06001965 RID: 6501 RVA: 0x000674C0 File Offset: 0x000656C0
		public event CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo> postCalculadoDeEstimulo;

		// Token: 0x06001966 RID: 6502 RVA: 0x000674F8 File Offset: 0x000656F8
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<T_ICalculoDeEstimulo> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06001967 RID: 6503 RVA: 0x0006752D File Offset: 0x0006572D
		protected virtual bool removerDataSiEstaNoTieneEstimulo { get; }

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06001968 RID: 6504 RVA: 0x00067372 File Offset: 0x00065572
		[Obsolete("", true)]
		public T_ICalculoDeEstimulo masFuerteGenerada
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06001969 RID: 6505 RVA: 0x00067535 File Offset: 0x00065735
		public List<T_ICalculoDeEstimulo> dataGenerada
		{
			get
			{
				return this.m_dataGenerada;
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x0600196A RID: 6506 RVA: 0x0006753D File Offset: 0x0006573D
		public List<T_ICalculoDeEstimulo> dataGeneradaConEstimuloMasFuerteAlMasDebil
		{
			get
			{
				return this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil;
			}
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00067545 File Offset: 0x00065745
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_pool.itemCreated += this.M_pool_itemCreated;
			this.m_pool.itemReturning += this.M_pool_itemReturning;
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x0006757B File Offset: 0x0006577B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_pool.itemCreated -= this.M_pool_itemCreated;
			this.m_pool.itemReturning -= this.M_pool_itemReturning;
			this.ClearOldData();
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x000675B8 File Offset: 0x000657B8
		protected sealed override void Updating(float deltaTime)
		{
			this.ClearOldData();
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x000675C0 File Offset: 0x000657C0
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			TEstimulosCollection estimulosEnFrame = this.GetEstimulosEnFrame(this.m_EstimuloByMainInFrame);
			if (estimulosEnFrame.Count == 0)
			{
				return;
			}
			if (!this.generar)
			{
				return;
			}
			this.GenerarDataLoop(estimulosEnFrame, deltaTime, ref cambiarValorDeEmocionDespuesDeTiempoMod);
			this.Calcular(out generadoNoLimitado, out generadoLimitado);
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x00067605 File Offset: 0x00065805
		private void M_pool_itemReturning(SimplePool<T_ICalculoDeEstimulo> arg1, T_ICalculoDeEstimulo arg2)
		{
			this.OnPoolReturningItem(this.m_pool, arg2);
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00067614 File Offset: 0x00065814
		private void M_pool_itemCreated(SimplePool<T_ICalculoDeEstimulo> arg1, T_ICalculoDeEstimulo arg2)
		{
			this.OnPoolCreatedItem(this.m_pool, arg2);
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnPoolCreatedItem(SimplePoolDeClearables<T_ICalculoDeEstimulo> pool, T_ICalculoDeEstimulo itemCreated)
		{
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnPoolReturningItem(SimplePoolDeClearables<T_ICalculoDeEstimulo> pool, T_ICalculoDeEstimulo itemReturning)
		{
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x00067624 File Offset: 0x00065824
		private void Calcular(out float generadoNoLimitado, out float generadoLimitado)
		{
			generadoLimitado = (generadoNoLimitado = 0f);
			float total = this.m_Emo.value.total;
			for (int i = this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count - 1; i >= 0; i--)
			{
				T_ICalculoDeEstimulo t_ICalculoDeEstimulo = this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i];
				float num = this.PostCalculoDeEstimulo(t_ICalculoDeEstimulo);
				if (num < 0f)
				{
					Debug.LogWarning("calculo de data es menor a zero, esto no es apropiado.");
					num = 0f;
				}
				CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo> calculadorOnCalculadoCallbacksHandler = this.postCalculadoDeEstimulo;
				if (calculadorOnCalculadoCallbacksHandler != null)
				{
					calculadorOnCalculadoCallbacksHandler(t_ICalculoDeEstimulo, num, this);
				}
				float num2;
				bool flag = this.MaximoAlcanzado(t_ICalculoDeEstimulo, total, out num2);
				generadoNoLimitado += num;
				float num3;
				this.AplicarMaxValueEmoMods(t_ICalculoDeEstimulo, flag, total, num2, out num3);
				generadoLimitado += num * num3;
				if (num <= 0f && this.removerDataSiEstaNoTieneEstimulo)
				{
					this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.RemoveAt(i);
				}
				else if (flag && this.removerDataSiEstaLlegoAlMaximo)
				{
					this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.RemoveAt(i);
				}
			}
			this.SortMasFuerteAlMasDebil(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil);
		}

		// Token: 0x06001974 RID: 6516
		protected abstract void AplicarMaxValueEmoMods(T_ICalculoDeEstimulo data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange);

		// Token: 0x06001975 RID: 6517 RVA: 0x00067728 File Offset: 0x00065928
		private void GenerarDataLoop(TEstimulosCollection estimulosCollection, float deltaTime, ref float cambiarValorDeEmocionDespuesDeTiempoMod)
		{
			try
			{
				int num = 0;
				foreach (TEstimulosCollectionItem testimulosCollectionItem in estimulosCollection)
				{
					try
					{
						if (this.ItemEsValido(testimulosCollectionItem, num))
						{
							T_ICalculoDeEstimulo item = this.m_pool.GetItem();
							this.PoblarDataConItem(item, testimulosCollectionItem, num, deltaTime, estimulosCollection);
							this.PostPoblarDataConItem(item, estimulosCollection);
							if (!this.DataGeneradaEsValida(item, num))
							{
								this.m_pool.ReturnItem(item);
							}
							else
							{
								this.OnDataGenerada(item);
								this.m_dataGenerada.Add(item);
								float num2 = this.PreCalculoDeEstimulo(item);
								CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo> calculadorOnCalculadoCallbacksHandler = this.preCalculadoDeEstimulo;
								if (calculadorOnCalculadoCallbacksHandler != null)
								{
									calculadorOnCalculadoCallbacksHandler(item, num2, this);
								}
								if (item.producidoPor == null)
								{
									throw new InvalidOperationException();
								}
								if (num2 > 0f)
								{
									this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Add(item);
									this.OnDataAdded(item);
								}
								else if (this.removerDataSiEstaNoTieneEstimulo)
								{
									this.m_dataGenerada.RemoveAt(this.m_dataGenerada.Count - 1);
									this.m_pool.ReturnItem(item);
								}
								cambiarValorDeEmocionDespuesDeTiempoMod *= this.ModParaCambiarValorDeEmocionDespuesDeTiempo(item);
							}
						}
					}
					finally
					{
						num++;
					}
				}
			}
			finally
			{
				this.SortMasFuerteAlMasDebil(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil);
			}
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnDataAdded(T_ICalculoDeEstimulo data)
		{
		}

		// Token: 0x06001977 RID: 6519
		protected abstract void SortMasFuerteAlMasDebil(List<T_ICalculoDeEstimulo> calculos);

		// Token: 0x06001978 RID: 6520 RVA: 0x000678AC File Offset: 0x00065AAC
		protected void ClearOldData()
		{
			for (int i = 0; i < this.m_dataGenerada.Count; i++)
			{
				this.m_pool.ReturnItem(this.m_dataGenerada[i]);
			}
			if (this.m_dataGenerada.Count > 0)
			{
				this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Clear();
				this.m_dataGenerada.Clear();
			}
			this.OnOldDataCleared();
		}

		// Token: 0x06001979 RID: 6521
		protected abstract TEstimulosCollection GetEstimulosEnFrame(TEstimuloEnFrameCollecor collecor);

		// Token: 0x0600197A RID: 6522
		protected abstract void OnOldDataCleared();

		// Token: 0x0600197B RID: 6523
		protected abstract bool ItemEsValido(TEstimulosCollectionItem item, int index);

		// Token: 0x0600197C RID: 6524
		protected abstract void PoblarDataConItem(T_ICalculoDeEstimulo data, TEstimulosCollectionItem item, int index, float deltaTime, TEstimulosCollection allItems);

		// Token: 0x0600197D RID: 6525
		protected abstract void PostPoblarDataConItem(T_ICalculoDeEstimulo data, TEstimulosCollection allData);

		// Token: 0x0600197E RID: 6526
		protected abstract bool DataGeneradaEsValida(T_ICalculoDeEstimulo data, int index);

		// Token: 0x0600197F RID: 6527
		protected abstract float PreCalculoDeEstimulo(T_ICalculoDeEstimulo data);

		// Token: 0x06001980 RID: 6528 RVA: 0x00030684 File Offset: 0x0002E884
		protected virtual float ModParaCambiarValorDeEmocionDespuesDeTiempo(T_ICalculoDeEstimulo data)
		{
			return 1f;
		}

		// Token: 0x06001981 RID: 6529
		protected abstract bool MaximoAlcanzado(T_ICalculoDeEstimulo data, float valorDeEmovionActual, out float maxEmoValueDeGrupo);

		// Token: 0x06001982 RID: 6530
		protected abstract float PostCalculoDeEstimulo(T_ICalculoDeEstimulo data);

		// Token: 0x06001983 RID: 6531
		protected abstract void OnDataGenerada(T_ICalculoDeEstimulo data);

		// Token: 0x06001985 RID: 6533 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400131E RID: 4894
		public bool generar = true;

		// Token: 0x04001320 RID: 4896
		[SerializeField]
		[ReadOnlyUI]
		protected bool removerDataSiEstaLlegoAlMaximo;

		// Token: 0x04001321 RID: 4897
		private SimplePoolDeClearables<T_ICalculoDeEstimulo> m_pool = new SimplePoolDeClearables<T_ICalculoDeEstimulo>();

		// Token: 0x04001322 RID: 4898
		[Obsolete("", true)]
		protected T_ICalculoDeEstimulo m_masFuerteGenerada;

		// Token: 0x04001323 RID: 4899
		[SerializeField]
		protected List<T_ICalculoDeEstimulo> m_dataGenerada = new List<T_ICalculoDeEstimulo>();

		// Token: 0x04001324 RID: 4900
		[SerializeField]
		protected List<T_ICalculoDeEstimulo> m_dataGeneradaConEstimuloMasFuerteAlMasDebil = new List<T_ICalculoDeEstimulo>();
	}
}
