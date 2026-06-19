using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000023C8 File Offset: 0x000005C8
		public IReadOnlyList<TKey> serializedKeys
		{
			get
			{
				return this.keys;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000023D0 File Offset: 0x000005D0
		public IReadOnlyList<TValue> serializedValues
		{
			get
			{
				return this.values;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000023D8 File Offset: 0x000005D8
		public SerializableDictionary()
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000023F6 File Offset: 0x000005F6
		public SerializableDictionary(IDictionary<TKey, TValue> dictionary)
			: base(dictionary)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002415 File Offset: 0x00000615
		public SerializableDictionary(IEqualityComparer<TKey> comparer)
			: base(comparer)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002434 File Offset: 0x00000634
		public bool TryAddInmediate(TKey key, TValue value)
		{
			if (base.TryAdd(key, value))
			{
				this.keys.Add(key);
				this.values.Add(value);
				return true;
			}
			return false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000245C File Offset: 0x0000065C
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

		// Token: 0x0600001F RID: 31 RVA: 0x000024D8 File Offset: 0x000006D8
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

		// Token: 0x06000020 RID: 32 RVA: 0x00002554 File Offset: 0x00000754
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

		// Token: 0x06000021 RID: 33 RVA: 0x000025C4 File Offset: 0x000007C4
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

		// Token: 0x06000022 RID: 34 RVA: 0x00002648 File Offset: 0x00000848
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

		// Token: 0x04000015 RID: 21
		[SerializeField]
		private List<TKey> keys = new List<TKey>();

		// Token: 0x04000016 RID: 22
		[SerializeField]
		private List<TValue> values = new List<TValue>();
	}
}
