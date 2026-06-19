using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Assets.Productos.Juegos.Reception;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.General.Scenas;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.AI.Holders;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Scenes;
using Assets._ReusableScripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.Globales
{
	// Token: 0x020000BF RID: 191
	public class SMAGameplayController : Singleton<SMAGameplayController>
	{
		// Token: 0x06000732 RID: 1842 RVA: 0x00028CD4 File Offset: 0x00026ED4
		protected override void DoAwake()
		{
			base.DoAwake();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00028CDC File Offset: 0x00026EDC
		private void Start()
		{
			if (Singleton<PlayerInputProxy>.IsInScene)
			{
				this.m_inputMod = Singleton<PlayerInputProxy>.instance.activoModificableOverallAND.ObtenerModificadorNotNull(this);
			}
			this.m_hidingLoadingUI = Singleton<LoadingPanel>.instance.hidingModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00028D11 File Offset: 0x00026F11
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			if (Singleton<PlayerInputProxy>.IsInScene)
			{
				ModificadorDeBool inputMod = this.m_inputMod;
				if (inputMod != null)
				{
					inputMod.TryRemoverDeOwner(true);
				}
			}
			if (Singleton<LoadingPanel>.IsInScene)
			{
				ModificadorDeBool hidingLoadingUI = this.m_hidingLoadingUI;
				if (hidingLoadingUI == null)
				{
					return;
				}
				hidingLoadingUI.TryRemoverDeOwner(true);
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00028D4D File Offset: 0x00026F4D
		public int GetCurrentMaxPosibleModelsEmployees()
		{
			this.m_officeLvl = MemoriaDeSMAGamePlay.GetCurrentOfficeLvl(GlobalSingletonV2<MemoriaJson>.instance);
			return this.configEmplyment.vacanciesPerLvl * (this.m_officeLvl + 1);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00028D74 File Offset: 0x00026F74
		public bool IsHired(string npcID)
		{
			List<string> list = new List<string>();
			MemoriaDeSMAModelosFemeninas.HiredNPCs(GlobalSingletonV2<MemoriaJson>.instance, list);
			return list.Contains(npcID);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00028D99 File Offset: 0x00026F99
		public bool CanBeHired(string npcID, bool checkIfIsAlreadyHired)
		{
			return !checkIfIsAlreadyHired || !this.IsHired(npcID);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00028DAC File Offset: 0x00026FAC
		public bool VacantesDisponibles()
		{
			int num = MemoriaDeSMAModelosFemeninas.HiredNPCCount(GlobalSingletonV2<MemoriaJson>.instance);
			int currentMaxPosibleModelsEmployees = this.GetCurrentMaxPosibleModelsEmployees();
			return num < currentMaxPosibleModelsEmployees;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00028DD0 File Offset: 0x00026FD0
		public bool TryHire(string npcID, float salario, float comision, Texture2D portrait = null, bool disposePortrait = false, ICharacter character = null)
		{
			ISujetoIdentificableNpc sujetoIdentificableNpc = LoaderDeNpcFemeninos.ReadFromMemoryNPC(npcID, GlobalSingletonV2<MemoriaJson>.instance);
			bool flag;
			try
			{
				LoaderDeNpcFemeninos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, sujetoIdentificableNpc, character, portrait);
				if (!MemoriaDeSMAModelosFemeninas.TryWriteNPCAsHired(GlobalSingletonV2<MemoriaJson>.instance, npcID, salario, comision))
				{
					MemoriaDeSujetosNpcFemenina.BorrarNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID, false);
					flag = false;
				}
				else
				{
					Singleton<PiscinaDeCampaingActual>.instance.RemoveHiredNPCIDFromPoolMem(npcID);
					flag = true;
				}
			}
			finally
			{
				if (sujetoIdentificableNpc != null)
				{
					sujetoIdentificableNpc.Destruir();
				}
				if (disposePortrait && portrait != null)
				{
					Object.Destroy(portrait);
				}
			}
			return flag;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00028E58 File Offset: 0x00027058
		public bool TryFire(string npcID, out float salary)
		{
			float num;
			MemoriaDeSMAModelosFemeninas.GetModeSalaryAndCommission(GlobalSingletonV2<MemoriaJson>.instance, npcID, out salary, out num);
			MemoriaDeSMAModelosFemeninas.EraseNPCAsHired(GlobalSingletonV2<MemoriaJson>.instance, npcID);
			MemoriaDeSujetosNpcFemenina.BorrarNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID, false);
			return true;
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00028E8C File Offset: 0x0002708C
		public bool CampaingExiste()
		{
			bool flag = Singleton<SimplifiedAutoRatings>.instance.autoRatingProfile != null;
			bool flag2 = Singleton<PiscinaDeCampaingActual>.instance.CampaingExiste();
			if (!flag || !flag2)
			{
				if (flag != flag2)
				{
					this.EndCampaing();
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00028EC5 File Offset: 0x000270C5
		public void EndCampaing()
		{
			Singleton<SimplifiedAutoRatings>.instance.RemoveProfile(true);
			Singleton<PiscinaDeCampaingActual>.instance.EndCampaing();
			GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Campaing/").ClearData();
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00028EF0 File Offset: 0x000270F0
		public int GetCantidadMaximaDePhasesDeCampaing()
		{
			return GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Campaing/").FindDataInt("PhasesC", 3);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00028F0C File Offset: 0x0002710C
		public int GetCantidadMaximaDeNextPhasesDeCampaing()
		{
			return this.GetCantidadMaximaDePhasesDeCampaing() - 1;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00028F16 File Offset: 0x00027116
		public int GetCurrentIndexDePhasesDeCampaing()
		{
			return GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Campaing/").FindDataInt("PhaseI", 0);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00028F32 File Offset: 0x00027132
		public SMAGameplayController.CampaingType GetCurrentCampaingType()
		{
			return (SMAGameplayController.CampaingType)GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Campaing/").FindDataInt("Type", 0);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00028F50 File Offset: 0x00027150
		public int GetInterviwedModelsCountInCurrentCampaing()
		{
			int num = 0;
			foreach (ISujetoIdentificableNpc sujetoIdentificableNpc in ((IEnumerable<ISujetoIdentificableNpc>)Singleton<PiscinaDeCampaingActual>.instance))
			{
				ISujetoCalificable sujetoCalificable = sujetoIdentificableNpc as ISujetoCalificable;
				if (sujetoCalificable != null && sujetoCalificable.interviewed)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00028FAC File Offset: 0x000271AC
		public int GetModelsCountInCurrentCampaing()
		{
			return Singleton<PiscinaDeCampaingActual>.instance.Count;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00028FB8 File Offset: 0x000271B8
		public void StartCampaing(SMAGameplayController.CampaingType type, string autoRatingProfile, float cost)
		{
			if (this.m_forzarCampaingTESTING && Application.isEditor)
			{
				type = SMAGameplayController.CampaingType.testing;
			}
			if (this.m_CampaingCambiado)
			{
				throw new InvalidOperationException("Primero se debe terminanrse el proceso actual");
			}
			if (this.CampaingExiste())
			{
				throw new InvalidOperationException("Primero se debe finalizar la campaña pasada");
			}
			try
			{
				Texture2D texture2D;
				byte[] array;
				SaveLoadProfilePortraits.Cargar(autoRatingProfile, out texture2D, out array);
				AutoRatingWraper autoRatingWraper = JsonUtility.FromJson<AutoRatingWraper>(Encoding.UTF8.GetString(array));
				Singleton<SimplifiedAutoRatings>.instance.ChangeProfile(autoRatingWraper.modo, autoRatingProfile, ref autoRatingWraper.simple, ref autoRatingWraper.completa, texture2D, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				return;
			}
			int phasesDeTypo = this.GetPhasesDeTypo(type);
			int num;
			int num2;
			switch (type)
			{
			case SMAGameplayController.CampaingType.free:
				num = this.configCampaing.freeforAllSujetosCount;
				num2 = 0;
				break;
			case SMAGameplayController.CampaingType.amateur:
				num = this.configCampaing.amateurSujetosCount;
				num2 = 1;
				break;
			case SMAGameplayController.CampaingType.professional:
				num = this.configCampaing.professionalSujetosCount;
				num2 = 2;
				break;
			case SMAGameplayController.CampaingType.testing:
				num = 100;
				num2 = 0;
				break;
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
			int num3 = num2 + 1;
			this.m_costoCampaing = cost;
			this.m_CampaingCambiado = true;
			this.m_inputMod.valor.valor = false;
			GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, this, this.CreatingPoolAndStartCampaingRutine(type, phasesDeTypo, num, num3, new Action<bool>(this.OnCampaingStartResult)), new ManualCorrutina.OnEndedHandler(this.OnCampaingStartRutineEnded));
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00029118 File Offset: 0x00027318
		private IEnumerator CreatingPoolAndStartCampaingRutine(SMAGameplayController.CampaingType type, int phases, int count, int rondas, Action<bool> resultado)
		{
			bool errorInCampaing = false;
			ManualCorrutina.OnEndedHandler onEndedCampaing = delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				if (error != null)
				{
					Debug.LogError("no se pudo completar la Campaing", this);
					errorInCampaing = true;
				}
			};
			this.m_hidingLoadingUI.valor.valor = false;
			yield return null;
			if (Singleton<LoadingPanel>.IsInScene)
			{
				LoadingPanel instance = Singleton<LoadingPanel>.instance;
				instance.nextUserText = instance.defaultText + " Creating Pool...";
			}
			int num;
			for (int i = 0; i < 10; i = num + 1)
			{
				yield return null;
				num = i;
			}
			Singleton<PiscinaDeCampaingActual>.instance.StartCampaing(count);
			int num2 = 0;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Campaing/");
			jsonMemoryNode.AddData("Type", (int)type, true);
			jsonMemoryNode.AddData("PhasesC", phases, true);
			jsonMemoryNode.AddData("PhaseI", num2, true);
			if (Singleton<LoadingPanel>.IsInScene)
			{
				LoadingPanel instance2 = Singleton<LoadingPanel>.instance;
				instance2.nextUserText = instance2.defaultText + " Creating Models...";
			}
			GlobalUpdater.Corrutina startCampaingRutine = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.StartOrGoNextPhaseCampaingRutine(type, num2, rondas, true, resultado), onEndedCampaing);
			while (!startCampaingRutine.finalizada)
			{
				yield return null;
			}
			if (errorInCampaing)
			{
				Debug.LogError("Error stating Campaing, campaing will be terminated", this);
				resultado(false);
				yield break;
			}
			yield break;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0002914C File Offset: 0x0002734C
		private IEnumerator StartOrGoNextPhaseCampaingRutine(SMAGameplayController.CampaingType type, int phaseActual, int rounds, bool puedeReproducir, Action<bool> resultado)
		{
			this.m_hidingLoadingUI.valor.valor = false;
			SMAGameplayController.<>c__DisplayClass34_1 CS$<>8__locals2 = new SMAGameplayController.<>c__DisplayClass34_1();
			CS$<>8__locals2.ratingSceneLoaded = false;
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 9;
			@default.doLoadOrDoUnload = true;
			@default.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				CS$<>8__locals2.ratingSceneLoaded = true;
			};
			Singleton<SceneLoader>.instance.AddPedido(@default);
			while (!CS$<>8__locals2.ratingSceneLoaded)
			{
				yield return null;
			}
			CS$<>8__locals2 = null;
			yield return null;
			Scene ratingSceneStruck = SceneManager.GetSceneByBuildIndex(9);
			StandAloneRatingScene ratingScene = SceneSingletonV2<StandAloneRatingScene>.Instance(ratingSceneStruck);
			if (ratingScene == null)
			{
				Debug.LogError("no existe StandAloneRatingScene", this);
				resultado(false);
				yield break;
			}
			bool errorInRounds = false;
			ManualCorrutina.OnEndedHandler onEndedRound = delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				if (error != null)
				{
					Debug.LogError("no se completar ronda de rating", this);
					errorInRounds = true;
				}
			};
			float currentProgress = 0f;
			Action<float> onUpdateProgress = delegate(float adding)
			{
				currentProgress += adding;
				if (Singleton<LoadingPanel>.IsInScene)
				{
					LoadingPanel instance = Singleton<LoadingPanel>.instance;
					instance.nextUserText = instance.defaultText + " Creating Models... (" + currentProgress.ToString("0.0") + "%)";
				}
			};
			float loadingProgressPerRound = 100f / (float)rounds;
			int num;
			for (int i = 0; i < rounds; i = num + 1)
			{
				bool isLastRound = i.IsLastIndex(rounds);
				GlobalUpdater.Corrutina roundRutine = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.RateModelsInCampaingRutine(ratingScene, ratingSceneStruck, type, phaseActual, isLastRound, loadingProgressPerRound, onUpdateProgress, resultado), onEndedRound);
				while (!roundRutine.finalizada)
				{
					yield return null;
				}
				yield return null;
				if (Singleton<PiscinaDeCampaingActual>.instance.ObtenerSujetoNonRated() != null)
				{
					Debug.LogError("no se lograron calificar todos los npc", this);
					resultado(false);
					yield break;
				}
				if (!isLastRound && puedeReproducir)
				{
					Singleton<PiscinaDeCampaingActual>.instance.Reproducir();
				}
				roundRutine = null;
				num = i;
			}
			if (errorInRounds)
			{
				Debug.LogError("Error rating models in round, campaing will be terminated", this);
				resultado(false);
				yield break;
			}
			SMAGameplayController.<>c__DisplayClass34_2 CS$<>8__locals3 = new SMAGameplayController.<>c__DisplayClass34_2();
			CS$<>8__locals3.ratingSceneUnLoaded = false;
			SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
			default2.scene.index = 9;
			default2.doLoadOrDoUnload = false;
			default2.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				CS$<>8__locals3.ratingSceneUnLoaded = true;
			};
			Singleton<SceneLoader>.instance.AddPedido(default2);
			while (!CS$<>8__locals3.ratingSceneUnLoaded)
			{
				yield return null;
			}
			CS$<>8__locals3 = null;
			resultado(true);
			yield break;
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00029180 File Offset: 0x00027380
		private IEnumerator RateModelsInCampaingRutine(StandAloneRatingScene ratingScene, Scene scene, SMAGameplayController.CampaingType type, int phaseActual, bool isLastRound, float loadingProgressPerRound, Action<float> updateProgress, Action<bool> resultado)
		{
			int count = Singleton<PiscinaDeCampaingActual>.instance.Count;
			int slots = 12;
			bool errorRatingNpcs = false;
			ManualCorrutina.OnEndedHandler onEndedRating = delegate(MonoBehaviour owner, ManualCorrutina ended, Exception error)
			{
				if (error != null)
				{
					Debug.LogError("no se puto ratear un npc", this);
					errorRatingNpcs = true;
				}
				int slots2 = slots;
				slots = slots2 + 1;
			};
			float loadingProgressPerModel = loadingProgressPerRound / (float)Singleton<PiscinaDeCampaingActual>.instance.Count;
			List<GlobalUpdater.Corrutina> RateNPCRutinas = new List<GlobalUpdater.Corrutina>();
			List<IFemaleCharInfoPromediable> infosResult = new List<IFemaleCharInfoPromediable>();
			int modelIndex = 0;
			int num;
			foreach (ISujetoIdentificableNpc npc in ((IEnumerable<ISujetoIdentificableNpc>)Singleton<PiscinaDeCampaingActual>.instance))
			{
				int slots3 = slots;
				while (slots <= 0)
				{
					yield return null;
				}
				yield return null;
				GlobalUpdater.Corrutina corrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update3, this, this.RateNPCRutine(ratingScene, scene, npc, type, phaseActual, isLastRound, loadingProgressPerModel, infosResult, updateProgress), onEndedRating);
				RateNPCRutinas.Add(corrutina);
				num = slots;
				slots = num - 1;
				num = modelIndex;
				modelIndex = num + 1;
				npc = null;
			}
			IEnumerator<ISujetoIdentificableNpc> enumerator = null;
			for (int i = 0; i < RateNPCRutinas.Count; i = num + 1)
			{
				while (!RateNPCRutinas[i].finalizada)
				{
					yield return null;
				}
				num = i;
			}
			if (Application.isEditor && infosResult.Count > 0)
			{
				IFemaleCharInfoPromediable femaleCharInfoPromediable = infosResult.Promedio();
				Debug.LogWarning("Individuos: " + infosResult.Count.ToString() + "\n" + JsonUtility.ToJson(femaleCharInfoPromediable, true));
			}
			if (errorRatingNpcs)
			{
				Debug.LogError("Error rating models, campaing will be terminated", this);
				resultado(false);
				yield break;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x000291D8 File Offset: 0x000273D8
		private IEnumerator RateNPCRutine(StandAloneRatingScene ratingScene, Scene scene, ISujetoIdentificableNpc npc, SMAGameplayController.CampaingType type, int phaseActual, bool loadInfo, float loadingProgressPerModel, IList<IFemaleCharInfoPromediable> infosResult, Action<float> updateProgress)
		{
			float loadingProgressPerProcedimiento = loadingProgressPerModel / 4f;
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(0.025f);
			StandAloneRatingScene.Slot slot = ratingScene.GetSlot();
			slot.SetData(npc);
			slot.Instantiate(scene);
			updateProgress(loadingProgressPerProcedimiento);
			yield return w;
			slot.LoadNPCToFemaleChar();
			updateProgress(loadingProgressPerProcedimiento);
			yield return w;
			yield return w;
			yield return w;
			if (loadInfo)
			{
				bool terminoInfoLoading = false;
				Action<bool> action = delegate(bool r)
				{
					if (!r)
					{
						Debug.LogError("Fallo generando info de npc: " + npc.NpcID.ToString(), this);
					}
					terminoInfoLoading = true;
				};
				CurriculumVitaeSmallInfo info = new CurriculumVitaeSmallInfo();
				base.StartCoroutine(this.LoadSmallInfoRutine(slot.instantiatedFemale, info, infosResult, action));
				while (!terminoInfoLoading)
				{
					yield return null;
				}
				MemoriaDeSujetosNpcFemenina.EscribirPortraitDeNpcAMemoria(GlobalSingletonV2<MemoriaJson>.instance, npc, info.imagen);
				npc.dataContainer.AddData("height", info.height, true);
				npc.dataContainer.AddData("chest", info.chest, true);
				npc.dataContainer.AddData("waist", info.waist, true);
				npc.dataContainer.AddData("hips", info.hips, true);
				this.OverrideGenes(npc, type, phaseActual);
				info = null;
			}
			updateProgress(loadingProgressPerProcedimiento);
			IReadOnlyDictionary<string, float> readOnlyDictionary;
			IReadOnlyDictionary<string, float> readOnlyDictionary2;
			slot.DoAutoRating(out readOnlyDictionary, out readOnlyDictionary2);
			foreach (KeyValuePair<string, float> keyValuePair in readOnlyDictionary)
			{
				Singleton<PiscinaDeCampaingActual>.instance.flagScoreAparienciaCurrentFemaleV2.AddOrReplase(keyValuePair.Key, keyValuePair.Value);
			}
			foreach (KeyValuePair<string, float> keyValuePair2 in readOnlyDictionary2)
			{
				Singleton<PiscinaDeCampaingActual>.instance.flagScorePersonalidadCurrentFemaleV2.AddOrReplase(keyValuePair2.Key, keyValuePair2.Value);
			}
			Singleton<PiscinaDeCampaingActual>.instance.SetFemaleRate(npc.NpcID);
			updateProgress(loadingProgressPerProcedimiento);
			yield return null;
			slot.Destroy();
			yield return null;
			yield break;
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00029237 File Offset: 0x00027437
		private int GetPhasesDeTypo(SMAGameplayController.CampaingType type)
		{
			switch (type)
			{
			case SMAGameplayController.CampaingType.free:
			case SMAGameplayController.CampaingType.testing:
				return 2;
			case SMAGameplayController.CampaingType.amateur:
				return 3;
			case SMAGameplayController.CampaingType.professional:
				return 4;
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0002926C File Offset: 0x0002746C
		private void OverrideGenes(ISujetoIdentificableNpc npc, SMAGameplayController.CampaingType type, int phaseActual)
		{
			float num;
			float num2;
			float num3;
			float num4;
			float num5;
			float num6;
			switch (type)
			{
			case SMAGameplayController.CampaingType.free:
			case SMAGameplayController.CampaingType.testing:
				num = 0f;
				num2 = 1f;
				num3 = 3f;
				num4 = 1f;
				num5 = 1f;
				num6 = 1f;
				break;
			case SMAGameplayController.CampaingType.amateur:
				num = 0.5f;
				num2 = 2f;
				num3 = 2f;
				num4 = 3f;
				num5 = 3f;
				num6 = 1f;
				break;
			case SMAGameplayController.CampaingType.professional:
				num = 1f;
				num2 = 3f;
				num3 = 1f;
				num4 = 99f;
				num5 = 6f;
				num6 = 1.4f;
				break;
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
			MapaDeAlteracionesPersonalidadFemeninaBase @base = (npc.personalidad as SujetoAlteradoresPersonalidadFemeninos).@base;
			@base.PrepareAlteradoresDicc();
			ModificadoresDeAlterador modificadoresDeAlterador = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.pobreza]];
			ModificadoresDeAlterador modificadoresDeAlterador2 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorDinero]];
			this.OverrideGeneDeTrait(modificadoresDeAlterador, num3, num2, 1f - num);
			this.OverrideGeneDeTrait(modificadoresDeAlterador2, num2, num3, num);
			ModificadoresDeAlterador modificadoresDeAlterador3 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorModelaje]];
			ModificadoresDeAlterador modificadoresDeAlterador4 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorModelajeUnderwear]];
			ModificadoresDeAlterador modificadoresDeAlterador5 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorModelajeHerotico]];
			this.OverrideGeneDeTrait(modificadoresDeAlterador3, num4);
			this.OverrideGeneDeTrait(modificadoresDeAlterador4, num5);
			this.OverrideGeneDeTrait(modificadoresDeAlterador5, num6);
			ModificadoresDeAlterador modificadoresDeAlterador6 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorTratoDeClientes]];
			ModificadoresDeAlterador modificadoresDeAlterador7 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorTratoEspecialDeClientes]];
			ModificadoresDeAlterador modificadoresDeAlterador8 = @base.preparedAlteradoresDicc[AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorTratoExplicitoDeClientes]];
			this.OverrideGeneDeTrait(modificadoresDeAlterador6, 3f);
			this.OverrideGeneDeTrait(modificadoresDeAlterador7, 0.5f);
			this.OverrideGeneDeTrait(modificadoresDeAlterador8, 0.25f);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0002945C File Offset: 0x0002765C
		private void OverrideGeneDeTrait(ModificadoresDeAlterador mod, float outPowToMiddle, float inPowToMiddle, float middle)
		{
			for (int i = 0; i < mod.modificadores.Length; i++)
			{
				float num = Random.value.InInOutOutPowInverted(outPowToMiddle, inPowToMiddle, middle);
				mod.modificadores[i] = Mathf.Lerp(0.05f, 1f, num);
			}
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x000294A4 File Offset: 0x000276A4
		private void OverrideGeneDeTrait(ModificadoresDeAlterador mod, float outPow)
		{
			for (int i = 0; i < mod.modificadores.Length; i++)
			{
				float num = Random.value.OutPow(outPow);
				mod.modificadores[i] = Mathf.Lerp(0.05f, 1f, num);
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x000294E8 File Offset: 0x000276E8
		private IEnumerator LoadSmallInfoRutine(Character character, CurriculumVitaeSmallInfo infoResult, IList<IFemaleCharInfoPromediable> infosResult, Action<bool> result)
		{
			SelfPortraitCamera selfPortraitCamera = character.GetComponentInChildren<SelfPortraitCamera>();
			if (selfPortraitCamera == null)
			{
				Debug.LogError("Character: " + character.nombreCompleto + " no tiene SelfPortraitCamera", character);
				result(false);
				yield break;
			}
			selfPortraitCamera.TurnOnFlash();
			yield return new WaitForSeconds(0.333f);
			IFemaleCharInfo componentInChildren = character.GetComponentInChildren<IFemaleCharInfo>();
			if (componentInChildren == null)
			{
				Debug.LogError("Character: " + character.nombreCompleto + " no tiene IFemaleCharInfo", character);
				result(false);
				yield break;
			}
			componentInChildren.ActualizarInfo();
			infoResult.height = Mathf.RoundToInt(character.estatura * 100f).ToString() + " cm";
			infoResult.chest = componentInChildren.chest.ToString() + "(" + componentInChildren.cup + " Cup) cm";
			infoResult.waist = componentInChildren.waist.ToString() + " cm";
			infoResult.hips = componentInChildren.hips.ToString() + " cm";
			if (Application.isEditor)
			{
				infosResult.Add(componentInChildren.GetPromediableData());
			}
			yield return new WaitForEndOfFrame();
			infoResult.imagen = selfPortraitCamera.TakeFemalePortrait();
			result(true);
			yield break;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0002950D File Offset: 0x0002770D
		private void OnCampaingStartResult(bool exito)
		{
			if (!exito)
			{
				Debug.LogError("Could not start a new campaign", this);
				this.EndCampaing();
				return;
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00029524 File Offset: 0x00027724
		private void OnCampaingStartRutineEnded(MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.m_CampaingCambiado = false;
			this.m_inputMod.valor.valor = true;
			this.m_hidingLoadingUI.valor.valor = true;
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
			if (characterWallet2 != null)
			{
				characterWallet2.Change("fiat", -this.m_costoCampaing, "Latest campaign expense");
			}
			this.m_costoCampaing = 0f;
			if (error != null)
			{
				Debug.LogException(error, this);
				this.OnCampaingStartResult(false);
				return;
			}
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
			Singleton<MainCanvas>.instance.MostrartMsg("", "A new campaign was launched.", 5f, true, null, null, null);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00029600 File Offset: 0x00027800
		public void GoNextCampaingPhase()
		{
			if (this.m_CampaingCambiado)
			{
				throw new InvalidOperationException("Primero se debe terminanrse el proceso actual");
			}
			if (!this.CampaingExiste())
			{
				throw new InvalidOperationException("Primero se debe comenzar una campaña");
			}
			try
			{
				Singleton<PiscinaDeCampaingActual>.instance.Reproducir();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				return;
			}
			int num = 1;
			this.m_CampaingCambiado = true;
			this.m_inputMod.valor.valor = false;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Campaing/");
			SMAGameplayController.CampaingType campaingType = (SMAGameplayController.CampaingType)jsonMemoryNode.FindDataInt("Type", 0);
			int num2 = jsonMemoryNode.FindDataInt("PhaseI", 0) + 1;
			jsonMemoryNode.AddData("PhaseI", num2, true);
			GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.StartOrGoNextPhaseCampaingRutine(campaingType, num2, num, false, new Action<bool>(this.OnGoNextCampaingPhaseResult)), new ManualCorrutina.OnEndedHandler(this.OnGoNextCampaingPhaseEnded));
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000296DC File Offset: 0x000278DC
		private void OnGoNextCampaingPhaseResult(bool exito)
		{
			if (!exito)
			{
				Debug.LogError("Could not Go Next campaign Phase", this);
				this.EndCampaing();
				return;
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x000296F4 File Offset: 0x000278F4
		private void OnGoNextCampaingPhaseEnded(MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.m_CampaingCambiado = false;
			this.m_inputMod.valor.valor = true;
			this.m_hidingLoadingUI.valor.valor = true;
			if (error != null)
			{
				Debug.LogException(error, this);
				this.OnCampaingStartResult(false);
				return;
			}
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
			Singleton<MainCanvas>.instance.MostrartMsg("", "A new campaign phase started.", 5f, true, null, null, null);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00029788 File Offset: 0x00027988
		public override void Aplicar1()
		{
			base.Aplicar1();
			foreach (ISujetoIdentificableNpc sujetoIdentificableNpc in ((IEnumerable<ISujetoIdentificableNpc>)Singleton<PiscinaDeCampaingActual>.instance))
			{
				Singleton<PiscinaDeCampaingActual>.instance.SetFemaleAsInterviewed(sujetoIdentificableNpc.NpcID);
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x000297E4 File Offset: 0x000279E4
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "DEBUG flag all as interviewd",
				editorTimeVisible = false
			};
		}

		// Token: 0x04000427 RID: 1063
		public const string campaingTypeSaveName = "Type";

		// Token: 0x04000428 RID: 1064
		public const string campaingPhasesCountSaveName = "PhasesC";

		// Token: 0x04000429 RID: 1065
		public const string campaingCurrentPhasesSaveName = "PhaseI";

		// Token: 0x0400042A RID: 1066
		public const int freeforAllSujetosLvl = 0;

		// Token: 0x0400042B RID: 1067
		public const int amateurSujetosLvl = 1;

		// Token: 0x0400042C RID: 1068
		public const int professionalSujetosLvl = 2;

		// Token: 0x0400042D RID: 1069
		public SMAGameplayController.ConfigEmplyment configEmplyment = new SMAGameplayController.ConfigEmplyment();

		// Token: 0x0400042E RID: 1070
		public SMAGameplayController.ConfigCampaing configCampaing = new SMAGameplayController.ConfigCampaing();

		// Token: 0x0400042F RID: 1071
		[SerializeField]
		private int m_officeLvl;

		// Token: 0x04000430 RID: 1072
		[SerializeField]
		private ModificadorDeBool m_inputMod;

		// Token: 0x04000431 RID: 1073
		[SerializeField]
		[ReadOnlyUI]
		private bool m_CampaingCambiado;

		// Token: 0x04000432 RID: 1074
		[SerializeField]
		[ReadOnlyUI]
		private float m_costoCampaing;

		// Token: 0x04000433 RID: 1075
		[SerializeField]
		private bool m_forzarCampaingTESTING;

		// Token: 0x04000434 RID: 1076
		private ModificadorDeBool m_hidingLoadingUI;

		// Token: 0x0200023F RID: 575
		[Serializable]
		public class ConfigEmplyment
		{
			// Token: 0x04000AB8 RID: 2744
			public int vacanciesPerLvl = 1;
		}

		// Token: 0x02000240 RID: 576
		[Serializable]
		public class ConfigCampaing
		{
			// Token: 0x04000AB9 RID: 2745
			public int freeforAllSujetosCount = 12;

			// Token: 0x04000ABA RID: 2746
			public int amateurSujetosCount = 24;

			// Token: 0x04000ABB RID: 2747
			public int professionalSujetosCount = 36;
		}

		// Token: 0x02000241 RID: 577
		public enum CampaingType
		{
			// Token: 0x04000ABD RID: 2749
			[DescripcionLocalizado("Open to everyone", "US")]
			free,
			// Token: 0x04000ABE RID: 2750
			[DescripcionLocalizado("Only amateurs are allowed", "US")]
			amateur,
			// Token: 0x04000ABF RID: 2751
			[DescripcionLocalizado("Exclusive to professionals", "US")]
			professional,
			// Token: 0x04000AC0 RID: 2752
			testing
		}
	}
}
