using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200005B RID: 91
	public interface IPrintableBuff
	{
		// Token: 0x060001DE RID: 478
		string DebugPrint();

		// Token: 0x060001DF RID: 479
		string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language);

		// Token: 0x060001E0 RID: 480
		string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language);

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001E1 RID: 481
		DisplayableBuffCategory category { get; }
	}
}
