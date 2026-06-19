using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A7 RID: 167
	[RequireComponent(typeof(LuzIntensidadModificable))]
	public sealed class SpotLightDeEntrevista : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00012CAB File Offset: 0x00010EAB
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeAnimationConstraints);
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00012CB4 File Offset: 0x00010EB4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_defaultRotation = base.transform.rotation;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00012CD0 File Offset: 0x00010ED0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			LuzIntensidadModificable component = base.GetComponent<LuzIntensidadModificable>();
			this.m_intensidadMod = component.modificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00012CFC File Offset: 0x00010EFC
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

		// Token: 0x06000377 RID: 887 RVA: 0x00012D18 File Offset: 0x00010F18
		public unsafe override void OnUpdateEvent1()
		{
			ConfiguracionDeLucesDeScena.User_Data user_Data = *Singleton<ConfiguracionDeLucesDeScena>.instance.current;
			this.m_intensidadMod.valor.valor = user_Data.indoorPrimariaIntensity;
			if (user_Data.spotMode == ConfiguracionDeLucesDeScena.ModoDeLuz.statica)
			{
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, this.m_defaultRotation, Time.deltaTime * this.rotationVelocity);
				return;
			}
			AnimatorCharacter animatorCharacter = TargetChar.current as AnimatorCharacter;
			if (animatorCharacter == null)
			{
				return;
			}
			Transform transform;
			switch (user_Data.spotModeFolloing)
			{
			case ConfiguracionDeLucesDeScena.ModoDeSeguimiento.face:
				transform = animatorCharacter.bones.head.transform;
				break;
			case ConfiguracionDeLucesDeScena.ModoDeSeguimiento.chest:
				transform = animatorCharacter.bones.chest.transform;
				break;
			case ConfiguracionDeLucesDeScena.ModoDeSeguimiento.hips:
				transform = animatorCharacter.bones.hips.transform;
				break;
			default:
				throw new ArgumentOutOfRangeException(user_Data.spotModeFolloing.ToString());
			}
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(transform.position - base.transform.position), Time.deltaTime * this.rotationVelocity);
		}

		// Token: 0x0400017A RID: 378
		public float rotationVelocity = 50f;

		// Token: 0x0400017B RID: 379
		private ModificadorDeFloat m_intensidadMod;

		// Token: 0x0400017C RID: 380
		private Quaternion m_defaultRotation;
	}
}
