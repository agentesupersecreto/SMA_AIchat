using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000010 RID: 16
	[Serializable]
	public class PersistentDataSettings
	{
		// Token: 0x04000051 RID: 81
		[Tooltip("- All Game Objects: Send notification to all scripts on all GameObjects in the scene to record and/or apply their persistent data if supported.\n- Only Registered Game Objects: Send notification only to explicitly-registered GameObjects.\n- No Game Objects: Don't send notification to any GameObjects in the scene.")]
		public PersistentDataManager.RecordPersistentDataOn recordPersistentDataOn;

		// Token: 0x04000052 RID: 82
		[Tooltip("Tick to include the Actor[] table in save data.")]
		public bool includeActorData = true;

		// Token: 0x04000053 RID: 83
		[Tooltip("Tick to include all Item[] and Quest[] fields. If unticked, only record quest states and quest tracking states to reduce size.")]
		public bool includeAllItemData;

		// Token: 0x04000054 RID: 84
		[Tooltip("Tick to include the Location[] table.")]
		public bool includeLocationData;

		// Token: 0x04000055 RID: 85
		[Tooltip("Tick to include status and relationship tables in save data.")]
		public bool includeStatusAndRelationshipData = true;

		// Token: 0x04000056 RID: 86
		[Tooltip("Tick to include all conversation fields.")]
		public bool includeAllConversationFields;

		// Token: 0x04000057 RID: 87
		[Tooltip("Optional field to use when saving a conversation's SimStatus info (e.g., Title). If blank, uses conversation ID.")]
		public string saveConversationSimStatusWithField = string.Empty;

		// Token: 0x04000058 RID: 88
		[Tooltip("Optional field to use when saving a dialogue entry's SimStatus info (e.g,. Title). If blank, uses entry's ID.")]
		public string saveDialogueEntrySimStatusWithField = string.Empty;

		// Token: 0x04000059 RID: 89
		[Tooltip("How many scene GameObjects are sent OnRecordPersistentData each frame.")]
		public int asyncGameObjectBatchSize = 1000;

		// Token: 0x0400005A RID: 90
		[Tooltip("How many dialogue entries' SimStatus values are recorded each frame; only used if saving SimStatus.")]
		public int asyncDialogueEntryBatchSize = 100;
	}
}
