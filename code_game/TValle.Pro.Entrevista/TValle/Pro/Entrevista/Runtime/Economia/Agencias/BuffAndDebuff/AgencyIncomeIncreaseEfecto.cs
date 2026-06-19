using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000DE RID: 222
	[Serializable]
	public sealed class AgencyIncomeIncreaseEfecto : AgencyIncomeChangeEfecto<AgencyIncomeIncreaseEfecto>
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0002F61D File Offset: 0x0002D81D
		protected override float amount
		{
			get
			{
				return 5f;
			}
		}
	}
}
