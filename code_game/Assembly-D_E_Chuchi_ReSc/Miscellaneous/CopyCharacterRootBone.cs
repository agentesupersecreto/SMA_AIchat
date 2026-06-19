using System;
using Assets._ReusableScripts.Globales.Updater;

namespace Assets._ReusableScripts.CuchiCuchi.Miscellaneous
{
	// Token: 0x02000165 RID: 357
	public class CopyCharacterRootBone : TrasnformCopier
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x00025CF6 File Offset: 0x00023EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.m_Event1 = GlobalUpdater.UpdateType.lateUpdate1;
			this.m_useEvent2 = false;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00025D5A File Offset: 0x00023F5A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Character componentInParent = base.GetComponentInParent<Character>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			componentInParent.stared += this.Character_stared;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00025D92 File Offset: 0x00023F92
		private void Character_stared(object sender)
		{
			base.Init(base.transform, (sender as Character).rootBoneTransform);
		}
	}
}
