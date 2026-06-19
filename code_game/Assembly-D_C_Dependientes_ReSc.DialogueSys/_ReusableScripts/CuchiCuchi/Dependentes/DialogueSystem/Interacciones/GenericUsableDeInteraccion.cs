using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones
{
	// Token: 0x02000040 RID: 64
	[RequireComponent(typeof(GenericUsable))]
	public class GenericUsableDeInteraccion : CustomMonobehaviour
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x0000933F File Offset: 0x0000753F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_GenericUsable = base.GetComponent<GenericUsable>();
			this.m_interaccion = base.GetComponentInParent<Interaccion>();
			if (this.m_interaccion == null)
			{
				throw new ArgumentNullException("m_interaccion", "m_interaccion null reference.");
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00009380 File Offset: 0x00007580
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_interaccion.comenzada += this.M_interaccion_comenzada;
			this.m_interaccion.terminada += this.M_interaccion_terminada;
			this.m_GenericUsable.onUsado += this.M_GenericUsable_onUsado;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000093D8 File Offset: 0x000075D8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_interaccion.comenzada -= this.M_interaccion_comenzada;
			this.m_interaccion.terminada -= this.M_interaccion_terminada;
			this.m_GenericUsable.onUsado -= this.M_GenericUsable_onUsado;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00009431 File Offset: 0x00007631
		private void M_interaccion_terminada(Interaccion obj)
		{
			this.m_GenericUsable.puedeUsarse = true;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000943F File Offset: 0x0000763F
		private void M_interaccion_comenzada(Interaccion obj)
		{
			this.m_GenericUsable.puedeUsarse = false;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000944D File Offset: 0x0000764D
		private void M_GenericUsable_onUsado(Transform obj)
		{
			if (this.m_interaccion.owner != null)
			{
				this.m_interaccion.EjecutarMaxPrioridadTiempoIndefinido();
			}
		}

		// Token: 0x040000D7 RID: 215
		private GenericUsable m_GenericUsable;

		// Token: 0x040000D8 RID: 216
		private Interaccion m_interaccion;
	}
}
