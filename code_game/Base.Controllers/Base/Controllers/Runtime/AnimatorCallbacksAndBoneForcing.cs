using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;

namespace Assets.Base.Controllers.Runtime
{
	// Token: 0x02000005 RID: 5
	public class AnimatorCallbacksAndBoneForcing : AnimatorCallbacks
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000270B File Offset: 0x0000090B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_animController = this.GetComponentEnRoot(false);
			if (this.m_animController == null)
			{
				throw new ArgumentNullException("m_animController", "m_animController null reference.");
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000273E File Offset: 0x0000093E
		protected override void OnAnimatorIK(int layerIndex)
		{
			base.OnAnimatorIK(layerIndex);
		}

		// Token: 0x0400000C RID: 12
		private AnimController m_animController;
	}
}
