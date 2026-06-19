using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000364 RID: 868
	public class BarraDeDeseoBoca : BarraDeDeseo
	{
		// Token: 0x060012FE RID: 4862 RVA: 0x00052368 File Offset: 0x00050568
		protected override float GetDeseoValor()
		{
			return this.m_deseos.valores.labiosModBySexThresholds;
		}
	}
}
