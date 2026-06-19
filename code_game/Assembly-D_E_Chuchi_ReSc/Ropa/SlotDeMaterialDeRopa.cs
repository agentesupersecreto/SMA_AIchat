using System;
using Assets._ReusableScripts.Materiales;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000D1 RID: 209
	[Serializable]
	public class SlotDeMaterialDeRopa : MaterialDataIDSlotPar
	{
		// Token: 0x06000507 RID: 1287 RVA: 0x000184A8 File Offset: 0x000166A8
		public SlotDeMaterialDeRopa()
		{
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000184B0 File Offset: 0x000166B0
		[Obsolete("", true)]
		public SlotDeMaterialDeRopa(long matID)
		{
			this.SetMaterialID(matID);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x000184BF File Offset: 0x000166BF
		public SlotDeMaterialDeRopa(string matID)
		{
			this.m_materialIDString = matID;
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x000184CE File Offset: 0x000166CE
		[Obsolete("", true)]
		public override long materialID
		{
			get
			{
				return this.m_materialID;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x000184CE File Offset: 0x000166CE
		public long materialID_OLD
		{
			get
			{
				return this.m_materialID;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x000184D6 File Offset: 0x000166D6
		public override string materialIDString
		{
			get
			{
				return this.m_materialIDString;
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000184DE File Offset: 0x000166DE
		public void SetMaterialID(string ID)
		{
			this.m_materialIDString = ID;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x000184E8 File Offset: 0x000166E8
		[Obsolete("", true)]
		public void Descomponer(out MapaDeRopa.RopaPreSetId ropaId, out MapaDeMaterialesParaRopa.MaterialParaRopaPreSetId materialID)
		{
			int num;
			int num2;
			EnumIDAttribute.Descomponer(this.m_materialID, out num, out num2);
			ropaId = (MapaDeRopa.RopaPreSetId)num;
			materialID = (MapaDeMaterialesParaRopa.MaterialParaRopaPreSetId)num2;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0001850A File Offset: 0x0001670A
		[Obsolete("", true)]
		public void SetMaterialID(long matID)
		{
			this.m_materialID = matID;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00018513 File Offset: 0x00016713
		public SlotDeMaterialDeRopa Clone()
		{
			return (SlotDeMaterialDeRopa)base.MemberwiseClone();
		}

		// Token: 0x0400035E RID: 862
		[SerializeField]
		[HideInInspector]
		private long m_materialID;

		// Token: 0x0400035F RID: 863
		[SerializeField]
		[ComboBox(typeof(ProveedorMaterialesDeRopaIDAttribute))]
		private string m_materialIDString;

		// Token: 0x04000360 RID: 864
		[HideInInspector]
		public DiffusionProfileSettings customDiffusionProfileSettings;
	}
}
