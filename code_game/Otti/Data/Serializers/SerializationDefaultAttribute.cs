using System;

namespace com.ootii.Data.Serializers
{
	// Token: 0x02000061 RID: 97
	public class SerializationDefaultAttribute : Attribute
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0001B7EE File Offset: 0x000199EE
		public object Value
		{
			get
			{
				return this.mValue;
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001B7F6 File Offset: 0x000199F6
		public SerializationDefaultAttribute(object rValue)
		{
			this.mValue = rValue;
		}

		// Token: 0x0400024A RID: 586
		protected object mValue;
	}
}
