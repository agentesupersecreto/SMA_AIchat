using System;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000D8 RID: 216
	public interface IAttribute
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000B0B RID: 2827
		string ID { get; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000B0C RID: 2828
		Type ValueType { get; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000B0D RID: 2829
		// (set) Token: 0x06000B0E RID: 2830
		bool IsValid { get; set; }

		// Token: 0x06000B0F RID: 2831
		T1 GetValue<T1>();

		// Token: 0x06000B10 RID: 2832
		void SetValue<T1>(T1 rValue);
	}
}
