using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Miscellaneous
{
	// Token: 0x02000164 RID: 356
	public class CopyCharacterAnimatorTransform : TrasnformCopier
	{
		// Token: 0x06000826 RID: 2086 RVA: 0x00025CF6 File Offset: 0x00023EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.m_Event1 = GlobalUpdater.UpdateType.lateUpdate1;
			this.m_useEvent2 = false;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00025D0C File Offset: 0x00023F0C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Animator componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			base.Init(base.transform, componentEnCharacter.transform);
		}
	}
}
