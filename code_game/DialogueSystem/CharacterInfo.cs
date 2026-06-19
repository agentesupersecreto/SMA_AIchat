using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200021F RID: 543
	public class CharacterInfo
	{
		// Token: 0x060018A7 RID: 6311 RVA: 0x00023ABC File Offset: 0x00021CBC
		public CharacterInfo(int id, string nameInDatabase, Transform transform, CharacterType characterType, Texture2D portrait)
		{
			this.id = id;
			this.nameInDatabase = nameInDatabase;
			this.characterType = characterType;
			this.portrait = portrait;
			this.transform = transform;
			if (transform == null && !string.IsNullOrEmpty(nameInDatabase))
			{
				GameObject gameObject = SequencerTools.FindSpecifier(nameInDatabase, true);
				if (gameObject != null)
				{
					this.transform = gameObject.transform;
				}
			}
			this.Name = ((!(this.transform == null)) ? OverrideActorName.GetActorName(this.transform) : CharacterInfo.GetLocalizedDisplayNameInDatabase(nameInDatabase));
		}

		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x060018A9 RID: 6313 RVA: 0x00023B64 File Offset: 0x00021D64
		public bool IsPlayer
		{
			get
			{
				return this.characterType == CharacterType.PC;
			}
		}

		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x060018AA RID: 6314 RVA: 0x00023B70 File Offset: 0x00021D70
		public bool IsNPC
		{
			get
			{
				return this.characterType == CharacterType.NPC;
			}
		}

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x060018AB RID: 6315 RVA: 0x00023B7C File Offset: 0x00021D7C
		// (set) Token: 0x060018AC RID: 6316 RVA: 0x00023B84 File Offset: 0x00021D84
		public string Name { get; set; }

		// Token: 0x060018AD RID: 6317 RVA: 0x00023B90 File Offset: 0x00021D90
		public static string GetLocalizedDisplayNameInDatabase(string nameInDatabase)
		{
			string text = DialogueLua.GetLocalizedActorField(nameInDatabase, "Display Name").AsString;
			if (string.IsNullOrEmpty(text) || string.Equals(text, "nil"))
			{
				text = DialogueLua.GetLocalizedActorField(nameInDatabase, "Name").AsString;
			}
			if (string.IsNullOrEmpty(text) || string.Equals(text, "nil"))
			{
				text = nameInDatabase;
			}
			return FormattedText.ParseCode(text);
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x00023C04 File Offset: 0x00021E04
		public Texture2D GetPicOverride(int picNum)
		{
			if (picNum < 2)
			{
				return this.portrait;
			}
			int num = picNum - 2;
			Actor actor = DialogueManager.MasterDatabase.GetActor(this.id);
			return (actor == null || num >= actor.alternatePortraits.Count) ? this.portrait : actor.alternatePortraits[num];
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x00023C64 File Offset: 0x00021E64
		public static void RegisterActorTransform(string actorName, Transform actorTransform)
		{
			if (string.IsNullOrEmpty(actorName) || actorTransform == null)
			{
				return;
			}
			if (CharacterInfo.registeredActorTransforms.ContainsKey(actorName))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Concat(new string[] { "Dialogue System: Registering transform ", actorTransform.name, " as actor '", actorName, "' but another transform is already registered. Overwriting with new transform." }), actorTransform);
				}
				CharacterInfo.registeredActorTransforms[actorName] = actorTransform;
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Concat(new string[] { "Dialogue System: Registering transform ", actorTransform.name, " as actor '", actorName, "'." }), actorTransform);
				}
				CharacterInfo.registeredActorTransforms.Add(actorName, actorTransform);
			}
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00023D38 File Offset: 0x00021F38
		public static void UnregisterActorTransform(string actorName, Transform actorTransform)
		{
			if (string.IsNullOrEmpty(actorName) || actorTransform == null)
			{
				return;
			}
			if (CharacterInfo.registeredActorTransforms.ContainsKey(actorName))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Concat(new string[] { "Dialogue System: Unregistering transform ", actorTransform.name, " from actor '", actorName, "'." }), actorTransform);
				}
				CharacterInfo.registeredActorTransforms.Remove(actorName);
			}
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x00023DBC File Offset: 0x00021FBC
		public static Transform GetRegisteredActorTransform(string actorName)
		{
			return (!CharacterInfo.registeredActorTransforms.ContainsKey(actorName)) ? null : CharacterInfo.registeredActorTransforms[actorName];
		}

		// Token: 0x04000DC4 RID: 3524
		public int id;

		// Token: 0x04000DC5 RID: 3525
		public string nameInDatabase;

		// Token: 0x04000DC6 RID: 3526
		public CharacterType characterType;

		// Token: 0x04000DC7 RID: 3527
		public Transform transform;

		// Token: 0x04000DC8 RID: 3528
		public Texture2D portrait;

		// Token: 0x04000DC9 RID: 3529
		private static Dictionary<string, Transform> registeredActorTransforms = new Dictionary<string, Transform>();
	}
}
