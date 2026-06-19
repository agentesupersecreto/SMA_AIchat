using System;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000D9 RID: 217
	public interface IAttributeSource
	{
		// Token: 0x06000B11 RID: 2833
		bool AttributeExists(string rAttributeID);

		// Token: 0x06000B12 RID: 2834
		bool AttributesExist(string rAttributeIDs, bool rRequireAll = true);

		// Token: 0x06000B13 RID: 2835
		Type GetAttributeType(string rAttributeID);

		// Token: 0x06000B14 RID: 2836
		T GetAttributeValue<T>(string rAttributeID, T rDefault = default(T));

		// Token: 0x06000B15 RID: 2837
		void SetAttributeValue<T>(string rAttributeID, T rValue);
	}
}
