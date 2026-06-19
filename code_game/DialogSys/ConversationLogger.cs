using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000039 RID: 57
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/conversation_logger.html")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Conversation Logger")]
	public class ConversationLogger : MonoBehaviour
	{
		// Token: 0x06000191 RID: 401 RVA: 0x00008F75 File Offset: 0x00007175
		public void OnConversationStart(Transform actor)
		{
			Debug.Log(string.Format("{0}: Starting conversation with {1}", new object[]
			{
				base.name,
				this.GetActorName(actor)
			}));
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00008FA0 File Offset: 0x000071A0
		public void OnConversationLine(Subtitle subtitle)
		{
			if ((subtitle == null) | (subtitle.formattedText == null) | string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				return;
			}
			string text = ((subtitle.speakerInfo != null && subtitle.speakerInfo.transform != null) ? subtitle.speakerInfo.transform.name : "(null speaker)");
			Debug.Log(string.Format("<color={0}>{1}: {2}</color>", new object[]
			{
				this.GetActorColor(subtitle),
				text,
				subtitle.formattedText.text
			}));
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00009033 File Offset: 0x00007233
		public void OnConversationEnd(Transform actor)
		{
			Debug.Log(string.Format("{0}: Ending conversation with {1}", base.name, this.GetActorName(actor)));
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00009051 File Offset: 0x00007251
		private string GetActorName(Transform actor)
		{
			if (!(actor != null))
			{
				return "(null transform)";
			}
			return actor.name;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00009068 File Offset: 0x00007268
		private string GetActorColor(Subtitle subtitle)
		{
			if ((subtitle == null) | (subtitle.speakerInfo == null))
			{
				return "white";
			}
			return Tools.ToWebColor(subtitle.speakerInfo.IsPlayer ? this.playerColor : this.npcColor);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000090A0 File Offset: 0x000072A0
		public void OnPrepareConversationLine(DialogueEntry entry)
		{
			if (entry == null)
			{
				return;
			}
			Debug.Log(string.Format("Preparing line {0}", entry.DialogueText));
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000090BC File Offset: 0x000072BC
		public void OnConversationLineCancelled(Subtitle subtitle)
		{
			if ((subtitle == null) | (subtitle.formattedText == null) | string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				return;
			}
			string text = ((subtitle.speakerInfo != null && subtitle.speakerInfo.transform != null) ? subtitle.speakerInfo.transform.name : "(null speaker)");
			Debug.Log(string.Format("<color={0}>Line cancelled - {1}: {2}</color>", new object[]
			{
				this.GetActorColor(subtitle),
				text,
				subtitle.formattedText.text
			}));
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00009150 File Offset: 0x00007350
		public void OnConversationLineEnd(Subtitle subtitle)
		{
			if ((subtitle == null) | (subtitle.formattedText == null) | string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				return;
			}
			string text = ((subtitle.speakerInfo != null && subtitle.speakerInfo.transform != null) ? subtitle.speakerInfo.transform.name : "(null speaker)");
			Debug.Log(string.Format("<color={0}>Line ended - {1}: {2}</color>", new object[]
			{
				this.GetActorColor(subtitle),
				text,
				subtitle.formattedText.text
			}));
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000091E3 File Offset: 0x000073E3
		public void OnConversationResponseMenu(Response[] responses)
		{
			Debug.Log("Showing conversation response menu.");
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000091EF File Offset: 0x000073EF
		public void OnConversationTimeout()
		{
			Debug.Log("Conversation timed out.");
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000091FB File Offset: 0x000073FB
		public void OnLinkedConversationStart(Transform actor)
		{
			Debug.Log("Starting linked conversation.");
		}

		// Token: 0x0400013C RID: 316
		public Color playerColor = Color.blue;

		// Token: 0x0400013D RID: 317
		public Color npcColor = Color.red;
	}
}
