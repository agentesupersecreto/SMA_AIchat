using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Ropa;
using Assets.TValle.BeachGirl.Runtime.Camaras;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.Menus.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers.GoTo;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen.Heredacion;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Globales;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.UI;
using Battlehub.RTCommon;
using PixelCrushers.DialogueSystem;
using RootMotion.Dynamics;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs
{
	// Token: 0x02000060 RID: 96
	public class SpaJob : TValleSMAJob, ISMAJob, RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000383 RID: 899 RVA: 0x000124E4 File Offset: 0x000106E4
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000384 RID: 900 RVA: 0x000124E7 File Offset: 0x000106E7
		public override bool nonPlayerCharacterWillRememberPlayerCharacter
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000385 RID: 901 RVA: 0x000124EA File Offset: 0x000106EA
		protected override ActividadScenesLoader.SceneLoadOrder initialLoadOrder
		{
			get
			{
				return ActividadScenesLoader.SceneLoadOrder.Pre_Main_Lighting_Post;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000386 RID: 902 RVA: 0x000124ED File Offset: 0x000106ED
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000124F4 File Offset: 0x000106F4
		private void SubscribeToRegistroDeFuncionesDeTrabajosDeModelaje(RegistroDeFuncionesDeTrabajosDeModelaje registro)
		{
			registro.AddListiner(this);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x000124FD File Offset: 0x000106FD
		private void UnsubscribeToRegistroDeFuncionesDeTrabajosDeModelaje(RegistroDeFuncionesDeTrabajosDeModelaje registro)
		{
			registro.RemoveListiner(this);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00012506 File Offset: 0x00010706
		private void OnHeroineLoaded_DEBUG()
		{
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00012508 File Offset: 0x00010708
		private void OnHeroLoaded_DEBUG()
		{
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0001250A File Offset: 0x0001070A
		private void Update_DEBUG()
		{
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0001250C File Offset: 0x0001070C
		public override IEnumerator DoStart()
		{
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeAI>();
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeTrabajosDeModelaje>();
			RegistroDeFuncionesDeTrabajosDeModelaje registroDeFuncionesDeTrabajosDeModelaje = CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>();
			this.SubscribeToRegistroDeFuncionesDeTrabajosDeModelaje(registroDeFuncionesDeTrabajosDeModelaje);
			GoToScenaManager.GoTo femGOTO = Singleton<GoToScenaManager>.instance.Obtener("WelcomeWorker_GoTo");
			yield return this.ResetMainCamera();
			CameraFade.FadeOutMain(0.0001f);
			yield return base.LoadFemaleCharacter(this.m_mainNonPlayerCharacterID, femGOTO.transform.position, femGOTO.transform.forward, null, true, null);
			yield return null;
			Singleton<ActividadesManager>.instance.AddExtraComponentsAndConfigToNonPlayerCharacter();
			float num;
			float num2;
			float num3;
			this.m_jobManager.GetPreferredTreatmentForClientsWeights(this.m_mainNonPlayerCharacterID, out num, out num2, out num3);
			MapaConjuntoDeRopa conjunto;
			if (num3 > 0f)
			{
				conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto("spa.tubeDress");
			}
			else
			{
				conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto("spa.nursePantsAndShirt");
			}
			yield return AsyncSingleton<RopaParaAvatarUnificado>.TryIniciar();
			yield return AsyncSingleton<MaterialesParaRopa>.TryIniciar();
			yield return AsyncSingleton<ConjuntosDeRopa>.TryIniciar();
			yield return Singleton<ActividadesManager>.instance.SetOutfitAndWait(this.m_mainNonPlayerCharacterID, conjunto, true);
			this.AddMenus();
			this.m_clientsCount = (this.m_clientsToGo = 1 + base.lvl * 2);
			this.OnHeroineLoaded_DEBUG();
			this.m_jobManager.UI.showMenuKeyReleased += this.UI_showMenuKeyReleased;
			yield break;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0001251B File Offset: 0x0001071B
		private IEnumerator ResetMainCamera()
		{
			GoToScenaManager.GoTo maleGOTO = Singleton<GoToScenaManager>.instance.Obtener("WelcomeClient_GoTo");
			yield return base.CheckMainCamera();
			InstantiatedSingleton<MainCameraRig>.instance.transform.SetPositionAndRotation(maleGOTO.transform.position, maleGOTO.transform.rotation);
			InstantiatedSingleton<MainCameraRig>.instance.transform.position = InstantiatedSingleton<MainCameraRig>.instance.transform.position + new Vector3(0f, 2f, 0f);
			yield break;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0001252A File Offset: 0x0001072A
		public override IEnumerator Introduce()
		{
			this.m_introduciendo = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.IntroduceToNewClientRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0001253C File Offset: 0x0001073C
		private void AddMenus()
		{
			RadialMenusForActivities instance = AsyncSingleton<RadialMenusForActivities>.instance;
			Character component = this.m_jobManager.current.mainNonPlayerCharacter.GetComponent<Character>();
			IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem = instance.AddRadialMenu(component, "FAST_TIP");
			clickableSelectableTHSDonaItem.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuTipClicked));
			((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuTipIsGrayOut));
			IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem2 = instance.AddRadialMenu(component, "SPA_MOVE_ON");
			clickableSelectableTHSDonaItem2.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuMoveOnPhaseClicked));
			((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem2).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuMoveOnIsGrayOut));
			IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem3 = instance.AddRadialMenu(component, "FAST_GUIDEHER");
			clickableSelectableTHSDonaItem3.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuGuideHerClicked));
			((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem3).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuGuideHerIsGrayOut));
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00012620 File Offset: 0x00010820
		private void UI_showMenuKeyReleased(ISMAJobsUIManager obj)
		{
			if (!this.m_jobManager.UI.floatingMainMenuIsShowing)
			{
				object obj2;
				this.m_jobManager.UI.DrawFloatingMainMenuPanel(this.GetMenuModel(), out obj2, new Action(this.OnHided));
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

		// Token: 0x06000391 RID: 913 RVA: 0x000126AA File Offset: 0x000108AA
		private void OnHided()
		{
			this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, false);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000126C0 File Offset: 0x000108C0
		private object GetMenuModel()
		{
			if (base.mainNonPlayerCharacter.gameObject.activeInHierarchy)
			{
				if (this.m_mainMenuModel == null)
				{
					this.m_mainMenuModel = new JobWithClientDefaultMenuModel();
					this.m_mainMenuModel.onShowModelInfo += this.M_mainMenuModel_onShowModelInfo;
					this.m_mainMenuModel.onShowClientInfo += this.M_mainMenuModel_onShowClientInfo;
					this.m_mainMenuModel.onLeave += this.M_mainMenuModel_onLeave;
				}
				return this.m_mainMenuModel;
			}
			throw new InvalidOperationException("si es job con cliente, la female no deberia retirarse, al menos en este job");
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00012748 File Offset: 0x00010948
		private void M_mainMenuModel_onLeave(JobWithClientDefaultMenuModel obj)
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			AsyncSingleton<JobsManager>.instance.AbortCurrentJob(null);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00012765 File Offset: 0x00010965
		private void M_mainMenuModel_onShowClientInfo(JobWithClientDefaultMenuModel obj)
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainPlayerCharacterInfo();
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00012787 File Offset: 0x00010987
		private void M_mainMenuModel_onShowModelInfo(JobWithClientDefaultMenuModel obj)
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainNonPlayerCharacterInfo();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x000127A9 File Offset: 0x000109A9
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000127AB File Offset: 0x000109AB
		public override void AfterAnimationsUpdate()
		{
		}

		// Token: 0x06000398 RID: 920 RVA: 0x000127AD File Offset: 0x000109AD
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x06000399 RID: 921 RVA: 0x000127AF File Offset: 0x000109AF
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x0600039A RID: 922 RVA: 0x000127B1 File Offset: 0x000109B1
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000127B3 File Offset: 0x000109B3
		public override void AfterAIUpdate()
		{
			this.Update_DEBUG();
		}

		// Token: 0x0600039C RID: 924 RVA: 0x000127BB File Offset: 0x000109BB
		public override IEnumerator Conclude()
		{
			this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, true);
			base.isAborted = base.isAborted || Actividad.running.aborted || !this.m_jobManager.objectives.CheckCompleted();
			List<SceneCharacterFromToBuffAndDebuff> list = new List<SceneCharacterFromToBuffAndDebuff>();
			float num = 0f;
			foreach (Guid guid in this.m_clientsIDs)
			{
				ICharactersSceneInteractionsArchived mainArchivedInteractions = this.m_jobManager.interactions.GetMainArchivedInteractions(guid, this.m_jobManager.current.mainNonPlayerCharacter.ID);
				num += base.CalcularFatiga(mainArchivedInteractions);
				SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff;
				this.m_jobManager.interactions.DefaultBuffAndDebuffGenerate(guid, this.m_jobManager.current.mainNonPlayerCharacter, base.isAborted, base.date, out sceneCharacterFromToBuffAndDebuff);
				list.Add(sceneCharacterFromToBuffAndDebuff);
			}
			SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFemale = SceneCharacterFromToBuffAndDebuff.Combine(list);
			MemoriaDeSMAJobs.RegistrarNewSesionesLaboralDeCharacter(AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(this, AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter));
			float num2 = base.DefaultExpGainCalcule(base.lvl, this.m_clientsCount, this.despachadosPorSatisfecho + this.despachadosPorTiempo + this.despachadosPorSex, this.despachadosPorSatisfecho + this.despachadosPorSex * 2, 0.25f, new int[] { 3, 6, 9 });
			float num3;
			float num4;
			base.SetExpToMainCharacters(num2, out num3, out num4, 0.1f, 1f);
			float num5;
			base.SetFatigueToMainCharacters(ref num, out num5, base.lvl, new float[] { 5f, 15f, 30f });
			float num6;
			base.SetFatigueToJob(0f, out num6);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			float num7 = (float)(this.despachadosPorSatisfecho + this.despachadosPorTiempo + this.despachadosPorSex) / (float)this.m_clientsCount;
			float num8 = this.m_jobManager.PayMoneyToManager((base.isAborted ? 0.666f : 1f) * num7, this.m_totalJobTipTotalAmount * 0.5f);
			Singleton<ActividadesManager>.instance.SetUIInputsActive(true);
			yield return this.m_jobManager.UI.ShowDefaultEndSessionPanel(base.isAborted, num8, num3, num4, num, num5, null, BuffAndDebuffOnFemale);
			this.RemoverBuffDeConsentPorContrato();
			BuffAndDebuffOnFemale.Apply();
			yield break;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000127CA File Offset: 0x000109CA
		public override IEnumerator End()
		{
			RegistroDeFuncionesDeTrabajosDeModelaje registroDeFuncionesDeTrabajosDeModelaje = CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>();
			this.UnsubscribeToRegistroDeFuncionesDeTrabajosDeModelaje(registroDeFuncionesDeTrabajosDeModelaje);
			this.m_jobManager.UI.showMenuKeyReleased -= this.UI_showMenuKeyReleased;
			this.m_jobManager.UpdateCharacterMemory(base.mainNonPlayerCharacter);
			yield break;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000127D9 File Offset: 0x000109D9
		protected override IEnumerator LoadingInitialScences()
		{
			yield break;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x000127E1 File Offset: 0x000109E1
		protected override AssetReference GetMainSceneAssetReference()
		{
			return this.m_map.mainScene;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000127EE File Offset: 0x000109EE
		protected override int GetMainSceneBuildIndex()
		{
			return -1;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000127F1 File Offset: 0x000109F1
		protected override void OnMainSceneLoaded(Scene scene, bool success)
		{
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000127F3 File Offset: 0x000109F3
		protected override AssetReference GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			AssetReference assetReference = this.m_map.lightingAndGeometricsScenes["Act1"];
			onSceneLoadedCallback = null;
			return assetReference;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0001280D File Offset: 0x00010A0D
		protected override int GetLightingAndGeometricsSceneBuildIndexToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
			return -1;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00012813 File Offset: 0x00010A13
		protected override void GetPreSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> AdditionalScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00012818 File Offset: 0x00010A18
		protected override void GetPreSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0001281D File Offset: 0x00010A1D
		protected override void GetPostSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> AdditionalScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00012822 File Offset: 0x00010A22
		protected override void GetPostSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00012828 File Offset: 0x00010A28
		private void RemoverBuffDeConsentPorContrato()
		{
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			componentEnRoot.eventos.Remove(BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobContract", string.Empty));
			componentEnRoot.eventos.Remove(BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByJobContract", string.Empty));
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00012892 File Offset: 0x00010A92
		private IEnumerator WaitForContractable()
		{
			BuffDeCharacter m_BuffDeCharacter = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (m_BuffDeCharacter == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			while (!m_BuffDeCharacter.isStared)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x000128A4 File Offset: 0x00010AA4
		private void GenerarBuffDeConsentPorContrato()
		{
			this.RemoverBuffDeConsentPorContrato();
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			BuffMap buffMap;
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
			BuffMap buffMap2;
			BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
			this.GenerarAgreementBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg);
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			List<GenericDataExclusiveOfInteractionArg> list2 = new List<GenericDataExclusiveOfInteractionArg>();
			this.FillInclusiveData(list);
			this.FillExclusionesData(list2);
			buffOnMinFavorabilityValueArg.InyectData(list);
			buffOnMinFavorabilityValueArg.InyectExclusiveData(list2);
			buffOnDeshieloDeEstimuloEnPartesArg.InyectData(list);
			this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00012934 File Offset: 0x00010B34
		private void AddBuffToCharacter(BuffDeCharacter m_BuffDeCharacter, BuffMap favMap, BuffOnMinFavorabilityValueArg favArgument, BuffMap desMap, BuffOnDeshieloDeEstimuloEnPartesArg desArgument)
		{
			favArgument.changedByFatigue = true;
			favArgument.force = true;
			desArgument.value = 100f;
			DisplayableBuff eventoBuff = favMap.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, favArgument, null);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff.showSmallMsgOnApplied = false;
			eventoBuff.showSmallMsgOnEnd = false;
			eventoBuff.showSmallMsgOnStart = false;
			m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
			DisplayableBuff eventoBuff2 = desMap.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, desArgument, null);
			if (eventoBuff2 == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff2.showSmallMsgOnApplied = false;
			eventoBuff2.showSmallMsgOnEnd = false;
			eventoBuff2.showSmallMsgOnStart = false;
			m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff2, false, false);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00012A04 File Offset: 0x00010C04
		private void FillInclusiveData(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00012AE4 File Offset: 0x00010CE4
		private void FillExclusionesData(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.desvestidura,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.peticionDesvestidura,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.boca,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.ejecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.peticionEjecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.boca,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.manipulandoBone;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.guiandoBone;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.boca;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00012EE4 File Offset: 0x000110E4
		private void GenerarAgreementBuffes(BuffDeCharacter m_BuffDeCharacter, out BuffMap favMap, out BuffOnMinFavorabilityValueArg favArgument, out BuffMap desMap, out BuffOnDeshieloDeEstimuloEnPartesArg desArgument)
		{
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobContract", string.Empty);
			m_BuffDeCharacter.eventos.Remove(text);
			favMap = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.FavorabilityByJobContract");
			if (favMap == null)
			{
				Debug.LogException(new ArgumentNullException("favMap", "favMap null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(favMap.efectoId);
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnMinFavorabilityValueArg>(efecto.argumentoID, out favArgument))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			string text2 = BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByJobContract", string.Empty);
			m_BuffDeCharacter.eventos.Remove(text2);
			desMap = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.DeshieloByJobContract");
			if (desMap == null)
			{
				Debug.LogException(new ArgumentNullException("desMap", "desMap null reference."));
			}
			Efecto efecto2 = Singleton<EfectosManager>.instance.GetEfecto(desMap.efectoId);
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnDeshieloDeEstimuloEnPartesArg>(efecto2.argumentoID, out desArgument))
			{
				Debug.LogError("arg id :" + efecto2.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00013009 File Offset: 0x00011209
		private IEnumerator ExposeConjuntoDeRopa()
		{
			float num;
			float num2;
			float num3;
			this.m_jobManager.GetPreferredTreatmentForClientsWeights(this.m_mainNonPlayerCharacterID, out num, out num2, out num3);
			MapaConjuntoDeRopa mapaConjuntoDeRopa;
			if (num3 > 0f)
			{
				mapaConjuntoDeRopa = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto("spa.tubeDress.Exposed");
			}
			else
			{
				mapaConjuntoDeRopa = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto("spa.nursePantsAndShirt.Exposed");
			}
			IRopaManager ropaManager = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<IRopaManager>(this.m_mainNonPlayerCharacterID, true);
			yield return HeredarHelper.DowngradeConjuntoDeRopa(mapaConjuntoDeRopa, ropaManager, this);
			yield break;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00013018 File Offset: 0x00011218
		private IEnumerator RestoreConjuntoDeRopa()
		{
			float num;
			float num2;
			float num3;
			this.m_jobManager.GetPreferredTreatmentForClientsWeights(this.m_mainNonPlayerCharacterID, out num, out num2, out num3);
			MapaConjuntoDeRopa mapaConjuntoDeRopa;
			if (num3 > 0f)
			{
				mapaConjuntoDeRopa = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto("spa.tubeDress");
			}
			else
			{
				mapaConjuntoDeRopa = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto("spa.nursePantsAndShirt");
			}
			IRopaManager ropaManager = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<IRopaManager>(this.m_mainNonPlayerCharacterID, true);
			yield return HeredarHelper.RestoreConjuntoDeRopa(mapaConjuntoDeRopa, ropaManager, this);
			yield break;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00013027 File Offset: 0x00011227
		private IEnumerator CoverExposedParts()
		{
			IRopaManager ropaManager = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<IRopaManager>(this.m_mainNonPlayerCharacterID, true);
			InteraccionesBasicasDeFemale interaccionesBasicasDeFemale = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<InteraccionesBasicasDeFemale>(this.m_mainNonPlayerCharacterID, true);
			bool flag = ropaManager.CantidadPiezasCubriendo(RopaCubre.vientreBajo, true, null) <= 1;
			bool flag2 = ropaManager.CantidadPiezasCubriendo(RopaCubre.nalgas, true, null) <= 0;
			bool flag3 = ropaManager.CantidadPiezasCubriendo(RopaCubre.pectorales, true, null) <= 0;
			List<Interaccion> toWait = new List<Interaccion>();
			Interaccion interaccion2;
			if (flag)
			{
				Interaccion interaccion;
				if (interaccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparVagConManoDerecha, out interaccion) && interaccion != null && interaccion.Ejecutar(1, 60f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
				{
					toWait.Add(interaccion);
				}
			}
			else if (flag2 && interaccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparColaConManoDerecha, out interaccion2) && interaccion2 != null && interaccion2.Ejecutar(1, 60f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				toWait.Add(interaccion2);
			}
			Interaccion interaccion3;
			if (flag3 && interaccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparSenosConManoIzquierda, out interaccion3) && interaccion3 != null && interaccion3.Ejecutar(1, 60f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				toWait.Add(interaccion3);
			}
			bool flag4;
			do
			{
				yield return null;
				flag4 = true;
				for (int i = 0; i < toWait.Count; i++)
				{
					if (toWait[i].currentEstado.EstadosTimerWeigthPromedio(0f) < 0.75f)
					{
						flag4 = false;
						break;
					}
				}
			}
			while (!flag4);
			yield break;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00013036 File Offset: 0x00011236
		private IEnumerator StopInteractions(FemaleChar heroine, bool stopAnimPoses, bool waitForInteractionsToStop)
		{
			MassageController componentInChildren = heroine.GetComponentInChildren<MassageController>();
			HandJobController componentInChildren2 = heroine.GetComponentInChildren<HandJobController>();
			if (componentInChildren != null)
			{
				componentInChildren.DetenerOrdenes();
			}
			if (componentInChildren2 != null)
			{
				componentInChildren2.DetenerOrdenes();
			}
			yield return null;
			IInteraccionesDeCharacterFemenino interaccionesDeFemale = heroine.GetComponentEnRoot<IInteraccionesDeCharacterFemenino>();
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino in interaccionesDeFemale.interacciones)
			{
				if (((interaccionDeCharacterFemenino != null) ? interaccionDeCharacterFemenino.instancia : null) != null)
				{
					interaccionDeCharacterFemenino.instancia.Detener(false);
				}
			}
			if (waitForInteractionsToStop)
			{
				do
				{
					yield return null;
				}
				while (interaccionesDeFemale.interacciones.FirstOrDefault(delegate(InteraccionDeCharacterFemenino inter)
				{
					bool? flag;
					if (inter == null)
					{
						flag = null;
					}
					else
					{
						Interaccion instancia = inter.instancia;
						flag = ((instancia != null) ? new bool?(instancia.ejecutandose) : null);
					}
					bool? flag2 = flag;
					return flag2.GetValueOrDefault();
				}) != null);
			}
			yield return null;
			if (stopAnimPoses)
			{
				FemaleAnimController componentEnRoot = heroine.GetComponentEnRoot<FemaleAnimController>();
				if (componentEnRoot.animatedPoseID != FemaleAnimatedPoseIDs.None)
				{
					componentEnRoot.animatedPoseID = FemaleAnimatedPoseIDs.None;
					if (waitForInteractionsToStop)
					{
						yield return this.EsperarTransicionDeAnimPoses(heroine);
						yield return this.EsperarStateDeAnimPoses(heroine);
					}
					yield return null;
				}
			}
			yield break;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0001305A File Offset: 0x0001125A
		private IEnumerator StopInteractions(MaleChar hero)
		{
			IInteraccionesDeCharacterMale componentEnRoot = hero.GetComponentEnRoot<IInteraccionesDeCharacterMale>();
			if (componentEnRoot != null)
			{
				InteraccionDeCharacter interaccionDeCharacter = componentEnRoot.Obtener("tvalle.inter.MaleRestCamillaBigOpenLegs".GetHashCode());
				if (interaccionDeCharacter != null)
				{
					Interaccion instancia = interaccionDeCharacter.instancia;
					if (instancia != null)
					{
						instancia.Detener(false);
					}
				}
			}
			if (componentEnRoot != null)
			{
				InteraccionDeCharacter interaccionDeCharacter2 = componentEnRoot.Obtener("tvalle.inter.MaleRestCamillaBigClosedLegs".GetHashCode());
				if (interaccionDeCharacter2 != null)
				{
					Interaccion instancia2 = interaccionDeCharacter2.instancia;
					if (instancia2 != null)
					{
						instancia2.Detener(false);
					}
				}
			}
			yield return null;
			yield break;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00013069 File Offset: 0x00011269
		private IEnumerator CamillaSexRutine(SpaJob.GamePlayEstadoEspecifico estado, FemaleAnimatedPoseIDs animPoseToUse, string camillaID, FemaleChar heroine, MaleChar target)
		{
			IMaleSkins componentEnRoot = base.mainPlayerCharacter.GetComponentEnRoot(false);
			ModificadorDeBool maleSkinsEnabledModificador = componentEnRoot.enableHitSkinsOR.ObtenerModificadorNotNull(this);
			maleSkinsEnabledModificador.valor.valor = false;
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(false);
			actividadesManager.SetUIInputsActive(false);
			yield return this.StopFullBodyPoseRutine(heroine, 0f);
			CameraFade.FadeOutMain(0.75f);
			yield return new ManualCorrutina.TValleWaitForSeconds(0.8f);
			yield return this.ExposeConjuntoDeRopa();
			this.TeleportToGOTO(heroine, "WelcomeWorker_GoTo");
			yield return null;
			PuppetMaster malePuppet = target.GetComponentEnRoot<PuppetMaster>();
			malePuppet.mode = PuppetMaster.Mode.Disabled;
			while (malePuppet.isBlending)
			{
				yield return null;
			}
			Camilla camilla = InstantiatedSingleton<ColleccionDeCamillas>.instance.GetCamilla(camillaID, true);
			if (camilla == null)
			{
				throw new NullReferenceException("camilla is null");
			}
			IInteraccionesDeCharacterMale interaccionesDeMale = target.GetComponentEnRoot<IInteraccionesDeCharacterMale>();
			yield return this.StopFullBodyPoseRutineMale(target, 0f);
			this.TeleportToCamillaGOTO(target, "GOTO.Massage.CamillaBig.MaleOn", camillaID);
			yield return null;
			SpaJob.GamePlayEstadoEspecifico gamePlayEstadoEspecifico = estado;
			string maleInterID;
			if (gamePlayEstadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase3Oral)
			{
				if (gamePlayEstadoEspecifico - SpaJob.GamePlayEstadoEspecifico.enPhase3Sex > 1)
				{
					throw new ArgumentOutOfRangeException(estado.ToString());
				}
				maleInterID = "tvalle.inter.MaleRestCamillaBigClosedLegs";
			}
			else
			{
				maleInterID = "tvalle.inter.MaleRestCamillaBigOpenLegs";
			}
			InteraccionAdderOnRange[] maleAdders = (from inter in camilla.GetComponentsInChildren<InteracionMalePrimariaExterna>()
				select inter.GetComponentInChildren<InteraccionAdderOnRange>()).ToArray<InteraccionAdderOnRange>();
			while (!interaccionesDeMale.Contiene(maleInterID.GetHashCode()))
			{
				maleAdders.ForEach(delegate(InteraccionAdderOnRange adder)
				{
					adder.DoUpdate();
				});
				yield return null;
			}
			yield return this.EjecutarFullBodyPoseRutineMale(target, maleInterID, 10f, 10f, 1f);
			yield return new ManualCorrutina.TValleWaitForSeconds(0.1f);
			ModificadorDeBool penisBlocker = target.pene.isBlockedOR.ObtenerModificadorNotNull(this);
			penisBlocker.valor.valor = true;
			target.pene.Hide();
			yield return new ManualCorrutina.TValleWaitForSeconds(0.25f);
			string text;
			switch (estado)
			{
			case SpaJob.GamePlayEstadoEspecifico.enPhase3Oral:
				text = "GOTO.Massage.CamillaBig.OnOral";
				break;
			case SpaJob.GamePlayEstadoEspecifico.enPhase3Sex:
				text = "GOTO.Massage.CamillaBig.OnSex";
				break;
			case SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv:
				text = "GOTO.Massage.CamillaBig.Inv.OnSex";
				break;
			default:
				throw new ArgumentOutOfRangeException(estado.ToString());
			}
			this.TeleportToCamillaGOTO(heroine, text, camillaID);
			yield return null;
			heroine.GetComponentEnRoot<FemaleAnimController>().animatedPoseID = animPoseToUse;
			yield return this.EsperarTransicionDeAnimPoses(heroine);
			maleSkinsEnabledModificador.valor.valor = true;
			ModificadorDeBool modificadorDeBool = penisBlocker;
			if (modificadorDeBool != null)
			{
				modificadorDeBool.TryRemoverDeOwner(true);
			}
			target.pene.SetErectionTarget(100f);
			yield return new ManualCorrutina.TValleWaitForSeconds(0.2f);
			CameraFade.FadeInMain(1f);
			yield return this.EsperarStateDeAnimPoses(heroine);
			yield return null;
			yield return this.FixSexPoseWitCustomPose(estado, heroine, target);
			malePuppet.mode = PuppetMaster.Mode.Active;
			while (malePuppet.isBlending)
			{
				yield return null;
			}
			actividadesManager.SetUIInputsActive(true);
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(true);
			yield break;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001309D File Offset: 0x0001129D
		private IEnumerator EsperarTransicionDeAnimPoses(FemaleChar heroine)
		{
			float inTRansitionTime = 0f;
			while (!heroine.animator.IsInTransition(0) && inTRansitionTime < 2f)
			{
				yield return null;
				inTRansitionTime += Time.deltaTime;
			}
			if (inTRansitionTime >= 2f)
			{
				Debug.LogError("Heroina Animator, Never when to transition mode", this);
			}
			inTRansitionTime = 0f;
			while (heroine.animator.IsInTransition(0) && inTRansitionTime < 2f)
			{
				yield return null;
				inTRansitionTime += Time.deltaTime;
			}
			if (inTRansitionTime >= 2f)
			{
				Debug.LogError("Heroina Animator, Never stoped transitioning", this);
			}
			yield break;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x000130B3 File Offset: 0x000112B3
		private IEnumerator EsperarStateDeAnimPoses(FemaleChar heroine)
		{
			AnimatorStateInfo currentAnimatorStateInfo;
			do
			{
				yield return null;
				currentAnimatorStateInfo = heroine.animator.GetCurrentAnimatorStateInfo(0);
			}
			while (!currentAnimatorStateInfo.loop && currentAnimatorStateInfo.normalizedTime < 1f);
			yield break;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000130C2 File Offset: 0x000112C2
		private IEnumerator FixSexPoseWitCustomPose(SpaJob.GamePlayEstadoEspecifico estado, FemaleChar heroine, MaleChar target)
		{
			Singleton<SkeletonEditorMode>.instance.inputs.enabled = false;
			yield return null;
			BoneGuiable.ActivateSkeletonEditorMode(heroine, true, true);
			yield return null;
			if (estado == SpaJob.GamePlayEstadoEspecifico.enPhase3Sex || estado == SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv)
			{
				GizmoDeBoneRMInfo hipGizmoBone = Singleton<SkeletonEditorMode>.instance.skeletonActivos.First<GizmosDeSkeleton>().mainBones.First(delegate(Transform t)
				{
					GizmoDeBoneRMInfo component = t.GetComponent<GizmoDeBoneRMInfo>();
					return component != null && component.isHumanBone && component.humanBone == HumanBodyBones.Hips;
				}).GetComponent<GizmoDeBoneRMInfo>();
				GizmoDeBoneRMInfo handLGizmoBone = Singleton<SkeletonEditorMode>.instance.skeletonActivos.First<GizmosDeSkeleton>().mainBones.First(delegate(Transform t)
				{
					GizmoDeBoneRMInfo component2 = t.GetComponent<GizmoDeBoneRMInfo>();
					return component2 != null && component2.isHumanBone && component2.humanBone == HumanBodyBones.LeftHand;
				}).GetComponent<GizmoDeBoneRMInfo>();
				GizmoDeBoneRMInfo handRGizmoBone = Singleton<SkeletonEditorMode>.instance.skeletonActivos.First<GizmosDeSkeleton>().mainBones.First(delegate(Transform t)
				{
					GizmoDeBoneRMInfo component3 = t.GetComponent<GizmoDeBoneRMInfo>();
					return component3 != null && component3.isHumanBone && component3.humanBone == HumanBodyBones.RightHand;
				}).GetComponent<GizmoDeBoneRMInfo>();
				Singleton<SkeletonEditorMode>.instance.editor.Selection.Select(null, null);
				while (Singleton<SkeletonEditorMode>.instance.editor.Tools.Current != RuntimeTool.Move || !Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.IsPositionHandleEnabled || !Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.PositionHandle.gameObject.activeInHierarchy || Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.PositionHandle.Targets == null || Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.PositionHandle.Targets.Length == 0)
				{
					Singleton<SkeletonEditorMode>.instance.editor.Selection.Select(hipGizmoBone.gameObject, new Object[] { hipGizmoBone.gameObject });
					Singleton<SkeletonEditorMode>.instance.editor.Tools.Current = RuntimeTool.Move;
					Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.IsPositionHandleEnabled = true;
					yield return null;
				}
				Vector3 hipVsHoleEntranceOffset = heroine.bones.hips.transform.position - heroine.vagHole.entrada.position;
				Vector3 startAnimHipsPosition = hipGizmoBone.transform.position;
				Vector3 position2;
				Vector3 vector2;
				do
				{
					yield return null;
					Quaternion quaternion = target.pene.skinSurfaceTransform.rotation * target.armatureOrientationOffSet;
					Vector3 position = target.pene.penisLinearChain.puntoBaseTransform.position;
					float num = 0.02f * Mathf.Clamp(target.pene.worldScaleIgnorandoEreccion, 0.33f, 1.5f) * ((float)target.pene.partesEnOrden.Count + 5f);
					Vector3 vector = position + quaternion * Vector3.forward * num;
					vector = Math3d.ProjectPointOnLine(heroine.posicion, heroine.rotacion * Vector3.up, vector);
					position2 = hipGizmoBone.transform.position;
					vector2 = vector + hipVsHoleEntranceOffset;
					Vector3 vector3 = Vector3.MoveTowards(position2, vector2, Time.deltaTime * 0.05f * heroine.escala);
					Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.PositionHandle.EmulateDragTo(vector3);
				}
				while (!ExtendedMonoBehaviour.AlmostEqual(position2, vector2, 0.001f));
				Vector3 vector4 = vector2 - startAnimHipsPosition;
				Vector3 effectiveHipsDisplacement = Vector3.Lerp(Vector3.zero, vector4, (vector4.y < 0f) ? 0.3f : 0.15f);
				Singleton<SkeletonEditorMode>.instance.editor.Selection.Select(null, null);
				Singleton<SkeletonEditorMode>.instance.editor.Selection.Select(handLGizmoBone.gameObject, new Object[] { handLGizmoBone.gameObject });
				Vector3 animHandPositionToReach = handLGizmoBone.transform.position + effectiveHipsDisplacement;
				Vector3 vector5;
				do
				{
					yield return null;
					vector5 = handLGizmoBone.transform.position;
					Vector3 vector6 = Vector3.MoveTowards(vector5, animHandPositionToReach, Time.deltaTime * 0.05f * heroine.escala);
					Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.PositionHandle.EmulateDragTo(vector6);
				}
				while (!ExtendedMonoBehaviour.AlmostEqual(vector5, animHandPositionToReach, 0.001f));
				Singleton<SkeletonEditorMode>.instance.editor.Selection.Select(null, null);
				Singleton<SkeletonEditorMode>.instance.editor.Selection.Select(handRGizmoBone.gameObject, new Object[] { handRGizmoBone.gameObject });
				animHandPositionToReach = handRGizmoBone.transform.position + effectiveHipsDisplacement;
				do
				{
					yield return null;
					vector5 = handRGizmoBone.transform.position;
					Vector3 vector7 = Vector3.MoveTowards(vector5, animHandPositionToReach, Time.deltaTime * 0.05f * heroine.escala);
					Singleton<SkeletonEditorMode>.instance.runtimeSceneComponent.PositionHandle.EmulateDragTo(vector7);
				}
				while (!ExtendedMonoBehaviour.AlmostEqual(vector5, animHandPositionToReach, 0.001f));
				hipGizmoBone = null;
				handLGizmoBone = null;
				handRGizmoBone = null;
				hipVsHoleEntranceOffset = default(Vector3);
				startAnimHipsPosition = default(Vector3);
				effectiveHipsDisplacement = default(Vector3);
				animHandPositionToReach = default(Vector3);
			}
			Singleton<SkeletonEditorMode>.instance.DesactivarParaTodos(true);
			yield return null;
			Singleton<SkeletonEditorMode>.instance.inputs.enabled = true;
			yield break;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x000130DF File Offset: 0x000112DF
		private IEnumerator CamillaHandJobRutine(string camillaID, float velocity, FemaleChar heroine, MaleChar target)
		{
			HandJobController controller = heroine.GetComponentInChildren<HandJobController>();
			if (controller == null)
			{
				yield break;
			}
			yield return this.NavToCamillaGOTORutine(heroine, "GOTO.camillaHandJob", camillaID, true);
			yield return this.EjecutarFullBodyPoseRutine(heroine, "tvalle.inter.camillaHandJob", 0.5f);
			while (!controller.DoToConApoyoAutomatico(target, Side.R, velocity, Mathf.Clamp(velocity / 30f, 0f, 0.033333335f), -1f, 1, ControllerPrioridadConfig.interrumpir))
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0001310B File Offset: 0x0001130B
		private IEnumerator CamillaSideR_MassagePartRutine(string camillaID, RecorridoDeMassgeOnMaleBody.Recorrido recorrido, float velocity, ICharacter heroine, ICharacter target)
		{
			MassageController controller = heroine.GetComponentInChildren<MassageController>();
			if (controller == null)
			{
				throw new ArgumentNullException("MassageController", "MassageController null reference.");
			}
			MaleChar toDo = target.GetComponentEnRoot<MaleChar>();
			if (toDo == null)
			{
				throw new ArgumentNullException("toDo", "toDo null reference.");
			}
			string text;
			string InterID;
			switch (recorrido)
			{
			case RecorridoDeMassgeOnMaleBody.Recorrido.None:
				text = string.Empty;
				InterID = string.Empty;
				break;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Chest:
			case RecorridoDeMassgeOnMaleBody.Recorrido.Nipple:
				text = "GOTO.Massage.Shoulders";
				InterID = "tvalle.inter.massageFullBodyPose.Shoulders";
				break;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Shoulder:
				text = "GOTO.Massage.Chest";
				InterID = "tvalle.inter.massageFullBodyPose.Chest";
				break;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Abdomen:
				text = "GOTO.Massage.Abs";
				InterID = "tvalle.inter.massageFullBodyPose.Abs";
				break;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Groin:
				text = "GOTO.Massage.Groin";
				InterID = "tvalle.inter.massageFullBodyPose.Groin";
				break;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Leg:
				text = "GOTO.Massage.Legs";
				InterID = "tvalle.inter.massageFullBodyPose.Legs";
				break;
			case RecorridoDeMassgeOnMaleBody.Recorrido.Calf:
				text = "GOTO.Massage.Calf";
				InterID = "tvalle.inter.massageFullBodyPose.Calf";
				break;
			default:
				throw new ArgumentOutOfRangeException(recorrido.ToString());
			}
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(InterID))
			{
				throw new ArgumentNullException("gotoID or InterID", "gotoID or InterID null reference.");
			}
			yield return this.NavToCamillaGOTORutine(heroine, text, camillaID, true);
			yield return null;
			yield return this.EjecutarFullBodyPoseRutine(heroine as IFemaleChar, InterID, 0.666f);
			yield return null;
			while (!controller.DoToConApoyoAutomaticoLadoDerecho(toDo, recorrido, velocity, Mathf.Clamp(velocity / 25f, 0f, 0.04f), -1f, 1, ControllerPrioridadConfig.interrumpir))
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0001313F File Offset: 0x0001133F
		private IEnumerator StopFullBodyPoseRutine(IFemaleChar poser, float waitingForWeigth = 0f)
		{
			IInteraccionesDeCharacterFemenino componentEnRoot = poser.GetComponentEnRoot<IInteraccionesDeCharacterFemenino>();
			InteraccionDeCharacter interaccionDeCharacter = componentEnRoot.ObtenerFirstEjecutandosePrimaria();
			Interaccion ejecutandose = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null);
			if (ejecutandose != null && ejecutandose.ejecutandose)
			{
				ejecutandose.Detener(true);
				while (ejecutandose.currentEstado.EstadosTimerWeigthPromedio(0f) > waitingForWeigth)
				{
					yield return null;
				}
			}
			yield return null;
			yield return null;
			yield break;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00013155 File Offset: 0x00011355
		private IEnumerator EjecutarFullBodyPoseRutine(IFemaleChar poser, string InterID, float waitingForWeigth = 0.333f)
		{
			IInteraccionesDeCharacterFemenino componentEnRoot = poser.GetComponentEnRoot<IInteraccionesDeCharacterFemenino>();
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("IInteraccionesInteraccionharacterFemenino", "IInteraccionesDeCharacterFemenino null reference.");
			}
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = componentEnRoot.Obtener(InterID.GetHashCode());
			if (((interaccionDeCharacterFemenino != null) ? interaccionDeCharacterFemenino.instancia : null) == null)
			{
				throw new ArgumentNullException("Interaccion", "Interaccion null reference.");
			}
			Interaccion fullbodyInter = interaccionDeCharacterFemenino.instancia;
			while (!fullbodyInter.ejecutandose)
			{
				if (fullbodyInter.EsperandoEjecutarse())
				{
					break;
				}
				yield return null;
				fullbodyInter.Ejecutar(1, -1f, ControllerPrioridadConfig.interrumpir, 1f, 1f, true);
			}
			while (fullbodyInter.currentEstado.EstadosTimerWeigthPromedio(0f) < waitingForWeigth)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00013172 File Offset: 0x00011372
		private IEnumerator StopFullBodyPoseRutineMale(IMaleCharacter poser, float waitingForWeigth = 0f)
		{
			IInteraccionesDeCharacterMale componentEnRoot = poser.GetComponentEnRoot<IInteraccionesDeCharacterMale>();
			InteraccionDeCharacter interaccionDeCharacter = componentEnRoot.ObtenerFirstEjecutandosePrimaria();
			Interaccion ejecutandose = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null);
			if (ejecutandose != null && ejecutandose.ejecutandose)
			{
				ejecutandose.Detener(true);
				while (ejecutandose.currentEstado.EstadosTimerWeigthPromedio(0f) > waitingForWeigth)
				{
					yield return null;
				}
			}
			yield return null;
			yield return null;
			yield break;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00013188 File Offset: 0x00011388
		private IEnumerator EjecutarFullBodyPoseRutineMale(IMaleCharacter poser, string InterID, float inVelocity = 1f, float outVelocity = 1f, float waitingForWeigth = 0.333f)
		{
			IInteraccionesDeCharacterMale componentEnRoot = poser.GetComponentEnRoot<IInteraccionesDeCharacterMale>();
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("IInteraccionesInteraccionharacterFemenino", "IInteraccionesDeCharacterFemenino null reference.");
			}
			InteraccionDeCharacter interaccionDeCharacter = componentEnRoot.Obtener(InterID.GetHashCode());
			if (((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null) == null)
			{
				throw new ArgumentNullException("Interaccion", "Interaccion null reference.");
			}
			Interaccion fullbodyInter = interaccionDeCharacter.instancia;
			while (!fullbodyInter.ejecutandose)
			{
				if (fullbodyInter.EsperandoEjecutarse())
				{
					break;
				}
				yield return null;
				fullbodyInter.Ejecutar(1, -1f, ControllerPrioridadConfig.interrumpir, inVelocity, outVelocity, true);
			}
			while (fullbodyInter.currentEstado.EstadosTimerWeigthPromedio(0f) < waitingForWeigth)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000131B5 File Offset: 0x000113B5
		private IEnumerator NavToCamillaGOTORutine(ICharacter navigator, string gotoID, string camillaID, bool OnlyStrafe)
		{
			Camilla camilla = InstantiatedSingleton<ColleccionDeCamillas>.instance.GetCamilla(camillaID, true);
			if (camilla == null)
			{
				throw new NullReferenceException("camilla is null");
			}
			GoToTarget GoTo = camilla.GetGoTo(gotoID);
			GoToTarget goToTarget = GoTo;
			if (((goToTarget != null) ? goToTarget.data : null) == null)
			{
				throw new NullReferenceException("goto is null");
			}
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
			while (!Singleton<GoToScenaManager>.instance.IsOn(gotoID, animatorRootMotionTransform.position, animatorRootMotionTransform.rotation, false, 0.2f, 22.5f, false))
			{
				yield return null;
				Singleton<GoToScenaManager>.instance.NavTo(femNavegable, false, GoTo.data, 1f, 0.2f, OnlyStrafe);
				while (femNavegable.isGoingToNavite || femNavegable.isNavigating)
				{
					yield return null;
				}
			}
			yield break;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000131DC File Offset: 0x000113DC
		private bool EstaEnCamllia(FemaleChar character, out string camillaID, out string offCamillaGotoID)
		{
			offCamillaGotoID = null;
			camillaID = null;
			Transform animatorRootMotionTransform = character.animatorRootMotionTransform;
			foreach (Camilla camilla in InstantiatedSingleton<ColleccionDeCamillas>.instance.camillas)
			{
				foreach (GoToTarget goToTarget in camilla.gotos)
				{
					if (Singleton<GoToScenaManager>.instance.IsOn(goToTarget.data, animatorRootMotionTransform.position, animatorRootMotionTransform.rotation, false, 0.4f, 90f))
					{
						camillaID = camilla.id;
						break;
					}
				}
				if (camillaID != null)
				{
					break;
				}
			}
			if (camillaID == null)
			{
				return false;
			}
			if (camillaID == "TValle.Camilla.Main")
			{
				offCamillaGotoID = "GOTO.Massage.CamillaMain.FemOff";
			}
			else
			{
				if (!(camillaID == "TValle.Camilla.Big"))
				{
					throw new ArgumentOutOfRangeException();
				}
				offCamillaGotoID = "GOTO.Massage.CamillaBig.FemOff";
			}
			return true;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000132E0 File Offset: 0x000114E0
		private void TeleportToCamillaGOTO(ICharacter navigator, string gotoID, string camillaID)
		{
			Camilla camilla = InstantiatedSingleton<ColleccionDeCamillas>.instance.GetCamilla(camillaID, true);
			if (camilla == null)
			{
				throw new NullReferenceException("camilla is null");
			}
			GoToTarget goTo = camilla.GetGoTo(gotoID);
			if (((goTo != null) ? goTo.data : null) == null)
			{
				throw new NullReferenceException("goto is null");
			}
			Singleton<GoToScenaManager>.instance.Apply(navigator, false, goTo.data);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00013340 File Offset: 0x00011540
		private void TeleportToGOTO(ICharacter navigator, string gotoID)
		{
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener(gotoID);
			if (goTo == null)
			{
				throw new NullReferenceException("goto is null");
			}
			Singleton<GoToScenaManager>.instance.Apply(navigator, false, goTo);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00013374 File Offset: 0x00011574
		private void ResetInputs()
		{
			Singleton<ActividadesManager>.instance.SetUIInputsActive(true);
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(true);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0001338C File Offset: 0x0001158C
		private void ResetPlayerState()
		{
			this.ResetInputs();
			Singleton<ActividadesManager>.instance.current.mainPlayerCharacter.GetComponentEnRoot<PuppetMaster>().mode = PuppetMaster.Mode.Active;
			Singleton<SkeletonEditorMode>.instance.DesactivarParaTodos(false);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000133BC File Offset: 0x000115BC
		protected override void OnAplicar()
		{
			base.OnAplicar();
			base.StartCoroutine(this.CamillaSideR_MassagePartRutine("TValle.Camilla.Main", this.m_recorridoDEBUG, this.m_velocidadDEBUG, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character as FemaleChar, CurrentMainCharacter<CurrentMainChar, MainChar>.current.character as MaleChar));
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001340B File Offset: 0x0001160B
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Debug Massage"
			};
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00013424 File Offset: 0x00011624
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			base.StartCoroutine(this.CamillaHandJobRutine("TValle.Camilla.Main", this.m_velocidadDEBUG, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character as FemaleChar, CurrentMainCharacter<CurrentMainChar, MainChar>.current.character as MaleChar));
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00013462 File Offset: 0x00011662
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Debug Handjob"
			};
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0001347B File Offset: 0x0001167B
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			base.StartCoroutine(this.StopInteractions(CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character as FemaleChar, true, true));
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000134A1 File Offset: 0x000116A1
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Debug Stop All"
			};
		}

		// Token: 0x060003CA RID: 970 RVA: 0x000134BC File Offset: 0x000116BC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (Application.isEditor)
			{
				this.m_SpaDebugger = Object.FindAnyObjectByType<SpaDebugger>();
			}
			SpaDebugger spaDebugger = this.m_SpaDebugger;
			this.isDebugging = ((spaDebugger != null) ? new bool?(spaDebugger.activado) : null).GetValueOrDefault();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00013510 File Offset: 0x00011710
		protected override void OnAplicar6()
		{
			base.OnAplicar6();
			List<SceneCharacterFromToBuffAndDebuff> list = new List<SceneCharacterFromToBuffAndDebuff>();
			float num = 0f;
			foreach (Guid guid in this.m_clientsIDs)
			{
				ICharactersSceneInteractionsArchived mainArchivedInteractions = this.m_jobManager.interactions.GetMainArchivedInteractions(guid, this.m_jobManager.current.mainNonPlayerCharacter.ID);
				num += base.CalcularFatiga(mainArchivedInteractions);
				SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff;
				this.m_jobManager.interactions.DefaultBuffAndDebuffGenerate(guid, this.m_jobManager.current.mainNonPlayerCharacter, base.isAborted, base.date, out sceneCharacterFromToBuffAndDebuff);
				list.Add(sceneCharacterFromToBuffAndDebuff);
			}
			SceneCharacterFromToBuffAndDebuff.Combine(list);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000135E0 File Offset: 0x000117E0
		protected override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Generar Dummy Buff",
				editorTimeVisible = false
			};
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000135F9 File Offset: 0x000117F9
		private void PhaseStarting_DEBUG()
		{
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000135FC File Offset: 0x000117FC
		void RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner.AceptoMassageEnParte(ParteDelCuerpoHumano parte, RegistroDeFuncionesDeTrabajosDeModelaje sender)
		{
			this.m_MassageRequestState.finished = true;
			this.m_MassageRequestState.selected = parte;
			this.m_MassageRequestState.registro = sender;
			this.m_MassageHappySexRequestState.finished = true;
			this.m_MassageHappySexRequestState.massageAccepted = true;
			this.m_MassageHappySexRequestState.selected = parte;
			this.m_MassageHappySexRequestState.registro = sender;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001365D File Offset: 0x0001185D
		void RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner.AceptoHappyEnding(RegistroDeFuncionesDeTrabajosDeModelaje sender)
		{
			this.m_MassageHappySexRequestState.finished = true;
			this.m_MassageHappySexRequestState.happyAccepted = true;
			this.m_MassageHappySexRequestState.registro = sender;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00013684 File Offset: 0x00011884
		void RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner.AceptoGetOnTopEnding(float aceptacionOral, float aceptacionVaginal, float aceptacionAnal, RegistroDeFuncionesDeTrabajosDeModelaje sender)
		{
			this.m_MassageHappySexRequestState.finished = true;
			this.m_MassageHappySexRequestState.sexAccepted = true;
			this.m_MassageHappySexRequestState.analAceptance = aceptacionAnal;
			this.m_MassageHappySexRequestState.vagAceptance = aceptacionVaginal;
			this.m_MassageHappySexRequestState.oralAceptance = aceptacionOral;
			this.m_MassageHappySexRequestState.registro = sender;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x000136DC File Offset: 0x000118DC
		private void MenuTipIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.enPhase1 && this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.enPhase2 && this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.enPhase3;
			if (!args.esGreyOut)
			{
				args.esGreyOut = this.m_currentCountDown == null || this.m_currentCountDown.ended || this.m_currentCountDown.isWaitingForCorrutina || this.m_currentCountDown.flagedToStop;
				if (!args.esGreyOut)
				{
					ActividadesManager instance = Singleton<ActividadesManager>.instance;
					FemaleChar femaleChar = instance.current.mainNonPlayerCharacter as FemaleChar;
					Character mainPlayerCharacter = instance.current.mainPlayerCharacter;
					HandJobController componentEnRoot = femaleChar.GetComponentEnRoot<HandJobController>();
					MassageController componentEnRoot2 = femaleChar.GetComponentEnRoot<MassageController>();
					if (!componentEnRoot.AlgunaOrndeEjecutandose() && !componentEnRoot2.AlgunaOrndeEjecutandose())
					{
						args.esGreyOut = true;
					}
					if (!args.esGreyOut)
					{
						float num = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<CharacterWallet>(AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.ID, false).Current("fiat");
						args.esGreyOut = num < 5f;
					}
				}
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x000137E4 File Offset: 0x000119E4
		private void MenuMoveOnIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.enPhase1 && this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.enPhase2 && this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.enPhase3;
			if (!args.esGreyOut)
			{
				args.esGreyOut = this.m_currentCountDown == null || this.m_currentCountDown.ended || this.m_currentCountDown.flagedToStop;
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00013849 File Offset: 0x00011A49
		private void MenuGuideHerIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_estadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase3Sex && this.m_estadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv && this.m_estadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase3Oral;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00013878 File Offset: 0x00011A78
		private void OnMenuTipClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (this.m_TipCoolDonw.isOn)
			{
				return;
			}
			if (this.m_currentCountDown == null)
			{
				return;
			}
			if (this.m_currentCountDown.ended)
			{
				return;
			}
			if (this.m_currentCountDown.flagedToStop)
			{
				return;
			}
			if (this.m_currentCountDown.isWaitingForCorrutina)
			{
				return;
			}
			this.m_TipCoolDonw.ApplyNext(0.5f);
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			CharacterWallet characterWallet = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<CharacterWallet>(AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.ID, false);
			if (characterWallet.Current("fiat") < 5f)
			{
				return;
			}
			SimpleWallet simpleWallet = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<SimpleWallet>(AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.ID, false);
			if (characterWallet != null)
			{
				characterWallet.Change("fiat", -5f, "Tip");
			}
			if (simpleWallet != null)
			{
				simpleWallet.Change("fiat", 5f, AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.fullName);
			}
			this.m_currentTipTotalAmount += 5f;
			this.m_totalJobTipTotalAmount += 5f;
			ActividadesManager instance = Singleton<ActividadesManager>.instance;
			FemaleChar femaleChar = instance.current.mainNonPlayerCharacter as FemaleChar;
			MaleChar maleChar = instance.current.mainPlayerCharacter as MaleChar;
			HandJobController componentEnRoot = femaleChar.GetComponentEnRoot<HandJobController>();
			MassageController componentEnRoot2 = femaleChar.GetComponentEnRoot<MassageController>();
			ICharacterRespirador characterRespirador = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<ICharacterRespirador>(AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.ID, false);
			IEnumerator enumerator = null;
			if (this.m_estadoEspecifico == SpaJob.GamePlayEstadoEspecifico.enPhase3Happy)
			{
				if (componentEnRoot.AlgunaOrndeEjecutandose())
				{
					float num = SpaJob.GetVelocityByCurrentPropina(this.m_currentTipTotalAmount, 50f, 0.25f, 1f, 5f);
					enumerator = this.CamillaHandJobRutine("TValle.Camilla.Main", num, femaleChar, maleChar);
				}
				if (characterRespirador != null)
				{
					characterRespirador.ChangeSaturacionNext(0.5f);
				}
			}
			else
			{
				if (this.m_estadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase3Massage && this.m_estadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase1 && this.m_estadoEspecifico != SpaJob.GamePlayEstadoEspecifico.enPhase2)
				{
					Debug.LogException(new ArgumentOutOfRangeException());
					return;
				}
				if (componentEnRoot2.AlgunaOrndeEjecutandose())
				{
					float num = SpaJob.GetVelocityByCurrentPropina(this.m_currentTipTotalAmount, 30f, 0.25f, 1f, 5f);
					enumerator = this.CamillaSideR_MassagePartRutine("TValle.Camilla.Main", this.m_lastSelectedRecorrido, num, femaleChar, maleChar);
				}
				if (characterRespirador != null)
				{
					characterRespirador.ChangeSaturacionNext(2f);
				}
			}
			SpaSounds instance2 = InstantiatedSingleton<SpaSounds>.instance;
			if (instance2 != null)
			{
				AudioSource tip = instance2.tip;
				if (tip != null)
				{
					tip.Play();
				}
			}
			if (enumerator != null)
			{
				GlobalUpdater.Corrutina corrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, this, enumerator, new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
				if (this.m_currentCountDown != null)
				{
					this.m_currentCountDown.waitFor = corrutina;
				}
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00013B28 File Offset: 0x00011D28
		private void OnMenuMoveOnPhaseClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (this.m_currentCountDown == null)
			{
				return;
			}
			if (this.m_currentCountDown.ended)
			{
				return;
			}
			if (this.m_currentCountDown.flagedToStop)
			{
				return;
			}
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			this.m_currentCountDown.FlagToStop();
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00013B7B File Offset: 0x00011D7B
		private void OnMenuGuideHerClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			BoneGuiable.ActivateSkeletonEditorMode(Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter, false, false);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00013BAC File Offset: 0x00011DAC
		private static float GetVelocityByCurrentPropina(float currentTipTotalAmount, float maxTipTotalAmount, float minVelocity, float medVelocity, float maxVelocity)
		{
			float num = currentTipTotalAmount / maxTipTotalAmount;
			num = num.InInOutOutPowInverted(2f, 2f, 0.5f);
			return MathfExtension.LerpConMedio(minVelocity, medVelocity, maxVelocity, num);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00013BDD File Offset: 0x00011DDD
		private void OnEndedRutine(MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.ResetInputs();
			if (error != null)
			{
				this.RetirarPorError();
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00013BEE File Offset: 0x00011DEE
		private void OnEndedRutineMassage(SpaJob.MassageRequestState state, MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.ResetInputs();
			if (error != null)
			{
				this.RetirarPorError();
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00013C00 File Offset: 0x00011E00
		private void OnEndedRutineMassageHappySex(SpaJob.MassageHappySexRequestState state, MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.ResetInputs();
			if (error != null)
			{
				this.RetirarPorError();
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00013C12 File Offset: 0x00011E12
		private void RetirarPorError()
		{
			this.StopAllStates();
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, this, this.RetirarRutine(), null);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00013C34 File Offset: 0x00011E34
		private IEnumerator IntroduceToNewClientRutine()
		{
			this.m_currentTipTotalAmount = 0f;
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.introduciendo, true);
			yield return null;
			LoaderDeNpcMasculinos.RandomGeneratorOverrider randomGeneratorOverrider = default(LoaderDeNpcMasculinos.RandomGeneratorOverrider);
			float num = MathfExtension.InverseLerpConMedio(150f, 750f, 2500f, 149.99998f);
			float num2 = MathfExtension.InverseLerpConMedio(150f, 750f, 2500f, 599.99994f);
			float num3 = Random.value.InInOutOutPowInverted(2f, 2f, 0.5f);
			float num4 = Mathf.Lerp(num, num2, num3);
			randomGeneratorOverrider.money = new float?(num4);
			randomGeneratorOverrider.moneyMod = new float?(0.26666668f);
			randomGeneratorOverrider.clothes = new float?(num3);
			randomGeneratorOverrider.pleasureGain = new float?(Mathf.Lerp(0.25f, 1f, Random.value));
			randomGeneratorOverrider.pleasureInterExp = new float?(Mathf.Lerp(0.25f, 1f, Random.value));
			randomGeneratorOverrider.pleasureInterInc = new float?(Mathf.Lerp(0f, 0.75f, Random.value));
			randomGeneratorOverrider.pleasureMaxValue = new float?(Mathf.Lerp(0.5f, 1f, Random.value));
			randomGeneratorOverrider.eyacTimes = new float?(Mathf.Lerp(0.25f, 1f, Random.value));
			randomGeneratorOverrider.eyacAmount = new float?(Mathf.Lerp(0.25f, 1f, Random.value));
			Action<SceneCharacter> action = delegate(SceneCharacter sc)
			{
				CharacterWallet componentEnRoot2 = sc.GetComponentEnRoot(false);
				if (componentEnRoot2 != null)
				{
					componentEnRoot2.msgChanges = false;
				}
			};
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("WelcomeClient_GoTo");
			yield return base.GenerarMaleCharacter(goTo.transform.position, goTo.transform.forward, randomGeneratorOverrider, null, action, true, null);
			yield return this.WaitForContractable();
			this.GenerarBuffDeConsentPorContrato();
			yield return null;
			this.OnHeroLoaded_DEBUG();
			Singleton<ActividadesManager>.instance.AddExtraComponentsAndConfigToPlayerCharacter();
			yield return null;
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(false);
			this.m_clientsIDs.Add(actividadesManager.current.mainPlayerCharacter.ID_Unico);
			if (this.m_clientsIDs.Last<Guid>() == Guid.Empty)
			{
				Debug.LogError("Clien ID was not generated");
			}
			CameraFade.FadeInMain(0.75f);
			bool flag = !this.isDebugging || !this.m_SpaDebugger.ignoreWelcomeDialogue;
			string welcomeConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.welcome");
			if (flag)
			{
				while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, welcomeConversation))
				{
					yield return null;
				}
			}
			IAnimatorCharacter componentEnRoot = this.m_jobManager.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Singleton<CurrentMainChar>.instance.camara.Ver(componentEnRoot.bones.head.posicionFinal);
			CharacterRotationMode componentInChildren = this.m_jobManager.current.mainPlayerCharacter.GetComponentInChildren<CharacterRotationMode>();
			if (componentInChildren != null)
			{
				componentInChildren.ForzarBodyRotationPor(2f);
			}
			actividadesManager.SetUIInputsActive(true);
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			IRopaManager ropa = base.mainPlayerCharacter.GetComponentEnRoot(false);
			while (ropa.isLoadingConjunto)
			{
				yield return null;
			}
			this.GenerarObjetives();
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(true);
			this.m_esperandoCamilla = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.WaitForPlayerToTheStretcherRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00013C43 File Offset: 0x00011E43
		private IEnumerator WaitForPlayerToTheStretcherRutine()
		{
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.esperandoCamilla, true);
			yield return null;
			IInteraccionesDeCharacter inters = base.mainPlayerCharacter.GetComponentEnRoot(false);
			while (!inters.EstaEjecutandose("tvalle.inter.MaleRestCamilla".GetHashCode()))
			{
				yield return null;
			}
			base.mainPlayerCharacter.GetComponentEnRoot(false).enableHitSkinsOR.ObtenerModificadorNotNull(this).valor.valor = true;
			yield return this.NavToCamillaGOTORutine(Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter, "GOTO.Massage.Groin", "TValle.Camilla.Main", false);
			this.m_esperandoRopaYCamilla = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update3, this, this.WaitForPlayerToGetNakedAndToTheStretcherRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00013C52 File Offset: 0x00011E52
		private IEnumerator WaitForPlayerToGetNakedAndToTheStretcherRutine()
		{
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.esperandoRopaYCamilla, true);
			yield return null;
			IRopaManager ropa = base.mainPlayerCharacter.GetComponentEnRoot(false);
			IInteraccionesDeCharacter inters = base.mainPlayerCharacter.GetComponentEnRoot(false);
			while (!inters.EstaEjecutandose("tvalle.inter.MaleRestCamilla".GetHashCode()))
			{
				yield return null;
			}
			int cubriendoFlags;
			int num;
			do
			{
				yield return null;
				cubriendoFlags = (int)ropa.cubriendoFlags;
				num = 2048;
			}
			while (cubriendoFlags.HasFlag(num));
			ropa.OcultarPiezasCubriendo((RopaCubre)(-1), true, null);
			if (this.isDebugging && this.m_SpaDebugger.startWithEnding != SpaDebugger.StartWithEnding.Default)
			{
				this.m_MassageHappySexRequestState.Clear();
				RegistroDeFuncionesDeTrabajosDeModelaje registroDeFuncionesDeTrabajosDeModelaje = CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>();
				switch (this.m_SpaDebugger.startWithEnding)
				{
				case SpaDebugger.StartWithEnding.MassageEnding:
					((RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner)this).AceptoMassageEnParte(ParteDelCuerpoHumano.vientreBajo, registroDeFuncionesDeTrabajosDeModelaje);
					this.m_enPhase3Massage = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3MassageRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
					break;
				case SpaDebugger.StartWithEnding.HappyEnding:
					((RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner)this).AceptoHappyEnding(registroDeFuncionesDeTrabajosDeModelaje);
					this.m_enPhase3Happy = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3HappyRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
					break;
				case SpaDebugger.StartWithEnding.OralEnding:
					((RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner)this).AceptoGetOnTopEnding(1f, -1f, -1f, registroDeFuncionesDeTrabajosDeModelaje);
					this.m_enPhase3AnySex = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3AnySexRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
					break;
				case SpaDebugger.StartWithEnding.SexVaginalEnding:
					((RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner)this).AceptoGetOnTopEnding(-1f, 1f, -1f, registroDeFuncionesDeTrabajosDeModelaje);
					this.m_enPhase3AnySex = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3AnySexRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
					break;
				case SpaDebugger.StartWithEnding.SexAnalEnding:
					((RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner)this).AceptoGetOnTopEnding(-1f, -1f, 1f, registroDeFuncionesDeTrabajosDeModelaje);
					this.m_enPhase3AnySex = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3AnySexRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
					break;
				default:
					throw new ArgumentOutOfRangeException(this.m_SpaDebugger.startWithEnding.ToString());
				}
				yield break;
			}
			base.mainPlayerCharacter.GetComponentEnRoot(false).enabled = false;
			this.m_MassageRequestState.Clear();
			this.m_enPhase1 = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageRequestState, this, this.Face1Rutine(this.m_MassageRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassage));
			yield break;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00013C61 File Offset: 0x00011E61
		private IEnumerator Face1Rutine(SpaJob.MassageRequestState requestState)
		{
			this.m_currentTipTotalAmount *= 0.5f;
			this.PhaseStarting_DEBUG();
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase1, false);
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.phase1");
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive || !requestState.finished)
			{
				yield return null;
			}
			this.ChangeContractByStado(SpaJob.GamePlayEstadoEspecifico.enPhase1);
			requestState.registro.GenerarAgreementDeTratoMassage();
			ParteDelCuerpoHumano selected = requestState.selected;
			if (selected != ParteDelCuerpoHumano.hombros)
			{
				if (selected != ParteDelCuerpoHumano.canillas)
				{
					throw new ArgumentOutOfRangeException(requestState.selected.ToString());
				}
				this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Calf;
			}
			else
			{
				this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Shoulder;
			}
			float velocityByCurrentPropina = SpaJob.GetVelocityByCurrentPropina(this.m_currentTipTotalAmount, 30f, 0.25f, 1f, 5f);
			yield return this.CamillaSideR_MassagePartRutine("TValle.Camilla.Main", this.m_lastSelectedRecorrido, velocityByCurrentPropina, actividadesManager.current.mainNonPlayerCharacter, actividadesManager.current.mainPlayerCharacter);
			SpaJob.PhaseEndCountDown.Replace(ref this.m_currentCountDown, this.massageDuration);
			yield return this.EsperandoPhaceEndMassage(this.m_currentCountDown, false);
			this.m_currentCountDown = null;
			yield return this.StopInteractions(base.mainNonPlayerCharacter.GetComponent<FemaleChar>(), true, false);
			requestState.registro.BorrarAgreementDeTrato();
			requestState.Clear();
			this.m_enPhase2 = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageRequestState>(GlobalUpdater.UpdateType.update2, requestState, this, this.Face2Rutine(requestState), new GlobalUpdater.Corrutina<SpaJob.MassageRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassage));
			yield break;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00013C77 File Offset: 0x00011E77
		private IEnumerator Face2Rutine(SpaJob.MassageRequestState requestState)
		{
			this.m_currentTipTotalAmount *= 0.5f;
			this.PhaseStarting_DEBUG();
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase2, false);
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.phase2");
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive || !requestState.finished)
			{
				yield return null;
			}
			this.ChangeContractByStado(SpaJob.GamePlayEstadoEspecifico.enPhase1);
			requestState.registro.GenerarAgreementDeTratoMassage();
			ParteDelCuerpoHumano selected = requestState.selected;
			if (selected != ParteDelCuerpoHumano.pecho)
			{
				if (selected != ParteDelCuerpoHumano.abdomen)
				{
					if (selected != ParteDelCuerpoHumano.piernas)
					{
						throw new ArgumentOutOfRangeException(requestState.selected.ToString());
					}
					this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Leg;
				}
				else
				{
					this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Abdomen;
				}
			}
			else
			{
				this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Chest;
			}
			float velocityByCurrentPropina = SpaJob.GetVelocityByCurrentPropina(this.m_currentTipTotalAmount, 30f, 0.25f, 1f, 5f);
			yield return this.CamillaSideR_MassagePartRutine("TValle.Camilla.Main", this.m_lastSelectedRecorrido, velocityByCurrentPropina, actividadesManager.current.mainNonPlayerCharacter, actividadesManager.current.mainPlayerCharacter);
			SpaJob.PhaseEndCountDown.Replace(ref this.m_currentCountDown, this.massageDuration);
			yield return this.EsperandoPhaceEndMassage(this.m_currentCountDown, false);
			this.m_currentCountDown = null;
			yield return this.StopInteractions(base.mainNonPlayerCharacter.GetComponent<FemaleChar>(), true, false);
			requestState.registro.BorrarAgreementDeTrato();
			requestState.Clear();
			this.m_MassageHappySexRequestState.Clear();
			this.m_enPhase3 = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update3, this.m_MassageHappySexRequestState, this, this.Face3Rutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
			yield break;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00013C8D File Offset: 0x00011E8D
		private IEnumerator Face3Rutine(SpaJob.MassageHappySexRequestState requestState)
		{
			this.m_currentTipTotalAmount *= 0.5f;
			this.PhaseStarting_DEBUG();
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase3, true);
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.phase3");
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive || !requestState.finished)
			{
				yield return null;
			}
			if (requestState.sexAccepted)
			{
				this.m_enPhase3AnySex = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3AnySexRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
			}
			else if (requestState.happyAccepted)
			{
				this.m_enPhase3Happy = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3HappyRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
			}
			else
			{
				if (!requestState.massageAccepted)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.m_enPhase3Massage = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3MassageRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
			}
			yield break;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00013CA3 File Offset: 0x00011EA3
		private IEnumerator Face3MassageRutine(SpaJob.MassageHappySexRequestState requestState)
		{
			this.PhaseStarting_DEBUG();
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase3Massage, true);
			requestState.registro.GenerarAgreementDeTratoMassage();
			ParteDelCuerpoHumano selected = requestState.selected;
			if (selected != ParteDelCuerpoHumano.pezones)
			{
				if (selected != ParteDelCuerpoHumano.vientreBajo)
				{
					throw new ArgumentOutOfRangeException(requestState.selected.ToString());
				}
				this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Groin;
			}
			else
			{
				this.m_lastSelectedRecorrido = RecorridoDeMassgeOnMaleBody.Recorrido.Nipple;
			}
			ActividadesManager instance = Singleton<ActividadesManager>.instance;
			float velocityByCurrentPropina = SpaJob.GetVelocityByCurrentPropina(this.m_currentTipTotalAmount, 30f, 0.25f, 1f, 5f);
			yield return this.CamillaSideR_MassagePartRutine("TValle.Camilla.Main", this.m_lastSelectedRecorrido, velocityByCurrentPropina, instance.current.mainNonPlayerCharacter, instance.current.mainPlayerCharacter);
			SpaJob.PhaseEndCountDown.Replace(ref this.m_currentCountDown, this.massageDuration);
			yield return this.EsperandoPhaceEndMassage(this.m_currentCountDown, true);
			this.m_currentCountDown = null;
			this.m_despachadoPorTiempo = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.EsperandoRetirarsePorTiempoRutine(SpaJob.GamePlayEstadoEspecifico.enPhase3Massage), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00013CB9 File Offset: 0x00011EB9
		private IEnumerator Face3HappyRutine(SpaJob.MassageHappySexRequestState requestState)
		{
			this.PhaseStarting_DEBUG();
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase3Happy, true);
			requestState.registro.GenerarAgreementDeTratoMassage();
			ActividadesManager instance = Singleton<ActividadesManager>.instance;
			float velocityByCurrentPropina = SpaJob.GetVelocityByCurrentPropina(this.m_currentTipTotalAmount, 50f, 0.25f, 1f, 5f);
			yield return this.CamillaHandJobRutine("TValle.Camilla.Main", velocityByCurrentPropina, instance.current.mainNonPlayerCharacter as FemaleChar, instance.current.mainPlayerCharacter as MaleChar);
			SpaJob.PhaseEndCountDown.Replace(ref this.m_currentCountDown, this.happyDuration);
			yield return this.EsperandoPhaceEndMassage(this.m_currentCountDown, true);
			this.m_currentCountDown = null;
			this.m_despachadoPorTiempo = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.EsperandoRetirarsePorTiempoRutine(SpaJob.GamePlayEstadoEspecifico.enPhase3Happy), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00013CCF File Offset: 0x00011ECF
		private IEnumerator Face3AnySexRutine(SpaJob.MassageHappySexRequestState requestState)
		{
			this.PhaseStarting_DEBUG();
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			bool flag = requestState.oralAceptance >= requestState.vagAceptance && requestState.oralAceptance >= requestState.analAceptance;
			bool flag2 = requestState.vagAceptance >= requestState.oralAceptance && requestState.vagAceptance >= requestState.analAceptance;
			FemaleAnimatedPoseIDs animPoseToUse;
			if (requestState.analAceptance >= requestState.oralAceptance && requestState.analAceptance >= requestState.vagAceptance)
			{
				animPoseToUse = FemaleAnimatedPoseIDs.camillaCowInv;
			}
			else if (flag2)
			{
				animPoseToUse = FemaleAnimatedPoseIDs.camillaCow;
			}
			else
			{
				if (!flag)
				{
					Debug.LogError("no se pudo definir q calse de GetON es");
					this.m_enPhase3Massage = GlobalUpdater.instancia.StartCorrutinaOnEvent<SpaJob.MassageHappySexRequestState>(GlobalUpdater.UpdateType.update1, this.m_MassageHappySexRequestState, this, this.Face3MassageRutine(this.m_MassageHappySexRequestState), new GlobalUpdater.Corrutina<SpaJob.MassageHappySexRequestState>.OnEndedHandlerConEstado(this.OnEndedRutineMassageHappySex));
					yield break;
				}
				float escala = actividadesManager.current.mainNonPlayerCharacter.escala;
				if (actividadesManager.current.mainPlayerCharacter.escala >= 1f && escala <= 1f)
				{
					animPoseToUse = FemaleAnimatedPoseIDs.camillaOralSmall;
				}
				else
				{
					animPoseToUse = FemaleAnimatedPoseIDs.camillaOralBig;
				}
			}
			float duration;
			switch (animPoseToUse)
			{
			case FemaleAnimatedPoseIDs.camillaOralSmall:
			case FemaleAnimatedPoseIDs.camillaOralBig:
				this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase3Oral, true);
				requestState.registro.GenerarAgreementDeTratoExplicitoOral();
				duration = this.oralDuration;
				break;
			case FemaleAnimatedPoseIDs.camillaCow:
				this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase3Sex, true);
				requestState.registro.GenerarAgreementDeTratoExplicitoVag();
				duration = this.sexDuration;
				break;
			case FemaleAnimatedPoseIDs.camillaCowInv:
				this.SetEstado(SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv, true);
				requestState.registro.GenerarAgreementDeTratoExplicitoAnal();
				duration = this.sexDuration;
				break;
			default:
				throw new ArgumentOutOfRangeException(animPoseToUse.ToString());
			}
			yield return null;
			SpaJob.GamePlayEstadoEspecifico fromEstado = this.m_estadoEspecifico;
			yield return null;
			CharacterWallet characterWallet = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<CharacterWallet>(AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.ID, false);
			SimpleWallet simpleWallet = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<SimpleWallet>(AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.ID, false);
			float valueOrDefault = ((characterWallet != null) ? new float?(characterWallet.Current("fiat")) : null).GetValueOrDefault();
			if (characterWallet != null)
			{
				characterWallet.Change("fiat", -valueOrDefault, "Tip");
			}
			if (simpleWallet != null)
			{
				simpleWallet.Change("fiat", valueOrDefault, AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.fullName);
			}
			this.m_currentTipTotalAmount += valueOrDefault;
			this.m_totalJobTipTotalAmount += valueOrDefault;
			SpaSounds instance = InstantiatedSingleton<SpaSounds>.instance;
			if (instance != null)
			{
				AudioSource tip = instance.tip;
				if (tip != null)
				{
					tip.Play();
				}
			}
			yield return this.CamillaSexRutine(this.m_estadoEspecifico, animPoseToUse, "TValle.Camilla.Big", actividadesManager.current.mainNonPlayerCharacter as FemaleChar, actividadesManager.current.mainPlayerCharacter as MaleChar);
			ICharacterRespirador characterRespirador = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<ICharacterRespirador>(AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.ID, false);
			if (characterRespirador != null)
			{
				characterRespirador.ChangeSaturacionNext(-5f);
			}
			SpaJob.PhaseEndCountDown.Replace(ref this.m_currentCountDown, duration);
			yield return this.EsperandoPhaceEndSex(this.m_currentCountDown, true);
			this.m_currentCountDown = null;
			this.m_despachadoPorSex = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.EsperandoRetirarsePorSexRutine(fromEstado), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00013CE5 File Offset: 0x00011EE5
		private IEnumerator EsperandoPhaceEndMassage(SpaJob.PhaseEndCountDown countDown, bool isLastPhase)
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(1f);
			countDown.startTime = Time.time;
			while (Time.time - countDown.startTime < countDown.duration)
			{
				yield return w;
				if (countDown.flagedToStop)
				{
					if (isLastPhase)
					{
						SpaSounds instance = InstantiatedSingleton<SpaSounds>.instance;
						AudioSource audioSource = ((instance != null) ? instance.alarm : null);
						if (audioSource != null && !audioSource.isPlaying)
						{
							audioSource.Play();
						}
					}
					IL_0152:
					while (countDown.isWaitingForCorrutina)
					{
						yield return w;
					}
					countDown.SetEnded();
					yield break;
				}
				if (countDown.startTime + countDown.duration - Time.time < 5f && isLastPhase)
				{
					this.m_flagCantRestoreOutfit = true;
					SpaSounds instance2 = InstantiatedSingleton<SpaSounds>.instance;
					AudioSource audioSource2 = ((instance2 != null) ? instance2.alarm : null);
					if (audioSource2 != null && !audioSource2.isPlaying)
					{
						audioSource2.Play();
					}
				}
			}
			goto IL_0152;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00013D02 File Offset: 0x00011F02
		private IEnumerator EsperandoPhaceEndSex(SpaJob.PhaseEndCountDown countDown, bool isLastPhase)
		{
			Debug.LogError("reproducir sonido de golpear puerta si es la ultima phase y esta apunto de acabar");
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(0.5f);
			countDown.startTime = Time.time;
			while (Singleton<SkeletonEditorMode>.instance.activado || Time.time - countDown.startTime < countDown.duration)
			{
				yield return w;
				if (countDown.flagedToStop)
				{
					if (isLastPhase)
					{
						SpaSounds instance = InstantiatedSingleton<SpaSounds>.instance;
						AudioSource audioSource = ((instance != null) ? instance.alarm : null);
						if (audioSource != null && !audioSource.isPlaying)
						{
							audioSource.Play();
						}
					}
					IL_01DD:
					while (countDown.isWaitingForCorrutina)
					{
						yield return w;
					}
					countDown.SetEnded();
					yield break;
				}
				FemaleChar femaleChar = actividadesManager.current.mainNonPlayerCharacter as FemaleChar;
				if ((!femaleChar.vagHole.isPenetrated && !femaleChar.anusHole.isPenetrated && !femaleChar.bocaHole.isPenetrated) || Singleton<SkeletonEditorMode>.instance.activado)
				{
					countDown.startTime += 0.5f;
				}
				if (countDown.startTime + countDown.duration - Time.time < 5f && isLastPhase)
				{
					this.m_flagCantRestoreOutfit = true;
					SpaSounds instance2 = InstantiatedSingleton<SpaSounds>.instance;
					AudioSource audioSource2 = ((instance2 != null) ? instance2.alarm : null);
					if (audioSource2 != null && !audioSource2.isPlaying)
					{
						audioSource2.Play();
					}
				}
			}
			goto IL_01DD;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00013D1F File Offset: 0x00011F1F
		private IEnumerator EsperandoRetirarsePorMaxEmocionNegativaRutine(Emotion emotion, SpaJob.GamePlayEstadoEspecifico fromEstado)
		{
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorEmoNegativa, true);
			this.despachadosPorEmoNegativa++;
			MaleChar male = base.mainPlayerCharacter.GetComponent<MaleChar>();
			FemaleChar fem = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			male.GetComponentEnRoot<PuppetMaster>();
			yield return this.StopServicing(fem, male, false, false);
			yield return this.GetBothOffCamillaFadingCamera(fem, male, fromEstado);
			string text;
			switch (emotion)
			{
			case Emotion.disappointment:
				text = "spa.boredMax";
				break;
			case Emotion.rage:
				text = "spa.rageMax";
				break;
			case Emotion.pain:
				text = "spa.painMax";
				break;
			case Emotion.fear:
				text = "spa.fearMax";
				break;
			default:
				throw new ArgumentOutOfRangeException(emotion.ToString());
			}
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(text);
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.RetirarRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00013D3C File Offset: 0x00011F3C
		private IEnumerator EsperandoRetirarsePorSexRutine(SpaJob.GamePlayEstadoEspecifico fromEstado)
		{
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorSex, true);
			this.despachadosPorSex++;
			yield return null;
			FemaleChar fem = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			MaleChar male = base.mainPlayerCharacter.GetComponent<MaleChar>();
			FemaleChar femaleChar = fem;
			MaleChar maleChar = male;
			bool flag = true;
			SemenParaPene componentEnRoot = male.GetComponentEnRoot<SemenParaPene>();
			yield return this.StopServicing(femaleChar, maleChar, flag, ((componentEnRoot != null) ? new bool?(componentEnRoot.eyaculando) : null).GetValueOrDefault());
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.SexEnded");
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			yield return this.GetBothOffCamillaFadingCamera(fem, male, fromEstado);
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.RetirarRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00013D52 File Offset: 0x00011F52
		private IEnumerator EsperandoRetirarsePorTiempoRutine(SpaJob.GamePlayEstadoEspecifico fromEstado)
		{
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorTiempo, true);
			this.despachadosPorTiempo++;
			yield return null;
			FemaleChar fem = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			MaleChar male = base.mainPlayerCharacter.GetComponent<MaleChar>();
			yield return this.StopServicing(fem, male, true, false);
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.TimeUp");
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			yield return this.GetBothOffCamillaFadingCamera(fem, male, fromEstado);
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.RetirarRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00013D68 File Offset: 0x00011F68
		private IEnumerator EsperandoRetirarsePorSatisfechoRutine(SpaJob.GamePlayEstadoEspecifico fromEstado)
		{
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorSatisfecho, true);
			this.despachadosPorSatisfecho++;
			yield return null;
			FemaleChar fem = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			MaleChar male = base.mainPlayerCharacter.GetComponent<MaleChar>();
			yield return this.StopServicing(fem, male, true, true);
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("spa.Eyaculated");
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			yield return this.GetBothOffCamillaFadingCamera(fem, male, fromEstado);
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.RetirarRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00013D7E File Offset: 0x00011F7E
		private IEnumerator RetirarRutine()
		{
			SpaSounds instance = InstantiatedSingleton<SpaSounds>.instance;
			if (instance != null)
			{
				AudioSource alarm = instance.alarm;
				if (alarm != null)
				{
					alarm.Stop();
				}
			}
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.retirando, true);
			FemaleChar fem = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			MaleChar male = base.mainPlayerCharacter.GetComponent<MaleChar>();
			yield return this.StopServicing(fem, male, true, true);
			yield return this.StopInteractions(fem, true, true);
			yield return this.StopFullBodyPoseRutineMale(male, 0f);
			base.mainPlayerCharacter.GetComponentEnRoot(false).enableHitSkinsOR.ObtenerModificadorNotNull(this).TryRemoverDeOwner(true);
			Penis componentEnRoot = base.mainPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot != null)
			{
				ModificableDeFloat erectionModificable = componentEnRoot.erectionModificable;
				if (erectionModificable != null)
				{
					erectionModificable.RemoverModificador(this);
				}
			}
			RegistroDeFuncionesDeTrabajosDeModelaje registroDeFuncionesDeTrabajosDeModelaje = CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>();
			if (registroDeFuncionesDeTrabajosDeModelaje != null)
			{
				registroDeFuncionesDeTrabajosDeModelaje.BorrarAgreementDeTrato();
			}
			yield return null;
			male.gameObject.SetActive(false);
			yield return null;
			this.m_jobManager.DeleteAndDestroyCharacter(this.m_mainPlayerCharacterID);
			yield return null;
			this.m_clientsToGo--;
			if (this.m_clientsToGo <= 0)
			{
				DialogueManager.Instance.StopConversation();
				AsyncSingleton<JobsManager>.instance.EndCurrentJob(null);
				yield break;
			}
			this.SetEstado(SpaJob.GamePlayEstadoEspecifico.None, true);
			GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, this, this.Restart(), null);
			this.StopAllStates();
			yield break;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00013D8D File Offset: 0x00011F8D
		private IEnumerator Restart()
		{
			yield return null;
			CameraFade.FadeOutMain(0.75f);
			yield return new ManualCorrutina.TValleWaitForSeconds(0.8f);
			if (!this.m_flagCantRestoreOutfit)
			{
				yield return this.RestoreConjuntoDeRopa();
			}
			else
			{
				yield return this.CoverExposedParts();
			}
			this.m_flagCantRestoreOutfit = false;
			yield return null;
			FemaleChar component = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			this.TeleportToGOTO(component, "WelcomeWorker_GoTo");
			yield return this.ResetMainCamera();
			yield return null;
			this.m_introduciendo = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.IntroduceToNewClientRutine(), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			yield break;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00013D9C File Offset: 0x00011F9C
		private IEnumerator StopServicing(FemaleChar fem, MaleChar male, bool waitEyaculation, bool killPenis)
		{
			if (waitEyaculation)
			{
				SemenParaPene semenParaPene = male.GetComponentEnRoot<SemenParaPene>();
				for (;;)
				{
					SemenParaPene semenParaPene2 = semenParaPene;
					if (!((semenParaPene2 != null) ? new bool?(semenParaPene2.eyaculando) : null).GetValueOrDefault())
					{
						break;
					}
					yield return null;
				}
				semenParaPene = null;
			}
			Penis penis = base.mainPlayerCharacter.GetComponentEnRoot(false);
			if (killPenis)
			{
				penis.erectionModificable.ObtenerModificadorNotNull(this).valor.valor = 0f;
			}
			bool waitALiitle = false;
			HandJobController handJobController = fem.GetComponentEnRoot<HandJobController>();
			HandJobController.Orden orden;
			while (handJobController.currentStado.Ejecutandose(0, out orden) && orden.velocidad > 0.25f)
			{
				orden.velocidad = -orden.velocidad * Time.deltaTime * 0.333f;
				waitALiitle = true;
				yield return null;
			}
			MassageController massageController = fem.GetComponentEnRoot<MassageController>();
			MassageController.Orden orden2;
			while (massageController.currentStado.Ejecutandose(0, out orden2) && orden2.velocidad > 0.25f)
			{
				orden2.velocidad = -orden2.velocidad * Time.deltaTime * 0.333f;
				yield return null;
			}
			ControlladorDeAutoSexV2 autoSexController = fem.GetComponentEnRoot<ControlladorDeAutoSexV2>();
			ControlladorDeAutoSexV2.Orden orden3;
			while (autoSexController.currentStado.Ejecutandose(0, out orden3) && orden3.weight > 0f)
			{
				orden3.weight = -orden3.weight * Time.deltaTime * 0.333f;
				orden3.weight = Mathf.Clamp01(orden3.weight);
				yield return null;
			}
			if (killPenis)
			{
				while (penis.currentRealErectionValue > 1f)
				{
					yield return null;
				}
			}
			if (waitALiitle)
			{
				yield return new ManualCorrutina.TValleWaitForSeconds(5f);
			}
			while (fem.vagHole.isPenetrated || fem.anusHole.isPenetrated || fem.bocaHole.isPenetrated)
			{
				fem.vagHole.ExpulsarPenes();
				fem.anusHole.ExpulsarPenes();
				fem.bocaHole.ExpulsarPenes();
				yield return null;
			}
			yield return this.StopInteractions(fem, false, false);
			yield break;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00013DC8 File Offset: 0x00011FC8
		private IEnumerator GetBothOffCamillaFadingCamera(FemaleChar fem, MaleChar male, SpaJob.GamePlayEstadoEspecifico fromEstado)
		{
			PuppetMaster malePuppet = male.GetComponentEnRoot<PuppetMaster>();
			IMaleSkins maleSkins = base.mainPlayerCharacter.GetComponentEnRoot(false);
			bool estaEnCamillaGrande = fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase3Sex || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase3Oral;
			bool estaEnCamillaPeque = fromEstado == SpaJob.GamePlayEstadoEspecifico.esperandoRopaYCamilla || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase1 || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase2 || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase3 || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase3Massage || fromEstado == SpaJob.GamePlayEstadoEspecifico.enPhase3Happy;
			bool fadeInCamera;
			if (estaEnCamillaGrande)
			{
				fadeInCamera = true;
				CameraFade.FadeOutMain(0.75f);
				yield return new ManualCorrutina.TValleWaitForSeconds(0.8f);
				maleSkins.enableHitSkinsOR.ObtenerModificadorNotNull(this).valor.valor = false;
				malePuppet.mode = PuppetMaster.Mode.Disabled;
				while (malePuppet.isBlending)
				{
					yield return null;
				}
				yield return this.StopInteractions(fem, true, true);
			}
			else if (estaEnCamillaPeque)
			{
				yield return this.StopInteractions(fem, true, true);
				fadeInCamera = true;
				CameraFade.FadeOutMain(0.75f);
				yield return new ManualCorrutina.TValleWaitForSeconds(0.8f);
				maleSkins.enableHitSkinsOR.ObtenerModificadorNotNull(this).valor.valor = false;
			}
			else
			{
				yield return this.StopInteractions(fem, true, true);
				fadeInCamera = false;
			}
			string text;
			string text2;
			if ((estaEnCamillaGrande || estaEnCamillaPeque) && this.EstaEnCamllia(fem, out text, out text2))
			{
				this.TeleportToCamillaGOTO(fem, text2, text);
				yield return null;
			}
			yield return this.StopFullBodyPoseRutineMale(male, 0f);
			malePuppet.mode = PuppetMaster.Mode.Active;
			while (malePuppet.isBlending)
			{
				yield return null;
			}
			yield return null;
			if (fadeInCamera)
			{
				CameraFade.FadeInMain(0.75f);
			}
			yield break;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00013DEC File Offset: 0x00011FEC
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00013DF0 File Offset: 0x00011FF0
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			if (DialogueManager.IsConversationActive)
			{
				return false;
			}
			if (emotion - Emotion.disappointment > 3)
			{
				return true;
			}
			SpaJob.GamePlayEstadoEspecifico estadoEspecifico = this.m_estadoEspecifico;
			this.StopAllGamePlayStates();
			if (this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.despachando && this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.retirando && (this.m_despachadoPorEmoNegativa == null || !this.m_despachadoPorEmoNegativa.alive))
			{
				this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorEmoNegativa, true);
				this.m_despachadoPorEmoNegativa = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.EsperandoRetirarsePorMaxEmocionNegativaRutine(emotion, estadoEspecifico), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
			}
			return this.m_estadoGeneral == SpaJob.GamePlayEstadoGeneral.retirando;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00013E7A File Offset: 0x0001207A
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00013E7C File Offset: 0x0001207C
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			if (DialogueManager.IsConversationActive)
			{
				return false;
			}
			if (emotion != Emotion.pleasure)
			{
				return true;
			}
			SpaJob.GamePlayEstadoEspecifico estadoEspecifico = this.m_estadoEspecifico;
			this.StopAllGamePlayStates();
			if (this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.despachando && this.m_estadoGeneral != SpaJob.GamePlayEstadoGeneral.retirando)
			{
				if (this.m_estadoEspecifico == SpaJob.GamePlayEstadoEspecifico.enPhase3Sex || this.m_estadoEspecifico == SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv || this.m_estadoEspecifico == SpaJob.GamePlayEstadoEspecifico.enPhase3Oral)
				{
					if (this.m_despachadoPorSex == null || !this.m_despachadoPorSex.alive)
					{
						this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorSex, true);
						this.m_despachadoPorSex = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.EsperandoRetirarsePorSexRutine(estadoEspecifico), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
					}
				}
				else if (this.m_despachadoPorSatisfecho == null || !this.m_despachadoPorSatisfecho.alive)
				{
					this.SetEstado(SpaJob.GamePlayEstadoEspecifico.despachadoPorSatisfecho, true);
					this.m_despachadoPorSatisfecho = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.EsperandoRetirarsePorSatisfechoRutine(estadoEspecifico), new ManualCorrutina.OnEndedHandler(this.OnEndedRutine));
				}
			}
			return this.m_estadoGeneral == SpaJob.GamePlayEstadoGeneral.retirando;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00013F6C File Offset: 0x0001216C
		private void StopAllGamePlayStates()
		{
			if (this.m_currentCountDown != null)
			{
				this.m_currentCountDown.SetEnded();
			}
			GlobalUpdater.Corrutina introduciendo = this.m_introduciendo;
			if (((introduciendo != null) ? new bool?(introduciendo.alive) : null).GetValueOrDefault())
			{
				this.m_introduciendo.Stop();
			}
			GlobalUpdater.Corrutina esperandoCamilla = this.m_esperandoCamilla;
			if (((esperandoCamilla != null) ? new bool?(esperandoCamilla.alive) : null).GetValueOrDefault())
			{
				this.m_esperandoCamilla.Stop();
			}
			GlobalUpdater.Corrutina esperandoRopaYCamilla = this.m_esperandoRopaYCamilla;
			if (((esperandoRopaYCamilla != null) ? new bool?(esperandoRopaYCamilla.alive) : null).GetValueOrDefault())
			{
				this.m_esperandoRopaYCamilla.Stop();
			}
			GlobalUpdater.Corrutina enPhase = this.m_enPhase1;
			if (((enPhase != null) ? new bool?(enPhase.alive) : null).GetValueOrDefault())
			{
				this.m_enPhase1.Stop();
			}
			GlobalUpdater.Corrutina enPhase2 = this.m_enPhase2;
			if (((enPhase2 != null) ? new bool?(enPhase2.alive) : null).GetValueOrDefault())
			{
				this.m_enPhase2.Stop();
			}
			GlobalUpdater.Corrutina enPhase3 = this.m_enPhase3;
			if (((enPhase3 != null) ? new bool?(enPhase3.alive) : null).GetValueOrDefault())
			{
				this.m_enPhase3.Stop();
			}
			GlobalUpdater.Corrutina enPhase3Massage = this.m_enPhase3Massage;
			if (((enPhase3Massage != null) ? new bool?(enPhase3Massage.alive) : null).GetValueOrDefault())
			{
				this.m_enPhase3Massage.Stop();
			}
			GlobalUpdater.Corrutina enPhase3Happy = this.m_enPhase3Happy;
			if (((enPhase3Happy != null) ? new bool?(enPhase3Happy.alive) : null).GetValueOrDefault())
			{
				this.m_enPhase3Happy.Stop();
			}
			GlobalUpdater.Corrutina enPhase3AnySex = this.m_enPhase3AnySex;
			if (((enPhase3AnySex != null) ? new bool?(enPhase3AnySex.alive) : null).GetValueOrDefault())
			{
				this.m_enPhase3AnySex.Stop();
			}
			this.m_introduciendo = null;
			this.m_esperandoCamilla = null;
			this.m_esperandoRopaYCamilla = null;
			this.m_enPhase1 = null;
			this.m_enPhase2 = null;
			this.m_enPhase3 = null;
			this.m_enPhase3Massage = null;
			this.m_enPhase3Happy = null;
			this.m_enPhase3AnySex = null;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x000141A0 File Offset: 0x000123A0
		private void StopAllStates()
		{
			this.StopAllGamePlayStates();
			GlobalUpdater.Corrutina despachadoPorEmoNegativa = this.m_despachadoPorEmoNegativa;
			if (((despachadoPorEmoNegativa != null) ? new bool?(despachadoPorEmoNegativa.alive) : null).GetValueOrDefault())
			{
				this.m_despachadoPorEmoNegativa.Stop();
			}
			GlobalUpdater.Corrutina despachadoPorSatisfecho = this.m_despachadoPorSatisfecho;
			if (((despachadoPorSatisfecho != null) ? new bool?(despachadoPorSatisfecho.alive) : null).GetValueOrDefault())
			{
				this.m_despachadoPorSatisfecho.Stop();
			}
			GlobalUpdater.Corrutina despachadoPorTiempo = this.m_despachadoPorTiempo;
			if (((despachadoPorTiempo != null) ? new bool?(despachadoPorTiempo.alive) : null).GetValueOrDefault())
			{
				this.m_despachadoPorTiempo.Stop();
			}
			GlobalUpdater.Corrutina despachadoPorSex = this.m_despachadoPorSex;
			if (((despachadoPorSex != null) ? new bool?(despachadoPorSex.alive) : null).GetValueOrDefault())
			{
				this.m_despachadoPorSex.Stop();
			}
			GlobalUpdater.Corrutina retirar = this.m_Retirar;
			if (((retirar != null) ? new bool?(retirar.alive) : null).GetValueOrDefault())
			{
				this.m_Retirar.Stop();
			}
			this.m_despachadoPorEmoNegativa = null;
			this.m_despachadoPorSatisfecho = null;
			this.m_despachadoPorTiempo = null;
			this.m_despachadoPorSex = null;
			this.m_Retirar = null;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000142DA File Offset: 0x000124DA
		private void ChangeContractByStado(SpaJob.GamePlayEstadoEspecifico newEstado)
		{
			if (newEstado - SpaJob.GamePlayEstadoEspecifico.enPhase1 <= 7)
			{
				this.RemoverBuffDeConsentPorContrato();
				return;
			}
			this.GenerarBuffDeConsentPorContrato();
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000142F0 File Offset: 0x000124F0
		private void SetEstado(SpaJob.GamePlayEstadoEspecifico estado, bool changeContract)
		{
			if (changeContract && estado != this.m_estadoEspecifico)
			{
				try
				{
					this.ChangeContractByStado(estado);
				}
				catch (Exception)
				{
					throw;
				}
			}
			this.m_estadoEspecifico = estado;
			switch (estado)
			{
			case SpaJob.GamePlayEstadoEspecifico.None:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.None;
				return;
			case SpaJob.GamePlayEstadoEspecifico.introduciendo:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.introduciendo;
				return;
			case SpaJob.GamePlayEstadoEspecifico.esperandoCamilla:
			case SpaJob.GamePlayEstadoEspecifico.esperandoRopaYCamilla:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.esperandoRopaYCamilla;
				return;
			case SpaJob.GamePlayEstadoEspecifico.enPhase1:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.enPhase1;
				return;
			case SpaJob.GamePlayEstadoEspecifico.enPhase2:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.enPhase2;
				return;
			case SpaJob.GamePlayEstadoEspecifico.enPhase3:
			case SpaJob.GamePlayEstadoEspecifico.enPhase3Massage:
			case SpaJob.GamePlayEstadoEspecifico.enPhase3Happy:
			case SpaJob.GamePlayEstadoEspecifico.enPhase3Oral:
			case SpaJob.GamePlayEstadoEspecifico.enPhase3Sex:
			case SpaJob.GamePlayEstadoEspecifico.enPhase3SexInv:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.enPhase3;
				return;
			case SpaJob.GamePlayEstadoEspecifico.despachadoPorEmoNegativa:
			case SpaJob.GamePlayEstadoEspecifico.despachadoPorSatisfecho:
			case SpaJob.GamePlayEstadoEspecifico.despachadoPorTiempo:
			case SpaJob.GamePlayEstadoEspecifico.despachadoPorSex:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.despachando;
				return;
			case SpaJob.GamePlayEstadoEspecifico.retirando:
				this.m_estadoGeneral = SpaJob.GamePlayEstadoGeneral.retirando;
				return;
			default:
				throw new ArgumentOutOfRangeException(estado.ToString());
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000143CC File Offset: 0x000125CC
		private void GenerarObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			IRopaManager maleRopa = base.mainPlayerCharacter.GetComponentEnRoot(false);
			IInteraccionesDeCharacter inters = base.mainPlayerCharacter.GetComponentEnRoot(false);
			ISMAJobObjective ismajobObjective = instance.objectives.CreateObjective("tvalle.SpaJob.GetOnStrecher", "Lie down on the stretcher so the session can begin.", false, () => inters.EstaEjecutandose("tvalle.inter.MaleRestCamilla".GetHashCode()), ObjectiveCheckFrequency.delayed, null, null);
			ISMAJobObjective ismajobObjective2 = instance.objectives.CreateObjective("tvalle.SpaJob.GetNaked", "Undress completely to allow for a proper full-body massage.", false, () => maleRopa.cubriendoFlags == RopaCubre.None, ObjectiveCheckFrequency.delayed, null, "Press Shift + P");
			ISMAJobObjective ismajobObjective3 = instance.objectives.CreateObjective("tvalle.SpaJob.TipGer", "Offer her tips during the massage. The more you tip, the more effort she will put into pleasing you.", false, () => this.m_currentTipTotalAmount > 0f, ObjectiveCheckFrequency.delayed, null, null);
			this.m_actividadObjectivesOptional.Add((GameplayObjectives.Objective)ismajobObjective);
			this.m_actividadObjectivesOptional.Add((GameplayObjectives.Objective)ismajobObjective2);
			this.m_actividadObjectivesOptional.Add((GameplayObjectives.Objective)ismajobObjective3);
			this.m_jobManager.objectives.AddObjectives(this.m_actividadObjectivesRequired, true);
			this.m_jobManager.objectives.AddObjectives(this.m_actividadObjectivesOptional, false);
		}

		// Token: 0x040001EB RID: 491
		private JobWithClientDefaultMenuModel m_mainMenuModel;

		// Token: 0x040001EC RID: 492
		public const string clafGOTOID = "GOTO.Massage.Calf";

		// Token: 0x040001ED RID: 493
		public const string legsGOTOID = "GOTO.Massage.Legs";

		// Token: 0x040001EE RID: 494
		public const string groinGOTOID = "GOTO.Massage.Groin";

		// Token: 0x040001EF RID: 495
		public const string absGOTOID = "GOTO.Massage.Abs";

		// Token: 0x040001F0 RID: 496
		public const string chestGOTOID = "GOTO.Massage.Chest";

		// Token: 0x040001F1 RID: 497
		public const string sholdersGOTOID = "GOTO.Massage.Shoulders";

		// Token: 0x040001F2 RID: 498
		public const string clafInterID = "tvalle.inter.massageFullBodyPose.Calf";

		// Token: 0x040001F3 RID: 499
		public const string legsInterID = "tvalle.inter.massageFullBodyPose.Legs";

		// Token: 0x040001F4 RID: 500
		public const string groinInterID = "tvalle.inter.massageFullBodyPose.Groin";

		// Token: 0x040001F5 RID: 501
		public const string absInterID = "tvalle.inter.massageFullBodyPose.Abs";

		// Token: 0x040001F6 RID: 502
		public const string chestInterID = "tvalle.inter.massageFullBodyPose.Chest";

		// Token: 0x040001F7 RID: 503
		public const string sholdersInterID = "tvalle.inter.massageFullBodyPose.Shoulders";

		// Token: 0x040001F8 RID: 504
		public const string maleOpenedLegsInterID = "tvalle.inter.MaleRestCamillaBigOpenLegs";

		// Token: 0x040001F9 RID: 505
		public const string maleClosedLegsInterID = "tvalle.inter.MaleRestCamillaBigClosedLegs";

		// Token: 0x040001FA RID: 506
		public const string handJobGOTOID = "GOTO.camillaHandJob";

		// Token: 0x040001FB RID: 507
		public const string camillaHandJobInterID = "tvalle.inter.camillaHandJob";

		// Token: 0x040001FC RID: 508
		public const string oralGOTOID = "GOTO.Massage.CamillaBig.OnOral";

		// Token: 0x040001FD RID: 509
		public const string sexGOTOID = "GOTO.Massage.CamillaBig.OnSex";

		// Token: 0x040001FE RID: 510
		public const string sexInvGOTOID = "GOTO.Massage.CamillaBig.Inv.OnSex";

		// Token: 0x040001FF RID: 511
		public const string femCamillaMainOffGOTOID = "GOTO.Massage.CamillaMain.FemOff";

		// Token: 0x04000200 RID: 512
		public const string maleCamillaMainOffGOTOID = "GOTO.Massage.CamillaMain.MaleOff";

		// Token: 0x04000201 RID: 513
		public const string femCamillaBigOffGOTOID = "GOTO.Massage.CamillaBig.FemOff";

		// Token: 0x04000202 RID: 514
		public const string maleCamillaBigOnGOTOID = "GOTO.Massage.CamillaBig.MaleOn";

		// Token: 0x04000203 RID: 515
		public const string maleCamillaBigOffGOTOID = "GOTO.Massage.CamillaBig.MaleOff";

		// Token: 0x04000204 RID: 516
		public const string camillaMainID = "TValle.Camilla.Main";

		// Token: 0x04000205 RID: 517
		public const string camillaBigID = "TValle.Camilla.Big";

		// Token: 0x04000206 RID: 518
		[Header("DEBUG")]
		[SerializeField]
		private RecorridoDeMassgeOnMaleBody.Recorrido m_recorridoDEBUG;

		// Token: 0x04000207 RID: 519
		[SerializeField]
		private float m_velocidadDEBUG = 1f;

		// Token: 0x04000208 RID: 520
		[SerializeField]
		[ReadOnlyUI]
		private bool isDebugging;

		// Token: 0x04000209 RID: 521
		[SerializeField]
		[ReadOnlyUI]
		private SpaDebugger m_SpaDebugger;

		// Token: 0x0400020A RID: 522
		private const float clientMaxMoney = 160f;

		// Token: 0x0400020B RID: 523
		private const float clientMinMoney = 40f;

		// Token: 0x0400020C RID: 524
		private const float maxTipTotalAmount_Massage = 30f;

		// Token: 0x0400020D RID: 525
		private const float maxTipTotalAmount_HandJob = 50f;

		// Token: 0x0400020E RID: 526
		private const float tipAmount = 5f;

		// Token: 0x0400020F RID: 527
		private const float initialMassageVelocity = 0.25f;

		// Token: 0x04000210 RID: 528
		private const float initialHandJobVelocity = 0.25f;

		// Token: 0x04000211 RID: 529
		private const string camillaInterName = "tvalle.inter.MaleRestCamilla";

		// Token: 0x04000212 RID: 530
		[SerializeField]
		private SpaJob.GamePlayEstadoEspecifico m_estadoEspecifico;

		// Token: 0x04000213 RID: 531
		[SerializeField]
		private SpaJob.GamePlayEstadoGeneral m_estadoGeneral;

		// Token: 0x04000214 RID: 532
		[SerializeField]
		private int m_clientsToGo;

		// Token: 0x04000215 RID: 533
		[SerializeField]
		private int m_clientsCount;

		// Token: 0x04000216 RID: 534
		[SerializeField]
		private SpaJob.MassageRequestState m_MassageRequestState = new SpaJob.MassageRequestState();

		// Token: 0x04000217 RID: 535
		[SerializeField]
		private SpaJob.MassageHappySexRequestState m_MassageHappySexRequestState = new SpaJob.MassageHappySexRequestState();

		// Token: 0x04000218 RID: 536
		private GlobalUpdater.Corrutina m_introduciendo;

		// Token: 0x04000219 RID: 537
		private GlobalUpdater.Corrutina m_esperandoCamilla;

		// Token: 0x0400021A RID: 538
		private GlobalUpdater.Corrutina m_esperandoRopaYCamilla;

		// Token: 0x0400021B RID: 539
		private GlobalUpdater.Corrutina m_enPhase1;

		// Token: 0x0400021C RID: 540
		private GlobalUpdater.Corrutina m_enPhase2;

		// Token: 0x0400021D RID: 541
		private GlobalUpdater.Corrutina m_enPhase3;

		// Token: 0x0400021E RID: 542
		private GlobalUpdater.Corrutina m_enPhase3Massage;

		// Token: 0x0400021F RID: 543
		private GlobalUpdater.Corrutina m_enPhase3Happy;

		// Token: 0x04000220 RID: 544
		private GlobalUpdater.Corrutina m_enPhase3AnySex;

		// Token: 0x04000221 RID: 545
		private GlobalUpdater.Corrutina m_despachadoPorEmoNegativa;

		// Token: 0x04000222 RID: 546
		private GlobalUpdater.Corrutina m_despachadoPorSatisfecho;

		// Token: 0x04000223 RID: 547
		private GlobalUpdater.Corrutina m_despachadoPorTiempo;

		// Token: 0x04000224 RID: 548
		private GlobalUpdater.Corrutina m_despachadoPorSex;

		// Token: 0x04000225 RID: 549
		private GlobalUpdater.Corrutina m_Retirar;

		// Token: 0x04000226 RID: 550
		public float massageDuration = 30f;

		// Token: 0x04000227 RID: 551
		public float happyDuration = 60f;

		// Token: 0x04000228 RID: 552
		public float oralDuration = 90f;

		// Token: 0x04000229 RID: 553
		public float sexDuration = 90f;

		// Token: 0x0400022A RID: 554
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentTipTotalAmount;

		// Token: 0x0400022B RID: 555
		[SerializeField]
		[ReadOnlyUI]
		private float m_totalJobTipTotalAmount;

		// Token: 0x0400022C RID: 556
		[SerializeField]
		[ReadOnlyUI]
		private bool m_flagCantRestoreOutfit;

		// Token: 0x0400022D RID: 557
		[SerializeField]
		[ReadOnlyUI]
		private int despachadosPorEmoNegativa;

		// Token: 0x0400022E RID: 558
		[SerializeField]
		[ReadOnlyUI]
		private int despachadosPorSatisfecho;

		// Token: 0x0400022F RID: 559
		[SerializeField]
		[ReadOnlyUI]
		private int despachadosPorTiempo;

		// Token: 0x04000230 RID: 560
		[SerializeField]
		[ReadOnlyUI]
		private int despachadosPorSex;

		// Token: 0x04000231 RID: 561
		private List<Guid> m_clientsIDs = new List<Guid>();

		// Token: 0x04000232 RID: 562
		[SerializeField]
		[ReadOnlyUI]
		private RecorridoDeMassgeOnMaleBody.Recorrido m_lastSelectedRecorrido;

		// Token: 0x04000233 RID: 563
		private CoolDown m_TipCoolDonw = new CoolDown();

		// Token: 0x04000234 RID: 564
		[SerializeReference]
		private SpaJob.PhaseEndCountDown m_currentCountDown;

		// Token: 0x04000235 RID: 565
		[SerializeField]
		private List<GameplayObjectives.Objective> m_actividadObjectivesRequired = new List<GameplayObjectives.Objective>();

		// Token: 0x04000236 RID: 566
		[SerializeField]
		private List<GameplayObjectives.Objective> m_actividadObjectivesOptional = new List<GameplayObjectives.Objective>();

		// Token: 0x02000194 RID: 404
		[Serializable]
		internal class PhaseEndCountDown
		{
			// Token: 0x06000D24 RID: 3364 RVA: 0x0004191C File Offset: 0x0003FB1C
			internal static void Replace(ref SpaJob.PhaseEndCountDown old, float duration)
			{
				if (old != null && !old.ended)
				{
					Debug.LogError("last PhaseEndCountDown was not finished");
				}
				old = new SpaJob.PhaseEndCountDown();
				old.duration = duration;
			}

			// Token: 0x06000D25 RID: 3365 RVA: 0x00041944 File Offset: 0x0003FB44
			private PhaseEndCountDown()
			{
			}

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x06000D26 RID: 3366 RVA: 0x0004194C File Offset: 0x0003FB4C
			public bool ended
			{
				get
				{
					return this.m_ended;
				}
			}

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00041954 File Offset: 0x0003FB54
			public bool flagedToStop
			{
				get
				{
					return this.m_flagedToStop;
				}
			}

			// Token: 0x06000D28 RID: 3368 RVA: 0x0004195C File Offset: 0x0003FB5C
			public void FlagToStop()
			{
				this.m_flagedToStop = true;
			}

			// Token: 0x06000D29 RID: 3369 RVA: 0x00041965 File Offset: 0x0003FB65
			public void SetEnded()
			{
				this.m_ended = true;
				this.waitFor = null;
				this.m_flagedToStop = false;
			}

			// Token: 0x170001EB RID: 491
			// (get) Token: 0x06000D2A RID: 3370 RVA: 0x0004197C File Offset: 0x0003FB7C
			public bool isWaitingForCorrutina
			{
				get
				{
					return this.waitFor != null && !this.waitFor.finalizada;
				}
			}

			// Token: 0x040006FE RID: 1790
			public float duration;

			// Token: 0x040006FF RID: 1791
			public float startTime;

			// Token: 0x04000700 RID: 1792
			public GlobalUpdater.Corrutina waitFor;

			// Token: 0x04000701 RID: 1793
			[SerializeField]
			private bool m_flagedToStop;

			// Token: 0x04000702 RID: 1794
			[SerializeField]
			private bool m_ended;
		}

		// Token: 0x02000195 RID: 405
		[Serializable]
		public class MassageRequestState
		{
			// Token: 0x06000D2B RID: 3371 RVA: 0x00041996 File Offset: 0x0003FB96
			public void Clear()
			{
				this.selected = ParteDelCuerpoHumano.vag;
				this.finished = false;
				this.registro = null;
			}

			// Token: 0x04000703 RID: 1795
			public bool finished;

			// Token: 0x04000704 RID: 1796
			public ParteDelCuerpoHumano selected;

			// Token: 0x04000705 RID: 1797
			public RegistroDeFuncionesDeTrabajosDeModelaje registro;
		}

		// Token: 0x02000196 RID: 406
		[Serializable]
		public class MassageHappySexRequestState
		{
			// Token: 0x06000D2D RID: 3373 RVA: 0x000419B8 File Offset: 0x0003FBB8
			public void Clear()
			{
				this.selected = ParteDelCuerpoHumano.vag;
				this.finished = false;
				this.registro = null;
				this.massageAccepted = false;
				this.happyAccepted = false;
				this.sexAccepted = false;
				this.analAceptance = 0f;
				this.vagAceptance = 0f;
				this.oralAceptance = 0f;
			}

			// Token: 0x04000706 RID: 1798
			public bool finished;

			// Token: 0x04000707 RID: 1799
			public bool massageAccepted;

			// Token: 0x04000708 RID: 1800
			public bool happyAccepted;

			// Token: 0x04000709 RID: 1801
			public bool sexAccepted;

			// Token: 0x0400070A RID: 1802
			public ParteDelCuerpoHumano selected;

			// Token: 0x0400070B RID: 1803
			public float analAceptance;

			// Token: 0x0400070C RID: 1804
			public float vagAceptance;

			// Token: 0x0400070D RID: 1805
			public float oralAceptance;

			// Token: 0x0400070E RID: 1806
			public RegistroDeFuncionesDeTrabajosDeModelaje registro;
		}

		// Token: 0x02000197 RID: 407
		public enum GamePlayEstadoEspecifico
		{
			// Token: 0x04000710 RID: 1808
			None,
			// Token: 0x04000711 RID: 1809
			introduciendo,
			// Token: 0x04000712 RID: 1810
			esperandoCamilla,
			// Token: 0x04000713 RID: 1811
			esperandoRopaYCamilla,
			// Token: 0x04000714 RID: 1812
			enPhase1,
			// Token: 0x04000715 RID: 1813
			enPhase2,
			// Token: 0x04000716 RID: 1814
			enPhase3,
			// Token: 0x04000717 RID: 1815
			enPhase3Massage,
			// Token: 0x04000718 RID: 1816
			enPhase3Happy,
			// Token: 0x04000719 RID: 1817
			enPhase3Oral,
			// Token: 0x0400071A RID: 1818
			enPhase3Sex,
			// Token: 0x0400071B RID: 1819
			enPhase3SexInv,
			// Token: 0x0400071C RID: 1820
			despachadoPorEmoNegativa,
			// Token: 0x0400071D RID: 1821
			despachadoPorSatisfecho,
			// Token: 0x0400071E RID: 1822
			despachadoPorTiempo,
			// Token: 0x0400071F RID: 1823
			despachadoPorSex,
			// Token: 0x04000720 RID: 1824
			retirando
		}

		// Token: 0x02000198 RID: 408
		public enum GamePlayEstadoGeneral
		{
			// Token: 0x04000722 RID: 1826
			None,
			// Token: 0x04000723 RID: 1827
			introduciendo,
			// Token: 0x04000724 RID: 1828
			esperandoRopaYCamilla,
			// Token: 0x04000725 RID: 1829
			enPhase1,
			// Token: 0x04000726 RID: 1830
			enPhase2,
			// Token: 0x04000727 RID: 1831
			enPhase3,
			// Token: 0x04000728 RID: 1832
			despachando,
			// Token: 0x04000729 RID: 1833
			retirando
		}
	}
}
