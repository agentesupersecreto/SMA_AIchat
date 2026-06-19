using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos
{
	// Token: 0x0200038B RID: 907
	public class DesvestidurasByMainInFrame : EstimuloInFrame
	{
		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060013D0 RID: 5072 RVA: 0x00056218 File Offset: 0x00054418
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> frameDesvestirudas
		{
			get
			{
				return this.m_resultDesvestiduras;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x00056220 File Offset: 0x00054420
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> framePeticionesDeDesvestirudas
		{
			get
			{
				return this.m_resultPeticiones;
			}
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x00056228 File Offset: 0x00054428
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ICharDesvestiduraInformer = this.m_character.GetComponentInChildren<ICharDesvestiduraInformer>();
			if (this.m_ICharDesvestiduraInformer == null)
			{
				throw new ArgumentNullException("m_ICharDesvestiduraInformer", "m_ICharDesvestiduraInformer null reference.");
			}
			this.m_ICharPeticionDesvestiduraInformer = this.m_character.GetComponentInChildren<ICharPeticionDesvestiduraInformer>();
			if (this.m_ICharPeticionDesvestiduraInformer == null)
			{
				throw new ArgumentNullException("m_ICharPeticionDesvestiduraInformer", "m_ICharPeticionDesvestiduraInformer null reference.");
			}
			this.m_resultDesvestiduras = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir>((ParteQuePuedeEstimular e) => (int)e);
			this.m_resultPeticiones = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir>((ParteQuePuedeEstimular e) => (int)e);
			this.instanciasGetter = new ICharDesvestiduraInformerInstanceGetter<EstimuloPorDesvestir>(this.m_pool.GetItem);
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x000562FC File Offset: 0x000544FC
		protected override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			if (this.m_resultDesvestiduras.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloPorDesvestir> keyValuePair in this.m_resultDesvestiduras)
				{
					this.m_pool.ReturnItem(keyValuePair.Value);
				}
				this.m_resultDesvestiduras.Clear();
			}
			if (this.m_resultPeticiones.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloPorDesvestir> keyValuePair2 in this.m_resultPeticiones)
				{
					this.m_pool.ReturnItem(keyValuePair2.Value);
				}
				this.m_resultPeticiones.Clear();
			}
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			this.m_ICharDesvestiduraInformer.EstimulosRecibidosDe(current, this.instanciasGetter, this.m_resultDesvestiduras);
			this.m_ICharPeticionDesvestiduraInformer.EstimulosRecibidosDe(current, this.instanciasGetter, this.m_resultPeticiones);
		}

		// Token: 0x04001076 RID: 4214
		private ICharDesvestiduraInformer m_ICharDesvestiduraInformer;

		// Token: 0x04001077 RID: 4215
		private ICharPeticionDesvestiduraInformer m_ICharPeticionDesvestiduraInformer;

		// Token: 0x04001078 RID: 4216
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> m_resultDesvestiduras;

		// Token: 0x04001079 RID: 4217
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> m_resultPeticiones;

		// Token: 0x0400107A RID: 4218
		private ICharDesvestiduraInformerInstanceGetter<EstimuloPorDesvestir> instanciasGetter;

		// Token: 0x0400107B RID: 4219
		private PoolDeInteraccionEstimulante<EstimuloPorDesvestir> m_pool = new PoolDeInteraccionEstimulante<EstimuloPorDesvestir>();
	}
}
