using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones
{
	// Token: 0x020001E7 RID: 487
	public class CambiosDePoseByMainInFrame : EstimuloInFrame
	{
		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x0003871C File Offset: 0x0003691C
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> enFrame
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x00038724 File Offset: 0x00036924
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> enFramePeticiones
		{
			get
			{
				return this.m_resultPeticiones;
			}
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0003872C File Offset: 0x0003692C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ICharInformer = this.m_character.GetComponentInChildren<ICharCambioDePoseInformer>();
			if (this.m_ICharInformer == null)
			{
				throw new ArgumentNullException("m_ICharInformer", "m_ICharInformer null reference.");
			}
			this.m_ICharPeticionInformer = this.m_character.GetComponentInChildren<ICharPeticionDeCambioDePoseInformer>();
			if (this.m_ICharPeticionInformer == null)
			{
				throw new ArgumentNullException("m_ICharPeticionInformer", "m_ICharPeticionInformer null reference.");
			}
			this.m_result = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose>((ParteQuePuedeEstimular e) => (int)e);
			this.m_resultPeticiones = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose>((ParteQuePuedeEstimular e) => (int)e);
			this.instanciasGetter = new ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose>(this.m_pool.GetItem);
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x00038800 File Offset: 0x00036A00
		protected override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			if (this.m_result.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloPorCambiarPose> keyValuePair in this.m_result)
				{
					this.m_pool.ReturnItem(keyValuePair.Value);
				}
				this.m_result.Clear();
			}
			if (this.m_resultPeticiones.Count > 0)
			{
				foreach (KeyValuePair<int, EstimuloPorCambiarPose> keyValuePair2 in this.m_resultPeticiones)
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

		// Token: 0x04000891 RID: 2193
		private ICharCambioDePoseInformer m_ICharInformer;

		// Token: 0x04000892 RID: 2194
		private ICharPeticionDeCambioDePoseInformer m_ICharPeticionInformer;

		// Token: 0x04000893 RID: 2195
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> m_result;

		// Token: 0x04000894 RID: 2196
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> m_resultPeticiones;

		// Token: 0x04000895 RID: 2197
		private ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose> instanciasGetter;

		// Token: 0x04000896 RID: 2198
		private PoolDeInteraccionEstimulante<EstimuloPorCambiarPose> m_pool = new PoolDeInteraccionEstimulante<EstimuloPorCambiarPose>();
	}
}
