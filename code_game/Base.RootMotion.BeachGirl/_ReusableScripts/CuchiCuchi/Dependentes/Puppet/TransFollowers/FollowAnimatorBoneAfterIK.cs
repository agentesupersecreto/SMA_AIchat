using System;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.TransFollowers
{
	// Token: 0x02000107 RID: 263
	public class FollowAnimatorBoneAfterIK : BaseFolowTransform
	{
		// Token: 0x06000A41 RID: 2625 RVA: 0x0002DEFD File Offset: 0x0002C0FD
		protected sealed override void EditorAdded()
		{
			base.EditorAdded();
			this.m_CustomUpdate = true;
			this.m_InitType = BaseFolowTransform.InitType.awake;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0002DF13 File Offset: 0x0002C113
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ikUpdater = this.GetComponentEnRoot(false);
			if (this.m_ikUpdater == null)
			{
				throw new ArgumentNullException("m_ikUpdater", "m_ikUpdater null reference.");
			}
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0002DF40 File Offset: 0x0002C140
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ikUpdater.onAllIKsUpdated += this.M_ikUpdater_iKsUpdated_AntesDePupppet;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0002DF5F File Offset: 0x0002C15F
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_ikUpdater.onAllIKsUpdated -= this.M_ikUpdater_iKsUpdated_AntesDePupppet;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0002DF7F File Offset: 0x0002C17F
		private void M_ikUpdater_iKsUpdated_AntesDePupppet(IIKUpdater obj)
		{
			base.Follow();
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0002DF87 File Offset: 0x0002C187
		protected sealed override Transform GetTransformTarget()
		{
			return base.GetComponentInParent<ICharacter>().GetComponentInChildren<Animator>().GetBoneTransform(this.m_boneToFollow);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0002DF9F File Offset: 0x0002C19F
		protected sealed override void Followed()
		{
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0002DFA1 File Offset: 0x0002C1A1
		protected sealed override void Following()
		{
		}

		// Token: 0x04000640 RID: 1600
		[SerializeField]
		private HumanBodyBones m_boneToFollow;

		// Token: 0x04000641 RID: 1601
		private IIKUpdater m_ikUpdater;
	}
}
