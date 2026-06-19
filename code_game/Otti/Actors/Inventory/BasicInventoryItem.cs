using System;
using UnityEngine;

namespace com.ootii.Actors.Inventory
{
	// Token: 0x020000B5 RID: 181
	[Serializable]
	public class BasicInventoryItem
	{
		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000A37 RID: 2615 RVA: 0x00033282 File Offset: 0x00031482
		// (set) Token: 0x06000A38 RID: 2616 RVA: 0x0003328A File Offset: 0x0003148A
		public string ItemType
		{
			get
			{
				return this._ItemType;
			}
			set
			{
				this._ItemType = value;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00033293 File Offset: 0x00031493
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x0003329B File Offset: 0x0003149B
		public virtual Vector3 LocalRotationEuler
		{
			get
			{
				return this._LocalRotationEuler;
			}
			set
			{
				this._LocalRotationEuler = value;
				this.LocalRotation = Quaternion.Euler(this._LocalRotationEuler);
			}
		}

		// Token: 0x04000506 RID: 1286
		public string ID = "";

		// Token: 0x04000507 RID: 1287
		public int Quantity = 1;

		// Token: 0x04000508 RID: 1288
		public string _ItemType = "";

		// Token: 0x04000509 RID: 1289
		public string ResourcePath = "";

		// Token: 0x0400050A RID: 1290
		public string EquipMotion = "";

		// Token: 0x0400050B RID: 1291
		public int EquipStyle;

		// Token: 0x0400050C RID: 1292
		public string StoreMotion = "";

		// Token: 0x0400050D RID: 1293
		public int StoreStyle;

		// Token: 0x0400050E RID: 1294
		public bool DestroyOnStore;

		// Token: 0x0400050F RID: 1295
		public GameObject Instance;

		// Token: 0x04000510 RID: 1296
		public Vector3 LocalPosition = Vector3.zero;

		// Token: 0x04000511 RID: 1297
		public Quaternion LocalRotation = Quaternion.identity;

		// Token: 0x04000512 RID: 1298
		public Vector3 _LocalRotationEuler = Vector3.zero;

		// Token: 0x04000513 RID: 1299
		[NonSerialized]
		public Transform StoredParent;

		// Token: 0x04000514 RID: 1300
		[NonSerialized]
		public Vector3 StoredPosition = Vector3.zero;

		// Token: 0x04000515 RID: 1301
		[NonSerialized]
		public Quaternion StoredRotation = Quaternion.identity;
	}
}
