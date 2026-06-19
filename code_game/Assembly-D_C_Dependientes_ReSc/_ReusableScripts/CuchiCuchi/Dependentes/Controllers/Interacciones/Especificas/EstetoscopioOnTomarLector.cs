using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Cadenas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.Miscellaneous.Transforms;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001BF RID: 447
	[Obsolete("hay q actializar", true)]
	[RequireComponent(typeof(InteractionObjectV2))]
	public sealed class EstetoscopioOnTomarLector : InteraccionObjectCallBacksPauseOnHalfTime
	{
		// Token: 0x06000AB6 RID: 2742 RVA: 0x000352AC File Offset: 0x000334AC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionObjectV2 = base.GetComponent<InteractionObjectV2>();
			this.m_InteractionObjectV2.stared += this.M_InteractionObjectV2_stared;
			this.m_InteractionObjectV2.stoped += this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000352F9 File Offset: 0x000334F9
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_InteractionObjectV2.stared -= this.M_InteractionObjectV2_stared;
			this.m_InteractionObjectV2.stoped -= this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00035330 File Offset: 0x00033530
		private void M_InteractionObjectV2_stared(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			EstetoscopioInteractions estetoscopioInteractions = this.interactions;
			bool flag;
			if (estetoscopioInteractions == null)
			{
				flag = null != null;
			}
			else
			{
				IInteraccionesDeCharacter currentUser = estetoscopioInteractions.currentUser;
				flag = ((currentUser != null) ? currentUser.character : null) != null;
			}
			if (!flag)
			{
				return;
			}
			if (this.colliders != null)
			{
				this.interactions.currentUser.character.IgnorarCollosionesConManos(this.colliders.colliders, true);
			}
			this.interactions.currentUser.character.IgnorarCollosionesConManos(this.extraColliders, true);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000353AC File Offset: 0x000335AC
		private void M_InteractionObjectV2_stoped(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			EstetoscopioInteractions estetoscopioInteractions = this.interactions;
			bool flag;
			if (estetoscopioInteractions == null)
			{
				flag = null != null;
			}
			else
			{
				IInteraccionesDeCharacter currentUser = estetoscopioInteractions.currentUser;
				flag = ((currentUser != null) ? currentUser.character : null) != null;
			}
			if (!flag)
			{
				return;
			}
			if (this.colliders != null)
			{
				this.interactions.currentUser.character.IgnorarCollosionesConManos(this.colliders.colliders, false);
			}
			this.interactions.currentUser.character.IgnorarCollosionesConManos(this.extraColliders, false);
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00035425 File Offset: 0x00033625
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.side != Side.R && this.side != Side.L)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00035445 File Offset: 0x00033645
		private void DestroyFollower()
		{
			if (this.m_follower)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00035468 File Offset: 0x00033668
		public override void OnPause()
		{
			this.DestroyFollower();
			if (this.copiadorDePivot != null)
			{
				this.copiadorDePivot.enabled = false;
			}
			if (!(this.pivot == null) && !(this.lector == null) && !(this.interactionTarget == null))
			{
				EstetoscopioInteractions estetoscopioInteractions = this.interactions;
				bool flag;
				if (estetoscopioInteractions == null)
				{
					flag = null != null;
				}
				else
				{
					IInteraccionesDeCharacter currentUser = estetoscopioInteractions.currentUser;
					flag = ((currentUser != null) ? currentUser.character : null) != null;
				}
				if (flag)
				{
					this.lector.isKinematic = true;
					Transform parent = this.lector.transform.parent;
					this.copiadorDePivot.target.parent = null;
					this.lector.transform.parent = null;
					this.copiadorDePivot.target.parent = parent;
					this.lector.transform.parent = this.copiadorDePivot.target;
					this.copiadorDePivot.target.SetPositionAndRotation(this.pivot.position, this.pivot.rotation);
					this.copiadorDePivot.target.parent = null;
					this.lector.transform.parent = null;
					this.copiadorDePivot.target.parent = this.lector.transform;
					this.lector.transform.parent = parent;
					Transform boneTransform = this.interactions.currentUser.character.bodyAnimator.GetBoneTransform((this.side == Side.R) ? HumanBodyBones.RightHand : HumanBodyBones.LeftHand);
					this.m_follower = this.lector.gameObject.AddComponent<MatrixFollower>();
					this.m_follower.target = boneTransform;
					this.m_follower.initType = MatrixFollowerBase.InitType.custom;
					this.m_follower.followScale = false;
					this.m_follower.updateEvent = GlobalUpdater.UpdateType.afterAnimationConstraints;
					this.m_follower.Init();
					this.m_follower.ResetDefaultOffsets();
					this.m_follower.localOffset = this.interactionTarget.transform.InverseTransformPoint(this.lector.transform.position);
					this.m_follower.localRotOffset = Quaternion.Inverse(this.interactionTarget.transform.rotation) * this.lector.transform.rotation;
					return;
				}
			}
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x000356A6 File Offset: 0x000338A6
		public override void OnResume()
		{
			this.DestroyFollower();
			if (this.lector != null)
			{
				this.lector.isKinematic = false;
			}
			if (this.copiadorDePivot != null)
			{
				this.copiadorDePivot.enabled = true;
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x0400081D RID: 2077
		public Side side;

		// Token: 0x0400081E RID: 2078
		public Transform pivot;

		// Token: 0x0400081F RID: 2079
		public InteractionTarget interactionTarget;

		// Token: 0x04000820 RID: 2080
		public EstetoscopioInteractions interactions;

		// Token: 0x04000821 RID: 2081
		public CollidersParaCadenaLinearDeLargoVariable colliders;

		// Token: 0x04000822 RID: 2082
		public Rigidbody lector;

		// Token: 0x04000823 RID: 2083
		public TrasnformCopiadorManual copiadorDePivot;

		// Token: 0x04000824 RID: 2084
		public List<Collider> extraColliders = new List<Collider>();

		// Token: 0x04000825 RID: 2085
		[ReadOnlyUI]
		[SerializeField]
		private MatrixFollower m_follower;

		// Token: 0x04000826 RID: 2086
		private InteractionObjectV2 m_InteractionObjectV2;
	}
}
