using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000557 RID: 1367
	public abstract class BasePar
	{
		// Token: 0x06002145 RID: 8517 RVA: 0x0007BF99 File Offset: 0x0007A199
		public BasePar()
		{
			this.puntaje = 100f;
		}

		// Token: 0x04001595 RID: 5525
		[Range(0f, 100f)]
		public float puntaje = 100f;
	}
}
