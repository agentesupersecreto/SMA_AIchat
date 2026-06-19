using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Input;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.MotionControllers
{
	// Token: 0x02000164 RID: 356
	[MotionName("Tavo Testing Motion")]
	[MotionDescription("WoW style movement. When Rotate Action Alias is held, character rotates to the camera's forward. When not held, camera rotates to the character's forward.\r\n\r\nLeft/Right Action Alias = Strafe\r\nHorizontal movement keys = Rotate")]
	public class TavoTestingMotion : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x00027884 File Offset: 0x00025A84
		// (set) Token: 0x0600078C RID: 1932 RVA: 0x0002788C File Offset: 0x00025A8C
		public float minInputToWalk
		{
			get
			{
				return this._minInputToWalk;
			}
			set
			{
				this._minInputToWalk = value;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x00027895 File Offset: 0x00025A95
		// (set) Token: 0x0600078E RID: 1934 RVA: 0x0002789D File Offset: 0x00025A9D
		public int FormCondition
		{
			get
			{
				return this._FormCondition;
			}
			set
			{
				this._FormCondition = value;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x000278A6 File Offset: 0x00025AA6
		// (set) Token: 0x06000790 RID: 1936 RVA: 0x000278AE File Offset: 0x00025AAE
		public bool DefaultToRun
		{
			get
			{
				return this._DefaultToRun;
			}
			set
			{
				this._DefaultToRun = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x000278B8 File Offset: 0x00025AB8
		public bool IsRunActive
		{
			get
			{
				if (this.mMotionController.TargetNormalizedSpeed > 0f && this.mMotionController.TargetNormalizedSpeed <= 0.5f)
				{
					return false;
				}
				if (this.m_UnityInputSource == null)
				{
					return this._DefaultToRun;
				}
				return (this._DefaultToRun && !this.m_UnityInputSource.IsGoingFaster) || (!this._DefaultToRun && this.m_UnityInputSource.IsGoingFaster);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0002792C File Offset: 0x00025B2C
		// (set) Token: 0x06000793 RID: 1939 RVA: 0x00027934 File Offset: 0x00025B34
		[Obsolete("siempre va a estar activado")]
		public string StrafeLeftActionAlias
		{
			get
			{
				return this._StrafeLeftActionAlias;
			}
			set
			{
				this._StrafeLeftActionAlias = value;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0002793D File Offset: 0x00025B3D
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x00027945 File Offset: 0x00025B45
		[Obsolete("siempre va a estar activado")]
		public string StrafeRightActionAlias
		{
			get
			{
				return this._StrafeRightActionAlias;
			}
			set
			{
				this._StrafeRightActionAlias = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x0002794E File Offset: 0x00025B4E
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x00027956 File Offset: 0x00025B56
		public virtual float WalkSpeed
		{
			get
			{
				return this._WalkSpeed;
			}
			set
			{
				this._WalkSpeed = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x0002795F File Offset: 0x00025B5F
		// (set) Token: 0x06000799 RID: 1945 RVA: 0x00027967 File Offset: 0x00025B67
		public virtual float RunSpeed
		{
			get
			{
				return this._RunSpeed;
			}
			set
			{
				this._RunSpeed = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x00027970 File Offset: 0x00025B70
		// (set) Token: 0x0600079B RID: 1947 RVA: 0x00027978 File Offset: 0x00025B78
		public bool StartInMove
		{
			get
			{
				return this.mStartInMove;
			}
			set
			{
				this.mStartInMove = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x00027981 File Offset: 0x00025B81
		// (set) Token: 0x0600079D RID: 1949 RVA: 0x00027989 File Offset: 0x00025B89
		public bool StartInWalk
		{
			get
			{
				return this.mStartInWalk;
			}
			set
			{
				this.mStartInWalk = value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x00027992 File Offset: 0x00025B92
		// (set) Token: 0x0600079F RID: 1951 RVA: 0x0002799A File Offset: 0x00025B9A
		public bool StartInRun
		{
			get
			{
				return this.mStartInRun;
			}
			set
			{
				this.mStartInRun = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x000279A3 File Offset: 0x00025BA3
		// (set) Token: 0x060007A1 RID: 1953 RVA: 0x000279AB File Offset: 0x00025BAB
		[Obsolete("siempre va a estar activado")]
		public string RotateActionAlias
		{
			get
			{
				return this._RotateActionAlias;
			}
			set
			{
				this._RotateActionAlias = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x000279B4 File Offset: 0x00025BB4
		// (set) Token: 0x060007A3 RID: 1955 RVA: 0x000279BC File Offset: 0x00025BBC
		[Obsolete("Solo RotaraConCamara")]
		public bool RotateWithInput
		{
			get
			{
				return this._RotateWithInput;
			}
			set
			{
				this._RotateWithInput = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x000279C5 File Offset: 0x00025BC5
		// (set) Token: 0x060007A5 RID: 1957 RVA: 0x000279CD File Offset: 0x00025BCD
		public bool RotateWithCamera
		{
			get
			{
				return this._RotateWithCamera;
			}
			set
			{
				this._RotateWithCamera = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x000279D6 File Offset: 0x00025BD6
		// (set) Token: 0x060007A7 RID: 1959 RVA: 0x000279DE File Offset: 0x00025BDE
		public float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x000279E7 File Offset: 0x00025BE7
		// (set) Token: 0x060007A9 RID: 1961 RVA: 0x000279EF File Offset: 0x00025BEF
		public virtual float RotationSmoothing
		{
			get
			{
				return this._RotationSmoothing;
			}
			set
			{
				this._RotationSmoothing = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x000279F8 File Offset: 0x00025BF8
		// (set) Token: 0x060007AB RID: 1963 RVA: 0x00027A00 File Offset: 0x00025C00
		public int SmoothingSamples
		{
			get
			{
				return this._SmoothingSamples;
			}
			set
			{
				this._SmoothingSamples = value;
				this.mInputX.SampleCount = this._SmoothingSamples;
				this.mInputY.SampleCount = this._SmoothingSamples;
				this.mInputMagnitude_V2.ChangeCapacity(this._SmoothingSamples / 2);
			}
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00027A40 File Offset: 0x00025C40
		public TavoTestingMotion()
		{
			this._Category = 2;
			this._Priority = 2f;
			this._ActionAlias = "GoFaster";
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00027B04 File Offset: 0x00025D04
		public TavoTestingMotion(MotionController rController)
			: base(rController)
		{
			this._Category = 2;
			this._Priority = 2f;
			this._ActionAlias = "GoFaster";
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00027BC7 File Offset: 0x00025DC7
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00027BDC File Offset: 0x00025DDC
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			if (this.mMotionController.Stance != 0)
			{
				return false;
			}
			if (!Singleton<ConfiguracionGeneralUsuario>.IsInScene)
			{
				Debug.LogWarning("No existe configuracion de usuario", this.mMotionController);
				return false;
			}
			if (Singleton<ConfiguracionGeneralUsuario>.instance.heroConfig.movementSpeed != HeroConfig.MovementSpeed.slow)
			{
				return false;
			}
			if (this._FormCondition >= 0 && this.mMotionController.CurrentForm != this._FormCondition)
			{
				return false;
			}
			if (this.mMotionController._InputSource == null)
			{
				return false;
			}
			this.m_UnityInputSource = this.mMotionController._InputSource as UnityInputSource;
			if (this.m_UnityInputSource == null)
			{
				Debug.Log(base.GetType().Name + " necesita un " + typeof(UnityInputSource).Name, this.mMotionController);
				return false;
			}
			return Mathf.Abs(this.mMotionController.State.InputX) > this.minInputToWalk || Mathf.Abs(this.mMotionController.State.InputY) > this.minInputToWalk;
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00027D00 File Offset: 0x00025F00
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionController.IsGrounded && this.mMotionController.Stance == 0 && (this.mInputMagnitude_V2.suavizado != 0f || this.mMotionController.State.InputX != 0f) && this.mMotionLayer._AnimatorStateID != TavoTestingMotion.STATE_IdlePose && (!this.mIsAnimatorActive || this.IsInMotionState));
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00027D87 File Offset: 0x00025F87
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00027DC0 File Offset: 0x00025FC0
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this._ActionAlias = "GoFaster";
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mLinkRotation = false;
			this.mInputX.Clear(0f);
			this.mInputY.Clear(0f);
			this.mInputMagnitude_V2.Clear();
			this.m_CurrentRotationSpeed = 0f;
			this.mMotionController.MaxSpeed = 5.668f;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 17301, true);
			if (this.m_UnityInputSource == null)
			{
				Debug.Log(base.GetType().Name + " necesita un " + typeof(UnityInputSource).Name, this.mMotionController);
			}
			else
			{
				this.m_UnityInputSource.ViewActivator = 2;
			}
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00027F30 File Offset: 0x00026130
		public override void Deactivate()
		{
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00027F88 File Offset: 0x00026188
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			float num = (this.IsRunActive ? this._RunSpeed : this._WalkSpeed);
			if (num <= 0f)
			{
				if (this.mMotionController.State.InputX == 0f && rMovement.x > -0.01f && rMovement.x < 0.01f)
				{
					rMovement.x = 0f;
				}
				return;
			}
			if (rMovement.sqrMagnitude > 0f)
			{
				rMovement = rMovement.normalized * (num * rDeltaTime);
				return;
			}
			float num2 = 0f;
			float inputY = this.mMotionController.State.InputY;
			Vector3 vector = new Vector3(num2, 0f, inputY);
			rMovement = vector.normalized * (num * rDeltaTime);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0002805C File Offset: 0x0002625C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.m_CurrentRotationSpeed = Mathf.MoveTowards(this.m_CurrentRotationSpeed, this._RotationSpeed, rDeltaTime * 3f * 160f);
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.mForceRotationToCamera = true;
			float num = (this.IsRunActive ? 0.75f : 0.15f);
			MotionState state = this.mMotionController.State;
			float num2 = 0f;
			if (this.mForceRotationToCamera && num2 == 0f)
			{
				num2 = state.InputX;
			}
			float num3 = Mathf.Sqrt(num2 * num2 + state.InputY * state.InputY);
			num2 = Mathf.Clamp(num2, -num, num);
			float num4 = Mathf.Clamp(state.InputY, -num, num);
			num3 = Mathf.Clamp(num3, 0f, num);
			this.mInputX.Add(num2);
			this.mInputY.Add(num4);
			this.mInputMagnitude_V2.Add(num3);
			this.mMotionController.State.InputX = this.mInputX.Average;
			this.mMotionController.State.InputY = this.mInputY.Average;
			this.mMotionController.State.InputMagnitudeTrend.Replace(this.mInputMagnitude_V2.suavizado);
			if (this._RotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000281C8 File Offset: 0x000263C8
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = this.mMotionController._InputSource.MovementX * this.m_CurrentRotationSpeed * rDeltaTime;
			if (num == 0f && this.mMotionController._InputSource.IsViewingActivated)
			{
				num = this.mMotionController._InputSource.ViewX * this.m_CurrentRotationSpeed * rDeltaTime;
			}
			this.mYawTarget += num;
			num = ((this._RotationSmoothing <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, this._RotationSmoothing)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
			if ((num != 0f || this.mMotionController.State.InputMagnitudeTrend.Value > 0f) && this.mMotionController.CameraRig is BaseCameraRig)
			{
				((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x000282F8 File Offset: 0x000264F8
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this.mMotionController.enabled)
			{
				return;
			}
			if (!this.mForceRotationToCamera)
			{
				return;
			}
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = 0f;
			Vector3 vector = Quaternion.Inverse(rCamera.Anchor.rotation) * this.mMotionController._CameraTransform.rotation * Vector3.forward;
			Vector3 vector2 = Math3d.ProjectVectorOnPlane(Vector3.up, vector);
			if (vector2 != Vector3.zero)
			{
				num = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
			}
			if (!this.mLinkRotation && Mathf.Abs(num) <= this.m_CurrentRotationSpeed * rDeltaTime)
			{
				this.mLinkRotation = true;
			}
			if (!this.mLinkRotation)
			{
				float num2 = Mathf.Abs(num);
				num = Mathf.Sign(num) * Mathf.Min(this.m_CurrentRotationSpeed * rDeltaTime, num2);
			}
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
			this.mActorController.Yaw = this.mActorController.Yaw * quaternion;
			this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x000066D6 File Offset: 0x000048D6
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x00028430 File Offset: 0x00026630
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == TavoTestingMotion.STATE_IdlePose || animatorStateID == TavoTestingMotion.STATE_MoveTree || animatorTransitionID == TavoTestingMotion.TRANS_AnyState_MoveTree || animatorTransitionID == TavoTestingMotion.TRANS_EntryState_MoveTree || animatorTransitionID == TavoTestingMotion.TRANS_IdlePose_MoveTree || animatorTransitionID == TavoTestingMotion.TRANS_MoveTree_IdlePose;
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00028492 File Offset: 0x00026692
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == TavoTestingMotion.STATE_IdlePose || rStateID == TavoTestingMotion.STATE_MoveTree;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000284A9 File Offset: 0x000266A9
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == TavoTestingMotion.STATE_IdlePose || rStateID == TavoTestingMotion.STATE_MoveTree || rTransitionID == TavoTestingMotion.TRANS_AnyState_MoveTree || rTransitionID == TavoTestingMotion.TRANS_EntryState_MoveTree || rTransitionID == TavoTestingMotion.TRANS_IdlePose_MoveTree || rTransitionID == TavoTestingMotion.TRANS_MoveTree_IdlePose;
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000284E8 File Offset: 0x000266E8
		public override void LoadAnimatorData()
		{
			TavoTestingMotion.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.TavoTestingMotion.Move Tree");
			TavoTestingMotion.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> Base Layer.TavoTestingMotion.Move Tree");
			TavoTestingMotion.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.TavoTestingMotion.IdlePose");
			TavoTestingMotion.TRANS_IdlePose_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.TavoTestingMotion.IdlePose -> Base Layer.TavoTestingMotion.Move Tree");
			TavoTestingMotion.STATE_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.TavoTestingMotion.Move Tree");
			TavoTestingMotion.TRANS_MoveTree_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.TavoTestingMotion.Move Tree -> Base Layer.TavoTestingMotion.IdlePose");
		}

		// Token: 0x040005EA RID: 1514
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x040005EB RID: 1515
		public const int PHASE_START = 17301;

		// Token: 0x040005EC RID: 1516
		public const int PHASE_STOP = 17351;

		// Token: 0x040005ED RID: 1517
		public float _minInputToWalk = 0.49f;

		// Token: 0x040005EE RID: 1518
		public int _FormCondition = -1;

		// Token: 0x040005EF RID: 1519
		public bool _DefaultToRun;

		// Token: 0x040005F0 RID: 1520
		[Obsolete("siempre va a estar activado")]
		public string _StrafeLeftActionAlias = "StrafeLeft";

		// Token: 0x040005F1 RID: 1521
		[Obsolete("siempre va a estar activado")]
		public string _StrafeRightActionAlias = "StrafeRight";

		// Token: 0x040005F2 RID: 1522
		public float _WalkSpeed;

		// Token: 0x040005F3 RID: 1523
		public float _RunSpeed;

		// Token: 0x040005F4 RID: 1524
		private bool mStartInMove;

		// Token: 0x040005F5 RID: 1525
		private bool mStartInWalk;

		// Token: 0x040005F6 RID: 1526
		private bool mStartInRun;

		// Token: 0x040005F7 RID: 1527
		[Obsolete("siempre va a estar activado")]
		public string _RotateActionAlias = "ActivateRotation";

		// Token: 0x040005F8 RID: 1528
		[Obsolete("Solo RotaraConCamara")]
		public bool _RotateWithInput = true;

		// Token: 0x040005F9 RID: 1529
		public bool _RotateWithCamera = true;

		// Token: 0x040005FA RID: 1530
		public float _RotationSpeed = 180f;

		// Token: 0x040005FB RID: 1531
		public float _RotationSmoothing = 0.1f;

		// Token: 0x040005FC RID: 1532
		public int _SmoothingSamples = 20;

		// Token: 0x040005FD RID: 1533
		protected bool mLinkRotation;

		// Token: 0x040005FE RID: 1534
		protected bool mForceRotationToCamera;

		// Token: 0x040005FF RID: 1535
		protected float mYaw;

		// Token: 0x04000600 RID: 1536
		protected float mYawTarget;

		// Token: 0x04000601 RID: 1537
		protected float mYawVelocity;

		// Token: 0x04000602 RID: 1538
		protected FloatValue mInputX = new FloatValue(0f, 5);

		// Token: 0x04000603 RID: 1539
		protected FloatValue mInputY = new FloatValue(0f, 5);

		// Token: 0x04000604 RID: 1540
		protected SmoothFloats mInputMagnitude_V2 = new SmoothFloats(5, 0.11f);

		// Token: 0x04000605 RID: 1541
		private float m_CurrentRotationSpeed;

		// Token: 0x04000606 RID: 1542
		private UnityInputSource m_UnityInputSource;

		// Token: 0x04000607 RID: 1543
		public static int STATE_IdlePose = -1;

		// Token: 0x04000608 RID: 1544
		public static int STATE_MoveTree = -1;

		// Token: 0x04000609 RID: 1545
		public static int TRANS_AnyState_MoveTree = -1;

		// Token: 0x0400060A RID: 1546
		public static int TRANS_EntryState_MoveTree = -1;

		// Token: 0x0400060B RID: 1547
		public static int TRANS_IdlePose_MoveTree = -1;

		// Token: 0x0400060C RID: 1548
		public static int TRANS_MoveTree_IdlePose = -1;
	}
}
