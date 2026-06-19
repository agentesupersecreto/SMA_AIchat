using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos;
using Assets.TValle.Pro.Entrevista.Runtime.General.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.Clothing;
using Assets.TValle.Tools.Runtime.Memory;
using Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.Inputs;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using InterfaceFields;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x0200005B RID: 91
	public class JobsManager : AsyncSingleton<JobsManager>, ISMAJobsManager
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00010949 File Offset: 0x0000EB49
		public ISMAJobsUIManager UI
		{
			get
			{
				return this.m_JobsUIManager;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00010951 File Offset: 0x0000EB51
		public ISceneInteractions interactions
		{
			get
			{
				return Singleton<InteraccionesEnScena>.instance;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00010958 File Offset: 0x0000EB58
		public ISMAJobsObjectives objectives
		{
			get
			{
				return this.m_Objectives;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00010960 File Offset: 0x0000EB60
		public ISMAJobsOutfits outfits
		{
			get
			{
				return this.m_Outfits;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00010968 File Offset: 0x0000EB68
		public bool isloadingJob
		{
			get
			{
				return this.m_loadingJob || Singleton<ActividadesManager>.instance.isloadingActividad;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0001097E File Offset: 0x0000EB7E
		public Language gameLanguage
		{
			get
			{
				return ModdingParser.GetLanguage();
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00010985 File Offset: 0x0000EB85
		public ISMAJob current
		{
			get
			{
				return this.currentJob;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0001098D File Offset: 0x0000EB8D
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0001099A File Offset: 0x0000EB9A
		private ISMAJob currentJob
		{
			get
			{
				return this.m_currentJob as ISMAJob;
			}
			set
			{
				this.m_currentJob = value as Object;
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000109A8 File Offset: 0x0000EBA8
		protected override void Awaking()
		{
			base.Awaking();
			this.m_JobsUIManager = base.GetComponent<JobsUIManager>();
			if (this.m_JobsUIManager == null)
			{
				throw new ArgumentNullException("m_JobsUIManager", "m_JobsUIManager null reference.");
			}
			this.m_Objectives.Init(this);
			this.m_Outfits.Init(this);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00010A00 File Offset: 0x0000EC00
		protected override void InitSyncData(bool esEditorTime)
		{
			this.m_GameJobs = new Dictionary<string, SMAJobMap>();
			foreach (SMAJobMap smajobMap in this.m_allGameJobs)
			{
				if (this.m_GameJobs.ContainsKey(smajobMap.id))
				{
					Debug.LogError("job repetido TODO");
				}
				else
				{
					this.m_GameJobs.Add(smajobMap.id, smajobMap);
				}
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00010A88 File Offset: 0x0000EC88
		protected override IEnumerator PreInitData()
		{
			while (!Singleton<ActividadesManager>.IsInScene)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00010A90 File Offset: 0x0000EC90
		protected override void DoAwake()
		{
			base.DoAwake();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00010A98 File Offset: 0x0000EC98
		protected override void Initiated()
		{
			base.Initiated();
			if (this.m_testMapAtStart && this.m_mapToTest)
			{
				this.Aplicar1();
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00010ABB File Offset: 0x0000ECBB
		public IContextMemory GetMemory(ISMAJob job)
		{
			return this.GetMemory(job.ID);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00010ACC File Offset: 0x0000ECCC
		public IContextMemory GetMemory(string jobID)
		{
			string text = "root/Activity/" + jobID;
			JobsManager.JobContextMemory jobContextMemory;
			if (!this.m_actividadMem.TryGetValue(text, out jobContextMemory))
			{
				jobContextMemory = new JobsManager.JobContextMemory(Singleton<ActividadesManager>.instance.GetMemory(jobID), jobID);
				this.m_actividadMem.Add(text, jobContextMemory);
			}
			return jobContextMemory;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00010B18 File Offset: 0x0000ED18
		public IContextMemory GetCharacterInMemory(ISMAJob job, SceneCharacter character)
		{
			return this.GetCharacterInMemory(job.ID, character.ID.ToString());
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00010B48 File Offset: 0x0000ED48
		public IContextMemory GetCharacterInMemory(string jobID, string characterID)
		{
			string text = string.Format("root/NPC/{0}/Activity/{1}/", characterID, jobID);
			JobsManager.JobContextMemory jobContextMemory;
			if (!this.m_CharsInActividadMem.TryGetValue(text, out jobContextMemory))
			{
				jobContextMemory = new JobsManager.JobContextMemory(Singleton<ActividadesManager>.instance.GetCharacterInMemory(jobID, characterID), jobID);
				this.m_CharsInActividadMem.Add(text, jobContextMemory);
			}
			return jobContextMemory;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00010B93 File Offset: 0x0000ED93
		public void UpdateCharacterMemory(SceneCharacter character)
		{
			LoaderDeNpc.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, character.GetComponentEnRoot(false));
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00010BA8 File Offset: 0x0000EDA8
		public void StartJob(string id, int Lvl, Guid male, Guid female, Action<Exception> OnStaredJobRutine = null)
		{
			if (this.isloadingJob)
			{
				throw new InvalidOperationException();
			}
			if (!AsyncSingleton<JobsGetter>.instance.jobsDisponibles.ContainsKey(id))
			{
				Debug.LogError("job: " + id + " is not in game", this);
				return;
			}
			SMAJobMap smajobMap = AsyncSingleton<JobsGetter>.instance.jobsDisponibles[id];
			this.StartJob(smajobMap, Lvl, male, female, OnStaredJobRutine);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00010C0C File Offset: 0x0000EE0C
		public void EndCurrentJob(Action<Exception> OnEndedJobRutine = null)
		{
			if (this.isloadingJob)
			{
				throw new InvalidOperationException();
			}
			Action<Exception> action = new Action<Exception>(this.OnEndedEndJobRutine);
			if (OnEndedJobRutine != null)
			{
				action = (Action<Exception>)Delegate.Combine(action, OnEndedJobRutine);
			}
			base.StartCoroutine(this.EndJobRutine(false, action));
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00010C54 File Offset: 0x0000EE54
		public void AbortCurrentJob(Action<Exception> OnAbortedJobRutine = null)
		{
			if (this.isloadingJob)
			{
				throw new InvalidOperationException();
			}
			Action<Exception> action = new Action<Exception>(this.OnEndedEndJobRutine);
			if (OnAbortedJobRutine != null)
			{
				action = (Action<Exception>)Delegate.Combine(action, OnAbortedJobRutine);
			}
			base.StartCoroutine(this.EndJobRutine(true, action));
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00010C9B File Offset: 0x0000EE9B
		private IEnumerator EndJobRutine(bool abortando, Action<Exception> OnEndedJobRutine)
		{
			CameraFade.FadeOutMain(1f);
			yield return new WaitForSeconds(1.1f);
			foreach (ICharacterUnico characterUnico in Singleton<CharacteresActivos>.instance.characteres.ToArray<ICharacterUnico>())
			{
				if (characterUnico is FemaleChar)
				{
					characterUnico.transform.gameObject.SetActive(false);
				}
			}
			yield return null;
			yield return null;
			CameraFade.FadeInMain(1f);
			GlobalUpdater.Corrutina endRutine;
			if (!abortando)
			{
				endRutine = Singleton<ActividadesManager>.instance.EndCurrentActividad(OnEndedJobRutine);
			}
			else
			{
				endRutine = Singleton<ActividadesManager>.instance.AbortarCurrentActividad(OnEndedJobRutine);
			}
			while (!endRutine.finalizada)
			{
				yield return null;
			}
			this.currentJob = null;
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
			yield break;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00010CB8 File Offset: 0x0000EEB8
		private void StartJob(SMAJobMap jobMap, int Lvl, Guid male, Guid female, Action<Exception> OnStaredJobRutine = null)
		{
			if (this.isloadingJob)
			{
				throw new InvalidOperationException();
			}
			Action<JobActivityLoader> action = delegate(JobActivityLoader l)
			{
				l.SetData(jobMap, Lvl, male, female, new Action<ISMAJob>(this.OnJobInit));
			};
			this.m_loadingJob = true;
			OnStaredJobRutine = (Action<Exception>)Delegate.Combine(OnStaredJobRutine, new Action<Exception>(this.OnEndedStartJobRutine));
			Singleton<ActividadesManager>.instance.StartActividad<JobActivityLoader>(jobMap.name, action, OnStaredJobRutine, true);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00010D44 File Offset: 0x0000EF44
		private void OnJobInit(ISMAJob mainLogic)
		{
			this.currentJob = mainLogic;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00010D4D File Offset: 0x0000EF4D
		private void OnEndedStartJobRutine(Exception error)
		{
			this.m_loadingJob = false;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00010D56 File Offset: 0x0000EF56
		private void OnEndedEndJobRutine(Exception error)
		{
			this.m_loadingJob = false;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00010D60 File Offset: 0x0000EF60
		public float AddExpToMainPlayerInCurrentJob(float levels)
		{
			ISMAJob current = this.current;
			if (current == null)
			{
				return 0f;
			}
			IContextMemory characterInMemory = this.GetCharacterInMemory(current, this.current.mainPlayerCharacter);
			float num = characterInMemory.FindDataFloat("Exp", 0f) + levels;
			characterInMemory.AddData("Exp", num, true);
			return num;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		public float AddExpToMainNonPlayerInCurrentJob(float levels)
		{
			ISMAJob current = this.current;
			if (current == null)
			{
				return 0f;
			}
			IContextMemory characterInMemory = this.GetCharacterInMemory(current, this.current.mainNonPlayerCharacter);
			float num = characterInMemory.FindDataFloat("Exp", 0f);
			int num2 = Mathf.FloorToInt(num);
			float num3 = num + levels;
			int num4 = Mathf.FloorToInt(num3);
			characterInMemory.AddData("Exp", num3, true);
			if (num4 > num2)
			{
				string text = Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid().ToString();
				string text2;
				string text3;
				string text4;
				MemoriaDeNpc.GetNombres(GlobalSingletonV2<MemoriaJson>.instance, text, out text2, out text3, out text4);
				EmailModelLvlIncreased emailModelLvlIncreased = new EmailModelLvlIncreased();
				emailModelLvlIncreased.jobID = current.ID;
				emailModelLvlIncreased.modelID = this.current.mainNonPlayerCharacter.ID.ToString();
				emailModelLvlIncreased.lvl = num4;
				emailModelLvlIncreased.id = BuffMap.GenerateIdSegundaria(emailModelLvlIncreased.jobID, emailModelLvlIncreased.modelID, "Lvl", num4.ToString(CultureInfo.InvariantCulture));
				emailModelLvlIncreased.nombre = this.current.mainNonPlayerCharacter.fullName;
				emailModelLvlIncreased.showMessageOnStart = false;
				emailModelLvlIncreased.startDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual;
				emailModelLvlIncreased.endDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual + new TimeSpan(14, 0, 0, 0);
				emailModelLvlIncreased.msg = string.Concat(new string[]
				{
					"Model Lvl Up Notice: ",
					this.current.mainNonPlayerCharacter.fullName,
					" – ",
					current.Name,
					"\r\n\r\nDear ",
					text4,
					",\r\n\r\nI hope this message finds you well.\r\n\r\nWe're pleased to inform you that our model, ",
					this.current.mainNonPlayerCharacter.fullName,
					",\r\n\r\nhas shown remarkable development in her professional performance. \r\n\r\nThis improvement positions her for more challenging assignments.\r\n\r\nBest regards,\r\n",
					this.current.mainPlayerCharacter.fullName
				});
				EmailsInbox.Add(emailModelLvlIncreased, text, this);
			}
			return num3;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00010F9C File Offset: 0x0000F19C
		public float AddModelingExpToMainNonPlayer(float levels)
		{
			string text = this.current.mainNonPlayerCharacter.ID.ToString();
			float num = MemoriaDeSMAModelosFemeninas.TryGetModelingExp(GlobalSingletonV2<MemoriaJson>.instance, text, 0f) + levels;
			MemoriaDeSMAModelosFemeninas.SetModelingExp(GlobalSingletonV2<MemoriaJson>.instance, text, num);
			return num;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00010FE8 File Offset: 0x0000F1E8
		public float AddFatigueToCurrentJob(float percentage)
		{
			if (this.current == null)
			{
				return 0f;
			}
			return MemoriaDeSMAModelosFemeninas.AddJobFatige(this.current.ID, percentage);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0001100C File Offset: 0x0000F20C
		public float AddFatigueToMainNonPlayerInJob(float percentage)
		{
			if (this.current == null)
			{
				return 0f;
			}
			return MemoriaDeSMAModelosFemeninas.AddNpcFatigeInJob(this.current.ID, this.current.mainNonPlayerCharacter.ID.ToString(), percentage);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00011058 File Offset: 0x0000F258
		public float AddFatigueToMainNonPlayer(float percentage)
		{
			return MemoriaDeNpc.AddFatigue(GlobalSingletonV2<MemoriaJson>.instance, this.current.mainNonPlayerCharacter.ID.ToString(), percentage);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00011090 File Offset: 0x0000F290
		public float GetExpToMainPlayerInCurrentJob()
		{
			ISMAJob current = this.current;
			if (current == null)
			{
				return 0f;
			}
			return this.GetCharacterInMemory(current, this.current.mainPlayerCharacter).FindDataFloat("Exp", 0f);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000110D0 File Offset: 0x0000F2D0
		public float GetExpToMainNonPlayerInCurrentJob()
		{
			ISMAJob current = this.current;
			if (current == null)
			{
				return 0f;
			}
			return this.GetCharacterInMemory(current, this.current.mainNonPlayerCharacter).FindDataFloat("Exp", 0f);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00011110 File Offset: 0x0000F310
		public float PayMoneyToManager(float paymnentAmountModifier, float paymnentAmountAddBonus)
		{
			ISMAJob current = this.current;
			if (current == null)
			{
				return 0f;
			}
			if (!float.IsFinite(paymnentAmountModifier) || !float.IsFinite(paymnentAmountAddBonus))
			{
				return 0f;
			}
			string text = this.current.mainNonPlayerCharacter.ID.ToString();
			string text2 = Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid().ToString();
			float nextJobIncome = MemoriaDeSMAModelosFemeninas.GetNextJobIncome(text, current.ID, 0f);
			MemoriaDeSMAModelosFemeninas.SetNextJobIncome(text, current.ID, 0f);
			float num = nextJobIncome * paymnentAmountModifier + paymnentAmountAddBonus;
			CharacterWallet.Change(text2, "fiat", num, current.Name, Singleton<TiempoDeJuego>.instance.now);
			float num2;
			float num3;
			MemoriaDeSMAModelosFemeninas.GetModeSalaryAndCommission(GlobalSingletonV2<MemoriaJson>.instance, text, out num2, out num3);
			float num4 = num * (num3 / 100f);
			CharacterWallet.Change(text2, "fiat", -num4, this.current.mainNonPlayerCharacter.fullName, Singleton<TiempoDeJuego>.instance.now);
			return num;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00011207 File Offset: 0x0000F407
		public IEnumerator CheckMainCamera()
		{
			return Singleton<ActividadesManager>.instance.CheckMainCamera();
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00011214 File Offset: 0x0000F414
		public IEnumerator LoadFemaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<SceneCharacter> result, Action<SceneCharacter> onLoading = null)
		{
			return Singleton<ActividadesManager>.instance.LoadFemaleCharacter(id, feetPosition, bodyForwardDirection, delegate(Character cr)
			{
				Action<SceneCharacter> result2 = result;
				if (result2 == null)
				{
					return;
				}
				result2(cr.GetComponent<SceneCharacter>());
			}, (onLoading != null) ? delegate(ICharacterIdentificable cr)
			{
				Action<SceneCharacter> onLoading2 = onLoading;
				if (onLoading2 == null)
				{
					return;
				}
				onLoading2(cr.GetComponent<SceneCharacter>());
			} : null);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00011268 File Offset: 0x0000F468
		public IEnumerator GenerateMaleCharacter(Vector3 feetPosition, Vector3 bodyForwardDirection, IMaleRandomGeneratorOverrider overrider, Action<SceneCharacter> result, Action<SceneCharacter> beforeAwake, string conjuntoID)
		{
			return Singleton<ActividadesManager>.instance.GenerarMaleCharacter(feetPosition, bodyForwardDirection, overrider, delegate(Character cr)
			{
				Action<SceneCharacter> result2 = result;
				if (result2 == null)
				{
					return;
				}
				result2(cr.GetComponent<SceneCharacter>());
			}, delegate(Character cr)
			{
				Action<SceneCharacter> beforeAwake2 = beforeAwake;
				if (beforeAwake2 == null)
				{
					return;
				}
				beforeAwake2(cr.GetComponent<SceneCharacter>());
			}, conjuntoID);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x000112B4 File Offset: 0x0000F4B4
		public IEnumerator LoadMaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<SceneCharacter> result, Action<SceneCharacter> beforeAwake)
		{
			return Singleton<ActividadesManager>.instance.LoadMaleCharacter(id, feetPosition, bodyForwardDirection, delegate(Character cr)
			{
				Action<SceneCharacter> result2 = result;
				if (result2 == null)
				{
					return;
				}
				result2(cr.GetComponent<SceneCharacter>());
			}, delegate(Character cr)
			{
				Action<SceneCharacter> beforeAwake2 = beforeAwake;
				if (beforeAwake2 == null)
				{
					return;
				}
				beforeAwake2(cr.GetComponent<SceneCharacter>());
			});
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000112FC File Offset: 0x0000F4FC
		public void DestroyCharacter(Guid id)
		{
			Singleton<ActividadesManager>.instance.DestroyCharacter(id);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00011309 File Offset: 0x0000F509
		public void DeleteAndDestroyCharacter(Guid id)
		{
			Singleton<ActividadesManager>.instance.DeleteAndDestroyCharacter(id);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00011316 File Offset: 0x0000F516
		public void AddAdditinalLogicToScene(Scene scene, float phoneAndCameraScreenEmissionModifier)
		{
			Singleton<ActividadesManager>.instance.AddAdditinalLogicToScene(scene, phoneAndCameraScreenEmissionModifier);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00011324 File Offset: 0x0000F524
		public void SetMainPlayerCharacterInputsActive(bool value)
		{
			ISMAJob current = this.current;
			SceneCharacter sceneCharacter = ((current != null) ? current.mainPlayerCharacter : null);
			if (sceneCharacter == null)
			{
				return;
			}
			PausePlayerInputs componentEnRoot = sceneCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				return;
			}
			componentEnRoot.puedeMoverseModificable.ObtenerModificadorNotNull(this).valor.valor = value;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00011377 File Offset: 0x0000F577
		public void GetPreferredTreatmentForClientsWeights(Guid characterID, out float nonSexual, out float softCore, out float hardcore)
		{
			Singleton<ActividadesManager>.instance.GetPreferredTreatmentForClientsWeights(characterID, out nonSexual, out softCore, out hardcore);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00011388 File Offset: 0x0000F588
		public void SetOutfit(Guid characterID, ITValleOutfit outfit)
		{
			ConjuntoDeRopa conjuntoDeRopa = ConjuntoDeRopa.FromOutif(outfit);
			Singleton<ActividadesManager>.instance.SetOutfit(characterID, conjuntoDeRopa);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000113A8 File Offset: 0x0000F5A8
		public IEnumerator SetOutfitAndWait(Guid characterID, ITValleOutfit outfit)
		{
			ConjuntoDeRopa conjuntoDeRopa = ConjuntoDeRopa.FromOutif(outfit);
			yield return Singleton<ActividadesManager>.instance.SetOutfitAndWait(characterID, conjuntoDeRopa, true);
			yield break;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000113BE File Offset: 0x0000F5BE
		public override SingletonEditorBotones Boton1()
		{
			if (this.m_mapToTest != null)
			{
				return new SingletonEditorBotones
				{
					text = "Test Job Map",
					editorTimeVisible = false
				};
			}
			return base.Boton1();
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000113EC File Offset: 0x0000F5EC
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.StartJob(this.m_mapToTest, this.m_testMapLvl, Guid.Empty, Guid.Empty, null);
		}

		// Token: 0x040001C9 RID: 457
		[SerializeField]
		private List<SMAJobMap> m_allGameJobs = new List<SMAJobMap>();

		// Token: 0x040001CA RID: 458
		[NonSerialized]
		private Dictionary<string, SMAJobMap> m_GameJobs;

		// Token: 0x040001CB RID: 459
		[SerializeField]
		private JobsManager.Objectives m_Objectives = new JobsManager.Objectives();

		// Token: 0x040001CC RID: 460
		[SerializeField]
		private JobsManager.Outfits m_Outfits = new JobsManager.Outfits();

		// Token: 0x040001CD RID: 461
		[ConstraintType(typeof(ISMAJob), true)]
		[SerializeField]
		private Object m_currentJob;

		// Token: 0x040001CE RID: 462
		[ReadOnlyUI]
		[SerializeField]
		private bool m_loadingJob;

		// Token: 0x040001CF RID: 463
		private Dictionary<string, JobsManager.JobContextMemory> m_actividadMem = new Dictionary<string, JobsManager.JobContextMemory>();

		// Token: 0x040001D0 RID: 464
		private Dictionary<string, JobsManager.JobContextMemory> m_CharsInActividadMem = new Dictionary<string, JobsManager.JobContextMemory>();

		// Token: 0x040001D1 RID: 465
		private JobsUIManager m_JobsUIManager;

		// Token: 0x040001D2 RID: 466
		[Header("Testing")]
		[SerializeField]
		private SMAJobMap m_mapToTest;

		// Token: 0x040001D3 RID: 467
		[SerializeField]
		private bool m_testMapAtStart;

		// Token: 0x040001D4 RID: 468
		[SerializeField]
		private int m_testMapLvl;

		// Token: 0x0200017D RID: 381
		public class Outfits : ISMAJobsOutfits
		{
			// Token: 0x06000C2D RID: 3117 RVA: 0x0003C7D8 File Offset: 0x0003A9D8
			public void Init(JobsManager manager)
			{
				this.m_manager = manager;
			}

			// Token: 0x06000C2E RID: 3118 RVA: 0x0003C7E4 File Offset: 0x0003A9E4
			public int CountOfClothingPiecesCoveringBodyPartOfMainPlayer(SensitiveBodyPart bodyPart)
			{
				IRopaManager cachedComponentInCharacter = Singleton<CurrentMainChar>.instance.GetCachedComponentInCharacter<IRopaManager>();
				int valueOrDefault = ((cachedComponentInCharacter != null) ? new int?(cachedComponentInCharacter.CantidadPiezasCubriendo(bodyPart.GetPart().Parce(), true, null)) : null).GetValueOrDefault(-1);
				if (valueOrDefault < 0)
				{
					Debug.LogError("CountOfClothingPiecesCoveringBodyPartOfMainPlayer Error", this.m_manager);
				}
				return valueOrDefault;
			}

			// Token: 0x06000C2F RID: 3119 RVA: 0x0003C840 File Offset: 0x0003AA40
			public int CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart bodyPart)
			{
				IRopaManager cachedComponentInCharacter = Singleton<CurrentTargetChar>.instance.GetCachedComponentInCharacter<IRopaManager>();
				int valueOrDefault = ((cachedComponentInCharacter != null) ? new int?(cachedComponentInCharacter.CantidadPiezasCubriendo(bodyPart.GetPart().Parce(), true, null)) : null).GetValueOrDefault(-1);
				if (valueOrDefault < 0)
				{
					Debug.LogError("CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer Error", this.m_manager);
				}
				return valueOrDefault;
			}

			// Token: 0x06000C30 RID: 3120 RVA: 0x0003C89C File Offset: 0x0003AA9C
			public ClothingItemMap.Type GetFirstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer(SensitiveBodyPart bodyPart)
			{
				List<string> list = new List<string>();
				IRopaManager cachedComponentInCharacter = Singleton<CurrentTargetChar>.instance.GetCachedComponentInCharacter<IRopaManager>();
				if (((cachedComponentInCharacter != null) ? new int?(cachedComponentInCharacter.CantidadPiezasCubriendo(bodyPart.GetPart().Parce(), true, list)) : null).GetValueOrDefault(-1) < 0)
				{
					Debug.LogError("CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer Error", this.m_manager);
				}
				if (list.Count == 0)
				{
					return ClothingItemMap.Type.None;
				}
				return (ClothingItemMap.Type)AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerFirstRootData(list[0]).tipoDePrenda;
			}

			// Token: 0x04000673 RID: 1651
			private JobsManager m_manager;
		}

		// Token: 0x0200017E RID: 382
		public class Objectives : ISMAJobsObjectives
		{
			// Token: 0x06000C32 RID: 3122 RVA: 0x0003C923 File Offset: 0x0003AB23
			public void Init(JobsManager manager)
			{
				this.m_manager = manager;
			}

			// Token: 0x06000C33 RID: 3123 RVA: 0x0003C92C File Offset: 0x0003AB2C
			public ISMAJobObjective CreateObjective(string ID, string description, bool checkAfterCompleted, ObjectiveCheckerHandler checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null)
			{
				bool flag = checkFrequency == ObjectiveCheckFrequency.eachFrame;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (subObjectives != null)
				{
					readOnlyList = (from sub in subObjectives
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				return new GameplayObjectives.SingleActionObjective(ID, description, checkAfterCompleted, checkDelegate, flag, readOnlyList, tips);
			}

			// Token: 0x06000C34 RID: 3124 RVA: 0x0003C9A4 File Offset: 0x0003ABA4
			public ISMAJobObjective CreatePercentageObjective(string ID, string description, bool checkAfterCompleted, ObjectiveCheckerHandler_RecalculateWeight checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, PercentageObjectiveProgressWeightChandedHandler callback = null)
			{
				bool flag = checkFrequency == ObjectiveCheckFrequency.eachFrame;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (subObjectives != null)
				{
					readOnlyList = (from sub in subObjectives
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				GameplayObjectives.PercentageObjective percentageObjective = new GameplayObjectives.PercentageObjective(ID, description, checkAfterCompleted, checkDelegate, flag, readOnlyList, tips);
				if (callback != null)
				{
					percentageObjective.progressWeightChanged2 += callback;
				}
				return percentageObjective;
			}

			// Token: 0x06000C35 RID: 3125 RVA: 0x0003CA2C File Offset: 0x0003AC2C
			public ISMAJobObjective CreateFlagsObjective(string ID, string description, bool checkAfterCompleted, IReadOnlyList<string> Flags, ObjectiveCheckerHandler_IsFlagSet checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, ObjectiveFlagsChandedHandler callback = null)
			{
				bool flag = checkFrequency == ObjectiveCheckFrequency.eachFrame;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (subObjectives != null)
				{
					readOnlyList = (from sub in subObjectives
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				GameplayObjectives.FlagsObjective flagsObjective = new GameplayObjectives.FlagsObjective(ID, description, checkAfterCompleted, Flags, checkDelegate, flag, readOnlyList, tips);
				if (callback != null)
				{
					flagsObjective.flagsChanged2 += callback;
				}
				return flagsObjective;
			}

			// Token: 0x06000C36 RID: 3126 RVA: 0x0003CAB4 File Offset: 0x0003ACB4
			public ISMAJobObjective CreateUniqueActionsCountObjective(string ID, string description, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_GetLastUniqueAction checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, ObjectiveCountChandedHandler callback = null)
			{
				bool flag = checkFrequency == ObjectiveCheckFrequency.eachFrame;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (subObjectives != null)
				{
					readOnlyList = (from sub in subObjectives
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				GameplayObjectives.CountOfUniqueActionObjective countOfUniqueActionObjective = new GameplayObjectives.CountOfUniqueActionObjective(ID, description, checkAfterCompleted, Capacity, checkDelegate, flag, readOnlyList, tips);
				if (callback != null)
				{
					countOfUniqueActionObjective.countChanded2 += callback;
				}
				return countOfUniqueActionObjective;
			}

			// Token: 0x06000C37 RID: 3127 RVA: 0x0003CB3C File Offset: 0x0003AD3C
			public ISMAJobObjective CreateCountOfSingleActionObjective(string ID, string description, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_CurrentCount checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, ObjectiveCountChandedHandler callback = null)
			{
				bool flag = checkFrequency == ObjectiveCheckFrequency.eachFrame;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (subObjectives != null)
				{
					readOnlyList = (from sub in subObjectives
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				GameplayObjectives.CountOfSingleActionObjective countOfSingleActionObjective = new GameplayObjectives.CountOfSingleActionObjective(ID, description, checkAfterCompleted, Capacity, checkDelegate, flag, readOnlyList, tips);
				if (callback != null)
				{
					countOfSingleActionObjective.countChanded2 += callback;
				}
				return countOfSingleActionObjective;
			}

			// Token: 0x06000C38 RID: 3128 RVA: 0x0003CBC4 File Offset: 0x0003ADC4
			public void AddObjective(ISMAJobObjective objective, bool required, bool msgOnComplete)
			{
				Singleton<GameplayObjectives>.instance.AddObjetive(objective as GameplayObjectives.Objective, required, msgOnComplete);
			}

			// Token: 0x06000C39 RID: 3129 RVA: 0x0003CBD8 File Offset: 0x0003ADD8
			public void RemoveObjective(ISMAJobObjective objective)
			{
				Singleton<GameplayObjectives>.instance.RemoveObjetive(objective as GameplayObjectives.Objective);
			}

			// Token: 0x06000C3A RID: 3130 RVA: 0x0003CBEC File Offset: 0x0003ADEC
			public void AddObjectives(IReadOnlyList<ISMAJobObjective> objective, bool required)
			{
				GameplayObjectives instance = Singleton<GameplayObjectives>.instance;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (objective != null)
				{
					readOnlyList = (from sub in objective
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				instance.AddObjetives(readOnlyList, required);
			}

			// Token: 0x06000C3B RID: 3131 RVA: 0x0003CC58 File Offset: 0x0003AE58
			public void RefreshUI()
			{
				Singleton<GameplayObjectives>.instance.Refresh();
			}

			// Token: 0x06000C3C RID: 3132 RVA: 0x0003CC64 File Offset: 0x0003AE64
			public void RemoveObjectives(IReadOnlyList<ISMAJobObjective> objective)
			{
				GameplayObjectives instance = Singleton<GameplayObjectives>.instance;
				IReadOnlyList<GameplayObjectives.Objective> readOnlyList;
				if (objective != null)
				{
					readOnlyList = (from sub in objective
						select sub as GameplayObjectives.Objective into ob
						where ob != null
						select ob).ToArray<GameplayObjectives.Objective>();
				}
				else
				{
					readOnlyList = null;
				}
				instance.RemoveObjetives(readOnlyList);
			}

			// Token: 0x06000C3D RID: 3133 RVA: 0x0003CCCF File Offset: 0x0003AECF
			public bool CheckCompleted()
			{
				return Singleton<GameplayObjectives>.instance.AllRequiredObjectivesCompleted();
			}

			// Token: 0x06000C3E RID: 3134 RVA: 0x0003CCDB File Offset: 0x0003AEDB
			public void Status(out int totalRequiredObjectives, out int completedRequiredObjectives, out int totalOptionalObjectives, out int completedOptionalObjectives)
			{
				Singleton<GameplayObjectives>.instance.Status(out totalRequiredObjectives, out completedRequiredObjectives, out totalOptionalObjectives, out completedOptionalObjectives);
			}

			// Token: 0x06000C3F RID: 3135 RVA: 0x0003CCEC File Offset: 0x0003AEEC
			public void StartSession()
			{
				Singleton<GameplayObjectives>.instance.StartSession();
			}

			// Token: 0x06000C40 RID: 3136 RVA: 0x0003CCF8 File Offset: 0x0003AEF8
			public void SessionStatus(out int totalRequiredObjectives, out int completedRequiredObjectives, out int totalOptionalObjectives, out int completedOptionalObjectives)
			{
				Singleton<GameplayObjectives>.instance.SessionStatus(out totalRequiredObjectives, out completedRequiredObjectives, out totalOptionalObjectives, out completedOptionalObjectives);
			}

			// Token: 0x06000C41 RID: 3137 RVA: 0x0003CD09 File Offset: 0x0003AF09
			public void EndSession()
			{
				Singleton<GameplayObjectives>.instance.EndSession();
			}

			// Token: 0x04000674 RID: 1652
			private JobsManager m_manager;
		}

		// Token: 0x0200017F RID: 383
		public class JobContextMemory : IContextMemory
		{
			// Token: 0x06000C43 RID: 3139 RVA: 0x0003CD1D File Offset: 0x0003AF1D
			public JobContextMemory(ActividadesManager.ContextMemory mem, string JobId)
			{
				this.m_JobId = JobId;
				this.m_mem = mem;
			}

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x06000C44 RID: 3140 RVA: 0x0003CD33 File Offset: 0x0003AF33
			public string jobId
			{
				get
				{
					return this.m_JobId;
				}
			}

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x06000C45 RID: 3141 RVA: 0x0003CD3B File Offset: 0x0003AF3B
			string IContextMemory.id
			{
				get
				{
					return this.m_JobId;
				}
			}

			// Token: 0x06000C46 RID: 3142 RVA: 0x0003CD43 File Offset: 0x0003AF43
			public void AddData(string id, string data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C47 RID: 3143 RVA: 0x0003CD53 File Offset: 0x0003AF53
			public string FindData(string id, string defaultValue)
			{
				return this.m_mem.FindData(id, defaultValue);
			}

			// Token: 0x06000C48 RID: 3144 RVA: 0x0003CD62 File Offset: 0x0003AF62
			public void AddData(string id, bool data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C49 RID: 3145 RVA: 0x0003CD72 File Offset: 0x0003AF72
			public bool FindDataBool(string id, bool defaultValue)
			{
				return this.m_mem.FindDataBool(id, defaultValue);
			}

			// Token: 0x06000C4A RID: 3146 RVA: 0x0003CD81 File Offset: 0x0003AF81
			public void AddData(string id, int data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C4B RID: 3147 RVA: 0x0003CD91 File Offset: 0x0003AF91
			public int FindDataInt(string id, int defaultValue)
			{
				return this.m_mem.FindDataInt(id, defaultValue);
			}

			// Token: 0x06000C4C RID: 3148 RVA: 0x0003CDA0 File Offset: 0x0003AFA0
			public void AddData(int id, int data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C4D RID: 3149 RVA: 0x0003CDB0 File Offset: 0x0003AFB0
			public int FindDataInt(int id, int defaultValue)
			{
				return this.m_mem.FindDataInt(id, defaultValue);
			}

			// Token: 0x06000C4E RID: 3150 RVA: 0x0003CDBF File Offset: 0x0003AFBF
			public bool TryFindDataInt(string id, out int value)
			{
				return this.m_mem.TryFindDataInt(id, out value);
			}

			// Token: 0x06000C4F RID: 3151 RVA: 0x0003CDCE File Offset: 0x0003AFCE
			public bool TryFindDataInt(int id, out int value)
			{
				return this.m_mem.TryFindDataInt(id, out value);
			}

			// Token: 0x06000C50 RID: 3152 RVA: 0x0003CDDD File Offset: 0x0003AFDD
			public void AddData(string id, float data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C51 RID: 3153 RVA: 0x0003CDED File Offset: 0x0003AFED
			public void AddData(int id, float data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C52 RID: 3154 RVA: 0x0003CDFD File Offset: 0x0003AFFD
			public float FindDataFloat(string id, float defaultValue)
			{
				return this.m_mem.FindDataFloat(id, defaultValue);
			}

			// Token: 0x06000C53 RID: 3155 RVA: 0x0003CE0C File Offset: 0x0003B00C
			public float FindDataFloat(int id, float defaultValue)
			{
				return this.m_mem.FindDataFloat(id, defaultValue);
			}

			// Token: 0x06000C54 RID: 3156 RVA: 0x0003CE1B File Offset: 0x0003B01B
			public bool TryFindDataFloat(int id, out float value)
			{
				return this.m_mem.TryFindDataFloat(id, out value);
			}

			// Token: 0x06000C55 RID: 3157 RVA: 0x0003CE2A File Offset: 0x0003B02A
			public bool TryFindDataFloat(string id, out float value)
			{
				return this.m_mem.TryFindDataFloat(id, out value);
			}

			// Token: 0x06000C56 RID: 3158 RVA: 0x0003CE39 File Offset: 0x0003B039
			public void AddData<T>(string id, List<T> data, bool replace = true)
			{
				this.m_mem.AddData<T>(id, data, replace);
			}

			// Token: 0x06000C57 RID: 3159 RVA: 0x0003CE49 File Offset: 0x0003B049
			public bool TryFindDataArrayEmpty<T>(string id, out List<T> value)
			{
				return this.m_mem.TryFindDataArrayEmpty<T>(id, out value);
			}

			// Token: 0x06000C58 RID: 3160 RVA: 0x0003CE58 File Offset: 0x0003B058
			public bool TryFindDataArrayNull<T>(string id, out List<T> value)
			{
				return this.m_mem.TryFindDataArrayNull<T>(id, out value);
			}

			// Token: 0x06000C59 RID: 3161 RVA: 0x0003CE67 File Offset: 0x0003B067
			public void AddData<T>(string id, T[] data, bool replace = true)
			{
				this.m_mem.AddData<T>(id, data, replace);
			}

			// Token: 0x06000C5A RID: 3162 RVA: 0x0003CE77 File Offset: 0x0003B077
			public bool TryFindDataArrayEmpty<T>(string id, out T[] value)
			{
				return this.m_mem.TryFindDataArrayEmpty<T>(id, out value);
			}

			// Token: 0x06000C5B RID: 3163 RVA: 0x0003CE86 File Offset: 0x0003B086
			public bool TryFindDataArrayNull<T>(string id, out T[] value)
			{
				return this.m_mem.TryFindDataArrayNull<T>(id, out value);
			}

			// Token: 0x06000C5C RID: 3164 RVA: 0x0003CE95 File Offset: 0x0003B095
			public void AddData(string id, Texture2D data, bool replace = true)
			{
				this.m_mem.AddData(id, data, replace);
			}

			// Token: 0x06000C5D RID: 3165 RVA: 0x0003CEA5 File Offset: 0x0003B0A5
			public Texture2D FindDataImage(string id)
			{
				return this.m_mem.FindDataImage(id);
			}

			// Token: 0x06000C5E RID: 3166 RVA: 0x0003CEB3 File Offset: 0x0003B0B3
			public bool TryFindDataImage(string id, ref Texture2D result)
			{
				return this.m_mem.TryFindDataImage(id, ref result);
			}

			// Token: 0x06000C5F RID: 3167 RVA: 0x0003CEC2 File Offset: 0x0003B0C2
			public void AddDataObject<TKey, TValue>(TKey id, TValue data, bool replace = true)
			{
				this.m_mem.AddDataObject<TKey, TValue>(id, data, replace);
			}

			// Token: 0x06000C60 RID: 3168 RVA: 0x0003CED2 File Offset: 0x0003B0D2
			public bool TryFindDataObject<TKey, TValue>(string id, out TKey key, out TValue value, TKey defaultKey, TValue defaultValue)
			{
				return this.m_mem.TryFindDataObject<TKey, TValue>(id, out key, out value, defaultKey, defaultValue);
			}

			// Token: 0x06000C61 RID: 3169 RVA: 0x0003CEE6 File Offset: 0x0003B0E6
			public void AddDataObject<T>(string id, T data, bool replace = true)
			{
				this.m_mem.AddDataObject<T>(id, data, replace);
			}

			// Token: 0x06000C62 RID: 3170 RVA: 0x0003CEF6 File Offset: 0x0003B0F6
			public bool TryFindDataObject<T>(string id, out T value, T defaultValue)
			{
				return this.m_mem.TryFindDataObject<T>(id, out value, defaultValue);
			}

			// Token: 0x06000C63 RID: 3171 RVA: 0x0003CF06 File Offset: 0x0003B106
			public bool TryFindDataObject<T>(string id, Type type, out T value, T defaultValue) where T : class
			{
				return this.m_mem.TryFindDataObject<T>(id, type, out value, defaultValue);
			}

			// Token: 0x06000C64 RID: 3172 RVA: 0x0003CF18 File Offset: 0x0003B118
			public bool TryFindDataObject(string id, Type type, out object value, object defaultValue)
			{
				return this.m_mem.TryFindDataObject(id, type, out value, defaultValue);
			}

			// Token: 0x06000C65 RID: 3173 RVA: 0x0003CF2A File Offset: 0x0003B12A
			public bool RemoveData(string id)
			{
				return this.m_mem.RemoveData(id);
			}

			// Token: 0x06000C66 RID: 3174 RVA: 0x0003CF38 File Offset: 0x0003B138
			public void Clear()
			{
				this.m_mem.Clear();
			}

			// Token: 0x04000675 RID: 1653
			private string m_JobId;

			// Token: 0x04000676 RID: 1654
			private ActividadesManager.ContextMemory m_mem;
		}
	}
}
