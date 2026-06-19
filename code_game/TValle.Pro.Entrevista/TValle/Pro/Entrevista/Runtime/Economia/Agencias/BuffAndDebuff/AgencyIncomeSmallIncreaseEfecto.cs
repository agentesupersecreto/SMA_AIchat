using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000E0 RID: 224
	[Serializable]
	public sealed class AgencyIncomeSmallIncreaseEfecto : AgencyIncomeChangeEfecto<AgencyIncomeSmallIncreaseEfecto>
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0002F63B File Offset: 0x0002D83B
		protected override float amount
		{
			get
			{
				return 1f;
			}
		}
	}
}
