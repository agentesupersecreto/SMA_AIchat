using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A7 RID: 167
	public class DecalCore : MonoBehaviour, ILifeCore
	{
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x00030817 File Offset: 0x0002EA17
		// (set) Token: 0x06000968 RID: 2408 RVA: 0x0003081F File Offset: 0x0002EA1F
		public GameObject Prefab
		{
			get
			{
				return this.mPrefab;
			}
			set
			{
				this.mPrefab = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x00030828 File Offset: 0x0002EA28
		// (set) Token: 0x0600096A RID: 2410 RVA: 0x00030830 File Offset: 0x0002EA30
		public virtual float MaxAge
		{
			get
			{
				return this._MaxAge;
			}
			set
			{
				this._MaxAge = value;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x00030839 File Offset: 0x0002EA39
		// (set) Token: 0x0600096C RID: 2412 RVA: 0x00030841 File Offset: 0x0002EA41
		public virtual float Age
		{
			get
			{
				return this.mAge;
			}
			set
			{
				this.mAge = value;
			}
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0003084C File Offset: 0x0002EA4C
		public virtual void Activate()
		{
			this.mAge = 0f;
			AudioSource component = base.gameObject.GetComponent<AudioSource>();
			if (component != null)
			{
				component.Play();
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0003087F File Offset: 0x0002EA7F
		public virtual void Update()
		{
			this.mAge += Time.deltaTime;
			if (this.mAge >= this._MaxAge)
			{
				this.Release();
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x000308A7 File Offset: 0x0002EAA7
		public virtual void Release()
		{
			if (this.mPrefab != null)
			{
				GameObjectPool.Release(this.mPrefab, base.gameObject);
				return;
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000308E7 File Offset: 0x0002EAE7
		GameObject ILifeCore.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004BB RID: 1211
		protected GameObject mPrefab;

		// Token: 0x040004BC RID: 1212
		public float _MaxAge = 5f;

		// Token: 0x040004BD RID: 1213
		protected float mAge;
	}
}
