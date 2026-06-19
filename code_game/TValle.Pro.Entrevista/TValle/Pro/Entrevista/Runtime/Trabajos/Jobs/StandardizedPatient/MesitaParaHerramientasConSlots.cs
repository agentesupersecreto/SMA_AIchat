using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000069 RID: 105
	public class MesitaParaHerramientasConSlots : CustomMonobehaviour
	{
		// Token: 0x060004BD RID: 1213 RVA: 0x0001C168 File Offset: 0x0001A368
		public int GetNextSlotIndex()
		{
			int nextSlot = this.m_nextSlot;
			this.m_nextSlot++;
			return nextSlot;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001C17E File Offset: 0x0001A37E
		public Transform GetNextSlot()
		{
			return this.GetSlot(this.GetNextSlotIndex());
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001C18C File Offset: 0x0001A38C
		public void SetSlot(int index, GameObject go)
		{
			this.m_SlotDe.AddOrReplase(go, index);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001C19C File Offset: 0x0001A39C
		public int GetSlotIndex(GameObject go)
		{
			int nextSlot;
			if (!this.m_SlotDe.TryGetValue(go, out nextSlot))
			{
				nextSlot = this.m_nextSlot;
				this.m_nextSlot++;
				this.m_SlotDe.Add(go, nextSlot);
			}
			return nextSlot;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001C1DC File Offset: 0x0001A3DC
		public Transform GetSlot(int index)
		{
			switch (index)
			{
			case 0:
				return this.slot0;
			case 1:
				return this.slot1;
			case 2:
				return this.slot2;
			case 3:
				return this.slot3;
			case 4:
				return this.slot4;
			case 5:
				return this.slot5;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0001C240 File Offset: 0x0001A440
		public Transform GetSlot(GameObject go)
		{
			int slotIndex = this.GetSlotIndex(go);
			return this.GetSlot(slotIndex);
		}

		// Token: 0x040002A0 RID: 672
		public Transform slot0;

		// Token: 0x040002A1 RID: 673
		public Transform slot1;

		// Token: 0x040002A2 RID: 674
		public Transform slot2;

		// Token: 0x040002A3 RID: 675
		public Transform slot3;

		// Token: 0x040002A4 RID: 676
		public Transform slot4;

		// Token: 0x040002A5 RID: 677
		public Transform slot5;

		// Token: 0x040002A6 RID: 678
		private int m_nextSlot;

		// Token: 0x040002A7 RID: 679
		private Dictionary<GameObject, int> m_SlotDe = new Dictionary<GameObject, int>();
	}
}
