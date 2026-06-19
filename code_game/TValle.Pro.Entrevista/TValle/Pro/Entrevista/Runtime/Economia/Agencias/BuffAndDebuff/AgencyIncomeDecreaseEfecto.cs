using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000DF RID: 223
	[Serializable]
	public sealed class AgencyIncomeDecreaseEfecto : AgencyIncomeChangeEfecto<AgencyIncomeDecreaseEfecto>
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0002F62C File Offset: 0x0002D82C
		protected override float amount
		{
			get
			{
				return -5f;
			}
		}
	}
}
