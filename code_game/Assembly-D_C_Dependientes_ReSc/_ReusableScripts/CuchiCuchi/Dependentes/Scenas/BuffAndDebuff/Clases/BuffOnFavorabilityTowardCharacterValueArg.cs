using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000BF RID: 191
	[Serializable]
	public class BuffOnFavorabilityTowardCharacterValueArg : DisplayableArgumentoDeEfecto<BuffOnFavorabilityTowardCharacterValueArg>
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x000066D6 File Offset: 0x000048D6
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.favorability;
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00016484 File Offset: 0x00014684
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			if (string.IsNullOrWhiteSpace(this.towardID))
			{
				return string.Empty;
			}
			string text;
			string text2;
			string text3;
			MemoriaDeNpc.TryGetNombres(GlobalSingletonV2<MemoriaJson>.instance, this.towardID, out text, out text2, out text3);
			return (string.IsNullOrWhiteSpace(text3) ? "Forgotten" : text3) + " +" + this.add.ToString("0.0");
		}

		// Token: 0x04000378 RID: 888
		public string towardID;

		// Token: 0x04000379 RID: 889
		public float add;
	}
}
