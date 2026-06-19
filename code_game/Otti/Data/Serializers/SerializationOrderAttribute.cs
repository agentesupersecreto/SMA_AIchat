using System;

namespace com.ootii.Data.Serializers
{
	// Token: 0x02000062 RID: 98
	public class SerializationOrderAttribute : Attribute
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0001B805 File Offset: 0x00019A05
		public int Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001B80D File Offset: 0x00019A0D
		public SerializationOrderAttribute(int rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x0400024B RID: 587
		protected int mValue;
	}
}
