using System;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C9 RID: 201
	public class BuffOnPartePorLubricacionArg : DisplayableArgumentoDeEfecto<BuffOnPartePorLubricacionArg>
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00014284 File Offset: 0x00012484
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00017021 File Offset: 0x00015221
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return TValleUILocalTextAttribute.Localizado<SensitiveBodyPart>(this.parte, Language.en) + " at " + this.weight.ToString("p0");
		}

		// Token: 0x04000389 RID: 905
		public SensitiveBodyPart parte;

		// Token: 0x0400038A RID: 906
		public float weight;

		// Token: 0x0400038B RID: 907
		public float pleasureReductionWeight;
	}
}
