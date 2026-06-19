using System;
using com.ootii.Data.Serializers;
using UnityEngine;

namespace com.ootii.Base
{
	// Token: 0x0200006D RID: 109
	[Serializable]
	public class BaseScriptableObject : ScriptableObject, IBaseObject
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0001C553 File Offset: 0x0001A753
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0001C570 File Offset: 0x0001A770
		[SerializationIgnore]
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

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0001C5B3 File Offset: 0x0001A7B3
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0001C5BB File Offset: 0x0001A7BB
		[SerializationIgnore]
		public virtual string Name
		{
			get
			{
				return base.name;
			}
			set
			{
				base.name = value;
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0001C5C4 File Offset: 0x0001A7C4
		public string GenerateGUID()
		{
			this._GUID = Guid.NewGuid().ToString();
			return this._GUID;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001C5F0 File Offset: 0x0001A7F0
		public virtual void OnGUIDChanged(string rOldGUID, string rNewGUID)
		{
			if (this.GUIDChangedEvent != null)
			{
				this.GUIDChangedEvent(rOldGUID, rNewGUID);
			}
		}

		// Token: 0x04000260 RID: 608
		public GUIDChangedDelegate GUIDChangedEvent;

		// Token: 0x04000261 RID: 609
		[HideInInspector]
		public string _GUID = "";
	}
}
