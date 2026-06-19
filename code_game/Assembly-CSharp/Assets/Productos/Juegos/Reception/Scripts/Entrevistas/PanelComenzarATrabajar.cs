using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.General.UI;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Tiempo;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using TValleCustomClases;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A1 RID: 161
	public class PanelComenzarATrabajar : PanelBaseDualModel<EntrevistaComenzarSinConvocatoria, EntrevistaComenzarConConvocatoria>
	{
		// Token: 0x06000332 RID: 818 RVA: 0x000116C8 File Offset: 0x0000F8C8
		protected override object ObtenerModeloAUsar(bool esParaDibujar)
		{
			if (this.m_resting)
			{
				return null;
			}
			if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
			{
				return null;
			}
			SMAGameplayController instance = Singleton<SMAGameplayController>.instance;
			bool flag = instance.CampaingExiste();
			bool flag2 = MemoriaDeSMAModelosFemeninas.HiredNPCCount(GlobalSingletonV2<MemoriaJson>.instance) > 0;
			object obj;
			if (!flag)
			{
				obj = this.m_a;
			}
			else
			{
				obj = this.m_b;
			}
			if (esParaDibujar)
			{
				if (obj is IModeloConContratadas)
				{
					((IModeloConContratadas)obj).existenModelosContratadas = flag2;
				}
				if (flag)
				{
					int modelsCountInCurrentCampaing = instance.GetModelsCountInCurrentCampaing();
					int interviwedModelsCountInCurrentCampaing = instance.GetInterviwedModelsCountInCurrentCampaing();
					int currentIndexDePhasesDeCampaing = instance.GetCurrentIndexDePhasesDeCampaing();
					int cantidadMaximaDeNextPhasesDeCampaing = instance.GetCantidadMaximaDeNextPhasesDeCampaing();
					bool flag3 = interviwedModelsCountInCurrentCampaing < modelsCountInCurrentCampaing;
					bool flag4 = cantidadMaximaDeNextPhasesDeCampaing - currentIndexDePhasesDeCampaing > 0;
					if (!flag3)
					{
						if (flag4)
						{
							Singleton<MainCanvas>.instance.MostrartMsg("Phase Ended", "Please go to campaign info and click go next phase.", 10f, true, null, null, null);
						}
						else
						{
							Singleton<MainCanvas>.instance.MostrartMsg("Campaign Ended", "Please end the campaign and start a new one if you want to.", 10f, true, null, null, null);
						}
					}
					if (obj is IModeloConConvocatoria)
					{
						((IModeloConConvocatoria)obj).existenModelosPorEntrevistar = flag3;
					}
				}
			}
			return obj;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x000117E2 File Offset: 0x0000F9E2
		public override bool CanShow()
		{
			return !this.m_resting && base.CanShow();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000117F4 File Offset: 0x0000F9F4
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_showObjectives.valor.valor = true;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0001180D File Offset: 0x0000FA0D
		protected override void OnHided()
		{
			base.OnHided();
			this.m_showObjectives.valor.valor = false;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00011828 File Offset: 0x0000FA28
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_agencyInfoPanel == null)
			{
				throw new ArgumentNullException("m_agencyInfoPanel", "m_agencyInfoPanel null reference.");
			}
			if (this.m_PanelModelAssignments == null)
			{
				throw new ArgumentNullException("m_PanelModelAssignments", "m_PanelModelAssignments null reference.");
			}
			if (this.m_comenzarCampaingPanel == null)
			{
				throw new ArgumentNullException("m_comenzarCampaingPanel", "m_comenzarCampaingPanel null reference.");
			}
			if (this.m_infoCampaingPanel == null)
			{
				throw new ArgumentNullException("m_infoCampaingPanel", "m_infoCampaingPanel null reference.");
			}
			this.m_b.onCancelarConvocatoria += this.CancelCampaign;
			this.m_b.onShowCampaignInfo += this.ShowCampaignInfo;
			this.m_b.onStartWorking += this.StartWorking;
			EntrevistaComenzarSinConvocatoria a = this.m_a;
			a.isLastWorkSchedule = (Func<bool>)Delegate.Combine(a.isLastWorkSchedule, new Func<bool>(this.IsLastWorkSchedule));
			EntrevistaComenzarConConvocatoria b = this.m_b;
			b.isLastWorkSchedule = (Func<bool>)Delegate.Combine(b.isLastWorkSchedule, new Func<bool>(this.IsLastWorkSchedule));
			this.m_a.onStartRecruitment += this.StartReclutamiento;
			this.m_a.onRest += this.DoRest;
			this.m_b.onRest += this.DoRest;
			this.m_a.onSaving += this.DoSave;
			this.m_b.onSaving += this.DoSave;
			this.m_a.onCheckAgencyInfo += this.ShowAgencyInfo;
			this.m_b.onCheckAgencyInfo += this.ShowAgencyInfo;
			this.m_a.onCheckModelAssignments += this.ShowModelAssignments;
			this.m_b.onCheckModelAssignments += this.ShowModelAssignments;
			this.m_a.onDisplayHired += this.ShowHired;
			this.m_b.onDisplayHired += this.ShowHired;
			this.m_a.onShowMyInfo += this.ShowMyInfo;
			this.m_b.onShowMyInfo += this.ShowMyInfo;
			this.m_a.onImport += this.Import;
			this.m_b.onImport += this.Import;
			this.m_showObjectives = Singleton<GameplayObjectives>.instance.showPanel.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00011AB5 File Offset: 0x0000FCB5
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool showObjectives = this.m_showObjectives;
			if (showObjectives == null)
			{
				return;
			}
			showObjectives.TryRemoverDeOwner(true);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00011AD0 File Offset: 0x0000FCD0
		private void StartWorking()
		{
			if (!DialogueManager.IsConversationActive)
			{
				CurrentWorkingModelsPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarCurrentModelsInCampaingPortraitsDialog();
				diag.GetComponentNotNull<CurrentModelsInCampaingPortraitsGetter>();
				diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.onPortraitClicked += delegate(string npcID)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
					PlayerPrefs.SetInt("SelectedModelToInterviewMode", 0);
					PlayerPrefs.SetString("SelectedModelToInterview", npcID);
					Type type = GetLoaderDeNivelDeOficina.Interviewing(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
					Singleton<ActividadesManager>.instance.StartActividad("Entrevista&Calificacion", type, null, null, true);
				};
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00011B6C File Offset: 0x0000FD6C
		private void Import()
		{
			if (!DialogueManager.IsConversationActive)
			{
				CurrentWorkingModelsPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarCurrentModelsInCampaingPortraitsDialog();
				diag.GetComponentNotNull<CurrentModelsOnDiskNotInMemoryPortraitsGetter>();
				diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.onPortraitClicked += delegate(string npcNombre)
				{
					MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
					CharacterWallet characterWallet;
					if (current == null)
					{
						characterWallet = null;
					}
					else
					{
						Character character = current.character;
						characterWallet = ((character != null) ? character.GetComponentEnRoot<CharacterWallet>() : null);
					}
					CharacterWallet characterWallet2 = characterWallet;
					if (((characterWallet2 != null) ? new float?(characterWallet2.Current("fiat")) : null).GetValueOrDefault() < 200f)
					{
						Singleton<MainCanvas>.instance.MostrartMsg("", "Insufficient Funds", 1f, false, null, null, null);
						return;
					}
					if (characterWallet2 != null)
					{
						characterWallet2.Change("fiat", -200f, "Hospitality Costs");
					}
					this.Hide();
					Singleton<ModalWindow>.instance.Clear(diag);
					PlayerPrefs.SetInt("SelectedModelToInterviewMode", 1);
					PlayerPrefs.SetString("SelectedModelToInterview", npcNombre);
					Type type = GetLoaderDeNivelDeOficina.Interviewing(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
					Singleton<ActividadesManager>.instance.StartActividad("Entrevista&Calificacion", type, null, null, true);
				};
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00011C0C File Offset: 0x0000FE0C
		private void StartReclutamiento()
		{
			if (!DialogueManager.IsConversationActive && this.m_comenzarCampaingPanel != null && !this.m_comenzarCampaingPanel.isShowing)
			{
				base.Clear();
				this.m_comenzarCampaingPanel.CrearYDibujar(null);
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00011C42 File Offset: 0x0000FE42
		private void ShowCampaignInfo()
		{
			if (!DialogueManager.IsConversationActive && this.m_infoCampaingPanel != null && !this.m_infoCampaingPanel.isShowing)
			{
				base.Clear();
				this.m_infoCampaingPanel.CrearYDibujar(null);
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00011C78 File Offset: 0x0000FE78
		private void CancelCampaign()
		{
			base.Clear();
			Singleton<SMAGameplayController>.instance.EndCampaing();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00011C8C File Offset: 0x0000FE8C
		private void ShowMyInfo()
		{
			if (!DialogueManager.IsConversationActive)
			{
				MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
				MaleChar maleChar = ((current != null) ? current.character : null) as MaleChar;
				if (maleChar != null && !Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing)
				{
					base.Hide();
					Singleton<PanelCharacterCompleteInfoGetter>.instance.CrearYDibujar(maleChar);
				}
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00011CE0 File Offset: 0x0000FEE0
		private bool IsLastWorkSchedule()
		{
			if (!Singleton<HorariosNormalesDeEntrevistas>.IsInScene)
			{
				throw new InvalidOperationException("Se necesita singleton " + typeof(HorariosNormalesDeEntrevistas).Name);
			}
			EventoDiarioHorario eventoDiarioHorario = Singleton<HorariosNormalesDeEntrevistas>.instance.ObtenerCurrentEntrevistaEvento();
			if (eventoDiarioHorario == null)
			{
				throw new InvalidOperationException("Solo se puede usar el panel del pc en un evento de entrevista");
			}
			TimeOfDay timeOfDay = eventoDiarioHorario.StartDateTime.GetTimeOfDay();
			if (timeOfDay == TimeOfDay.morning)
			{
				return false;
			}
			if (timeOfDay != TimeOfDay.afternoon)
			{
				throw new ArgumentOutOfRangeException(timeOfDay.ToString());
			}
			return true;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00011D58 File Offset: 0x0000FF58
		private void DoSave()
		{
			if (this.m_saveCoolDown.isOn)
			{
				return;
			}
			GlobalSingletonV2<MemoriaJson>.instance.SaveToDiskDefaultFile();
			this.m_saveCoolDown.ApplyNext(1f);
			TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
			temporalInfoDialog.duration = 0.5f;
			temporalInfoDialog.info.text = "Saved...";
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00011DB4 File Offset: 0x0000FFB4
		private void DoRest()
		{
			base.ActualizarValoresDeModelo();
			this.m_resting = true;
			base.Hide();
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00011DF2 File Offset: 0x0000FFF2
		private void ShowAgencyInfo()
		{
			if (!DialogueManager.IsConversationActive && this.m_agencyInfoPanel != null && !this.m_agencyInfoPanel.isShowing)
			{
				base.Hide();
				this.m_agencyInfoPanel.CrearYDibujar(null);
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00011E28 File Offset: 0x00010028
		private void ShowModelAssignments()
		{
			if (!DialogueManager.IsConversationActive && this.m_PanelModelAssignments != null && !this.m_PanelModelAssignments.isShowing)
			{
				base.Hide();
				this.m_PanelModelAssignments.CrearYDibujar(null);
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00011E60 File Offset: 0x00010060
		private void ShowHired()
		{
			if (!DialogueManager.IsConversationActive)
			{
				CurrentWorkingModelsPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarCurrentWorkingModelsPortraitsDialog();
				diag.GetComponentNotNull<CurrentWorkingModelsPortraitsGetter>();
				diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.onPortraitClicked += delegate(string npcID)
				{
					this.Hide();
					Singleton<ModalWindow>.instance.Clear(diag);
					PlayerPrefs.SetString("SelectedModelToMeet", npcID);
					Type type = GetLoaderDeNivelDeOficina.Meeting(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
					Singleton<ActividadesManager>.instance.StartActividad("MeetingInOffice", type, null, null, true);
				};
			}
		}

		// Token: 0x0400016C RID: 364
		[SerializeField]
		private PanelInfoOwnAgencia m_agencyInfoPanel;

		// Token: 0x0400016D RID: 365
		[SerializeField]
		private PanelModelAssignmentsLoader m_PanelModelAssignments;

		// Token: 0x0400016E RID: 366
		[SerializeField]
		private PanelComenzarCampaing m_comenzarCampaingPanel;

		// Token: 0x0400016F RID: 367
		[SerializeField]
		private PanelInfoCampaing m_infoCampaingPanel;

		// Token: 0x04000170 RID: 368
		private CoolDown m_saveCoolDown = new CoolDown();

		// Token: 0x04000171 RID: 369
		public bool forceNingunaHeroina;

		// Token: 0x04000172 RID: 370
		[Space]
		[SerializeField]
		private bool m_resting;

		// Token: 0x04000173 RID: 371
		private ModificadorDeBool m_showObjectives;
	}
}
