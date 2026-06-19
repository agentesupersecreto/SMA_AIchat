using System;
using com.ootii.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A3 RID: 163
	public class ModifyMovement : ActorCoreEffect
	{
		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x00030097 File Offset: 0x0002E297
		// (set) Token: 0x06000931 RID: 2353 RVA: 0x0003009F File Offset: 0x0002E29F
		public float MovementFactor
		{
			get
			{
				return this._MovementFactor;
			}
			set
			{
				this._MovementFactor = value;
			}
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x000300A8 File Offset: 0x0002E2A8
		public ModifyMovement()
		{
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x000300BB File Offset: 0x0002E2BB
		public ModifyMovement(ActorCore rActorCore)
			: base(rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x000300D8 File Offset: 0x0002E2D8
		public override void Activate(float rTriggerDelay, float rMaxAge)
		{
			bool flag = false;
			this.mActorController = this.mActorCore.gameObject.GetComponent<ActorController>();
			if (this.mActorController != null && !this.mActorController.UseTransformPosition)
			{
				flag = true;
				ActorController actorController = this.mActorController;
				actorController.OnPreControllerMove = (ControllerMoveDelegate)Delegate.Combine(actorController.OnPreControllerMove, new ControllerMoveDelegate(this.OnControllerMoved));
			}
			if (!flag)
			{
				this.mNavMeshDriver = this.mActorCore.gameObject.GetComponent<NavMeshDriver>();
				if (this.mNavMeshDriver != null)
				{
					flag = true;
					this.mOriginalSpeed = this.mNavMeshDriver.MovementSpeed;
					this.mNavMeshDriver.MovementSpeed = this.mNavMeshDriver.MovementSpeed * this._MovementFactor;
				}
			}
			if (!flag)
			{
				this.mNavMeshAgent = this.mActorCore.gameObject.GetComponent<NavMeshAgent>();
				if (this.mNavMeshAgent != null)
				{
					this.mOriginalSpeed = this.mNavMeshAgent.speed;
					this.mNavMeshAgent.speed = this.mNavMeshAgent.speed * this._MovementFactor;
				}
			}
			base.Activate(rTriggerDelay, rMaxAge);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x000301F8 File Offset: 0x0002E3F8
		public override void Deactivate()
		{
			if (this.mActorController != null)
			{
				ActorController actorController = this.mActorController;
				actorController.OnPreControllerMove = (ControllerMoveDelegate)Delegate.Remove(actorController.OnPreControllerMove, new ControllerMoveDelegate(this.OnControllerMoved));
				this.mActorController = null;
			}
			if (this.mNavMeshDriver != null)
			{
				this.mNavMeshDriver.MovementSpeed = this.mOriginalSpeed;
				this.mNavMeshDriver = null;
			}
			if (this.mNavMeshAgent != null)
			{
				this.mNavMeshAgent.speed = this.mOriginalSpeed;
				this.mNavMeshAgent = null;
			}
			base.Deactivate();
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00030293 File Offset: 0x0002E493
		public override bool Update()
		{
			return !(this.mActorController == null);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x000302A6 File Offset: 0x0002E4A6
		public override void Release()
		{
			ModifyMovement.Release(this);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x000302B0 File Offset: 0x0002E4B0
		protected void OnControllerMoved(ICharacterController rController, ref Vector3 rFinalPosition, ref Quaternion rFinalRotation)
		{
			if (this._MovementFactor != 1f)
			{
				Vector3 vector = rFinalPosition - this.mActorController._Transform.position;
				rFinalPosition = this.mActorController._Transform.position + vector.normalized * (vector.magnitude * this._MovementFactor);
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0003031B File Offset: 0x0002E51B
		public static ModifyMovement Allocate()
		{
			return ModifyMovement.sPool.Allocate();
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00030327 File Offset: 0x0002E527
		public static void Release(ModifyMovement rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			ModifyMovement.sPool.Release(rInstance);
		}

		// Token: 0x040004A9 RID: 1193
		public float _MovementFactor = 1f;

		// Token: 0x040004AA RID: 1194
		protected float mOriginalSpeed;

		// Token: 0x040004AB RID: 1195
		protected ActorController mActorController;

		// Token: 0x040004AC RID: 1196
		protected NavMeshDriver mNavMeshDriver;

		// Token: 0x040004AD RID: 1197
		protected NavMeshAgent mNavMeshAgent;

		// Token: 0x040004AE RID: 1198
		private static ObjectPool<ModifyMovement> sPool = new ObjectPool<ModifyMovement>(10, 10);
	}
}
