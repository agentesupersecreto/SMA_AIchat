using System;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B3 RID: 179
	public class BuffOnEmocionGainArg : DisplayableArgumentoDeEfecto<BuffOnEmocionGainArg>
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0001543A File Offset: 0x0001363A
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return this.emo.ParseToCategory();
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00015448 File Offset: 0x00013648
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Emotion>(this.emo, Language.en) + " " + (this.gainMod * 100f - 100f).ToString("0.0") + "%";
		}

		// Token: 0x04000356 RID: 854
		public float gainMod;

		// Token: 0x04000357 RID: 855
		public Emotion emo;
	}
}
