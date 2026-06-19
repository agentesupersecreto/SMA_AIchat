using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200003B RID: 59
	public interface IPuppetConPartes : IComponentStartable
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000131 RID: 305
		PartesDePuppet<IPuppetParte> partesDePuppet { get; }
	}
}
