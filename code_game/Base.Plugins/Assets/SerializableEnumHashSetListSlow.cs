using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200013C RID: 316
	[Serializable]
	public class SerializableEnumHashSetListSlow<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver, IReadOnlyList<T>, IReadOnlyCollection<T> where T : Enum, IConvertible
	{
		// Token: 0x0600090E RID: 2318 RVA: 0x0001DDBC File Offset: 0x0001BFBC
		public SerializableEnumHashSetListSlow()
		{
			IEqualityComparer<T> equalityComparer = default(SerializableEnumHashSetListSlow<T>.FastEnumIntEqualityComparer);
			this.m_set = new HashSet<T>(equalityComparer);
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

		// Token: 0x0600090F RID: 2319 RVA: 0x0001DE40 File Offset: 0x0001C040
		public SerializableEnumHashSetListSlow(IEnumerable<T> collection)
		{
			IEqualityComparer<T> equalityComparer = default(SerializableEnumHashSetListSlow<T>.FastEnumIntEqualityComparer);
			this.m_set = new HashSet<T>(equalityComparer);
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
				if (this.m_set.Add(t))
				{
					this.m_list.Add(t);
				}
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0001DF18 File Offset: 0x0001C118
		public SerializableEnumHashSetListSlow(int capacity)
		{
			IEqualityComparer<T> equalityComparer = default(SerializableEnumHashSetListSlow<T>.FastEnumIntEqualityComparer);
			this.m_set = new HashSet<T>(equalityComparer);
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

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0001DF9B File Offset: 0x0001C19B
		public int Count
		{
			get
			{
				return this.m_list.Count;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0001DFA8 File Offset: 0x0001C1A8
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<T>)this.m_list).IsReadOnly;
			}
		}

		// Token: 0x17000198 RID: 408
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

		// Token: 0x17000199 RID: 409
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

		// Token: 0x06000916 RID: 2326 RVA: 0x0001DFFC File Offset: 0x0001C1FC
		public void Clear()
		{
			this.m_list.Clear();
			this.m_set.Clear();
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0001E014 File Offset: 0x0001C214
		public bool Add(T item)
		{
			bool flag = this.m_set.Add(item);
			if (flag)
			{
				this.m_list.Add(item);
			}
			return flag;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0001E031 File Offset: 0x0001C231
		public bool Contains(T item)
		{
			return this.m_set.Contains(item);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0001E040 File Offset: 0x0001C240
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

		// Token: 0x0600091A RID: 2330 RVA: 0x0001E08C File Offset: 0x0001C28C
		public bool Remove(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list.Remove(item);
			}
			return flag;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0001E0AA File Offset: 0x0001C2AA
		public bool RemoveAndRepopulate(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list.Clear();
				this.m_list.AddRange(this.m_set.Cast<T>());
			}
			return flag;
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0001E0DC File Offset: 0x0001C2DC
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
				this.m_list.AddRange(this.m_set.Cast<T>());
			}
			return flag;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0001E136 File Offset: 0x0001C336
		public bool RemoveAndRebuild(T item)
		{
			bool flag = this.m_set.Remove(item);
			if (flag)
			{
				this.m_list = new List<T>(this.m_set.Cast<T>());
			}
			return flag;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0001E160 File Offset: 0x0001C360
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

		// Token: 0x0600091F RID: 2335 RVA: 0x0001E194 File Offset: 0x0001C394
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
				this.m_list.AddRange(this.m_set.Cast<T>());
			}
			return flag.Value;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0001E21C File Offset: 0x0001C41C
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
				this.m_list = new List<T>(this.m_set.Cast<T>());
			}
			return flag.Value;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0001E297 File Offset: 0x0001C497
		public int IndexOf(T item)
		{
			return ((IList<T>)this.m_list).IndexOf(item);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0001E2A5 File Offset: 0x0001C4A5
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0001E2AC File Offset: 0x0001C4AC
		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0001E2B6 File Offset: 0x0001C4B6
		public void CopyTo(T[] array, int arrayIndex)
		{
			((ICollection<T>)this.m_list).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0001E2C5 File Offset: 0x0001C4C5
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0001E2D2 File Offset: 0x0001C4D2
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this.m_list).GetEnumerator();
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0001E2E0 File Offset: 0x0001C4E0
		public void OnBeforeSerialize()
		{
			this.m_list.Clear();
			foreach (T t in this.m_set)
			{
				this.m_list.Add(t);
			}
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0001E344 File Offset: 0x0001C544
		public void OnAfterDeserialize()
		{
			this.m_set.Clear();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				T t = this.m_list[i];
				if (!this.m_set.Add(t))
				{
					Debug.LogError("Set contiene valores repetidos: " + t.ToString());
				}
			}
		}

		// Token: 0x04000257 RID: 599
		[SerializeField]
		private List<T> m_list;

		// Token: 0x04000258 RID: 600
		[NonSerialized]
		private HashSet<T> m_set;

		// Token: 0x020001D7 RID: 471
		public struct FastEnumIntEqualityComparer : IEqualityComparer<T>
		{
			// Token: 0x06000C93 RID: 3219 RVA: 0x00027077 File Offset: 0x00025277
			public bool Equals(T firstEnum, T secondEnum)
			{
				return firstEnum.ToInt32(null) == secondEnum.ToInt32(null);
			}

			// Token: 0x06000C94 RID: 3220 RVA: 0x00027097 File Offset: 0x00025297
			public int GetHashCode(T firstEnum)
			{
				return firstEnum.ToInt32(null);
			}
		}
	}
}
