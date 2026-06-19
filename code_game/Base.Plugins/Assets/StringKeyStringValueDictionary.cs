using System;
using System.Collections.Generic;
using TValleCustomClases;

namespace Assets
{
	// Token: 0x0200011F RID: 287
	[Serializable]
	public sealed class StringKeyStringValueDictionary : SerializableDictionary<string, string>, ISerializedDataContainer, IDataContainer<string>
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x0001BA37 File Offset: 0x00019C37
		public StringKeyStringValueDictionary()
		{
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0001BA3F File Offset: 0x00019C3F
		public StringKeyStringValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0001BA48 File Offset: 0x00019C48
		public void AddData(string id, string data, bool replace = true)
		{
			if (!string.IsNullOrEmpty(id))
			{
				if (base.ContainsKey(id))
				{
					if (replace)
					{
						base[id] = data;
						return;
					}
				}
				else
				{
					base.Add(id, data);
				}
				return;
			}
			if (id == null)
			{
				throw new ArgumentNullException("id", "id de data es null reference.");
			}
			throw new NotSupportedException("no se puede añadir a data una id vacia");
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0001BA98 File Offset: 0x00019C98
		public void ClearData()
		{
			base.Clear();
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0001BAA0 File Offset: 0x00019CA0
		public string FindData(string id)
		{
			string text;
			if (base.TryGetValue(id, out text))
			{
				return text;
			}
			return null;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0001BABB File Offset: 0x00019CBB
		public bool RemoverData(string id)
		{
			return base.Remove(id);
		}
	}
}
