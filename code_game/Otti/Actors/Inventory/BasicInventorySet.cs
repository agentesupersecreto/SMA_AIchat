using System;
using System.Collections.Generic;

namespace com.ootii.Actors.Inventory
{
	// Token: 0x020000B6 RID: 182
	[Serializable]
	public class BasicInventorySet
	{
		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000A3C RID: 2620 RVA: 0x00033340 File Offset: 0x00031540
		// (set) Token: 0x06000A3D RID: 2621 RVA: 0x00033348 File Offset: 0x00031548
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x00033351 File Offset: 0x00031551
		// (set) Token: 0x06000A3F RID: 2623 RVA: 0x00033359 File Offset: 0x00031559
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x00033362 File Offset: 0x00031562
		// (set) Token: 0x06000A41 RID: 2625 RVA: 0x0003336A File Offset: 0x0003156A
		public int Stance
		{
			get
			{
				return this._Stance;
			}
			set
			{
				this._Stance = value;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x00033373 File Offset: 0x00031573
		// (set) Token: 0x06000A43 RID: 2627 RVA: 0x0003337B File Offset: 0x0003157B
		public int DefaultForm
		{
			get
			{
				return this._DefaultForm;
			}
			set
			{
				this._DefaultForm = value;
			}
		}

		// Token: 0x04000516 RID: 1302
		public string _ID = "";

		// Token: 0x04000517 RID: 1303
		public bool _IsEnabled = true;

		// Token: 0x04000518 RID: 1304
		public int _Stance = -1;

		// Token: 0x04000519 RID: 1305
		public int _DefaultForm = -1;

		// Token: 0x0400051A RID: 1306
		public List<BasicInventorySetItem> Items = new List<BasicInventorySetItem>();
	}
}
