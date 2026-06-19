using System;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.TargetsDynamicos
{
	// Token: 0x0200003E RID: 62
	public abstract class TargetDynamicoDeInteracionBase : CustomMonobehaviour
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x0000DBFF File Offset: 0x0000BDFF
		public void Actualizar(ICharacter para)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (para == null)
			{
				Debug.Log("No se pueden calcular correctamente los target dinamicos sin una referencia de character", this);
			}
			this.actualizar(para);
		}

		// Token: 0x060002A4 RID: 676
		public abstract void ResetTarget();

		// Token: 0x060002A5 RID: 677
		protected abstract void actualizar(ICharacter para);
	}
}
