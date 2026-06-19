using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A6 RID: 166
	[RequireComponent(typeof(LuzIntensidadModificable))]
	public sealed class SecondayLightDeEntrevista : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00012C1E File Offset: 0x00010E1E
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeAnimationConstraints);
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00012C28 File Offset: 0x00010E28
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			LuzIntensidadModificable component = base.GetComponent<LuzIntensidadModificable>();
			this.m_intensidadMod = component.modificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00012C54 File Offset: 0x00010E54
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat intensidadMod = this.m_intensidadMod;
			if (intensidadMod == null)
			{
				return;
			}
			intensidadMod.TryRemoverDeOwner(true);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00012C70 File Offset: 0x00010E70
		public unsafe override void OnUpdateEvent1()
		{
			ConfiguracionDeLucesDeScena.User_Data user_Data = *Singleton<ConfiguracionDeLucesDeScena>.instance.current;
			this.m_intensidadMod.valor.valor = user_Data.indoorSecondaryIntensity;
		}

		// Token: 0x04000179 RID: 377
		private ModificadorDeFloat m_intensidadMod;
	}
}
