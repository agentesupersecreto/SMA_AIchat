using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C6 RID: 710
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Typewriter Effect (Unity GUI)")]
	public class TypewriterEffect : GUIEffect
	{
		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06001D5C RID: 7516 RVA: 0x000387A8 File Offset: 0x000369A8
		// (set) Token: 0x06001D5D RID: 7517 RVA: 0x000387B0 File Offset: 0x000369B0
		public bool IsPlaying { get; private set; }

		// Token: 0x06001D5E RID: 7518 RVA: 0x000387BC File Offset: 0x000369BC
		public override IEnumerator Play()
		{
			GUILabel control = base.GetComponent<GUILabel>();
			if (control == null)
			{
				yield break;
			}
			this.IsPlaying = true;
			control.currentLength = 0;
			while (control.currentLength + 1 < control.text.Length)
			{
				float delay = 1f / this.charactersPerSecond;
				if (!DialogueTime.IsPaused)
				{
					if (this.audioClip != null && control.currentLength > 0)
					{
						control.PlaySound(this.audioClip);
					}
					this.AdvanceOneCharacter(control);
				}
				yield return base.StartCoroutine(DialogueTime.WaitForSeconds(delay));
			}
			control.currentLength = control.text.Length;
			control.ResetClosureTags();
			this.IsPlaying = false;
			yield break;
		}

		// Token: 0x06001D5F RID: 7519 RVA: 0x000387D8 File Offset: 0x000369D8
		private void AdvanceOneCharacter(GUILabel control)
		{
			if (control.text[control.currentLength] == '<')
			{
				if (string.Compare(control.text, control.currentLength, "<b>", 0, "<b>".Length) == 0)
				{
					control.currentLength += "<b>".Length;
					control.PushClosureTag("</b>");
				}
				else if (string.Compare(control.text, control.currentLength, "</b>", 0, "</b>".Length) == 0)
				{
					control.currentLength += "</b>".Length;
					control.PopClosureTag();
				}
				else if (string.Compare(control.text, control.currentLength, "<i>", 0, "<i>".Length) == 0)
				{
					control.currentLength += "<i>".Length;
					control.PushClosureTag("</i>");
				}
				else if (string.Compare(control.text, control.currentLength, "</i>", 0, "</i>".Length) == 0)
				{
					control.currentLength += "</i>".Length;
					control.PopClosureTag();
				}
				if (string.Compare(control.text, control.currentLength, "<color=", 0, "<color=".Length) == 0)
				{
					control.currentLength += "<color=".Length + 10;
					control.PushClosureTag("</color>");
				}
				else if (string.Compare(control.text, control.currentLength, "</color>", 0, "</color>".Length) == 0)
				{
					control.currentLength += "</color>".Length;
					control.PopClosureTag();
				}
			}
			else
			{
				control.currentLength++;
			}
		}

		// Token: 0x06001D60 RID: 7520 RVA: 0x000389C8 File Offset: 0x00036BC8
		public override void Stop()
		{
			base.Stop();
			this.IsPlaying = false;
			GUILabel component = base.GetComponent<GUILabel>();
			if (component != null)
			{
				component.currentLength = component.text.Length;
				component.ResetClosureTags();
			}
		}

		// Token: 0x040010CA RID: 4298
		private const string RichTextBoldOpen = "<b>";

		// Token: 0x040010CB RID: 4299
		private const string RichTextBoldClose = "</b>";

		// Token: 0x040010CC RID: 4300
		private const string RichTextItalicOpen = "<i>";

		// Token: 0x040010CD RID: 4301
		private const string RichTextItalicClose = "</i>";

		// Token: 0x040010CE RID: 4302
		private const string RichTextColorOpenPrefix = "<color=";

		// Token: 0x040010CF RID: 4303
		private const string RichTextColorClose = "</color>";

		// Token: 0x040010D0 RID: 4304
		public float charactersPerSecond = 50f;

		// Token: 0x040010D1 RID: 4305
		public AudioClip audioClip;
	}
}
