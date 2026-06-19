using System;
using Assets._ReusableScripts.Activables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Miscellaneous
{
	// Token: 0x02000166 RID: 358
	public class RadiusActivatorWithMainCharacter : RadiusActivator
	{
		// Token: 0x0600082D RID: 2093 RVA: 0x00025DAB File Offset: 0x00023FAB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_own = this.GetComponentEnRoot(false);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00025DC0 File Offset: 0x00023FC0
		protected override float GetRadiusMod()
		{
			if (this.m_own == null)
			{
				return 1f;
			}
			return this.m_own.escala;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00025DE4 File Offset: 0x00023FE4
		protected override Transform GetTarget()
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return null;
			}
			Transform transform = current.cameraAtadaTransform;
			if (transform == null)
			{
				transform = current.trasnformParaObservar;
			}
			return transform;
		}

		// Token: 0x04000669 RID: 1641
		private Character m_own;
	}
}
