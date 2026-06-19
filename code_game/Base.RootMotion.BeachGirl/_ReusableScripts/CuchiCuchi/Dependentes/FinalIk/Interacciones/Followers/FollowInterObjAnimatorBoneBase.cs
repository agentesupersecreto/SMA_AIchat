using System;
using Assets._ReusableScripts.CuchiCuchi.TransFollowers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers
{
	// Token: 0x020000B0 RID: 176
	public abstract class FollowInterObjAnimatorBoneBase : InterObjIKPassMatrixFollower
	{
		// Token: 0x060006B6 RID: 1718 RVA: 0x00020A89 File Offset: 0x0001EC89
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.pass = IKPassMatrixFollower.Pass.ultimo;
			this.postPhysicsIKWeight = 1f;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00020AA4 File Offset: 0x0001ECA4
		protected override void LoadTarget()
		{
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			this.m_boneTarget = componentEnRoot.GetBoneTransform(this.bone);
			if (this.m_boneTarget == null)
			{
				throw new ArgumentNullException("m_boneTarget", "m_boneTarget null reference.");
			}
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00020B02 File Offset: 0x0001ED02
		protected override bool Following()
		{
			return this.m_boneTarget != null;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00020B10 File Offset: 0x0001ED10
		protected override Matrix4x4 GetLocalToWorldMatrix()
		{
			return this.m_boneTarget.localToWorldMatrix;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00020B1D File Offset: 0x0001ED1D
		protected override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00020B1F File Offset: 0x0001ED1F
		protected override void Followed()
		{
		}

		// Token: 0x0400048D RID: 1165
		public HumanBodyBones bone;

		// Token: 0x0400048E RID: 1166
		[ReadOnlyUI]
		[SerializeField]
		protected Transform m_boneTarget;
	}
}
