using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000365 RID: 869
	public class BarraDeDeseoEntrepierna : BarraDeDeseo
	{
		// Token: 0x06001300 RID: 4864 RVA: 0x00052382 File Offset: 0x00050582
		protected override float GetDeseoValor()
		{
			return this.m_deseos.valores.entrepiernaModBySexThresholds;
		}
	}
}
