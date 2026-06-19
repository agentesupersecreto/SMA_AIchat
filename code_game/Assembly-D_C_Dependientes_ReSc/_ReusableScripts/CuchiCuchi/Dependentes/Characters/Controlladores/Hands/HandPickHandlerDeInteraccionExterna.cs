using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200024E RID: 590
	public abstract class HandPickHandlerDeInteraccionExterna : HandPickHandlerBase
	{
		// Token: 0x06000F9E RID: 3998 RVA: 0x00045B20 File Offset: 0x00043D20
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interaccion = base.GetComponentInParent<Interaccion>();
			this.m_interaccion.addedTo += this.M_interaccion_addedTo;
			this.m_interaccion.removingFrom += this.M_interaccion_removingFrom;
			this.m_interaccion.removedFrom += this.M_interaccion_removedFrom;
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x00045B84 File Offset: 0x00043D84
		private void M_interaccion_addedTo(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			this.OnAddedToUser(arg2);
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x00045B8D File Offset: 0x00043D8D
		private void M_interaccion_removingFrom(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			this.OnRemovingFromUser(arg2);
			if (this.m_interaccion.ejecutandose)
			{
				this.m_interaccion.Detener(false);
			}
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x00045BAF File Offset: 0x00043DAF
		private void M_interaccion_removedFrom(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			this.OnRemovedFromUser(arg2);
		}

		// Token: 0x06000FA2 RID: 4002
		protected abstract void OnAddedToUser(IInteraccionesDeCharacter character);

		// Token: 0x06000FA3 RID: 4003
		protected abstract void OnRemovingFromUser(IInteraccionesDeCharacter character);

		// Token: 0x06000FA4 RID: 4004
		protected abstract void OnRemovedFromUser(IInteraccionesDeCharacter character);

		// Token: 0x04000AD9 RID: 2777
		protected Interaccion m_interaccion;
	}
}
