using System;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000AC RID: 172
	public class BuffOnDeseoGainAndMaxValueArg : DisplayableArgumentoDeEfecto<BuffOnDeseoGainAndMaxValueArg>
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00014CB2 File Offset: 0x00012EB2
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.desires;
			}
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00014CB8 File Offset: 0x00012EB8
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Desires>(this.des, Language.en) + " " + (this.mod * 100f - 100f).ToString("0.0") + "%";
		}

		// Token: 0x0400034C RID: 844
		public float mod;

		// Token: 0x0400034D RID: 845
		public Desires des;
	}
}
