using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000224 RID: 548
	[Obsolete]
	[RequireComponent(typeof(HandController))]
	public class HandCameraController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x0003DD22 File Offset: 0x0003BF22
		[Obsolete("", true)]
		public Quaternion worldDefaultRotation
		{
			get
			{
				return this.m_mainCamera.transform.rotation * this.m_HandController.currentDefOffset;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x0003DD44 File Offset: 0x0003BF44
		protected bool IsActivated
		{
			get
			{
				return this.m_HandController.currentPose != null && base.isActiveAndEnabled && this.activado;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x0003DD69 File Offset: 0x0003BF69
		public Camera referenceCamera
		{
			get
			{
				return this.m_mainCamera;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x0003DD71 File Offset: 0x0003BF71
		public Transform referenceCameraTransform
		{
			get
			{
				return this.m_mainCamera.transform;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x0003DD7E File Offset: 0x0003BF7E
		public HandController handController
		{
			get
			{
				return this.m_HandController;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x0003DD86 File Offset: 0x0003BF86
		public bool handWasMoved
		{
			get
			{
				return this.m_isMovingHand && this.activado && this.puedeMoverHand && base.enabled;
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000DF5 RID: 3573 RVA: 0x0003DDA8 File Offset: 0x0003BFA8
		// (remove) Token: 0x06000DF6 RID: 3574 RVA: 0x0003DDE0 File Offset: 0x0003BFE0
		public event UpdatingHandPosition updatingHandPosition;

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0003DE18 File Offset: 0x0003C018
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
			this.m_IIKUpdater = this.GetComponentEnCharacter(false);
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("iKBeforePhysicsV2", "iKBeforePhysicsV2 null reference.");
			}
			if (this.m_IIKUpdater.CantidadDePasadasDeIK(2) < 2)
			{
				throw new NotSupportedException();
			}
			this.m_HandController = base.GetComponent<HandController>();
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x0003DE7D File Offset: 0x0003C07D
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IIKUpdater.onSingleIKUpdatingPass1 += this.M_IIKUpdater_passing;
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x0003DE9C File Offset: 0x0003C09C
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (base.isStared)
			{
				this.SetConfigs(false, 0f, 0f);
			}
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onSingleIKUpdatingPass1 -= this.M_IIKUpdater_passing;
			}
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x0003DEE8 File Offset: 0x0003C0E8
		public void Init(Side side)
		{
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_ik = this.m_character.GetComponentInChildren<FullBodyBipedIK>();
			this.m_Animator = this.m_character.GetComponentInChildren<Animator>();
			this.m_side = side;
			if (this.m_character == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			this.m_mainCamera = Camera.main;
			if (this.m_mainCamera == null)
			{
				throw new ArgumentNullException("m_mainCamera", "m_mainCamera null reference.");
			}
			switch (side)
			{
			case Side.L:
				this.m_hand = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftHand);
				this.m_forearm = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
				this.m_arm = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
				this.m_ChestBone = this.m_Animator.GetBoneTransform(HumanBodyBones.Chest);
				goto IL_0177;
			case Side.R:
				this.m_hand = this.m_Animator.GetBoneTransform(HumanBodyBones.RightHand);
				this.m_forearm = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
				this.m_arm = this.m_Animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
				this.m_ChestBone = this.m_Animator.GetBoneTransform(HumanBodyBones.Chest);
				goto IL_0177;
			}
			throw new ArgumentOutOfRangeException();
			IL_0177:
			this.handPoser = this.m_hand.GetComponentNotNull<HandPoser>();
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x00002BEA File Offset: 0x00000DEA
		[Obsolete("", true)]
		public void SetTarget()
		{
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00002BEA File Offset: 0x00000DEA
		[Obsolete("", true)]
		public void ClearTarget()
		{
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x0003E089 File Offset: 0x0003C289
		private void M_IIKUpdater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isInitiated)
			{
				return;
			}
			if (IKEventData.layer != 2 || !IKEventData.esUltimoDeLayer)
			{
				return;
			}
			if (PassEventData.index == 0)
			{
				this.M_iKBeforePhysicsV2_updatingFBBIK1();
			}
			if (PassEventData.esUltimo)
			{
				this.M_iKBeforePhysicsV2_updatingFBBIK2();
			}
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x0003E0C4 File Offset: 0x0003C2C4
		private void M_iKBeforePhysicsV2_updatingFBBIK1()
		{
			this.DisableManoIKPoserOnPass();
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x0003E0CC File Offset: 0x0003C2CC
		private void M_iKBeforePhysicsV2_updatingFBBIK2()
		{
			this.UpdateWeigth();
			this.SetConfigs(this.IsActivated, this.positionWeigth, this.rotationWeigth);
			if (this.IsActivated)
			{
				this.UpdatePoser();
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x0003E0FA File Offset: 0x0003C2FA
		protected sealed override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x0003E104 File Offset: 0x0003C304
		private void UpdatePoser()
		{
			Transform currentPose = this.m_HandController.currentPose;
			if (this.handPoser == null)
			{
				return;
			}
			if (currentPose == null)
			{
				return;
			}
			if (this.m_mainCamera == null)
			{
				return;
			}
			Vector3 vector = this.m_mainCamera.ViewportToWorldPoint(this.viewPointTarget);
			UpdatingHandPosition updatingHandPosition = this.updatingHandPosition;
			if (updatingHandPosition != null)
			{
				updatingHandPosition(ref vector, ref this.fixingPositionOffSet, this);
			}
			vector += this.fixingPositionOffSet;
			this.fixingPositionOffSet = Vector3.MoveTowards(this.fixingPositionOffSet, Vector3.zero, Time.deltaTime * this.fixPositionRestoreVelocity);
			if (this.limitarDistancia)
			{
				vector = this.LimitarDistanciaHaciaHombro(vector);
			}
			if (this.limitarAngulo)
			{
				vector = this.LimitarAngulo(vector);
			}
			else
			{
				this.m_limiteAnguloSobrepasado = false;
			}
			Quaternion quaternion = this.m_mainCamera.transform.rotation * this.fixingRotationOffSet * this.userRotationOffSet * this.m_HandController.currentDefOffset;
			this.fixingRotationOffSet = Quaternion.RotateTowards(this.fixingRotationOffSet, Quaternion.identity, Time.deltaTime * 360f * this.fixRotationRestoreVelocity);
			this.m_isMovingHand = !ExtendedMonoBehaviour.AlmostEqual(currentPose.position, vector, 0.001f) || !ExtendedMonoBehaviour.AlmostEqual(currentPose.rotation, quaternion, 0.1f);
			if (this.puedeMoverHand)
			{
				currentPose.position = Vector3.SmoothDamp(currentPose.position, vector, ref this.m_vel, this.m_limiteAnguloSobrepasado ? (this.m_SmoothTime * 20f) : this.m_SmoothTime, this.m_limiteAnguloSobrepasado ? (this.m_MaxSpeed / 20f) : this.m_MaxSpeed, Time.deltaTime);
				currentPose.rotation = quaternion;
			}
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x0003E2BC File Offset: 0x0003C4BC
		private void UpdateWeigth()
		{
			if (this.m_updateId.IsCurrent())
			{
				return;
			}
			this.m_updateId = UpdateAutoId.current;
			if (this.IsActivated)
			{
				float num = Mathf.Max((1f - this.positionWeigth).InPow(this.handGointOutSpeedInPower), 0.005f);
				this.positionWeigth = Mathf.MoveTowards(this.positionWeigth, 1f, Time.deltaTime * this.handGointOutSpeed * num);
			}
			else
			{
				float num2 = Mathf.Max((1f - this.positionWeigth).InPow(this.handGointInSpeedInPower), 0.005f);
				this.positionWeigth = Mathf.MoveTowards(this.positionWeigth, 0f, Time.deltaTime * this.handGointInSpeed * num2);
			}
			this.rotationWeigth = Mathf.InverseLerp(0.666f, 1f, this.positionWeigth);
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0003E394 File Offset: 0x0003C594
		private void DisableManoIKPoserOnPass()
		{
			IKEffector handEfector = this.GetHandEfector();
			FBIKChain chain = this.GetChain();
			this.handPoser.weight = 0f;
			handEfector.positionWeight = 0f;
			handEfector.rotationWeight = 0f;
			chain.reach = 0.1f;
			chain.pull = 1f;
			chain.push = 0f;
			chain.pushParent = 0f;
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x0003E400 File Offset: 0x0003C600
		private void SetConfigs(bool mostrandoMano, float wPosition, float wRotation)
		{
			Transform currentPose = this.m_HandController.currentPose;
			IKEffector handEfector = this.GetHandEfector();
			FBIKChain chain = this.GetChain();
			if (mostrandoMano)
			{
				if (this.handPoser.poseRoot != currentPose)
				{
					this.handPoser.poseRoot = currentPose;
					this.handPoser.fixTransforms = true;
					this.handPoser.localRotationWeight = 1f;
					this.handPoser.localPositionWeight = 0f;
				}
				if (handEfector.target != currentPose)
				{
					handEfector.target = currentPose;
					chain.pull = 0f;
					chain.reach = 0.05f;
					chain.push = 0.05f;
					chain.pushParent = 1f;
					this.GetMaping().weight = 1f;
				}
			}
			else
			{
				chain.reach = Mathf.Lerp(0.1f, chain.reach, wPosition);
				chain.pull = Mathf.Lerp(1f, chain.pull, wPosition);
				chain.push = Mathf.Lerp(0f, chain.push, wPosition);
				chain.pushParent = Mathf.Lerp(0f, chain.pushParent, wPosition);
				if (wPosition == 0f)
				{
					if (this.handPoser.poseRoot != null)
					{
						this.handPoser.poseRoot = null;
						this.handPoser.fixTransforms = true;
						this.handPoser.localRotationWeight = 1f;
						this.handPoser.localPositionWeight = 0f;
					}
					if (handEfector.target != null)
					{
						handEfector.target = null;
					}
				}
			}
			this.handPoser.weight = wPosition.OutPow(2f);
			handEfector.positionWeight = wPosition;
			handEfector.rotationWeight = wRotation;
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00002BEA File Offset: 0x00000DEA
		[Obsolete("", true)]
		private void OnWOne(IKEffector handEfector, FBIKChain handChain)
		{
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x0003E5BC File Offset: 0x0003C7BC
		[Obsolete("", true)]
		private void OnWZero(IKEffector handEfector, FBIKChain handChain)
		{
			if (this.handPoser.poseRoot != null)
			{
				this.handPoser.poseRoot = null;
				this.handPoser.fixTransforms = true;
				this.handPoser.weight = 0f;
				this.handPoser.localRotationWeight = 1f;
				this.handPoser.localPositionWeight = 0f;
			}
			if (handEfector.target != null)
			{
				handEfector.target = null;
				handChain.reach = 0.1f;
				handChain.pull = 1f;
				handChain.push = 0f;
				handChain.pushParent = 0f;
			}
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0003E668 File Offset: 0x0003C868
		private Vector3 LimitarAngulo(Vector3 target)
		{
			Vector3 centerOfMassForwardDirection = this.m_character.centerOfMassForwardDirection;
			Vector3 vector = target - this.m_arm.position;
			float num = Vector3.Angle(centerOfMassForwardDirection, vector);
			if (this.m_MaxBrazoAngle > num)
			{
				this.m_limiteAnguloSobrepasado = false;
				return target;
			}
			this.m_limiteAnguloSobrepasado = true;
			Quaternion quaternion = Quaternion.LookRotation(centerOfMassForwardDirection, this.m_character.centerOfMassUpDirection);
			float num2;
			Vector3 vector2;
			(Quaternion.Inverse(quaternion) * Quaternion.LookRotation(vector, this.m_character.centerOfMassUpDirection)).ToAngleAxis(out num2, out vector2);
			if (num2 > 180f)
			{
				vector2 *= -1f;
			}
			Quaternion quaternion2 = Quaternion.AngleAxis((num > this.m_MaxBrazoAngle) ? this.m_MaxBrazoAngle : num, vector2);
			Vector3 vector3 = quaternion * quaternion2 * Vector3.forward;
			return this.m_arm.position + vector3.normalized * vector.magnitude;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x0003E758 File Offset: 0x0003C958
		private Vector3 LimitarDistanciaHaciaHombro(Vector3 target)
		{
			float num = Vector3.Distance(this.m_hand.position, this.m_forearm.position) + Vector3.Distance(this.m_arm.position, this.m_forearm.position);
			float num2 = num * this.m_minModBrazoLargo;
			float num3 = num * this.m_maxModBrazoLargo;
			Vector3 vector = target - this.m_arm.position;
			float magnitude = vector.magnitude;
			if (magnitude < num2)
			{
				target = this.m_arm.position + vector.normalized * num2;
			}
			else if (magnitude > num3)
			{
				target = this.m_arm.position + vector.normalized * num3;
			}
			return target;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x0003E810 File Offset: 0x0003CA10
		private IKEffector GetHandEfector()
		{
			switch (this.m_side)
			{
			case Side.L:
				return this.m_ik.solver.GetEffector(FullBodyBipedEffector.LeftHand);
			case Side.R:
				return this.m_ik.solver.GetEffector(FullBodyBipedEffector.RightHand);
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0003E86C File Offset: 0x0003CA6C
		private IKEffector GetHormbroEfector()
		{
			switch (this.m_side)
			{
			case Side.L:
				return this.m_ik.solver.GetEffector(FullBodyBipedEffector.LeftShoulder);
			case Side.R:
				return this.m_ik.solver.GetEffector(FullBodyBipedEffector.RightShoulder);
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x0003E8C8 File Offset: 0x0003CAC8
		private FBIKChain GetChain()
		{
			switch (this.m_side)
			{
			case Side.L:
				return this.m_ik.solver.GetChain(FullBodyBipedEffector.LeftHand);
			case Side.R:
				return this.m_ik.solver.GetChain(FullBodyBipedEffector.RightHand);
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x0003E924 File Offset: 0x0003CB24
		private IKMappingLimb GetMaping()
		{
			switch (this.m_side)
			{
			case Side.L:
				return this.m_ik.solver.leftArmMapping;
			case Side.R:
				return this.m_ik.solver.rightArmMapping;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0400097C RID: 2428
		public bool activado;

		// Token: 0x0400097D RID: 2429
		public float fixPositionRestoreVelocity = 2f;

		// Token: 0x0400097E RID: 2430
		public float fixRotationRestoreVelocity = 2f;

		// Token: 0x0400097F RID: 2431
		private UpdateAutoId m_updateId;

		// Token: 0x04000980 RID: 2432
		[Range(0f, 1f)]
		public float positionWeigth;

		// Token: 0x04000981 RID: 2433
		[Range(0f, 1f)]
		public float rotationWeigth;

		// Token: 0x04000982 RID: 2434
		[SerializeField]
		private float handGointOutSpeed = 5f;

		// Token: 0x04000983 RID: 2435
		[SerializeField]
		private float handGointOutSpeedInPower = 1.2f;

		// Token: 0x04000984 RID: 2436
		[SerializeField]
		private float handGointInSpeed = 3f;

		// Token: 0x04000985 RID: 2437
		[SerializeField]
		private float handGointInSpeedInPower = 0.5f;

		// Token: 0x04000986 RID: 2438
		private Transform m_hand;

		// Token: 0x04000987 RID: 2439
		private Transform m_forearm;

		// Token: 0x04000988 RID: 2440
		private Transform m_arm;

		// Token: 0x04000989 RID: 2441
		[Obsolete("", true)]
		private Transform m_head;

		// Token: 0x0400098A RID: 2442
		private Transform m_ChestBone;

		// Token: 0x0400098B RID: 2443
		private FullBodyBipedIK m_ik;

		// Token: 0x0400098C RID: 2444
		private Animator m_Animator;

		// Token: 0x0400098D RID: 2445
		private Character m_character;

		// Token: 0x0400098E RID: 2446
		[SerializeField]
		[ReadOnlyUI]
		private HandPoser handPoser;

		// Token: 0x0400098F RID: 2447
		[Obsolete("", true)]
		private Transform handTarget;

		// Token: 0x04000990 RID: 2448
		public Vector3 viewPointTarget;

		// Token: 0x04000991 RID: 2449
		public Quaternion userRotationOffSet;

		// Token: 0x04000992 RID: 2450
		public Vector3 fixingPositionOffSet;

		// Token: 0x04000993 RID: 2451
		public Quaternion fixingRotationOffSet;

		// Token: 0x04000994 RID: 2452
		[SerializeField]
		private float m_minModBrazoLargo = 0.4f;

		// Token: 0x04000995 RID: 2453
		[SerializeField]
		private float m_maxModBrazoLargo = 1.2f;

		// Token: 0x04000996 RID: 2454
		public bool limitarDistancia = true;

		// Token: 0x04000997 RID: 2455
		public bool limitarAngulo;

		// Token: 0x04000998 RID: 2456
		public bool puedeMoverHand = true;

		// Token: 0x04000999 RID: 2457
		[SerializeField]
		[Range(1f, 180f)]
		private float m_MaxBrazoAngle = 85f;

		// Token: 0x0400099A RID: 2458
		[SerializeField]
		private float m_SmoothTime = 0.01f;

		// Token: 0x0400099B RID: 2459
		[SerializeField]
		private float m_MaxSpeed = 20f;

		// Token: 0x0400099C RID: 2460
		private Vector3 m_vel;

		// Token: 0x0400099D RID: 2461
		[SerializeField]
		[ReadOnlyUI]
		private bool m_limiteAnguloSobrepasado;

		// Token: 0x0400099E RID: 2462
		private IIKUpdater m_IIKUpdater;

		// Token: 0x0400099F RID: 2463
		private Side m_side;

		// Token: 0x040009A0 RID: 2464
		private Camera m_mainCamera;

		// Token: 0x040009A1 RID: 2465
		private HandController m_HandController;

		// Token: 0x040009A2 RID: 2466
		[SerializeField]
		[ReadOnlyUI]
		private bool m_isMovingHand;
	}
}
