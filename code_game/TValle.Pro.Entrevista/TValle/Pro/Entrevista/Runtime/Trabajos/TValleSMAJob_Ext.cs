using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Camaras;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Globales;
using Assets.TValle.Tools.Runtime.Moddding;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales.Updater;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x02000058 RID: 88
	public abstract class TValleSMAJob_Ext : TValleSMAJob
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060002C3 RID: 707
		protected abstract string dispatchDialogueID { get; }

		// Token: 0x060002C4 RID: 708 RVA: 0x000100A4 File Offset: 0x0000E2A4
		protected void MainNonPlayerCharacterLookAtMainCharacter(float duration, float wHead, float wEyes, LookAtControllerV2.LookAtType headType, bool headConstantUpdate, LookAtControllerV2.LookAtType eyesType, bool eyesConstantUpdate, float velMod = 1f)
		{
			LookAtControllerV2 componentInChildren = base.mainNonPlayerCharacter.GetComponentInChildren<LookAtControllerV2>();
			if (componentInChildren == null)
			{
				return;
			}
			MaleChar component = base.mainPlayerCharacter.GetComponent<MaleChar>();
			Transform transform = component.cameraAtadaTransform;
			if (transform == null)
			{
				transform = component.bones.eyeL.transform;
			}
			if (transform == null)
			{
				transform = component.bones.head.transform;
			}
			if (transform == null)
			{
				return;
			}
			componentInChildren.Mirar(wHead, wEyes, transform, headType, headConstantUpdate, eyesType, eyesConstantUpdate, velMod, 100, duration, ControllerPrioridadConfig.prioridad, default(Vector3), true, 5f);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00010140 File Offset: 0x0000E340
		protected void UI_showMenuKeyReleased(ISMAJobsUIManager obj)
		{
			if (!this.m_jobManager.UI.floatingMainMenuIsShowing)
			{
				object obj2;
				this.m_jobManager.UI.DrawFloatingMainMenuPanel(this.GetUIMenuModel(), out obj2, new Action(this.OnHided));
				if (this.m_jobManager.UI.floatingMainMenuIsShowing)
				{
					this.m_jobManager.UI.ShowCurrentJobSessionObjetives(true, false);
					return;
				}
			}
			else
			{
				this.m_jobManager.UI.CloseFloatingPanel();
				this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, false);
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000101CA File Offset: 0x0000E3CA
		private void OnHided()
		{
			this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, false);
		}

		// Token: 0x060002C7 RID: 711
		protected abstract object GetUIMenuModel();

		// Token: 0x060002C8 RID: 712 RVA: 0x000101E0 File Offset: 0x0000E3E0
		protected object GetDefaultUIMenuModel_ForClients()
		{
			if (base.mainNonPlayerCharacter.gameObject.activeInHierarchy)
			{
				if (this.m_JobWithClientDefaultMenuModel_UIModel == null)
				{
					this.m_JobWithClientDefaultMenuModel_UIModel = new JobWithClientDefaultMenuModel();
					this.m_JobWithClientDefaultMenuModel_UIModel.onShowModelInfo += this.M_mainMenuModel_onShowModelInfo;
					this.m_JobWithClientDefaultMenuModel_UIModel.onShowClientInfo += this.M_mainMenuModel_onShowClientInfo;
					this.m_JobWithClientDefaultMenuModel_UIModel.onLeave += this.M_mainMenuModel_onLeave;
				}
				return this.m_JobWithClientDefaultMenuModel_UIModel;
			}
			throw new InvalidOperationException("si es job con cliente, la female no deberia retirarse, al menos en este job");
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00010268 File Offset: 0x0000E468
		protected object GetDefaultUIModel_ForEmployers()
		{
			if (base.mainNonPlayerCharacter.gameObject.activeInHierarchy)
			{
				if (this.m_JobWithEmployerDefaultMenuModel_UIModel == null)
				{
					this.m_JobWithEmployerDefaultMenuModel_UIModel = new JobWithEmployerDefaultMenuModel();
					this.m_JobWithEmployerDefaultMenuModel_UIModel.onModelDismissed += this.M_mainMenuModel_onModelDismissed;
					this.m_JobWithEmployerDefaultMenuModel_UIModel.onShowEmployerInfo += this.M_mainMenuModel_onShowEmployerInfo;
					this.m_JobWithEmployerDefaultMenuModel_UIModel.onShowModelInfo += this.M_mainMenuModel_onShowModelInfo;
				}
				return this.m_JobWithEmployerDefaultMenuModel_UIModel;
			}
			if (this.m_JobWithEmployerModelGoneDefaultMenuModel_UIModel == null)
			{
				this.m_JobWithEmployerModelGoneDefaultMenuModel_UIModel = new JobWithEmployerModelGoneDefaultMenuModel();
				this.m_JobWithEmployerModelGoneDefaultMenuModel_UIModel.onShowEmployerInfo += this.M_mainMenuModel_onShowEmployerInfo;
				this.m_JobWithEmployerModelGoneDefaultMenuModel_UIModel.onEndSession += this.M_mainMenuModelGone_onEndSession;
			}
			return this.m_JobWithEmployerModelGoneDefaultMenuModel_UIModel;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0001032D File Offset: 0x0000E52D
		private void M_mainMenuModel_onLeave(JobWithClientDefaultMenuModel obj)
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			AsyncSingleton<JobsManager>.instance.AbortCurrentJob(null);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001034A File Offset: 0x0000E54A
		private void M_mainMenuModel_onShowClientInfo(JobWithClientDefaultMenuModel obj)
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainPlayerCharacterInfo();
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0001036C File Offset: 0x0000E56C
		private void M_mainMenuModel_onShowModelInfo(JobWithClientDefaultMenuModel obj)
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainNonPlayerCharacterInfo();
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0001038E File Offset: 0x0000E58E
		private void M_mainMenuModel_onShowModelInfo()
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainNonPlayerCharacterInfo();
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000103B0 File Offset: 0x0000E5B0
		private void M_mainMenuModel_onShowEmployerInfo()
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainPlayerCharacterInfo();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000103D4 File Offset: 0x0000E5D4
		private void M_mainMenuModel_onModelDismissed()
		{
			string conversationID = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(this.dispatchDialogueID);
			if (!DialogueManager.IsConversationActive && !string.IsNullOrWhiteSpace(conversationID))
			{
				ActividadesManager instance = Singleton<ActividadesManager>.instance;
				IAnimatorCharacter componentEnRoot = this.m_jobManager.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot != null && instance.current.mainNonPlayerCharacter.TrySerConversarzado(instance.current.mainPlayerCharacter, conversationID))
				{
					this.m_jobManager.UI.CloseFloatingPanel();
					Singleton<CurrentMainChar>.instance.camara.Ver(componentEnRoot.bones.head.posicionFinal);
					CharacterRotationMode componentInChildren = this.m_jobManager.current.mainPlayerCharacter.GetComponentInChildren<CharacterRotationMode>();
					if (componentInChildren == null)
					{
						return;
					}
					componentInChildren.ForzarBodyRotationPor(2f);
				}
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00010498 File Offset: 0x0000E698
		private void M_mainMenuModelGone_onEndSession()
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			AsyncSingleton<JobsManager>.instance.AbortCurrentJob(null);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000104B5 File Offset: 0x0000E6B5
		protected void ResetInputs()
		{
			Singleton<ActividadesManager>.instance.SetUIInputsActive(true);
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(true);
		}

		// Token: 0x060002D2 RID: 722
		protected abstract IEnumerator RetirarRutine();

		// Token: 0x060002D3 RID: 723 RVA: 0x000104CD File Offset: 0x0000E6CD
		protected void OnEndedRutine(MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.ResetInputs();
			if (error != null)
			{
				this.RetirarPorError();
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000104DE File Offset: 0x0000E6DE
		protected void RetirarPorError()
		{
			this.StopAllStates();
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, this, this.RetirarRutine(), null);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00010500 File Offset: 0x0000E700
		protected virtual void StopAllGamePlayStates()
		{
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00010504 File Offset: 0x0000E704
		protected virtual void StopAllStates()
		{
			this.StopAllGamePlayStates();
			GlobalUpdater.Corrutina retirar = this.m_Retirar;
			if (((retirar != null) ? new bool?(retirar.alive) : null).GetValueOrDefault())
			{
				this.m_Retirar.Stop();
			}
			this.m_Retirar = null;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00010554 File Offset: 0x0000E754
		protected void TeleportToGOTO(ICharacter navigator, string gotoID, bool turnedAround)
		{
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener(gotoID);
			if (goTo == null)
			{
				throw new NullReferenceException("goto is null");
			}
			Singleton<GoToScenaManager>.instance.Apply(navigator, turnedAround, goTo);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00010588 File Offset: 0x0000E788
		protected IEnumerator NavToGOTORutineSlow(ICharacter navigator, string gotoID, bool OnlyStrafe, Func<bool> customInOn = null, float cornerDistanceMod = 1f, Action termino = null, bool checkAltura = true)
		{
			float num = Mathf.InverseLerp(0.777f, 1.2f, navigator.escala);
			num = Mathf.Lerp(0.9f, 0.5f, num);
			yield return this.NavToGOTORutine(navigator, gotoID, OnlyStrafe, customInOn, num, cornerDistanceMod, termino, checkAltura);
			yield break;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000105D8 File Offset: 0x0000E7D8
		protected IEnumerator NavToGOTORutine(ICharacter navigator, string gotoID, bool OnlyStrafe, Func<bool> customInOn = null, float maxMagnitude = 1f, float cornerDistanceMod = 1f, Action termino = null, bool checkAltura = true)
		{
			GoToScenaManager.GoTo GoTo = Singleton<GoToScenaManager>.instance.Obtener(gotoID);
			ICharacterNavegable femNavegable = navigator.GetComponentEnRoot<ICharacterNavegable>();
			if (femNavegable == null)
			{
				throw new NullReferenceException("ICharacterNavegable is null");
			}
			Transform animatorRootMotionTransform = navigator.animatorRootMotionTransform;
			if (animatorRootMotionTransform == null)
			{
				throw new NullReferenceException("root animator is null");
			}
			float presitionMod = Mathf.Lerp(cornerDistanceMod, 1f, 0.5f);
			while (!Singleton<GoToScenaManager>.instance.IsOn(gotoID, animatorRootMotionTransform.position, animatorRootMotionTransform.rotation, false, 0.4f * presitionMod, 45f * presitionMod, !checkAltura) || (customInOn != null && !customInOn()))
			{
				yield return null;
				Singleton<GoToScenaManager>.instance.NavTo(femNavegable, false, GoTo, maxMagnitude, cornerDistanceMod, OnlyStrafe);
				while (femNavegable.isGoingToNavite || femNavegable.isNavigating)
				{
					yield return null;
				}
				maxMagnitude *= 0.9f;
				OnlyStrafe = true;
			}
			if (termino != null)
			{
				termino();
			}
			yield break;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00010628 File Offset: 0x0000E828
		protected ISMAJobObjective CreateObjective(int lvl, string ID, bool checkAfterCompleted, ObjectiveCheckerHandler checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null)
		{
			InGameObjectiveText inGameObjectiveText = ((lvl < 0) ? this.m_map.GetObjectiveText(ID, this.m_jobManager.gameLanguage) : this.m_map.GetObjectiveText(lvl, ID, this.m_jobManager.gameLanguage));
			if (inGameObjectiveText == null)
			{
				Debug.LogError("can load objective text: " + ID, this);
				return null;
			}
			return this.m_jobManager.objectives.CreateObjective(ID, inGameObjectiveText.desc, checkAfterCompleted, checkDelegate, checkFrequency, subObjectives, inGameObjectiveText.tips);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000106A8 File Offset: 0x0000E8A8
		protected ISMAJobObjective CreatePercentageObjective(int lvl, string ID, bool checkAfterCompleted, ObjectiveCheckerHandler_RecalculateWeight checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, PercentageObjectiveProgressWeightChandedHandler callback = null)
		{
			InGameObjectiveText inGameObjectiveText = ((lvl < 0) ? this.m_map.GetObjectiveText(ID, this.m_jobManager.gameLanguage) : this.m_map.GetObjectiveText(lvl, ID, this.m_jobManager.gameLanguage));
			if (inGameObjectiveText == null)
			{
				Debug.LogError("can load objective text: " + ID, this);
				return null;
			}
			return this.m_jobManager.objectives.CreatePercentageObjective(ID, inGameObjectiveText.desc, checkAfterCompleted, checkDelegate, checkFrequency, subObjectives, inGameObjectiveText.tips, callback);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00010728 File Offset: 0x0000E928
		protected ISMAJobObjective CreateFlagsObjective(int lvl, string ID, bool checkAfterCompleted, IReadOnlyList<string> Flags, ObjectiveCheckerHandler_IsFlagSet checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, ObjectiveFlagsChandedHandler callback = null)
		{
			InGameObjectiveText inGameObjectiveText = ((lvl < 0) ? this.m_map.GetObjectiveText(ID, this.m_jobManager.gameLanguage) : this.m_map.GetObjectiveText(lvl, ID, this.m_jobManager.gameLanguage));
			if (inGameObjectiveText == null)
			{
				Debug.LogError("can load objective text: " + ID, this);
				return null;
			}
			return this.m_jobManager.objectives.CreateFlagsObjective(ID, inGameObjectiveText.desc, checkAfterCompleted, Flags, checkDelegate, checkFrequency, subObjectives, inGameObjectiveText.tips, callback);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x000107AC File Offset: 0x0000E9AC
		protected ISMAJobObjective CreateUniqueActionsCountObjective(int lvl, string ID, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_GetLastUniqueAction checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, ObjectiveCountChandedHandler callback = null)
		{
			InGameObjectiveText inGameObjectiveText = ((lvl < 0) ? this.m_map.GetObjectiveText(ID, this.m_jobManager.gameLanguage) : this.m_map.GetObjectiveText(lvl, ID, this.m_jobManager.gameLanguage));
			if (inGameObjectiveText == null)
			{
				Debug.LogError("can load objective text: " + ID, this);
				return null;
			}
			return this.m_jobManager.objectives.CreateUniqueActionsCountObjective(ID, inGameObjectiveText.desc, checkAfterCompleted, Capacity, checkDelegate, checkFrequency, subObjectives, inGameObjectiveText.tips, callback);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00010830 File Offset: 0x0000EA30
		protected ISMAJobObjective CreateCountOfSingleActionObjective(int lvl, string ID, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_CurrentCount checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, ObjectiveCountChandedHandler callback = null)
		{
			InGameObjectiveText inGameObjectiveText = ((lvl < 0) ? this.m_map.GetObjectiveText(ID, this.m_jobManager.gameLanguage) : this.m_map.GetObjectiveText(lvl, ID, this.m_jobManager.gameLanguage));
			if (inGameObjectiveText == null)
			{
				Debug.LogError("can load objective text: " + ID, this);
				return null;
			}
			return this.m_jobManager.objectives.CreateCountOfSingleActionObjective(ID, inGameObjectiveText.desc, checkAfterCompleted, Capacity, checkDelegate, checkFrequency, subObjectives, inGameObjectiveText.tips, callback);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x000108B1 File Offset: 0x0000EAB1
		protected IEnumerator ResetMainCamera(string gotoName)
		{
			GoToScenaManager.GoTo maleGOTO = Singleton<GoToScenaManager>.instance.Obtener(gotoName);
			if (maleGOTO == null)
			{
				throw new ArgumentNullException("maleGOTO", "maleGOTO null reference.");
			}
			yield return base.CheckMainCamera();
			InstantiatedSingleton<MainCameraRig>.instance.transform.SetPositionAndRotation(maleGOTO.transform.position, maleGOTO.transform.rotation);
			InstantiatedSingleton<MainCameraRig>.instance.transform.position = InstantiatedSingleton<MainCameraRig>.instance.transform.position + new Vector3(0f, 2f, 0f);
			yield break;
		}

		// Token: 0x040001C0 RID: 448
		private JobWithClientDefaultMenuModel m_JobWithClientDefaultMenuModel_UIModel;

		// Token: 0x040001C1 RID: 449
		private JobWithEmployerDefaultMenuModel m_JobWithEmployerDefaultMenuModel_UIModel;

		// Token: 0x040001C2 RID: 450
		private JobWithEmployerModelGoneDefaultMenuModel m_JobWithEmployerModelGoneDefaultMenuModel_UIModel;

		// Token: 0x040001C3 RID: 451
		protected GlobalUpdater.Corrutina m_Retirar;
	}
}
