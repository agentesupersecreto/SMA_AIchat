using System;
using com.ootii.Actors.Navigation;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000115 RID: 277
	[MotionName("Vault 1 Meter")]
	[MotionDescription("Walking/running value that allows us to go over a 1m high wall that is 0.2m or shallower in depth.")]
	public class Vault_1m : MotionControllerMotion
	{
		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x0600107A RID: 4218 RVA: 0x0005852F File Offset: 0x0005672F
		// (set) Token: 0x0600107B RID: 4219 RVA: 0x00058537 File Offset: 0x00056737
		public float MinDistance
		{
			get
			{
				return this._MinDistance;
			}
			set
			{
				this._MinDistance = value;
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x0600107C RID: 4220 RVA: 0x00058540 File Offset: 0x00056740
		// (set) Token: 0x0600107D RID: 4221 RVA: 0x00058548 File Offset: 0x00056748
		public float MaxDistance
		{
			get
			{
				return this._MaxDistance;
			}
			set
			{
				this._MaxDistance = value;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x0600107E RID: 4222 RVA: 0x00058551 File Offset: 0x00056751
		// (set) Token: 0x0600107F RID: 4223 RVA: 0x00058559 File Offset: 0x00056759
		public float MinHeight
		{
			get
			{
				return this._MinHeight;
			}
			set
			{
				this._MinHeight = value;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06001080 RID: 4224 RVA: 0x00058562 File Offset: 0x00056762
		// (set) Token: 0x06001081 RID: 4225 RVA: 0x0005856A File Offset: 0x0005676A
		public float MaxHeight
		{
			get
			{
				return this._MaxHeight;
			}
			set
			{
				this._MaxHeight = value;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06001082 RID: 4226 RVA: 0x00058573 File Offset: 0x00056773
		// (set) Token: 0x06001083 RID: 4227 RVA: 0x0005857B File Offset: 0x0005677B
		public bool AllowRunningVault
		{
			get
			{
				return this._AllowRunningVault;
			}
			set
			{
				this._AllowRunningVault = value;
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06001084 RID: 4228 RVA: 0x00058584 File Offset: 0x00056784
		// (set) Token: 0x06001085 RID: 4229 RVA: 0x0005858C File Offset: 0x0005678C
		public int ClimbableLayers
		{
			get
			{
				return this._ClimbableLayers;
			}
			set
			{
				this._ClimbableLayers = value;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06001086 RID: 4230 RVA: 0x00058595 File Offset: 0x00056795
		// (set) Token: 0x06001087 RID: 4231 RVA: 0x0005859D File Offset: 0x0005679D
		public Vector3 ReachOffset1
		{
			get
			{
				return this._ReachOffset1;
			}
			set
			{
				this._ReachOffset1 = value;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06001088 RID: 4232 RVA: 0x000585A6 File Offset: 0x000567A6
		// (set) Token: 0x06001089 RID: 4233 RVA: 0x000585AE File Offset: 0x000567AE
		public Vector3 ReachOffset2
		{
			get
			{
				return this._ReachOffset2;
			}
			set
			{
				this._ReachOffset2 = value;
			}
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x000585B8 File Offset: 0x000567B8
		public Vault_1m()
		{
			this._Priority = 40f;
			this._ActionAlias = "Jump";
			this.mIsStartable = true;
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x00058668 File Offset: 0x00056868
		public Vault_1m(MotionController rController)
			: base(rController)
		{
			this._Priority = 40f;
			this._ActionAlias = "Jump";
			this.mIsStartable = true;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00058716 File Offset: 0x00056916
		public override void Initialize()
		{
			if (this.mMotionController != null && this.mWalkRunMotion == null)
			{
				this.mWalkRunMotion = this.mMotionController.GetMotionInterface<IWalkRunMotion>(0);
			}
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x00058740 File Offset: 0x00056940
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
			bool flag = false;
			if (this._ActionAlias.Length == 0 || this.mMotionController.InputSource.IsJustPressed(this._ActionAlias))
			{
				flag = this.TestForClimbUp();
			}
			return flag;
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x000587A4 File Offset: 0x000569A4
		public override bool TestUpdate()
		{
			return true;
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x000587A8 File Offset: 0x000569A8
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mRaycastHitInfo.collider == null)
			{
				return false;
			}
			this.mIsExitTriggered = false;
			this.mStartPosition = this.mActorController._Transform.position;
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			this.mActorController.IsGravityEnabled = false;
			this.mActorController.ForceGrounding = false;
			this.mActorController.FixGroundPenetration = false;
			this.mActorController.SetGround(this.mClimbable.transform);
			this.mDefaultToRun = false;
			if (this._AllowRunningVault && rPrevMotion is IWalkRunMotion)
			{
				this.mDefaultToRun = ((IWalkRunMotion)rPrevMotion).IsRunActive;
			}
			this.ClearReachData();
			if (this.mDefaultToRun)
			{
				Quaternion rotation = this.mActorController._Transform.rotation;
				MotionReachData motionReachData = MotionReachData.Allocate();
				motionReachData.StateID = Vault_1m.STATE_RunVault_1m;
				motionReachData.StartTime = 0f;
				motionReachData.EndTime = 0.25f;
				motionReachData.Power = 3;
				motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * (this._ReachOffset1 + new Vector3(0f, 0.3f, -0.5f)) + rotation * this._ReachOffset2;
				motionReachData.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData);
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1305, true);
			}
			else
			{
				Quaternion rotation2 = this.mActorController._Transform.rotation;
				MotionReachData motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = Vault_1m.STATE_WalkVault_1m;
				motionReachData2.StartTime = 0f;
				motionReachData2.EndTime = 0.25f;
				motionReachData2.Power = 3;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * this._ReachOffset1 + rotation2 * this._ReachOffset2;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1300, true);
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x00058A14 File Offset: 0x00056C14
		public override void Deactivate()
		{
			this.mClimbable = null;
			this.mActorController.IsGravityEnabled = true;
			this.mActorController.ForceGrounding = true;
			this.mActorController.IsCollsionEnabled = true;
			this.mActorController.FixGroundPenetration = true;
			this.mActorController.SetGround(null);
			base.Deactivate();
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x00058A6A File Offset: 0x00056C6A
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x00058A6C File Offset: 0x00056C6C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (this.mClimbable == null)
			{
				return;
			}
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			float animatorStateNormalizedTime = this.mMotionLayer._AnimatorStateNormalizedTime;
			this.mMovement = this.GetReachMovement();
			if (animatorStateID == Vault_1m.STATE_WalkVault_1m || animatorStateID == Vault_1m.STATE_RunVault_1m)
			{
				if (animatorStateNormalizedTime > 0.65f)
				{
					this.mActorController.IsGravityEnabled = true;
					this.mActorController.FixGroundPenetration = true;
					return;
				}
				if (animatorStateNormalizedTime > 0.3f)
				{
					this.mActorController.IsCollsionEnabled = false;
					return;
				}
			}
			else if (animatorStateID == Vault_1m.STATE_WalkForward || animatorStateID == Vault_1m.STATE_RunForward)
			{
				this.mActorController.IsGravityEnabled = true;
				this.mActorController.IsCollsionEnabled = true;
				this.mActorController.FixGroundPenetration = true;
				this.mActorController.SetGround(null);
				if (!this.mIsExitTriggered)
				{
					this.mIsExitTriggered = true;
					if (this.mWalkRunMotion != null && this.mWalkRunMotion.IsEnabled)
					{
						this.mWalkRunMotion.StartInRun = this.mWalkRunMotion.IsRunActive;
						this.mWalkRunMotion.StartInWalk = !this.mWalkRunMotion.StartInRun;
						this.Deactivate();
						return;
					}
					this.Deactivate();
				}
			}
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x00058BC4 File Offset: 0x00056DC4
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			if (rMessage is NavigationMessage && rMessage.ID == NavigationMessage.MSG_NAVIGATE_CLIMB && !this.mIsActive && this.mMotionController.IsGrounded && this.TestForClimbUp())
			{
				rMessage.Recipient = this;
				rMessage.IsHandled = true;
				this.mMotionController.ActivateMotion(this, 0);
			}
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x00058C24 File Offset: 0x00056E24
		public virtual bool TestForClimbUp()
		{
			float maxDistance = this._MaxDistance;
			Transform transform = this.mActorController._Transform;
			Vector3 vector = transform.position + transform.up * this._MinHeight;
			Vector3 vector2 = transform.forward;
			float num = this._MaxDistance;
			if (!RaycastExt.SafeRaycast(vector, vector2, out this.mRaycastHitInfo, num, this._ClimbableLayers, transform, null, true, false))
			{
				return false;
			}
			float distance = this.mRaycastHitInfo.distance;
			if (distance < this._MinDistance)
			{
				return false;
			}
			vector = transform.position + transform.up * this._MaxHeight;
			if (RaycastExt.SafeRaycast(vector, vector2, out this.mRaycastHitInfo, num, this._ClimbableLayers, transform, null, true, false))
			{
				return false;
			}
			vector += transform.forward * (distance + 0.01f);
			vector2 = -transform.up;
			num = this._MaxHeight;
			if (!RaycastExt.SafeRaycast(vector, -this.mMotionController.transform.up, out this.mRaycastHitInfo, this._MaxHeight - this._MinHeight + 0.01f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector3 = transform.InverseTransformPoint(this.mRaycastHitInfo.point);
			vector = transform.position + transform.up * (vector3.y - 0.01f);
			vector2 = transform.forward;
			num = this._MaxDistance;
			if (!RaycastExt.SafeRaycast(vector, this.mMotionController.transform.forward, out this.mRaycastHitInfo, maxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			vector = this.mRaycastHitInfo.point + this.mActorController.transform.forward * 0.3f + this.mActorController._Transform.up * 0.2f;
			RaycastHit raycastHit;
			return !RaycastExt.SafeRaycast(vector, -this.mMotionController.transform.up, out raycastHit, this._MinHeight, this._ClimbableLayers, this.mActorController._Transform, null, true, false);
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x00058E5C File Offset: 0x0005705C
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Vault_1m.STATE_WalkVault_1m || animatorStateID == Vault_1m.STATE_WalkForward || animatorStateID == Vault_1m.STATE_RunVault_1m || animatorStateID == Vault_1m.STATE_RunForward || animatorTransitionID == Vault_1m.TRANS_EntryState_WalkVault_1m || animatorTransitionID == Vault_1m.TRANS_AnyState_WalkVault_1m || animatorTransitionID == Vault_1m.TRANS_EntryState_RunVault_1m || animatorTransitionID == Vault_1m.TRANS_AnyState_RunVault_1m || animatorTransitionID == Vault_1m.TRANS_WalkVault_1m_WalkForward || animatorTransitionID == Vault_1m.TRANS_RunVault_1m_RunForward;
			}
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x00058EE6 File Offset: 0x000570E6
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Vault_1m.STATE_WalkVault_1m || rStateID == Vault_1m.STATE_WalkForward || rStateID == Vault_1m.STATE_RunVault_1m || rStateID == Vault_1m.STATE_RunForward;
		}

		// Token: 0x06001097 RID: 4247 RVA: 0x00058F14 File Offset: 0x00057114
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Vault_1m.STATE_WalkVault_1m || rStateID == Vault_1m.STATE_WalkForward || rStateID == Vault_1m.STATE_RunVault_1m || rStateID == Vault_1m.STATE_RunForward || rTransitionID == Vault_1m.TRANS_EntryState_WalkVault_1m || rTransitionID == Vault_1m.TRANS_AnyState_WalkVault_1m || rTransitionID == Vault_1m.TRANS_EntryState_RunVault_1m || rTransitionID == Vault_1m.TRANS_AnyState_RunVault_1m || rTransitionID == Vault_1m.TRANS_WalkVault_1m_WalkForward || rTransitionID == Vault_1m.TRANS_RunVault_1m_RunForward;
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x00058F88 File Offset: 0x00057188
		public override void LoadAnimatorData()
		{
			Vault_1m.TRANS_EntryState_WalkVault_1m = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Vault_1m-SM.WalkVault_1m");
			Vault_1m.TRANS_AnyState_WalkVault_1m = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Vault_1m-SM.WalkVault_1m");
			Vault_1m.TRANS_EntryState_RunVault_1m = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Vault_1m-SM.RunVault_1m");
			Vault_1m.TRANS_AnyState_RunVault_1m = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Vault_1m-SM.RunVault_1m");
			Vault_1m.STATE_WalkVault_1m = this.mMotionController.AddAnimatorName("Base Layer.Vault_1m-SM.WalkVault_1m");
			Vault_1m.TRANS_WalkVault_1m_WalkForward = this.mMotionController.AddAnimatorName("Base Layer.Vault_1m-SM.WalkVault_1m -> Base Layer.Vault_1m-SM.WalkForward");
			Vault_1m.STATE_WalkForward = this.mMotionController.AddAnimatorName("Base Layer.Vault_1m-SM.WalkForward");
			Vault_1m.STATE_RunVault_1m = this.mMotionController.AddAnimatorName("Base Layer.Vault_1m-SM.RunVault_1m");
			Vault_1m.TRANS_RunVault_1m_RunForward = this.mMotionController.AddAnimatorName("Base Layer.Vault_1m-SM.RunVault_1m -> Base Layer.Vault_1m-SM.RunForward");
			Vault_1m.STATE_RunForward = this.mMotionController.AddAnimatorName("Base Layer.Vault_1m-SM.RunForward");
		}

		// Token: 0x04000B55 RID: 2901
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000B56 RID: 2902
		public const int PHASE_START = 1300;

		// Token: 0x04000B57 RID: 2903
		public const int PHASE_START_RUN = 1305;

		// Token: 0x04000B58 RID: 2904
		public float _MinDistance = 0.2f;

		// Token: 0x04000B59 RID: 2905
		public float _MaxDistance = 1.5f;

		// Token: 0x04000B5A RID: 2906
		public float _MinHeight = 0.9f;

		// Token: 0x04000B5B RID: 2907
		public float _MaxHeight = 1f;

		// Token: 0x04000B5C RID: 2908
		public bool _AllowRunningVault;

		// Token: 0x04000B5D RID: 2909
		public int _ClimbableLayers = 1;

		// Token: 0x04000B5E RID: 2910
		public Vector3 _ReachOffset1 = new Vector3(0f, -0.9f, -0.6f);

		// Token: 0x04000B5F RID: 2911
		public Vector3 _ReachOffset2 = new Vector3(0.2f, 0f, 0.2f);

		// Token: 0x04000B60 RID: 2912
		protected GameObject mClimbable;

		// Token: 0x04000B61 RID: 2913
		protected bool mDefaultToRun;

		// Token: 0x04000B62 RID: 2914
		protected IWalkRunMotion mWalkRunMotion;

		// Token: 0x04000B63 RID: 2915
		protected bool mIsExitTriggered;

		// Token: 0x04000B64 RID: 2916
		protected Vector3 mStartPosition = Vector3.zero;

		// Token: 0x04000B65 RID: 2917
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x04000B66 RID: 2918
		public static int TRANS_EntryState_WalkVault_1m = -1;

		// Token: 0x04000B67 RID: 2919
		public static int TRANS_AnyState_WalkVault_1m = -1;

		// Token: 0x04000B68 RID: 2920
		public static int TRANS_EntryState_RunVault_1m = -1;

		// Token: 0x04000B69 RID: 2921
		public static int TRANS_AnyState_RunVault_1m = -1;

		// Token: 0x04000B6A RID: 2922
		public static int STATE_WalkVault_1m = -1;

		// Token: 0x04000B6B RID: 2923
		public static int TRANS_WalkVault_1m_WalkForward = -1;

		// Token: 0x04000B6C RID: 2924
		public static int STATE_WalkForward = -1;

		// Token: 0x04000B6D RID: 2925
		public static int STATE_RunVault_1m = -1;

		// Token: 0x04000B6E RID: 2926
		public static int TRANS_RunVault_1m_RunForward = -1;

		// Token: 0x04000B6F RID: 2927
		public static int STATE_RunForward = -1;
	}
}
