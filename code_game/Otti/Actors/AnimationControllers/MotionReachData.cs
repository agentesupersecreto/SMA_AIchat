using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000EC RID: 236
	public class MotionReachData
	{
		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0003B070 File Offset: 0x00039270
		// (set) Token: 0x06000C62 RID: 3170 RVA: 0x0003B0A0 File Offset: 0x000392A0
		public Vector3 ReachTarget
		{
			get
			{
				if (this.IsReachTargetLocal && this._ReachTargetGround != null)
				{
					return this._ReachTargetGround.TransformPoint(this._ReachTarget);
				}
				return this._ReachTarget;
			}
			set
			{
				this._ReachTarget = value;
				if (this._ReachTargetGround != null)
				{
					this.IsReachTargetLocal = true;
					this._ReachTarget = this._ReachTargetGround.InverseTransformPoint(this._ReachTarget);
				}
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x0003B0D5 File Offset: 0x000392D5
		// (set) Token: 0x06000C64 RID: 3172 RVA: 0x0003B0E0 File Offset: 0x000392E0
		public Transform ReachTargetGround
		{
			get
			{
				return this._ReachTargetGround;
			}
			set
			{
				if (this.IsReachTargetLocal && this._ReachTargetGround != null)
				{
					this.IsReachTargetLocal = false;
					this._ReachTarget = this._ReachTargetGround.TransformPoint(this._ReachTarget);
				}
				this._ReachTargetGround = value;
				if (this._ReachTargetGround != null)
				{
					this.IsReachTargetLocal = true;
					this._ReachTarget = this._ReachTargetGround.InverseTransformPoint(this._ReachTarget);
				}
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000C65 RID: 3173 RVA: 0x0003B154 File Offset: 0x00039354
		public static int Length
		{
			get
			{
				return MotionReachData.sPool.Length;
			}
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0003B160 File Offset: 0x00039360
		public static MotionReachData Allocate()
		{
			return MotionReachData.sPool.Allocate();
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0003B16C File Offset: 0x0003936C
		public static void Release(MotionReachData rInstance)
		{
			rInstance.StateID = 0;
			rInstance.TransitionID = 0;
			rInstance.Power = 1;
			rInstance.IsReachTargetLocal = false;
			rInstance._ReachTarget = Vector3.zero;
			rInstance._ReachTargetGround = null;
			rInstance.StartTime = 0f;
			rInstance.EndTime = 0f;
			rInstance.IsComplete = false;
			MotionReachData.sPool.Release(rInstance);
		}

		// Token: 0x0400067F RID: 1663
		public int StateID;

		// Token: 0x04000680 RID: 1664
		public int TransitionID;

		// Token: 0x04000681 RID: 1665
		public float StartTime;

		// Token: 0x04000682 RID: 1666
		public float EndTime;

		// Token: 0x04000683 RID: 1667
		public int Power;

		// Token: 0x04000684 RID: 1668
		public bool IsReachTargetLocal;

		// Token: 0x04000685 RID: 1669
		public Vector3 _ReachTarget;

		// Token: 0x04000686 RID: 1670
		public Transform _ReachTargetGround;

		// Token: 0x04000687 RID: 1671
		public bool IsComplete;

		// Token: 0x04000688 RID: 1672
		private static ObjectPool<MotionReachData> sPool = new ObjectPool<MotionReachData>(10, 5);
	}
}
