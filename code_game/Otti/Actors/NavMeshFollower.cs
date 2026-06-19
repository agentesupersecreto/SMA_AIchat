using System;
using com.ootii.Geometry;
using UnityEngine;
using UnityEngine.AI;

namespace com.ootii.Actors
{
	// Token: 0x0200008F RID: 143
	[AddComponentMenu("ootii/Actor Drivers/Nav Mesh Follower")]
	public class NavMeshFollower : MonoBehaviour
	{
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0002BBD1 File Offset: 0x00029DD1
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x0002BBDC File Offset: 0x00029DDC
		public bool IsEnabled
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

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0002BC32 File Offset: 0x00029E32
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0002BC3C File Offset: 0x00029E3C
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
					this.mIsTargetSet = false;
					this._TargetPosition = Vector3Ext.Null;
					return;
				}
				this.mIsTargetSet = true;
				this._TargetPosition = this._Target.position;
				if (Application.isPlaying)
				{
					this.SetDestination(this._TargetPosition);
				}
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0002BCAF File Offset: 0x00029EAF
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x0002BCB8 File Offset: 0x00029EB8
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
					this.mIsTargetSet = false;
					return;
				}
				this.mIsTargetSet = true;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0002BD07 File Offset: 0x00029F07
		// (set) Token: 0x0600081F RID: 2079 RVA: 0x0002BD0F File Offset: 0x00029F0F
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

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0002BD18 File Offset: 0x00029F18
		public bool IsTargetSet
		{
			get
			{
				return this.mIsTargetSet;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0002BD20 File Offset: 0x00029F20
		public bool HasArrived
		{
			get
			{
				return this.mHasArrived;
			}
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0002BD28 File Offset: 0x00029F28
		protected void Awake()
		{
			this.mNavMeshAgent = base.gameObject.GetComponent<NavMeshAgent>();
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0002BD3B File Offset: 0x00029F3B
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

		// Token: 0x06000824 RID: 2084 RVA: 0x0002BD76 File Offset: 0x00029F76
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
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002BDAC File Offset: 0x00029FAC
		protected void Update()
		{
			if (!this._IsEnabled)
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
			if (this._Target != null)
			{
				this._TargetPosition = this._Target.position;
			}
			this.SetDestination(this._TargetPosition);
			if (!this.mNavMeshAgent.pathPending && this.mNavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && this.mNavMeshAgent.remainingDistance == 0f)
			{
				this.ClearTarget();
				this.mHasArrived = true;
				this.OnArrived();
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0002BE44 File Offset: 0x0002A044
		protected virtual void SetDestination(Vector3 rDestination)
		{
			if (!this.mHasArrived && this.mAgentDestination == rDestination)
			{
				return;
			}
			this.mHasArrived = false;
			this.mAgentDestination = rDestination;
			if (!this.mNavMeshAgent.pathPending)
			{
				this.mNavMeshAgent.ResetPath();
				this.mNavMeshAgent.SetDestination(this.mAgentDestination);
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0002BEA0 File Offset: 0x0002A0A0
		protected virtual void OnArrived()
		{
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0002BEA2 File Offset: 0x0002A0A2
		protected virtual void OnSlowDistanceEntered()
		{
		}

		// Token: 0x0400042C RID: 1068
		public const float EPSILON = 0.01f;

		// Token: 0x0400042D RID: 1069
		public bool _IsEnabled = true;

		// Token: 0x0400042E RID: 1070
		public Transform _Target;

		// Token: 0x0400042F RID: 1071
		public Vector3 _TargetPosition = Vector3.zero;

		// Token: 0x04000430 RID: 1072
		public bool _ClearTargetOnStop = true;

		// Token: 0x04000431 RID: 1073
		protected bool mIsTargetSet;

		// Token: 0x04000432 RID: 1074
		protected bool mHasArrived;

		// Token: 0x04000433 RID: 1075
		protected NavMeshAgent mNavMeshAgent;

		// Token: 0x04000434 RID: 1076
		protected Vector3 mAgentDestination = Vector3.zero;
	}
}
