using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003F4 RID: 1012
	public class VisionDesdeMainInFrame : EstimuloInFrame
	{
		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06001623 RID: 5667 RVA: 0x0005C731 File Offset: 0x0005A931
		public DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> frameVistas
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06001624 RID: 5668 RVA: 0x0005C739 File Offset: 0x0005A939
		public IReadOnlyList<EstimuloVisual> frameVistasList
		{
			get
			{
				return this.m_estimulosEnframes;
			}
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x0005C744 File Offset: 0x0005A944
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_visionInformer = this.m_character.GetComponentInChildren<ICharVisionInformer>();
			if (this.m_visionInformer == null)
			{
				throw new ArgumentNullException("m_visionInformer", "m_visionInformer null reference.");
			}
			this.m_result = new DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual>((ParteQuePuedeEstimular e) => (int)e);
			this.instanciasGetter = new Func<EstimuloVisual>(this.m_pool.GetItem);
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x0005C7C4 File Offset: 0x0005A9C4
		protected override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			if (this.m_result.Count > 0)
			{
				for (int i = 0; i < this.m_estimulosEnframes.Count; i++)
				{
					this.m_pool.ReturnItem(this.m_estimulosEnframes[i]);
				}
				this.m_result.Clear();
				this.m_estimulosEnframes.Clear();
			}
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			this.m_visionInformer.EstimulosRecibidosPor(current, this.instanciasGetter, this.m_result, this.m_estimulosEnframes);
		}

		// Token: 0x04001197 RID: 4503
		private ICharVisionInformer m_visionInformer;

		// Token: 0x04001198 RID: 4504
		[ReadOnlyUI]
		[SerializeField]
		private List<EstimuloVisual> m_estimulosEnframes = new List<EstimuloVisual>();

		// Token: 0x04001199 RID: 4505
		private DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> m_result;

		// Token: 0x0400119A RID: 4506
		private Func<EstimuloVisual> instanciasGetter;

		// Token: 0x0400119B RID: 4507
		private PoolDeInteraccionEstimulante<EstimuloVisual> m_pool = new PoolDeInteraccionEstimulante<EstimuloVisual>();
	}
}
