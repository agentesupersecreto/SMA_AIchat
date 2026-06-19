using System;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Timing;
using UnityEngine;
using UnityEngine.AI;

namespace com.ootii.Input
{
	// Token: 0x0200002D RID: 45
	[AddComponentMenu("ootii/Input Sources/Nav Mesh Input Source")]
	public class NavMeshInputSource : UnityInputSource
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000AFA6 File Offset: 0x000091A6
		// (set) Token: 0x06000226 RID: 550 RVA: 0x0000AFB0 File Offset: 0x000091B0
		public override bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				if (this._IsEnabled && !value)
				{
					if (this.mIsTargetSet)
					{
						this.mNavMeshAgent.isStopped = true;
					}
				}
				else if (!this._IsEnabled && value && this.mIsTargetSet)
				{
					this.SetDestination(this._TargetPosition);
				}
				this._IsEnabled = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000B006 File Offset: 0x00009206
		// (set) Token: 0x06000228 RID: 552 RVA: 0x0000B00E File Offset: 0x0000920E
		public float NormalizedSpeed
		{
			get
			{
				return this._NormalizedSpeed;
			}
			set
			{
				this._NormalizedSpeed = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000229 RID: 553 RVA: 0x0000B01C File Offset: 0x0000921C
		// (set) Token: 0x0600022A RID: 554 RVA: 0x0000B024 File Offset: 0x00009224
		public bool UseStrafingInput
		{
			get
			{
				return this._UseStrafingInput;
			}
			set
			{
				this._UseStrafingInput = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600022B RID: 555 RVA: 0x0000B02D File Offset: 0x0000922D
		// (set) Token: 0x0600022C RID: 556 RVA: 0x0000B038 File Offset: 0x00009238
		public Transform Target
		{
			get
			{
				return this._Target;
			}
			set
			{
				this._Target = value;
				if (this._Target == null)
				{
					this.mNavMeshAgent.isStopped = true;
					this.mHasArrived = false;
					this.mIsInSlowDistance = false;
					this.mIsTargetSet = false;
					this._TargetPosition = Vector3Ext.Null;
					return;
				}
				this.mIsTargetSet = true;
				this._TargetPosition = this._Target.position;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600022D RID: 557 RVA: 0x0000B09F File Offset: 0x0000929F
		// (set) Token: 0x0600022E RID: 558 RVA: 0x0000B0A8 File Offset: 0x000092A8
		public Vector3 TargetPosition
		{
			get
			{
				return this._TargetPosition;
			}
			set
			{
				this._Target = null;
				this._TargetPosition = value;
				if (this._TargetPosition == Vector3Ext.Null)
				{
					this.mNavMeshAgent.isStopped = true;
					this.mHasArrived = false;
					this.mIsInSlowDistance = false;
					this.mIsTargetSet = false;
					return;
				}
				this.mIsTargetSet = true;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0000B0FE File Offset: 0x000092FE
		// (set) Token: 0x06000230 RID: 560 RVA: 0x0000B106 File Offset: 0x00009306
		public float StopDistance
		{
			get
			{
				return this._StopDistance;
			}
			set
			{
				this._StopDistance = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000231 RID: 561 RVA: 0x0000B10F File Offset: 0x0000930F
		// (set) Token: 0x06000232 RID: 562 RVA: 0x0000B117 File Offset: 0x00009317
		public float SlowDistance
		{
			get
			{
				return this._SlowDistance;
			}
			set
			{
				this._SlowDistance = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0000B120 File Offset: 0x00009320
		// (set) Token: 0x06000234 RID: 564 RVA: 0x0000B128 File Offset: 0x00009328
		public float SlowFactor
		{
			get
			{
				return this._SlowFactor;
			}
			set
			{
				this._SlowFactor = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000235 RID: 565 RVA: 0x0000B131 File Offset: 0x00009331
		// (set) Token: 0x06000236 RID: 566 RVA: 0x0000B139 File Offset: 0x00009339
		public bool AllowUserInput
		{
			get
			{
				return this._AllowUserInput;
			}
			set
			{
				this._AllowUserInput = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000237 RID: 567 RVA: 0x0000B142 File Offset: 0x00009342
		// (set) Token: 0x06000238 RID: 568 RVA: 0x0000B14A File Offset: 0x0000934A
		public float PathHeight
		{
			get
			{
				return this._PathHeight;
			}
			set
			{
				this._PathHeight = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0000B153 File Offset: 0x00009353
		public bool IsTargetSet
		{
			get
			{
				return this.mIsTargetSet;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000B15B File Offset: 0x0000935B
		public bool HasArrived
		{
			get
			{
				return this.mHasArrived;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000B163 File Offset: 0x00009363
		public bool IsInSlowDistance
		{
			get
			{
				return this.IsInSlowDistance;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000B16B File Offset: 0x0000936B
		// (set) Token: 0x0600023D RID: 573 RVA: 0x0000B181 File Offset: 0x00009381
		public override float InputFromCameraAngle
		{
			get
			{
				if (!this._IsEnabled)
				{
					return 0f;
				}
				return this.mInputFromCameraAngle;
			}
			set
			{
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000B183 File Offset: 0x00009383
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000B199 File Offset: 0x00009399
		public override float InputFromAvatarAngle
		{
			get
			{
				if (!this._IsEnabled)
				{
					return 0f;
				}
				return this.mInputFromAvatarAngle;
			}
			set
			{
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000B19B File Offset: 0x0000939B
		public override float MovementX
		{
			get
			{
				if (!this._IsEnabled)
				{
					return 0f;
				}
				return this.mMovementX;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000B1B1 File Offset: 0x000093B1
		public override float MovementY
		{
			get
			{
				if (!this._IsEnabled)
				{
					return 0f;
				}
				return this.mMovementY;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0000B1C7 File Offset: 0x000093C7
		public override bool IsViewingActivated
		{
			get
			{
				return this.mViewX != 0f;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0000B1D9 File Offset: 0x000093D9
		public override float ViewX
		{
			get
			{
				if (!this._IsEnabled)
				{
					return 0f;
				}
				return this.mViewX;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000B1EF File Offset: 0x000093EF
		public override float ViewY
		{
			get
			{
				if (!this._IsEnabled)
				{
					return 0f;
				}
				return this.mViewY;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000B205 File Offset: 0x00009405
		// (set) Token: 0x06000246 RID: 582 RVA: 0x0000B20D File Offset: 0x0000940D
		public float MaxViewSpeed
		{
			get
			{
				return this._MaxViewSpeed;
			}
			set
			{
				this._MaxViewSpeed = value;
				this.mViewSpeedPer60FPSTick = this._MaxViewSpeed * 60f;
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000B228 File Offset: 0x00009428
		protected void Awake()
		{
			this._Transform = base.gameObject.transform;
			this.mActorController = base.gameObject.GetComponent<ActorController>();
			if (base.enabled)
			{
				this.OnEnable();
			}
			this.mMotionController = base.gameObject.GetComponent<MotionController>();
			this.mNavMeshAgent = base.gameObject.GetComponent<NavMeshAgent>();
			if (this.mNavMeshAgent != null)
			{
				this.mNavMeshAgent.updatePosition = false;
				this.mNavMeshAgent.updateRotation = false;
			}
			this.mViewSpeedPer60FPSTick = this._MaxViewSpeed * 60f;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000B2BF File Offset: 0x000094BF
		protected virtual void Start()
		{
			if (this._Target != null)
			{
				this.Target = this._Target;
				return;
			}
			if (this._TargetPosition.magnitude > 0f)
			{
				this.TargetPosition = this._TargetPosition;
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000B2FC File Offset: 0x000094FC
		protected void OnEnable()
		{
			if (this.mActorController != null)
			{
				if (this.mActorController.OnControllerPreLateUpdate != null)
				{
					ActorController actorController = this.mActorController;
					actorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(actorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
				ControllerLateUpdateDelegate onControllerPreLateUpdate = this.mActorController.OnControllerPreLateUpdate;
				this.mActorController.OnControllerPreLateUpdate = new ControllerLateUpdateDelegate(this.OnControllerLateUpdate);
				ActorController actorController2 = this.mActorController;
				actorController2.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(actorController2.OnControllerPreLateUpdate, onControllerPreLateUpdate);
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000B38C File Offset: 0x0000958C
		protected void OnDisable()
		{
			if (this.mActorController != null && this.mActorController.OnControllerPreLateUpdate != null)
			{
				ActorController actorController = this.mActorController;
				actorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(actorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000B3DC File Offset: 0x000095DC
		public void ClearTarget()
		{
			this._Target = null;
			this._TargetPosition = Vector3Ext.Null;
			this.mNavMeshAgent.isStopped = true;
			this.mHasArrived = false;
			this.mIsPathValid = true;
			this.mFirstPathSet = false;
			this.mFirstPathValid = false;
			this.mIsInSlowDistance = false;
			this.mIsTargetSet = false;
			this.mViewX = 0f;
			this.mViewY = 0f;
			this.mMovementX = 0f;
			this.mMovementY = 0f;
			this.mInputFromAvatarAngle = 0f;
			this.mInputFromCameraAngle = 0f;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000B473 File Offset: 0x00009673
		public override bool IsJustPressed(KeyCode rKey)
		{
			return this._AllowUserInput && base.IsJustPressed(rKey);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000B486 File Offset: 0x00009686
		public override bool IsJustPressed(int rKey)
		{
			return this._AllowUserInput && base.IsJustPressed(rKey);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000B499 File Offset: 0x00009699
		public override bool IsJustPressed(string rAction)
		{
			return this._AllowUserInput && base.IsJustPressed(rAction);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000B4AC File Offset: 0x000096AC
		public override bool IsPressed(KeyCode rKey)
		{
			return this._AllowUserInput && base.IsPressed(rKey);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000B4BF File Offset: 0x000096BF
		public override bool IsPressed(int rKey)
		{
			return this._AllowUserInput && base.IsPressed(rKey);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000B4D2 File Offset: 0x000096D2
		public override bool IsPressed(string rAction)
		{
			if (rAction == "ActivateRotation")
			{
				return this.mViewX != 0f;
			}
			return this._AllowUserInput && base.IsPressed(rAction);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000B503 File Offset: 0x00009703
		public override bool IsJustReleased(KeyCode rKey)
		{
			return this._AllowUserInput && base.IsJustReleased(rKey);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000B516 File Offset: 0x00009716
		public override bool IsJustReleased(int rKey)
		{
			return this._AllowUserInput && base.IsJustReleased(rKey);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B529 File Offset: 0x00009729
		public override bool IsJustReleased(string rAction)
		{
			return this._AllowUserInput && base.IsJustReleased(rAction);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000B53C File Offset: 0x0000973C
		public override bool IsReleased(KeyCode rKey)
		{
			return !this._AllowUserInput || base.IsReleased(rKey);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000B54F File Offset: 0x0000974F
		public override bool IsReleased(int rKey)
		{
			return !this._AllowUserInput || base.IsReleased(rKey);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000B562 File Offset: 0x00009762
		public override bool IsReleased(string rAction)
		{
			return !this._AllowUserInput || base.IsReleased(rAction);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000B575 File Offset: 0x00009775
		public override float GetValue(int rKey)
		{
			if (this._AllowUserInput)
			{
				return base.GetValue(rKey);
			}
			return 0f;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000B58C File Offset: 0x0000978C
		public override float GetValue(string rAction)
		{
			if (this._AllowUserInput)
			{
				return base.GetValue(rAction);
			}
			return 0f;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000B5A4 File Offset: 0x000097A4
		protected void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			if (!this._IsEnabled)
			{
				return;
			}
			if (this.mActorController == null)
			{
				return;
			}
			if (this.mNavMeshAgent == null)
			{
				return;
			}
			if (!this.mIsTargetSet)
			{
				return;
			}
			this.mViewX = 0f;
			this.mViewY = 0f;
			this.mMovementX = 0f;
			this.mMovementY = 0f;
			this.mInputFromAvatarAngle = 0f;
			this.mInputFromCameraAngle = 0f;
			if (this.mFirstPathSet && this.mNavMeshAgent.hasPath && !this.mNavMeshAgent.pathPending)
			{
				this.mFirstPathValid = true;
			}
			if (this._Target != null)
			{
				this._TargetPosition = this._Target.position;
			}
			this.SetDestination(this._TargetPosition);
			this.mTargetVector = this.mAgentDestination - this._Transform.position;
			this.mTargetDistance = this.mTargetVector.magnitude;
			if (this.mTargetDistance < this._StopDistance)
			{
				this.ClearTarget();
				this.mHasArrived = true;
				this.mFirstPathSet = false;
				this.mFirstPathValid = false;
				this.OnArrived();
				this.mNavMeshAgent.nextPosition = this._Transform.position;
			}
			if (!this.mHasArrived && this.mFirstPathValid)
			{
				if (this.mNavMeshAgent.hasPath && !this.mNavMeshAgent.pathPending)
				{
					this.mIsPathValid = true;
					this.mWaypoint = this.mNavMeshAgent.steeringTarget;
					this.mWaypointVector = this.mNavMeshAgent.desiredVelocity;
					this.mWaypointDistance = this.mWaypointVector.magnitude;
					if (this.mTargetDistance > this._SlowDistance)
					{
						this.mIsInSlowDistance = false;
					}
				}
				if (this._SlowDistance > 0f && this.mTargetDistance < this._SlowDistance)
				{
					if (!this.mIsInSlowDistance)
					{
						this.OnSlowDistanceEntered();
					}
					this.mIsInSlowDistance = true;
				}
				if (this._UseStrafingInput)
				{
					this.SimulateStrafeInput();
				}
				else
				{
					this.SimulateInput();
				}
				this.mNavMeshAgent.nextPosition = this._Transform.position;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000B7C4 File Offset: 0x000099C4
		protected void SimulateStrafeInput()
		{
			Vector3 vector = this.mWaypointVector;
			vector.y -= this._PathHeight;
			vector.Normalize();
			Vector3 vector2 = Vector3.Project(vector, this._Transform.up);
			Vector3 vector3 = (vector - vector2).normalized;
			this.mInputFromAvatarAngle = Vector3Ext.SignedAngle(this._Transform.forward, vector3);
			if (this.mTargetDistance > this._StopDistance)
			{
				float num = this._NormalizedSpeed;
				if (this.mIsInSlowDistance && this._SlowFactor > 0f)
				{
					float num2 = (this.mTargetDistance - this._StopDistance) / (this._SlowDistance - this._StopDistance);
					num = (1f - this._SlowFactor) * num2 + this._SlowFactor;
				}
				if (this.mIsInSlowDistance && this._SlowFactor > 0f)
				{
					num = this._SlowFactor;
				}
				vector3 = this._Transform.InverseTransformDirection(vector3);
				this.mMovementX = vector3.x * num;
				this.mMovementY = vector3.z * num;
				this.mMotionController.TargetNormalizedSpeed = num;
			}
			if (this.mMotionController._CameraTransform == null)
			{
				this.mInputFromCameraAngle = this.mInputFromAvatarAngle;
				return;
			}
			Vector3 vector4 = new Vector3(this.mMovementX, 0f, this.mMovementY);
			Quaternion quaternion = QuaternionExt.FromToRotation(this._Transform.up, Vector3.up);
			Vector3 vector5 = quaternion * this.mMotionController._CameraTransform.forward;
			Vector3 vector6 = Quaternion.LookRotation(vector5, quaternion * this._Transform.up) * vector4;
			this.mInputFromCameraAngle = NumberHelper.GetHorizontalAngle(vector5, vector6);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000B980 File Offset: 0x00009B80
		protected void SimulateInput()
		{
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			Vector3 vector = this.mWaypointVector;
			vector.y -= this._PathHeight;
			vector.Normalize();
			Vector3 vector2 = Vector3.Project(vector, this._Transform.up);
			Vector3 vector3 = vector - vector2;
			this.mInputFromAvatarAngle = Vector3Ext.SignedAngle(this._Transform.forward, vector3);
			float num = Mathf.Min(Mathf.Abs(this.mInputFromAvatarAngle * smoothedDeltaTime), this.mViewSpeedPer60FPSTick * smoothedDeltaTime);
			if (num < 0.01f)
			{
				num = 0f;
			}
			this.mViewX = Mathf.Sign(this.mInputFromAvatarAngle) * num;
			if (this.mTargetDistance > this._StopDistance)
			{
				float num2 = this._NormalizedSpeed;
				if (this.mIsInSlowDistance && this._SlowFactor > 0f)
				{
					float num3 = (this.mTargetDistance - this._StopDistance) / (this._SlowDistance - this._StopDistance);
					num2 = (1f - this._SlowFactor) * num3 + this._SlowFactor;
				}
				if (this.mIsInSlowDistance && this._SlowFactor > 0f)
				{
					num2 = this._SlowFactor;
				}
				this.mMovementY = 1f * num2;
				this.mMotionController.TargetNormalizedSpeed = num2;
			}
			if (this.mMotionController._CameraTransform == null)
			{
				this.mInputFromCameraAngle = this.mInputFromAvatarAngle;
				return;
			}
			Vector3 vector4 = new Vector3(this.mMovementX, 0f, this.mMovementY);
			Quaternion quaternion = QuaternionExt.FromToRotation(this._Transform.up, Vector3.up);
			Vector3 vector5 = quaternion * this.mMotionController._CameraTransform.forward;
			Vector3 vector6 = Quaternion.LookRotation(vector5, quaternion * this._Transform.up) * vector4;
			this.mInputFromCameraAngle = NumberHelper.GetHorizontalAngle(vector5, vector6);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000BB5C File Offset: 0x00009D5C
		protected virtual void SetDestination(Vector3 rDestination)
		{
			if (!this.mHasArrived && this.mAgentDestination == rDestination)
			{
				return;
			}
			this.mHasArrived = false;
			this.mAgentDestination = rDestination;
			if (this.mIsPathValid && !this.mNavMeshAgent.pathPending)
			{
				this.mIsPathValid = false;
				this.mNavMeshAgent.updatePosition = false;
				this.mNavMeshAgent.updateRotation = false;
				this.mNavMeshAgent.stoppingDistance = this._StopDistance;
				this.mNavMeshAgent.ResetPath();
				this.mNavMeshAgent.SetDestination(this.mAgentDestination);
				this.mFirstPathSet = true;
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000BBF7 File Offset: 0x00009DF7
		protected virtual void OnArrived()
		{
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000BBF9 File Offset: 0x00009DF9
		protected virtual void OnSlowDistanceEntered()
		{
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000BBFC File Offset: 0x00009DFC
		protected void OnDrawGizmos()
		{
			if (this.mNavMeshAgent == null)
			{
				return;
			}
			if (this.mNavMeshAgent.path == null)
			{
				return;
			}
			Color color = Gizmos.color;
			Gizmos.color = Color.green;
			for (int i = 1; i < this.mNavMeshAgent.path.corners.Length; i++)
			{
				Gizmos.DrawLine(this.mNavMeshAgent.path.corners[i - 1], this.mNavMeshAgent.path.corners[i]);
			}
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(this.mNavMeshAgent.steeringTarget, 0.1f);
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(this.mWaypoint, 0.1f);
			Gizmos.DrawRay(base.transform.position, this.mTargetVector.normalized);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.mAgentDestination, this._StopDistance);
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(this.mAgentDestination, this._SlowDistance);
			Gizmos.color = color;
		}

		// Token: 0x0400014F RID: 335
		public const float EPSILON = 0.01f;

		// Token: 0x04000150 RID: 336
		public float _NormalizedSpeed = 1f;

		// Token: 0x04000151 RID: 337
		public bool _UseStrafingInput;

		// Token: 0x04000152 RID: 338
		public Transform _Target;

		// Token: 0x04000153 RID: 339
		public Vector3 _TargetPosition = Vector3.zero;

		// Token: 0x04000154 RID: 340
		public float _StopDistance = 0.5f;

		// Token: 0x04000155 RID: 341
		public float _SlowDistance = 4f;

		// Token: 0x04000156 RID: 342
		public float _SlowFactor = 0.5f;

		// Token: 0x04000157 RID: 343
		public bool _AllowUserInput;

		// Token: 0x04000158 RID: 344
		public float _PathHeight = 0.05f;

		// Token: 0x04000159 RID: 345
		protected bool mIsTargetSet;

		// Token: 0x0400015A RID: 346
		protected bool mHasArrived;

		// Token: 0x0400015B RID: 347
		protected bool mIsInSlowDistance;

		// Token: 0x0400015C RID: 348
		protected float mInputFromCameraAngle;

		// Token: 0x0400015D RID: 349
		protected float mInputFromAvatarAngle;

		// Token: 0x0400015E RID: 350
		protected float mMovementX;

		// Token: 0x0400015F RID: 351
		protected float mMovementY;

		// Token: 0x04000160 RID: 352
		protected float mViewX;

		// Token: 0x04000161 RID: 353
		protected float mViewY;

		// Token: 0x04000162 RID: 354
		public float _MaxViewSpeed = 1f;

		// Token: 0x04000163 RID: 355
		protected Transform _Transform;

		// Token: 0x04000164 RID: 356
		protected NavMeshAgent mNavMeshAgent;

		// Token: 0x04000165 RID: 357
		protected ActorController mActorController;

		// Token: 0x04000166 RID: 358
		protected MotionController mMotionController;

		// Token: 0x04000167 RID: 359
		protected Vector3 mWaypoint = Vector3.zero;

		// Token: 0x04000168 RID: 360
		protected Vector3 mAgentDestination = Vector3Ext.Null;

		// Token: 0x04000169 RID: 361
		protected float mViewSpeedPer60FPSTick = 1f;

		// Token: 0x0400016A RID: 362
		protected Vector3 mTargetVector = Vector3.zero;

		// Token: 0x0400016B RID: 363
		protected float mTargetDistance;

		// Token: 0x0400016C RID: 364
		protected Vector3 mWaypointVector = Vector3.zero;

		// Token: 0x0400016D RID: 365
		protected float mWaypointDistance;

		// Token: 0x0400016E RID: 366
		protected bool mFirstPathSet;

		// Token: 0x0400016F RID: 367
		protected bool mFirstPathValid;

		// Token: 0x04000170 RID: 368
		protected bool mIsPathValid = true;
	}
}
