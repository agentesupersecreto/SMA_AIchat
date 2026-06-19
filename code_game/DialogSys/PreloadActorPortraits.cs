using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000035 RID: 53
	[AddComponentMenu("Dialogue System/UI/Miscellaneous/Preload Actor Portraits")]
	public class PreloadActorPortraits : MonoBehaviour
	{
		// Token: 0x06000177 RID: 375 RVA: 0x000088D0 File Offset: 0x00006AD0
		private void Start()
		{
			if (DialogueManager.Instance == null || DialogueManager.DatabaseManager == null || DialogueManager.MasterDatabase == null)
			{
				return;
			}
			if (this.collapseLegacyTextures && !DialogueManager.Instance.instantiateDatabase)
			{
				Debug.LogWarning("Dialogue System: Dialogue Manager's Instantiate Database checkbox isn't ticked. Can't collapse legacy textures.", DialogueManager.Instance);
				this.collapseLegacyTextures = false;
			}
			List<Actor> actors = DialogueManager.MasterDatabase.actors;
			if (actors == null)
			{
				return;
			}
			for (int i = 0; i < actors.Count; i++)
			{
				this.PreloadActor(actors[i]);
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00008958 File Offset: 0x00006B58
		public void PreloadActor(Actor actor)
		{
			if (actor == null)
			{
				return;
			}
			actor.portrait = this.PreloadTexture(actor.portrait);
			if (actor.alternatePortraits == null)
			{
				return;
			}
			for (int i = 0; i < actor.alternatePortraits.Count; i++)
			{
				actor.alternatePortraits[i] = this.PreloadTexture(actor.alternatePortraits[i]);
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000089B8 File Offset: 0x00006BB8
		public Texture2D PreloadTexture(Texture2D texture)
		{
			if (texture == null)
			{
				return null;
			}
			if (this.supportUnityUI)
			{
				Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, (float)texture.width, (float)texture.height), Vector2.zero);
				if (this.collapseLegacyTextures)
				{
					texture = new Texture2D(2, 2);
				}
				UITools.spriteCache.Add(texture, sprite);
			}
			this.legacyPortraits.Add(texture);
			return texture;
		}

		// Token: 0x0400012E RID: 302
		[Tooltip("Preload for Unity UI Dialogue UI.")]
		public bool supportUnityUI;

		// Token: 0x0400012F RID: 303
		[Tooltip("If preloading for Unity UI Dialogue UI, collapse legacy textures to save memory. Dialogue Manager's Instantiate Database must be ticked.")]
		public bool collapseLegacyTextures;

		// Token: 0x04000130 RID: 304
		private List<Texture2D> legacyPortraits = new List<Texture2D>();
	}
}
