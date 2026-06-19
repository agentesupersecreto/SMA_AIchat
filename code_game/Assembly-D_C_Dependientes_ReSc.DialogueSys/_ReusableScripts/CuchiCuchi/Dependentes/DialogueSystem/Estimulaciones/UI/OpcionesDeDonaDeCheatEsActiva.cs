using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x0200005A RID: 90
	public sealed class OpcionesDeDonaDeCheatEsActiva : CustomMonobehaviour
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x0000DBAA File Offset: 0x0000BDAA
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_GenericOpcionDeTHSDona = base.GetComponent<GenericOpcionDeTHSDona>();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000DBBE File Offset: 0x0000BDBE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (Singleton<ConfiguracionGeneralDeCheats>.IsInScene)
			{
				this.Instance_changed(Singleton<ConfiguracionGeneralDeCheats>.instance);
				Singleton<ConfiguracionGeneralDeCheats>.instance.changed += this.Instance_changed;
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000DBEE File Offset: 0x0000BDEE
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<ConfiguracionGeneralDeCheats>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeCheats>.instance.changed -= this.Instance_changed;
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000DC14 File Offset: 0x0000BE14
		private void Instance_changed(ConfiguracionGeneralDeCheats obj)
		{
			if (this.m_GenericOpcionDeTHSDona)
			{
				this.m_GenericOpcionDeTHSDona.enabled = Singleton<ConfiguracionGeneralDeCheats>.instance.useCheatDialogueOptions;
			}
		}

		// Token: 0x0400011A RID: 282
		private GenericOpcionDeTHSDona m_GenericOpcionDeTHSDona;
	}
}
