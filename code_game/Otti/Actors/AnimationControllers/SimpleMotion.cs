using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200010F RID: 271
	[MotionName("Simple Motion")]
	[MotionDescription("Generic motion that can support any basic Mecanim animation. This is an easy way to associate simple animations with characters.")]
	public class SimpleMotion : MotionControllerMotion
	{
		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x00054AAD File Offset: 0x00052CAD
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x00054AB0 File Offset: 0x00052CB0
		// (set) Token: 0x06000FFB RID: 4091 RVA: 0x00054AB8 File Offset: 0x00052CB8
		public int PhaseID
		{
			get
			{
				return this._PhaseID;
			}
			set
			{
				this._PhaseID = value;
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00054AC1 File Offset: 0x00052CC1
		// (set) Token: 0x06000FFD RID: 4093 RVA: 0x00054AC9 File Offset: 0x00052CC9
		public float ExitTime
		{
			get
			{
				return this._ExitTime;
			}
			set
			{
				this._ExitTime = value;
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000FFE RID: 4094 RVA: 0x00054AD2 File Offset: 0x00052CD2
		// (set) Token: 0x06000FFF RID: 4095 RVA: 0x00054ADA File Offset: 0x00052CDA
		public string ExitState
		{
			get
			{
				return this._ExitState;
			}
			set
			{
				this._ExitState = value;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x00054AE3 File Offset: 0x00052CE3
		// (set) Token: 0x06001001 RID: 4097 RVA: 0x00054AEB File Offset: 0x00052CEB
		public bool ExitOnRelease
		{
			get
			{
				return this._ExitOnRelease;
			}
			set
			{
				this._ExitOnRelease = value;
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06001002 RID: 4098 RVA: 0x00054AF4 File Offset: 0x00052CF4
		// (set) Token: 0x06001003 RID: 4099 RVA: 0x00054AFC File Offset: 0x00052CFC
		public bool DisableGravity
		{
			get
			{
				return this._DisableGravity;
			}
			set
			{
				this._DisableGravity = value;
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06001004 RID: 4100 RVA: 0x00054B05 File Offset: 0x00052D05
		// (set) Token: 0x06001005 RID: 4101 RVA: 0x00054B0D File Offset: 0x00052D0D
		public bool DisableRootMotionRotation
		{
			get
			{
				return this._DisableRootMotionRotation;
			}
			set
			{
				this._DisableRootMotionRotation = value;
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06001006 RID: 4102 RVA: 0x00054B16 File Offset: 0x00052D16
		// (set) Token: 0x06001007 RID: 4103 RVA: 0x00054B1E File Offset: 0x00052D1E
		public bool DisableRootMotionMovement
		{
			get
			{
				return this._DisableRootMotionMovement;
			}
			set
			{
				this._DisableRootMotionMovement = value;
			}
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x00054B27 File Offset: 0x00052D27
		public SimpleMotion()
		{
			this._Priority = 10f;
			this.mIsStartable = true;
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00054B5E File Offset: 0x00052D5E
		public SimpleMotion(MotionController rController)
			: base(rController)
		{
			this._Priority = 10f;
			this.mIsStartable = true;
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00054B96 File Offset: 0x00052D96
		public override void LoadAnimatorData()
		{
			if (this._ExitState.Length > 0)
			{
				this.mExitStateID = this.mMotionController.AddAnimatorName(this._ExitState);
			}
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00054BC0 File Offset: 0x00052DC0
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
			if (this.mMotionController.InputSource == null)
			{
				return false;
			}
			if (this._ActionAlias.Length > 0 && this.mMotionController.InputSource.IsJustPressed(this._ActionAlias))
			{
				this.mHasEnteredAnimatorState = false;
				return true;
			}
			return false;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x00054C28 File Offset: 0x00052E28
		public override bool TestUpdate()
		{
			if (this.mIsAnimatorActive && this.mMotionLayer._AnimatorTransitionID == 0)
			{
				this.mHasEnteredAnimatorState = true;
			}
			if (this.mHasEnteredAnimatorState)
			{
				if ((this.mExitStateID == 0 || this.mMotionLayer._AnimatorStateID == this.mExitStateID) && this._ExitTime > 0f && this.mMotionLayer._AnimatorStateNormalizedTime >= this._ExitTime)
				{
					return false;
				}
				if (this._ExitOnRelease && this._ActionAlias.Length > 0 && this.mMotionController.InputSource.IsReleased(this._ActionAlias))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x00054CC8 File Offset: 0x00052EC8
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mHasEnteredAnimatorState = false;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this._PhaseID, true);
			if (this._DisableGravity)
			{
				this.mWasGravityEnabled = this.mActorController._IsGravityEnabled;
				this.mActorController.IsGravityEnabled = false;
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00054D25 File Offset: 0x00052F25
		public override void Deactivate()
		{
			if (this._DisableGravity)
			{
				this.mActorController.IsGravityEnabled = this.mWasGravityEnabled;
			}
			base.Deactivate();
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00054D46 File Offset: 0x00052F46
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			if (this._DisableRootMotionRotation)
			{
				rRotationDelta = Quaternion.identity;
			}
			if (this._DisableRootMotionMovement)
			{
				rVelocityDelta = Vector3.zero;
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x00054D6F File Offset: 0x00052F6F
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x04000A81 RID: 2689
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000A82 RID: 2690
		public int _PhaseID;

		// Token: 0x04000A83 RID: 2691
		public float _ExitTime = 1f;

		// Token: 0x04000A84 RID: 2692
		public string _ExitState = "";

		// Token: 0x04000A85 RID: 2693
		public bool _ExitOnRelease;

		// Token: 0x04000A86 RID: 2694
		public bool _DisableGravity;

		// Token: 0x04000A87 RID: 2695
		public bool _DisableRootMotionRotation;

		// Token: 0x04000A88 RID: 2696
		public bool _DisableRootMotionMovement;

		// Token: 0x04000A89 RID: 2697
		private int mExitStateID;

		// Token: 0x04000A8A RID: 2698
		private bool mHasEnteredAnimatorState;

		// Token: 0x04000A8B RID: 2699
		private bool mWasGravityEnabled = true;
	}
}
