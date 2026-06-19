using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000116 RID: 278
	public class DiccionaryEnumLong<TEnum, TValue> : IEnumerable<KeyValuePair<long, TValue>>, IEnumerable, ICollection<KeyValuePair<long, TValue>>, IDictionary<long, TValue>, IReadOnlyDictionary<long, TValue>, IReadOnlyCollection<KeyValuePair<long, TValue>>
	{
		// Token: 0x060007E9 RID: 2025 RVA: 0x0001B599 File Offset: 0x00019799
		public DiccionaryEnumLong(int capacidad, Func<TEnum, long> convertidor)
		{
			if (convertidor == null)
			{
				throw new ArgumentNullException("convertidor", "convertidor null reference.");
			}
			this.m_convertidor = convertidor;
			this.m_dicc = new Dictionary<long, TValue>(capacidad);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0001B5C7 File Offset: 0x000197C7
		public DiccionaryEnumLong(Func<TEnum, long> convertidor)
		{
			if (convertidor == null)
			{
				throw new ArgumentNullException("convertidor", "convertidor null reference.");
			}
			this.m_convertidor = convertidor;
			this.m_dicc = new Dictionary<long, TValue>();
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x0001B5F4 File Offset: 0x000197F4
		public Func<TEnum, long> convertidor
		{
			get
			{
				return this.m_convertidor;
			}
		}

		// Token: 0x1700016A RID: 362
		public TValue this[TEnum key]
		{
			get
			{
				return this.m_dicc[this.m_convertidor(key)];
			}
			set
			{
				this.m_dicc[this.m_convertidor(key)] = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x0001B62F File Offset: 0x0001982F
		public int Count
		{
			get
			{
				return this.m_dicc.Count;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x0001B63C File Offset: 0x0001983C
		public ICollection<long> Keys
		{
			get
			{
				return this.m_dicc.Keys;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x0001B649 File Offset: 0x00019849
		public ICollection<TValue> Values
		{
			get
			{
				return this.m_dicc.Values;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0001B656 File Offset: 0x00019856
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<KeyValuePair<long, TValue>>)this.m_dicc).IsReadOnly;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0001B663 File Offset: 0x00019863
		IEnumerable<long> IReadOnlyDictionary<long, TValue>.Keys
		{
			get
			{
				return ((IReadOnlyDictionary<long, TValue>)this.m_dicc).Keys;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x0001B670 File Offset: 0x00019870
		IEnumerable<TValue> IReadOnlyDictionary<long, TValue>.Values
		{
			get
			{
				return ((IReadOnlyDictionary<long, TValue>)this.m_dicc).Values;
			}
		}

		// Token: 0x17000171 RID: 369
		public TValue this[long key]
		{
			get
			{
				return ((IDictionary<long, TValue>)this.m_dicc)[key];
			}
			set
			{
				((IDictionary<long, TValue>)this.m_dicc)[key] = value;
			}
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0001B69C File Offset: 0x0001989C
		public void Add(TEnum key, TValue value)
		{
			try
			{
				this.m_dicc.Add(this.m_convertidor(key), value);
			}
			catch (ArgumentException ex)
			{
				throw new Exception("KEY REPETIDO: " + ((key != null) ? key.ToString() : null) + ", CON VALOR: " + this.m_convertidor(key).ToString(), ex);
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0001B724 File Offset: 0x00019924
		public void Clear()
		{
			this.m_dicc.Clear();
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0001B731 File Offset: 0x00019931
		public bool ContainsKey(TEnum key)
		{
			return this.m_dicc.ContainsKey(this.m_convertidor(key));
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0001B74A File Offset: 0x0001994A
		public IEnumerator<KeyValuePair<long, TValue>> GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0001B75C File Offset: 0x0001995C
		public bool Remove(KeyValuePair<TEnum, TValue> item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0001B763 File Offset: 0x00019963
		public bool Remove(TEnum key)
		{
			return this.m_dicc.Remove(this.m_convertidor(key));
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0001B77C File Offset: 0x0001997C
		public bool TryGetValue(TEnum key, out TValue value)
		{
			return this.m_dicc.TryGetValue(this.m_convertidor(key), out value);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0001B796 File Offset: 0x00019996
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0001B7A8 File Offset: 0x000199A8
		IEnumerator<KeyValuePair<long, TValue>> IEnumerable<KeyValuePair<long, TValue>>.GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0001B7BA File Offset: 0x000199BA
		public void Add(KeyValuePair<long, TValue> item)
		{
			((ICollection<KeyValuePair<long, TValue>>)this.m_dicc).Add(item);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0001B7C8 File Offset: 0x000199C8
		public bool Contains(KeyValuePair<long, TValue> item)
		{
			return ((ICollection<KeyValuePair<long, TValue>>)this.m_dicc).Contains(item);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0001B7D6 File Offset: 0x000199D6
		public void CopyTo(KeyValuePair<long, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<long, TValue>>)this.m_dicc).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0001B7E5 File Offset: 0x000199E5
		public bool Remove(KeyValuePair<long, TValue> item)
		{
			return ((ICollection<KeyValuePair<long, TValue>>)this.m_dicc).Remove(item);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0001B7F3 File Offset: 0x000199F3
		public void Add(long key, TValue value)
		{
			((IDictionary<long, TValue>)this.m_dicc).Add(key, value);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0001B802 File Offset: 0x00019A02
		public bool ContainsKey(long key)
		{
			return ((IDictionary<long, TValue>)this.m_dicc).ContainsKey(key);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0001B810 File Offset: 0x00019A10
		public bool Remove(long key)
		{
			return ((IDictionary<long, TValue>)this.m_dicc).Remove(key);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0001B81E File Offset: 0x00019A1E
		public bool TryGetValue(long key, out TValue value)
		{
			return ((IDictionary<long, TValue>)this.m_dicc).TryGetValue(key, out value);
		}

		// Token: 0x04000229 RID: 553
		private Func<TEnum, long> m_convertidor;

		// Token: 0x0400022A RID: 554
		private Dictionary<long, TValue> m_dicc;
	}
}
