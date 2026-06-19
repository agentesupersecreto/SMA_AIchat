using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.CustomTargets;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets
{
	// Token: 0x020000B8 RID: 184
	public class InteractionTargetTValle : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x00021284 File Offset: 0x0001F484
		public Vector3 bendGoalV2Position
		{
			get
			{
				if (!this.m_esBendGoalV2Initiated)
				{
					FullBodyBipedEffector shoulderOrMuscle;
					FullBodyBipedEffector handOrFeet;
					this.effectorType.GetBendGoal(out shoulderOrMuscle, out handOrFeet);
					this.m_InteractionSkeletonRoot = base.GetComponentInParent<InteractionSkeletonRoot>();
					InteractionTarget[] componentsInChildren = this.m_InteractionSkeletonRoot.GetComponentsInChildren<InteractionTarget>();
					this.m_shoulderOrMusleTarget = componentsInChildren.FirstOrDefault((InteractionTarget t) => t.effectorType == shoulderOrMuscle);
					this.m_handOrFeetTarget = componentsInChildren.FirstOrDefault((InteractionTarget t) => t.effectorType == handOrFeet);
					this.m_esBendGoalV2Initiated = true;
				}
				this.m_lastMiddlePoint = Math3d.ProjectPointOnLineSegment(this.m_handOrFeetTarget.transform.position, this.m_shoulderOrMusleTarget.transform.position, base.transform.position);
				this.m_lastBendGoalDirection = base.transform.position - this.m_lastMiddlePoint;
				float magnitude = this.m_lastBendGoalDirection.magnitude;
				float num = this.bendGoalErrorCorrctionDistance * this.m_InteractionSkeletonRoot.transform.localScale.Escala();
				if (this.m_lastBendGoalDirection.magnitude < num)
				{
					float num2 = Mathf.InverseLerp(0f, num, magnitude);
					this.m_lastBendGoalDirection = Vector3.Slerp(base.transform.forward * num, this.m_lastBendGoalDirection, num2).normalized * num;
				}
				return this.m_lastMiddlePoint + this.m_lastBendGoalDirection;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x000213E0 File Offset: 0x0001F5E0
		[Obsolete("", true)]
		public Vector3 localPositionFromBodyTarget
		{
			get
			{
				throw new NotSupportedException("esto no sirve ya q al intentar aplicar alguna pose local, el fix transforms arruina todo");
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x000213EC File Offset: 0x0001F5EC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_esBendGoal)
			{
				base.transform.position = base.transform.parent.TransformPoint(this.m_localPosition);
				base.transform.rotation = base.transform.parent.rotation * this.m_localRotation;
			}
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0002144E File Offset: 0x0001F64E
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00021458 File Offset: 0x0001F658
		public void SetGoals(Vector3 worldPosition, Quaternion rotation)
		{
			if (!Application.isEditor || Application.isPlaying)
			{
				throw new NotSupportedException();
			}
			this.m_esBendGoal = true;
			this.m_localPosition = base.transform.parent.InverseTransformPoint(worldPosition);
			this.m_localRotation = Quaternion.Inverse(base.transform.parent.rotation) * rotation;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x000214B8 File Offset: 0x0001F6B8
		private void OnDrawGizmosSelected()
		{
			if (this.esBendGoalV2 && this.m_esBendGoalV2Initiated)
			{
				Gizmos.color = Color.cyan;
				Gizmos.DrawLine(this.m_handOrFeetTarget.transform.position, this.m_shoulderOrMusleTarget.transform.position);
				Gizmos.DrawSphere(this.m_handOrFeetTarget.transform.position, 0.01f);
				Gizmos.DrawSphere(this.m_shoulderOrMusleTarget.transform.position, 0.01f);
				DebugExtension.DrawArrow(this.m_lastMiddlePoint, this.m_lastBendGoalDirection, Color.cyan);
			}
		}

		// Token: 0x040004A0 RID: 1184
		[Tooltip("The type of the FBBIK effector.")]
		public CustomBipedEffector effectorType;

		// Token: 0x040004A1 RID: 1185
		[ReadOnlyUI]
		[SerializeField]
		private bool m_esBendGoal;

		// Token: 0x040004A2 RID: 1186
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_localPosition;

		// Token: 0x040004A3 RID: 1187
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_localRotation;

		// Token: 0x040004A4 RID: 1188
		public bool esBendGoalV2;

		// Token: 0x040004A5 RID: 1189
		public bool esBendGoalAlwaysForced;

		// Token: 0x040004A6 RID: 1190
		public float bendGoalErrorCorrctionDistance = 0.25f;

		// Token: 0x040004A7 RID: 1191
		[ReadOnlyUI]
		[SerializeField]
		private bool m_esBendGoalV2Initiated;

		// Token: 0x040004A8 RID: 1192
		[ReadOnlyUI]
		[SerializeField]
		private InteractionSkeletonRoot m_InteractionSkeletonRoot;

		// Token: 0x040004A9 RID: 1193
		[ReadOnlyUI]
		[SerializeField]
		private InteractionTarget m_shoulderOrMusleTarget;

		// Token: 0x040004AA RID: 1194
		[ReadOnlyUI]
		[SerializeField]
		private InteractionTarget m_handOrFeetTarget;

		// Token: 0x040004AB RID: 1195
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_lastMiddlePoint;

		// Token: 0x040004AC RID: 1196
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_lastBendGoalDirection;
	}
}
