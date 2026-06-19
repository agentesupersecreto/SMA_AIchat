using System;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B1 RID: 177
	public class BuffOnEmocionAddArg : DisplayableArgumentoDeEfecto<BuffOnEmocionAddArg>
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003AE RID: 942 RVA: 0x0001522D File Offset: 0x0001342D
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return this.emo.ParseToCategory();
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0001523A File Offset: 0x0001343A
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Emotion>(this.emo, Language.en) + " +" + this.add.ToString();
		}

		// Token: 0x04000354 RID: 852
		public float add;

		// Token: 0x04000355 RID: 853
		public Emotion emo;
	}
}
