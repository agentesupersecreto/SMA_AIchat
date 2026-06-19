using System;

namespace com.ootii.Data.Serializers
{
	// Token: 0x02000060 RID: 96
	public class SerializationNameAttribute : Attribute
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x0001B7D7 File Offset: 0x000199D7
		public string Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0001B7DF File Offset: 0x000199DF
		public SerializationNameAttribute(string rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x04000249 RID: 585
		protected string mValue;
	}
}
