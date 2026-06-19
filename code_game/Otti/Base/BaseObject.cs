using System;

namespace com.ootii.Base
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public class BaseObject : IBaseObject
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0001C459 File Offset: 0x0001A659
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x0001C478 File Offset: 0x0001A678
		public virtual string GUID
		{
			get
			{
				if (this._GUID.Length == 0)
				{
					this.GenerateGUID();
				}
				return this._GUID;
			}
			set
			{
				if (value.Length == 0)
				{
					return;
				}
				string guid = this._GUID;
				this._GUID = value;
				if (guid.Length > 0 && value != guid)
				{
					this.OnGUIDChanged(guid, this._GUID);
				}
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0001C4BB File Offset: 0x0001A6BB
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x0001C4C3 File Offset: 0x0001A6C3
		public virtual string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0001C4CC File Offset: 0x0001A6CC
		public BaseObject()
		{
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0001C4EA File Offset: 0x0001A6EA
		public BaseObject(string rGUID)
		{
			this._GUID = rGUID;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001C510 File Offset: 0x0001A710
		public string GenerateGUID()
		{
			this._GUID = Guid.NewGuid().ToString();
			return this._GUID;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001C53C File Offset: 0x0001A73C
		public virtual void OnGUIDChanged(string rOldGUID, string rNewGUID)
		{
			if (this.GUIDChangedEvent != null)
			{
				this.GUIDChangedEvent(rOldGUID, rNewGUID);
			}
		}

		// Token: 0x0400025D RID: 605
		public GUIDChangedDelegate GUIDChangedEvent;

		// Token: 0x0400025E RID: 606
		public string _GUID = "";

		// Token: 0x0400025F RID: 607
		public string _Name = "";
	}
}
