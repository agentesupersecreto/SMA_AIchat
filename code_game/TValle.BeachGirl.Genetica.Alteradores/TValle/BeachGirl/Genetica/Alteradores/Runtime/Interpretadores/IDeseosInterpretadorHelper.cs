using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000008 RID: 8
	public interface IDeseosInterpretadorHelper
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000056 RID: 86
		float facialInitial { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000057 RID: 87
		float crotchInitial { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000058 RID: 88
		float assInitial { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000059 RID: 89
		float facialGain { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005A RID: 90
		float crotchGain { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005B RID: 91
		float assGain { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005C RID: 92
		float deseoByVisual { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005D RID: 93
		float deseoByVerbal { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005E RID: 94
		float deseoByTouch { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005F RID: 95
		float deseoByExposure { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000060 RID: 96
		float deseoByCoital { get; }
	}
}
