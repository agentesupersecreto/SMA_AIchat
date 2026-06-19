using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000222 RID: 546
	[AddComponentMenu("Dialogue System/Actor/Override Actor Name")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/override_actor_name.html")]
	public class OverrideActorName : MonoBehaviour
	{
		// Token: 0x060018BD RID: 6333 RVA: 0x00023EF4 File Offset: 0x000220F4
		public void OnEnable()
		{
			if (string.IsNullOrEmpty(this.overrideName))
			{
				return;
			}
			CharacterInfo.RegisterActorTransform(this.overrideName, base.transform);
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x00023F24 File Offset: 0x00022124
		public void OnDisable()
		{
			if (string.IsNullOrEmpty(this.overrideName))
			{
				return;
			}
			CharacterInfo.UnregisterActorTransform(this.overrideName, base.transform);
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x00023F54 File Offset: 0x00022154
		public string GetName()
		{
			string text = ((!string.IsNullOrEmpty(this.overrideName)) ? this.overrideName : base.name);
			if (this.useLocalizedNameInDatabase)
			{
				string localizedDisplayNameInDatabase = CharacterInfo.GetLocalizedDisplayNameInDatabase(DialogueLua.GetActorField(text, "Name").AsString);
				return string.IsNullOrEmpty(localizedDisplayNameInDatabase) ? text : localizedDisplayNameInDatabase;
			}
			return text;
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x00023FBC File Offset: 0x000221BC
		public string GetOverrideName()
		{
			if (this.overrideName.Contains("[lua") || this.overrideName.Contains("[var"))
			{
				return FormattedText.Parse(this.overrideName, DialogueManager.MasterDatabase.emphasisSettings).text;
			}
			return this.overrideName;
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x00024014 File Offset: 0x00022214
		public string GetInternalName()
		{
			return (!string.IsNullOrEmpty(this.internalName)) ? this.internalName : this.GetOverrideName();
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x00024038 File Offset: 0x00022238
		public static OverrideActorName GetOverrideActorName(Transform t)
		{
			if (t == null)
			{
				return null;
			}
			OverrideActorName overrideActorName = t.GetComponentInChildren<OverrideActorName>();
			if (overrideActorName == null && t.parent != null)
			{
				overrideActorName = t.parent.GetComponent<OverrideActorName>();
			}
			return overrideActorName;
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x00024084 File Offset: 0x00022284
		public static string GetActorName(Transform t)
		{
			if (t == null)
			{
				return string.Empty;
			}
			OverrideActorName overrideActorName = OverrideActorName.GetOverrideActorName(t);
			return (!(overrideActorName == null)) ? overrideActorName.GetName() : CharacterInfo.GetLocalizedDisplayNameInDatabase(t.name);
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x000240CC File Offset: 0x000222CC
		public static string GetInternalName(Transform t)
		{
			if (t == null)
			{
				return string.Empty;
			}
			OverrideActorName overrideActorName = OverrideActorName.GetOverrideActorName(t);
			if (overrideActorName != null)
			{
				if (!string.IsNullOrEmpty(overrideActorName.internalName))
				{
					return overrideActorName.internalName;
				}
				if (!string.IsNullOrEmpty(overrideActorName.overrideName))
				{
					return overrideActorName.overrideName;
				}
			}
			return t.name;
		}

		// Token: 0x04000DD0 RID: 3536
		[Tooltip("Use this actor name in conversations.")]
		public string overrideName;

		// Token: 0x04000DD1 RID: 3537
		[Tooltip("Name used when saving persistent data.")]
		public string internalName;

		// Token: 0x04000DD2 RID: 3538
		[Tooltip("Look up the localized field associated with the actor's name.")]
		public bool useLocalizedNameInDatabase;
	}
}
