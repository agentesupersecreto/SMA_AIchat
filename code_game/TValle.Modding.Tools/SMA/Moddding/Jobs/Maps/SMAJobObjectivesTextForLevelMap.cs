using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Moddding;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps
{
	// Token: 0x02000016 RID: 22
	[CreateAssetMenu(fileName = "SMAJobObjectivesTextForLevelMap", menuName = "TValle/SMA/Modding/Jobs/SMAJobObjectivesTextForLevelMap")]
	public class SMAJobObjectivesTextForLevelMap : ScriptableObject
	{
		// Token: 0x0400002F RID: 47
		[Tooltip("You can get this data in-game with the id. the logic for each Objective must be set in-Game")]
		public List<SMAJobObjectivesTextForLevelMap.ObjectiveText> text = new List<SMAJobObjectivesTextForLevelMap.ObjectiveText>();

		// Token: 0x02000096 RID: 150
		[Serializable]
		public class ObjectiveText
		{
			// Token: 0x0400027C RID: 636
			[Tooltip("Ex: tvalle.photoshoot.lvl1.assPicture")]
			public string id;

			// Token: 0x0400027D RID: 637
			[Tooltip("How this Objective will be shown in the game in the UI. set 'name' field for Ex: 'Take a Phooto of her glutes', set 'desciption' field for Ex: 'press NUM 3 to show the camera and take a photo of her lower back' ")]
			public List<InGameObjectiveText> inGameDescription;
		}
	}
}
