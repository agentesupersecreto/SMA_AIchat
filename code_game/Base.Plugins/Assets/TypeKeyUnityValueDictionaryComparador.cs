using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000128 RID: 296
	internal class TypeKeyUnityValueDictionaryComparador : IEqualityComparer<SerializableType>
	{
		// Token: 0x06000840 RID: 2112 RVA: 0x0001BB5A File Offset: 0x00019D5A
		public bool Equals(SerializableType x, SerializableType y)
		{
			return x.type == y.type;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0001BB6D File Offset: 0x00019D6D
		public int GetHashCode(SerializableType obj)
		{
			return obj.type.GetHashCode();
		}
	}
}
