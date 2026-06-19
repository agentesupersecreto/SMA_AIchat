using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Collections
{
	// Token: 0x02000065 RID: 101
	public sealed class GameObjectPool
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x0001B90C File Offset: 0x00019B0C
		public GameObjectPool(GameObject rTemplate, int rSize)
		{
			this.mTemplate = rTemplate;
			this.Resize(rSize, false);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0001B92A File Offset: 0x00019B2A
		public GameObjectPool(GameObject rTemplate, int rSize, int rGrowSize)
		{
			this.mTemplate = rTemplate;
			this.mGrowSize = rGrowSize;
			this.Resize(rSize, false);
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0001B94F File Offset: 0x00019B4F
		public int Length
		{
			get
			{
				return this.mPool.Length;
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0001B95C File Offset: 0x00019B5C
		public GameObject Allocate()
		{
			GameObject gameObject = null;
			for (int i = this.mPool.Length - 1; i >= 0; i--)
			{
				if (this.mPool[i].IsReleased)
				{
					this.mPool[i].IsReleased = false;
					gameObject = this.mPool[i].GameObject;
					break;
				}
			}
			if (gameObject == null && this.mGrowSize > 0)
			{
				int num = this.mPool.Length;
				this.Resize(num + this.mGrowSize, true);
				this.mPool[num].IsReleased = false;
				gameObject = this.mPool[num].GameObject;
			}
			if (gameObject != null)
			{
				gameObject.SetActive(true);
			}
			return gameObject;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001BA18 File Offset: 0x00019C18
		public void Release(GameObject rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			for (int i = this.mPool.Length - 1; i >= 0; i--)
			{
				if (this.mPool[i].GameObject == rInstance)
				{
					rInstance.SetActive(false);
					rInstance.hideFlags = HideFlags.HideInHierarchy;
					rInstance.transform.parent = null;
					this.mPool[i].IsReleased = true;
					return;
				}
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001BA88 File Offset: 0x00019C88
		public void Reset()
		{
			int num = this.mGrowSize;
			if (this.mPool != null)
			{
				num = this.mPool.Length;
			}
			this.Resize(num, false);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0001BAB8 File Offset: 0x00019CB8
		public void Resize(int rSize, bool rCopyExisting)
		{
			lock (this)
			{
				int num = 0;
				GameObjectPool.PooledObject[] array = new GameObjectPool.PooledObject[rSize];
				if (this.mPool != null && rCopyExisting)
				{
					num = this.mPool.Length;
					Array.Copy(this.mPool, array, Math.Min(num, rSize));
				}
				for (int i = num; i < rSize; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.mTemplate);
					gameObject.SetActive(false);
					gameObject.hideFlags = HideFlags.HideInHierarchy;
					array[i] = default(GameObjectPool.PooledObject);
					array[i].GameObject = gameObject;
					array[i].IsReleased = true;
				}
				this.mPool = array;
			}
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0001BB80 File Offset: 0x00019D80
		public static void Initialize(GameObject rPrefab)
		{
			if (rPrefab == null)
			{
				return;
			}
			if (!GameObjectPool.sPool.ContainsKey(rPrefab))
			{
				GameObjectPool gameObjectPool = new GameObjectPool(rPrefab, 5);
				GameObjectPool.sPool.Add(rPrefab, gameObjectPool);
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0001BBB8 File Offset: 0x00019DB8
		public static GameObject Allocate(GameObject rPrefab)
		{
			if (rPrefab == null)
			{
				return null;
			}
			if (!GameObjectPool.sPool.ContainsKey(rPrefab))
			{
				GameObjectPool gameObjectPool = new GameObjectPool(rPrefab, 5);
				GameObjectPool.sPool.Add(rPrefab, gameObjectPool);
			}
			return GameObjectPool.sPool[rPrefab].Allocate();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0001BC01 File Offset: 0x00019E01
		public static void Release(GameObject rPrefab, GameObject rGameObject)
		{
			if (rPrefab == null || rGameObject == null)
			{
				return;
			}
			if (GameObjectPool.sPool.ContainsKey(rPrefab))
			{
				GameObjectPool.sPool[rPrefab].Release(rGameObject);
			}
		}

		// Token: 0x0400024C RID: 588
		private int mGrowSize = 5;

		// Token: 0x0400024D RID: 589
		private GameObject mTemplate;

		// Token: 0x0400024E RID: 590
		private GameObjectPool.PooledObject[] mPool;

		// Token: 0x0400024F RID: 591
		private static Dictionary<GameObject, GameObjectPool> sPool = new Dictionary<GameObject, GameObjectPool>();

		// Token: 0x02000132 RID: 306
		private struct PooledObject
		{
			// Token: 0x04000DD5 RID: 3541
			public bool IsReleased;

			// Token: 0x04000DD6 RID: 3542
			public GameObject GameObject;
		}
	}
}
