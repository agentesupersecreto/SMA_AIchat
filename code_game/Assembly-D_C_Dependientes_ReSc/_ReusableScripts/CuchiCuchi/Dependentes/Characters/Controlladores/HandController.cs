using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores
{
	// Token: 0x0200023D RID: 573
	[Obsolete]
	public class HandController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00043574 File Offset: 0x00041774
		public Transform currentPose
		{
			get
			{
				return this.GetCurrentPose();
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000F20 RID: 3872 RVA: 0x0004357C File Offset: 0x0004177C
		public Quaternion currentDefOffset
		{
			get
			{
				return this.GetCurrentDefOffset();
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x00043584 File Offset: 0x00041784
		public HandCameraController handCameraController
		{
			get
			{
				return this.m_handCameraController;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x0004358C File Offset: 0x0004178C
		public FingerPhyscisController fingerPhyscisController
		{
			get
			{
				return this.m_FingerPhyscisController;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x00043594 File Offset: 0x00041794
		public bool isMovingHand
		{
			get
			{
				return this.m_handCameraController.handWasMoved && base.enabled;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x000435AB File Offset: 0x000417AB
		public float handUserWeight
		{
			get
			{
				return this.m_handCameraController.positionWeigth;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x000435B8 File Offset: 0x000417B8
		public Quaternion armatureOrientationOffSet
		{
			get
			{
				return this.m_Character.armatureOrientationOffSet;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x000435C5 File Offset: 0x000417C5
		public Quaternion skeletonRotationFix
		{
			get
			{
				return this.m_RotationMatrix;
			}
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x000435D0 File Offset: 0x000417D0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_RotationMatrix = Quaternion.LookRotation(this.m_handForward, this.m_handUp);
			this.m_Character = base.GetComponentInParent<Character>();
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_handCameraController = this.GetComponentNotNull<HandCameraController>();
			this.m_head = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			this.m_defOffsetMassage = Quaternion.Inverse(this.m_head.rotation) * this.m_masagePose.rotation;
			this.m_defOffsetFinger = Quaternion.Inverse(this.m_head.rotation) * this.m_fingerPose.rotation;
			base.SetYieldStart();
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x0004369C File Offset: 0x0004189C
		private Transform GetCurrentPose()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.massage:
				return this.m_masagePose;
			case HandTipoDePose.finger:
				return this.m_fingerPose;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x000436E8 File Offset: 0x000418E8
		private Quaternion GetCurrentDefOffset()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.massage:
				return this.m_defOffsetMassage;
			case HandTipoDePose.finger:
				return this.m_defOffsetFinger;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F2A RID: 3882 RVA: 0x00043734 File Offset: 0x00041934
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_handCameraController.activado = true;
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00043748 File Offset: 0x00041948
		protected override IEnumerator YieldStartUnityEvent()
		{
			do
			{
				yield return null;
				this.m_FingerPhyscisController = this.GetComponentEnRoot(true);
			}
			while (this.m_FingerPhyscisController == null);
			this.m_handCameraController.Init(this.side);
			yield break;
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x00043757 File Offset: 0x00041957
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_handCameraController.activado = false;
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0004376C File Offset: 0x0004196C
		public void MoveHandToViewPoint(Vector3 viewPoint)
		{
			this.m_handCameraController.viewPointTarget = viewPoint;
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0004377A File Offset: 0x0004197A
		public void ResetRotationOffset()
		{
			this.m_handCameraController.fixingRotationOffSet = Quaternion.identity;
			this.m_handCameraController.userRotationOffSet = Quaternion.identity;
			this.m_handCameraController.fixingPositionOffSet = Vector3.zero;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x000437AC File Offset: 0x000419AC
		public void SetRotationOffset(Quaternion offsetAngles)
		{
			this.m_handCameraController.userRotationOffSet = offsetAngles;
		}

		// Token: 0x04000A59 RID: 2649
		public Side side;

		// Token: 0x04000A5A RID: 2650
		public HandTipoDePose tipoDePose = HandTipoDePose.massage;

		// Token: 0x04000A5B RID: 2651
		[SerializeField]
		private Transform m_masagePose;

		// Token: 0x04000A5C RID: 2652
		[SerializeField]
		private Transform m_fingerPose;

		// Token: 0x04000A5D RID: 2653
		[SerializeField]
		private Quaternion m_defOffsetMassage;

		// Token: 0x04000A5E RID: 2654
		[SerializeField]
		private Quaternion m_defOffsetFinger;

		// Token: 0x04000A5F RID: 2655
		private Transform m_head;

		// Token: 0x04000A60 RID: 2656
		private Character m_Character;

		// Token: 0x04000A61 RID: 2657
		private FingerPhyscisController m_FingerPhyscisController;

		// Token: 0x04000A62 RID: 2658
		private HandCameraController m_handCameraController;

		// Token: 0x04000A63 RID: 2659
		[SerializeField]
		private Vector3 m_handForward = Vector3.up;

		// Token: 0x04000A64 RID: 2660
		[SerializeField]
		private Vector3 m_handUp = -Vector3.right;

		// Token: 0x04000A65 RID: 2661
		private Quaternion m_RotationMatrix;
	}
}
