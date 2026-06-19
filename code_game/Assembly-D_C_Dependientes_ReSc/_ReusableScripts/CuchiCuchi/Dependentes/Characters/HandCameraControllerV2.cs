using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000227 RID: 551
	[RequireComponent(typeof(HandControllerV2))]
	public class HandCameraControllerV2 : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000E16 RID: 3606 RVA: 0x0003EA18 File Offset: 0x0003CC18
		// (remove) Token: 0x06000E17 RID: 3607 RVA: 0x0003EA50 File Offset: 0x0003CC50
		public event UpdatingHandPositionV2 updatingHandPosition;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000E18 RID: 3608 RVA: 0x0003EA88 File Offset: 0x0003CC88
		// (remove) Token: 0x06000E19 RID: 3609 RVA: 0x0003EAC0 File Offset: 0x0003CCC0
		public event Action updatedHandPosition;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000E1A RID: 3610 RVA: 0x0003EAF8 File Offset: 0x0003CCF8
		// (remove) Token: 0x06000E1B RID: 3611 RVA: 0x0003EB30 File Offset: 0x0003CD30
		public event UpdatingHandPositionV2 updatingHandPositionPhysics;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000E1C RID: 3612 RVA: 0x0003EB68 File Offset: 0x0003CD68
		// (remove) Token: 0x06000E1D RID: 3613 RVA: 0x0003EBA0 File Offset: 0x0003CDA0
		public event Action updatedHandPositionPhysics;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000E1E RID: 3614 RVA: 0x0003EBD8 File Offset: 0x0003CDD8
		// (remove) Token: 0x06000E1F RID: 3615 RVA: 0x0003EC10 File Offset: 0x0003CE10
		[Obsolete("", true)]
		public event UpdatingHandPositionFixing updatingHandPositionFixing1;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000E20 RID: 3616 RVA: 0x0003EC48 File Offset: 0x0003CE48
		// (remove) Token: 0x06000E21 RID: 3617 RVA: 0x0003EC80 File Offset: 0x0003CE80
		[Obsolete("", true)]
		public event UpdatingHandPositionFixing updatingHandPositionFixing2;

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000E22 RID: 3618 RVA: 0x0003ECB5 File Offset: 0x0003CEB5
		protected bool IsActivated
		{
			get
			{
				return this.m_HandController.currentPose != null && base.isActiveAndEnabled && this.activado;
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x0003ECDA File Offset: 0x0003CEDA
		[Obsolete("", true)]
		public Camera referenceCamera
		{
			get
			{
				return this.m_mainCamera;
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x0003ECE2 File Offset: 0x0003CEE2
		[Obsolete("", true)]
		public Transform referenceCameraTransform
		{
			get
			{
				return this.m_mainCamera.transform;
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x0003ECEF File Offset: 0x0003CEEF
		public HandControllerV2 handController
		{
			get
			{
				return this.m_HandController;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000E26 RID: 3622 RVA: 0x0003ECF7 File Offset: 0x0003CEF7
		public bool handWasMoved
		{
			get
			{
				return this.m_isMovingHand && this.activado && this.puedeMoverHand && base.enabled;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x0003ED19 File Offset: 0x0003CF19
		public Transform hand
		{
			get
			{
				return this.m_hand;
			}
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x0003ED24 File Offset: 0x0003CF24
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
			this.m_HandController = base.GetComponent<HandControllerV2>();
			this.fixingRotationOffSet = Quaternion.identity;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x0003ED94 File Offset: 0x0003CF94
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IIKUpdater.onSingleIKUpdatingPass1 += this.M_IIKUpdater_passing;
			this.m_IIKUpdater.onPhysicsIKUpdating += this.M_IIKUpdater_onPhysicsIKUpdating;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x0003EDCA File Offset: 0x0003CFCA
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onSingleIKUpdatingPass1 -= this.M_IIKUpdater_passing;
				this.m_IIKUpdater.onPhysicsIKUpdating -= this.M_IIKUpdater_onPhysicsIKUpdating;
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x0003EE0C File Offset: 0x0003D00C
		public void Init(Side side)
		{
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
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
			switch (side)
			{
			case Side.L:
				this.m_hand = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftHand);
				this.m_forearm = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
				this.m_arm = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
				goto IL_0116;
			case Side.R:
				this.m_hand = this.m_Animator.GetBoneTransform(HumanBodyBones.RightHand);
				this.m_forearm = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
				this.m_arm = this.m_Animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
				goto IL_0116;
			}
			throw new ArgumentOutOfRangeException();
			IL_0116:
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x0003EF3B File Offset: 0x0003D13B
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
			if (PassEventData.esUltimo && this.IsActivated)
			{
				this.UpdateHandTransform();
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x0003EF70 File Offset: 0x0003D170
		private void M_IIKUpdater_onPhysicsIKUpdating(IIKUpdater obj)
		{
			Transform currentPose = this.m_HandController.currentPose;
			if (currentPose == null)
			{
				return;
			}
			if (this.puedeMoverHand)
			{
				UpdatingHandPositionV2 updatingHandPositionV = this.updatingHandPositionPhysics;
				if (updatingHandPositionV != null)
				{
					updatingHandPositionV(ref this.userDefinedPosition, ref this.userDefinedRotation, this.m_hand, currentPose, this);
				}
				currentPose.SetPositionAndRotation(this.userDefinedPosition, this.userDefinedRotation);
				Action action = this.updatedHandPositionPhysics;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x0003E0FA File Offset: 0x0003C2FA
		protected sealed override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x0003EFE4 File Offset: 0x0003D1E4
		private void UpdateHandTransform()
		{
			Transform currentPose = this.m_HandController.currentPose;
			if (currentPose == null)
			{
				return;
			}
			CurrentMainChar.ICamera camara = Singleton<CurrentMainChar>.instance.camara;
			Camera camera = ((camara != null) ? camara.camara : null);
			if (camera == null)
			{
				return;
			}
			if (this.viewPortPositionContainer == null)
			{
				return;
			}
			if (this.depthPositionContainer == null)
			{
				return;
			}
			Vector2 viewportPosition = this.viewPortPositionContainer.viewportPosition;
			float depthPosition = this.depthPositionContainer.depthPosition;
			this.cameraRotationOnHandTransformUpdate = camera.transform.rotation;
			this.userDefinedPosition = camera.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, this.depthPositionContainer.defaultDepth));
			this.userDefinedPosition += camera.transform.forward * depthPosition;
			Quaternion currentDefOffset = this.m_HandController.currentDefOffset;
			this.userDefinedRotation = this.cameraRotationOnHandTransformUpdate * this.userRotationOffSet * currentDefOffset;
			if (!this.m_HandController.usarRotationMetodoViejo)
			{
				Vector2 viewportLookAtPosition = this.viewPortPositionContainer.viewportLookAtPosition;
				Vector3 vector = camera.transform.forward * 1f + camera.transform.right * ((viewportLookAtPosition.x - 0.5f) * 2f) + camera.transform.up * ((viewportLookAtPosition.y - 0.5f) * 2f);
				Quaternion quaternion = camera.transform.rotation * currentDefOffset;
				Vector3 vector2 = Quaternion.Inverse(quaternion) * camera.transform.up;
				Vector3 vector3 = Quaternion.Inverse(quaternion) * camera.transform.forward;
				Vector3 vector4 = Quaternion.Inverse(quaternion) * vector;
				Quaternion quaternion2 = Quaternion.LookRotation(vector3, vector2);
				Quaternion quaternion3 = Quaternion.LookRotation(vector4, vector2) * Quaternion.Inverse(quaternion2);
				this.userDefinedRotation *= quaternion3;
			}
			this.m_isMovingHand = !ExtendedMonoBehaviour.AlmostEqual(currentPose.position, this.userDefinedPosition, 0.01f) || !ExtendedMonoBehaviour.AlmostEqual(currentPose.rotation, this.userDefinedRotation, 0.1f);
			Vector3 vector5 = this.userDefinedPosition;
			vector5 += this.fixingPositionOffSet;
			if (this.limitarDistancia)
			{
				vector5 = this.LimitarDistanciaHaciaHombroV2(vector5, camera.transform.forward);
			}
			if (this.limitarAngulo)
			{
				vector5 = this.LimitarAngulo(vector5);
			}
			else
			{
				this.m_limiteAnguloSobrepasado = false;
			}
			Quaternion quaternion4 = this.userDefinedRotation * this.fixingRotationOffSet;
			UpdatingHandPositionV2 updatingHandPositionV = this.updatingHandPosition;
			if (updatingHandPositionV != null)
			{
				updatingHandPositionV(ref vector5, ref quaternion4, this.m_hand, currentPose, this);
			}
			this.fixingPositionOffSet = Vector3.MoveTowards(this.fixingPositionOffSet, Vector3.zero, Time.deltaTime * 0.1f * this.fixPositionRestoreVelocity);
			this.fixingRotationOffSet = Quaternion.RotateTowards(this.fixingRotationOffSet, Quaternion.identity, Time.deltaTime * 360f * this.fixRotationRestoreVelocity);
			if (this.puedeMoverHand)
			{
				currentPose.position = Vector3.SmoothDamp(currentPose.position, vector5, ref this.m_vel, this.m_limiteAnguloSobrepasado ? (this.m_SmoothTime * 20f) : this.m_SmoothTime, this.m_limiteAnguloSobrepasado ? (this.m_MaxSpeed / 20f) : this.m_MaxSpeed, Time.deltaTime);
				currentPose.rotation = quaternion4;
			}
			Action action = this.updatedHandPosition;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x0003F35C File Offset: 0x0003D55C
		[Obsolete("", true)]
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

		// Token: 0x06000E31 RID: 3633 RVA: 0x0003F434 File Offset: 0x0003D634
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

		// Token: 0x06000E32 RID: 3634 RVA: 0x0003F524 File Offset: 0x0003D724
		private Vector3 LimitarDistanciaHaciaHombroV2(Vector3 target, Vector3 forward)
		{
			Vector3 vector = this.LimitarDistanciaHaciaHombro(target);
			return Math3d.ProjectPointOnLine(target, forward, vector);
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x0003F544 File Offset: 0x0003D744
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

		// Token: 0x040009A4 RID: 2468
		public bool activado;

		// Token: 0x040009A5 RID: 2469
		public float fixPositionRestoreVelocity = 2f;

		// Token: 0x040009A6 RID: 2470
		public float fixRotationRestoreVelocity = 2f;

		// Token: 0x040009A7 RID: 2471
		private UpdateAutoId m_updateId;

		// Token: 0x040009A8 RID: 2472
		[Obsolete("", true)]
		public float positionWeigth;

		// Token: 0x040009A9 RID: 2473
		[Obsolete("", true)]
		public float rotationWeigth;

		// Token: 0x040009AA RID: 2474
		[SerializeField]
		private float handGointOutSpeed = 5f;

		// Token: 0x040009AB RID: 2475
		[SerializeField]
		private float handGointOutSpeedInPower = 1.2f;

		// Token: 0x040009AC RID: 2476
		[SerializeField]
		private float handGointInSpeed = 3f;

		// Token: 0x040009AD RID: 2477
		[SerializeField]
		private float handGointInSpeedInPower = 0.5f;

		// Token: 0x040009AE RID: 2478
		private Transform m_hand;

		// Token: 0x040009AF RID: 2479
		private Transform m_forearm;

		// Token: 0x040009B0 RID: 2480
		private Transform m_arm;

		// Token: 0x040009B1 RID: 2481
		private Animator m_Animator;

		// Token: 0x040009B2 RID: 2482
		private Character m_character;

		// Token: 0x040009B3 RID: 2483
		[Obsolete("", true)]
		private HandPoser handPoser;

		// Token: 0x040009BA RID: 2490
		public IViewPortPositionContainer viewPortPositionContainer;

		// Token: 0x040009BB RID: 2491
		public IDepthPositionContainer depthPositionContainer;

		// Token: 0x040009BC RID: 2492
		public Vector3 userDefinedPosition;

		// Token: 0x040009BD RID: 2493
		public Quaternion userDefinedRotation;

		// Token: 0x040009BE RID: 2494
		public Quaternion cameraRotationOnHandTransformUpdate;

		// Token: 0x040009BF RID: 2495
		public Quaternion userRotationOffSet;

		// Token: 0x040009C0 RID: 2496
		public Vector3 fixingPositionOffSet;

		// Token: 0x040009C1 RID: 2497
		public Quaternion fixingRotationOffSet;

		// Token: 0x040009C2 RID: 2498
		[SerializeField]
		private float m_minModBrazoLargo = 0.4f;

		// Token: 0x040009C3 RID: 2499
		[SerializeField]
		private float m_maxModBrazoLargo = 1.2f;

		// Token: 0x040009C4 RID: 2500
		public bool limitarDistancia = true;

		// Token: 0x040009C5 RID: 2501
		public bool limitarAngulo;

		// Token: 0x040009C6 RID: 2502
		public bool puedeMoverHand = true;

		// Token: 0x040009C7 RID: 2503
		[SerializeField]
		[Range(1f, 180f)]
		private float m_MaxBrazoAngle = 85f;

		// Token: 0x040009C8 RID: 2504
		[SerializeField]
		private float m_SmoothTime = 0.01f;

		// Token: 0x040009C9 RID: 2505
		[SerializeField]
		private float m_MaxSpeed = 20f;

		// Token: 0x040009CA RID: 2506
		private Vector3 m_vel;

		// Token: 0x040009CB RID: 2507
		[SerializeField]
		[ReadOnlyUI]
		private bool m_limiteAnguloSobrepasado;

		// Token: 0x040009CC RID: 2508
		private IIKUpdater m_IIKUpdater;

		// Token: 0x040009CD RID: 2509
		private Side m_side;

		// Token: 0x040009CE RID: 2510
		[Obsolete("", true)]
		private Camera m_mainCamera;

		// Token: 0x040009CF RID: 2511
		private HandControllerV2 m_HandController;

		// Token: 0x040009D0 RID: 2512
		[SerializeField]
		[ReadOnlyUI]
		private bool m_isMovingHand;

		// Token: 0x040009D1 RID: 2513
		[Obsolete("", true)]
		private FullBodyBipedIK m_ik;
	}
}
