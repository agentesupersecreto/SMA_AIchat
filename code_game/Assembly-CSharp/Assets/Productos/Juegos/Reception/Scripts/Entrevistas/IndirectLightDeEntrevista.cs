using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x0200009F RID: 159
	[RequireComponent(typeof(Volume))]
	public sealed class IndirectLightDeEntrevista : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00011441 File Offset: 0x0000F641
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeAnimationConstraints);
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0001144C File Offset: 0x0000F64C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_volume = base.GetComponent<Volume>();
			this.LoadComponent<IndirectLightingController>(this.m_volume, ref this.m_IndirectLightingController);
			this.m_defaultDiffuseValue = this.m_IndirectLightingController.indirectDiffuseLightingMultiplier.value;
			this.m_defaultReflectionValue = this.m_IndirectLightingController.reflectionLightingMultiplier.value;
			this.m_defaultReflectionPlanarValue = this.m_IndirectLightingController.reflectionProbeIntensityMultiplier.value;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000114BF File Offset: 0x0000F6BF
		private void LoadComponent<TComp>(Volume volume, ref TComp componente) where TComp : VolumeComponent
		{
			if (!volume.profile.TryGet<TComp>(out componente))
			{
				Debug.LogError("No se encontro componente de volumen: " + typeof(TComp).Name, this);
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x000114F0 File Offset: 0x0000F6F0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_IndirectLightingController.indirectDiffuseLightingMultiplier.value = this.m_defaultDiffuseValue;
			this.m_IndirectLightingController.reflectionLightingMultiplier.value = this.m_defaultReflectionValue;
			this.m_IndirectLightingController.reflectionProbeIntensityMultiplier.value = this.m_defaultReflectionPlanarValue;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00011548 File Offset: 0x0000F748
		public override void OnUpdateEvent1()
		{
			if (!this.m_IndirectLightingController.indirectDiffuseLightingMultiplier.overrideState)
			{
				this.m_IndirectLightingController.indirectDiffuseLightingMultiplier.overrideState = true;
			}
			if (!this.m_IndirectLightingController.reflectionLightingMultiplier.overrideState)
			{
				this.m_IndirectLightingController.reflectionLightingMultiplier.overrideState = true;
			}
			if (!this.m_IndirectLightingController.reflectionProbeIntensityMultiplier.overrideState)
			{
				this.m_IndirectLightingController.reflectionProbeIntensityMultiplier.overrideState = true;
			}
			Actividad current = Singleton<ActividadesManager>.instance.current;
			if (((current != null) ? new bool?(current.usesCustomLightingByUser) : null).GetValueOrDefault())
			{
				float sunIntensity = Singleton<ConfiguracionDeLucesDeScena>.instance.current.sunIntensity;
				this.m_IndirectLightingController.indirectDiffuseLightingMultiplier.value = this.m_defaultDiffuseValue * sunIntensity;
				this.m_IndirectLightingController.reflectionLightingMultiplier.value = 1f;
				this.m_IndirectLightingController.reflectionProbeIntensityMultiplier.value = ((sunIntensity <= 1f) ? (this.m_defaultReflectionPlanarValue * Mathf.Lerp(1f, sunIntensity, 0.95f)) : (this.m_defaultReflectionPlanarValue * Mathf.Lerp(1f, sunIntensity, 0.05f)));
				return;
			}
			this.m_IndirectLightingController.indirectDiffuseLightingMultiplier.value = this.m_defaultDiffuseValue;
			this.m_IndirectLightingController.reflectionLightingMultiplier.value = this.m_defaultReflectionValue;
			this.m_IndirectLightingController.reflectionProbeIntensityMultiplier.value = this.m_defaultReflectionPlanarValue;
		}

		// Token: 0x04000167 RID: 359
		private Volume m_volume;

		// Token: 0x04000168 RID: 360
		private IndirectLightingController m_IndirectLightingController;

		// Token: 0x04000169 RID: 361
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultDiffuseValue;

		// Token: 0x0400016A RID: 362
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultReflectionValue;

		// Token: 0x0400016B RID: 363
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultReflectionPlanarValue;
	}
}
