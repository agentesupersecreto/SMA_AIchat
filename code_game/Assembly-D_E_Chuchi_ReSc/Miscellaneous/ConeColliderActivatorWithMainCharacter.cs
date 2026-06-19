using System;
using Assets._ReusableScripts.Activables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Miscellaneous
{
	// Token: 0x02000163 RID: 355
	public class ConeColliderActivatorWithMainCharacter : ConeActivator
	{
		// Token: 0x06000822 RID: 2082 RVA: 0x00025C80 File Offset: 0x00023E80
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_own = this.GetComponentEnRoot(false);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x00025C95 File Offset: 0x00023E95
		protected override float GetRadiusMod()
		{
			if (this.m_own == null)
			{
				return 1f;
			}
			return this.m_own.escala;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00025CB8 File Offset: 0x00023EB8
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

		// Token: 0x04000668 RID: 1640
		private Character m_own;
	}
}
