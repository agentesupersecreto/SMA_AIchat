using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000071 RID: 113
	public sealed class ForcedFixedJoint : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600027B RID: 635 RVA: 0x000075BD File Offset: 0x000057BD
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600027C RID: 636 RVA: 0x000075C6 File Offset: 0x000057C6
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates3);
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000075D0 File Offset: 0x000057D0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (!base.isStared)
			{
				return;
			}
			if (this.connectedBody == null)
			{
				throw new ArgumentNullException("connectedBody", "connectedBody null reference.");
			}
			this.m_fixedJoint = base.gameObject.AddComponent<FixedJoint>();
			this.m_fixedJoint.connectedBody = this.connectedBody;
			this.m_fixedJoint.connectedMassScale = this.connectedMassScale;
			this.m_dummyCollider = base.transform.CreateChild("DummyCollider").gameObject.AddComponent<SphereCollider>();
			this.m_dummyCollider.radius = 0.01f;
			this.m_dummyCollider.gameObject.layer = 31;
			this.m_positionOffset = Matrix4x4.TRS(this.connectedBody.transform.position, this.connectedBody.transform.rotation, Vector3.one).inverse.MultiplyPoint3x4(base.transform.position);
			this.m_rotationOffset = Quaternion.Inverse(this.connectedBody.rotation) * base.transform.rotation;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000076F0 File Offset: 0x000058F0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_fixedJoint)
			{
				Object.Destroy(this.m_fixedJoint);
			}
			if (this.m_dummyCollider)
			{
				Object.Destroy(this.m_dummyCollider.gameObject);
			}
			this.m_fixedJoint = null;
			this.m_positionOffset = Vector3.zero;
			this.m_rotationOffset = Quaternion.identity;
			this.m_haGuardadoAtributos = false;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00007760 File Offset: 0x00005960
		public override void OnUpdateEvent1()
		{
			if (this.noForceOffsets)
			{
				return;
			}
			this.m_haGuardadoAtributos = true;
			this.m_lastPosition = this.connectedBody.position;
			this.m_lastRotation = this.connectedBody.rotation;
			Vector3 vector = this.connectedBody.position + this.connectedBody.rotation * this.m_positionOffset;
			Quaternion quaternion = this.connectedBody.rotation * this.m_rotationOffset;
			base.transform.SetPositionAndRotation(vector, quaternion);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000077EA File Offset: 0x000059EA
		public override void OnUpdateEvent2()
		{
			if (this.m_haGuardadoAtributos)
			{
				this.connectedBody.transform.SetPositionAndRotation(this.m_lastPosition, this.m_lastRotation);
			}
			this.m_haGuardadoAtributos = false;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00007818 File Offset: 0x00005A18
		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.connectedBody == null)
			{
				return;
			}
			Vector3 vector = this.connectedBody.position + this.connectedBody.rotation * this.m_positionOffset;
			Quaternion quaternion = this.connectedBody.rotation * this.m_rotationOffset;
			DebugExtension.DrawArrow(vector, quaternion * Vector3.forward * 0.1f, Color.blue);
			DebugExtension.DrawArrow(vector, quaternion * Vector3.up * 0.1f, Color.green);
			DebugExtension.DrawArrow(vector, quaternion * Vector3.right * 0.1f, Color.red);
		}

		// Token: 0x04000193 RID: 403
		public Rigidbody connectedBody;

		// Token: 0x04000194 RID: 404
		public float connectedMassScale = 1f;

		// Token: 0x04000195 RID: 405
		public bool noForceOffsets;

		// Token: 0x04000196 RID: 406
		private FixedJoint m_fixedJoint;

		// Token: 0x04000197 RID: 407
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_positionOffset = Vector3.zero;

		// Token: 0x04000198 RID: 408
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_rotationOffset = Quaternion.identity;

		// Token: 0x04000199 RID: 409
		private bool m_haGuardadoAtributos;

		// Token: 0x0400019A RID: 410
		private Vector3 m_lastPosition = Vector3.zero;

		// Token: 0x0400019B RID: 411
		private Quaternion m_lastRotation = Quaternion.identity;

		// Token: 0x0400019C RID: 412
		private SphereCollider m_dummyCollider;
	}
}
