using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.ArmaduresSkins
{
	// Token: 0x02000130 RID: 304
	public abstract class ArmatureSkinsClasificada : ArmatureSkins
	{
		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x0002E113 File Offset: 0x0002C313
		public ArmatureSkinsClasificada.SkinPartes skinPartes
		{
			get
			{
				return this.m_SkinPartes;
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x0002E11B File Offset: 0x0002C31B
		public sealed override Skin mainSkin
		{
			get
			{
				return this.m_SkinPartes.body;
			}
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0002E128 File Offset: 0x0002C328
		protected override void OnMainSkinsCreated(List<Skin> Skins, List<SkinnedMeshRenderer> mainRenderers)
		{
			base.OnMainSkinsCreated(Skins, mainRenderers);
			this.PoblarPartes(this.m_SkinPartes, Skins, mainRenderers);
		}

		// Token: 0x06000D4C RID: 3404
		protected abstract void PoblarPartes(ArmatureSkinsClasificada.SkinPartes skinPartes, List<Skin> Skins, List<SkinnedMeshRenderer> mainRenderers);

		// Token: 0x04000772 RID: 1906
		[ReadOnlyUI]
		[SerializeField]
		private ArmatureSkinsClasificada.SkinPartes m_SkinPartes = new ArmatureSkinsClasificada.SkinPartes();

		// Token: 0x02000206 RID: 518
		[Serializable]
		public class SkinPartes
		{
			// Token: 0x04000B0F RID: 2831
			public Skin head;

			// Token: 0x04000B10 RID: 2832
			public Skin body;

			// Token: 0x04000B11 RID: 2833
			public Skin scalp;

			// Token: 0x04000B12 RID: 2834
			public Skin cejas;

			// Token: 0x04000B13 RID: 2835
			[Obsolete("", true)]
			public Skin cejaR;

			// Token: 0x04000B14 RID: 2836
			[Obsolete("", true)]
			public Skin cejaL;

			// Token: 0x04000B15 RID: 2837
			public Skin ojos;

			// Token: 0x04000B16 RID: 2838
			public Skin lengua;

			// Token: 0x04000B17 RID: 2839
			public Skin dientes;

			// Token: 0x04000B18 RID: 2840
			public Skin pesones;
		}
	}
}
