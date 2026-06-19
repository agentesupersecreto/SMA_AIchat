using System;

namespace Assets
{
	// Token: 0x02000166 RID: 358
	public static class IntExt
	{
		// Token: 0x06000A90 RID: 2704 RVA: 0x00023B28 File Offset: 0x00021D28
		public static int FromMaskToLayer(this int mask)
		{
			return 1 >> mask;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00023B30 File Offset: 0x00021D30
		public static int ToLayerMask(this int layer)
		{
			return 1 << layer;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00023B38 File Offset: 0x00021D38
		public static bool IsLastIndex(this int index, int largo)
		{
			return index >= largo - 1;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00023B44 File Offset: 0x00021D44
		public static Guid ToGuid(this int value)
		{
			byte[] array = new byte[16];
			BitConverter.GetBytes(value).CopyTo(array, 0);
			return new Guid(array);
		}
	}
}
