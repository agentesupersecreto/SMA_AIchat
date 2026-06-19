using System;
using com.ootii.Base;

namespace com.ootii.Items
{
	// Token: 0x0200002A RID: 42
	public abstract class ItemComponent : BaseMonoObject, IItemComponent, IItem, IBaseObject
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000A924 File Offset: 0x00008B24
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x0000A92C File Offset: 0x00008B2C
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x0000A935 File Offset: 0x00008B35
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x0000A93D File Offset: 0x00008B3D
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				this._IsActive = value;
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000A946 File Offset: 0x00008B46
		public virtual void UpdateComponent(IItem rItem)
		{
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000A948 File Offset: 0x00008B48
		public virtual void OnEquipped(IItem rItem)
		{
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000A94A File Offset: 0x00008B4A
		public virtual void OnStored(IItem rItem)
		{
		}

		// Token: 0x04000143 RID: 323
		public bool _IsEnabled = true;

		// Token: 0x04000144 RID: 324
		public bool _IsActive = true;
	}
}
