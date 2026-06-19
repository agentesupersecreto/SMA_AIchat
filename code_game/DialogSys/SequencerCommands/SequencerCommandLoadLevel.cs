using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000054 RID: 84
	[AddComponentMenu("")]
	public class SequencerCommandLoadLevel : SequencerCommand
	{
		// Token: 0x06000273 RID: 627 RVA: 0x0000D404 File Offset: 0x0000B604
		public void Start()
		{
			string parameter = base.GetParameter(0, null);
			string parameter2 = base.GetParameter(1, null);
			if (string.IsNullOrEmpty(parameter))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: LoadLevel() level name is an empty string", "Dialogue System"));
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: LoadLevel({1})", "Dialogue System", base.GetParameters()));
				}
				DialogueLua.SetActorField("Player", "Spawnpoint", parameter2);
				LevelManager levelManager = Object.FindObjectOfType<LevelManager>();
				if (levelManager != null)
				{
					levelManager.LoadLevel(parameter);
				}
				else
				{
					PersistentDataManager.Record();
					PersistentDataManager.LevelWillBeUnloaded();
					SceneManager.LoadScene(parameter, LoadSceneMode.Single);
					PersistentDataManager.Apply();
				}
			}
			base.Stop();
		}
	}
}
