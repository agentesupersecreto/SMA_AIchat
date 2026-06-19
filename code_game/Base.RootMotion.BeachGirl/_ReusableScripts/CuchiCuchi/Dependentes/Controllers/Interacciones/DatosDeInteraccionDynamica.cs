using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D2 RID: 210
	public abstract class DatosDeInteraccionDynamica : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600079F RID: 1951 RVA: 0x00024F24 File Offset: 0x00023124
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.interaccion == null)
			{
				throw new ArgumentNullException("interaccion", "interaccion null reference.");
			}
			if (!this.interaccion.transform.IsChildOf(base.transform))
			{
				throw new InvalidOperationException();
			}
			this.interaccion.addedTo += this.OnAdded;
			this.interaccion.removedFrom += this.OnRemoved;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00024FA4 File Offset: 0x000231A4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.interaccion != null)
			{
				this.interaccion.addedTo -= this.OnAdded;
				this.interaccion.removedFrom -= this.OnRemoved;
			}
		}

		// Token: 0x060007A1 RID: 1953
		protected abstract void OnAdded(Interaccion arg1, IInteraccionesDeCharacter arg2);

		// Token: 0x060007A2 RID: 1954
		protected abstract void OnRemoved(Interaccion arg1, IInteraccionesDeCharacter arg2);

		// Token: 0x04000530 RID: 1328
		public int interaccionID;

		// Token: 0x04000531 RID: 1329
		public Interaccion interaccion;
	}
}
