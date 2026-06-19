using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A5 RID: 165
	[RequireComponent(typeof(InteractionObject))]
	public abstract class InteraccionObjectComienzaTerminaCallBacks : InteraccionObjectCallBacks
	{
		// Token: 0x1400005C RID: 92
		// (add) Token: 0x06000660 RID: 1632 RVA: 0x0001F26C File Offset: 0x0001D46C
		// (remove) Token: 0x06000661 RID: 1633 RVA: 0x0001F2A4 File Offset: 0x0001D4A4
		public event Action<InteraccionObjectComienzaTerminaCallBacks> comenzada;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06000662 RID: 1634 RVA: 0x0001F2DC File Offset: 0x0001D4DC
		// (remove) Token: 0x06000663 RID: 1635 RVA: 0x0001F314 File Offset: 0x0001D514
		public event Action<InteraccionObjectComienzaTerminaCallBacks> terminada;

		// Token: 0x06000664 RID: 1636 RVA: 0x0001F349 File Offset: 0x0001D549
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Termina();
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001F358 File Offset: 0x0001D558
		public void Comienza()
		{
			if (this.m_flagWaitingToEnd)
			{
				this.Termina();
			}
			if (!base.enabled)
			{
				return;
			}
			this.m_flagWaitingToEnd = true;
			this.OnComienza();
			Action<InteraccionObjectComienzaTerminaCallBacks> action = this.comenzada;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001F38F File Offset: 0x0001D58F
		public void Termina()
		{
			if (!this.m_flagWaitingToEnd)
			{
				return;
			}
			this.m_flagWaitingToEnd = false;
			this.OnTermina();
			Action<InteraccionObjectComienzaTerminaCallBacks> action = this.terminada;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000667 RID: 1639
		protected abstract void OnComienza();

		// Token: 0x06000668 RID: 1640
		protected abstract void OnTermina();

		// Token: 0x06000669 RID: 1641 RVA: 0x0001F3B8 File Offset: 0x0001D5B8
		protected override void SetCallBacks()
		{
			float num = base.CurrentInteractionObjectDuracion();
			base.SetCallBack(new Action(this.Comienza), num * this.comienzaTime);
			base.SetCallBack(new Action(this.Termina), num * this.terminaTime);
		}

		// Token: 0x04000462 RID: 1122
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagWaitingToEnd;

		// Token: 0x04000463 RID: 1123
		[Range(0f, 1f)]
		public float comienzaTime = 0.3f;

		// Token: 0x04000464 RID: 1124
		[Range(0f, 1f)]
		public float terminaTime = 0.7f;
	}
}
