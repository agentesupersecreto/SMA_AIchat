using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.Materiales;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x0200010B RID: 267
	[Serializable]
	public class MaterialParaRopaData : MaterialData
	{
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x0001ED8C File Offset: 0x0001CF8C
		[Obsolete("", true)]
		public override long id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0001ED94 File Offset: 0x0001CF94
		[Obsolete]
		public float chance
		{
			get
			{
				return this.chanceMaterial / 100f * (this.chancePrenda / 100f);
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001EDAF File Offset: 0x0001CFAF
		[Obsolete("", true)]
		public bool EsParaRopaId(int ropaID)
		{
			return EnumIDAttribute.EsConpuestoDeA(this.m_id, ropaID);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001EDBD File Offset: 0x0001CFBD
		public bool EsParaRopaId(string ropaID)
		{
			return this.paraPrendasID.Count != 0 && !string.IsNullOrWhiteSpace(ropaID) && this.paraPrendasID.Contains(ropaID);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001EDE2 File Offset: 0x0001CFE2
		protected override void OnInitiatedID()
		{
			if (this.indexes == null)
			{
				this.indexes = new List<int>();
			}
			if (this.indexes.Count == 0)
			{
				this.indexes.Add(0);
			}
		}

		// Token: 0x04000481 RID: 1153
		[Obsolete("", true)]
		[HideInInspector]
		[EnumID(typeof(MapaDeRopa.RopaPreSetId), typeof(MapaDeMaterialesParaRopa.MaterialParaRopaPreSetId))]
		private long m_id;

		// Token: 0x04000482 RID: 1154
		[Obsolete("ahora los materiales son compatibles con varias prendas", true)]
		[HideInInspector]
		public string paraPrendaID;

		// Token: 0x04000483 RID: 1155
		[ComboBox(typeof(ProveedorPiezasDeRopaIDAttribute))]
		public List<string> paraPrendasID = new List<string>();

		// Token: 0x04000484 RID: 1156
		public AssetReference diffusionProfile;

		// Token: 0x04000485 RID: 1157
		[Tooltip("inclusivo")]
		public List<int> indexes = new List<int> { 0 };

		// Token: 0x04000486 RID: 1158
		public bool puedeTenerCustomColor;

		// Token: 0x04000487 RID: 1159
		[InspectorName("puedeTenerCustomAlpha")]
		public bool esTransparente;

		// Token: 0x04000488 RID: 1160
		public ItemQuality itemQuality = ItemQuality.Common;

		// Token: 0x04000489 RID: 1161
		[Range(0f, 100f)]
		public float chanceMaterial = 100f;

		// Token: 0x0400048A RID: 1162
		[Obsolete]
		[Range(0.1f, 100f)]
		[NonSerialized]
		public float chancePrenda = 100f;
	}
}
