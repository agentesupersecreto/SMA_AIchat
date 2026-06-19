using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000038 RID: 56
	public static class UITools
	{
		// Token: 0x06000189 RID: 393 RVA: 0x00008DC0 File Offset: 0x00006FC0
		public static void RequireEventSystem()
		{
			if (Object.FindObjectOfType<EventSystem>() == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: The scene is missing an EventSystem. Adding one.");
				}
				new GameObject("EventSystem", new Type[]
				{
					typeof(EventSystem),
					typeof(StandaloneInputModule)
				});
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00008E16 File Offset: 0x00007016
		public static int GetAnimatorNameHash(AnimatorStateInfo animatorStateInfo)
		{
			return animatorStateInfo.fullPathHash;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00008E1F File Offset: 0x0000701F
		public static void ClearSpriteCache()
		{
			UITools.spriteCache.Clear();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00008E2C File Offset: 0x0000702C
		public static Sprite CreateSprite(Texture2D texture)
		{
			if (texture == null)
			{
				return null;
			}
			if (UITools.spriteCache.ContainsKey(texture))
			{
				return UITools.spriteCache[texture];
			}
			Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, (float)texture.width, (float)texture.height), Vector2.zero);
			UITools.spriteCache.Add(texture, sprite);
			return sprite;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00008E93 File Offset: 0x00007093
		public static string GetUIFormattedText(FormattedText formattedText)
		{
			if (formattedText == null)
			{
				return string.Empty;
			}
			if (formattedText.italic)
			{
				return "<i>" + formattedText.text + "</i>";
			}
			return formattedText.text;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00008EC4 File Offset: 0x000070C4
		public static void SendTextChangeMessage(Text text)
		{
			if (text == null)
			{
				return;
			}
			if (UITools.dialogueUI == null)
			{
				UITools.dialogueUI = text.GetComponentInParent<UnityUIDialogueUI>();
			}
			if (UITools.dialogueUI == null)
			{
				return;
			}
			UITools.dialogueUI.SendMessage("OnTextChange", text, SendMessageOptions.DontRequireReceiver);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00008F14 File Offset: 0x00007114
		public static void Select(Selectable selectable, bool allowStealFocus = true)
		{
			EventSystem current = EventSystem.current;
			if (current == null || selectable == null)
			{
				return;
			}
			if (current.currentSelectedGameObject == null || allowStealFocus)
			{
				current.SetSelectedGameObject(selectable.gameObject);
				selectable.Select();
				selectable.OnSelect(null);
			}
		}

		// Token: 0x0400013A RID: 314
		public static Dictionary<Texture2D, Sprite> spriteCache = new Dictionary<Texture2D, Sprite>();

		// Token: 0x0400013B RID: 315
		private static UnityUIDialogueUI dialogueUI = null;
	}
}
