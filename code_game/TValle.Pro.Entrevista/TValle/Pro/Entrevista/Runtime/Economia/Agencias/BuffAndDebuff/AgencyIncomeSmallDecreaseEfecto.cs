using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000E1 RID: 225
	[Serializable]
	public sealed class AgencyIncomeSmallDecreaseEfecto : AgencyIncomeChangeEfecto<AgencyIncomeSmallDecreaseEfecto>
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0002F64A File Offset: 0x0002D84A
		protected override float amount
		{
			get
			{
				return -1f;
			}
		}
	}
}
