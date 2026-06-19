using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Utilidades
{
	// Token: 0x020000F1 RID: 241
	[RequireComponent(typeof(Interaccion))]
	public abstract class TransferirScalaToPivot : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000918 RID: 2328 RVA: 0x000296A2 File Offset: 0x000278A2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x000296B6 File Offset: 0x000278B6
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.comenzada += this.M_Interaccion_comenzada;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x000296D5 File Offset: 0x000278D5
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_Interaccion.comenzada -= this.M_Interaccion_comenzada;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x000296F8 File Offset: 0x000278F8
		private void M_Interaccion_comenzada(Interaccion obj)
		{
			if (this.pivot == null)
			{
				throw new ArgumentNullException("root", "root null reference.");
			}
			if (obj.user == null)
			{
				throw new ArgumentNullException("obj.user", "obj.user null reference.");
			}
			Transform transform = this.ObtenerTarget(obj);
			if (transform == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			float num = this.pivot.parent.lossyScale.Escala();
			float num2 = transform.lossyScale.Escala();
			this.pivot.localScale = Vector3.one * (num2 / num);
		}

		// Token: 0x0600091C RID: 2332
		protected abstract Transform ObtenerTarget(Interaccion obj);

		// Token: 0x040005B1 RID: 1457
		public Transform pivot;

		// Token: 0x040005B2 RID: 1458
		private Interaccion m_Interaccion;
	}
}
