using System;
using Assets._ReusableScripts.CuchiCuchi.Ropa;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001BC RID: 444
	public class EstetoscopioChangeStateOnInteractionPause : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000A9F RID: 2719 RVA: 0x00034A70 File Offset: 0x00032C70
		public void OnPause()
		{
			EstetoscopioPiel.Estado estado = this.piel.estado;
			if (estado == EstetoscopioPiel.Estado.toNeck)
			{
				this.piel.estado = EstetoscopioPiel.Estado.toEars;
				return;
			}
			if (estado != EstetoscopioPiel.Estado.toEars)
			{
				throw new ArgumentOutOfRangeException(this.piel.estado.ToString());
			}
			this.piel.estado = EstetoscopioPiel.Estado.toNeck;
		}

		// Token: 0x04000802 RID: 2050
		public EstetoscopioPiel piel;
	}
}
