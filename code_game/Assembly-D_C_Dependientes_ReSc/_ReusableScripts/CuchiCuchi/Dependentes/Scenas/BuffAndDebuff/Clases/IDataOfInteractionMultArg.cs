using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x0200009C RID: 156
	public interface IDataOfInteractionMultArg
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600034A RID: 842
		// (set) Token: 0x0600034B RID: 843
		InterationReceivedType[] interationReceivedTypes { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600034C RID: 844
		// (set) Token: 0x0600034D RID: 845
		TriggeringBodyPart[] fromParts { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600034E RID: 846
		// (set) Token: 0x0600034F RID: 847
		SensitiveBodyPart[] toParts { get; set; }
	}
}
