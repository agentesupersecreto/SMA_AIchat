using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Skins.Globales
{
	// Token: 0x020001A6 RID: 422
	public class SemenSkinsParaHoleInternals : Singleton<SemenSkinsParaHoleInternals>
	{
		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000A0A RID: 2570 RVA: 0x0002D4D3 File Offset: 0x0002B6D3
		public SemenSkinsParaHoleInternals.HoleSemenSkins vag
		{
			get
			{
				return this.m_vag;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x0002D4DB File Offset: 0x0002B6DB
		public SemenSkinsParaHoleInternals.HoleSemenSkins anus
		{
			get
			{
				return this.m_anus;
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0002D4E3 File Offset: 0x0002B6E3
		protected override void DoAwake()
		{
			base.DoAwake();
			if (!this.m_vag.isValid)
			{
				throw new InvalidOperationException();
			}
			if (!this.m_anus.isValid)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0002D511 File Offset: 0x0002B711
		public SkinnedMeshRenderer GetPrefabForAnus(int index)
		{
			return this.m_anus.prefabs[index.GetWrappedIndex(this.m_anus.prefabs.Count)];
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0002D539 File Offset: 0x0002B739
		public SkinnedMeshRenderer GetPrefabForVag(int index)
		{
			return this.m_vag.prefabs[index.GetWrappedIndex(this.m_vag.prefabs.Count)];
		}

		// Token: 0x040007F6 RID: 2038
		[SerializeField]
		private SemenSkinsParaHoleInternals.HoleSemenSkins m_vag = new SemenSkinsParaHoleInternals.HoleSemenSkins();

		// Token: 0x040007F7 RID: 2039
		[SerializeField]
		private SemenSkinsParaHoleInternals.HoleSemenSkins m_anus = new SemenSkinsParaHoleInternals.HoleSemenSkins();

		// Token: 0x020001A7 RID: 423
		[Serializable]
		public class HoleSemenSkins
		{
			// Token: 0x17000230 RID: 560
			// (get) Token: 0x06000A10 RID: 2576 RVA: 0x0002D57F File Offset: 0x0002B77F
			public IReadOnlyList<SkinnedMeshRenderer> prefabs
			{
				get
				{
					return this.m_prefabs;
				}
			}

			// Token: 0x17000231 RID: 561
			// (get) Token: 0x06000A11 RID: 2577 RVA: 0x0002D587 File Offset: 0x0002B787
			public bool isValid
			{
				get
				{
					return this.m_prefabs.Length != 0;
				}
			}

			// Token: 0x040007F8 RID: 2040
			[SerializeField]
			private SkinnedMeshRenderer[] m_prefabs;
		}
	}
}
