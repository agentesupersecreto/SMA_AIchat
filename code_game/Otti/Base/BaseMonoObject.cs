using System;
using com.ootii.Data.Serializers;
using UnityEngine;

namespace com.ootii.Base
{
	// Token: 0x0200006A RID: 106
	[Serializable]
	public class BaseMonoObject : MonoBehaviour, IBaseObject
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0001C38D File Offset: 0x0001A58D
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x0001C3AC File Offset: 0x0001A5AC
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

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x0001C3EF File Offset: 0x0001A5EF
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x0001C3F7 File Offset: 0x0001A5F7
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

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001C414 File Offset: 0x0001A614
		public string GenerateGUID()
		{
			this._GUID = Guid.NewGuid().ToString();
			return this._GUID;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0001C440 File Offset: 0x0001A640
		public virtual void OnGUIDChanged(string rOldGUID, string rNewGUID)
		{
			if (this.GUIDChangedEvent != null)
			{
				this.GUIDChangedEvent(rOldGUID, rNewGUID);
			}
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0001C457 File Offset: 0x0001A657
		public virtual void OnGUIDChanged()
		{
		}

		// Token: 0x0400025B RID: 603
		public GUIDChangedDelegate GUIDChangedEvent;

		// Token: 0x0400025C RID: 604
		[HideInInspector]
		public string _GUID = "";
	}
}
