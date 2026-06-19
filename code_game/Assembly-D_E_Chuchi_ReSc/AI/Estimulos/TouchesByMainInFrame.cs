using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Estimulos;
using Assets.TValle.BeachGirl.Estimulos.Informers;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003F3 RID: 1011
	public class TouchesByMainInFrame : EstimuloInFrame, ICharTouchInformerV2User, IInformerDeEstimulosUser
	{
		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x0600161D RID: 5661 RVA: 0x0005C51B File Offset: 0x0005A71B
		public DictionaryDeEstimulosTactiles frameTouchesConPrioridad
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x0005C523 File Offset: 0x0005A723
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_charTouchInformer = this.m_character.GetComponentInChildren<ICharTouchInformerV2>();
			if (this.m_charTouchInformer == null)
			{
				throw new ArgumentNullException("m_charTouchInformer", "m_charTouchInformer null reference.");
			}
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x0005C554 File Offset: 0x0005A754
		protected sealed override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			if (this.m_result.Count > 0)
			{
				foreach (KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePair in this.m_result)
				{
					this.RetornarInstancia<EstimuloTactil>(keyValuePair.Value.Item1);
					if (keyValuePair.Value.Item2.Item1 != null)
					{
						this.RetornarInstancia<EstimuloTactil>(keyValuePair.Value.Item2.Item1);
					}
				}
				this.m_result.Clear();
			}
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			this.m_charTouchInformer.EstimulosProducidosPor(current, this, this.m_result);
			IReadOnlyList<ICharacter> slavesDe = Singleton<CharacteresActivos>.instance.GetSlavesDe(current);
			if (slavesDe != null)
			{
				for (int i = 0; i < slavesDe.Count; i++)
				{
					this.m_charTouchInformer.EstimulosProducidosPor(slavesDe[i], this, this.m_result);
				}
			}
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x0005C650 File Offset: 0x0005A850
		public void RetornarInstancia<T>(T isntance) where T : InteracionEstimulanteBasica
		{
			EstimuloTactil estimuloTactil = isntance as EstimuloTactil;
			EstimuloTactilDeSemen estimuloTactilDeSemen = isntance as EstimuloTactilDeSemen;
			if (estimuloTactilDeSemen != null)
			{
				this.m_poolSemen.ReturnItem(estimuloTactilDeSemen);
				return;
			}
			this.m_pool.ReturnItem(estimuloTactil);
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x0005C694 File Offset: 0x0005A894
		public T ProducirInstancia<T>() where T : InteracionEstimulanteBasica
		{
			if (typeof(T) == typeof(EstimuloTactil))
			{
				return this.m_pool.GetItem() as T;
			}
			if (typeof(T) == typeof(EstimuloTactilDeSemen))
			{
				return this.m_poolSemen.GetItem() as T;
			}
			throw new NotSupportedException();
		}

		// Token: 0x04001193 RID: 4499
		private ICharTouchInformerV2 m_charTouchInformer;

		// Token: 0x04001194 RID: 4500
		private DictionaryDeEstimulosTactiles m_result = new DictionaryDeEstimulosTactiles();

		// Token: 0x04001195 RID: 4501
		private PoolDeInteraccionEstimulante<EstimuloTactil> m_pool = new PoolDeInteraccionEstimulante<EstimuloTactil>();

		// Token: 0x04001196 RID: 4502
		private PoolDeInteraccionEstimulante<EstimuloTactilDeSemen> m_poolSemen = new PoolDeInteraccionEstimulante<EstimuloTactilDeSemen>();
	}
}
