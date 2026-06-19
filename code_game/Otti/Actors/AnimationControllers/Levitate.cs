using System;
using com.ootii.Actors.Combat;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Messages;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200010A RID: 266
	[MotionName("Levitate")]
	[MotionDescription("Allows the character to hover up and down with minimal lateral movement.")]
	public class Levitate : MotionControllerMotion
	{
		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000F8D RID: 3981 RVA: 0x0005216F File Offset: 0x0005036F
		// (set) Token: 0x06000F8E RID: 3982 RVA: 0x00052177 File Offset: 0x00050377
		public Vector3 ConstantVelocity
		{
			get
			{
				return this._ConstantVelocity;
			}
			set
			{
				this._ConstantVelocity = value;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x00052180 File Offset: 0x00050380
		// (set) Token: 0x06000F90 RID: 3984 RVA: 0x00052188 File Offset: 0x00050388
		public string UpAlias
		{
			get
			{
				return this._UpAlias;
			}
			set
			{
				this._UpAlias = value;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x00052191 File Offset: 0x00050391
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x00052199 File Offset: 0x00050399
		public string DownAlias
		{
			get
			{
				return this._DownAlias;
			}
			set
			{
				this._DownAlias = value;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x000521A2 File Offset: 0x000503A2
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x000521AA File Offset: 0x000503AA
		public float VerticalSpeed
		{
			get
			{
				return this._VerticalSpeed;
			}
			set
			{
				this._VerticalSpeed = value;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x000521B3 File Offset: 0x000503B3
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x000521BB File Offset: 0x000503BB
		public float HorizontalSpeed
		{
			get
			{
				return this._HorizontalSpeed;
			}
			set
			{
				this._HorizontalSpeed = value;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x000521C4 File Offset: 0x000503C4
		// (set) Token: 0x06000F98 RID: 3992 RVA: 0x000521CC File Offset: 0x000503CC
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

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000F99 RID: 3993 RVA: 0x000521D5 File Offset: 0x000503D5
		// (set) Token: 0x06000F9A RID: 3994 RVA: 0x000521DD File Offset: 0x000503DD
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

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000F9B RID: 3995 RVA: 0x000521E6 File Offset: 0x000503E6
		// (set) Token: 0x06000F9C RID: 3996 RVA: 0x000521EE File Offset: 0x000503EE
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

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000F9D RID: 3997 RVA: 0x000521F7 File Offset: 0x000503F7
		// (set) Token: 0x06000F9E RID: 3998 RVA: 0x000521FF File Offset: 0x000503FF
		public float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
				this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
			}
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x0005221C File Offset: 0x0005041C
		public Levitate()
		{
			this._Pack = Idle.GroupName();
			this._Category = 300;
			this._Priority = 25f;
			this._ActionAlias = "";
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x000522E4 File Offset: 0x000504E4
		public Levitate(MotionController rController)
			: base(rController)
		{
			this._Pack = Idle.GroupName();
			this._Category = 300;
			this._Priority = 25f;
			this._ActionAlias = "";
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x000523AB File Offset: 0x000505AB
		public override void Awake()
		{
			base.Awake();
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x000523C8 File Offset: 0x000505C8
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (!this.mActorController.IsGrounded)
			{
				return false;
			}
			if (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				this.mParameter = 0;
				return true;
			}
			return false;
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0005242C File Offset: 0x0005062C
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || ((!this.mIsAnimatorActive || this.IsInMotionState) && this.mMotionLayer._AnimatorStateID != Levitate.STATE_IdlePose && (this._ActionAlias.Length <= 0 || this.mMotionController._InputSource == null || !this.mMotionController._InputSource.IsJustPressed(this._ActionAlias)));
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x000524A0 File Offset: 0x000506A0
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mHasLanded = false;
			this.mHasLaunched = false;
			this.mStoredIsGravityEnabled = this.mActorController.IsGravityEnabled;
			this.mActorController.IsGravityEnabled = false;
			this.mStoredIsOrientationEnabled = this.mActorController.OrientToGround;
			this.mActorController.OrientToGround = false;
			this.mActorController.FixGroundPenetration = false;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1800, 0, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x000525A1 File Offset: 0x000507A1
		public override bool Interrupt(object rParameter)
		{
			return false;
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x000525A4 File Offset: 0x000507A4
		public override void Deactivate()
		{
			this.mActorController.IsGravityEnabled = this.mStoredIsGravityEnabled;
			this.mActorController.OrientToGround = this.mStoredIsOrientationEnabled;
			this.mActorController.FixGroundPenetration = true;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x00052628 File Offset: 0x00050828
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x00052644 File Offset: 0x00050844
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (!this.mHasLaunched && !this.mMotionController.IsGrounded)
			{
				this.mHasLaunched = true;
			}
			if (this.mHasLaunched && this.mMotionController.IsGrounded)
			{
				this.mHasLanded = true;
			}
			if (!this.mHasLanded)
			{
				if (!this.mHasLaunched)
				{
					this.mMovement = this.mMotionController._Transform.up * (0.25f * rDeltaTime);
				}
				else
				{
					this.mMovement = this.ConstantVelocity * rDeltaTime;
				}
				if (this.mMotionController._InputSource != null)
				{
					float num = this.mMotionController._InputSource.GetValue(this._UpAlias) * this._VerticalSpeed;
					float num2 = this.mMotionController._InputSource.GetValue(this._DownAlias) * -this._VerticalSpeed;
					this.mMovement += this.mMotionController._Transform.up * ((num + num2) * rDeltaTime);
					Vector3 inputForward = this.mMotionController.State.InputForward;
					this.mMovement += this.mMotionController._Transform.rotation * (inputForward * (this._HorizontalSpeed * rDeltaTime));
				}
			}
			else
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1805, 0, true);
			}
			if (!this._RotateWithCamera && this._RotateWithInput)
			{
				this.RotateUsingInput(rDeltaTime, ref this.mRotation);
			}
			if (this._RotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			base.Update(rDeltaTime, rUpdateIndex);
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0005280C File Offset: 0x00050A0C
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			float num2 = 0.1f;
			if (this.mMotionController._InputSource.IsViewingActivated)
			{
				num = this.mMotionController._InputSource.ViewX * this.mDegreesPer60FPSTick;
			}
			this.mYawTarget += num;
			num = ((num2 <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, num2)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x000528C8 File Offset: 0x00050AC8
		private void OnCameraUpdated(float rDeltaTime, int rUpdateCount, BaseCameraRig rCamera)
		{
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
			float num2 = Mathf.Abs(num);
			float num3 = Mathf.Sign(num);
			if (!this.mLinkRotation && num2 <= this._RotationSpeed / 60f * TimeManager.Relative60FPSDeltaTime)
			{
				this.mLinkRotation = true;
			}
			if (num2 < 1f)
			{
				float num4 = Mathf.Sign(this.mYawVelocity);
				this.mYawVelocity -= num4 * rDeltaTime * 10f;
				if (Mathf.Sign(this.mYawVelocity) != num4)
				{
					this.mYawVelocity = 0f;
				}
			}
			else
			{
				this.mYawVelocity = num3 * 12f;
			}
			if (!this.mLinkRotation)
			{
				num = num3 * Mathf.Min(this._RotationSpeed / 60f * TimeManager.Relative60FPSDeltaTime, num2);
			}
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
			this.mActorController.Yaw = this.mActorController.Yaw * quaternion;
			this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x00052A1C File Offset: 0x00050C1C
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			CombatMessage combatMessage = rMessage as CombatMessage;
			if (combatMessage != null)
			{
				if (combatMessage.Attacker == this.mMotionController.gameObject)
				{
					if (rMessage.ID != CombatMessage.MSG_COMBATANT_ATTACK && rMessage.ID != CombatMessage.MSG_DEFENDER_ATTACKED && rMessage.ID != CombatMessage.MSG_DEFENDER_ATTACKED_BLOCKED && rMessage.ID != CombatMessage.MSG_DEFENDER_ATTACKED_PARRIED && rMessage.ID != CombatMessage.MSG_DEFENDER_DAMAGED)
					{
						int id = rMessage.ID;
						int msg_DEFENDER_KILLED = CombatMessage.MSG_DEFENDER_KILLED;
						return;
					}
				}
				else
				{
					combatMessage.Defender == this.mMotionController.gameObject;
				}
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000FAC RID: 4012 RVA: 0x00052AB5 File Offset: 0x00050CB5
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x00052AB8 File Offset: 0x00050CB8
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == Levitate.STATE_LandToIdle)
					{
						return true;
					}
					if (animatorStateID == Levitate.STATE_FallToLand)
					{
						return true;
					}
					if (animatorStateID == Levitate.STATE_FallPose)
					{
						return true;
					}
					if (animatorStateID == Levitate.STATE_IdlePose)
					{
						return true;
					}
				}
				return animatorTransitionID == Levitate.TRANS_AnyState_FallPose || animatorTransitionID == Levitate.TRANS_EntryState_FallPose || animatorTransitionID == Levitate.TRANS_LandToIdle_IdlePose || animatorTransitionID == Levitate.TRANS_FallToLand_LandToIdle || animatorTransitionID == Levitate.TRANS_FallPose_FallToLand;
			}
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00052B3B File Offset: 0x00050D3B
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Levitate.STATE_LandToIdle || rStateID == Levitate.STATE_FallToLand || rStateID == Levitate.STATE_FallPose || rStateID == Levitate.STATE_IdlePose;
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00052B68 File Offset: 0x00050D68
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == Levitate.STATE_LandToIdle)
				{
					return true;
				}
				if (rStateID == Levitate.STATE_FallToLand)
				{
					return true;
				}
				if (rStateID == Levitate.STATE_FallPose)
				{
					return true;
				}
				if (rStateID == Levitate.STATE_IdlePose)
				{
					return true;
				}
			}
			return rTransitionID == Levitate.TRANS_AnyState_FallPose || rTransitionID == Levitate.TRANS_EntryState_FallPose || rTransitionID == Levitate.TRANS_LandToIdle_IdlePose || rTransitionID == Levitate.TRANS_FallToLand_LandToIdle || rTransitionID == Levitate.TRANS_FallPose_FallToLand;
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x00052BD4 File Offset: 0x00050DD4
		public override void LoadAnimatorData()
		{
			Levitate.TRANS_AnyState_FallPose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Levitate-SM.FallPose");
			Levitate.TRANS_EntryState_FallPose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Levitate-SM.FallPose");
			Levitate.STATE_LandToIdle = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.LandToIdle");
			Levitate.TRANS_LandToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.LandToIdle -> Base Layer.Levitate-SM.IdlePose");
			Levitate.STATE_FallToLand = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.FallToLand");
			Levitate.TRANS_FallToLand_LandToIdle = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.FallToLand -> Base Layer.Levitate-SM.LandToIdle");
			Levitate.STATE_FallPose = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.FallPose");
			Levitate.TRANS_FallPose_FallToLand = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.FallPose -> Base Layer.Levitate-SM.FallToLand");
			Levitate.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Levitate-SM.IdlePose");
		}

		// Token: 0x040009F8 RID: 2552
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x040009F9 RID: 2553
		public const int PHASE_START = 1800;

		// Token: 0x040009FA RID: 2554
		public const int PHASE_END = 1805;

		// Token: 0x040009FB RID: 2555
		public Vector3 _ConstantVelocity = new Vector3(0f, 0f, 0f);

		// Token: 0x040009FC RID: 2556
		public string _UpAlias = "Move Up";

		// Token: 0x040009FD RID: 2557
		public string _DownAlias = "Move Down";

		// Token: 0x040009FE RID: 2558
		public float _VerticalSpeed = 1f;

		// Token: 0x040009FF RID: 2559
		public float _HorizontalSpeed = 0.5f;

		// Token: 0x04000A00 RID: 2560
		public bool _RotateWithInput;

		// Token: 0x04000A01 RID: 2561
		public bool _RotateWithCamera = true;

		// Token: 0x04000A02 RID: 2562
		public string _RotateActionAlias = "";

		// Token: 0x04000A03 RID: 2563
		public float _RotationSpeed = 360f;

		// Token: 0x04000A04 RID: 2564
		protected bool mHasLaunched;

		// Token: 0x04000A05 RID: 2565
		protected bool mHasLanded;

		// Token: 0x04000A06 RID: 2566
		protected bool mStoredIsGravityEnabled = true;

		// Token: 0x04000A07 RID: 2567
		protected bool mStoredIsOrientationEnabled = true;

		// Token: 0x04000A08 RID: 2568
		protected Vector3 mTargetForward = Vector3.zero;

		// Token: 0x04000A09 RID: 2569
		protected float mDegreesPer60FPSTick = 1f;

		// Token: 0x04000A0A RID: 2570
		protected float mYaw;

		// Token: 0x04000A0B RID: 2571
		protected float mYawTarget;

		// Token: 0x04000A0C RID: 2572
		protected float mYawVelocity;

		// Token: 0x04000A0D RID: 2573
		protected bool mLinkRotation;

		// Token: 0x04000A0E RID: 2574
		public static int STATE_LandToIdle = -1;

		// Token: 0x04000A0F RID: 2575
		public static int STATE_FallToLand = -1;

		// Token: 0x04000A10 RID: 2576
		public static int STATE_FallPose = -1;

		// Token: 0x04000A11 RID: 2577
		public static int STATE_IdlePose = -1;

		// Token: 0x04000A12 RID: 2578
		public static int TRANS_AnyState_FallPose = -1;

		// Token: 0x04000A13 RID: 2579
		public static int TRANS_EntryState_FallPose = -1;

		// Token: 0x04000A14 RID: 2580
		public static int TRANS_LandToIdle_IdlePose = -1;

		// Token: 0x04000A15 RID: 2581
		public static int TRANS_FallToLand_LandToIdle = -1;

		// Token: 0x04000A16 RID: 2582
		public static int TRANS_FallPose_FallToLand = -1;
	}
}
