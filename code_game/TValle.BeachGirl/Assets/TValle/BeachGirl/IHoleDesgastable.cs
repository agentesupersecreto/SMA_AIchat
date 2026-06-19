using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000018 RID: 24
	public interface IHoleDesgastable
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600006B RID: 107
		IDesgastable motion { get; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600006C RID: 108
		IDesgastable profundidad { get; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600006D RID: 109
		IDesgastable anchura { get; }
	}
}
