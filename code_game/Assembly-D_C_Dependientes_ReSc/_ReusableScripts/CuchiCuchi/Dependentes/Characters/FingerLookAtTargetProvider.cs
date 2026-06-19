using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200022D RID: 557
	public class FingerLookAtTargetProvider : CustomMonobehaviour, IFingerLookAtTargetProividor
	{
		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x00040DC8 File Offset: 0x0003EFC8
		public Transform lookAtTarget
		{
			get
			{
				if (this.m_HandControllerV2.tipoDePose == HandTipoDePose.None)
				{
					return null;
				}
				return this.m_HandControllerV2.currentPoseIndex;
			}
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x00040DE4 File Offset: 0x0003EFE4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_HandControllerV2 = this.GetComponentEnRoot(false);
			if (this.m_HandControllerV2 == null)
			{
				throw new ArgumentNullException("m_HandControllerV2", "m_HandControllerV2 null reference.");
			}
		}

		// Token: 0x040009FA RID: 2554
		private HandControllerV2 m_HandControllerV2;
	}
}
