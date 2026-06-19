using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200027B RID: 635
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/persistent_position_data.html")]
	[AddComponentMenu("Dialogue System/Save System/Persistent Position Data")]
	public class PersistentPositionData : MonoBehaviour
	{
		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x06001B83 RID: 7043 RVA: 0x000318D0 File Offset: 0x0002FAD0
		private string actorName
		{
			get
			{
				return (!string.IsNullOrEmpty(this.overrideActorName)) ? this.overrideActorName : base.gameObject.name;
			}
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x00031904 File Offset: 0x0002FB04
		protected virtual void OnEnable()
		{
			PersistentDataManager.RegisterPersistentData(base.gameObject);
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x00031914 File Offset: 0x0002FB14
		protected virtual void OnDisable()
		{
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x00031924 File Offset: 0x0002FB24
		public void Start()
		{
			if (string.IsNullOrEmpty(this.overrideActorName))
			{
				this.overrideActorName = OverrideActorName.GetInternalName(base.transform);
			}
		}

		// Token: 0x06001B87 RID: 7047 RVA: 0x00031948 File Offset: 0x0002FB48
		public void OnRecordPersistentData()
		{
			string positionString = this.GetPositionString();
			string text = ((!this.recordCurrentLevel) ? "Position" : ("Position_" + PersistentPositionData.SanitizeLevelName(Tools.loadedLevelName)));
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Concat(new string[] { "Dialogue System: Persistent Position Data Actor[", this.actorName, "].", text, "='", positionString, "'" }), this);
			}
			DialogueLua.SetActorField(this.actorName, text, positionString);
		}

		// Token: 0x06001B88 RID: 7048 RVA: 0x000319E0 File Offset: 0x0002FBE0
		public void OnApplyPersistentData()
		{
			string asString = DialogueLua.GetActorField(this.actorName, "Spawnpoint").AsString;
			if (!string.IsNullOrEmpty(asString))
			{
				GameObject gameObject = Tools.GameObjectHardFind(asString);
				if (gameObject == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Concat(new string[] { "Dialogue System: Persistent Position Data found Actor[", this.actorName, "].Spawnpoint value '", asString, "' but can't find a GameObject with this name in the scene. Moving actor to saved position instead." }), this);
					}
				}
				else
				{
					base.transform.position = gameObject.transform.position;
					base.transform.rotation = gameObject.transform.rotation;
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Concat(new object[] { "Dialogue System: Persistent Position Data spawning ", this.actorName, " at spawnpoint ", gameObject }), this);
					}
				}
				DialogueLua.SetActorField(this.actorName, "Spawnpoint", string.Empty);
				if (gameObject != null)
				{
					return;
				}
			}
			string text = ((!this.recordCurrentLevel) ? "Position" : ("Position_" + PersistentPositionData.SanitizeLevelName(Tools.loadedLevelName)));
			string asString2 = DialogueLua.GetActorField(this.actorName, text).AsString;
			if (!string.IsNullOrEmpty(asString2))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: Persistent Position Data restoring " + this.actorName + " to position " + asString2, this);
				}
				this.ApplyPositionString(asString2);
			}
			else if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Concat(new string[] { "Dialogue System: Persistent Position Data Actor[", this.actorName, "].", text, " is blank. Not moving ", this.actorName }), this);
			}
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x00031BB8 File Offset: 0x0002FDB8
		private string GetPositionString()
		{
			string text = ((!this.recordCurrentLevel) ? string.Empty : DialogueLua.DoubleQuotesToSingle("," + Tools.loadedLevelName));
			return string.Format("{0},{1},{2},{3},{4},{5},{6}{7}", new object[]
			{
				base.transform.position.x,
				base.transform.position.y,
				base.transform.position.z,
				base.transform.rotation.x,
				base.transform.rotation.y,
				base.transform.rotation.z,
				base.transform.rotation.w,
				text
			});
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x00031CC4 File Offset: 0x0002FEC4
		private void ApplyPositionString(string s)
		{
			if (string.IsNullOrEmpty(s) || s.Equals("nil"))
			{
				return;
			}
			string[] array = s.Split(new char[] { ',' });
			if (7 <= array.Length && array.Length <= 8)
			{
				if (this.recordCurrentLevel && array.Length == 8 && !string.Equals(array[7], Tools.loadedLevelName))
				{
					return;
				}
				float[] array2 = new float[7];
				for (int i = 0; i < 7; i++)
				{
					array2[i] = 0f;
					float.TryParse(array[i], out array2[i]);
				}
				base.transform.position = new Vector3(array2[0], array2[1], array2[2]);
				base.transform.rotation = new Quaternion(array2[3], array2[4], array2[5], array2[6]);
			}
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x00031DA0 File Offset: 0x0002FFA0
		public static string SanitizeLevelName(string levelName)
		{
			return DialogueLua.StringToTableIndex(levelName).Replace(".", "_");
		}

		// Token: 0x04000F7A RID: 3962
		public string overrideActorName;

		// Token: 0x04000F7B RID: 3963
		public bool recordCurrentLevel = true;

		// Token: 0x04000F7C RID: 3964
		[HideInInspector]
		public bool restoreCurrentLevelPosition = true;
	}
}
