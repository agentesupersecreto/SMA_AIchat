using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000055 RID: 85
	public interface IEndableOnDateBuff
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001CF RID: 463
		bool infinite { get; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001D0 RID: 464
		DateTime endTime { get; }
	}
}
