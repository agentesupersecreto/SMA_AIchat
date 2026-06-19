using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200001A RID: 26
	public sealed class LoadLenguaje : AplicableBehaviour
	{
		// Token: 0x060000ED RID: 237 RVA: 0x000054A5 File Offset: 0x000036A5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.LoadL();
			Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.justChanged += this.OnIdiomaJustChanged;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000054CE File Offset: 0x000036CE
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (Singleton<ConfiguracionGeneralDeIdioma>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.justChanged -= this.OnIdiomaJustChanged;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000054F9 File Offset: 0x000036F9
		private void OnIdiomaJustChanged(ConfiguracionGeneralDeIdioma.Config.Idioma config, string last, string current)
		{
			this.LoadL();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005504 File Offset: 0x00003704
		private void LoadL()
		{
			this.m_current = (Localization.Language = (DialogueManager.DisplaySettings.localizationSettings.language = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura));
			DialogueManager.DisplaySettings.localizationSettings.useSystemLanguage = false;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000554E File Offset: 0x0000374E
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Editor Update",
				playTimeVisible = false
			};
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005567 File Offset: 0x00003767
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.LoadL();
		}

		// Token: 0x0400006D RID: 109
		private string m_current;
	}
}
