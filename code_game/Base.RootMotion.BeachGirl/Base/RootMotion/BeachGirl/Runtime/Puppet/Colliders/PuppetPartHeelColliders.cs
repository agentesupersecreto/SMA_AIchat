using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.HighHeelScripts;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Colliders
{
	// Token: 0x02000013 RID: 19
	public class PuppetPartHeelColliders : CustomMonobehaviour
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x000058A0 File Offset: 0x00003AA0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_heelCollider == null)
			{
				throw new ArgumentNullException("m_heelCollider", "m_heelCollider null reference.");
			}
			if (this.m_toeCollider == null)
			{
				throw new ArgumentNullException("m_toeCollider", "m_toeCollider null reference.");
			}
			this.m_FemaleHighHeelSystem = this.GetComponentEnRoot(false);
			if (this.m_FemaleHighHeelSystem == null)
			{
				throw new ArgumentNullException("m_FemaleHighHeelSystem", "m_FemaleHighHeelSystem null reference.");
			}
			this.m_partBody = base.GetComponentInParent<Rigidbody>();
			if (this.m_partBody == null)
			{
				throw new ArgumentNullException("m_partBody", "m_partBody null reference.");
			}
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			Animator bodyAnimator = componentEnRoot.bodyAnimator;
			this.m_LocalForward = base.transform.InverseTransformDirection(bodyAnimator.transform.forward);
			this.m_defaultHeelColliderHeight = this.m_heelCollider.center.y + this.m_heelCollider.size.y * 0.5f;
			this.m_defaultHeelColliderOffset = this.m_heelCollider.center.y - this.m_heelCollider.size.y * 0.5f;
			this.m_defaultHeelColliderSize = this.m_heelCollider.size;
			this.m_defaultHeelColliderCenter = this.m_heelCollider.center;
			this.m_defaultToeColliderHeight = this.m_toeCollider.center.y + this.m_toeCollider.size.y * 0.5f;
			this.m_defaultToeColliderOffset = this.m_toeCollider.center.y - this.m_toeCollider.size.y * 0.5f;
			this.m_defaultToeColliderSize = this.m_toeCollider.size;
			this.m_defaultToeColliderCenter = this.m_toeCollider.center;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00005A78 File Offset: 0x00003C78
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_FemaleHighHeelSystem.isStared)
			{
				this.M_FemaleHighHeelSystem_highHeelHeightUpdated(this.m_FemaleHighHeelSystem);
			}
			this.m_FemaleHighHeelSystem.highHeelHeightUpdated += this.M_FemaleHighHeelSystem_highHeelHeightUpdated;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00005AB0 File Offset: 0x00003CB0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_FemaleHighHeelSystem)
			{
				this.m_FemaleHighHeelSystem.highHeelHeightUpdated -= this.M_FemaleHighHeelSystem_highHeelHeightUpdated;
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005AE0 File Offset: 0x00003CE0
		private void M_FemaleHighHeelSystem_highHeelHeightUpdated(FemaleHighHeelSystem obj)
		{
			Side side = this.m_side;
			Vector3 vector;
			Vector3 vector2;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
				vector = this.m_FemaleHighHeelSystem.heelR.InverseTransformDirection(this.m_FemaleHighHeelSystem.GetVirtualDownDirectionFromHeelR());
				vector2 = this.m_FemaleHighHeelSystem.heelR.InverseTransformDirection(this.m_FemaleHighHeelSystem.GetDownDirectionFromToesR());
			}
			else
			{
				vector = this.m_FemaleHighHeelSystem.heelL.InverseTransformDirection(this.m_FemaleHighHeelSystem.GetVirtualDownDirectionFromHeelL());
				vector2 = this.m_FemaleHighHeelSystem.heelL.InverseTransformDirection(this.m_FemaleHighHeelSystem.GetDownDirectionFromToesL());
			}
			Vector3 vector3 = vector * this.m_FemaleHighHeelSystem.currentHeelLocalTotalHeight;
			this.m_heelCollider.transform.localRotation = Quaternion.LookRotation(vector3 - this.m_heelCollider.transform.localPosition, this.m_LocalForward) * Quaternion.AngleAxis(-90f, Vector3.right);
			Vector3 vector4 = vector2 * this.m_FemaleHighHeelSystem.currentToeLocalTotalHeight;
			this.m_toeCollider.transform.localRotation = Quaternion.LookRotation(vector4, this.m_LocalForward) * Quaternion.AngleAxis(-90f, Vector3.right);
			Vector3 vector5 = Vector3.up * this.m_defaultHeelColliderHeight;
			Vector3 vector6 = this.m_heelCollider.transform.InverseTransformPoint(base.transform.TransformPoint(vector3)) + Vector3.up * this.m_defaultHeelColliderOffset;
			Vector3 defaultHeelColliderSize = this.m_defaultHeelColliderSize;
			defaultHeelColliderSize.y = Vector3.Distance(vector5, vector6);
			Vector3 defaultHeelColliderCenter = this.m_defaultHeelColliderCenter;
			defaultHeelColliderCenter.y = -(defaultHeelColliderSize.y * 0.5f) + this.m_defaultHeelColliderHeight;
			this.m_heelCollider.center = defaultHeelColliderCenter;
			this.m_heelCollider.size = defaultHeelColliderSize;
			Vector3 defaultToeColliderSize = this.m_defaultToeColliderSize;
			defaultToeColliderSize.y += this.m_FemaleHighHeelSystem.currentRealToeLocalHeight;
			Vector3 defaultToeColliderCenter = this.m_defaultToeColliderCenter;
			defaultToeColliderCenter.y = -(defaultToeColliderSize.y * 0.5f) + this.m_defaultToeColliderHeight;
			this.m_toeCollider.center = defaultToeColliderCenter;
			this.m_toeCollider.size = defaultToeColliderSize;
		}

		// Token: 0x0400004B RID: 75
		[SerializeField]
		private Side m_side;

		// Token: 0x0400004C RID: 76
		[SerializeField]
		private BoxCollider m_heelCollider;

		// Token: 0x0400004D RID: 77
		[SerializeField]
		private BoxCollider m_toeCollider;

		// Token: 0x0400004E RID: 78
		private FemaleHighHeelSystem m_FemaleHighHeelSystem;

		// Token: 0x0400004F RID: 79
		private Rigidbody m_partBody;

		// Token: 0x04000050 RID: 80
		private Vector3 m_LocalForward;

		// Token: 0x04000051 RID: 81
		private float m_defaultHeelColliderHeight;

		// Token: 0x04000052 RID: 82
		private float m_defaultHeelColliderOffset;

		// Token: 0x04000053 RID: 83
		private Vector3 m_defaultHeelColliderSize;

		// Token: 0x04000054 RID: 84
		private Vector3 m_defaultHeelColliderCenter;

		// Token: 0x04000055 RID: 85
		private float m_defaultToeColliderHeight;

		// Token: 0x04000056 RID: 86
		private float m_defaultToeColliderOffset;

		// Token: 0x04000057 RID: 87
		private Vector3 m_defaultToeColliderSize;

		// Token: 0x04000058 RID: 88
		private Vector3 m_defaultToeColliderCenter;
	}
}
