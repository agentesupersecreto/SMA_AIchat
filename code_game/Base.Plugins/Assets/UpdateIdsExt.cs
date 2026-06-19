using System;

namespace Assets
{
	// Token: 0x02000173 RID: 371
	public static class UpdateIdsExt
	{
		// Token: 0x06000B14 RID: 2836 RVA: 0x00025440 File Offset: 0x00023640
		public static bool IsCurrent(this UpdateAutoId id)
		{
			return UpdateAutoId.isCurrent(id);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00025448 File Offset: 0x00023648
		public static bool IsCurrent(this ForcedFixedUpdateId id)
		{
			return ForcedFixedUpdateId.isCurrent(id);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00025450 File Offset: 0x00023650
		public static bool IsCurrent(this ForcedUpdateId id)
		{
			return ForcedUpdateId.isCurrent(id);
		}
	}
}
