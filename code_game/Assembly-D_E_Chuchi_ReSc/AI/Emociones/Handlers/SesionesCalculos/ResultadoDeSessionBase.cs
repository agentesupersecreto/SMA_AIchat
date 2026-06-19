using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004AD RID: 1197
	public abstract class ResultadoDeSessionBase
	{
		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06001C69 RID: 7273 RVA: 0x00070F83 File Offset: 0x0006F183
		public ResultadoDeSessionBase.Estado estado
		{
			get
			{
				return this.m_estado;
			}
		}

		// Token: 0x06001C6A RID: 7274 RVA: 0x00070F8B File Offset: 0x0006F18B
		protected virtual void Clear()
		{
			this.m_estado = ResultadoDeSessionBase.Estado.fuera;
		}

		// Token: 0x040013E1 RID: 5089
		[SerializeField]
		[ReadOnlyUI]
		protected ResultadoDeSessionBase.Estado m_estado;

		// Token: 0x020004AE RID: 1198
		public enum Estado
		{
			// Token: 0x040013E3 RID: 5091
			fuera,
			// Token: 0x040013E4 RID: 5092
			comenzando,
			// Token: 0x040013E5 RID: 5093
			activa,
			// Token: 0x040013E6 RID: 5094
			terminando
		}
	}
}
