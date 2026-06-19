using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000E2 RID: 226
	[ProveedorDeStacksTipoIds("ids")]
	public class StacksTiposDeAgencias
	{
		// Token: 0x0400049D RID: 1181
		public static readonly string incomeChangeMany = "AgencyIncomeChangeMany";

		// Token: 0x0400049E RID: 1182
		public static readonly string incomeChangeFew = "AgencyIncomeChangeFew";

		// Token: 0x0400049F RID: 1183
		public static readonly string[] ids = new string[]
		{
			StacksTiposDeAgencias.incomeChangeMany,
			StacksTiposDeAgencias.incomeChangeFew
		};
	}
}
