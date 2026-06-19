using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers;
using Assets._ReusableScripts.CuchiCuchi.TransFollowers;
using Assets._ReusableScripts.Miscellaneous;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001C0 RID: 448
	[RequireComponent(typeof(InteractionObjectV2))]
	public class EstetoscopioPasarAlFrenteLector : InteraccionObjectCallBacksPauseOnHalfTime
	{
		// Token: 0x06000AC0 RID: 2752 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000356F8 File Offset: 0x000338F8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionObjectV2 = base.GetComponent<InteractionObjectV2>();
			this.m_InteractionObjectV2.stared += this.M_InteractionObjectV2_stared;
			this.m_InteractionObjectV2.stoped += this.M_InteractionObjectV2_stoped;
			this.m_localPositionFromUnionBone = this.unionBone.InverseTransformPoint(this.pivot.position);
			this.m_localRotationFromUnionBone = Quaternion.Inverse(this.unionBone.rotation) * this.pivot.rotation;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00035787 File Offset: 0x00033987
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_InteractionObjectV2.stared -= this.M_InteractionObjectV2_stared;
			this.m_InteractionObjectV2.stoped -= this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000357BE File Offset: 0x000339BE
		private void DestroyFollower()
		{
			if (this.m_follower)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x000357E0 File Offset: 0x000339E0
		private void M_InteractionObjectV2_stared(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			this.DestroyFollower();
			this.pivot.position = this.unionBone.TransformPoint(this.m_localPositionFromUnionBone);
			this.pivot.rotation = this.unionBone.rotation * this.m_localRotationFromUnionBone;
			this.m_follower = this.pivot.gameObject.AddComponent<FollowInterObjAnimatorBone>();
			this.m_follower.bone = HumanBodyBones.Chest;
			this.m_follower.pass = IKPassMatrixFollower.Pass.primero;
			this.m_follower.postPhysicsIKWeight = 0f;
			this.m_follower.initType = MatrixFollowerBase.InitType.custom;
			this.m_follower.Init();
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00035885 File Offset: 0x00033A85
		private void M_InteractionObjectV2_stoped(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			this.DestroyFollower();
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnPause()
		{
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnResume()
		{
		}

		// Token: 0x04000827 RID: 2087
		public Transform unionBone;

		// Token: 0x04000828 RID: 2088
		public Transform pivot;

		// Token: 0x04000829 RID: 2089
		private Vector3 m_localPositionFromUnionBone;

		// Token: 0x0400082A RID: 2090
		private Quaternion m_localRotationFromUnionBone;

		// Token: 0x0400082B RID: 2091
		[ReadOnlyUI]
		[SerializeField]
		private FollowInterObjAnimatorBone m_follower;

		// Token: 0x0400082C RID: 2092
		private InteractionObjectV2 m_InteractionObjectV2;
	}
}
