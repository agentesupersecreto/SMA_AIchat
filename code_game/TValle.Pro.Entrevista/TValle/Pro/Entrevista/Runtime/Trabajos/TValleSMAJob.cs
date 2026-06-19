using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.Moddding;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x02000057 RID: 87
	public abstract class TValleSMAJob : ActividadScenesLoader, ISMAJob
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600028F RID: 655
		public abstract bool nonPlayerCharacterWillRememberPlayerCharacter { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000F95A File Offset: 0x0000DB5A
		public string ID
		{
			get
			{
				return this.m_map.id;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000F968 File Offset: 0x0000DB68
		public string Name
		{
			get
			{
				bool flag;
				return this.m_map.GetIngameName(this.m_jobManager.gameLanguage, out flag);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0000F98D File Offset: 0x0000DB8D
		public bool isInit
		{
			get
			{
				return this.m_isInit;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000F995 File Offset: 0x0000DB95
		// (set) Token: 0x06000294 RID: 660 RVA: 0x0000F99D File Offset: 0x0000DB9D
		public bool isAborted
		{
			get
			{
				return this.m_isAborted;
			}
			set
			{
				this.m_isAborted = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000F9A6 File Offset: 0x0000DBA6
		public DateTime date
		{
			get
			{
				return this.m_date;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0000F9AE File Offset: 0x0000DBAE
		public int lvl
		{
			get
			{
				return this.m_lvl;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000F9B6 File Offset: 0x0000DBB6
		public SceneCharacter mainPlayerCharacter
		{
			get
			{
				return this.m_mainPlayerCharacter;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000298 RID: 664 RVA: 0x0000F9BE File Offset: 0x0000DBBE
		public SceneCharacter mainNonPlayerCharacter
		{
			get
			{
				return this.m_mainNonPlayerCharacter;
			}
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000299 RID: 665 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
		// (remove) Token: 0x0600029A RID: 666 RVA: 0x0000FA00 File Offset: 0x0000DC00
		public event ISMAJob.CharacterChangedHandler mainPlayerChanged;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x0600029B RID: 667 RVA: 0x0000FA38 File Offset: 0x0000DC38
		// (remove) Token: 0x0600029C RID: 668 RVA: 0x0000FA70 File Offset: 0x0000DC70
		public event ISMAJob.CharacterChangedHandler mainNonPlayerChanged;

		// Token: 0x0600029D RID: 669 RVA: 0x0000FAA8 File Offset: 0x0000DCA8
		public virtual void Init(ISMAJobsManager jobManager, SMAJobMap map, int Lvl, Guid mainPlayerCharacterID, Guid mainNonPlayerCharacterID, DateTime inGameDate)
		{
			if (map == null)
			{
				throw new ArgumentNullException("map", "map null reference.");
			}
			this.m_date = inGameDate;
			this.m_map = map;
			this.m_lvl = Lvl;
			this.m_jobManager = jobManager;
			this.m_mainPlayerCharacterID = mainPlayerCharacterID;
			this.m_mainNonPlayerCharacterID = mainNonPlayerCharacterID;
			this.m_isInit = true;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000FB02 File Offset: 0x0000DD02
		public IEnumerator Load()
		{
			yield return base.DoLoad();
			yield break;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000FB11 File Offset: 0x0000DD11
		public IEnumerator UnLoad()
		{
			yield return base.DoUnLoad(null);
			yield break;
		}

		// Token: 0x060002A0 RID: 672
		public abstract IEnumerator DoStart();

		// Token: 0x060002A1 RID: 673
		public abstract IEnumerator Introduce();

		// Token: 0x060002A2 RID: 674
		public abstract void BeforeAnimationsUpdate();

		// Token: 0x060002A3 RID: 675
		public abstract void AfterAnimationsUpdate();

		// Token: 0x060002A4 RID: 676
		public abstract void OnNonPlayerMaxEmotionValue(Emotion emotion);

		// Token: 0x060002A5 RID: 677
		public abstract bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion);

		// Token: 0x060002A6 RID: 678
		public abstract void OnPlayerMaxEmotionValue(Emotion emotion);

		// Token: 0x060002A7 RID: 679
		public abstract bool OnPlayerMaxEmotionValueBuffer(Emotion emotion);

		// Token: 0x060002A8 RID: 680
		public abstract void BeforePhysicsUpdate();

		// Token: 0x060002A9 RID: 681
		public abstract void AfterPhysicsUpdate();

		// Token: 0x060002AA RID: 682
		public abstract void BeforeAIUpdate();

		// Token: 0x060002AB RID: 683
		public abstract void AfterAIUpdate();

		// Token: 0x060002AC RID: 684
		public abstract IEnumerator Conclude();

		// Token: 0x060002AD RID: 685
		public abstract IEnumerator End();

		// Token: 0x060002AE RID: 686 RVA: 0x0000FB20 File Offset: 0x0000DD20
		protected GameplayObjectives.SingleActionObjective CreateObjective([TupleElementNames(new string[] { null, "checkAfteCompleted", null, "RealTime", null })] ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>> data)
		{
			InGameObjectiveText objectiveText = this.m_map.GetObjectiveText(data.Item1, this.m_jobManager.gameLanguage);
			if (objectiveText == null)
			{
				Debug.LogError("can load objective text: " + data.Item1, this);
				return null;
			}
			return (GameplayObjectives.SingleActionObjective)this.m_jobManager.objectives.CreateObjective(data.Item1, objectiveText.desc, data.Item2, data.Item3, data.Item4 ? ObjectiveCheckFrequency.eachFrame : ObjectiveCheckFrequency.delayed, data.Item5, objectiveText.tips);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000FBAA File Offset: 0x0000DDAA
		protected GameplayObjectives.SingleActionObjective[] CreateObjectives([TupleElementNames(new string[] { null, "checkAfteCompleted", null, "RealTime", null })] params ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] data)
		{
			return (from p in data
				select this.CreateObjective(p) into oj
				where oj != null
				select oj).ToArray<GameplayObjectives.SingleActionObjective>();
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000FBE8 File Offset: 0x0000DDE8
		protected GameplayObjectives.CountOfSingleActionObjective CreateObjective([TupleElementNames(new string[] { null, "checkAfteCompleted", null, null, "RealTime", null, null })] ValueTuple<string, bool, int, ObjectiveCheckerHandler_CurrentCount, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler> data)
		{
			InGameObjectiveText objectiveText = this.m_map.GetObjectiveText(data.Item1, this.m_jobManager.gameLanguage);
			if (objectiveText == null)
			{
				Debug.LogError("can load objective text: " + data.Item1, this);
				return null;
			}
			return (GameplayObjectives.CountOfSingleActionObjective)this.m_jobManager.objectives.CreateCountOfSingleActionObjective(data.Item1, objectiveText.desc, data.Item2, data.Item3, data.Item4, data.Item5 ? ObjectiveCheckFrequency.eachFrame : ObjectiveCheckFrequency.delayed, data.Item6, objectiveText.tips, data.Item7);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000FC7E File Offset: 0x0000DE7E
		protected GameplayObjectives.CountOfSingleActionObjective[] CreateObjectives([TupleElementNames(new string[] { null, "checkAfteCompleted", null, null, "RealTime", null, null })] params ValueTuple<string, bool, int, ObjectiveCheckerHandler_CurrentCount, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] data)
		{
			return (from p in data
				select this.CreateObjective(p) into oj
				where oj != null
				select oj).ToArray<GameplayObjectives.CountOfSingleActionObjective>();
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000FCBC File Offset: 0x0000DEBC
		protected GameplayObjectives.CountOfUniqueActionObjective CreateObjective([TupleElementNames(new string[] { null, "checkAfteCompleted", null, null, "RealTime", null, null })] ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler> data)
		{
			InGameObjectiveText objectiveText = this.m_map.GetObjectiveText(data.Item1, this.m_jobManager.gameLanguage);
			if (objectiveText == null)
			{
				Debug.LogError("can load objective text: " + data.Item1, this);
				return null;
			}
			return (GameplayObjectives.CountOfUniqueActionObjective)this.m_jobManager.objectives.CreateUniqueActionsCountObjective(data.Item1, objectiveText.desc, data.Item2, data.Item3, data.Item4, data.Item5 ? ObjectiveCheckFrequency.eachFrame : ObjectiveCheckFrequency.delayed, data.Item6, objectiveText.tips, data.Item7);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000FD52 File Offset: 0x0000DF52
		protected GameplayObjectives.CountOfUniqueActionObjective[] CreateObjectives([TupleElementNames(new string[] { null, "checkAfteCompleted", null, null, "RealTime", null, null })] params ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] data)
		{
			return (from p in data
				select this.CreateObjective(p) into oj
				where oj != null
				select oj).ToArray<GameplayObjectives.CountOfUniqueActionObjective>();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000FD8F File Offset: 0x0000DF8F
		protected IEnumerator CheckMainCamera()
		{
			yield return this.m_jobManager.CheckMainCamera();
			yield break;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000FDA0 File Offset: 0x0000DFA0
		protected IEnumerator GenerarMaleCharacter(Vector3 feetPosition, Vector3 bodyForwardDirection, IMaleRandomGeneratorOverrider overrider, Action<SceneCharacter> result, Action<SceneCharacter> beforeAwake, bool setAsMain, string conjuntoID)
		{
			SceneCharacter loaded = null;
			yield return this.m_jobManager.GenerateMaleCharacter(feetPosition, bodyForwardDirection, overrider, delegate(SceneCharacter r)
			{
				loaded = r;
			}, beforeAwake, conjuntoID);
			if (setAsMain)
			{
				SceneCharacter mainPlayerCharacter = this.m_mainPlayerCharacter;
				this.m_mainPlayerCharacter = loaded;
				this.m_mainPlayerCharacterID = loaded.ID;
				ISMAJob.CharacterChangedHandler characterChangedHandler = this.mainPlayerChanged;
				if (characterChangedHandler != null)
				{
					characterChangedHandler(this.m_mainPlayerCharacter, mainPlayerCharacter, this);
				}
			}
			if (result != null)
			{
				result(loaded);
			}
			yield break;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000FDEF File Offset: 0x0000DFEF
		protected IEnumerator LoadMaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<SceneCharacter> result, Action<SceneCharacter> beforeAwake, bool setAsMain)
		{
			SceneCharacter loaded = null;
			yield return this.m_jobManager.LoadMaleCharacter(id, feetPosition, bodyForwardDirection, delegate(SceneCharacter r)
			{
				loaded = r;
			}, beforeAwake);
			if (setAsMain)
			{
				SceneCharacter mainPlayerCharacter = this.m_mainPlayerCharacter;
				this.m_mainPlayerCharacter = loaded;
				this.m_mainPlayerCharacterID = loaded.ID;
				ISMAJob.CharacterChangedHandler characterChangedHandler = this.mainPlayerChanged;
				if (characterChangedHandler != null)
				{
					characterChangedHandler(this.m_mainPlayerCharacter, mainPlayerCharacter, this);
				}
			}
			if (result != null)
			{
				result(loaded);
			}
			yield break;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000FE2B File Offset: 0x0000E02B
		protected IEnumerator LoadFemaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<SceneCharacter> result, bool setAsMain, Action<SceneCharacter> onLoading = null)
		{
			SceneCharacter loaded = null;
			yield return this.m_jobManager.LoadFemaleCharacter(id, feetPosition, bodyForwardDirection, delegate(SceneCharacter r)
			{
				loaded = r;
			}, onLoading);
			if (setAsMain)
			{
				SceneCharacter mainNonPlayerCharacter = this.m_mainNonPlayerCharacter;
				this.m_mainNonPlayerCharacter = loaded;
				this.m_mainNonPlayerCharacterID = loaded.ID;
				ISMAJob.CharacterChangedHandler characterChangedHandler = this.mainNonPlayerChanged;
				if (characterChangedHandler != null)
				{
					characterChangedHandler(this.m_mainNonPlayerCharacter, mainNonPlayerCharacter, this);
				}
			}
			if (result != null)
			{
				result(loaded);
			}
			yield break;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000FE68 File Offset: 0x0000E068
		protected float CalcularFatiga(ICharactersSceneInteractionsArchived archivedInteractions)
		{
			float num = 0f;
			foreach (object obj in typeof(Emotion).GetEnumValoresLimpiosObject())
			{
				Emotion emotion = (Emotion)obj;
				Interaction interaction;
				archivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, emotion, true, out interaction);
				Interaction interaction2;
				archivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, emotion, false, out interaction2);
				if (emotion.IsGood())
				{
					num += (float)interaction.times * 5f;
					num += interaction2.damagePercentageDone / 65f;
				}
				else
				{
					num += (float)interaction.times * 2.5f;
					num += interaction2.damagePercentageDone / 65f;
				}
			}
			return num;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000FF34 File Offset: 0x0000E134
		protected float DefaultExpGainCalcule(int LVL, int totalRequiredObjectives, int completedRequiredObjectives, int completedOptionalObjectives, float expModPerOptionalObjective, params int[] sessionPerLvlToLevelUp)
		{
			if (totalRequiredObjectives == 0)
			{
				return 0f;
			}
			float num = (float)sessionPerLvlToLevelUp[LVL];
			float num2 = 1f / num / (float)totalRequiredObjectives;
			float num3 = num2 * (float)completedRequiredObjectives;
			float num4 = num2 * (float)completedOptionalObjectives * expModPerOptionalObjective;
			float num5 = (this.isAborted ? 0.1f : 1f);
			return (num3 + num4) * num5;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000FF81 File Offset: 0x0000E181
		protected float ModExpGainBySandBagging(int LVL, int currentLvl)
		{
			if (LVL >= currentLvl)
			{
				return 1f;
			}
			return Mathf.Pow(0.1f, (float)(currentLvl - LVL));
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000FF9C File Offset: 0x0000E19C
		protected void SetExpToMainCharacters(float expGain, out float activityExpGain, out float activityExp, float redirectToOverallExpGain = 0.2f, float SandBaggingW = 1f)
		{
			int num = Mathf.FloorToInt(this.m_jobManager.GetExpToMainNonPlayerInCurrentJob());
			int num2 = Mathf.FloorToInt(this.m_jobManager.GetExpToMainPlayerInCurrentJob());
			float num3 = this.ModExpGainBySandBagging(this.lvl, num);
			float num4 = this.ModExpGainBySandBagging(this.lvl, num2);
			num3 = Mathf.Lerp(1f, num3, SandBaggingW);
			num4 = Mathf.Lerp(1f, num4, SandBaggingW);
			float num5 = expGain * redirectToOverallExpGain * num3;
			activityExpGain = expGain * num3;
			float num6 = expGain * num3;
			activityExp = this.m_jobManager.AddExpToMainNonPlayerInCurrentJob(activityExpGain);
			this.m_jobManager.AddModelingExpToMainNonPlayer(num5);
			this.m_jobManager.AddExpToMainPlayerInCurrentJob(num6);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00010040 File Offset: 0x0000E240
		protected void SetFatigueToMainCharacters(ref float fatigueGain, out float modelFatigue, int lvl, params float[] minFatigueGainPerLvl)
		{
			fatigueGain = Mathf.Max(fatigueGain, minFatigueGainPerLvl[lvl]);
			modelFatigue = this.m_jobManager.AddFatigueToMainNonPlayer(fatigueGain);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0001005E File Offset: 0x0000E25E
		protected void SetFatigueToJob(float jobFatigueGain, out float jobFatigue)
		{
			jobFatigue = this.m_jobManager.AddFatigueToCurrentJob(jobFatigueGain);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0001006E File Offset: 0x0000E26E
		protected void SetFatigueToMainNonPlayerInJob(float jobFatigueGain, out float jobFatigue)
		{
			jobFatigue = this.m_jobManager.AddFatigueToMainNonPlayerInJob(jobFatigueGain);
		}

		// Token: 0x040001B4 RID: 436
		[SerializeField]
		[ReadOnlyUI]
		protected bool m_isInit;

		// Token: 0x040001B5 RID: 437
		[SerializeField]
		[ReadOnlyUI]
		protected bool m_isAborted;

		// Token: 0x040001B6 RID: 438
		[SerializeField]
		[ReadOnlyUI]
		protected Guid m_mainPlayerCharacterID;

		// Token: 0x040001B7 RID: 439
		[SerializeField]
		[ReadOnlyUI]
		protected Guid m_mainNonPlayerCharacterID;

		// Token: 0x040001B8 RID: 440
		[SerializeField]
		[ReadOnlyUI]
		protected SMAJobMap m_map;

		// Token: 0x040001B9 RID: 441
		[SerializeField]
		[ReadOnlyUI]
		private int m_lvl;

		// Token: 0x040001BA RID: 442
		protected ISMAJobsManager m_jobManager;

		// Token: 0x040001BB RID: 443
		private DateTime m_date;

		// Token: 0x040001BC RID: 444
		[SerializeField]
		[ReadOnlyUI]
		private SceneCharacter m_mainPlayerCharacter;

		// Token: 0x040001BD RID: 445
		[SerializeField]
		[ReadOnlyUI]
		private SceneCharacter m_mainNonPlayerCharacter;
	}
}
