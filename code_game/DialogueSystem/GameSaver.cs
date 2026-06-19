using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000274 RID: 628
	[AddComponentMenu("Dialogue System/Save System/Game Saver")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/game_saver.html")]
	public class GameSaver : MonoBehaviour
	{
		// Token: 0x06001B41 RID: 6977 RVA: 0x0002FE30 File Offset: 0x0002E030
		public void Awake()
		{
			if (this.dontDestroyOnLoad)
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
			PersistentDataManager.includeAllItemData = this.includeAllItemData;
			PersistentDataManager.includeLocationData = this.includeLocationData;
			PersistentDataManager.includeSimStatus = this.includeSimStatus;
		}

		// Token: 0x06001B42 RID: 6978 RVA: 0x0002FE6C File Offset: 0x0002E06C
		public void OnUse()
		{
			GameSaver.FunctionOnUse functionOnUse = this.functionOnUse;
			if (functionOnUse != GameSaver.FunctionOnUse.Save)
			{
				if (functionOnUse == GameSaver.FunctionOnUse.Load)
				{
					this.LoadGame();
				}
			}
			else
			{
				this.SaveGame();
			}
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x0002FEB0 File Offset: 0x0002E0B0
		public void SaveGame(int slot)
		{
			if (string.IsNullOrEmpty(this.playerPrefsKey))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: PlayerPrefs Key isn't set. Not saving.", new object[] { "Dialogue System" }));
				}
				return;
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Saving game in slot {1}.", new object[] { "Dialogue System", slot }));
			}
			string text = this.playerPrefsKey + slot.ToString();
			PlayerPrefs.SetString(text, PersistentDataManager.GetSaveData());
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x0002FF44 File Offset: 0x0002E144
		public void SaveGame()
		{
			this.SaveGame(this.slot);
		}

		// Token: 0x06001B45 RID: 6981 RVA: 0x0002FF54 File Offset: 0x0002E154
		public void LoadGame(int slot)
		{
			if (string.IsNullOrEmpty(this.playerPrefsKey))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: PlayerPrefs Key isn't set. Not loading.", new object[] { "Dialogue System" }));
				}
				return;
			}
			string text = this.playerPrefsKey + slot.ToString();
			if (!PlayerPrefs.HasKey(text))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: No saved game in PlayerPrefs key '{1}'. Not loading.", new object[] { "Dialogue System", text }));
				}
				return;
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Loading save data from slot {1} and applying it.", new object[] { "Dialogue System", slot }));
			}
			string @string = PlayerPrefs.GetString(text);
			LevelManager levelManager = this.FindLevelManager();
			if (levelManager != null)
			{
				levelManager.LoadGame(@string);
			}
			else
			{
				PersistentDataManager.ApplySaveData(@string, DatabaseResetOptions.KeepAllLoaded);
				DialogueManager.SendUpdateTracker();
			}
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x00030048 File Offset: 0x0002E248
		public void LoadGame()
		{
			this.LoadGame(this.slot);
		}

		// Token: 0x06001B47 RID: 6983 RVA: 0x00030058 File Offset: 0x0002E258
		public void SaveGame(string slotString)
		{
			this.SaveGame(this.StringToSlot(slotString));
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x00030068 File Offset: 0x0002E268
		public void LoadGame(string slotString)
		{
			this.LoadGame(this.StringToSlot(slotString));
		}

		// Token: 0x06001B49 RID: 6985 RVA: 0x00030078 File Offset: 0x0002E278
		public void RestartGame()
		{
			LevelManager levelManager = this.FindLevelManager();
			if (levelManager != null)
			{
				levelManager.RestartGame();
			}
			else
			{
				DialogueManager.ResetDatabase(DatabaseResetOptions.RevertToDefault);
				if (string.IsNullOrEmpty(this.startingLevel))
				{
					Tools.LoadLevel(0);
				}
				else
				{
					Tools.LoadLevel(this.startingLevel);
				}
				DialogueManager.SendUpdateTracker();
			}
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x000300D4 File Offset: 0x0002E2D4
		private LevelManager FindLevelManager()
		{
			LevelManager levelManager = base.GetComponentInChildren<LevelManager>();
			if (levelManager == null)
			{
				levelManager = Object.FindObjectOfType<LevelManager>();
			}
			return levelManager;
		}

		// Token: 0x06001B4B RID: 6987 RVA: 0x000300FC File Offset: 0x0002E2FC
		private int StringToSlot(string slotString)
		{
			int num = 0;
			int.TryParse(slotString, out num);
			return num;
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x00030118 File Offset: 0x0002E318
		public void Record()
		{
			PersistentDataManager.Record();
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x00030120 File Offset: 0x0002E320
		public void Apply()
		{
			PersistentDataManager.Apply();
		}

		// Token: 0x04000F53 RID: 3923
		public string playerPrefsKey = "savedgame";

		// Token: 0x04000F54 RID: 3924
		public int slot;

		// Token: 0x04000F55 RID: 3925
		public GameSaver.FunctionOnUse functionOnUse;

		// Token: 0x04000F56 RID: 3926
		public bool includeAllItemData;

		// Token: 0x04000F57 RID: 3927
		public bool includeLocationData;

		// Token: 0x04000F58 RID: 3928
		public bool includeSimStatus;

		// Token: 0x04000F59 RID: 3929
		public string startingLevel = string.Empty;

		// Token: 0x04000F5A RID: 3930
		public bool dontDestroyOnLoad;

		// Token: 0x02000275 RID: 629
		public enum FunctionOnUse
		{
			// Token: 0x04000F5C RID: 3932
			None,
			// Token: 0x04000F5D RID: 3933
			Save,
			// Token: 0x04000F5E RID: 3934
			Load,
			// Token: 0x04000F5F RID: 3935
			Restart
		}
	}
}
