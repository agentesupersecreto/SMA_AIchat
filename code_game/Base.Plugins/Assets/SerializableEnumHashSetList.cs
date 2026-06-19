using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200013D RID: 317
	[Serializable]
	public abstract class SerializableEnumHashSetList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver, IReadOnlyList<T>, IReadOnlyCollection<T> where T : struct
	{
		// Token: 0x06000929 RID: 2345
		protected abstract int ToInt(T e);

		// Token: 0x0600092A RID: 2346
		protected abstract T ToEnum(int value);

		// Token: 0x0600092B RID: 2347 RVA: 0x0001E3AC File Offset: 0x0001C5AC
		public SerializableEnumHashSetList()
		{
			this.m_set = new HashSet<int>();
			if (this.m_list != null && this.m_list.Count > 0)
			{
				List<T> list = this.m_list;
				this.m_list = new List<T>();
				for (int i = 0; i < list.Count; i++)
				{
					this.Add(list[i]);
				}
				return;
			}
			this.m_list = new List<T>();
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0001E420 File Offset: 0x0001C620
		public SerializableEnumHashSetList(IEnumerable<T> collection)
		{
			this.m_set = new HashSet<int>();
			if (this.m_list != null && this.m_list.Count > 0)
			{
				List<T> list = this.m_list;
				this.m_list = new List<T>();
				for (int i = 0; i < list.Count; i++)
				{
					this.Add(list[i]);
				}
			}
			else
			{
				this.m_list = new List<T>();
			}
			foreach (T t in collection)
			{
				if (this.m_set.Add(this.ToInt(t)))
				{
					this.m_list.Add(t);
				}
			}
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001E4E8 File Offset: 0x0001C6E8
		public SerializableEnumHashSetList(int capacity)
		{
			this.m_set = new HashSet<int>();
			if (this.m_list != null && this.m_list.Count > 0)
			{
				List<T> list = this.m_list;
				this.m_list = new List<T>(capacity);
				for (int i = 0; i < list.Count; i++)
				{
					this.Add(list[i]);
				}
				return;
			}
			this.m_list = new List<T>(capacity);
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x0001E55B File Offset: 0x0001C75B
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0001E568 File Offset: 0x0001C768
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)this.m_list).IsReadOnly;
			}
		}

		// Token: 0x1700019C RID: 412
		T IList<T>.this[int index]
		{
			get
			{
				return ((IList<T>)this.m_list)[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700019D RID: 413
		public T this[int i]
		{
			get
			{
				T t;
				try
				{
					t = this.m_list[i];
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return t;
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0001E5BC File Offset: 0x0001C7BC
		public void Clear()
		{
			this.m_list.Clear();
			this.m_set.Clear();
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0001E5D4 File Offset: 0x0001C7D4
		public bool Add(T item)
		{
			bool flag = this.m_set.Add(this.ToInt(item));
			if (flag)
			{
				this.m_list.Add(item);
			}
			return flag;
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0001E5F7 File Offset: 0x0001C7F7
		public bool Contains(T item)
		{
			return this.m_set.Contains(this.ToInt(item));
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0001E60C File Offset: 0x0001C80C
		public void RemoveAt(int index)
		{
			try
			{
				T t = this.m_list[index];
				this.m_set.Remove(this.ToInt(t));
				this.m_list.RemoveAt(index);
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
				throw ex;
			}
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0001E660 File Offset: 0x0001C860
		public bool Remove(T item)
		{
			bool flag = this.m_set.Remove(this.ToInt(item));
			if (flag)
			{
				this.m_list.Remove(item);
			}
			return flag;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0001E684 File Offset: 0x0001C884
		public bool RemoveAndRepopulate(T item)
		{
			bool flag = this.m_set.Remove(this.ToInt(item));
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_set.Cast<T>());
			}
			return flag;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001E6BC File Offset: 0x0001C8BC
		public bool RemoveAndRepopulateMany(IList<T> items)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = this.m_set.Remove(this.ToInt(items[i])) || flag;
			}
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_set.Cast<T>());
			}
			return flag;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001E71C File Offset: 0x0001C91C
		public bool RemoveAndRebuild(T item)
		{
			bool flag = this.m_set.Remove(this.ToInt(item));
			if (flag)
			{
				this.m_list = new List<T>(this.m_set.Cast<T>());
			}
			return flag;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0001E74C File Offset: 0x0001C94C
		public bool Remove(IList<T> items)
		{
			bool flag = true;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.Remove(items[i]))
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001E780 File Offset: 0x0001C980
		public bool RemoveAndRepopulate(IList<T> items)
		{
			bool? flag = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.m_set.Remove(this.ToInt(items[i])))
				{
					flag = new bool?(false);
				}
				else if (flag == null)
				{
					flag = new bool?(true);
				}
			}
			if (flag != null)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_set.Cast<T>());
			}
			return flag.Value;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0001E80C File Offset: 0x0001CA0C
		public bool RemoveAndRebuild(IList<T> items)
		{
			bool? flag = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.m_set.Remove(this.ToInt(items[i])))
				{
					flag = new bool?(false);
				}
				else if (flag == null)
				{
					flag = new bool?(true);
				}
			}
			if (flag != null)
			{
				this.m_list = new List<T>(this.m_set.Cast<T>());
			}
			return flag.Value;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0001E88D File Offset: 0x0001CA8D
		public int IndexOf(T item)
		{
			return ((IList<T>)this.m_list).IndexOf(item);
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0001E89B File Offset: 0x0001CA9B
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0001E8A2 File Offset: 0x0001CAA2
		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0001E8AC File Offset: 0x0001CAAC
		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)this.m_list).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0001E8BB File Offset: 0x0001CABB
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0001E8C8 File Offset: 0x0001CAC8
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0001E8D8 File Offset: 0x0001CAD8
		public void OnBeforeSerialize()
		{
			this.m_list.Clear();
			foreach (int num in this.m_set)
			{
				this.m_list.Add(this.ToEnum(num));
			}
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0001E944 File Offset: 0x0001CB44
		public void OnAfterDeserialize()
		{
			this.m_set.Clear();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				int num = this.ToInt(this.m_list[i]);
				if (!this.m_set.Add(num))
				{
					string text = "Set contiene valores repetidos: ";
					T t = this.m_list[i];
					Debug.LogError(text + t.ToString());
				}
			}
		}

		// Token: 0x04000259 RID: 601
		[SerializeField]
		private List<T> m_list;

		// Token: 0x0400025A RID: 602
		[NonSerialized]
		private HashSet<int> m_set;
	}
}
