using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200012C RID: 300
	public class HashSetList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		// Token: 0x06000849 RID: 2121 RVA: 0x0001BBB5 File Offset: 0x00019DB5
		public List<T> ObtenerReferenciaDeLista()
		{
			return this.m_list;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0001BBBD File Offset: 0x00019DBD
		public HashSetList()
		{
			this.m_list = new List<T>();
			this.m_set = new HashSet<T>();
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0001BBDC File Offset: 0x00019DDC
		public HashSetList(IEnumerable<T> collection)
		{
			this.m_list = new List<T>(collection.Count<T>());
			this.m_set = new HashSet<T>();
			foreach (T t in collection)
			{
				if (this.m_set.Add(t))
				{
					this.m_list.Add(t);
				}
			}
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0001BC5C File Offset: 0x00019E5C
		public HashSetList(int capacity)
		{
			this.m_list = new List<T>(capacity);
			this.m_set = new HashSet<T>();
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001BC7B File Offset: 0x00019E7B
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x0001BC88 File Offset: 0x00019E88
		public void Shuffle()
		{
			this.m_list.Shuffle<T>();
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0001BC95 File Offset: 0x00019E95
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)this.m_list).IsReadOnly;
			}
		}

		// Token: 0x17000174 RID: 372
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

		// Token: 0x17000175 RID: 373
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

		// Token: 0x06000853 RID: 2131 RVA: 0x0001BCE8 File Offset: 0x00019EE8
		public void Clear()
		{
			this.m_list.Clear();
			this.m_set.Clear();
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0001BD00 File Offset: 0x00019F00
		public bool Add(T item)
		{
			bool flag = this.m_set.Add(item);
			if (flag)
			{
				this.m_list.Add(item);
			}
			return flag;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0001BD1D File Offset: 0x00019F1D
		public bool Contains(T item)
		{
			return this.m_set.Contains(item);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0001BD2C File Offset: 0x00019F2C
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

		// Token: 0x06000857 RID: 2135 RVA: 0x0001BD78 File Offset: 0x00019F78
		public bool Remove(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list.Remove(item);
			}
			return flag;
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0001BD96 File Offset: 0x00019F96
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

		// Token: 0x06000859 RID: 2137 RVA: 0x0001BDC4 File Offset: 0x00019FC4
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

		// Token: 0x0600085A RID: 2138 RVA: 0x0001BE19 File Offset: 0x0001A019
		public bool RemoveAndRebuild(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list = new List<T>(this.m_set);
			}
			return flag;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0001BE3C File Offset: 0x0001A03C
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

		// Token: 0x0600085C RID: 2140 RVA: 0x0001BE70 File Offset: 0x0001A070
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

		// Token: 0x0600085D RID: 2141 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
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

		// Token: 0x0600085E RID: 2142 RVA: 0x0001BF6A File Offset: 0x0001A16A
		public int IndexOf(T item)
		{
			return ((IList<T>)this.m_list).IndexOf(item);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0001BF78 File Offset: 0x0001A178
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0001BF7F File Offset: 0x0001A17F
		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0001BF89 File Offset: 0x0001A189
		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)this.m_list).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0001BF98 File Offset: 0x0001A198
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0001BFA5 File Offset: 0x0001A1A5
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x0400022C RID: 556
		[NonSerialized]
		private List<T> m_list;

		// Token: 0x0400022D RID: 557
		[NonSerialized]
		private HashSet<T> m_set;
	}
}
