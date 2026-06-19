using System;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A4 RID: 164
	public class PanelInfoCampaing : PanelBaseSingleModel<EntrevistaInfoCampaing>
	{
		// Token: 0x06000358 RID: 856 RVA: 0x000124F4 File Offset: 0x000106F4
		protected override void OnBinding()
		{
			base.OnBinding();
			SMAGameplayController instance = Singleton<SMAGameplayController>.instance;
			if (!instance.CampaingExiste())
			{
				Debug.LogError("se intento cargar panel de info campaña actual, pero no existe una campaña actual", this);
				base.Clear();
				return;
			}
			int currentIndexDePhasesDeCampaing = instance.GetCurrentIndexDePhasesDeCampaing();
			int cantidadMaximaDeNextPhasesDeCampaing = instance.GetCantidadMaximaDeNextPhasesDeCampaing();
			SMAGameplayController.CampaingType currentCampaingType = instance.GetCurrentCampaingType();
			int modelsCountInCurrentCampaing = instance.GetModelsCountInCurrentCampaing();
			int interviwedModelsCountInCurrentCampaing = instance.GetInterviwedModelsCountInCurrentCampaing();
			int num = cantidadMaximaDeNextPhasesDeCampaing - currentIndexDePhasesDeCampaing;
			this.m_model.info.campaing = TextoLocalizadoAttribute.Localizado<SMAGameplayController.CampaingType, DescripcionLocalizadoAttribute>(currentCampaingType, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura);
			this.m_model.info.models = string.Format("{0} out of {1} models has been interviewed.", interviwedModelsCountInCurrentCampaing, modelsCountInCurrentCampaing);
			if (num > 1)
			{
				this.m_model.info.phases = string.Format("Phase {0} of the campaign is underway, and there are a total of {1} more phases to come.", currentIndexDePhasesDeCampaing + 1, cantidadMaximaDeNextPhasesDeCampaing);
			}
			else if (num == 1)
			{
				this.m_model.info.phases = string.Format("Phase {0} of the campaign is underway, and there is one more phase to come.", currentIndexDePhasesDeCampaing + 1);
			}
			else
			{
				this.m_model.info.phases = string.Format("Phase {0} of the campaign is underway, and there will be no more phases after this.", currentIndexDePhasesDeCampaing + 1);
			}
			this.m_model.profile.profile = new MultipleValorElemento<string, bool>(Singleton<SimplifiedAutoRatings>.instance.autoRatingProfile.nombre, false);
			this.m_model.canGoNextPhase = num > 0;
			this.m_model.profile.onPortraitLoad += this.Profile_onPortraitLoad;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00012669 File Offset: 0x00010869
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_model.onGoNextPhase += this.M_model_onGoNextPhase;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00012688 File Offset: 0x00010888
		protected override void OnHided()
		{
			base.OnHided();
			this.m_model.onGoNextPhase -= this.M_model_onGoNextPhase;
			this.m_model.profile.onPortraitLoad -= this.Profile_onPortraitLoad;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000126C3 File Offset: 0x000108C3
		private void Profile_onPortraitLoad(string profileName, ref Texture2D image)
		{
			image = Singleton<SimplifiedAutoRatings>.instance.LoadProfilePictureFromMemory();
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000126D1 File Offset: 0x000108D1
		private void M_model_onGoNextPhase()
		{
			base.Clear();
			Singleton<SMAGameplayController>.instance.GoNextCampaingPhase();
		}
	}
}
