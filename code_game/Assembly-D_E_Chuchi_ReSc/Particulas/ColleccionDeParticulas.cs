using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Semens;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas
{
	// Token: 0x02000154 RID: 340
	public sealed class ColleccionDeParticulas : Singleton<ColleccionDeParticulas>
	{
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x00023E08 File Offset: 0x00022008
		[Obsolete("", true)]
		public ParticleSystem semenParaPene
		{
			get
			{
				return this.m_semenParaPene;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x00023E10 File Offset: 0x00022010
		[Obsolete("", true)]
		public ParticleSystem semenParaSkin
		{
			get
			{
				return this.m_semenParaSkin;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x00023E18 File Offset: 0x00022018
		public Material semenParticulaMaterial
		{
			get
			{
				return this.m_semenParticulaMaterial;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00023E20 File Offset: 0x00022020
		public Material semenSkinMaterial
		{
			get
			{
				return this.m_semenSkinMaterial;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x00023E28 File Offset: 0x00022028
		public GameObject semenParticulaPrefab
		{
			get
			{
				return this.m_semenParticulaPrefab;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x00023E30 File Offset: 0x00022030
		public EmisorDeSemenChain emisorParaPenePrefab
		{
			get
			{
				return this.m_emisorParaPenePrefab;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x00023E38 File Offset: 0x00022038
		public EmisorDeSemenChain emisorParaBocaPrefab
		{
			get
			{
				return this.m_emisorParaBocaPrefab;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x00023E40 File Offset: 0x00022040
		public EmisorDeSemenChain emisorParaHolePrefab
		{
			get
			{
				return this.m_emisorParaHolePrefab;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00023E48 File Offset: 0x00022048
		public EmisorDeSemenChain emisorParaHoleWaterPrefab
		{
			get
			{
				return this.m_emisorParaHoleWaterPrefab;
			}
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00023E50 File Offset: 0x00022050
		protected override void InitData(bool esEditorTime)
		{
			if (this.m_semenParticulaMaterial == null)
			{
				throw new ArgumentNullException("m_semenParticulaMaterial", "m_semenParticulaMaterial null reference.");
			}
			if (this.m_semenSkinMaterial == null)
			{
				throw new ArgumentNullException("m_semenSkinMaterial", "m_semenSkinMaterial null reference.");
			}
			if (this.m_semenParticulaPrefab == null)
			{
				throw new ArgumentNullException("m_semenParticulaPrefab", "m_semenParticulaPrefab null reference.");
			}
			if (this.m_emisorParaPenePrefab == null)
			{
				throw new ArgumentNullException("m_emisorParaPenePrefab", "m_emisorParaPenePrefab null reference.");
			}
			if (this.m_emisorParaBocaPrefab == null)
			{
				throw new ArgumentNullException("m_emisorParaBocaPrefab", "m_emisorParaBocaPrefab null reference.");
			}
			if (this.m_emisorParaHolePrefab == null)
			{
				throw new ArgumentNullException("m_emisorParaHolePrefab", "m_emisorParaHolePrefab null reference.");
			}
			if (this.m_emisorParaHoleWaterPrefab == null)
			{
				throw new ArgumentNullException("m_emisorParaHoleWaterPrefab", "m_emisorParaHoleWaterPrefab null reference.");
			}
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00023F2F File Offset: 0x0002212F
		protected override void DoAwake()
		{
			base.DoAwake();
		}

		// Token: 0x0400060C RID: 1548
		[Obsolete("", true)]
		private ParticleSystem m_semenParaPene;

		// Token: 0x0400060D RID: 1549
		[Obsolete("", true)]
		private ParticleSystem m_semenParaSkin;

		// Token: 0x0400060E RID: 1550
		[SerializeField]
		private Material m_semenParticulaMaterial;

		// Token: 0x0400060F RID: 1551
		[SerializeField]
		private Material m_semenSkinMaterial;

		// Token: 0x04000610 RID: 1552
		[SerializeField]
		private GameObject m_semenParticulaPrefab;

		// Token: 0x04000611 RID: 1553
		[SerializeField]
		private EmisorDeSemenChain m_emisorParaPenePrefab;

		// Token: 0x04000612 RID: 1554
		[SerializeField]
		private EmisorDeSemenChain m_emisorParaBocaPrefab;

		// Token: 0x04000613 RID: 1555
		[SerializeField]
		private EmisorDeSemenChain m_emisorParaHolePrefab;

		// Token: 0x04000614 RID: 1556
		[SerializeField]
		private EmisorDeSemenChain m_emisorParaHoleWaterPrefab;
	}
}
