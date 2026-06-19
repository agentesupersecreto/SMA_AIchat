using System;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A2 RID: 162
	public class PanelComenzarCampaing : PanelBaseSingleModel<EntrevistaStartCampaing>
	{
		// Token: 0x06000345 RID: 837 RVA: 0x00011F14 File Offset: 0x00010114
		protected override void OnBinding()
		{
			base.OnBinding();
			EntrevistaStartCampaingInfo info = this.m_model.info;
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			float? num;
			if (current == null)
			{
				num = null;
			}
			else
			{
				Character character = current.character;
				if (character == null)
				{
					num = null;
				}
				else
				{
					CharacterWallet componentEnRoot = character.GetComponentEnRoot<CharacterWallet>();
					num = ((componentEnRoot != null) ? new float?(componentEnRoot.Current("fiat")) : null);
				}
			}
			float? num2 = num;
			info.currentMoney = num2.GetValueOrDefault();
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00011F8C File Offset: 0x0001018C
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_model.onCancel += this.M_model_onCancel;
			this.m_model.onStart += this.M_model_onStart;
			this.m_model.profile.onNew += this.Profile_onNew;
			this.m_model.profile.onCambiar += this.Profile_onCambiar;
			this.m_model.profile.onEditar += this.Profile_onEditar;
			this.m_model.info.onNoEnoughMoney += this.Info_onNoEnoughMoney;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00012040 File Offset: 0x00010240
		protected override void OnHided()
		{
			base.OnHided();
			this.m_model.onCancel -= this.M_model_onCancel;
			this.m_model.onStart -= this.M_model_onStart;
			this.m_model.profile.onNew -= this.Profile_onNew;
			this.m_model.profile.onCambiar -= this.Profile_onCambiar;
			this.m_model.profile.onEditar -= this.Profile_onEditar;
			this.m_model.info.onNoEnoughMoney -= this.Info_onNoEnoughMoney;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000120F1 File Offset: 0x000102F1
		private void M_model_onCancel()
		{
			base.Clear();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000120F9 File Offset: 0x000102F9
		private void Profile_onEditar(GrupoProfileIndependiente obj)
		{
			base.Hide();
			Singleton<SimplifiedAutoRatings>.instance.OpenEditor(obj.portraitDeGrupo.nombreDeProtrait).onHiddenBase += this.EditorPanel_onHiddenBase;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00012127 File Offset: 0x00010327
		private void EditorPanel_onHiddenBase(PanelBase obj)
		{
			obj.onHiddenBase -= this.EditorPanel_onHiddenBase;
			base.Show();
			this.LoadPerfil();
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00012148 File Offset: 0x00010348
		private void Profile_onCambiar(GrupoProfileIndependiente obj)
		{
			InterpretationPortraitsDialog portraits = Singleton<ModalWindow>.instance.MostrarInterpretationProfilePortraitsDialog();
			portraits.panelDePortraits.portraitsModel.canceling += delegate(InterpretationPortraitsModel model)
			{
				Singleton<ModalWindow>.instance.Clear(portraits);
			};
			portraits.panelDePortraits.portraitsModel.staring += delegate(InterpretationPortraitsModel model)
			{
				Singleton<ModalWindow>.instance.Clear(portraits);
				if (model.disponibles.ContieneIndex(model.currentSelected))
				{
					MultipleValorElemento<string, bool> multipleValorElemento = model.disponibles[model.currentSelected];
					this.m_model.profile.profile.item1 = multipleValorElemento.item1;
					this.LoadPerfil();
				}
			};
		}

		// Token: 0x0600034C RID: 844 RVA: 0x000121B4 File Offset: 0x000103B4
		private void Profile_onNew(GrupoProfileIndependiente obj)
		{
			base.Hide();
			Singleton<SimplifiedAutoRatings>.instance.OpenEditor(null).onHiddenBase += this.EditorPanel_onHiddenBase;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000121D8 File Offset: 0x000103D8
		private void M_model_onStart()
		{
			if (!this.m_model.IsValid())
			{
				throw new InvalidOperationException();
			}
			SMAGameplayController.CampaingType campaingType;
			if (this.m_model.info.profesionals)
			{
				campaingType = SMAGameplayController.CampaingType.professional;
			}
			else if (this.m_model.info.amateur)
			{
				campaingType = SMAGameplayController.CampaingType.amateur;
			}
			else
			{
				if (!this.m_model.info.allPublic)
				{
					throw new InvalidOperationException();
				}
				campaingType = SMAGameplayController.CampaingType.free;
			}
			string item = this.m_model.profile.profile.item1;
			float costMoney = this.m_model.info.costMoney;
			base.Clear();
			Singleton<SMAGameplayController>.instance.StartCampaing(campaingType, item, costMoney);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0001227C File Offset: 0x0001047C
		private void Info_onNoEnoughMoney()
		{
			Singleton<MainCanvas>.instance.MostrartMsg("", "Insufficient Funds", 1f, false, null, null, null);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000122B6 File Offset: 0x000104B6
		protected override void OnCleared()
		{
			base.OnCleared();
			this.m_model = new EntrevistaStartCampaing();
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000122CC File Offset: 0x000104CC
		private void LoadPerfil()
		{
			try
			{
				GrupoProfile grupoProfile = (GrupoProfileIndependiente)((IUIPanel)this.m_model.panel.elementoPorModelo["profile"]).elementoPorModelo["profile"];
				if (this.m_model.profile.profile.item1 == null)
				{
					this.m_model.profile.profile.item1 = string.Empty;
				}
				grupoProfile.SetValor(this.m_model.profile.profile.item1, false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				Singleton<ModalWindow>.instance.AcumularErrores(ex.Message, null);
			}
		}
	}
}
