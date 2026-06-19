using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.ArmaduresSkins
{
	// Token: 0x0200012F RID: 303
	public abstract class ArmatureMaleSkinsClasificada : ArmatureSkins
	{
		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000D44 RID: 3396 RVA: 0x0002E0D3 File Offset: 0x0002C2D3
		public ArmatureMaleSkinsClasificada.SkinPartes skinPartes
		{
			get
			{
				return this.m_SkinPartes;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x0002E0DB File Offset: 0x0002C2DB
		public sealed override Skin mainSkin
		{
			get
			{
				return this.m_SkinPartes.body;
			}
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0002E0E8 File Offset: 0x0002C2E8
		protected override void OnMainSkinsCreated(List<Skin> Skins, List<SkinnedMeshRenderer> mainRenderers)
		{
			base.OnMainSkinsCreated(Skins, mainRenderers);
			this.PoblarPartes(this.m_SkinPartes, Skins, mainRenderers);
		}

		// Token: 0x06000D47 RID: 3399
		protected abstract void PoblarPartes(ArmatureMaleSkinsClasificada.SkinPartes skinPartes, List<Skin> Skins, List<SkinnedMeshRenderer> mainRenderers);

		// Token: 0x04000771 RID: 1905
		[ReadOnlyUI]
		[SerializeField]
		private ArmatureMaleSkinsClasificada.SkinPartes m_SkinPartes = new ArmatureMaleSkinsClasificada.SkinPartes();

		// Token: 0x02000205 RID: 517
		[Serializable]
		public class SkinPartes
		{
			// Token: 0x04000B0B RID: 2827
			public Skin body;

			// Token: 0x04000B0C RID: 2828
			public Skin ojos;

			// Token: 0x04000B0D RID: 2829
			public Skin lengua;

			// Token: 0x04000B0E RID: 2830
			public Skin dientes;
		}
	}
}
