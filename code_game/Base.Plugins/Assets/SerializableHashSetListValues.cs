using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200013E RID: 318
	[Serializable]
	public class SerializableHashSetListValues<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver, IReadOnlyList<T>, IReadOnlyCollection<T> where T : struct
	{
		// Token: 0x06000946 RID: 2374 RVA: 0x0001E9BC File Offset: 0x0001CBBC
		public SerializableHashSetListValues()
		{
			this.Init(0, null);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0001E9CC File Offset: 0x0001CBCC
		public SerializableHashSetListValues(IEqualityComparer<T> comparer)
		{
			this.Init(0, comparer);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0001E9DC File Offset: 0x0001CBDC
		public SerializableHashSetListValues(IEnumerable<T> collection)
		{
			this.Init(0, null);
			foreach (T t in collection)
			{
				this.Add(t);
			}
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0001EA34 File Offset: 0x0001CC34
		public SerializableHashSetListValues(int capacity)
		{
			this.Init(capacity, null);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0001EA44 File Offset: 0x0001CC44
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

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x0001EAC2 File Offset: 0x0001CCC2
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0001EACF File Offset: 0x0001CCCF
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)this.m_list).IsReadOnly;
			}
		}

		// Token: 0x170001A0 RID: 416
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

		// Token: 0x170001A1 RID: 417
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

		// Token: 0x06000950 RID: 2384 RVA: 0x0001EB40 File Offset: 0x0001CD40
		public void Sort(Comparison<T> comparison)
		{
			this.m_list.Sort(comparison);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0001EB4E File Offset: 0x0001CD4E
		public void Clear()
		{
			this.m_list.Clear();
			this.m_set.Clear();
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0001EB66 File Offset: 0x0001CD66
		public bool Add(T item)
		{
			bool flag = this.m_set.Add(item);
			if (flag)
			{
				this.m_list.Add(item);
			}
			return flag;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0001EB83 File Offset: 0x0001CD83
		public bool Contains(T item)
		{
			return this.m_set.Contains(item);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0001EB94 File Offset: 0x0001CD94
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

		// Token: 0x06000955 RID: 2389 RVA: 0x0001EBE0 File Offset: 0x0001CDE0
		public bool Remove(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list.Remove(item);
			}
			return flag;
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0001EBFE File Offset: 0x0001CDFE
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

		// Token: 0x06000957 RID: 2391 RVA: 0x0001EC2C File Offset: 0x0001CE2C
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

		// Token: 0x06000958 RID: 2392 RVA: 0x0001EC81 File Offset: 0x0001CE81
		public bool RemoveAndRebuild(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list = new List<T>(this.m_set);
			}
			return flag;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001ECA4 File Offset: 0x0001CEA4
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

		// Token: 0x0600095A RID: 2394 RVA: 0x0001ECD8 File Offset: 0x0001CED8
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

		// Token: 0x0600095B RID: 2395 RVA: 0x0001ED5C File Offset: 0x0001CF5C
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

		// Token: 0x0600095C RID: 2396 RVA: 0x0001EDD2 File Offset: 0x0001CFD2
		public int IndexOf(T item)
		{
			return ((IList<T>)this.m_list).IndexOf(item);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001EDE0 File Offset: 0x0001CFE0
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0001EDE7 File Offset: 0x0001CFE7
		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0001EDF1 File Offset: 0x0001CFF1
		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)this.m_list).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0001EE00 File Offset: 0x0001D000
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0001EE0D File Offset: 0x0001D00D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0001EE1C File Offset: 0x0001D01C
		public void OnBeforeSerialize()
		{
			this.m_list.Clear();
			foreach (T t in this.m_set)
			{
				this.m_list.Add(t);
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0001EE80 File Offset: 0x0001D080
		public void OnAfterDeserialize()
		{
			this.m_set.Clear();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				this.m_set.Add(this.m_list[i]);
			}
		}

		// Token: 0x0400025B RID: 603
		[SerializeField]
		private List<T> m_list;

		// Token: 0x0400025C RID: 604
		[NonSerialized]
		private HashSet<T> m_set;
	}
}
