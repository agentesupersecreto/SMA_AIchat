using System;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles.UI
{
	// Token: 0x020000C9 RID: 201
	[Obsolete("use simplified version", true)]
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelProfilesDeGrupos : PanelBaseSingleModel<PortraitsDeGruposModel>
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x000186F2 File Offset: 0x000168F2
		public override bool CanShow()
		{
			return base.CanShow() && (!Singleton<ModalWindow>.IsInScene || !Singleton<ModalWindow>.instance.isShowing);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00018714 File Offset: 0x00016914
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_currentPanel = (AutoRatingProfilesDeGruposPanel)base.UIPanel;
			this.LoadPerfilesDeGrupos();
			this.m_model.onRemover += this.M_model_onRemover;
			this.m_model.onEditar += this.M_model_onEditar;
			this.m_model.onCambiar += this.M_model_onCambiar;
			this.m_currentPanel.onCreate += this.M_currentPanel_onCreate;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001879C File Offset: 0x0001699C
		protected override void OnClearing()
		{
			base.OnClearing();
			if (this.m_model != null)
			{
				this.m_model.onRemover -= this.M_model_onRemover;
				this.m_model.onEditar -= this.M_model_onEditar;
				this.m_model.onCambiar -= this.M_model_onCambiar;
			}
			if (this.m_currentPanel != null)
			{
				this.m_currentPanel.onCreate -= this.M_currentPanel_onCreate;
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00018824 File Offset: 0x00016A24
		public void LoadPerfilesDeGrupos()
		{
			AutoRatings instance = Singleton<AutoRatings>.instance;
			for (int i = 0; i < 10; i++)
			{
				this.LoadGrupo(instance.GetGrupo(i));
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00018854 File Offset: 0x00016A54
		private void LoadGrupo(AutoRatings.GrupoProfilePar grupo)
		{
			try
			{
				GrupoProfile grupo2 = this.m_currentPanel.GetGrupo(grupo.grupoIndex);
				if (grupo.IsValid())
				{
					Texture2D texture2D;
					byte[] array;
					SaveLoadProfilePortraits.Cargar(grupo.profile.nombre, out texture2D, out array);
					grupo2.DoLoad(grupo.profile.nombre, (!Singleton<AutoRatings>.instance.GrupoEsDesblokeado(grupo.grupoIndex)) ? GrupoProfile.LoadingMode.locked : GrupoProfile.LoadingMode.none, null);
				}
				else
				{
					grupo2.DoLoad(string.Empty, (!Singleton<AutoRatings>.instance.GrupoEsDesblokeado(grupo.grupoIndex)) ? GrupoProfile.LoadingMode.locked : GrupoProfile.LoadingMode.none, null);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				Singleton<ModalWindow>.instance.AcumularErrores(ex.Message, null);
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00018908 File Offset: 0x00016B08
		private void M_model_onCambiar(int grupoIndex, object grupo, object panel, PortraitsDeGruposModel sender)
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
					this.LoadPortraitFromDisk(grupoIndex, grupo, panel, sender, model);
				}
			};
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00018994 File Offset: 0x00016B94
		private void M_model_onEditar(int grupoIndex, object grupo, object panel, PortraitsDeGruposModel sender)
		{
			base.Hide();
			GrupoProfile grupo2 = this.m_currentPanel.GetGrupo(grupoIndex);
			Singleton<AutoRatings>.instance.OpenEditor(grupo2.portraitDeGrupo.nombreDeProtrait).onHiddenBase += this.EditorPanel_onHiddenBase;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000189DA File Offset: 0x00016BDA
		private void M_currentPanel_onCreate(object obj)
		{
			base.Hide();
			Singleton<AutoRatings>.instance.OpenEditor(null).onHiddenBase += this.EditorPanel_onHiddenBase;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x000189FE File Offset: 0x00016BFE
		private void EditorPanel_onHiddenBase(PanelBase obj)
		{
			obj.onHiddenBase -= this.EditorPanel_onHiddenBase;
			base.Show();
			this.LoadPerfilesDeGrupos();
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00018A1E File Offset: 0x00016C1E
		private void M_model_onRemover(int grupoIndex, object grupo, object panel, PortraitsDeGruposModel sender)
		{
			Singleton<AutoRatings>.instance.RemoveProfile(grupoIndex, true);
			this.m_currentPanel.GetGrupo(grupoIndex).DoLoad(string.Empty, (!Singleton<AutoRatings>.instance.GrupoEsDesblokeado(grupoIndex)) ? GrupoProfile.LoadingMode.locked : GrupoProfile.LoadingMode.none, null);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00018A54 File Offset: 0x00016C54
		private void LoadPortraitFromDisk(int grupoIndex, object grupo, object panel, PortraitsDeGruposModel sender, InterpretationPortraitsModel model)
		{
			MultipleValorElemento<string, bool> multipleValorElemento = model.disponibles[model.currentSelected];
			Texture2D texture2D;
			byte[] array;
			SaveLoadProfilePortraits.Cargar(multipleValorElemento.item1, out texture2D, out array);
			try
			{
				if (array == null || array.Length == 0)
				{
					ErrorDialog modal2 = Singleton<ModalWindow>.instance.MostrarErrorDialog();
					modal2.pregunta.text = "Invalid Portrait File";
					modal2.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(modal2);
					});
				}
				else
				{
					string @string = Encoding.UTF8.GetString(array);
					try
					{
						AutoRatingWraper autoRatingWraper = JsonUtility.FromJson<AutoRatingWraper>(@string);
						Singleton<AutoRatings>.instance.ChangeProfile(grupoIndex, autoRatingWraper.modo, multipleValorElemento.item1, ref autoRatingWraper.simple, ref autoRatingWraper.completa, true);
						this.m_currentPanel.GetGrupo(grupoIndex).DoLoad(multipleValorElemento.item1, (!Singleton<AutoRatings>.instance.GrupoEsDesblokeado(grupoIndex)) ? GrupoProfile.LoadingMode.locked : GrupoProfile.LoadingMode.none, null);
					}
					catch (Exception ex)
					{
						ErrorDialog modal = Singleton<ModalWindow>.instance.MostrarErrorDialog();
						modal.pregunta.text = "Invalid Portrait File: " + ex.Message;
						modal.aceptar.onClick.AddListener(delegate
						{
							Singleton<ModalWindow>.instance.Clear(modal);
						});
					}
				}
			}
			finally
			{
				Object.Destroy(texture2D);
			}
		}

		// Token: 0x0400023D RID: 573
		private AutoRatingProfilesDeGruposPanel m_currentPanel;
	}
}
