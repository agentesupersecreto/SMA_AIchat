using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.Tools.Runtime.Moddding;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps
{
	// Token: 0x02000015 RID: 21
	[CreateAssetMenu(fileName = "SMAJobMap", menuName = "TValle/SMA/Modding/Jobs/SMAJobMap")]
	public class SMAJobMap : ModdingMap
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00002ECC File Offset: 0x000010CC
		public bool IsSMAJobMapValid()
		{
			AssetReference assetReference = this.mainScene;
			if (!string.IsNullOrWhiteSpace((assetReference != null) ? assetReference.AssetGUID : null))
			{
				AssetReferenceTexture assetReferenceTexture = this.portrait;
				if (!string.IsNullOrWhiteSpace((assetReferenceTexture != null) ? assetReferenceTexture.AssetGUID : null) && !string.IsNullOrWhiteSpace(this.mainLogic))
				{
					return this.otherPlayersFromPoolsAmount != 0;
				}
			}
			return false;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002F24 File Offset: 0x00001124
		public InGameNameDesc GetLevelDesc(int level, Language language)
		{
			if (level >= this.levels.Count)
			{
				return null;
			}
			InGameNameDesc inGameNameDesc = this.levels[level].inGameDescription.FirstOrDefault((InGameNameDesc d) => d.language == language);
			if (inGameNameDesc != null)
			{
				return inGameNameDesc;
			}
			return this.levels[level].inGameDescription.FirstOrDefault((InGameNameDesc d) => d.language == Language.None);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002FAC File Offset: 0x000011AC
		public InGameObjectiveText GetObjectiveText(int level, string objectiveID, Language language)
		{
			if (level >= this.levels.Count)
			{
				return null;
			}
			SMAJobMap.Level level2 = this.levels[level];
			if (level2.objectivesTextMap == null)
			{
				return null;
			}
			SMAJobObjectivesTextForLevelMap.ObjectiveText objectiveText = level2.objectivesTextMap.text.FirstOrDefault((SMAJobObjectivesTextForLevelMap.ObjectiveText ob) => ob.id == objectiveID);
			if (objectiveText == null)
			{
				return null;
			}
			InGameObjectiveText inGameObjectiveText = objectiveText.inGameDescription.FirstOrDefault((InGameObjectiveText tx) => tx.language == language);
			if (inGameObjectiveText != null)
			{
				return inGameObjectiveText;
			}
			return objectiveText.inGameDescription.FirstOrDefault((InGameObjectiveText tx) => tx.language == Language.None);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003068 File Offset: 0x00001268
		public InGameObjectiveText GetObjectiveText(string objectiveID, Language language)
		{
			if (this.generalObjectivesTextMap != null)
			{
				SMAJobObjectivesTextForLevelMap.ObjectiveText objectiveText = this.generalObjectivesTextMap.text.FirstOrDefault((SMAJobObjectivesTextForLevelMap.ObjectiveText ob) => ob.id == objectiveID);
				if (objectiveText != null)
				{
					InGameObjectiveText inGameObjectiveText = objectiveText.inGameDescription.FirstOrDefault((InGameObjectiveText tx) => tx.language == language);
					if (inGameObjectiveText == null)
					{
						inGameObjectiveText = objectiveText.inGameDescription.FirstOrDefault((InGameObjectiveText tx) => tx.language == Language.None);
					}
					if (inGameObjectiveText != null)
					{
						return inGameObjectiveText;
					}
				}
			}
			for (int i = 0; i < this.levels.Count; i++)
			{
				InGameObjectiveText inGameObjectiveText = this.GetObjectiveText(i, objectiveID, language);
				if (inGameObjectiveText != null)
				{
					return inGameObjectiveText;
				}
			}
			return null;
		}

		// Token: 0x04000024 RID: 36
		[Header("--- Job Info -----------------------------------------------------------------------")]
		[Header("Scenes")]
		[Space]
		[Tooltip("This scene is always forced to load; the other references to scenes are only loaded on demand.")]
		public AssetReference mainScene;

		// Token: 0x04000025 RID: 37
		[Space]
		[Tooltip("(Optional) These scenes are set as active scenes right after being loaded, meaning that they are used for lighting. (The first field to the left is for a string ID, so you can get the asset reference (second field to the right) in the logic script.)")]
		public AssetReferenceDictionary lightingAndGeometricsScenes = new AssetReferenceDictionary();

		// Token: 0x04000026 RID: 38
		[Space]
		[Tooltip("(Optional) these scenes are simply loaded additively. (The first field to the left is for a string ID, so you can get the asset reference (second field to the right) in the logic script.)")]
		public AssetReferenceDictionary additionalScenes = new AssetReferenceDictionary();

		// Token: 0x04000027 RID: 39
		[Header("Assets")]
		[Space]
		[Tooltip("An image (16:9) of the scenery for this job. (A 100KB image is enough)")]
		public AssetReferenceTexture portrait;

		// Token: 0x04000028 RID: 40
		[Space]
		[Tooltip("The first field to the left is for a string ID, so you can get the asset reference (second field to the right) in the logic script.")]
		public AssetReferenceDictionary extrasResources = new AssetReferenceDictionary();

		// Token: 0x04000029 RID: 41
		[Header("Logic")]
		public SMAJobMap.OtherPlayerType otherPlayerType;

		// Token: 0x0400002A RID: 42
		public int otherPlayersFromPoolsAmount = -1;

		// Token: 0x0400002B RID: 43
		[Space]
		[Tooltip("(Optional)You can get this data in-game with the id.")]
		public SMAJobObjectivesTextForLevelMap generalObjectivesTextMap;

		// Token: 0x0400002C RID: 44
		[Space]
		[Tooltip("(Index Zero is the initial or default level.) Job-related degrees of difficulty: for instance, a photo shoot may involve models wearing casual clothing, underwear, or nothing at all, for a 3-level total.")]
		public List<SMAJobMap.Level> levels = new List<SMAJobMap.Level>();

		// Token: 0x0400002D RID: 45
		[Tooltip("Must implement ISMAJob")]
		[AssemblyQualifiedName(implementingClass = typeof(Component), implementingInterface = typeof(ISMAJob))]
		public string mainLogic;

		// Token: 0x0400002E RID: 46
		[Space]
		[Tooltip("(Optional) Must implement ISMAUnlockableJob")]
		[AssemblyQualifiedName(implementingClass = typeof(Component), implementingInterface = typeof(ISMAUnlockableJob))]
		public string IsUnlockedLogic;

		// Token: 0x02000090 RID: 144
		[Serializable]
		public class Level
		{
			// Token: 0x04000262 RID: 610
			[Tooltip("Income Per Session")]
			public float incomePerSession;

			// Token: 0x04000263 RID: 611
			[Tooltip("(Optional)You can get this data in-game with the id.")]
			public SMAJobObjectivesTextForLevelMap objectivesTextMap;

			// Token: 0x04000264 RID: 612
			[Tooltip("(Optional)Black color to ignore.")]
			public Color customColor = Color.black;

			// Token: 0x04000265 RID: 613
			[Header("Model Requirements")]
			[Tooltip("Only models that accept modeling can be deployed to this level.")]
			public bool requiresModelingCareer;

			// Token: 0x04000266 RID: 614
			[Tooltip("Only models that accept lingerie modeling can be deployed to this level.")]
			public bool requiresLingerieModeling;

			// Token: 0x04000267 RID: 615
			[Tooltip("Only models that accept erotic modeling can be deployed to this level.")]
			public bool requiresEroticModeling;

			// Token: 0x04000268 RID: 616
			[Tooltip("")]
			public bool requiresNonSexualInterest;

			// Token: 0x04000269 RID: 617
			[Tooltip("")]
			public bool requiresSoftcoreInterest;

			// Token: 0x0400026A RID: 618
			[Tooltip("")]
			public bool requiresHardcoreInterest;

			// Token: 0x0400026B RID: 619
			public string requiresJobId;

			// Token: 0x0400026C RID: 620
			public int requiresJobLvl;

			// Token: 0x0400026D RID: 621
			[Header("Text")]
			[Tooltip("How this level will be described in the game in the UI.")]
			public List<InGameNameDesc> inGameDescription;
		}

		// Token: 0x02000091 RID: 145
		public enum OtherPlayerType
		{
			// Token: 0x0400026F RID: 623
			selfAdmin,
			// Token: 0x04000270 RID: 624
			employer_FromPool,
			// Token: 0x04000271 RID: 625
			client_FromPool,
			// Token: 0x04000272 RID: 626
			stranger_FromPool
		}
	}
}
