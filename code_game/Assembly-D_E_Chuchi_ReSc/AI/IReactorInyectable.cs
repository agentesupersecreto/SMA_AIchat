using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000313 RID: 787
	public interface IReactorInyectable : IReactor
	{
		// Token: 0x14000054 RID: 84
		// (add) Token: 0x0600110C RID: 4364
		// (remove) Token: 0x0600110D RID: 4365
		event IReactorReaccionandoHandler reaccionando;

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x0600110E RID: 4366
		// (remove) Token: 0x0600110F RID: 4367
		event IReactorReaccionadoHandler reaccionado;
	}
}
