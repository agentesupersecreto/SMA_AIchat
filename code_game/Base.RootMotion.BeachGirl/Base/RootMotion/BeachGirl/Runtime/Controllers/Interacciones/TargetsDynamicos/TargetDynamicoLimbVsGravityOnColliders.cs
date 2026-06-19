using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.TargetsDynamicos
{
	// Token: 0x02000041 RID: 65
	public class TargetDynamicoLimbVsGravityOnColliders : TargetDynamicoDeInteracionBase
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x0000E2A0 File Offset: 0x0000C4A0
		public Transform root
		{
			get
			{
				return this.bone1.parent;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000E2B0 File Offset: 0x0000C4B0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_defaultTargetLocalPosition = this.root.InverseTransformPoint(this.bone3.position);
			this.m_defaultTargetLocalRotation = Quaternion.Inverse(this.root.rotation) * this.bone3.rotation;
			this.m_limbLargo = Vector3.Distance(this.bone1.position, this.bone2.position) + Vector3.Distance(this.bone2.position, this.bone3.position);
			this.m_target = base.transform.CreateChild("Target");
			this.m_IK = base.gameObject.AddComponent<LimbIK>();
			if (!this.m_IK.solver.SetChain(this.bone1, this.bone2, this.bone3, this.root))
			{
				Debug.LogError("Chain is invalid", this);
			}
			this.m_IK.fixTransforms = false;
			this.m_IK.solver.target = this.m_target;
			this.m_IK.enabled = false;
			this.m_IK.solver.bendModifier = IKSolverLimb.BendModifier.Target;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000E3DD File Offset: 0x0000C5DD
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			Object.Destroy(this.m_target);
			this.m_target = null;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000E3F8 File Offset: 0x0000C5F8
		protected virtual float GetExtraCastDistance(ICharacter para, float scala, Vector3 castOrigin, float castDistance, Vector3 castDirection)
		{
			return this.localCastExtraDistance * scala;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000E404 File Offset: 0x0000C604
		protected override void actualizar(ICharacter para)
		{
			float valueOrDefault = ((para != null) ? new float?(para.escala) : null).GetValueOrDefault(1f);
			Vector3 vector = this.root.TransformPoint(this.m_defaultTargetLocalPosition);
			Vector3 vector2 = Math3d.ProjectPointOnPlane(this.gravity, this.bone1.position, vector);
			Vector3 vector3 = vector - vector2;
			float num = this.m_limbLargo * this.m_maxLargoUsable * valueOrDefault;
			float extraCastDistance = this.GetExtraCastDistance(para, valueOrDefault, vector2, num, vector3);
			num += extraCastDistance;
			float num2 = this.localCastRadius * valueOrDefault;
			RaycastHit raycastHit;
			if (Physics.SphereCast(vector2, num2, vector3, out raycastHit, num, this.layerMask, QueryTriggerInteraction.Ignore) && raycastHit.distance > 0f)
			{
				raycastHit.point = raycastHit.point - vector3.normalized * num2 - vector3.normalized * extraCastDistance;
				this.m_target.SetPositionAndRotation(raycastHit.point, this.root.rotation * this.m_defaultTargetLocalRotation);
				this.m_IK.solver.Update();
			}
			else
			{
				this.ResetTarget();
			}
			bool flag = this.debugDraw;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000E548 File Offset: 0x0000C748
		private void SetTargetToDefault()
		{
			if (this.m_target != null)
			{
				this.m_target.SetPositionAndRotation(this.root.TransformPoint(this.m_defaultTargetLocalPosition), this.root.rotation * this.m_defaultTargetLocalRotation);
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000E595 File Offset: 0x0000C795
		public override void ResetTarget()
		{
			if (this.m_IK != null)
			{
				this.m_IK.FixTransformsTValle();
			}
			this.SetTargetToDefault();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000E5B8 File Offset: 0x0000C7B8
		private void OnDrawGizmosSelected()
		{
			if (this.bone3 != null)
			{
				Vector3 vector = this.bone3.position + this.gravity.normalized * this.localCastExtraDistance;
				Debug.DrawLine(this.bone3.position, vector, Color.green, 0f, false);
			}
		}

		// Token: 0x040001DF RID: 479
		public bool debugDraw;

		// Token: 0x040001E0 RID: 480
		public Transform bone1;

		// Token: 0x040001E1 RID: 481
		public Transform bone2;

		// Token: 0x040001E2 RID: 482
		public Transform bone3;

		// Token: 0x040001E3 RID: 483
		public LayerMask layerMask;

		// Token: 0x040001E4 RID: 484
		public Vector3 gravity = Vector3.down;

		// Token: 0x040001E5 RID: 485
		[SerializeField]
		[Range(0f, 1f)]
		private float m_maxLargoUsable = 1f;

		// Token: 0x040001E6 RID: 486
		public float localCastRadius = 0.02f;

		// Token: 0x040001E7 RID: 487
		public float localCastExtraDistance;

		// Token: 0x040001E8 RID: 488
		private Vector3 m_defaultTargetLocalPosition;

		// Token: 0x040001E9 RID: 489
		private Quaternion m_defaultTargetLocalRotation;

		// Token: 0x040001EA RID: 490
		[ReadOnlyUI]
		[SerializeField]
		private float m_limbLargo;

		// Token: 0x040001EB RID: 491
		private Transform m_target;

		// Token: 0x040001EC RID: 492
		private LimbIK m_IK;
	}
}
