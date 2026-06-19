using System;
using Assets.SystemasConstraints._Abstract;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals
{
	// Token: 0x02000191 RID: 401
	public abstract class HoleExternal : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000964 RID: 2404 RVA: 0x00029BC0 File Offset: 0x00027DC0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
			if (this.m_SkinnedMeshRenderer == null)
			{
				throw new ArgumentNullException("m_SkinnedMeshRenderer", "m_SkinnedMeshRenderer null reference.");
			}
			if (this.m_ConstrainedSkeleton == null)
			{
				throw new ArgumentNullException("m_ConstrainedSkeleton", "m_ConstrainedSkeleton null reference.");
			}
			this.m_ConstrainedSkeleton.Init(this.m_SkinnedMeshRenderer);
		}

		// Token: 0x04000745 RID: 1861
		[SerializeField]
		protected BoneStretchedChain m_hole;

		// Token: 0x04000746 RID: 1862
		[SerializeField]
		protected Transform m_root;

		// Token: 0x04000747 RID: 1863
		[SerializeField]
		protected SkinnedMeshRenderer m_SkinnedMeshRenderer;

		// Token: 0x04000748 RID: 1864
		[SerializeField]
		protected ConstrainedSkeleton m_ConstrainedSkeleton;
	}
}
