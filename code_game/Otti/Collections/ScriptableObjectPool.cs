using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Collections
{
	// Token: 0x02000067 RID: 103
	public sealed class ScriptableObjectPool
	{
		// Token: 0x060004AF RID: 1199 RVA: 0x0001BE0C File Offset: 0x0001A00C
		public ScriptableObjectPool(ScriptableObject rTemplate, int rSize, bool rDeepCopy)
		{
			this.mDeepCopy = rDeepCopy;
			this.mTemplate = rTemplate;
			this.Resize(rSize, false);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001BE38 File Offset: 0x0001A038
		public ScriptableObjectPool(ScriptableObject rTemplate, int rSize, int rGrowSize, bool rDeepCopy)
		{
			this.mDeepCopy = rDeepCopy;
			this.mTemplate = rTemplate;
			this.mGrowSize = rGrowSize;
			this.Resize(rSize, false);
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0001BE6C File Offset: 0x0001A06C
		public int Length
		{
			get
			{
				return this.mPool.Length;
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001BE78 File Offset: 0x0001A078
		public ScriptableObject Allocate()
		{
			ScriptableObject scriptableObject = null;
			for (int i = this.mPool.Length - 1; i >= 0; i--)
			{
				if (this.mPool[i].IsReleased)
				{
					this.mPool[i].IsReleased = false;
					scriptableObject = this.mPool[i].ScriptableObject;
					break;
				}
			}
			if (scriptableObject == null && this.mGrowSize > 0)
			{
				int num = this.mPool.Length;
				this.Resize(num + this.mGrowSize, true);
				this.mPool[num].IsReleased = false;
				scriptableObject = this.mPool[num].ScriptableObject;
			}
			if (scriptableObject != null)
			{
				scriptableObject.hideFlags = HideFlags.None;
			}
			return scriptableObject;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001BF34 File Offset: 0x0001A134
		public void Release(ScriptableObject rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			for (int i = this.mPool.Length - 1; i >= 0; i--)
			{
				if (this.mPool[i].ScriptableObject == rInstance)
				{
					rInstance.hideFlags = HideFlags.HideInHierarchy;
					this.mPool[i].IsReleased = true;
					return;
				}
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001BF90 File Offset: 0x0001A190
		public void Reset()
		{
			int num = this.mGrowSize;
			if (this.mPool != null)
			{
				num = this.mPool.Length;
			}
			this.Resize(num, false);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001BFC0 File Offset: 0x0001A1C0
		public void Resize(int rSize, bool rCopyExisting)
		{
			lock (this)
			{
				int num = 0;
				ScriptableObjectPool.PooledObject[] array = new ScriptableObjectPool.PooledObject[rSize];
				if (this.mPool != null && rCopyExisting)
				{
					num = this.mPool.Length;
					Array.Copy(this.mPool, array, Math.Min(num, rSize));
				}
				for (int i = num; i < rSize; i++)
				{
					ScriptableObject scriptableObject;
					if (this.mDeepCopy)
					{
						scriptableObject = ScriptableObjectPool.DeepCopy(this.mTemplate, true);
					}
					else
					{
						scriptableObject = Object.Instantiate<ScriptableObject>(this.mTemplate);
					}
					scriptableObject.hideFlags = HideFlags.HideInHierarchy;
					array[i] = default(ScriptableObjectPool.PooledObject);
					array[i].ScriptableObject = scriptableObject;
					array[i].IsReleased = true;
				}
				this.mPool = array;
			}
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0001C09C File Offset: 0x0001A29C
		public static void Initialize(ScriptableObject rPrefab, bool rDeepCopy)
		{
			if (rPrefab == null)
			{
				return;
			}
			if (!ScriptableObjectPool.sPool.ContainsKey(rPrefab))
			{
				ScriptableObjectPool scriptableObjectPool = new ScriptableObjectPool(rPrefab, 5, rDeepCopy);
				ScriptableObjectPool.sPool.Add(rPrefab, scriptableObjectPool);
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0001C0D8 File Offset: 0x0001A2D8
		public static ScriptableObject Allocate(ScriptableObject rPrefab, bool rDeepCopy)
		{
			if (rPrefab == null)
			{
				return null;
			}
			if (!ScriptableObjectPool.sPool.ContainsKey(rPrefab))
			{
				ScriptableObjectPool scriptableObjectPool = new ScriptableObjectPool(rPrefab, 5, rDeepCopy);
				ScriptableObjectPool.sPool.Add(rPrefab, scriptableObjectPool);
			}
			return ScriptableObjectPool.sPool[rPrefab].Allocate();
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0001C122 File Offset: 0x0001A322
		public static void Release(ScriptableObject rPrefab, ScriptableObject rInstance)
		{
			if (rPrefab == null || rInstance == null)
			{
				return;
			}
			if (ScriptableObjectPool.sPool.ContainsKey(rPrefab))
			{
				ScriptableObjectPool.sPool[rPrefab].Release(rInstance);
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001C158 File Offset: 0x0001A358
		public static ScriptableObject DeepCopy(ScriptableObject rTemplate, bool rRoot = false)
		{
			if (rTemplate == null)
			{
				return null;
			}
			if (rRoot)
			{
				ScriptableObjectPool.sDeepCopyRegister.Clear();
			}
			if (ScriptableObjectPool.sDeepCopyRegister.ContainsKey(rTemplate))
			{
				return ScriptableObjectPool.sDeepCopyRegister[rTemplate];
			}
			ScriptableObject scriptableObject = Object.Instantiate<ScriptableObject>(rTemplate);
			if (rRoot)
			{
				ScriptableObjectPool.sDeepCopyRegister.Add(scriptableObject, scriptableObject);
			}
			else
			{
				ScriptableObjectPool.sDeepCopyRegister.Add(rTemplate, scriptableObject);
			}
			foreach (FieldInfo fieldInfo in scriptableObject.GetType().GetFields())
			{
				if (!fieldInfo.IsInitOnly && !fieldInfo.IsLiteral && fieldInfo.IsPublic && ReflectionHelper.IsDefined(fieldInfo, typeof(NonSerializedAttribute)))
				{
					Type fieldType = fieldInfo.FieldType;
					object value = fieldInfo.GetValue(scriptableObject);
					if (typeof(ScriptableObject).IsAssignableFrom(fieldType))
					{
						ScriptableObject scriptableObject2 = ScriptableObjectPool.DeepCopy(value as ScriptableObject, false);
						fieldInfo.SetValue(scriptableObject, scriptableObject2);
					}
					else if (ReflectionHelper.IsGenericType(fieldType) && fieldType.GetGenericTypeDefinition() == typeof(List<>))
					{
						Type type = fieldType.GetGenericArguments()[0];
						if (typeof(ScriptableObject).IsAssignableFrom(type))
						{
							IList list = value as IList;
							IList list2 = Activator.CreateInstance(fieldType) as IList;
							for (int j = 0; j < list.Count; j++)
							{
								ScriptableObject scriptableObject3 = ScriptableObjectPool.DeepCopy(list[j] as ScriptableObject, false);
								list2.Add(scriptableObject3);
							}
							fieldInfo.SetValue(scriptableObject, list2);
						}
					}
				}
			}
			if (rRoot)
			{
				ScriptableObjectPool.sDeepCopyRegister.Clear();
			}
			return scriptableObject;
		}

		// Token: 0x04000253 RID: 595
		private int mGrowSize = 5;

		// Token: 0x04000254 RID: 596
		private ScriptableObject mTemplate;

		// Token: 0x04000255 RID: 597
		private ScriptableObjectPool.PooledObject[] mPool;

		// Token: 0x04000256 RID: 598
		private bool mDeepCopy = true;

		// Token: 0x04000257 RID: 599
		private static Dictionary<ScriptableObject, ScriptableObjectPool> sPool = new Dictionary<ScriptableObject, ScriptableObjectPool>();

		// Token: 0x04000258 RID: 600
		private static Dictionary<ScriptableObject, ScriptableObject> sDeepCopyRegister = new Dictionary<ScriptableObject, ScriptableObject>();

		// Token: 0x02000133 RID: 307
		private struct PooledObject
		{
			// Token: 0x04000DD7 RID: 3543
			public bool IsReleased;

			// Token: 0x04000DD8 RID: 3544
			public ScriptableObject ScriptableObject;
		}
	}
}
