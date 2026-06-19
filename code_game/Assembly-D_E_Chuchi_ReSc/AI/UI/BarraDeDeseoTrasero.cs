using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000366 RID: 870
	public class BarraDeDeseoTrasero : BarraDeDeseo
	{
		// Token: 0x06001302 RID: 4866 RVA: 0x00052394 File Offset: 0x00050594
		protected override float GetDeseoValor()
		{
			return this.m_deseos.valores.traseroModBySexThresholds;
		}
	}
}
