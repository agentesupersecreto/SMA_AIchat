using System;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B0 RID: 688
	public abstract class ModificadorDeTouchingBlendingSound : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000F77 RID: 3959 RVA: 0x00046D38 File Offset: 0x00044F38
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Registrandor = base.GetComponent<IReproductorDeBlendingSonidoDeToques>();
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x00046D4C File Offset: 0x00044F4C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Registrandor.registrandoToqueExtraData += this.onRegistrandoExtraData;
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x00046D6B File Offset: 0x00044F6B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Registrandor != null)
			{
				this.m_Registrandor.registrandoToqueExtraData -= this.onRegistrandoExtraData;
			}
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x00046D93 File Offset: 0x00044F93
		private void onRegistrandoExtraData(EstimuloTactil toque, SonidoProductor other, SonidoBlendingExtraData extraData, object sender)
		{
			this.OnRegistrandoExtraData(toque, other, extraData, sender);
		}

		// Token: 0x06000F7B RID: 3963
		protected abstract void OnRegistrandoExtraData(EstimuloTactil toque, SonidoProductor other, SonidoBlendingExtraData extraData, object sender);

		// Token: 0x04000CD3 RID: 3283
		private IReproductorDeBlendingSonidoDeToques m_Registrandor;
	}
}
