using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200013F RID: 319
	[Serializable]
	public class SerializableHashSetList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver, IReadOnlyList<T>, IReadOnlyCollection<T> where T : class
	{
		// Token: 0x06000964 RID: 2404 RVA: 0x0001EEC6 File Offset: 0x0001D0C6
		public SerializableHashSetList()
		{
			this.Init(0, null);
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0001EED6 File Offset: 0x0001D0D6
		public SerializableHashSetList(IEqualityComparer<T> comparer)
		{
			this.Init(0, comparer);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0001EEE8 File Offset: 0x0001D0E8
		public SerializableHashSetList(IEnumerable<T> collection)
		{
			this.Init(0, null);
			foreach (T t in collection)
			{
				this.Add(t);
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001EF40 File Offset: 0x0001D140
		public SerializableHashSetList(int capacity)
		{
			this.Init(capacity, null);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0001EF50 File Offset: 0x0001D150
		private void Init(int capacity = 0, IEqualityComparer<T> comparer = null)
		{
			if (comparer == null)
			{
				this.m_set = new HashSet<T>();
			}
			else
			{
				this.m_set = new HashSet<T>(comparer);
			}
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

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x0001EFCE File Offset: 0x0001D1CE
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x0001EFDB File Offset: 0x0001D1DB
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)this.m_list).IsReadOnly;
			}
		}

		// Token: 0x170001A4 RID: 420
		T IList<T>.this[int index]
		{
			get
			{
				return ((IList<T>)this.m_list)[index];
			}
			set
			{
				if (!this.m_set.Contains(value))
				{
					throw new NotSupportedException();
				}
				((IList<T>)this.m_list)[index] = value;
			}
		}

		// Token: 0x170001A5 RID: 421
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

		// Token: 0x0600096E RID: 2414 RVA: 0x0001F04C File Offset: 0x0001D24C
		public void Clear()
		{
			this.m_list.Clear();
			this.m_set.Clear();
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001F064 File Offset: 0x0001D264
		public bool Add(T item)
		{
			bool flag = this.m_set.Add(item);
			if (flag)
			{
				this.m_list.Add(item);
			}
			return flag;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0001F081 File Offset: 0x0001D281
		public bool Contains(T item)
		{
			return this.m_set.Contains(item);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001F08F File Offset: 0x0001D28F
		public void Sort(Comparison<T> comparison)
		{
			this.m_list.Sort(comparison);
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001F0A0 File Offset: 0x0001D2A0
		public void RemoveAt(int index)
		{
			try
			{
				T t = this.m_list[index];
				this.m_set.Remove(t);
				this.m_list.RemoveAt(index);
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
				throw ex;
			}
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		public bool Remove(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list.Remove(item);
			}
			return flag;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0001F10A File Offset: 0x0001D30A
		public bool RemoveAndRepopulate(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_set);
			}
			return flag;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0001F138 File Offset: 0x0001D338
		public bool RemoveAndRepopulateMany(IList<T> items)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = this.m_set.Remove(items[i]) || flag;
			}
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_set);
			}
			return flag;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0001F18D File Offset: 0x0001D38D
		public bool RemoveAndRebuild(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list = new List<T>(this.m_set);
			}
			return flag;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0001F1B0 File Offset: 0x0001D3B0
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

		// Token: 0x06000978 RID: 2424 RVA: 0x0001F1E4 File Offset: 0x0001D3E4
		public bool RemoveAndRepopulate(IList<T> items)
		{
			bool? flag = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.m_set.Remove(items[i]))
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
				this.m_list.AddRange(this.m_set);
			}
			return flag.Value;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0001F268 File Offset: 0x0001D468
		public bool RemoveAndRebuild(IList<T> items)
		{
			bool? flag = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.m_set.Remove(items[i]))
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
				this.m_list = new List<T>(this.m_set);
			}
			return flag.Value;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0001F2DE File Offset: 0x0001D4DE
		public int IndexOf(T item)
		{
			return ((IList<T>)this.m_list).IndexOf(item);
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0001F2EC File Offset: 0x0001D4EC
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0001F2F3 File Offset: 0x0001D4F3
		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0001F2FD File Offset: 0x0001D4FD
		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)this.m_list).CopyTo(array, arrayIndex);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0001F30C File Offset: 0x0001D50C
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0001F319 File Offset: 0x0001D519
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0001F328 File Offset: 0x0001D528
		public void OnBeforeSerialize()
		{
			this.m_list.Clear();
			foreach (T t in this.m_set)
			{
				this.m_list.Add(t);
			}
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0001F38C File Offset: 0x0001D58C
		public void OnAfterDeserialize()
		{
			this.m_set.Clear();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				this.m_set.Add(this.m_list[i]);
			}
		}

		// Token: 0x0400025D RID: 605
		[SerializeReference]
		private List<T> m_list;

		// Token: 0x0400025E RID: 606
		[NonSerialized]
		private HashSet<T> m_set;
	}
}
