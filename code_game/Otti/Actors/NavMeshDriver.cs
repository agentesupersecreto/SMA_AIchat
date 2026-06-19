using System;
using com.ootii.Geometry;
using com.ootii.Timing;
using UnityEngine;
using UnityEngine.AI;

namespace com.ootii.Actors
{
	// Token: 0x0200008E RID: 142
	[AddComponentMenu("ootii/Actor Drivers/Nav Mesh Driver")]
	public class NavMeshDriver : AnimatorDriver
	{
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0002B3D9 File Offset: 0x000295D9
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x0002B3E4 File Offset: 0x000295E4
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

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0002B43A File Offset: 0x0002963A
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0002B442 File Offset: 0x00029642
		public bool UseNavMeshPosition
		{
			get
			{
				return this._UseNavMeshPosition;
			}
			set
			{
				this._UseNavMeshPosition = value;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x0002B44B File Offset: 0x0002964B
		// (set) Token: 0x060007FF RID: 2047 RVA: 0x0002B454 File Offset: 0x00029654
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
					this.mActorController.SetRelativeVelocity(Vector3.zero);
					return;
				}
				this.mIsTargetSet = true;
				this._TargetPosition = this._Target.position;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0002B4CB File Offset: 0x000296CB
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x0002B4D4 File Offset: 0x000296D4
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
					this.mActorController.SetRelativeVelocity(Vector3.zero);
					return;
				}
				this.mIsTargetSet = true;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0002B53A File Offset: 0x0002973A
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x0002B542 File Offset: 0x00029742
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

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x0002B54B File Offset: 0x0002974B
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x0002B553 File Offset: 0x00029753
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

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0002B55C File Offset: 0x0002975C
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x0002B564 File Offset: 0x00029764
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

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0002B56D File Offset: 0x0002976D
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x0002B575 File Offset: 0x00029775
		public bool ClearTargetOnStop
		{
			get
			{
				return this._ClearTargetOnStop;
			}
			set
			{
				this._ClearTargetOnStop = value;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x0002B57E File Offset: 0x0002977E
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x0002B586 File Offset: 0x00029786
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

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0002B58F File Offset: 0x0002978F
		public bool IsTargetSet
		{
			get
			{
				return this.mIsTargetSet;
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x0002B597 File Offset: 0x00029797
		public bool HasArrived
		{
			get
			{
				return this.mHasArrived;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0002B59F File Offset: 0x0002979F
		public bool IsInSlowDistance
		{
			get
			{
				return this.IsInSlowDistance;
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0002B5A8 File Offset: 0x000297A8
		protected override void Awake()
		{
			base.Awake();
			this.mNavMeshAgent = base.gameObject.GetComponent<NavMeshAgent>();
			if (this.mNavMeshAgent != null)
			{
				this.mNavMeshAgent.updatePosition = false;
				this.mNavMeshAgent.updateRotation = false;
				if (this._MovementSpeed > 0f)
				{
					this.mNavMeshAgent.speed = this._MovementSpeed;
				}
				if (this._RotationSpeed > 0f)
				{
					this.mNavMeshAgent.angularSpeed = this._RotationSpeed;
				}
			}
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0002B62E File Offset: 0x0002982E
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

		// Token: 0x06000811 RID: 2065 RVA: 0x0002B66C File Offset: 0x0002986C
		public void ClearTarget()
		{
			if (this._ClearTargetOnStop)
			{
				this._Target = null;
				this._TargetPosition = Vector3Ext.Null;
				this.mIsTargetSet = false;
			}
			this.mNavMeshAgent.isStopped = true;
			this.mHasArrived = false;
			this.mIsPathValid = true;
			this.mFirstPathSet = false;
			this.mFirstPathValid = false;
			this.mIsInSlowDistance = false;
			this.mActorController.SetRelativeVelocity(Vector3.zero);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0002B6DC File Offset: 0x000298DC
		protected override void Update()
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
			Vector3 zero = Vector3.zero;
			Quaternion identity = Quaternion.identity;
			if (this.mFirstPathSet && this.mNavMeshAgent.hasPath && !this.mNavMeshAgent.pathPending)
			{
				this.mFirstPathValid = true;
			}
			if (this._Target != null)
			{
				this._TargetPosition = this._Target.position;
			}
			this.SetDestination(this._TargetPosition);
			this.mTargetVector = this.mAgentDestination - base.transform.position;
			this.mTargetDistance = this.mTargetVector.magnitude;
			if (this._UseNavMeshPosition)
			{
				if (!this.mNavMeshAgent.pathPending && this.mNavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && this.mNavMeshAgent.remainingDistance == 0f)
				{
					this.ClearTarget();
					this.mHasArrived = true;
					this.mFirstPathSet = false;
					this.mFirstPathValid = false;
					this.OnArrived();
				}
			}
			else if (this.mTargetDistance < this._StopDistance)
			{
				this.ClearTarget();
				this.mHasArrived = true;
				this.OnArrived();
			}
			if (!this.mHasArrived && this.mFirstPathValid)
			{
				if (this.mNavMeshAgent.hasPath && !this.mNavMeshAgent.pathPending)
				{
					this.mIsPathValid = true;
					this.mWaypoint = this.mNavMeshAgent.steeringTarget;
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
				this.CalculateMove(this.mWaypoint, ref zero, ref identity);
				this.mActorController.Move(zero);
				this.mActorController.Rotate(identity);
				if (!this._UseNavMeshPosition)
				{
					this.mNavMeshAgent.nextPosition = base.transform.position;
				}
			}
			this.SetAnimatorProperties(Vector3.zero, zero, identity);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0002B900 File Offset: 0x00029B00
		protected virtual void CalculateMove(Vector3 rWaypoint, ref Vector3 rMove, ref Quaternion rRotate)
		{
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			Vector3 vector = rWaypoint - base.transform.position;
			vector.y -= this._PathHeight;
			vector.Normalize();
			Vector3 vector2 = Vector3.Project(vector, base.transform.up);
			Vector3 vector3 = vector - vector2;
			float num = Vector3Ext.SignedAngle(base.transform.forward, vector3);
			if (this._RotationSpeed == 0f)
			{
				rRotate = Quaternion.AngleAxis(num, base.transform.up);
			}
			else
			{
				rRotate = Quaternion.AngleAxis(Mathf.Sign(num) * Mathf.Min(Mathf.Abs(num), this._RotationSpeed * smoothedDeltaTime), base.transform.up);
			}
			if (this._UseNavMeshPosition)
			{
				rMove = this.mNavMeshAgent.nextPosition - base.transform.position;
				return;
			}
			float num2 = this.mRootMotionMovement.magnitude / smoothedDeltaTime;
			if (num2 == 0f)
			{
				num2 = this._MovementSpeed;
			}
			float num3 = 1f;
			if (this.mIsInSlowDistance && this._SlowFactor > 0f)
			{
				float num4 = (this.mTargetDistance - this._StopDistance) / (this._SlowDistance - this._StopDistance);
				num3 = (1f - this._SlowFactor) * num4 + this._SlowFactor;
			}
			if (this.mIsInSlowDistance && this._SlowFactor > 0f)
			{
				num2 = this._SlowFactor;
				num3 = 1f;
			}
			Quaternion quaternion = base.transform.rotation * rRotate;
			rMove = quaternion.Forward() * (num2 * num3 * smoothedDeltaTime);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0002BAB8 File Offset: 0x00029CB8
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

		// Token: 0x06000815 RID: 2069 RVA: 0x0002BB53 File Offset: 0x00029D53
		protected virtual void OnArrived()
		{
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0002BB55 File Offset: 0x00029D55
		protected virtual void OnSlowDistanceEntered()
		{
		}

		// Token: 0x04000418 RID: 1048
		public const float EPSILON = 0.01f;

		// Token: 0x04000419 RID: 1049
		public bool _UseNavMeshPosition;

		// Token: 0x0400041A RID: 1050
		public Transform _Target;

		// Token: 0x0400041B RID: 1051
		public Vector3 _TargetPosition = Vector3.zero;

		// Token: 0x0400041C RID: 1052
		public float _StopDistance = 0.1f;

		// Token: 0x0400041D RID: 1053
		public float _SlowDistance = 4f;

		// Token: 0x0400041E RID: 1054
		public float _SlowFactor = 0.25f;

		// Token: 0x0400041F RID: 1055
		public bool _ClearTargetOnStop = true;

		// Token: 0x04000420 RID: 1056
		public float _PathHeight = 0.05f;

		// Token: 0x04000421 RID: 1057
		protected bool mIsTargetSet;

		// Token: 0x04000422 RID: 1058
		protected bool mHasArrived;

		// Token: 0x04000423 RID: 1059
		protected bool mIsInSlowDistance;

		// Token: 0x04000424 RID: 1060
		protected Vector3 mWaypoint = Vector3.zero;

		// Token: 0x04000425 RID: 1061
		protected Vector3 mAgentDestination = Vector3.zero;

		// Token: 0x04000426 RID: 1062
		protected Vector3 mTargetVector = Vector3.zero;

		// Token: 0x04000427 RID: 1063
		protected float mTargetDistance;

		// Token: 0x04000428 RID: 1064
		protected NavMeshAgent mNavMeshAgent;

		// Token: 0x04000429 RID: 1065
		protected bool mFirstPathSet;

		// Token: 0x0400042A RID: 1066
		protected bool mFirstPathValid;

		// Token: 0x0400042B RID: 1067
		protected bool mIsPathValid = true;
	}
}
