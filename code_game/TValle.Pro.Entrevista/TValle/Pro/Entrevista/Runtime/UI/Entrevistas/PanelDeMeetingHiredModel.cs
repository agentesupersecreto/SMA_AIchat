using System;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Tiempo;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000041 RID: 65
	public class PanelDeMeetingHiredModel : PanelBaseDualModel<MeetingHiredModelModelo, MeetingHiredModelModeloGoneModelo>
	{
		// Token: 0x06000207 RID: 519 RVA: 0x0000CC50 File Offset: 0x0000AE50
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (string.IsNullOrWhiteSpace(this.m_conversationDespedir))
			{
				throw new ArgumentNullException("m_conversationDespedir", "m_conversationDespedir null reference.");
			}
			if (string.IsNullOrWhiteSpace(this.m_conversationDespachar))
			{
				throw new ArgumentNullException("m_conversationDespachar", "m_conversationDespachar null reference.");
			}
			if (this.m_PanelModelAssignmentsLoader == null)
			{
				throw new ArgumentNullException("m_PanelModelAssignmentsLoader", "m_PanelModelAssignmentsLoader null reference.");
			}
			this.m_a.onTalentDeployment += this.M_model_onTalentDeployment;
			this.m_a.onDispatchHerClicked += this.M_model_onDispatchHerClicked;
			this.m_a.onStartFiring += this.M_model_onStartFiring;
			this.m_a.onShowModelInfo += this.MainModel_onShowModelInfo;
			this.m_a.onShowPlayerInfo += this.MainModel_onShowPlayerInfo;
			this.m_b.onRest += this.DoRest;
			MeetingHiredModelModeloGoneModelo b = this.m_b;
			b.isLastWorkSchedule = (Func<bool>)Delegate.Combine(b.isLastWorkSchedule, new Func<bool>(this.IsLastWorkSchedule));
			this.m_b.onShowPlayerInfo += this.MainModel_onShowPlayerInfo;
			this.m_showObjectives = Singleton<GameplayObjectives>.instance.showPanel.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000CD99 File Offset: 0x0000AF99
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

		// Token: 0x06000209 RID: 521 RVA: 0x0000CDB4 File Offset: 0x0000AFB4
		protected override object ObtenerModeloAUsar(bool esParaDibujar)
		{
			if (this.m_resting)
			{
				return null;
			}
			EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
			EntrevistaConFemaleCharacter.FemalePresencia femalePresencia = entrevistaConFemaleCharacter.femalePresencia;
			if (femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.presente)
			{
				return this.m_a;
			}
			if (femalePresencia - EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorUserInteresado > 8)
			{
				throw new ArgumentOutOfRangeException(entrevistaConFemaleCharacter.femalePresencia.ToString());
			}
			return this.m_b;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000CE0F File Offset: 0x0000B00F
		public override bool CanShow()
		{
			return !this.m_resting && base.CanShow();
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000CE21 File Offset: 0x0000B021
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_showObjectives.valor.valor = true;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000CE3A File Offset: 0x0000B03A
		protected override void OnHided()
		{
			base.OnHided();
			this.m_showObjectives.valor.valor = false;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000CE54 File Offset: 0x0000B054
		private void DoRest()
		{
			base.ActualizarValoresDeModelo();
			this.m_resting = true;
			base.Hide();
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000CE94 File Offset: 0x0000B094
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

		// Token: 0x0600020F RID: 527 RVA: 0x0000CF0C File Offset: 0x0000B10C
		private void M_model_onStartFiring(MeetingHiredModelModelo obj)
		{
			if (!DialogueManager.IsConversationActive && !string.IsNullOrWhiteSpace(this.m_conversationDespedir))
			{
				ActividadConMaleAndFemaleCharacter mana = (ActividadConMaleAndFemaleCharacter)Actividad.running;
				if (mana != null && mana.currentFemaleCharacterConversador.puedeConversar)
				{
					float num;
					float num2;
					MemoriaDeSMAModelosFemeninas.GetModeSalaryAndCommission(GlobalSingletonV2<MemoriaJson>.instance, mana.currentFemaleCharacter.ID_UnicoString, out num, out num2);
					DateTime now = Singleton<TiempoDeJuego>.instance.now;
					DateTime dateTime = now.Next(DayOfWeek.Friday);
					DateTime dateTime2 = now.Last(DayOfWeek.Monday);
					int num3 = (int)Math.Ceiling((now - dateTime2).TotalDays);
					int num4 = (int)Math.Ceiling((dateTime - now).TotalDays);
					float num5 = num / 5f;
					float num6 = (float)num3 * num5;
					float num7 = (float)num3 * 0.5f * (float)num4;
					ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarBigConfirmacion();
					dialog.SetPreguntaText(string.Concat(new string[]
					{
						"Model: ",
						mana.currentFemaleCharacter.nombreCompleto,
						"\r\nDays Worked: ",
						num3.ToString(),
						" days\r\nDaily Salary: $",
						num5.ToString(),
						"\r\nTotal Salary Earned: $",
						num6.ToString(),
						"\r\nContract Length: ",
						6.ToString(),
						" days\r\nRemaining Days: ",
						num4.ToString(),
						" days\r\n\r\nEarly Termination Penalty: $",
						num7.ToString(),
						"\r\n(This amount will be deducted immediately.)\r\n\r\n⚠\ufe0f Are you sure you want to terminate this model’s contract?\r\nThis action is permanent and will remove her from your staff list."
					}));
					dialog.noMostrarOtraVezToggle.interactable = false;
					dialog.cancelar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
					});
					dialog.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
						mana.currentFemaleCharacter.TrySerConversarzado(MainChar.current, this.m_conversationDespedir);
						this.Hide();
						Singleton<CurrentMainChar>.instance.camara.Ver(mana.currentFemaleCharacter.bones.head.posicionFinal);
						CharacterRotationMode componentInChildren = MainChar.current.GetComponentInChildren<CharacterRotationMode>();
						if (componentInChildren == null)
						{
							return;
						}
						componentInChildren.ForzarBodyRotationPor(2f);
					});
				}
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000D114 File Offset: 0x0000B314
		private void M_model_onDispatchHerClicked(MeetingHiredModelModelo obj)
		{
			if (!DialogueManager.IsConversationActive && !string.IsNullOrWhiteSpace(this.m_conversationDespachar))
			{
				ActividadConMaleAndFemaleCharacter actividadConMaleAndFemaleCharacter = (ActividadConMaleAndFemaleCharacter)Actividad.running;
				if (actividadConMaleAndFemaleCharacter != null && actividadConMaleAndFemaleCharacter.currentFemaleCharacterConversador.puedeConversar)
				{
					actividadConMaleAndFemaleCharacter.currentFemaleCharacter.TrySerConversarzado(MainChar.current, this.m_conversationDespachar);
					base.Hide();
					Singleton<CurrentMainChar>.instance.camara.Ver(actividadConMaleAndFemaleCharacter.currentFemaleCharacter.bones.head.posicionFinal);
					CharacterRotationMode componentInChildren = MainChar.current.GetComponentInChildren<CharacterRotationMode>();
					if (componentInChildren == null)
					{
						return;
					}
					componentInChildren.ForzarBodyRotationPor(2f);
				}
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000D1B3 File Offset: 0x0000B3B3
		private void M_model_onTalentDeployment()
		{
			if (!DialogueManager.IsConversationActive && this.m_PanelModelAssignmentsLoader != null && !this.m_PanelModelAssignmentsLoader.isShowing)
			{
				base.Hide();
				this.m_PanelModelAssignmentsLoader.CrearYDibujar(null);
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000D1EC File Offset: 0x0000B3EC
		private void MainModel_onShowModelInfo()
		{
			if (!DialogueManager.IsConversationActive)
			{
				EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
				if (((entrevistaConFemaleCharacter != null) ? entrevistaConFemaleCharacter.currentFemaleCharacter : null) != null && !Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing)
				{
					base.Hide();
					Singleton<PanelCharacterCompleteInfoGetter>.instance.CrearYDibujar(entrevistaConFemaleCharacter.currentFemaleCharacter);
				}
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000D244 File Offset: 0x0000B444
		private void MainModel_onShowPlayerInfo()
		{
			if (!DialogueManager.IsConversationActive)
			{
				EntrevistaConFemaleCharacter entrevistaConFemaleCharacter = (EntrevistaConFemaleCharacter)Actividad.running;
				if (((entrevistaConFemaleCharacter != null) ? entrevistaConFemaleCharacter.currentMaleCharacter : null) != null && !Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing)
				{
					base.Hide();
					Singleton<PanelCharacterCompleteInfoGetter>.instance.CrearYDibujar(entrevistaConFemaleCharacter.currentMaleCharacter);
				}
			}
		}

		// Token: 0x04000167 RID: 359
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDespedir;

		// Token: 0x04000168 RID: 360
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDespachar;

		// Token: 0x04000169 RID: 361
		[SerializeField]
		private PanelModelAssignmentsLoader m_PanelModelAssignmentsLoader;

		// Token: 0x0400016A RID: 362
		[Space]
		[SerializeField]
		private bool m_resting;

		// Token: 0x0400016B RID: 363
		private ModificadorDeBool m_showObjectives;
	}
}
