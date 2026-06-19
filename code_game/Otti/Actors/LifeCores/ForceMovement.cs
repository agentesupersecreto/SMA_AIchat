using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A1 RID: 161
	public class ForceMovement : ActorCoreEffect
	{
		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0002FC3F File Offset: 0x0002DE3F
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x0002FC47 File Offset: 0x0002DE47
		public Vector3 Movement
		{
			get
			{
				return this._Movement;
			}
			set
			{
				this._Movement = value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x0002FC50 File Offset: 0x0002DE50
		// (set) Token: 0x0600091B RID: 2331 RVA: 0x0002FC58 File Offset: 0x0002DE58
		public bool ReduceMovementOverTime
		{
			get
			{
				return this._ReduceMovementOverTime;
			}
			set
			{
				this._ReduceMovementOverTime = value;
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0002FC61 File Offset: 0x0002DE61
		public ForceMovement()
		{
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0002FC7B File Offset: 0x0002DE7B
		public ForceMovement(ActorCore rActorCore)
			: base(rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0002FCA0 File Offset: 0x0002DEA0
		public override void Activate(float rTriggerDelay, float rMaxAge)
		{
			this.mActorController = this.mActorCore.gameObject.GetComponent<ActorController>();
			if (this.mActorController != null)
			{
				this.mStoredUseTransformPosition = this.mActorController.UseTransformPosition;
				this.mActorController.UseTransformPosition = true;
				this.mStoredUseTransformRotation = this.mActorController.UseTransformRotation;
				this.mActorController.UseTransformRotation = true;
			}
			base.Activate(rTriggerDelay, rMaxAge);
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x0002FD13 File Offset: 0x0002DF13
		public override void Deactivate()
		{
			if (this.mActorController != null)
			{
				this.mActorController.UseTransformPosition = this.mStoredUseTransformPosition;
				this.mActorController.UseTransformRotation = this.mStoredUseTransformRotation;
				this.mActorController = null;
			}
			base.Deactivate();
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0002FD54 File Offset: 0x0002DF54
		public override bool Update()
		{
			if (this.mActorController == null)
			{
				return false;
			}
			if (!base.Update())
			{
				return false;
			}
			Vector3 vector = this.Movement;
			if (this.ReduceMovementOverTime)
			{
				float num = 1f - this.mAge / this.MaxAge;
				vector *= num;
			}
			this.mActorController._Transform.position = this.mActorController._Transform.position + vector * Time.deltaTime;
			return true;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0002FDD7 File Offset: 0x0002DFD7
		public override void Release()
		{
			ForceMovement.Release(this);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0002FDDF File Offset: 0x0002DFDF
		public static ForceMovement Allocate()
		{
			return ForceMovement.sPool.Allocate();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0002FDEB File Offset: 0x0002DFEB
		public static void Release(ForceMovement rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			ForceMovement.sPool.Release(rInstance);
		}

		// Token: 0x0400049F RID: 1183
		public Vector3 _Movement = Vector3.zero;

		// Token: 0x040004A0 RID: 1184
		public bool _ReduceMovementOverTime = true;

		// Token: 0x040004A1 RID: 1185
		protected ActorController mActorController;

		// Token: 0x040004A2 RID: 1186
		protected bool mStoredUseTransformPosition;

		// Token: 0x040004A3 RID: 1187
		protected bool mStoredUseTransformRotation;

		// Token: 0x040004A4 RID: 1188
		private static ObjectPool<ForceMovement> sPool = new ObjectPool<ForceMovement>(10, 10);
	}
}
