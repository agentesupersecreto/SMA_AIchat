using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones
{
	// Token: 0x020001E9 RID: 489
	public class MovimientosDeBonesByMainInFrame : EstimuloInFrame
	{
		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00038933 File Offset: 0x00036B33
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> enFrame
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x0003893B File Offset: 0x00036B3B
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> enFramePeticiones
		{
			get
			{
				return this.m_resultPeticiones;
			}
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x00038944 File Offset: 0x00036B44
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ICharInformer = this.m_character.GetComponentInChildren<ICharManipulacionDeBonesInformer>();
			if (this.m_ICharInformer == null)
			{
				throw new ArgumentNullException("m_ICharInformer", "m_ICharInformer null reference.");
			}
			this.m_ICharPeticionInformer = this.m_character.GetComponentInChildren<ICharGuiadoDeBonesInformer>();
			if (this.m_ICharPeticionInformer == null)
			{
				throw new ArgumentNullException("m_ICharPeticionInformer", "m_ICharPeticionInformer null reference.");
			}
			this.m_result = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone>((ParteQuePuedeEstimular e) => (int)e);
			this.m_resultPeticiones = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone>((ParteQuePuedeEstimular e) => (int)e);
			this.instanciasGetter = new ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone>(this.m_pool.GetItem);
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x00038A18 File Offset: 0x00036C18
		protected override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			if (this.m_result.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloPorManipulacionDeBone> keyValuePair in this.m_result)
				{
					this.m_pool.ReturnItem(keyValuePair.Value);
				}
				this.m_result.Clear();
			}
			if (this.m_resultPeticiones.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloPorManipulacionDeBone> keyValuePair2 in this.m_resultPeticiones)
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
			this.m_ICharInformer.EstimulosRecibidosDe(current, this.instanciasGetter, this.m_result);
			this.m_ICharPeticionInformer.EstimulosRecibidosDe(current, this.instanciasGetter, this.m_resultPeticiones);
		}

		// Token: 0x0400089A RID: 2202
		private ICharManipulacionDeBonesInformer m_ICharInformer;

		// Token: 0x0400089B RID: 2203
		private ICharGuiadoDeBonesInformer m_ICharPeticionInformer;

		// Token: 0x0400089C RID: 2204
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> m_result;

		// Token: 0x0400089D RID: 2205
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> m_resultPeticiones;

		// Token: 0x0400089E RID: 2206
		private ICharMovimientoDeBonesInformerInstanceGetter<EstimuloPorManipulacionDeBone> instanciasGetter;

		// Token: 0x0400089F RID: 2207
		private PoolDeInteraccionEstimulante<EstimuloPorManipulacionDeBone> m_pool = new PoolDeInteraccionEstimulante<EstimuloPorManipulacionDeBone>();
	}
}
