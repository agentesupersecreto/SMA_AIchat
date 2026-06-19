using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.UserControllers
{
	// Token: 0x020001B2 RID: 434
	[RequireComponent(typeof(PelvisMovementLimitSegunHoleFondo))]
	[RequireComponent(typeof(PelvisMovementMouseUserController))]
	public sealed class PelvisMovementMouseUserFixPositionOnPenetration : CustomMonobehaviour
	{
		// Token: 0x06000A68 RID: 2664 RVA: 0x00033F34 File Offset: 0x00032134
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PelvisMovementMouseUserController = base.GetComponent<PelvisMovementMouseUserController>();
			this.m_PelvisMovementLimitSegunHoleFondo = base.GetComponent<PelvisMovementLimitSegunHoleFondo>();
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00033F54 File Offset: 0x00032154
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_PelvisMovementMouseUserController.userWorldPositionCalculed += this.M_PelvisMovementMouseUserController_userWorldPositionCalculed;
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00033F73 File Offset: 0x00032173
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PelvisMovementMouseUserController)
			{
				this.m_PelvisMovementMouseUserController.userWorldPositionCalculed -= this.M_PelvisMovementMouseUserController_userWorldPositionCalculed;
			}
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x00033FA0 File Offset: 0x000321A0
		private void M_PelvisMovementMouseUserController_userWorldPositionCalculed(ref Vector3 userWorldPositiob, PelvisMovementMouseUserController sender)
		{
			if (!this.m_PelvisMovementLimitSegunHoleFondo.peneAdentro)
			{
				return;
			}
			userWorldPositiob = Math3d.ProjectPointOnConeSurfaceOrInside(this.m_PelvisMovementLimitSegunHoleFondo.hole.worldOutHoleDirection, this.m_PelvisMovementLimitSegunHoleFondo.hole.entrada.position, this.m_PelvisMovementLimitSegunHoleFondo.configPelvis.maxAngleConeDificulty, userWorldPositiob, this.debugDraw, float.PositiveInfinity);
		}

		// Token: 0x040007DC RID: 2012
		private PelvisMovementMouseUserController m_PelvisMovementMouseUserController;

		// Token: 0x040007DD RID: 2013
		private PelvisMovementLimitSegunHoleFondo m_PelvisMovementLimitSegunHoleFondo;

		// Token: 0x040007DE RID: 2014
		public bool debugDraw;
	}
}
