using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A5 RID: 165
	public class SpawnParticles : ActorCoreEffect
	{
		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x000305D4 File Offset: 0x0002E7D4
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x000305DC File Offset: 0x0002E7DC
		public override float Age
		{
			get
			{
				return this.mAge;
			}
			set
			{
				this.mAge = value;
				if (this.mParticleCore != null)
				{
					this.mParticleCore.Age = value;
				}
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x000305FF File Offset: 0x0002E7FF
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00030607 File Offset: 0x0002E807
		public override float MaxAge
		{
			get
			{
				return this._MaxAge;
			}
			set
			{
				this._MaxAge = value;
				if (this.mParticleCore != null)
				{
					this.mParticleCore.MaxAge = value;
				}
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0003062A File Offset: 0x0002E82A
		public SpawnParticles()
		{
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00030632 File Offset: 0x0002E832
		public SpawnParticles(ActorCore rActorCore)
			: base(rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00030644 File Offset: 0x0002E844
		public virtual void Activate(float rMaxAge, GameObject rPrefab, Transform rParent = null)
		{
			if (rPrefab == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(rPrefab);
			if (gameObject != null)
			{
				this.mParticleCore = gameObject.GetComponent<ParticleCore>();
				if (this.mParticleCore != null)
				{
					gameObject.transform.parent = ((rParent != null) ? rParent : this.mActorCore.Transform);
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.transform.localRotation = Quaternion.identity;
					this.mParticleCore.Age = 0f;
					this.mParticleCore.MaxAge = rMaxAge;
					this.mParticleCore.Prefab = rPrefab;
					this.mParticleCore.OnReleasedEvent = new LifeCoreDelegate(this.OnParticleCoreReleased);
					this.mParticleCore.Play();
					base.Activate(0f, rMaxAge);
					return;
				}
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0003072A File Offset: 0x0002E92A
		public override void Deactivate()
		{
			if (this.mParticleCore == null)
			{
				base.Deactivate();
				return;
			}
			this.mParticleCore.Stop(false);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0003074D File Offset: 0x0002E94D
		public override bool Update()
		{
			return !(this.mParticleCore == null);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00030760 File Offset: 0x0002E960
		private void OnParticleCoreReleased(ILifeCore rCore, object rUserData = null)
		{
			if (this.mParticleCore != null)
			{
				this.mParticleCore.OnReleasedEvent = null;
				this.mParticleCore = null;
			}
			base.Deactivate();
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00030789 File Offset: 0x0002E989
		public override void Release()
		{
			SpawnParticles.Release(this);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00030791 File Offset: 0x0002E991
		public static SpawnParticles Allocate()
		{
			return SpawnParticles.sPool.Allocate();
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0003079D File Offset: 0x0002E99D
		public static void Release(SpawnParticles rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			SpawnParticles.sPool.Release(rInstance);
		}

		// Token: 0x040004B7 RID: 1207
		protected ParticleCore mParticleCore;

		// Token: 0x040004B8 RID: 1208
		private static ObjectPool<SpawnParticles> sPool = new ObjectPool<SpawnParticles>(5, 5);
	}
}
