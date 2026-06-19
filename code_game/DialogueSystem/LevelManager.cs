using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000276 RID: 630
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/level_manager.html")]
	[AddComponentMenu("Dialogue System/Save System/Level Manager")]
	public class LevelManager : MonoBehaviour
	{
		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x06001B4F RID: 6991 RVA: 0x00030130 File Offset: 0x0002E330
		// (set) Token: 0x06001B50 RID: 6992 RVA: 0x00030138 File Offset: 0x0002E338
		public bool IsLoading { get; private set; }

		// Token: 0x06001B51 RID: 6993 RVA: 0x00030144 File Offset: 0x0002E344
		protected virtual void Awake()
		{
			this.IsLoading = false;
		}

		// Token: 0x06001B52 RID: 6994 RVA: 0x00030150 File Offset: 0x0002E350
		protected virtual void OnEnable()
		{
			PersistentDataManager.RegisterPersistentData(base.gameObject);
		}

		// Token: 0x06001B53 RID: 6995 RVA: 0x00030160 File Offset: 0x0002E360
		protected virtual void OnDisable()
		{
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
		}

		// Token: 0x06001B54 RID: 6996 RVA: 0x00030170 File Offset: 0x0002E370
		public void LoadGame(string saveData)
		{
			base.StartCoroutine(this.LoadLevelFromSaveData(saveData));
		}

		// Token: 0x06001B55 RID: 6997 RVA: 0x00030180 File Offset: 0x0002E380
		public void RestartGame()
		{
			base.StartCoroutine(this.LoadLevelFromSaveData(null));
		}

		// Token: 0x06001B56 RID: 6998 RVA: 0x00030190 File Offset: 0x0002E390
		private IEnumerator LoadLevelFromSaveData(string saveData)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: LevelManager: Starting LoadLevelFromSaveData coroutine");
			}
			string levelName = this.defaultStartingLevel;
			if (string.IsNullOrEmpty(saveData))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: LevelManager: Save data is empty, so just resetting database");
				}
				DialogueManager.ResetDatabase(DatabaseResetOptions.RevertToDefault);
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: LevelManager: Applying save data to get value of 'SavedLevelName' variable");
				}
				Lua.Run(saveData, DialogueDebug.LogInfo);
				levelName = DialogueLua.GetVariable("SavedLevelName").AsString;
				if (string.IsNullOrEmpty(levelName) || string.Equals(levelName, "nil"))
				{
					levelName = this.defaultStartingLevel;
					if (DialogueDebug.LogInfo)
					{
						Debug.Log("Dialogue System: LevelManager: 'SavedLevelName' isn't defined. Using default level " + levelName);
					}
				}
				else if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: LevelManager: SavedLevelName = " + levelName);
				}
			}
			PersistentDataManager.LevelWillBeUnloaded();
			if (this.CanLoadAsync())
			{
				AsyncOperation async = Tools.LoadLevelAsync(levelName);
				this.IsLoading = true;
				while (!async.isDone)
				{
					yield return null;
				}
				this.IsLoading = false;
			}
			else
			{
				Tools.LoadLevel(levelName);
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: LevelManager finished loading level " + levelName + ". Waiting 2 frames for scene objects to start.");
			}
			yield return null;
			yield return null;
			if (!string.IsNullOrEmpty(saveData))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: LevelManager waited 2 frames. Appling save data: " + saveData);
				}
				PersistentDataManager.ApplySaveData(saveData, DatabaseResetOptions.KeepAllLoaded);
			}
			DialogueManager.SendUpdateTracker();
			yield break;
		}

		// Token: 0x06001B57 RID: 6999 RVA: 0x000301BC File Offset: 0x0002E3BC
		public void LoadLevel(string levelName)
		{
			base.StartCoroutine(this.LoadLevelCoroutine(levelName, -1));
		}

		// Token: 0x06001B58 RID: 7000 RVA: 0x000301D0 File Offset: 0x0002E3D0
		public void LoadLevel(int levelIndex)
		{
			base.StartCoroutine(this.LoadLevelCoroutine(null, levelIndex));
		}

		// Token: 0x06001B59 RID: 7001 RVA: 0x000301E4 File Offset: 0x0002E3E4
		private IEnumerator LoadLevelCoroutine(string levelName, int levelIndex)
		{
			PersistentDataManager.Record();
			PersistentDataManager.LevelWillBeUnloaded();
			if (this.CanLoadAsync())
			{
				AsyncOperation async = (string.IsNullOrEmpty(levelName) ? Tools.LoadLevelAsync(levelIndex) : Tools.LoadLevelAsync(levelName));
				this.IsLoading = true;
				while (!async.isDone)
				{
					yield return null;
				}
				this.IsLoading = false;
			}
			else if (!string.IsNullOrEmpty(levelName))
			{
				Tools.LoadLevel(levelName);
			}
			else
			{
				Tools.LoadLevel(levelIndex);
			}
			yield return null;
			yield return null;
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			PersistentPositionData persistentPos = ((!(player != null)) ? null : player.GetComponent<PersistentPositionData>());
			bool originalValue = false;
			if (persistentPos != null)
			{
				originalValue = persistentPos.restoreCurrentLevelPosition;
				persistentPos.restoreCurrentLevelPosition = false;
			}
			PersistentDataManager.Apply();
			if (persistentPos != null)
			{
				persistentPos.restoreCurrentLevelPosition = originalValue;
			}
			DialogueManager.SendUpdateTracker();
			yield break;
		}

		// Token: 0x06001B5A RID: 7002 RVA: 0x0003021C File Offset: 0x0002E41C
		private bool CanLoadAsync()
		{
			return true;
		}

		// Token: 0x06001B5B RID: 7003 RVA: 0x00030220 File Offset: 0x0002E420
		public virtual void OnRecordPersistentData()
		{
			DialogueLua.SetVariable("SavedLevelName", Tools.loadedLevelName);
		}

		// Token: 0x04000F60 RID: 3936
		public string defaultStartingLevel;
	}
}
