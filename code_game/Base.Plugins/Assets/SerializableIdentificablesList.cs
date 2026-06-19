using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000140 RID: 320
	[Serializable]
	public abstract class SerializableIdentificablesList<ID, T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver, IReadOnlyList<T>, IReadOnlyCollection<T> where T : class
	{
		// Token: 0x06000982 RID: 2434 RVA: 0x0001F3D2 File Offset: 0x0001D5D2
		public SerializableIdentificablesList()
		{
			this.Init(0, null);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0001F3E2 File Offset: 0x0001D5E2
		public SerializableIdentificablesList(IEqualityComparer<ID> comparer)
		{
			this.Init(0, comparer);
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0001F3F4 File Offset: 0x0001D5F4
		public SerializableIdentificablesList(IEnumerable<T> collection)
		{
			this.Init(0, null);
			foreach (T t in collection)
			{
				this.Add(t);
			}
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001F44C File Offset: 0x0001D64C
		public SerializableIdentificablesList(int capacity)
		{
			this.Init(capacity, null);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0001F45C File Offset: 0x0001D65C
		private void Init(int capacity = 0, IEqualityComparer<ID> comparer = null)
		{
			if (comparer == null)
			{
				this.m_dicc = new Dictionary<ID, T>();
			}
			else
			{
				this.m_dicc = new Dictionary<ID, T>(comparer);
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

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x0001F4DA File Offset: 0x0001D6DA
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0001F4E7 File Offset: 0x0001D6E7
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)this.m_list).IsReadOnly;
			}
		}

		// Token: 0x170001A8 RID: 424
		T IList<T>.this[int index]
		{
			get
			{
				return ((IList<T>)this.m_list)[index];
			}
			set
			{
				if (!this.m_dicc.ContainsKey(this.GetKeyDeItem(value)))
				{
					throw new NotSupportedException();
				}
				((IList<T>)this.m_list)[index] = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		public T this[ID key]
		{
			get
			{
				return this.m_dicc[key];
			}
		}

		// Token: 0x170001AA RID: 426
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

		// Token: 0x0600098D RID: 2445 RVA: 0x0001F56C File Offset: 0x0001D76C
		public void Clear()
		{
			this.m_list.Clear();
			this.m_dicc.Clear();
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0001F584 File Offset: 0x0001D784
		public bool Add(T item)
		{
			bool flag = this.m_dicc.TryAdd(this.GetKeyDeItem(item), item);
			if (flag)
			{
				this.m_list.Add(item);
			}
			return flag;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0001F5A8 File Offset: 0x0001D7A8
		public bool Contains(T item)
		{
			return this.m_dicc.ContainsKey(this.GetKeyDeItem(item));
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0001F5BC File Offset: 0x0001D7BC
		public bool Contains(ID key)
		{
			return this.m_dicc.ContainsKey(key);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0001F5CA File Offset: 0x0001D7CA
		public void Sort(Comparison<T> comparison)
		{
			this.m_list.Sort(comparison);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0001F5D8 File Offset: 0x0001D7D8
		public void RemoveAt(int index)
		{
			try
			{
				T t = this.m_list[index];
				this.m_dicc.Remove(this.GetKeyDeItem(t));
				this.m_list.RemoveAt(index);
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
				throw ex;
			}
		}

		// Token: 0x06000993 RID: 2451
		protected abstract ID GetKeyDeItem(T item);

		// Token: 0x06000994 RID: 2452 RVA: 0x0001F62C File Offset: 0x0001D82C
		public bool Remove(T item)
		{
			bool flag = this.m_dicc.Remove(this.GetKeyDeItem(item));
			if (flag)
			{
				this.m_list.Remove(item);
			}
			return flag;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0001F650 File Offset: 0x0001D850
		public bool RemoveAndRepopulate(T item)
		{
			bool flag = this.m_dicc.Remove(this.GetKeyDeItem(item));
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_dicc.Values);
			}
			return flag;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0001F688 File Offset: 0x0001D888
		public bool RemoveAndRepopulateMany(IList<T> items)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				flag = this.m_dicc.Remove(this.GetKeyDeItem(items[i])) || flag;
			}
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_dicc.Values);
			}
			return flag;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0001F6E8 File Offset: 0x0001D8E8
		public bool RemoveAndRebuild(T item)
		{
			bool flag = this.m_dicc.Remove(this.GetKeyDeItem(item));
			if (flag)
			{
				this.m_list = new List<T>(this.m_dicc.Values);
			}
			return flag;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0001F718 File Offset: 0x0001D918
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

		// Token: 0x06000999 RID: 2457 RVA: 0x0001F74C File Offset: 0x0001D94C
		public bool RemoveAndRepopulate(IList<T> items)
		{
			bool? flag = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.m_dicc.Remove(this.GetKeyDeItem(items[i])))
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
				this.m_list.AddRange(this.m_dicc.Values);
			}
			return flag.Value;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		public bool RemoveAndRebuild(IList<T> items)
		{
			bool? flag = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (!this.m_dicc.Remove(this.GetKeyDeItem(items[i])))
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
				this.m_list = new List<T>(this.m_dicc.Values);
			}
			return flag.Value;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0001F859 File Offset: 0x0001DA59
		public int IndexOf(T item)
		{
			return ((IList<T>)this.m_list).IndexOf(item);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0001F867 File Offset: 0x0001DA67
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0001F86E File Offset: 0x0001DA6E
		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0001F878 File Offset: 0x0001DA78
		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)this.m_list).CopyTo(array, arrayIndex);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0001F887 File Offset: 0x0001DA87
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0001F894 File Offset: 0x0001DA94
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0001F8A1 File Offset: 0x0001DAA1
		public void OnBeforeSerialize()
		{
			this.m_list.Clear();
			this.m_list.AddRange(this.m_dicc.Values);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		public void OnAfterDeserialize()
		{
			this.m_dicc.Clear();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				T t = this.m_list[i];
				this.m_dicc.Add(this.GetKeyDeItem(t), t);
			}
		}

		// Token: 0x0400025F RID: 607
		[SerializeReference]
		private List<T> m_list;

		// Token: 0x04000260 RID: 608
		[NonSerialized]
		private Dictionary<ID, T> m_dicc;
	}
}
