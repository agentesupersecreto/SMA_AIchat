using System;
using System.Collections.Generic;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000D6EA File Offset: 0x0000B8EA
		public IReadOnlyList<TKey> serializedKeys
		{
			get
			{
				return this.keys;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000D6F2 File Offset: 0x0000B8F2
		public IReadOnlyList<TValue> serializedValues
		{
			get
			{
				return this.values;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000D6FA File Offset: 0x0000B8FA
		public SerializableDictionary()
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000D718 File Offset: 0x0000B918
		public SerializableDictionary(IDictionary<TKey, TValue> dictionary)
			: base(dictionary)
		{
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000D737 File Offset: 0x0000B937
		public SerializableDictionary(IEqualityComparer<TKey> comparer)
			: base(comparer)
		{
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000D758 File Offset: 0x0000B958
		public void LoadFrom(IReadOnlyDictionary<TKey, TValue> source)
		{
			this.keys = new List<TKey>();
			this.values = new List<TValue>();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in source)
			{
				this.keys.Add(keyValuePair.Key);
				this.values.Add(keyValuePair.Value);
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000D7D4 File Offset: 0x0000B9D4
		public void LoadFrom(IDictionary<TKey, TValue> source)
		{
			this.keys = new List<TKey>();
			this.values = new List<TValue>();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in source)
			{
				this.keys.Add(keyValuePair.Key);
				this.values.Add(keyValuePair.Value);
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000D850 File Offset: 0x0000BA50
		public void SaveTo(IDictionary<TKey, TValue> result)
		{
			result.Clear();
			this.keys = new List<TKey>();
			this.values = new List<TValue>();
			int num = Mathf.Min(this.keys.Count, this.values.Count);
			for (int i = 0; i < num; i++)
			{
				result.Add(this.keys[i], this.values[i]);
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000D8C0 File Offset: 0x0000BAC0
		public void OnBeforeSerialize()
		{
			this.keys.Clear();
			this.values.Clear();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
			{
				this.keys.Add(keyValuePair.Key);
				this.values.Add(keyValuePair.Value);
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000D944 File Offset: 0x0000BB44
		public void OnAfterDeserialize()
		{
			base.Clear();
			if (this.keys.Count != this.values.Count)
			{
				throw new Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable.", Array.Empty<object>()));
			}
			for (int i = 0; i < this.keys.Count; i++)
			{
				base.Add(this.keys[i], this.values[i]);
			}
		}

		// Token: 0x04000095 RID: 149
		[SerializeField]
		private List<TKey> keys = new List<TKey>();

		// Token: 0x04000096 RID: 150
		[SerializeField]
		private List<TValue> values = new List<TValue>();
	}
}
