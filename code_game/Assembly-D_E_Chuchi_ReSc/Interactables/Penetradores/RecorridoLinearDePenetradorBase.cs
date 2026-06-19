using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables.Penetradores
{
	// Token: 0x02000181 RID: 385
	[RequireComponent(typeof(InteraccionRootRecorridoLinear))]
	public abstract class RecorridoLinearDePenetradorBase : CustomMonobehaviour
	{
		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x00029069 File Offset: 0x00027269
		public InteraccionRootRecorridoLinear recorrido
		{
			get
			{
				return this.m_PuntosGuiasRecorridoLinear;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600091B RID: 2331
		public abstract Penetrador penetrador { get; }

		// Token: 0x0600091C RID: 2332 RVA: 0x00029071 File Offset: 0x00027271
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuntosGuiasRecorridoLinear = base.GetComponent<InteraccionRootRecorridoLinear>();
		}

		// Token: 0x04000710 RID: 1808
		protected InteraccionRootRecorridoLinear m_PuntosGuiasRecorridoLinear;
	}
}
