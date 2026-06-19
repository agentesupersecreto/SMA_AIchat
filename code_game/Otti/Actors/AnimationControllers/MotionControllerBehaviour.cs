using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E7 RID: 231
	public class MotionControllerBehaviour : StateMachineBehaviour
	{
		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x0003875D File Offset: 0x0003695D
		public string MotionKey
		{
			get
			{
				return this._MotionKey;
			}
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00038765 File Offset: 0x00036965
		public virtual void AddMotion(MotionControllerMotion rMotion)
		{
			if (this.mMotions.IndexOf(rMotion) < 0)
			{
				this.mMotions.Add(rMotion);
			}
			this.mMotionCount = this.mMotions.Count;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00038793 File Offset: 0x00036993
		public virtual void RemoveMotion(MotionControllerMotion rMotion)
		{
			this.mMotions.Remove(rMotion);
			this.mMotionCount = this.mMotions.Count;
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x000387B4 File Offset: 0x000369B4
		public override void OnStateMachineEnter(Animator rAnimator, int rStateMachinePathHash)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateMachineEnter(rAnimator, rStateMachinePathHash);
			}
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x000387E8 File Offset: 0x000369E8
		public override void OnStateMachineExit(Animator rAnimator, int rStateMachinePathHash)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateMachineExit(rAnimator, rStateMachinePathHash);
			}
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0003881C File Offset: 0x00036A1C
		public override void OnStateEnter(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateEnter(rAnimator, rAnimatorStateInfo, rLayerIndex);
			}
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x00038850 File Offset: 0x00036A50
		public override void OnStateExit(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateExit(rAnimator, rAnimatorStateInfo, rLayerIndex);
			}
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x00038884 File Offset: 0x00036A84
		public override void OnStateIK(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateIK(rAnimator, rAnimatorStateInfo, rLayerIndex);
			}
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x000388B8 File Offset: 0x00036AB8
		public override void OnStateMove(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateMove(rAnimator, rAnimatorStateInfo, rLayerIndex);
			}
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x000388EC File Offset: 0x00036AEC
		public override void OnStateUpdate(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
			for (int i = 0; i < this.mMotionCount; i++)
			{
				this.mMotions[i].OnStateUpdate(rAnimator, rAnimatorStateInfo, rLayerIndex);
			}
		}

		// Token: 0x04000636 RID: 1590
		public string _MotionKey = "";

		// Token: 0x04000637 RID: 1591
		protected int mMotionCount;

		// Token: 0x04000638 RID: 1592
		protected List<MotionControllerMotion> mMotions = new List<MotionControllerMotion>();
	}
}
