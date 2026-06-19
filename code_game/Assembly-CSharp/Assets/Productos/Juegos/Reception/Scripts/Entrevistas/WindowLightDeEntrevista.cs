using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A8 RID: 168
	[RequireComponent(typeof(LuzIntensidadModificable))]
	public sealed class WindowLightDeEntrevista : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00012E57 File Offset: 0x00011057
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeAnimationConstraints);
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00012E60 File Offset: 0x00011060
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_ventanaRender == null)
			{
				throw new ArgumentNullException("m_ventanaRender", "m_ventanaRender null reference.");
			}
			this.m_original = this.m_ventanaRender.sharedMaterial;
			this.m_clone = Object.Instantiate<Material>(this.m_original);
			this.m_ventanaRender.sharedMaterial = this.m_clone;
			this.m_propBlock = new MaterialPropertyBlock();
			this.m_EmissiveIntensity = Shader.PropertyToID("_EmissiveIntensity");
			this.m_EmissiveColor = Shader.PropertyToID("_EmissiveColor");
			this.m_defaultEmissiveIntensity = this.m_clone.GetFloat(this.m_EmissiveIntensity);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00012F08 File Offset: 0x00011108
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			LuzIntensidadModificable component = base.GetComponent<LuzIntensidadModificable>();
			this.m_intensidadMod = component.modificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00012F34 File Offset: 0x00011134
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat intensidadMod = this.m_intensidadMod;
			if (intensidadMod != null)
			{
				intensidadMod.TryRemoverDeOwner(true);
			}
			this.m_lastMod = -1f;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00012F5B File Offset: 0x0001115B
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_ventanaRender != null)
			{
				this.m_ventanaRender.sharedMaterial = this.m_original;
			}
			Object.Destroy(this.m_clone);
			this.m_clone = null;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00012F98 File Offset: 0x00011198
		public unsafe override void OnUpdateEvent1()
		{
			ConfiguracionDeLucesDeScena.User_Data user_Data = *Singleton<ConfiguracionDeLucesDeScena>.instance.current;
			if (user_Data.sunIntensity != this.m_lastMod)
			{
				this.m_lastMod = user_Data.sunIntensity;
				this.m_intensidadMod.valor.valor = user_Data.sunIntensity;
				this.m_clone.SetFloat(this.m_EmissiveIntensity, this.m_defaultEmissiveIntensity * user_Data.sunIntensity);
				WindowLightDeEntrevista.UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(this.m_clone);
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00013010 File Offset: 0x00011210
		public static void UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(Material material)
		{
			if (material.HasProperty("_EmissiveColorLDR") && material.HasProperty("_EmissiveIntensity") && material.HasProperty("_EmissiveColor"))
			{
				Color color = material.GetColor("_EmissiveColorLDR");
				Color color2 = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
				material.SetColor("_EmissiveColor", color2 * material.GetFloat("_EmissiveIntensity"));
			}
		}

		// Token: 0x0400017D RID: 381
		private ModificadorDeFloat m_intensidadMod;

		// Token: 0x0400017E RID: 382
		[SerializeField]
		private MeshRenderer m_ventanaRender;

		// Token: 0x0400017F RID: 383
		private Material m_original;

		// Token: 0x04000180 RID: 384
		private Material m_clone;

		// Token: 0x04000181 RID: 385
		private MaterialPropertyBlock m_propBlock;

		// Token: 0x04000182 RID: 386
		private float m_defaultEmissiveIntensity;

		// Token: 0x04000183 RID: 387
		private int m_EmissiveIntensity;

		// Token: 0x04000184 RID: 388
		private int m_EmissiveColor;

		// Token: 0x04000185 RID: 389
		private float m_lastMod = -1f;
	}
}
