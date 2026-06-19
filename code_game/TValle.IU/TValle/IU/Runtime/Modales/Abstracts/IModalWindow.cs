using System;

namespace Assets.TValle.IU.Runtime.Modales.Abstracts
{
	// Token: 0x020000DA RID: 218
	public interface IModalWindow
	{
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000670 RID: 1648
		bool isShowing { get; }

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000671 RID: 1649
		// (remove) Token: 0x06000672 RID: 1650
		event Action<IModalWindow> showingStateChanged;
	}
}
