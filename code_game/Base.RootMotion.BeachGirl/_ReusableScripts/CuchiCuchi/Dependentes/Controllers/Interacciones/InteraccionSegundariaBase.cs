using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D9 RID: 217
	public abstract class InteraccionSegundariaBase : Interaccion
	{
		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0002642A File Offset: 0x0002462A
		public sealed override int Tipo
		{
			get
			{
				return this.m_Tipo;
			}
		}

		// Token: 0x04000551 RID: 1361
		public bool followScalePose = true;

		// Token: 0x04000552 RID: 1362
		[SerializeField]
		private int m_Tipo = 1;
	}
}
