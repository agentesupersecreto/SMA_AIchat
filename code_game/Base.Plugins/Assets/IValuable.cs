using System;

namespace Assets
{
	// Token: 0x020000F7 RID: 247
	public interface IValuable<T_Val> where T_Val : struct
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060006E3 RID: 1763
		int id { get; }

		// Token: 0x060006E4 RID: 1764
		void EditorOverrideKey(int overridingKey);

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060006E5 RID: 1765
		// (set) Token: 0x060006E6 RID: 1766
		T_Val valor { get; set; }
	}
}
