using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers;
using Assets._ReusableScripts.CuchiCuchi.TransFollowers;
using Assets._ReusableScripts.Miscellaneous;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001BD RID: 445
	[RequireComponent(typeof(InteractionObjectV2))]
	public sealed class EstetoscopioHacerLectura : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000AA1 RID: 2721 RVA: 0x00034AC8 File Offset: 0x00032CC8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionObjectV2 = base.GetComponent<InteractionObjectV2>();
			this.m_InteractionObjectV2.stared += this.M_InteractionObjectV2_stared1;
			this.m_InteractionObjectV2.stoped += this.M_InteractionObjectV2_stoped1;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00034B18 File Offset: 0x00032D18
		private void M_InteractionObjectV2_stared1(InteractionObjectV2Base arg1, InteractionSystem arg2)
		{
			this.DestroyComponents();
			AnimatorCharacter componentEnRoot = arg1.lastUsedInteractionSystem.GetComponentEnRoot(false);
			this.m_currentUserChest = componentEnRoot.bones.chest;
			DatosDeHumanBone chest = ((AnimatorCharacter)MainChar.current).bones.chest;
			Vector3 vector = chest.transform.position + chest.currentWorldRotation * this.localMaleChestPositionOffset - this.m_currentUserChest.transform.position;
			float y = Math3d.InverseTransformDirectionMath(this.m_currentUserChest.currentWorldRotation, vector).y;
			this.pivot.SetPositionAndRotation(this.m_currentUserChest.transform.position + Math3d.TransformDirectionMath(this.m_currentUserChest.currentWorldRotation, new Vector3(0f, y, 0f)), this.m_currentUserChest.currentWorldRotation);
			this.m_follower = this.pivot.gameObject.AddComponent<FollowInterObjAnimatorBone>();
			this.m_follower.bone = HumanBodyBones.Chest;
			this.m_follower.pass = IKPassMatrixFollower.Pass.ultimo;
			this.m_follower.postPhysicsIKWeight = 0f;
			this.m_follower.initType = MatrixFollowerBase.InitType.custom;
			this.m_follower.Init();
			this.m_follower.followed += this.M_follower_followed;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00034C64 File Offset: 0x00032E64
		private void M_InteractionObjectV2_stoped1(InteractionObjectV2Base arg1, InteractionSystem arg2)
		{
			this.DestroyComponents();
			this.proyector.Clear();
			this.m_currentUserChest = null;
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00034C7E File Offset: 0x00032E7E
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_InteractionObjectV2.stared -= this.M_InteractionObjectV2_stared1;
			this.m_InteractionObjectV2.stoped -= this.M_InteractionObjectV2_stoped1;
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00034CB5 File Offset: 0x00032EB5
		private void DestroyComponents()
		{
			if (this.m_follower)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00034CD8 File Offset: 0x00032ED8
		private void M_follower_followed(MatrixFollowerBase obj)
		{
			this.proyector.worldDirectionToProyect = this.m_currentUserChest.currentForward;
			FBIKChain chain = this.m_InteractionObjectV2.lastUsedInteractionSystem.ik.solver.GetChain(FullBodyBipedChain.RightArm);
			float num = 0f;
			for (int i = 0; i < chain.nodes.Length; i++)
			{
				num += chain.nodes[i].length;
			}
			this.proyector.rotationOffSet = new Vector3(0f, 0f, 0f);
			this.proyector.maxDistance = num * this.distanceMod;
			this.proyector.backwardsDistanceMod = 0f;
			this.proyector.Actualizar();
		}

		// Token: 0x04000803 RID: 2051
		public ProyectorDePuntos proyector;

		// Token: 0x04000804 RID: 2052
		public Transform pivot;

		// Token: 0x04000805 RID: 2053
		public float distanceMod = 1f;

		// Token: 0x04000806 RID: 2054
		private InteractionObjectV2 m_InteractionObjectV2;

		// Token: 0x04000807 RID: 2055
		public Vector3 localMaleChestPositionOffset = new Vector3(0f, 0.1f, 0f);

		// Token: 0x04000808 RID: 2056
		private FollowInterObjAnimatorBone m_follower;

		// Token: 0x04000809 RID: 2057
		private DatosDeHumanBone m_currentUserChest;

		// Token: 0x0400080A RID: 2058
		private Transform m_pivotDePivot;
	}
}
