using System;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000EE RID: 238
	[MotionName("Balance Walk")]
	[MotionDescription("Slow walk for balance beams and tight ropes.")]
	public class BalanceWalk : MotionControllerMotion
	{
		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x0003BF0E File Offset: 0x0003A10E
		// (set) Token: 0x06000C76 RID: 3190 RVA: 0x0003BF16 File Offset: 0x0003A116
		public float MinBeamWidth
		{
			get
			{
				return this._MinBeamWidth;
			}
			set
			{
				this._MinBeamWidth = value;
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000C77 RID: 3191 RVA: 0x0003BF1F File Offset: 0x0003A11F
		// (set) Token: 0x06000C78 RID: 3192 RVA: 0x0003BF27 File Offset: 0x0003A127
		public float MaxBeamWidth
		{
			get
			{
				return this._MaxBeamWidth;
			}
			set
			{
				this._MaxBeamWidth = value;
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x0003BF30 File Offset: 0x0003A130
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x0003BF38 File Offset: 0x0003A138
		public bool RotateWithInput
		{
			get
			{
				return this._RotateWithInput;
			}
			set
			{
				this._RotateWithInput = value;
				if (this._RotateWithInput)
				{
					this._RotateWithView = false;
				}
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x0003BF50 File Offset: 0x0003A150
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x0003BF58 File Offset: 0x0003A158
		public bool RotateWithView
		{
			get
			{
				return this._RotateWithView;
			}
			set
			{
				this._RotateWithView = value;
				if (this._RotateWithView)
				{
					this._RotateWithInput = false;
				}
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x0003BF70 File Offset: 0x0003A170
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x0003BF78 File Offset: 0x0003A178
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

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x0003BF93 File Offset: 0x0003A193
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x0003BF9B File Offset: 0x0003A19B
		public bool ActivateUsingRaycasts
		{
			get
			{
				return this._ActivateUsingRaycasts;
			}
			set
			{
				this._ActivateUsingRaycasts = value;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0003BFA4 File Offset: 0x0003A1A4
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x0003BFAC File Offset: 0x0003A1AC
		public bool ActivateUsingLayers
		{
			get
			{
				return this._ActivateUsingLayers;
			}
			set
			{
				this._ActivateUsingLayers = value;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x0003BFB5 File Offset: 0x0003A1B5
		// (set) Token: 0x06000C84 RID: 3204 RVA: 0x0003BFBD File Offset: 0x0003A1BD
		public int BalanceLayers
		{
			get
			{
				return this._BalanceLayers;
			}
			set
			{
				this._BalanceLayers = value;
			}
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0003BFC8 File Offset: 0x0003A1C8
		public BalanceWalk()
		{
			this._Priority = 15f;
			this.mIsStartable = true;
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0003C034 File Offset: 0x0003A234
		public BalanceWalk(MotionController rController)
			: base(rController)
		{
			this._Priority = 15f;
			this.mIsStartable = true;
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x0003C09F File Offset: 0x0003A29F
		public override void Awake()
		{
			base.Awake();
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x0003C0B9 File Offset: 0x0003A2B9
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.TestBeamWidth(this._MinBeamWidth, this._MaxBeamWidth);
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x0003C0EC File Offset: 0x0003A2EC
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || ((!this.mIsAnimatorActive || this.IsInMotionState) && (!this.mMotionController.IsGrounded || !this.mIsFalling) && (this.mMotionLayer._AnimatorStateID != BalanceWalk.STATE_BalanceFallLeft || this.mMotionLayer._AnimatorStateNormalizedTime <= 0.3f));
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0003C153 File Offset: 0x0003A353
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsFalling = false;
			this.mPushDirection = Vector3.zero;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1400, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0003C18A File Offset: 0x0003A38A
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x0003C192 File Offset: 0x0003A392
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0003C1A0 File Offset: 0x0003A3A0
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			if (this._RotateWithInput)
			{
				this.mRotation = Quaternion.identity;
				this.GetRotationVelocityWithInput(rDeltaTime, ref this.mRotation);
			}
			else if (this._RotateWithView)
			{
				this.mAngularVelocity = Vector3.zero;
				this.GetRotationVelocityWithView(rDeltaTime, ref this.mAngularVelocity);
			}
			if (!this.mActorController.State.IsGrounded)
			{
				if (!this.mIsFalling || this.mMotionLayer._AnimatorStateID != BalanceWalk.STATE_BalanceFallLeft)
				{
					this.mIsFalling = true;
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1405, true);
				}
				RaycastHit raycastHit;
				if (RaycastExt.SafeSphereCast(this.mActorController._Transform.position + this.mActorController._Transform.up * this.mActorController._BaseRadius, -this.mActorController._Transform.up, this.mActorController._BaseRadius, out raycastHit, this.mActorController._BaseRadius * 2f, -1, this.mActorController._Transform, null, true))
				{
					Vector3 normalized = (raycastHit.point - this.mActorController._Transform.position).normalized;
					if (normalized != -this.mActorController._Transform.up)
					{
						this.mPushDirection = -(normalized - Vector3.Project(normalized, this.mActorController._Transform.up));
					}
				}
				this.mMovement = this.mPushDirection * rDeltaTime;
			}
			if (!this.mIsFalling)
			{
				bool flag = this.TestBeamWidth(this._MinBeamWidth, this._MaxBeamWidth);
				if (this.mMotionLayer._AnimatorStateID == BalanceWalk.STATE_IdlePose)
				{
					if (flag)
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1400, true);
						return;
					}
					if (!this.mActorController.State.IsGrounded)
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1410, true);
						return;
					}
					if (this.mMotionLayer._AnimatorStateNormalizedTime > 1f)
					{
						this.Deactivate();
						return;
					}
				}
				else if (!flag)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1410, true);
				}
			}
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0003C3FC File Offset: 0x0003A5FC
		private void GetRotationVelocityWithInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			if (this.mMotionController._InputSource.IsViewingActivated)
			{
				float viewX = this.mMotionController._InputSource.ViewX;
				rRotation = Quaternion.Euler(0f, viewX * this.mDegreesPer60FPSTick, 0f);
			}
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x0003C458 File Offset: 0x0003A658
		private void GetRotationVelocityWithView(float rDeltaTime, ref Vector3 rRotationalVelocity)
		{
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = 0f;
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mMotionController._Transform.forward, this.mMotionController._CameraTransform.forward);
			if (horizontalAngle > 0f)
			{
				if (this._RotationSpeed == 0f)
				{
					num = horizontalAngle / smoothedDeltaTime;
				}
				else
				{
					if (this._RotationSpeed < 0f)
					{
						num = this.mMotionController._RotationSpeed;
					}
					else
					{
						num = this._RotationSpeed;
					}
					if (num * smoothedDeltaTime > horizontalAngle)
					{
						num = horizontalAngle / smoothedDeltaTime;
					}
				}
			}
			else if (horizontalAngle < 0f)
			{
				if (this._RotationSpeed == 0f)
				{
					num = horizontalAngle / smoothedDeltaTime;
				}
				else
				{
					if (this._RotationSpeed < 0f)
					{
						num = -this.mMotionController._RotationSpeed;
					}
					else
					{
						num = -this._RotationSpeed;
					}
					if (num * smoothedDeltaTime < horizontalAngle)
					{
						num = horizontalAngle / smoothedDeltaTime;
					}
				}
			}
			rRotationalVelocity = this.mMotionController._Transform.up * num;
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x0003C55C File Offset: 0x0003A75C
		private bool TestBeamWidth(float rMinWidth, float rMaxWidth)
		{
			if (this._ActivateUsingLayers && this.mActorController.State.Ground != null)
			{
				GameObject gameObject = this.mActorController.State.Ground.gameObject;
				int num = 1 << gameObject.layer;
				if ((this._BalanceLayers & num) > 0)
				{
					return true;
				}
			}
			if (this._ActivateUsingRaycasts)
			{
				Vector3 vector = this.mActorController._Transform.position - this.mActorController._Transform.up * (this.mActorController._SkinWidth * 2f);
				float num2 = rMaxWidth * 3f;
				float num3 = num2 * 0.5f;
				Vector3 vector2 = this.mActorController._Transform.right;
				RaycastHit raycastHit;
				if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit, num2, -1, this.mActorController._Transform, null, true, false))
				{
					vector2 = -vector2;
					RaycastHit raycastHit2;
					if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit2, num2, -1, this.mActorController._Transform, null, true, false) && raycastHit.collider == raycastHit2.collider)
					{
						float num4 = Vector3.Distance(raycastHit.point, raycastHit2.point);
						if (num4 > rMinWidth && num4 - 0.01f < rMaxWidth && Vector3.Angle(raycastHit.normal, raycastHit2.normal) > 170f)
						{
							return true;
						}
					}
				}
				vector2 = this.mActorController._Transform.forward;
				if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit, num2, -1, this.mActorController._Transform, null, true, false))
				{
					vector2 = -vector2;
					RaycastHit raycastHit2;
					if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit2, num2, -1, this.mActorController._Transform, null, true, false) && raycastHit.collider == raycastHit2.collider)
					{
						float num5 = Vector3.Distance(raycastHit.point, raycastHit2.point);
						if (num5 > rMinWidth && num5 - 0.01f < rMaxWidth && Vector3.Angle(raycastHit.normal, raycastHit2.normal) > 170f)
						{
							return true;
						}
					}
				}
				vector2 = (this.mActorController._Transform.forward + this.mActorController._Transform.right).normalized;
				if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit, num2, -1, this.mActorController._Transform, null, true, false))
				{
					vector2 = -vector2;
					RaycastHit raycastHit2;
					if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit2, num2, -1, this.mActorController._Transform, null, true, false) && raycastHit.collider == raycastHit2.collider)
					{
						float num6 = Vector3.Distance(raycastHit.point, raycastHit2.point);
						if (num6 > rMinWidth && num6 - 0.01f < rMaxWidth && Vector3.Angle(raycastHit.normal, raycastHit2.normal) > 170f)
						{
							return true;
						}
					}
				}
				vector2 = (this.mActorController._Transform.forward - this.mActorController._Transform.right).normalized;
				if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit, num2, -1, this.mActorController._Transform, null, true, false))
				{
					vector2 = -vector2;
					RaycastHit raycastHit2;
					if (RaycastExt.SafeRaycast(vector - vector2 * num3, vector2, out raycastHit2, num2, -1, this.mActorController._Transform, null, true, false) && raycastHit.collider == raycastHit2.collider)
					{
						float num7 = Vector3.Distance(raycastHit.point, raycastHit2.point);
						if (num7 > rMinWidth && num7 - 0.01f < rMaxWidth && Vector3.Angle(raycastHit.normal, raycastHit2.normal) > 170f)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x0003C980 File Offset: 0x0003AB80
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == BalanceWalk.STATE_BalanceForward || animatorStateID == BalanceWalk.STATE_BalanceBackward || animatorStateID == BalanceWalk.STATE_BalanceIdlePose || animatorStateID == BalanceWalk.STATE_IdlePose || animatorStateID == BalanceWalk.STATE_BalanceFallLeft || animatorTransitionID == BalanceWalk.TRANS_EntryState_BalanceIdlePose || animatorTransitionID == BalanceWalk.TRANS_AnyState_BalanceIdlePose || animatorTransitionID == BalanceWalk.TRANS_BalanceForward_BalanceBackward || animatorTransitionID == BalanceWalk.TRANS_BalanceForward_BalanceIdlePose || animatorTransitionID == BalanceWalk.TRANS_BalanceForward_IdlePose || animatorTransitionID == BalanceWalk.TRANS_BalanceForward_BalanceFallLeft || animatorTransitionID == BalanceWalk.TRANS_BalanceBackward_BalanceForward || animatorTransitionID == BalanceWalk.TRANS_BalanceBackward_BalanceIdlePose || animatorTransitionID == BalanceWalk.TRANS_BalanceBackward_IdlePose || animatorTransitionID == BalanceWalk.TRANS_BalanceBackward_BalanceFallLeft || animatorTransitionID == BalanceWalk.TRANS_BalanceIdlePose_BalanceForward || animatorTransitionID == BalanceWalk.TRANS_BalanceIdlePose_BalanceBackward || animatorTransitionID == BalanceWalk.TRANS_BalanceIdlePose_IdlePose || animatorTransitionID == BalanceWalk.TRANS_BalanceIdlePose_BalanceFallLeft || animatorTransitionID == BalanceWalk.TRANS_IdlePose_BalanceIdlePose;
			}
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x0003CA6E File Offset: 0x0003AC6E
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == BalanceWalk.STATE_BalanceForward || rStateID == BalanceWalk.STATE_BalanceBackward || rStateID == BalanceWalk.STATE_BalanceIdlePose || rStateID == BalanceWalk.STATE_IdlePose || rStateID == BalanceWalk.STATE_BalanceFallLeft;
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x0003CAA4 File Offset: 0x0003ACA4
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == BalanceWalk.STATE_BalanceForward || rStateID == BalanceWalk.STATE_BalanceBackward || rStateID == BalanceWalk.STATE_BalanceIdlePose || rStateID == BalanceWalk.STATE_IdlePose || rStateID == BalanceWalk.STATE_BalanceFallLeft || rTransitionID == BalanceWalk.TRANS_EntryState_BalanceIdlePose || rTransitionID == BalanceWalk.TRANS_AnyState_BalanceIdlePose || rTransitionID == BalanceWalk.TRANS_BalanceForward_BalanceBackward || rTransitionID == BalanceWalk.TRANS_BalanceForward_BalanceIdlePose || rTransitionID == BalanceWalk.TRANS_BalanceForward_IdlePose || rTransitionID == BalanceWalk.TRANS_BalanceForward_BalanceFallLeft || rTransitionID == BalanceWalk.TRANS_BalanceBackward_BalanceForward || rTransitionID == BalanceWalk.TRANS_BalanceBackward_BalanceIdlePose || rTransitionID == BalanceWalk.TRANS_BalanceBackward_IdlePose || rTransitionID == BalanceWalk.TRANS_BalanceBackward_BalanceFallLeft || rTransitionID == BalanceWalk.TRANS_BalanceIdlePose_BalanceForward || rTransitionID == BalanceWalk.TRANS_BalanceIdlePose_BalanceBackward || rTransitionID == BalanceWalk.TRANS_BalanceIdlePose_IdlePose || rTransitionID == BalanceWalk.TRANS_BalanceIdlePose_BalanceFallLeft || rTransitionID == BalanceWalk.TRANS_IdlePose_BalanceIdlePose;
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0003CB7C File Offset: 0x0003AD7C
		public override void LoadAnimatorData()
		{
			BalanceWalk.TRANS_EntryState_BalanceIdlePose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.BalanceWalk-SM.BalanceIdlePose");
			BalanceWalk.TRANS_AnyState_BalanceIdlePose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.BalanceWalk-SM.BalanceIdlePose");
			BalanceWalk.STATE_BalanceForward = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceForward");
			BalanceWalk.TRANS_BalanceForward_BalanceBackward = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceForward -> Base Layer.BalanceWalk-SM.BalanceBackward");
			BalanceWalk.TRANS_BalanceForward_BalanceIdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceForward -> Base Layer.BalanceWalk-SM.BalanceIdlePose");
			BalanceWalk.TRANS_BalanceForward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceForward -> Base Layer.BalanceWalk-SM.IdlePose");
			BalanceWalk.TRANS_BalanceForward_BalanceFallLeft = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceForward -> Base Layer.BalanceWalk-SM.BalanceFallLeft");
			BalanceWalk.STATE_BalanceBackward = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceBackward");
			BalanceWalk.TRANS_BalanceBackward_BalanceForward = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceBackward -> Base Layer.BalanceWalk-SM.BalanceForward");
			BalanceWalk.TRANS_BalanceBackward_BalanceIdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceBackward -> Base Layer.BalanceWalk-SM.BalanceIdlePose");
			BalanceWalk.TRANS_BalanceBackward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceBackward -> Base Layer.BalanceWalk-SM.IdlePose");
			BalanceWalk.TRANS_BalanceBackward_BalanceFallLeft = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceBackward -> Base Layer.BalanceWalk-SM.BalanceFallLeft");
			BalanceWalk.STATE_BalanceIdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceIdlePose");
			BalanceWalk.TRANS_BalanceIdlePose_BalanceForward = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceIdlePose -> Base Layer.BalanceWalk-SM.BalanceForward");
			BalanceWalk.TRANS_BalanceIdlePose_BalanceBackward = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceIdlePose -> Base Layer.BalanceWalk-SM.BalanceBackward");
			BalanceWalk.TRANS_BalanceIdlePose_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceIdlePose -> Base Layer.BalanceWalk-SM.IdlePose");
			BalanceWalk.TRANS_BalanceIdlePose_BalanceFallLeft = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceIdlePose -> Base Layer.BalanceWalk-SM.BalanceFallLeft");
			BalanceWalk.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.IdlePose");
			BalanceWalk.TRANS_IdlePose_BalanceIdlePose = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.IdlePose -> Base Layer.BalanceWalk-SM.BalanceIdlePose");
			BalanceWalk.STATE_BalanceFallLeft = this.mMotionController.AddAnimatorName("Base Layer.BalanceWalk-SM.BalanceFallLeft");
		}

		// Token: 0x0400068B RID: 1675
		private const float EPSILON = 0.01f;

		// Token: 0x0400068C RID: 1676
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x0400068D RID: 1677
		public const int PHASE_START = 1400;

		// Token: 0x0400068E RID: 1678
		public const int PHASE_FALL = 1405;

		// Token: 0x0400068F RID: 1679
		public const int PHASE_END = 1410;

		// Token: 0x04000690 RID: 1680
		public float _MinBeamWidth = 0.05f;

		// Token: 0x04000691 RID: 1681
		public float _MaxBeamWidth = 0.1f;

		// Token: 0x04000692 RID: 1682
		public bool _RotateWithInput = true;

		// Token: 0x04000693 RID: 1683
		public bool _RotateWithView;

		// Token: 0x04000694 RID: 1684
		public float _RotationSpeed = 120f;

		// Token: 0x04000695 RID: 1685
		public bool _ActivateUsingRaycasts = true;

		// Token: 0x04000696 RID: 1686
		public bool _ActivateUsingLayers;

		// Token: 0x04000697 RID: 1687
		public int _BalanceLayers;

		// Token: 0x04000698 RID: 1688
		protected float mDegreesPer60FPSTick = 1f;

		// Token: 0x04000699 RID: 1689
		protected bool mIsFalling;

		// Token: 0x0400069A RID: 1690
		protected Vector3 mPushDirection = Vector3.zero;

		// Token: 0x0400069B RID: 1691
		public static int TRANS_EntryState_BalanceIdlePose = -1;

		// Token: 0x0400069C RID: 1692
		public static int TRANS_AnyState_BalanceIdlePose = -1;

		// Token: 0x0400069D RID: 1693
		public static int STATE_BalanceForward = -1;

		// Token: 0x0400069E RID: 1694
		public static int TRANS_BalanceForward_BalanceBackward = -1;

		// Token: 0x0400069F RID: 1695
		public static int TRANS_BalanceForward_BalanceIdlePose = -1;

		// Token: 0x040006A0 RID: 1696
		public static int TRANS_BalanceForward_IdlePose = -1;

		// Token: 0x040006A1 RID: 1697
		public static int TRANS_BalanceForward_BalanceFallLeft = -1;

		// Token: 0x040006A2 RID: 1698
		public static int STATE_BalanceBackward = -1;

		// Token: 0x040006A3 RID: 1699
		public static int TRANS_BalanceBackward_BalanceForward = -1;

		// Token: 0x040006A4 RID: 1700
		public static int TRANS_BalanceBackward_BalanceIdlePose = -1;

		// Token: 0x040006A5 RID: 1701
		public static int TRANS_BalanceBackward_IdlePose = -1;

		// Token: 0x040006A6 RID: 1702
		public static int TRANS_BalanceBackward_BalanceFallLeft = -1;

		// Token: 0x040006A7 RID: 1703
		public static int STATE_BalanceIdlePose = -1;

		// Token: 0x040006A8 RID: 1704
		public static int TRANS_BalanceIdlePose_BalanceForward = -1;

		// Token: 0x040006A9 RID: 1705
		public static int TRANS_BalanceIdlePose_BalanceBackward = -1;

		// Token: 0x040006AA RID: 1706
		public static int TRANS_BalanceIdlePose_IdlePose = -1;

		// Token: 0x040006AB RID: 1707
		public static int TRANS_BalanceIdlePose_BalanceFallLeft = -1;

		// Token: 0x040006AC RID: 1708
		public static int STATE_IdlePose = -1;

		// Token: 0x040006AD RID: 1709
		public static int TRANS_IdlePose_BalanceIdlePose = -1;

		// Token: 0x040006AE RID: 1710
		public static int STATE_BalanceFallLeft = -1;
	}
}
