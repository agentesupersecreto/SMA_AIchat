using System;
using System.Collections;
using Assets.Base.Genetica.Runtime.NPCs;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.UI;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x02000005 RID: 5
	[RequireComponent(typeof(GenericFlotanteUserPanel))]
	public class PanelDeEntrevistaCalificacion : AplicableBehaviour, IPanelOfModel
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002B04 File Offset: 0x00000D04
		private object CalcularModelObject()
		{
			if (this.resting)
			{
				return null;
			}
			if (this.calificando)
			{
				return this.ratingModel;
			}
			EntrevistaFemaleCharacterFromPoolOrMemOrDisk entrevistaFemaleCharacterFromPoolOrMemOrDisk = (EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running;
			EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
			EntrevistaConFemaleCharacter.FemalePresencia femalePresencia = entrevistaConFemaleCharacter.femalePresencia;
			if (femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.presente)
			{
				this.mainModel.femaleCharacterCanBeRated = entrevistaFemaleCharacterFromPoolOrMemOrDisk.femaleCharacterCanBeRated;
				return this.mainModel;
			}
			if (femalePresencia - EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorUserInteresado > 8)
			{
				throw new ArgumentOutOfRangeException(entrevistaConFemaleCharacter.femalePresencia.ToString());
			}
			if (Singleton<HorariosNormalesDeEntrevistas>.instance.EsUltimaEntrevistaDelDia())
			{
				this.mainGoneLateModel.femaleCharacterCanBeRated = entrevistaFemaleCharacterFromPoolOrMemOrDisk.femaleCharacterCanBeRated;
				return this.mainGoneLateModel;
			}
			this.mainGoneModel.femaleCharacterCanBeRated = entrevistaFemaleCharacterFromPoolOrMemOrDisk.femaleCharacterCanBeRated;
			return this.mainGoneModel;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002BC0 File Offset: 0x00000DC0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_agencyInfoPanel == null)
			{
				throw new ArgumentNullException("m_agencyInfoPanel", "m_agencyInfoPanel null reference.");
			}
			this.m_userPanel = base.GetComponent<GenericFlotanteUserPanel>();
			this.m_userPanel.disableCanvasOnHide = true;
			this.m_userPanel.enableCanvasOnShow = true;
			this.m_userPanel.hided += this.M_userPanel_hided;
			this.m_userPanel.showed += this.M_userPanel_showed;
			this.mainModel.onStartRating += this.MainModel_onStartRating;
			this.mainGoneModel.onStartRating += this.MainGoneModel_onStartRating;
			this.mainGoneLateModel.onStartRating += this.MainGoneLateModel_onStartRating;
			this.mainModel.onStartContacting += this.MainModel_onStartContacting;
			this.mainModel.onShowModelInfo += this.MainModel_onShowModelInfo;
			this.mainModel.onStartHiring += this.MainModel_onStartHiring;
			this.mainModel.onShowMyInfo += this.ShowMyInfo;
			this.mainModel.onDispatchHerClicked += this.MainModel_onDispatchHerClicked;
			this.ratingModel.onDoneClicked += this.OnCalificada;
			this.ratingModel.onConfirmarDone += this.OnConfirmarDone;
			this.ratingModel.onRedoAutoRating += this.OnRedoAutoRating;
			this.ratingModel.aparienciaFisica.onOverallChanging += this.AparienciaFisica_onOverallChanging;
			this.ratingModel.aparienciaFisica.onOverallChanged += this.AparienciaFisica_onOverallChanged;
			this.mainGoneModel.onShowMyInfo += this.ShowMyInfo;
			this.mainGoneLateModel.onShowMyInfo += this.ShowMyInfo;
			this.mainGoneModel.onResting += this.MainGoneModel_onResting;
			this.mainGoneLateModel.onGoingHome += this.MainGoneLateModel_onGoingHome;
			this.mainModel.confirmarDispatchHerDelegate = new Func<bool>(this.ConfirmarSinRaing);
			this.mainGoneModel.confirmarOnRestDelegate = new Func<bool>(this.ConfirmarSinRaing);
			this.mainGoneLateModel.confirmarGoHomeDelegate = new Func<bool>(this.ConfirmarSinRaing);
			this.m_AlwaysOnScreenGeneric = base.GetComponentInChildren<AlwaysOnScreenGeneric>(true);
			if (this.m_AlwaysOnScreenGeneric == null)
			{
				throw new ArgumentNullException("m_AlwaysOnScreenGeneric", "m_AlwaysOnScreenGeneric null reference.");
			}
			this.m_canvasDefaultPosition = this.m_AlwaysOnScreenGeneric.transform.position;
			this.mainModel.onCheckAgencyInfo += this.M_onCheckAgencyInfo;
			this.m_showObjectives = Singleton<GameplayObjectives>.instance.showPanel.ObtenerModificadorNotNull(this);
			base.SetYieldStart();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002E90 File Offset: 0x00001090
		private void ShowMyInfo()
		{
			if (!DialogueManager.IsConversationActive)
			{
				MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
				MaleChar maleChar = ((current != null) ? current.character : null) as MaleChar;
				if (maleChar != null && !Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing)
				{
					this.Hide();
					Singleton<PanelCharacterCompleteInfoGetter>.instance.CrearYDibujar(maleChar);
				}
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002EE1 File Offset: 0x000010E1
		private void M_onCheckAgencyInfo()
		{
			if (!DialogueManager.IsConversationActive && this.m_agencyInfoPanel != null && !this.m_agencyInfoPanel.isShowing)
			{
				this.Hide();
				this.m_agencyInfoPanel.CrearYDibujar(null);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002F18 File Offset: 0x00001118
		[Obsolete("ya no se necesita saber ningun grupo", true)]
		private string GetInfoTitleDelegate()
		{
			return "Group " + HorariosNormalesDeEntrevistasIDs.GetGrupoLetterFromEntrevistaID(((EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running).currentEvento.id).ToString();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002F50 File Offset: 0x00001150
		[Obsolete("ya no se necesita saber ningun grupo", true)]
		private string GetInfoNombreDelegate()
		{
			EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
			return "Model Name: <B>" + entrevistaConFemaleCharacter.currentFemaleCharacter.nombreCompleto + "</B>";
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002F84 File Offset: 0x00001184
		[Obsolete("ya no se necesita saber ningun grupo", true)]
		private string GetInfoLevelDelegate()
		{
			EntrevistaFemaleCharacterFromPoolOrMemOrDisk entrevistaFemaleCharacterFromPoolOrMemOrDisk = (EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running;
			return "Model Level: <B>" + (entrevistaFemaleCharacterFromPoolOrMemOrDisk.currentFemaleCharacterLvl + 1).ToString() + "</B>";
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002FBB File Offset: 0x000011BB
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (Actividad.running == null)
			{
				yield return null;
			}
			((EntrevistaConFemaleCharacter)Actividad.running).femalePresenciaChanged += this.Inst_femalePresenciaChanged;
			yield break;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002FCA File Offset: 0x000011CA
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				((EntrevistaConFemaleCharacter)Actividad.running).femalePresenciaChanged += this.Inst_femalePresenciaChanged;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002FF8 File Offset: 0x000011F8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = Actividad.running as EntrevistaConFemaleCharacter;
			if (entrevistaConFemaleCharacter != null)
			{
				entrevistaConFemaleCharacter.femalePresenciaChanged -= this.Inst_femalePresenciaChanged;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003032 File Offset: 0x00001232
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

		// Token: 0x0600002C RID: 44 RVA: 0x0000304D File Offset: 0x0000124D
		private bool ConfirmarSinRaing()
		{
			if (!((EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running).femaleCharacterCanBeRated)
			{
				return false;
			}
			if (!this.haSidoCalificado)
			{
				this.TryAutoRatingAModelo();
			}
			return !this.haSidoCalificado;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000307A File Offset: 0x0000127A
		private void AparienciaFisica_onOverallChanging(EstrevistaCalificacionAparienciaFisicaModelo obj)
		{
			this.ActualizarValoresDeModelo();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003082 File Offset: 0x00001282
		private void AparienciaFisica_onOverallChanged(EstrevistaCalificacionAparienciaFisicaModelo obj)
		{
			this.ActualizarValoresDePanel();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000308A File Offset: 0x0000128A
		private void MainModel_onStartRating(EstrevistaMainModelo obj)
		{
			this.StartRating();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003092 File Offset: 0x00001292
		private void MainGoneModel_onStartRating(EstrevistaMainGoneModelo obj)
		{
			this.StartRating();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000309A File Offset: 0x0000129A
		private void MainGoneLateModel_onStartRating(EstrevistaMainGoneLateModelo obj)
		{
			this.StartRating();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000030A4 File Offset: 0x000012A4
		private void MainModel_onStartContacting(EstrevistaMainModelo obj)
		{
			if (!DialogueManager.IsConversationActive)
			{
				EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
				if (((entrevistaConFemaleCharacter != null) ? entrevistaConFemaleCharacter.currentFemaleCharacter : null) != null && this.m_otrasAgenciasPanel != null && !this.m_otrasAgenciasPanel.panel.isShowing)
				{
					this.Hide();
					this.tryContactada = true;
					this.m_otrasAgenciasPanel.panel.CrearYDibujar(null);
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003114 File Offset: 0x00001314
		private void MainModel_onShowModelInfo(EstrevistaMainModelo obj)
		{
			if (!DialogueManager.IsConversationActive)
			{
				EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
				if (((entrevistaConFemaleCharacter != null) ? entrevistaConFemaleCharacter.currentFemaleCharacter : null) != null && !Singleton<CurriculumVitaePanelGetter>.instance.curriculumVitaePanel.isShowing)
				{
					this.Hide();
					Singleton<CurriculumVitaePanelGetter>.instance.curriculumVitaePanel.SetTarget((entrevistaConFemaleCharacter != null) ? entrevistaConFemaleCharacter.currentFemaleCharacter : null);
					Singleton<CurriculumVitaePanelGetter>.instance.curriculumVitaePanel.CrearYDibujar(null);
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003189 File Offset: 0x00001389
		private Texture2D GetPortrait()
		{
			SelfPortraitCamera componentInChildren = ((EntrevistaParaCalificarFemaleCharacterFromPool)Actividad.running).currentFemaleCharacter.GetComponentInChildren<SelfPortraitCamera>();
			if (componentInChildren == null)
			{
				return null;
			}
			return componentInChildren.TakeFemalePortrait();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000031AC File Offset: 0x000013AC
		private void MainModel_onStartHiring(EstrevistaMainModelo obj)
		{
			if (!DialogueManager.IsConversationActive)
			{
				EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
				if (((entrevistaConFemaleCharacter != null) ? entrevistaConFemaleCharacter.currentFemaleCharacter : null) != null)
				{
					this.Hide();
					SMAGameplayController instance = Singleton<SMAGameplayController>.instance;
					FemaleChar currentFemaleCharacter = entrevistaConFemaleCharacter.currentFemaleCharacter;
					string text = currentFemaleCharacter.ID_Unico.ToString();
					if (instance.IsHired(text))
					{
						ConfirmacionMiembros dialog2 = Singleton<ModalWindow>.instance.MostrarConfirmacion();
						dialog2.SetPreguntaText(currentFemaleCharacter.nombreCompleto + " is already hired.");
						dialog2.noMostrarOtraVezToggle.interactable = false;
						dialog2.cancelar.gameObject.SetActive(false);
						dialog2.aceptar.onClick.AddListener(delegate
						{
							Singleton<ModalWindow>.instance.Clear(dialog2);
						});
						return;
					}
					if (!instance.CanBeHired(text, false))
					{
						ConfirmacionMiembros dialog3 = Singleton<ModalWindow>.instance.MostrarConfirmacion();
						dialog3.SetPreguntaText("You can't hire any more models right now.");
						dialog3.noMostrarOtraVezToggle.interactable = false;
						dialog3.cancelar.gameObject.SetActive(false);
						dialog3.aceptar.onClick.AddListener(delegate
						{
							Singleton<ModalWindow>.instance.Clear(dialog3);
						});
						return;
					}
					if (!instance.VacantesDisponibles())
					{
						ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarConfirmacion();
						dialog.SetPreguntaText("Improve your office if you want to employ additional models; all you can do currently is refer them to other agencies and get a commission if they are approved.");
						dialog.noMostrarOtraVezToggle.interactable = false;
						dialog.cancelar.gameObject.SetActive(false);
						dialog.aceptar.onClick.AddListener(delegate
						{
							Singleton<ModalWindow>.instance.Clear(dialog);
						});
						return;
					}
					if (entrevistaConFemaleCharacter != null && entrevistaConFemaleCharacter.currentFemaleCharacterConversador.puedeConversar)
					{
						entrevistaConFemaleCharacter.currentFemaleCharacter.TrySerConversarzado(MainChar.current, this.m_conversationContratar);
						this.tryHired = true;
						this.Hide();
						Singleton<CurrentMainChar>.instance.camara.Ver(entrevistaConFemaleCharacter.currentFemaleCharacter.bones.head.posicionFinal);
						CharacterRotationMode componentInChildren = MainChar.current.GetComponentInChildren<CharacterRotationMode>();
						if (componentInChildren == null)
						{
							return;
						}
						componentInChildren.ForzarBodyRotationPor(2f);
					}
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003410 File Offset: 0x00001610
		private void StartRating()
		{
			this.m_AlwaysOnScreenGeneric.enabled = true;
			this.m_AlwaysOnScreenGeneric.config = this.calificandoConfig;
			if (!this.haSidoCalificado)
			{
				this.TryAutoRatingAModelo();
			}
			this.ActualizarValoresDeModelo();
			this.calificando = true;
			this.CrearYDibujar(null);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003460 File Offset: 0x00001660
		private bool TryAutoRatingAModelo()
		{
			EntrevistaFemaleCharacterFromPoolOrMemOrDisk entrevistaFemaleCharacterFromPoolOrMemOrDisk = (EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running;
			if (Singleton<SimplifiedAutoRatings>.instance.AutoRatingSeAplica() && entrevistaFemaleCharacterFromPoolOrMemOrDisk.femaleCharacterCanBeRated)
			{
				ISujetoIdentificableNpc sujetoIdentificableNpc = entrevistaFemaleCharacterFromPoolOrMemOrDisk.currentPiscinaManager.Obtener(entrevistaFemaleCharacterFromPoolOrMemOrDisk.currentFemaleCharacter.ID_Unico);
				this.ratingModel.aparienciaFisica.SetScore(sujetoIdentificableNpc.aparienciaFisica.conjuntoPorNombre);
				this.ratingModel.personalidad.SetScore(sujetoIdentificableNpc.personalidad.conjuntoPorNombre);
				this.haSidoCalificado = true;
				this.ActualizarValoresDePanel();
				return true;
			}
			return false;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000034EC File Offset: 0x000016EC
		private void MainModel_onDispatchHerClicked(EstrevistaMainModelo obj)
		{
			if (!DialogueManager.IsConversationActive && !string.IsNullOrWhiteSpace(this.m_conversationDespachar))
			{
				EntrevistaFemaleCharacterFromPoolOrMemOrDisk entrevistaFemaleCharacterFromPoolOrMemOrDisk = (EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running;
				if (entrevistaFemaleCharacterFromPoolOrMemOrDisk != null && entrevistaFemaleCharacterFromPoolOrMemOrDisk.currentFemaleCharacterConversador.puedeConversar)
				{
					entrevistaFemaleCharacterFromPoolOrMemOrDisk.currentFemaleCharacter.TrySerConversarzado(MainChar.current, this.m_conversationDespachar);
					this.tryDespachada = true;
					this.Hide();
					Singleton<CurrentMainChar>.instance.camara.Ver(entrevistaFemaleCharacterFromPoolOrMemOrDisk.currentFemaleCharacter.bones.head.posicionFinal);
					CharacterRotationMode componentInChildren = MainChar.current.GetComponentInChildren<CharacterRotationMode>();
					if (componentInChildren == null)
					{
						return;
					}
					componentInChildren.ForzarBodyRotationPor(2f);
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003595 File Offset: 0x00001795
		private void Inst_femalePresenciaChanged(EntrevistaConFemaleCharacter.FemalePresencia last, EntrevistaConFemaleCharacter.FemalePresencia current, EntrevistaConFemaleCharacter sender)
		{
			this.ActualizarValoresDeModelo();
			if (this.isShowing)
			{
				this.CrearYDibujar(null);
				return;
			}
			if (this.isBinded)
			{
				this.Clear();
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000035BB File Offset: 0x000017BB
		private void OnRedoAutoRating(EstrevistaRatingModelo obj)
		{
			ICharacterAutoRateable componentEnRoot = ((EntrevistaFemaleCharacterFromPoolOrMemOrDisk)Actividad.running).currentFemaleCharacter.GetComponentEnRoot<ICharacterAutoRateable>();
			if (componentEnRoot != null)
			{
				componentEnRoot.DoAutoRating();
			}
			this.TryAutoRatingAModelo();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000035E3 File Offset: 0x000017E3
		private void OnConfirmarDone(EstrevistaRatingModelo obj)
		{
			this.ActualizarValoresDeModelo();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000035EC File Offset: 0x000017EC
		private void OnCalificada(EstrevistaRatingModelo obj)
		{
			EntrevistaParaCalificarFemaleCharacterFromPool entrevistaParaCalificarFemaleCharacterFromPool = (EntrevistaParaCalificarFemaleCharacterFromPool)Actividad.running;
			this.ActualizarValoresDeModelo();
			obj.aparienciaFisica.GetScore(entrevistaParaCalificarFemaleCharacterFromPool.flagScoreAparienciaCurrentFemaleV2);
			obj.personalidad.GetScore(entrevistaParaCalificarFemaleCharacterFromPool.flagScorePersonalidadCurrentFemaleV2);
			this.haSidoCalificadoPorPlayer = (this.haSidoCalificado = true);
			this.calificando = false;
			this.CrearYDibujar(null);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000364A File Offset: 0x0000184A
		private void MainGoneLateModel_onGoingHome(EstrevistaMainGoneLateModelo obj)
		{
			this.OnRest();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003652 File Offset: 0x00001852
		private void MainGoneModel_onResting(EstrevistaMainGoneModelo obj)
		{
			this.OnRest();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000365C File Offset: 0x0000185C
		private void OnRest()
		{
			EntrevistaParaCalificarFemaleCharacterFromPool entrevistaParaCalificarFemaleCharacterFromPool = (EntrevistaParaCalificarFemaleCharacterFromPool)Actividad.running;
			if (entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresApariencia.mapaDeValores != null)
			{
				entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresApariencia.Save();
			}
			if (entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresPersonalidad.mapaDeValores != null)
			{
				entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresPersonalidad.Save();
			}
			if (entrevistaParaCalificarFemaleCharacterFromPool.femaleCharacterCanBeRated && !this.haSidoCalificado)
			{
				this.TryAutoRatingAModelo();
			}
			this.ActualizarValoresDeModelo();
			if (entrevistaParaCalificarFemaleCharacterFromPool.femaleCharacterCanBeRated)
			{
				this.ratingModel.aparienciaFisica.GetScore(entrevistaParaCalificarFemaleCharacterFromPool.flagScoreAparienciaCurrentFemaleV2);
				this.ratingModel.personalidad.GetScore(entrevistaParaCalificarFemaleCharacterFromPool.flagScorePersonalidadCurrentFemaleV2);
				entrevistaParaCalificarFemaleCharacterFromPool.CalificarCurrentFemale();
			}
			entrevistaParaCalificarFemaleCharacterFromPool.CurrentFemaleWasInterviewed();
			this.resting = true;
			this.Hide();
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003738 File Offset: 0x00001938
		public bool isShowing
		{
			get
			{
				return this.m_userPanel.isShowing;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00003745 File Offset: 0x00001945
		public bool isBinded
		{
			get
			{
				return this.m_userPanel.isBinded;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003752 File Offset: 0x00001952
		GenericUserPanelBase IPanelOfModel.genericUserPanel
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000375C File Offset: 0x0000195C
		public void CrearYDibujar(DibujadorDynamico.ExtraData extraData = null)
		{
			if (DialogueManager.IsConversationActive)
			{
				this.Clear();
				return;
			}
			if (!this.calificando)
			{
				this.m_AlwaysOnScreenGeneric.enabled = true;
				this.m_AlwaysOnScreenGeneric.config = this.noCalificandoConfig;
				this.m_AlwaysOnScreenGeneric.transform.position = this.m_canvasDefaultPosition;
			}
			if (this.isBinded)
			{
				this.Clear();
			}
			if (!this.resting)
			{
				this.m_lastDrawnModel = this.CalcularModelObject();
				this.m_userPanel.Bind(this.m_lastDrawnModel, this.m_lastDrawnModel, extraData);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000037ED File Offset: 0x000019ED
		public void ActualizarValoresDeModelo()
		{
			if (!this.m_userPanel.isBinded)
			{
				return;
			}
			this.m_userPanel.ActualizarValoresDeModelo();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003808 File Offset: 0x00001A08
		public void ActualizarValoresDePanel()
		{
			if (!this.m_userPanel.isBinded)
			{
				return;
			}
			this.m_userPanel.ActualizarValoresDePanel();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003823 File Offset: 0x00001A23
		public void Clear()
		{
			this.m_userPanel.Clear();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003830 File Offset: 0x00001A30
		public void Show()
		{
			this.m_userPanel.Show();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000383D File Offset: 0x00001A3D
		public void Hide()
		{
			this.m_userPanel.Hide();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000384A File Offset: 0x00001A4A
		private void M_userPanel_showed(GenericUserPanelBase obj)
		{
			this.m_showObjectives.valor.valor = true;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000385D File Offset: 0x00001A5D
		private void M_userPanel_hided(GenericUserPanelBase obj)
		{
			this.m_showObjectives.valor.valor = false;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003870 File Offset: 0x00001A70
		public bool CanShow()
		{
			return !this.resting;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000387C File Offset: 0x00001A7C
		public object CurrentModelObjectAndState(out bool changed)
		{
			object obj = this.CalcularModelObject();
			changed = this.m_lastModel != obj;
			this.m_lastModel = obj;
			return this.m_lastModel;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000038AB File Offset: 0x00001AAB
		public object GetLastDrawModel()
		{
			return this.m_lastDrawnModel;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000038B3 File Offset: 0x00001AB3
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Dibujar",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000038CC File Offset: 0x00001ACC
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.CrearYDibujar(null);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000038DB File Offset: 0x00001ADB
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar Valores De Modelo",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000038F4 File Offset: 0x00001AF4
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.ActualizarValoresDeModelo();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003902 File Offset: 0x00001B02
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar Valores De Panel",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000391B File Offset: 0x00001B1B
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			this.ActualizarValoresDePanel();
		}

		// Token: 0x04000028 RID: 40
		[SerializeField]
		private PanelInfoOwnAgencia m_agencyInfoPanel;

		// Token: 0x04000029 RID: 41
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDespachar;

		// Token: 0x0400002A RID: 42
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationContratar;

		// Token: 0x0400002B RID: 43
		[SerializeField]
		private OtrasAgenciasPanelDataLoader m_otrasAgenciasPanel;

		// Token: 0x0400002C RID: 44
		public bool resting;

		// Token: 0x0400002D RID: 45
		public bool calificando;

		// Token: 0x0400002E RID: 46
		public bool haSidoCalificado;

		// Token: 0x0400002F RID: 47
		public bool haSidoCalificadoPorPlayer;

		// Token: 0x04000030 RID: 48
		public bool tryContactada;

		// Token: 0x04000031 RID: 49
		public bool tryDespachada;

		// Token: 0x04000032 RID: 50
		public bool tryHired;

		// Token: 0x04000033 RID: 51
		public EstrevistaMainModelo mainModel = new EstrevistaMainModelo();

		// Token: 0x04000034 RID: 52
		public EstrevistaMainGoneModelo mainGoneModel = new EstrevistaMainGoneModelo();

		// Token: 0x04000035 RID: 53
		public EstrevistaMainGoneLateModelo mainGoneLateModel = new EstrevistaMainGoneLateModelo();

		// Token: 0x04000036 RID: 54
		public EstrevistaRatingModelo ratingModel = new EstrevistaRatingModelo();

		// Token: 0x04000037 RID: 55
		[NonSerialized]
		private object m_lastModel;

		// Token: 0x04000038 RID: 56
		[NonSerialized]
		private object m_lastDrawnModel;

		// Token: 0x04000039 RID: 57
		private AlwaysOnScreenGeneric m_AlwaysOnScreenGeneric;

		// Token: 0x0400003A RID: 58
		private Vector3 m_canvasDefaultPosition;

		// Token: 0x0400003B RID: 59
		public AlwaysOnScreenBase.Config calificandoConfig = new AlwaysOnScreenBase.Config();

		// Token: 0x0400003C RID: 60
		public AlwaysOnScreenBase.Config noCalificandoConfig = new AlwaysOnScreenBase.Config();

		// Token: 0x0400003D RID: 61
		private GenericFlotanteUserPanel m_userPanel;

		// Token: 0x0400003E RID: 62
		private ModificadorDeBool m_showObjectives;
	}
}
