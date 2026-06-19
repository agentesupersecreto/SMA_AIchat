using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000078 RID: 120
	public class HeadLookAtSolver : CustomMonobehaviour
	{
		// Token: 0x1400003D RID: 61
		// (add) Token: 0x0600048D RID: 1165 RVA: 0x0001572C File Offset: 0x0001392C
		// (remove) Token: 0x0600048E RID: 1166 RVA: 0x00015764 File Offset: 0x00013964
		public event Action<HeadLookAtSolver> onPreSolve;

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x0600048F RID: 1167 RVA: 0x0001579C File Offset: 0x0001399C
		// (remove) Token: 0x06000490 RID: 1168 RVA: 0x000157D4 File Offset: 0x000139D4
		public event Action<HeadLookAtSolver> onPostSolve;

		// Token: 0x06000491 RID: 1169 RVA: 0x00015809 File Offset: 0x00013A09
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0001581D File Offset: 0x00013A1D
		public void Init()
		{
			this.Init(base.GetComponentInParent<ICharacter>().bodyAnimator);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00015830 File Offset: 0x00013A30
		public void Init(Animator animator)
		{
			if (animator == null)
			{
				throw new ArgumentNullException("animator", "animator null reference.");
			}
			this.m_Animator = animator;
			this.head = this.m_Animator.GetBoneTransform(HumanBodyBones.Head);
			this.m_initialLocalHeadForward = this.head.InverseTransformDirection(this.m_Animator.transform.forward);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001589D File Offset: 0x00013A9D
		public bool IsValid()
		{
			return this.head != null;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000158AB File Offset: 0x00013AAB
		public void Solve()
		{
			Action<HeadLookAtSolver> action = this.onPreSolve;
			if (action != null)
			{
				action(this);
			}
			this.SolveHead();
			Action<HeadLookAtSolver> action2 = this.onPostSolve;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x000158D8 File Offset: 0x00013AD8
		private void SolveHead()
		{
			if (this.IKPositionWeight * this.headWeight <= 0f)
			{
				return;
			}
			Vector3 vector = this.head.TransformDirection(this.m_initialLocalHeadForward);
			Vector3 normalized = (this.IKPosition - this.head.transform.position).normalized;
			Vector3 normalized2 = Vector3.Lerp(vector, normalized, this.IKPositionWeight * this.headWeight).normalized;
			this.GetForward(ref this.headForward, vector, normalized2, this.clampWeightHead);
			this.LookAt(vector, this.headForward, this.IKPositionWeight * this.headWeight);
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001597C File Offset: 0x00013B7C
		private Vector3 GetForward(ref Vector3 forward, Vector3 baseForward, Vector3 targetForward, float clamp)
		{
			if (clamp >= 1f || this.IKPositionWeight <= 0f)
			{
				forward = baseForward;
				return forward;
			}
			float num = Vector3.Angle(baseForward, targetForward);
			float num2 = 1f - num / 180f;
			float num3 = ((clamp > 0f) ? Mathf.Clamp(1f - (clamp - num2) / (1f - num2), 0f, 1f) : 1f);
			float num4 = ((clamp > 0f) ? Mathf.Clamp(num2 / clamp, 0f, 1f) : 1f);
			for (int i = 0; i < this.clampSmoothing; i++)
			{
				num4 = Mathf.Sin(num4 * 3.1415927f * 0.5f);
			}
			forward = Vector3.Slerp(baseForward, targetForward, num4 * num3);
			return forward;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00015A58 File Offset: 0x00013C58
		private void LookAt(Vector3 forward, Vector3 direction, float weight)
		{
			Quaternion quaternion = Quaternion.FromToRotation(forward, direction);
			Quaternion rotation = this.head.rotation;
			this.head.rotation = Quaternion.Lerp(rotation, quaternion * rotation, weight);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00015A94 File Offset: 0x00013C94
		private void OnDrawGizmosSelected()
		{
			Color green = Color.green;
			green.a = this.IKPositionWeight;
			DebugExtension.DrawPoint(this.IKPosition, green, 0.25f);
		}

		// Token: 0x04000302 RID: 770
		[Range(0f, 1f)]
		public float IKPositionWeight = 1f;

		// Token: 0x04000303 RID: 771
		public Vector3 IKPosition;

		// Token: 0x04000304 RID: 772
		[Range(0f, 1f)]
		public float headWeight = 1f;

		// Token: 0x04000305 RID: 773
		[Range(0f, 2f)]
		public int clampSmoothing = 2;

		// Token: 0x04000306 RID: 774
		[Range(0f, 1f)]
		public float clampWeightHead = 0.5f;

		// Token: 0x04000307 RID: 775
		public Transform head;

		// Token: 0x04000308 RID: 776
		[SerializeField]
		protected Animator m_Animator;

		// Token: 0x0400030B RID: 779
		private Vector3 headForward;

		// Token: 0x0400030C RID: 780
		private Vector3 m_initialLocalHeadForward;
	}
}
