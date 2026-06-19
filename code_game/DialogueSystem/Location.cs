using System;
using PixelCrushers.DialogueSystem.ChatMapper;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	public class Location : Asset
	{
		// Token: 0x060001F6 RID: 502 RVA: 0x00008FC8 File Offset: 0x000071C8
		public Location()
		{
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00008FD0 File Offset: 0x000071D0
		public Location(Location sourceLocation)
			: base(sourceLocation)
		{
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00008FDC File Offset: 0x000071DC
		public Location(Location chatMapperLocation)
		{
			this.Assign(chatMapperLocation);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00008FEC File Offset: 0x000071EC
		public void Assign(Location chatMapperLocation)
		{
			if (chatMapperLocation != null)
			{
				base.Assign(chatMapperLocation.ID, chatMapperLocation.Fields);
			}
		}
	}
}
