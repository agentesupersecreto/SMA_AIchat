using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000115 RID: 277
	public class DiccionaryEnum<TEnum, TValue> : IEnumerable<KeyValuePair<int, TValue>>, IEnumerable, ICollection<KeyValuePair<int, TValue>>, IDictionary<int, TValue>, IReadOnlyDictionary<int, TValue>, IReadOnlyCollection<KeyValuePair<int, TValue>>
	{
		// Token: 0x060007CB RID: 1995 RVA: 0x0001B305 File Offset: 0x00019505
		public DiccionaryEnum(int capacidad, Func<TEnum, int> convertidor)
		{
			if (convertidor == null)
			{
				throw new ArgumentNullException("convertidor", "convertidor null reference.");
			}
			this.m_convertidor = convertidor;
			this.m_dicc = new Dictionary<int, TValue>(capacidad);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0001B333 File Offset: 0x00019533
		public DiccionaryEnum(Func<TEnum, int> convertidor)
		{
			if (convertidor == null)
			{
				throw new ArgumentNullException("convertidor", "convertidor null reference.");
			}
			this.m_convertidor = convertidor;
			this.m_dicc = new Dictionary<int, TValue>();
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0001B360 File Offset: 0x00019560
		public Func<TEnum, int> convertidor
		{
			get
			{
				return this.m_convertidor;
			}
		}

		// Token: 0x17000161 RID: 353
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

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0001B39B File Offset: 0x0001959B
		public int Count
		{
			get
			{
				return this.m_dicc.Count;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x0001B3A8 File Offset: 0x000195A8
		public ICollection<int> Keys
		{
			get
			{
				return this.m_dicc.Keys;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0001B3B5 File Offset: 0x000195B5
		public ICollection<TValue> Values
		{
			get
			{
				return this.m_dicc.Values;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0001B3C2 File Offset: 0x000195C2
		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<KeyValuePair<int, TValue>>)this.m_dicc).IsReadOnly;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0001B3CF File Offset: 0x000195CF
		IEnumerable<int> IReadOnlyDictionary<int, TValue>.Keys
		{
			get
			{
				return ((IReadOnlyDictionary<int, TValue>)this.m_dicc).Keys;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0001B3DC File Offset: 0x000195DC
		IEnumerable<TValue> IReadOnlyDictionary<int, TValue>.Values
		{
			get
			{
				return ((IReadOnlyDictionary<int, TValue>)this.m_dicc).Values;
			}
		}

		// Token: 0x17000168 RID: 360
		public TValue this[int key]
		{
			get
			{
				return ((IDictionary<int, TValue>)this.m_dicc)[key];
			}
			set
			{
				((IDictionary<int, TValue>)this.m_dicc)[key] = value;
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0001B408 File Offset: 0x00019608
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

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001B490 File Offset: 0x00019690
		public void Clear()
		{
			this.m_dicc.Clear();
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001B49D File Offset: 0x0001969D
		public bool ContainsKey(TEnum key)
		{
			return this.m_dicc.ContainsKey(this.m_convertidor(key));
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0001B4B6 File Offset: 0x000196B6
		public IEnumerator<KeyValuePair<int, TValue>> GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0001B4C8 File Offset: 0x000196C8
		public bool Remove(KeyValuePair<TEnum, TValue> item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0001B4CF File Offset: 0x000196CF
		public bool Remove(TEnum key)
		{
			return this.m_dicc.Remove(this.m_convertidor(key));
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0001B4E8 File Offset: 0x000196E8
		public bool TryGetValue(TEnum key, out TValue value)
		{
			return this.m_dicc.TryGetValue(this.m_convertidor(key), out value);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0001B502 File Offset: 0x00019702
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0001B514 File Offset: 0x00019714
		IEnumerator<KeyValuePair<int, TValue>> IEnumerable<KeyValuePair<int, TValue>>.GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0001B526 File Offset: 0x00019726
		public void Add(KeyValuePair<int, TValue> item)
		{
			((ICollection<KeyValuePair<int, TValue>>)this.m_dicc).Add(item);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0001B534 File Offset: 0x00019734
		public bool Contains(KeyValuePair<int, TValue> item)
		{
			return ((ICollection<KeyValuePair<int, TValue>>)this.m_dicc).Contains(item);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0001B542 File Offset: 0x00019742
		public void CopyTo(KeyValuePair<int, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<int, TValue>>)this.m_dicc).CopyTo(array, arrayIndex);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0001B551 File Offset: 0x00019751
		public bool Remove(KeyValuePair<int, TValue> item)
		{
			return ((ICollection<KeyValuePair<int, TValue>>)this.m_dicc).Remove(item);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0001B55F File Offset: 0x0001975F
		public void Add(int key, TValue value)
		{
			((IDictionary<int, TValue>)this.m_dicc).Add(key, value);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0001B56E File Offset: 0x0001976E
		public bool ContainsKey(int key)
		{
			return ((IDictionary<int, TValue>)this.m_dicc).ContainsKey(key);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0001B57C File Offset: 0x0001977C
		public bool Remove(int key)
		{
			return ((IDictionary<int, TValue>)this.m_dicc).Remove(key);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0001B58A File Offset: 0x0001978A
		public bool TryGetValue(int key, out TValue value)
		{
			return ((IDictionary<int, TValue>)this.m_dicc).TryGetValue(key, out value);
		}

		// Token: 0x04000227 RID: 551
		private Func<TEnum, int> m_convertidor;

		// Token: 0x04000228 RID: 552
		private Dictionary<int, TValue> m_dicc;
	}
}
