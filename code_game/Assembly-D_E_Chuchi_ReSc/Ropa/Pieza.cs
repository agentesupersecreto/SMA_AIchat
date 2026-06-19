using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000CF RID: 207
	[Serializable]
	public class Pieza
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0001842B File Offset: 0x0001662B
		public int ropaID_OLD
		{
			get
			{
				return this.ropaID;
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00018434 File Offset: 0x00016634
		public Pieza Clone()
		{
			Pieza pieza = (Pieza)base.MemberwiseClone();
			pieza.materiales = this.materiales.Select((SlotDeMaterialDeRopa d) => d.Clone()).ToList<SlotDeMaterialDeRopa>();
			return pieza;
		}

		// Token: 0x04000359 RID: 857
		[HideInInspector]
		[SerializeField]
		private int ropaID;

		// Token: 0x0400035A RID: 858
		[ComboBox(typeof(ProveedorPiezasDeRopaIDAttribute))]
		public string ropaIDString;

		// Token: 0x0400035B RID: 859
		public List<SlotDeMaterialDeRopa> materiales = new List<SlotDeMaterialDeRopa>();
	}
}
