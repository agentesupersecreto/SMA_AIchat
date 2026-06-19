using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.TransFollowers;
using Assets._ReusableScripts.Miscellaneous;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers
{
	// Token: 0x020000B3 RID: 179
	[RequireComponent(typeof(InteractionObjectV2Base))]
	public abstract class InterObjIKPassMatrixFollower : IKPassMatrixFollower
	{
		// Token: 0x060006CA RID: 1738 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		protected override void AwakeUnityEvent()
		{
			this.m_object = base.GetComponentInParent<InteractionObjectV2Base>();
			this.m_Interaccion = base.GetComponentInParent<Interaccion>();
			if (this.m_object == null)
			{
				throw new ArgumentNullException("m_object", "m_object null reference.");
			}
			if (this.m_Interaccion == null)
			{
				throw new ArgumentNullException("m_Interaccion", "m_Interaccion null reference.");
			}
			this.m_internalUsePhysicsIKUpdated = false;
			this.m_object.stared += this.OnInteractionStared;
			this.m_object.stoped += this.OnInteractionStoped;
			this.m_Interaccion.checkingPuedeEjecutarse += this.M_Interaccion_checkingPuedeEjecutarse;
			this.m_Interaccion.checkedPuedeEjecutarse += this.M_Interaccion_checkedPuedeEjecutarse;
			base.AwakeUnityEvent();
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00020FBA File Offset: 0x0001F1BA
		public void Init()
		{
			if (this.m_InitType != MatrixFollowerBase.InitType.custom)
			{
				throw new InvalidOperationException();
			}
			this.InitTransformTarget();
		}

		// Token: 0x060006CC RID: 1740
		protected abstract void LoadTarget();

		// Token: 0x060006CD RID: 1741 RVA: 0x00020FD1 File Offset: 0x0001F1D1
		protected override void InitTransformTarget()
		{
			this.LoadTarget();
			base.InitTransformTarget();
			if (this.m_object.interacting && this.m_ikIdOfInteraction < 0)
			{
				this.OnInteractionStared(this.m_object, this.m_object.lastUsedInteractionSystem);
			}
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0002100C File Offset: 0x0001F20C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_object != null)
			{
				this.m_object.stared -= this.OnInteractionStared;
				this.m_object.stoped -= this.OnInteractionStoped;
			}
			if (this.m_Interaccion != null)
			{
				this.m_Interaccion.checkingPuedeEjecutarse -= this.M_Interaccion_checkingPuedeEjecutarse;
				this.m_Interaccion.checkedPuedeEjecutarse -= this.M_Interaccion_checkedPuedeEjecutarse;
			}
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00021098 File Offset: 0x0001F298
		private void M_Interaccion_checkingPuedeEjecutarse(Interaccion obj)
		{
			if (!this.onlyFollowBeforeStartInteraction)
			{
				InterObjIKPassMatrixFollower.m_tempPosition = base.transform.position;
				InterObjIKPassMatrixFollower.m_tempRotation = base.transform.rotation;
				InterObjIKPassMatrixFollower.m_tempScale = base.transform.localScale;
			}
			this.m_flagFirstFollowFromThisInteraction = true;
			base.Follow();
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x000210EA File Offset: 0x0001F2EA
		private void M_Interaccion_checkedPuedeEjecutarse(Interaccion obj)
		{
			if (!this.onlyFollowBeforeStartInteraction)
			{
				base.transform.localScale = InterObjIKPassMatrixFollower.m_tempScale;
				base.transform.SetPositionAndRotation(InterObjIKPassMatrixFollower.m_tempPosition, InterObjIKPassMatrixFollower.m_tempRotation);
			}
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0002111C File Offset: 0x0001F31C
		protected override bool CanFollow()
		{
			bool flagFirstFollowFromThisInteraction = this.m_flagFirstFollowFromThisInteraction;
			this.m_flagFirstFollowFromThisInteraction = false;
			return base.CanFollow() && (!this.onlyFollowBeforeStartInteraction || flagFirstFollowFromThisInteraction);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00021150 File Offset: 0x0001F350
		private void OnInteractionStared(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			if (obj.lastUsedInteractionSystem == null)
			{
				Debug.LogWarning("InteractionObject no contiene ningun InteractionSystem", this);
				this.ikId = (this.m_ikIdOfInteraction = -1);
				this.m_internalUsePhysicsIKUpdated = false;
				return;
			}
			if (obj.lastUsedInteractionSystem.ik == null)
			{
				Debug.LogWarning("InteractionSystem no contiene ningun IK", this);
				this.ikId = (this.m_ikIdOfInteraction = -1);
				this.m_internalUsePhysicsIKUpdated = false;
				return;
			}
			this.ikId = (this.m_ikIdOfInteraction = this.m_updater.IDDeIK(obj.lastUsedInteractionSystem.ik));
			this.m_internalUsePhysicsIKUpdated = true;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000211F0 File Offset: 0x0001F3F0
		private void OnInteractionStoped(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			this.ikId = (this.m_ikIdOfInteraction = -1);
			this.m_internalUsePhysicsIKUpdated = false;
		}

		// Token: 0x04000497 RID: 1175
		public bool onlyFollowBeforeStartInteraction;

		// Token: 0x04000498 RID: 1176
		protected InteractionObjectV2Base m_object;

		// Token: 0x04000499 RID: 1177
		protected Interaccion m_Interaccion;

		// Token: 0x0400049A RID: 1178
		[ReadOnlyUI]
		[SerializeField]
		protected int m_ikIdOfInteraction = -1;

		// Token: 0x0400049B RID: 1179
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagFirstFollowFromThisInteraction;

		// Token: 0x0400049C RID: 1180
		private static Vector3 m_tempPosition;

		// Token: 0x0400049D RID: 1181
		private static Quaternion m_tempRotation;

		// Token: 0x0400049E RID: 1182
		private static Vector3 m_tempScale;
	}
}
