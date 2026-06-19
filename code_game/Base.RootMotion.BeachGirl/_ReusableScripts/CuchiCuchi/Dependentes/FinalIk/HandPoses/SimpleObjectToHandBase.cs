using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.HandPoses
{
	// Token: 0x02000089 RID: 137
	public abstract class SimpleObjectToHandBase<TPose> : CustomUpdatedMonobehaviourBase where TPose : Poser
	{
		// Token: 0x06000573 RID: 1395 RVA: 0x0001B800 File Offset: 0x00019A00
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.handPose == null)
			{
				throw new ArgumentNullException("handPose", "handPose null reference.");
			}
			if (this.Prefab == null)
			{
				throw new ArgumentNullException("Prefab", "Prefab null reference.");
			}
			Animator componentInChildren = base.GetComponentInParent<ICharacter>().GetComponentInChildren<Animator>();
			Side side = this.m_side;
			Transform transform;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
				transform = componentInChildren.GetBoneTransform(HumanBodyBones.RightHand);
			}
			else
			{
				transform = componentInChildren.GetBoneTransform(HumanBodyBones.LeftHand);
			}
			this.m_HandPoser = transform.GetComponentNotNull<TPose>();
			this.m_HandPoser.weight = 1f;
			this.m_HandPoser.poseRoot = this.handPose;
			this.m_HandPoser.SetAnimator(componentInChildren);
			this.m_HandPoser.AutoMapping();
			this.m_HandPoser.InitiateComponent();
			GameObject gameObject = Object.Instantiate<GameObject>(this.Prefab);
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = this.m_PositionOffset;
			gameObject.transform.localRotation = Quaternion.identity;
			if (this.m_RotationOffset != Vector3.zero)
			{
				gameObject.transform.localRotation = Quaternion.Euler(this.m_RotationOffset);
			}
		}

		// Token: 0x040003C0 RID: 960
		public Transform handPose;

		// Token: 0x040003C1 RID: 961
		public GameObject Prefab;

		// Token: 0x040003C2 RID: 962
		[SerializeField]
		private Vector3 m_RotationOffset;

		// Token: 0x040003C3 RID: 963
		[SerializeField]
		private Vector3 m_PositionOffset;

		// Token: 0x040003C4 RID: 964
		[SerializeField]
		private Side m_side;

		// Token: 0x040003C5 RID: 965
		[ReadOnlyUI]
		[SerializeField]
		private TPose m_HandPoser;
	}
}
