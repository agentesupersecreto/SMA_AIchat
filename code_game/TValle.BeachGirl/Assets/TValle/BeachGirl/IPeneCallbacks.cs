using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000036 RID: 54
	public interface IPeneCallbacks
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000117 RID: 279
		// (remove) Token: 0x06000118 RID: 280
		event IPeneCallbacksHandler peneTryingEnterInHole;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000119 RID: 281
		// (remove) Token: 0x0600011A RID: 282
		event IPeneCallbacksHandler peneEnteredInHole;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600011B RID: 283
		// (remove) Token: 0x0600011C RID: 284
		event IPeneCallbacksHandler peneStayedInHole;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600011D RID: 285
		// (remove) Token: 0x0600011E RID: 286
		event IPeneCallbacksHandler peneExitedInHole;
	}
}
