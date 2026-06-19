using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000042 RID: 66
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/persistent_destructible.html")]
	[AddComponentMenu("Dialogue System/Save System/Persistent Destructible")]
	public class PersistentDestructible : MonoBehaviour
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x0000A2B2 File Offset: 0x000084B2
		protected string ActualVariableName
		{
			get
			{
				if (!string.IsNullOrEmpty(this.variableName))
				{
					return this.variableName;
				}
				return OverrideActorName.GetInternalName(base.transform);
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000A2D3 File Offset: 0x000084D3
		protected virtual void OnEnable()
		{
			PersistentDataManager.RegisterPersistentData(base.gameObject);
			this.listenForOnDestroy = true;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000A2E8 File Offset: 0x000084E8
		public void OnApplyPersistentData()
		{
			if (DialogueLua.GetVariable(this.ActualVariableName).AsBool)
			{
				base.gameObject.BroadcastMessage("OnLevelWillBeUnloaded", SendMessageOptions.DontRequireReceiver);
				PersistentDestructible.RecordOn recordOn = this.recordOn;
				if (recordOn != PersistentDestructible.RecordOn.Destroy)
				{
					if (recordOn == PersistentDestructible.RecordOn.Disable)
					{
						base.gameObject.SetActive(false);
					}
				}
				else
				{
					Object.Destroy(base.gameObject);
				}
				this.SpawnCorpse();
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000A34A File Offset: 0x0000854A
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000A353 File Offset: 0x00008553
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000A35C File Offset: 0x0000855C
		public void OnDestroy()
		{
			if (!this.listenForOnDestroy || this.recordOn != PersistentDestructible.RecordOn.Destroy)
			{
				return;
			}
			this.MarkDestroyed();
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000A378 File Offset: 0x00008578
		private void MarkDestroyed()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (DialogueManager.Instance == null || DialogueManager.DatabaseManager == null || DialogueManager.MasterDatabase == null)
			{
				return;
			}
			DialogueLua.SetVariable(this.ActualVariableName, true);
			this.SpawnCorpse();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000A3C6 File Offset: 0x000085C6
		public void OnDisable()
		{
			if (!this.listenForOnDestroy || this.recordOn != PersistentDestructible.RecordOn.Disable)
			{
				return;
			}
			this.MarkDestroyed();
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000A3EB File Offset: 0x000085EB
		private void SpawnCorpse()
		{
			if (this.spawnWhenDestroyed == null)
			{
				return;
			}
			Object.Instantiate<GameObject>(this.spawnWhenDestroyed, base.transform.position, base.transform.rotation);
		}

		// Token: 0x0400016D RID: 365
		[Tooltip("Record destroyed on Destroy or Disable.")]
		public PersistentDestructible.RecordOn recordOn;

		// Token: 0x0400016E RID: 366
		[Tooltip("Unique Dialogue System variable (Boolean) to record whether the GameObject has been destroyed/disabled.")]
		public string variableName = string.Empty;

		// Token: 0x0400016F RID: 367
		[Tooltip("Spawn an instance of this when destroyed.")]
		public GameObject spawnWhenDestroyed;

		// Token: 0x04000170 RID: 368
		protected bool listenForOnDestroy;

		// Token: 0x02000088 RID: 136
		public enum RecordOn
		{
			// Token: 0x040002C1 RID: 705
			Destroy,
			// Token: 0x040002C2 RID: 706
			Disable
		}
	}
}
