using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.Productos.Juegos.Reception;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Camaras;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Emociones;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Maps;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Menus.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.Mapas;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.NPCs;
using Assets._ReusableScripts.Scenes;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200011F RID: 287
	public class ActividadesManager : Singleton<ActividadesManager>
	{
		// Token: 0x06000A0F RID: 2575 RVA: 0x0003907B File Offset: 0x0003727B
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			Actividad.ForzeClear();
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000A10 RID: 2576 RVA: 0x00039082 File Offset: 0x00037282
		public ISceneInteractions interactions
		{
			get
			{
				if (!Singleton<InteraccionesEnScena>.IsInScene)
				{
					return null;
				}
				return Singleton<InteraccionesEnScena>.instance;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x00039092 File Offset: 0x00037292
		public bool isloadingActividad
		{
			get
			{
				return this.m_LoadActividadRutina != null;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000A12 RID: 2578 RVA: 0x0003909D File Offset: 0x0003729D
		public Actividad current
		{
			get
			{
				return Actividad.running;
			}
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x000390A4 File Offset: 0x000372A4
		protected override void DoAwake()
		{
			MemoriaDeSujetosNpcFemenina.IgnorarDataKeys.Add("ModelingExp");
			base.DoAwake();
			if (!Singleton<ConfiguracionGeneralDeInputs>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeInputs>.TryIniciar();
			}
			this.m_inputEnabled = Singleton<ConfiguracionGeneralDeInputs>.instance.activoOverallAND.ObtenerModificadorNotNull(this);
			this.m_playerInputEnabled = Singleton<PlayerInputProxy>.instance.activoModificableOverallAND.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00039100 File Offset: 0x00037300
		protected override void OnDestroyingThisDuplicated()
		{
			base.OnDestroyingThisDuplicated();
			ModificadorDeBool inputEnabled = this.m_inputEnabled;
			if (inputEnabled != null)
			{
				inputEnabled.TryRemoverDeOwner(true);
			}
			ModificadorDeBool playerInputEnabled = this.m_playerInputEnabled;
			if (playerInputEnabled == null)
			{
				return;
			}
			playerInputEnabled.TryRemoverDeOwner(true);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0003912D File Offset: 0x0003732D
		public ActividadesManager.ContextMemory GetMemory(Actividad actividad)
		{
			return this.GetMemory(actividad.ID);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0003913C File Offset: 0x0003733C
		public ActividadesManager.ContextMemory GetMemory(string actividadID)
		{
			MemoriaJson instance = GlobalSingletonV2<MemoriaJson>.instance;
			string text = "root/Activity/" + actividadID;
			ActividadesManager.ContextMemory contextMemory;
			if (!this.m_actividadMem.TryGetValue(text, out contextMemory))
			{
				contextMemory = new ActividadesManager.ContextMemory(instance.LeerDeep(text, true), actividadID);
				this.m_actividadMem.Add(text, contextMemory);
			}
			return contextMemory;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00039188 File Offset: 0x00037388
		public ActividadesManager.ContextMemory GetCharacterInMemory(Actividad actividad, Character character)
		{
			return this.GetCharacterInMemory(actividad.ID, character.ID_Unico.ToString());
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x000391B8 File Offset: 0x000373B8
		public ActividadesManager.ContextMemory GetCharacterInMemory(string actividadID, string characterID)
		{
			MemoriaJson instance = GlobalSingletonV2<MemoriaJson>.instance;
			string text = string.Format("root/NPC/{0}/Activity/{1}/", characterID, actividadID);
			ActividadesManager.ContextMemory contextMemory;
			if (!this.m_CharsInActividadMem.TryGetValue(text, out contextMemory))
			{
				contextMemory = new ActividadesManager.ContextMemory(instance.LeerDeep(text, true), actividadID);
				this.m_CharsInActividadMem.Add(text, contextMemory);
			}
			return contextMemory;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00039208 File Offset: 0x00037408
		public void AddAdditinalLogicToScene(Scene scene, float cameraEmitionMult)
		{
			Singleton<LucesEnEscena>.instance.modificableDeEmisionDeCamaraScreens.ObtenerModificadorNotNull(this).valor.valor = cameraEmitionMult;
			try
			{
				scene.GetRootGameObjects(ActividadesManager.m_SceneRootGameObjects);
				foreach (GameObject gameObject in ActividadesManager.m_SceneRootGameObjects)
				{
					try
					{
						gameObject.GetComponentsInChildren<Light>(true, ActividadesManager.m_SceneLights);
						foreach (Light light in ActividadesManager.m_SceneLights)
						{
							light.GetComponentNotNull<LuzEnEscena>();
						}
					}
					finally
					{
						ActividadesManager.m_SceneLights.Clear();
					}
				}
			}
			finally
			{
				ActividadesManager.m_SceneRootGameObjects.Clear();
			}
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x000392F4 File Offset: 0x000374F4
		public void DestroyCharacter(Guid id)
		{
			Object.Destroy(Singleton<NPC_to_Character>.instance.TryGet(id).GetComponentInParent<ICharacterRoot>(true).transform.gameObject);
			LoaderDeNpcFemeninos.DestroyNPC(id.ToString());
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00039328 File Offset: 0x00037528
		public void DeleteAndDestroyCharacter(Guid id)
		{
			LoaderDeNpcMasculinos.EraseNPCFromMemory(id.ToString());
			LoaderDeNpcFemeninos.EraseNPCFromGameMemory(id.ToString());
			this.DestroyCharacter(id);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00039355 File Offset: 0x00037555
		public IEnumerator LoadDefaultFemaleCharacter(Vector3 feetPosition, Vector3 bodyForwardDirection, Action<Character> result)
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated)
			{
				yield return null;
			}
			ICharacterIdentificable @default = LoaderDeNpcFemeninos.GetDefault(feetPosition, Quaternion.LookRotation(bodyForwardDirection, Vector3.up));
			SceneManager.MoveGameObjectToScene(@default.transform.gameObject, this.current.gameObject.scene);
			if (result != null)
			{
				result(@default as Character);
			}
			yield break;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00039379 File Offset: 0x00037579
		public IEnumerator LoadFemaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<Character> result, Action<ICharacterIdentificable> onLoading = null)
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated || !AsyncSingleton<RadialMenusForActivities>.instanceInitiated)
			{
				yield return null;
			}
			ICharacterIdentificable asCharacter;
			if (id == Guid.Empty)
			{
				ISujetoIdentificableNpc sujetoIdentificableNpc;
				LoaderDeNpcFemeninos.GenerateRandomNPC_Character(feetPosition, Quaternion.LookRotation(bodyForwardDirection, Vector3.up), out sujetoIdentificableNpc, out asCharacter);
				SceneManager.MoveGameObjectToScene(asCharacter.transform.gameObject, this.current.gameObject.scene);
				if (onLoading != null)
				{
					onLoading(asCharacter);
				}
			}
			else if (MemoriaDeSujetosNpcFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, id.ToString()))
			{
				ISujetoIdentificableNpc sujetoIdentificableNpc2;
				LoaderDeNpcFemeninos.ReadFromGameMemoryNPC_Character(id.ToString(), feetPosition, Quaternion.LookRotation(bodyForwardDirection, Vector3.up), out sujetoIdentificableNpc2, out asCharacter);
				SceneManager.MoveGameObjectToScene(asCharacter.transform.gameObject, this.current.gameObject.scene);
				if (onLoading != null)
				{
					onLoading(asCharacter);
				}
				IConjuntoDeRopa conjuntoDeRopa = LoaderDeNpcFemeninos.LoadFemaleRopaFromMemory(GlobalSingletonV2<MemoriaJson>.instance, id.ToString());
				IRopaManager componentInChildren = asCharacter.transform.GetComponentInChildren<IRopaManager>();
				if (componentInChildren != null && conjuntoDeRopa != null)
				{
					yield return componentInChildren.LoadConjuntoAsset(conjuntoDeRopa, true, null, true);
				}
				else
				{
					Debug.LogError("cant load female outfit from memory, it was empty or null or no Manager found");
				}
			}
			else
			{
				Singleton<ModalWindow>.instance.AcumularErrores("NPC with the ID " + id.ToString() + " was not found in memory.", null);
				asCharacter = null;
			}
			yield return null;
			if (result != null)
			{
				result(asCharacter as Character);
			}
			yield break;
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000393AD File Offset: 0x000375AD
		public void AddExtraComponentsAndConfigToPlayerCharacter()
		{
			Transform childNotNull = this.current.mainPlayerCharacter.transform.GetChildNotNull("ActividadLogic", true);
			childNotNull.GetComponentNotNull<CallBackAtEmocionesMaxValue>();
			childNotNull.GetComponentNotNull<CallBackAtPlacerMaxValueBuffer>();
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000393D8 File Offset: 0x000375D8
		public void AddExtraComponentsAndConfigToNonPlayerCharacter()
		{
			AsyncSingleton<RadialMenusForActivities>.instance.InitRadialMenusOnFemale(this.current.mainNonPlayerCharacter);
			for (int i = 0; i < this.m_configMaps.Length; i++)
			{
				ActividadFemaleConfigMap actividadFemaleConfigMap = this.m_configMaps[i];
				if (actividadFemaleConfigMap != null)
				{
					actividadFemaleConfigMap.SetConfig(this.current.mainNonPlayerCharacter);
				}
			}
			Transform childNotNull = this.current.mainNonPlayerCharacter.transform.GetChildNotNull("ActividadLogic", true);
			childNotNull.GetComponentNotNull<CallBackAtEmocionesMaxValue>();
			childNotNull.GetComponentNotNull<CallBackAtRageMaxValueBuffer>();
			childNotNull.GetComponentNotNull<CallBackAtPlacerMaxValueBuffer>();
			childNotNull.GetComponentNotNull<CallBackAtFearMaxValueBuffer>();
			childNotNull.GetComponentNotNull<CallBackAtDolorMaxValueBuffer>();
			childNotNull.GetComponentNotNull<CallBackAtDecepcionMaxValueBuffer>();
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0003946F File Offset: 0x0003766F
		public void AddExtraComponentsAndConfigToCharacters()
		{
			this.AddExtraComponentsAndConfigToNonPlayerCharacter();
			this.AddExtraComponentsAndConfigToPlayerCharacter();
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00039480 File Offset: 0x00037680
		public void OnEmotionMaxValue(Character onCharacter, Emocion emocion)
		{
			if (this.current == null)
			{
				return;
			}
			Emotion emotion;
			if (!emocion.reaccion.TryParse(out emotion))
			{
				return;
			}
			if (onCharacter == this.current.mainNonPlayerCharacter)
			{
				this.current.OnNonPlayerMaxEmotionValue(emotion);
				return;
			}
			if (onCharacter == this.current.mainPlayerCharacter)
			{
				this.current.OnPlayerMaxEmotionValue(emotion);
			}
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x000394EC File Offset: 0x000376EC
		public bool OnEmotionMaxValueBuffer(Character onCharacter, Emocion emocion)
		{
			if (this.current == null)
			{
				return true;
			}
			Emotion emotion;
			if (!emocion.reaccion.TryParse(out emotion))
			{
				return true;
			}
			if (onCharacter == this.current.mainNonPlayerCharacter)
			{
				return this.current.OnNonPlayerMaxEmotionValueBuffer(emotion);
			}
			return !(onCharacter == this.current.mainPlayerCharacter) || this.current.OnPlayerMaxEmotionValueBuffer(emotion);
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0003955B File Offset: 0x0003775B
		public IEnumerator CheckMainCamera()
		{
			if (!InstantiatedSingleton<MainCameraRig>.existeEnScena)
			{
				SceneManager.MoveGameObjectToScene(Object.Instantiate<GameObject>(MapaSingleton<CharactersPrefabsGetter>.instance.cameraRig, Vector3.zero, Quaternion.identity), this.current.gameObject.scene);
				yield return null;
			}
			else
			{
				SceneManager.MoveGameObjectToScene(InstantiatedSingleton<MainCameraRig>.instance.gameObject, this.current.gameObject.scene);
			}
			yield break;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0003956A File Offset: 0x0003776A
		public IEnumerator LoadDefaultMaleCharacter(Vector3 feetPosition, Vector3 bodyForwardDirection, Action<Character> result)
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated)
			{
				yield return null;
			}
			yield return this.CheckMainCamera();
			ICharacterIdentificable male = LoaderDeNpcMasculinos.GetDefault(feetPosition, Quaternion.LookRotation(bodyForwardDirection, Vector3.up), true);
			SceneManager.MoveGameObjectToScene(male.transform.gameObject, this.current.gameObject.scene);
			yield return null;
			male.transform.gameObject.SetActive(true);
			if (result != null)
			{
				result(male as Character);
			}
			yield break;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0003958E File Offset: 0x0003778E
		public IEnumerator GenerarMaleCharacter(Vector3 feetPosition, Vector3 bodyForwardDirection, IMaleRandomGeneratorOverrider overrides, Action<Character> result, Action<Character> beforeAwake, string conjuntoID)
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated)
			{
				yield return null;
			}
			yield return this.CheckMainCamera();
			yield return this.GenerarMaleCharacterNoCamera(feetPosition, bodyForwardDirection, overrides, result, beforeAwake, conjuntoID);
			yield break;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x000395CA File Offset: 0x000377CA
		private IEnumerator GenerarMaleCharacterNoCamera(Vector3 feetPosition, Vector3 bodyForwardDirection, IMaleRandomGeneratorOverrider overrides, Action<Character> result, Action<Character> beforeAwake, string conjuntoID)
		{
			string nuevoNombreCompleto;
			string nuevoNombre;
			string nuevoApellido;
			Guid ID;
			ICharacterIdentificable male = LoaderDeNpcMasculinos.GenerateRandomCharacter(feetPosition, Quaternion.LookRotation(bodyForwardDirection, Vector3.up), true, out nuevoNombreCompleto, out nuevoNombre, out nuevoApellido, out ID, overrides, conjuntoID);
			SceneManager.MoveGameObjectToScene(male.transform.gameObject, this.current.gameObject.scene);
			if (beforeAwake != null)
			{
				beforeAwake(male as Character);
			}
			yield return null;
			male.transform.gameObject.SetActive(true);
			male.Bind(nuevoNombreCompleto, nuevoNombre, nuevoApellido, ID);
			if (result != null)
			{
				result(male as Character);
			}
			yield break;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00039606 File Offset: 0x00037806
		public IEnumerator LoadMaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<Character> result, Action<Character> beforeAwake)
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated)
			{
				yield return null;
			}
			yield return this.CheckMainCamera();
			if (id == Guid.Empty)
			{
				yield return this.GenerarMaleCharacterNoCamera(feetPosition, bodyForwardDirection, null, result, beforeAwake, null);
				yield break;
			}
			ICharacterIdentificable male;
			if (LoaderDeNpcMasculinos.MemoriaContiene(GlobalSingletonV2<MemoriaJson>.instance, id.ToString()))
			{
				string nuevoNombreCompleto;
				string nuevoNombre;
				string nuevoApellido;
				Guid ID;
				male = LoaderDeNpcMasculinos.ReadFromMemoryCharacter(id.ToString(), feetPosition, Quaternion.LookRotation(bodyForwardDirection, Vector3.up), true, out nuevoNombreCompleto, out nuevoNombre, out nuevoApellido, out ID);
				SceneManager.MoveGameObjectToScene(male.transform.gameObject, this.current.gameObject.scene);
				yield return null;
				male.transform.gameObject.SetActive(true);
				male.Bind(nuevoNombreCompleto, nuevoNombre, nuevoApellido, ID);
				nuevoNombreCompleto = null;
				nuevoNombre = null;
				nuevoApellido = null;
				ID = default(Guid);
			}
			else
			{
				Singleton<ModalWindow>.instance.AcumularErrores("NPC with the ID " + id.ToString() + " was not found in memory.", null);
				male = null;
			}
			if (result != null)
			{
				result(male as Character);
			}
			yield break;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0003963C File Offset: 0x0003783C
		public void StartActividad(string actividadName, Type loaderType, Action<IActividadLoader> onLoaderInstantiated = null, Action<Exception> onEnded = null, bool requiresMainLogic = true)
		{
			if (this.isloadingActividad)
			{
				throw new InvalidOperationException();
			}
			ActividadesManager.TypeLoaderHandler typeLoaderHandler = new ActividadesManager.TypeLoaderHandler(loaderType, onLoaderInstantiated);
			this.m_LoadActividadRutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate1, this, this.startActividadRutine(actividadName, typeLoaderHandler, requiresMainLogic), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				this.OnEndedStartActividadRutine(owner, ended, error, onEnded);
			});
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0003969C File Offset: 0x0003789C
		public void StartActividad<T_ActividadLoader>(string actividadName, Action<T_ActividadLoader> onLoaderInstantiated = null, Action<Exception> onEnded = null, bool requiresMainLogic = true) where T_ActividadLoader : MonoBehaviour, IActividadLoader
		{
			if (this.isloadingActividad)
			{
				throw new InvalidOperationException();
			}
			ActividadesManager.GenericLoaderHandler<T_ActividadLoader> genericLoaderHandler = new ActividadesManager.GenericLoaderHandler<T_ActividadLoader>(onLoaderInstantiated);
			this.m_LoadActividadRutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate1, this, this.startActividadRutine(actividadName, genericLoaderHandler, requiresMainLogic), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				this.OnEndedStartActividadRutine(owner, ended, error, onEnded);
			});
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x000396FA File Offset: 0x000378FA
		public IEnumerator StartActividadRutine<T_ActividadLoader>(string actividadName, Action<T_ActividadLoader> onLoaderInstantiated = null, Action<Exception> onEnded = null, bool requiresMainLogic = true) where T_ActividadLoader : MonoBehaviour, IActividadLoader
		{
			if (this.isloadingActividad)
			{
				throw new InvalidOperationException();
			}
			bool waiting = true;
			ActividadesManager.GenericLoaderHandler<T_ActividadLoader> genericLoaderHandler = new ActividadesManager.GenericLoaderHandler<T_ActividadLoader>(onLoaderInstantiated);
			this.m_LoadActividadRutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate1, this, this.startActividadRutine(actividadName, genericLoaderHandler, requiresMainLogic), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				waiting = false;
				this.OnEndedStartActividadRutine(owner, ended, error, onEnded);
			});
			while (waiting)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00039728 File Offset: 0x00037928
		public GlobalUpdater.Corrutina EndCurrentActividad(Action<Exception> onEnded = null)
		{
			if (this.isloadingActividad)
			{
				throw new InvalidOperationException();
			}
			this.m_LoadActividadRutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate1, this, this.endCurrentActividadRutine(), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				this.OnEndedStartActividadRutine(owner, ended, error, onEnded);
			});
			return this.m_LoadActividadRutina;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00039781 File Offset: 0x00037981
		public GlobalUpdater.Corrutina AbortarCurrentActividad(Action<Exception> onEnded = null)
		{
			Actividad running = Actividad.running;
			if (running != null)
			{
				running.OnAborted();
			}
			return this.EndCurrentActividad(onEnded);
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0003979C File Offset: 0x0003799C
		public float AddModelingExpToMainNonPlayer(float levels)
		{
			string id_UnicoString = this.current.mainNonPlayerCharacter.ID_UnicoString;
			float num = MemoriaDeSMAModelosFemeninas.TryGetModelingExp(GlobalSingletonV2<MemoriaJson>.instance, id_UnicoString, 0f) + levels;
			MemoriaDeSMAModelosFemeninas.SetModelingExp(GlobalSingletonV2<MemoriaJson>.instance, id_UnicoString, num);
			return num;
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x000397DC File Offset: 0x000379DC
		public IEnumerator ShowDefaultEndSessionPanel(bool aborted, float income, float activityExpGain, float activityExpTotal, float modelFatigueGain, float modelFatigueTotal, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFrom, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnTo)
		{
			PanelSessionEnd panel = Singleton<PanelSessionEndGetter>.instance.panel;
			if (panel.isShowing)
			{
				panel.Clear();
			}
			PanelSessionEnd.LoadDataToModel(aborted, income, activityExpGain, activityExpTotal, modelFatigueGain, modelFatigueTotal, BuffAndDebuffOnFrom, BuffAndDebuffOnTo, panel.modelo);
			bool leaveClicked = false;
			Action action = delegate
			{
				panel.ClearLeaveCallBack();
				leaveClicked = true;
			};
			panel.onLeaveClicked += action;
			panel.CrearYDibujar(null);
			while (!leaveClicked)
			{
				yield return null;
			}
			panel.Clear();
			yield break;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0003982C File Offset: 0x00037A2C
		public void FlagForceNoReciclarScenas()
		{
			this.m_FlagForceNoReciclarScenas = true;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00039835 File Offset: 0x00037A35
		private IEnumerator startActividadRutine(string actividadName, ActividadesManager.LoaderHandler loaderHandler, bool requiresMainLogic)
		{
			this.m_inputEnabled.valor.valor = false;
			this.m_playerInputEnabled.valor.valor = false;
			if (requiresMainLogic && SceneLoader.EscenaYaEstaCerrada(10))
			{
				SceneLoader.Pedido loadLogic = SceneLoader.Pedido.@default;
				loadLogic.scene.index = 10;
				loadLogic.doLoadOrDoUnload = true;
				Singleton<SceneLoader>.instance.AddPedido(loadLogic);
				while (!loadLogic.finalizado)
				{
					yield return null;
				}
				loadLogic = null;
			}
			Actividad lastRunning = Actividad.running;
			Actividad lastLoaded = Actividad.loaded;
			if (lastRunning != null)
			{
				yield return this.ConcludeAndEndActividad(lastRunning);
			}
			ActividadesManager.m_ActividadLogicTEMP = new GameObject(actividadName);
			Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(0);
			SceneManager.MoveGameObjectToScene(ActividadesManager.m_ActividadLogicTEMP, sceneByBuildIndex);
			bool lastActividadUnloaded = lastLoaded == null;
			IActividadLoader loader = loaderHandler.AddComponent(ActividadesManager.m_ActividadLogicTEMP);
			bool flag = lastRunning != null && loader.GetType() == lastRunning.loader.GetType();
			bool flag2 = !lastActividadUnloaded && lastLoaded.lightingAndGeometricsScene == lastLoaded.mainScene;
			bool flag3;
			if (!lastActividadUnloaded)
			{
				Actividad actividad = lastLoaded;
				flag3 = ((actividad != null) ? actividad.loader : null) is JobActivityLoader;
			}
			else
			{
				flag3 = false;
			}
			bool loadedWasJobLoader = flag3;
			bool flag6;
			if (!this.m_FlagForceNoReciclarScenas && !loader.noReciclarScenas)
			{
				Actividad actividad2 = lastLoaded;
				bool? flag4;
				if (actividad2 == null)
				{
					flag4 = null;
				}
				else
				{
					IActividadLoader loader2 = actividad2.loader;
					flag4 = ((loader2 != null) ? new bool?(loader2.noReciclarScenas) : null);
				}
				bool? flag5 = flag4;
				flag6 = flag5.GetValueOrDefault();
			}
			else
			{
				flag6 = true;
			}
			if ((flag6 || flag || flag2 || loadedWasJobLoader) && !lastActividadUnloaded)
			{
				GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate3, this, this.UnLoadActividad(lastLoaded, null), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
				{
					lastActividadUnloaded = true;
					if (error != null)
					{
						throw error;
					}
				});
				lastLoaded = null;
				while (!lastActividadUnloaded)
				{
					yield return null;
				}
			}
			if (!loadedWasJobLoader && !lastActividadUnloaded)
			{
				Actividad actividad3 = lastLoaded;
				if (((actividad3 != null) ? actividad3.loader : null) != null)
				{
					ActividadesManager.<>c__DisplayClass51_1 CS$<>8__locals2 = new ActividadesManager.<>c__DisplayClass51_1();
					CS$<>8__locals2.nextActivityLigthingScenePath = null;
					CS$<>8__locals2.finishLoadingLightingAndGeometricsPath = false;
					GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate3, this, loader.GetOrLoadLightingAndGeometricsPath(delegate(string r)
					{
						CS$<>8__locals2.nextActivityLigthingScenePath = r;
					}), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
					{
						CS$<>8__locals2.finishLoadingLightingAndGeometricsPath = true;
						if (error != null)
						{
							throw error;
						}
					});
					while (!CS$<>8__locals2.finishLoadingLightingAndGeometricsPath)
					{
						yield return null;
					}
					if (CS$<>8__locals2.nextActivityLigthingScenePath != lastLoaded.lightingAndGeometricsScene.path)
					{
						ActividadesManager.<>c__DisplayClass51_2 CS$<>8__locals3 = new ActividadesManager.<>c__DisplayClass51_2();
						CS$<>8__locals3.finishUnloadLigthingScene = false;
						GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate3, this, this.UnLoadLighting(lastLoaded), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
						{
							CS$<>8__locals3.finishUnloadLigthingScene = true;
							if (error != null)
							{
								throw error;
							}
						});
						while (!CS$<>8__locals3.finishUnloadLigthingScene)
						{
							yield return null;
						}
						CS$<>8__locals3 = null;
					}
					CS$<>8__locals2 = null;
				}
			}
			this.m_FlagForceNoReciclarScenas = false;
			yield return loader.DoLoad();
			if (ActividadesManager.m_ActividadLogicTEMP.scene != loader.mainScene)
			{
				SceneManager.MoveGameObjectToScene(ActividadesManager.m_ActividadLogicTEMP, loader.mainScene);
			}
			Actividad actividad4 = loader.ProduceActividad();
			ActividadesManager.m_ActividadLogicTEMP = null;
			actividad4.Init(loader);
			bool staredAndIntroduced = false;
			GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate2, this, this.DoStartAndIntroduceActividad(actividad4), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				staredAndIntroduced = true;
				if (error != null)
				{
					throw error;
				}
			});
			if (!lastActividadUnloaded)
			{
				GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate3, this, this.UnLoadActividad(lastLoaded, actividad4), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
				{
					lastActividadUnloaded = true;
					if (error != null)
					{
						throw error;
					}
				});
			}
			while (!staredAndIntroduced || !lastActividadUnloaded)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00039859 File Offset: 0x00037A59
		private IEnumerator endCurrentActividadRutine()
		{
			this.m_inputEnabled.valor.valor = false;
			this.m_playerInputEnabled.valor.valor = false;
			Actividad running = Actividad.running;
			Actividad lastLoaded = Actividad.loaded;
			if (running != null)
			{
				yield return this.ConcludeAndEndActividad(running);
			}
			bool lastActividadUnloaded = true;
			if (lastLoaded != null)
			{
				lastActividadUnloaded = false;
				GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.yielUpdate3, this, this.UnLoadActividad(lastLoaded, null), delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
				{
					lastActividadUnloaded = true;
					if (error != null)
					{
						throw error;
					}
				});
			}
			while (!lastActividadUnloaded)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00039868 File Offset: 0x00037A68
		private IEnumerator DoStartAndIntroduceActividad(Actividad actividad)
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated || !AsyncSingleton<RadialMenusForActivities>.instanceInitiated)
			{
				yield return null;
			}
			yield return actividad.DoStart();
			while (!AsyncSingleton<DialoguesForActivities>.instanceInitiated)
			{
				yield return null;
			}
			if (Singleton<InteraccionesEnScena>.IsInScene)
			{
				Singleton<InteraccionesEnScena>.instance.StartRecording();
			}
			yield return actividad.Introduce();
			yield break;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00039877 File Offset: 0x00037A77
		private IEnumerator ConcludeAndEndActividad(Actividad actividad)
		{
			yield return actividad.Conclude();
			if (Singleton<InteraccionesEnScena>.IsInScene)
			{
				Singleton<InteraccionesEnScena>.instance.EndRecordign();
			}
			Singleton<GameplayObjectives>.instance.UIPanel.Clear();
			yield return actividad.End();
			yield break;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00039886 File Offset: 0x00037A86
		private IEnumerator UnLoadLighting(Actividad toUnload)
		{
			if (toUnload.lightingAndGeometricsScene == toUnload.gameObject.scene || toUnload.lightingAndGeometricsScene == toUnload.loader.gameObject.scene)
			{
				Debug.LogError("cant unload lighting scene alone if its main scene");
				yield break;
			}
			yield return toUnload.loader.DoUnLoadLighting();
			yield break;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00039895 File Offset: 0x00037A95
		private IEnumerator UnLoadActividad(Actividad toUnload, Actividad next)
		{
			bool actividadYLoaderEnDiferentesRoots = false;
			Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(0);
			SceneManager.MoveGameObjectToScene(toUnload.gameObject, sceneByBuildIndex);
			if (toUnload.gameObject != toUnload.loader.gameObject)
			{
				actividadYLoaderEnDiferentesRoots = true;
				SceneManager.MoveGameObjectToScene(toUnload.loader.gameObject, sceneByBuildIndex);
			}
			yield return null;
			yield return toUnload.loader.DoUnLoad((next != null) ? next.loader : null);
			toUnload.OnUnLoadedByLoader();
			bool UnloadUnusedAssetsComplete = false;
			AsyncOperation a = Resources.UnloadUnusedAssets();
			a.completed += delegate(AsyncOperation ap)
			{
				UnloadUnusedAssetsComplete = true;
			};
			while (!UnloadUnusedAssetsComplete && !a.isDone)
			{
				yield return null;
			}
			Object.Destroy(toUnload.gameObject);
			if (actividadYLoaderEnDiferentesRoots)
			{
				Object.Destroy(toUnload.loader.gameObject);
			}
			yield break;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x000398AB File Offset: 0x00037AAB
		public void SetUIInputsActive(bool active)
		{
			this.m_inputEnabled.valor.valor = active;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000398C0 File Offset: 0x00037AC0
		private void OnEndedStartActividadRutine(MonoBehaviour owner, ManualCorrutina ended, Exception error, Action<Exception> onEnded)
		{
			this.m_inputEnabled.valor.valor = true;
			this.m_playerInputEnabled.valor.valor = true;
			this.m_LoadActividadRutina = null;
			if (ActividadesManager.m_ActividadLogicTEMP != null)
			{
				Object.Destroy(ActividadesManager.m_ActividadLogicTEMP);
				ActividadesManager.m_ActividadLogicTEMP = null;
			}
			if (onEnded != null)
			{
				onEnded(error);
			}
			if (error != null)
			{
				Singleton<ModalWindow>.instance.AcumularErrores(error, null);
			}
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00039930 File Offset: 0x00037B30
		public void GetPreferredTreatmentForClientsWeights(Guid characterID, out float nonSexual, out float softCore, out float hardcore)
		{
			Personalidad personalidad = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<Personalidad>(characterID, true);
			if (personalidad == null)
			{
				nonSexual = 0f;
				softCore = 0f;
				hardcore = 0f;
				return;
			}
			personalidad.GetPreferredTreatmentForClientsWeights(out nonSexual, out softCore, out hardcore);
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00039974 File Offset: 0x00037B74
		public void SetOutfit(Guid characterID, IConjuntoDeRopa outfit)
		{
			IRopaManager ropaManager = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<IRopaManager>(characterID, true);
			if (ropaManager == null)
			{
				return;
			}
			ropaManager.conjuntoToLoad = outfit;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00039999 File Offset: 0x00037B99
		public IEnumerator SetOutfitAndWait(Guid characterID, IConjuntoDeRopa outfit, bool showLoadingScreen = true)
		{
			IRopaManager ropaManager = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<IRopaManager>(characterID, true);
			if (ropaManager == null)
			{
				yield break;
			}
			yield return ropaManager.LoadConjuntoAsset(outfit, true, null, showLoadingScreen);
			yield break;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x000399B6 File Offset: 0x00037BB6
		public bool SinConjuntoCargadoNiCargando(Guid characterID, out IRopaManager ropaManager)
		{
			ropaManager = Singleton<CharacteresExistentesEnScena>.instance.FindSingleCachedComponent<IRopaManager>(characterID, true);
			return ropaManager == null || (!ropaManager.isLoadingConjunto && ropaManager.loadedConjunto == null);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x000399E4 File Offset: 0x00037BE4
		public bool SinConjuntoCargadoNiCargando(Guid characterID)
		{
			IRopaManager ropaManager;
			return this.SinConjuntoCargadoNiCargando(characterID, out ropaManager);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x000399FA File Offset: 0x00037BFA
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Show Current Activity EDIOR",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00039A13 File Offset: 0x00037C13
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.m_current_EDITOR_ONLY = this.current;
		}

		// Token: 0x04000550 RID: 1360
		public const string rootNameForActividadesBehaviours = "ActividadLogic";

		// Token: 0x04000551 RID: 1361
		private GlobalUpdater.Corrutina m_LoadActividadRutina;

		// Token: 0x04000552 RID: 1362
		[ReadOnlyUI]
		[SerializeField]
		private bool m_FlagForceNoReciclarScenas;

		// Token: 0x04000553 RID: 1363
		[SerializeField]
		private Actividad m_current_EDITOR_ONLY;

		// Token: 0x04000554 RID: 1364
		private Dictionary<string, ActividadesManager.ContextMemory> m_actividadMem = new Dictionary<string, ActividadesManager.ContextMemory>();

		// Token: 0x04000555 RID: 1365
		private Dictionary<string, ActividadesManager.ContextMemory> m_CharsInActividadMem = new Dictionary<string, ActividadesManager.ContextMemory>();

		// Token: 0x04000556 RID: 1366
		[SerializeField]
		private ActividadFemaleConfigMap[] m_configMaps;

		// Token: 0x04000557 RID: 1367
		[SerializeField]
		private ModificadorDeBool m_inputEnabled;

		// Token: 0x04000558 RID: 1368
		[SerializeField]
		private ModificadorDeBool m_playerInputEnabled;

		// Token: 0x04000559 RID: 1369
		private static List<GameObject> m_SceneRootGameObjects = new List<GameObject>();

		// Token: 0x0400055A RID: 1370
		private static List<Light> m_SceneLights = new List<Light>();

		// Token: 0x0400055B RID: 1371
		private static GameObject m_ActividadLogicTEMP;

		// Token: 0x020002B3 RID: 691
		private abstract class LoaderHandler
		{
			// Token: 0x06001234 RID: 4660 RVA: 0x00054034 File Offset: 0x00052234
			public IActividadLoader AddComponent(GameObject target)
			{
				IActividadLoader actividadLoader = this.OnAddComponent(target);
				this.OnAddedComponent(actividadLoader, target);
				return actividadLoader;
			}

			// Token: 0x06001235 RID: 4661
			protected abstract IActividadLoader OnAddComponent(GameObject target);

			// Token: 0x06001236 RID: 4662
			protected abstract void OnAddedComponent(IActividadLoader added, GameObject target);
		}

		// Token: 0x020002B4 RID: 692
		private class GenericLoaderHandler<T_ActividadLoader> : ActividadesManager.LoaderHandler where T_ActividadLoader : MonoBehaviour, IActividadLoader
		{
			// Token: 0x06001238 RID: 4664 RVA: 0x0005405A File Offset: 0x0005225A
			public GenericLoaderHandler(Action<T_ActividadLoader> onLoaderInstantiated)
			{
				this.m_onLoaderInstantiated = onLoaderInstantiated;
			}

			// Token: 0x06001239 RID: 4665 RVA: 0x00054069 File Offset: 0x00052269
			protected override IActividadLoader OnAddComponent(GameObject target)
			{
				return target.AddComponent<T_ActividadLoader>();
			}

			// Token: 0x0600123A RID: 4666 RVA: 0x00054076 File Offset: 0x00052276
			protected override void OnAddedComponent(IActividadLoader added, GameObject target)
			{
				Action<T_ActividadLoader> onLoaderInstantiated = this.m_onLoaderInstantiated;
				if (onLoaderInstantiated == null)
				{
					return;
				}
				onLoaderInstantiated((T_ActividadLoader)((object)added));
			}

			// Token: 0x04000C6D RID: 3181
			private Action<T_ActividadLoader> m_onLoaderInstantiated;
		}

		// Token: 0x020002B5 RID: 693
		private class TypeLoaderHandler : ActividadesManager.LoaderHandler
		{
			// Token: 0x0600123B RID: 4667 RVA: 0x0005408E File Offset: 0x0005228E
			public TypeLoaderHandler(Type loaderType, Action<IActividadLoader> onLoaderInstantiated)
			{
				if (!typeof(IActividadLoader).IsAssignableFrom(loaderType))
				{
					throw new InvalidOperationException();
				}
				this.m_onLoaderInstantiated = onLoaderInstantiated;
				this.m_loaderType = loaderType;
			}

			// Token: 0x0600123C RID: 4668 RVA: 0x000540BC File Offset: 0x000522BC
			protected override IActividadLoader OnAddComponent(GameObject target)
			{
				return (IActividadLoader)target.AddComponent(this.m_loaderType);
			}

			// Token: 0x0600123D RID: 4669 RVA: 0x000540CF File Offset: 0x000522CF
			protected override void OnAddedComponent(IActividadLoader added, GameObject target)
			{
				Action<IActividadLoader> onLoaderInstantiated = this.m_onLoaderInstantiated;
				if (onLoaderInstantiated == null)
				{
					return;
				}
				onLoaderInstantiated(added);
			}

			// Token: 0x04000C6E RID: 3182
			private Type m_loaderType;

			// Token: 0x04000C6F RID: 3183
			private Action<IActividadLoader> m_onLoaderInstantiated;
		}

		// Token: 0x020002B6 RID: 694
		public class ContextMemory
		{
			// Token: 0x0600123E RID: 4670 RVA: 0x000540E2 File Offset: 0x000522E2
			public ContextMemory(IJsonMemoryNode mem, string ActividadID)
			{
				this.m_mem = mem;
				this.m_actividadID = ActividadID;
			}

			// Token: 0x17000310 RID: 784
			// (get) Token: 0x0600123F RID: 4671 RVA: 0x000540F8 File Offset: 0x000522F8
			public string actividadID
			{
				get
				{
					return this.m_actividadID;
				}
			}

			// Token: 0x06001240 RID: 4672 RVA: 0x00054100 File Offset: 0x00052300
			public void AddData(string id, string data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001241 RID: 4673 RVA: 0x00054110 File Offset: 0x00052310
			public string FindData(string id, string defaultValue)
			{
				return this.m_mem.FindData(id, defaultValue);
			}

			// Token: 0x06001242 RID: 4674 RVA: 0x0005411F File Offset: 0x0005231F
			public void AddData(string id, bool data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001243 RID: 4675 RVA: 0x0005412F File Offset: 0x0005232F
			public bool FindDataBool(string id, bool defaultValue)
			{
				return this.m_mem.FindDataBool(id, defaultValue);
			}

			// Token: 0x06001244 RID: 4676 RVA: 0x0005413E File Offset: 0x0005233E
			public void AddData(string id, int data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001245 RID: 4677 RVA: 0x0005414E File Offset: 0x0005234E
			public int FindDataInt(string id, int defaultValue)
			{
				return this.m_mem.FindDataInt(id, defaultValue);
			}

			// Token: 0x06001246 RID: 4678 RVA: 0x0005415D File Offset: 0x0005235D
			public void AddData(int id, int data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001247 RID: 4679 RVA: 0x0005416D File Offset: 0x0005236D
			public int FindDataInt(int id, int defaultValue)
			{
				return this.m_mem.FindDataInt(id, defaultValue);
			}

			// Token: 0x06001248 RID: 4680 RVA: 0x0005417C File Offset: 0x0005237C
			public bool TryFindDataInt(string id, out int value)
			{
				return this.m_mem.TryFindDataInt(id, out value);
			}

			// Token: 0x06001249 RID: 4681 RVA: 0x0005418B File Offset: 0x0005238B
			public bool TryFindDataInt(int id, out int value)
			{
				return this.m_mem.TryFindDataInt(id, out value);
			}

			// Token: 0x0600124A RID: 4682 RVA: 0x0005419A File Offset: 0x0005239A
			public void AddData(string id, float data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x0600124B RID: 4683 RVA: 0x000541AA File Offset: 0x000523AA
			public void AddData(int id, float data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x0600124C RID: 4684 RVA: 0x000541BA File Offset: 0x000523BA
			public float FindDataFloat(string id, float defaultValue)
			{
				return this.m_mem.FindDataFloat(id, defaultValue);
			}

			// Token: 0x0600124D RID: 4685 RVA: 0x000541C9 File Offset: 0x000523C9
			public float FindDataFloat(int id, float defaultValue)
			{
				return this.m_mem.FindDataFloat(id, defaultValue);
			}

			// Token: 0x0600124E RID: 4686 RVA: 0x000541D8 File Offset: 0x000523D8
			public bool TryFindDataFloat(int id, out float value)
			{
				return this.m_mem.TryFindDataFloat(id, out value);
			}

			// Token: 0x0600124F RID: 4687 RVA: 0x000541E7 File Offset: 0x000523E7
			public bool TryFindDataFloat(string id, out float value)
			{
				return this.m_mem.TryFindDataFloat(id, out value);
			}

			// Token: 0x06001250 RID: 4688 RVA: 0x000541F6 File Offset: 0x000523F6
			public void AddData<T>(string id, List<T> data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001251 RID: 4689 RVA: 0x00054206 File Offset: 0x00052406
			public bool TryFindDataArrayEmpty<T>(string id, out List<T> value)
			{
				return this.m_mem.TryFindDataArrayEmpty(id, out value);
			}

			// Token: 0x06001252 RID: 4690 RVA: 0x00054215 File Offset: 0x00052415
			public bool TryFindDataArrayNull<T>(string id, out List<T> value)
			{
				return this.m_mem.TryFindDataArrayNull(id, out value);
			}

			// Token: 0x06001253 RID: 4691 RVA: 0x00054224 File Offset: 0x00052424
			public void AddData<T>(string id, T[] data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001254 RID: 4692 RVA: 0x00054234 File Offset: 0x00052434
			public bool TryFindDataArrayEmpty<T>(string id, out T[] value)
			{
				return this.m_mem.TryFindDataArrayEmpty(id, out value);
			}

			// Token: 0x06001255 RID: 4693 RVA: 0x00054243 File Offset: 0x00052443
			public bool TryFindDataArrayNull<T>(string id, out T[] value)
			{
				return this.m_mem.TryFindDataArrayNull(id, out value);
			}

			// Token: 0x06001256 RID: 4694 RVA: 0x00054252 File Offset: 0x00052452
			public void AddData(string id, Texture2D data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06001257 RID: 4695 RVA: 0x00054262 File Offset: 0x00052462
			public Texture2D FindDataImage(string id)
			{
				return this.m_mem.FindDataImage(id);
			}

			// Token: 0x06001258 RID: 4696 RVA: 0x00054270 File Offset: 0x00052470
			public bool TryFindDataImage(string id, ref Texture2D result)
			{
				return this.m_mem.TryFindDataImage(id, ref result);
			}

			// Token: 0x06001259 RID: 4697 RVA: 0x0005427F File Offset: 0x0005247F
			public void AddDataObject<TKey, TValue>(TKey id, TValue data, bool replace = true)
			{
				this.m_mem.AddDataObject(id, data, replace);
			}

			// Token: 0x0600125A RID: 4698 RVA: 0x0005428F File Offset: 0x0005248F
			public bool TryFindDataObject<TKey, TValue>(string id, out TKey key, out TValue value, TKey defaultKey, TValue defaultValue)
			{
				return this.m_mem.TryFindDataObject(id, out key, out value, defaultKey, defaultValue);
			}

			// Token: 0x0600125B RID: 4699 RVA: 0x000542A3 File Offset: 0x000524A3
			public void AddDataObject<T>(string id, T data, bool replace = true)
			{
				this.m_mem.AddDataObject(id, data, replace);
			}

			// Token: 0x0600125C RID: 4700 RVA: 0x000542B3 File Offset: 0x000524B3
			public bool TryFindDataObject<T>(string id, out T value, T defaultValue)
			{
				return this.m_mem.TryFindDataObject(id, out value, defaultValue);
			}

			// Token: 0x0600125D RID: 4701 RVA: 0x000542C3 File Offset: 0x000524C3
			public bool TryFindDataObject<T>(string id, Type type, out T value, T defaultValue) where T : class
			{
				return this.m_mem.TryFindDataObject(id, type, out value, defaultValue);
			}

			// Token: 0x0600125E RID: 4702 RVA: 0x000542D5 File Offset: 0x000524D5
			public bool TryFindDataObject(string id, Type type, out object value, object defaultValue)
			{
				return this.m_mem.TryFindDataObject(id, type, out value, defaultValue);
			}

			// Token: 0x0600125F RID: 4703 RVA: 0x000542E7 File Offset: 0x000524E7
			public bool RemoveData(string id)
			{
				return this.m_mem.RemoverData(id);
			}

			// Token: 0x06001260 RID: 4704 RVA: 0x000542F5 File Offset: 0x000524F5
			public void Clear()
			{
				this.m_mem.ClearData();
			}

			// Token: 0x04000C70 RID: 3184
			private readonly string m_actividadID;

			// Token: 0x04000C71 RID: 3185
			private readonly IJsonMemoryNode m_mem;
		}
	}
}
