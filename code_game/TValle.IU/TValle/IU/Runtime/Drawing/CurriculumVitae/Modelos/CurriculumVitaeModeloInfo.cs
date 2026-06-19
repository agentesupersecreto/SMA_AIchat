using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos
{
	// Token: 0x02000157 RID: 343
	[Panel(width = 530, height = 550, unlockParentFlexibleIfWidthWasSet = true, unlockFlexibleIfWidthWasSet = true)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class CurriculumVitaeModeloInfo
	{
		// Token: 0x0400040C RID: 1036
		[Label("Name", "US")]
		[InfoLabel]
		public string name = "test 1";

		// Token: 0x0400040D RID: 1037
		[Label("Last Name", "US")]
		[InfoLabel]
		public string lastName = "test 2";

		// Token: 0x0400040E RID: 1038
		[Label("Age", "US")]
		[InfoLabel]
		public string age;

		// Token: 0x0400040F RID: 1039
		[Label("Sex", "US")]
		[InfoLabel]
		public string sex;

		// Token: 0x04000410 RID: 1040
		[Label("Fatigue", "US")]
		[InfoLabel]
		public string fatigue;

		// Token: 0x04000411 RID: 1041
		[Label("Overall Exp", "US")]
		[InfoLabel]
		public string overallExp;

		// Token: 0x04000412 RID: 1042
		[Label("Height", "US")]
		[InfoLabel]
		public string height;

		// Token: 0x04000413 RID: 1043
		[Label("Chest", "US")]
		[InfoLabel]
		public string chest;

		// Token: 0x04000414 RID: 1044
		[Label("Waist", "US")]
		[InfoLabel]
		public string waist;

		// Token: 0x04000415 RID: 1045
		[Label("Hips", "US")]
		[InfoLabel]
		public string hips;

		// Token: 0x04000416 RID: 1046
		[Label("Personality A", "US")]
		[DescripcionLocalizado("Most Notable Personality Trait", "US")]
		[InfoLabel]
		public string mostNotablePersonalityTrait;

		// Token: 0x04000417 RID: 1047
		[Label("Personality B", "US")]
		[DescripcionLocalizado("Second Most Notable Personality Trait", "US")]
		[InfoLabel]
		public string secondMostNotablePersonalityTrait;

		// Token: 0x04000418 RID: 1048
		[Label("Interests", "US")]
		[InfoLabel]
		public string interests;

		// Token: 0x04000419 RID: 1049
		[Label("Sexual Experience", "US")]
		[InfoLabel]
		public string sexualExperience;

		// Token: 0x0400041A RID: 1050
		[Label("Sexual Derivation", "US")]
		[InfoLabel]
		public string sexualDerivation;
	}
}
