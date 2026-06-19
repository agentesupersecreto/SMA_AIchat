using System;
using com.ootii.Collections;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A4 RID: 164
	public class SpawnGameObject : ActorCoreEffect
	{
		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0003034E File Offset: 0x0002E54E
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x00030356 File Offset: 0x0002E556
		public bool ParentToTarget
		{
			get
			{
				return this._ParentToTarget;
			}
			set
			{
				this._ParentToTarget = value;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x0003035F File Offset: 0x0002E55F
		// (set) Token: 0x0600093F RID: 2367 RVA: 0x00030367 File Offset: 0x0002E567
		public Transform Target
		{
			get
			{
				return this.mTarget;
			}
			set
			{
				this.mTarget = null;
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00030370 File Offset: 0x0002E570
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x00030378 File Offset: 0x0002E578
		public int BoneIndex
		{
			get
			{
				return this._BoneIndex;
			}
			set
			{
				this._BoneIndex = value;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x00030381 File Offset: 0x0002E581
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00030389 File Offset: 0x0002E589
		public string BoneName
		{
			get
			{
				return this._BoneName;
			}
			set
			{
				this._BoneName = value;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00030392 File Offset: 0x0002E592
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x0003039A File Offset: 0x0002E59A
		public Vector3 LocalPosition
		{
			get
			{
				return this._LocalPosition;
			}
			set
			{
				this._LocalPosition = value;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x000303A3 File Offset: 0x0002E5A3
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x000303AB File Offset: 0x0002E5AB
		public virtual GameObject Prefab
		{
			get
			{
				return this._Prefab;
			}
			set
			{
				this._Prefab = value;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x000303B4 File Offset: 0x0002E5B4
		public GameObject Instance
		{
			get
			{
				return this.mInstance;
			}
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000303BC File Offset: 0x0002E5BC
		public SpawnGameObject()
		{
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x000303E1 File Offset: 0x0002E5E1
		public SpawnGameObject(ActorCore rActorCore)
			: base(rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00030410 File Offset: 0x0002E610
		public virtual void Activate(float rMaxAge, GameObject rPrefab)
		{
			if (this._Prefab != null)
			{
				this.mInstance = Object.Instantiate<GameObject>(this._Prefab);
				if (this.mInstance != null)
				{
					if (this.ParentToTarget)
					{
						if (this.mTarget == null)
						{
							this.mTarget = this.mActorCore.Transform;
						}
						Transform transform = ((this.mTarget != null) ? this.mTarget.transform : null);
						if (this._BoneIndex == 1 && this._BoneName.Length > 0)
						{
							Transform transform2 = transform.FindTransform(this._BoneName);
							if (transform2 != null)
							{
								transform = transform2;
							}
						}
						else if (this._BoneIndex > 1 && this._BoneName.Length > 0)
						{
							try
							{
								HumanBodyBones humanBodyBones = (HumanBodyBones)Enum.Parse(typeof(HumanBodyBones), this._BoneName, true);
								Transform transform3 = transform.FindTransform(humanBodyBones);
								if (transform3 != null)
								{
									transform = transform3;
								}
							}
							catch
							{
							}
						}
						this.mInstance.transform.parent = transform;
					}
					this.mInstance.transform.localPosition = this._LocalPosition;
					this.mInstance.SetActive(true);
				}
			}
			base.Activate(0f, rMaxAge);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00030564 File Offset: 0x0002E764
		public override void Deactivate()
		{
			if (this.mInstance != null)
			{
				Object.Destroy(this.mInstance);
				this.mInstance = null;
			}
			base.Deactivate();
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0003058C File Offset: 0x0002E78C
		public override void TriggerEffect()
		{
			base.TriggerEffect();
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00030594 File Offset: 0x0002E794
		public override void Release()
		{
			this._Prefab = null;
			SpawnGameObject.Release(this);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000305A3 File Offset: 0x0002E7A3
		public static SpawnGameObject Allocate()
		{
			return SpawnGameObject.sPool.Allocate();
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000305AF File Offset: 0x0002E7AF
		public static void Release(SpawnGameObject rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			SpawnGameObject.sPool.Release(rInstance);
		}

		// Token: 0x040004AF RID: 1199
		public bool _ParentToTarget = true;

		// Token: 0x040004B0 RID: 1200
		protected Transform mTarget;

		// Token: 0x040004B1 RID: 1201
		public int _BoneIndex;

		// Token: 0x040004B2 RID: 1202
		public string _BoneName = "";

		// Token: 0x040004B3 RID: 1203
		public Vector3 _LocalPosition = Vector3.zero;

		// Token: 0x040004B4 RID: 1204
		public GameObject _Prefab;

		// Token: 0x040004B5 RID: 1205
		protected GameObject mInstance;

		// Token: 0x040004B6 RID: 1206
		private static ObjectPool<SpawnGameObject> sPool = new ObjectPool<SpawnGameObject>(5, 5);
	}
}
