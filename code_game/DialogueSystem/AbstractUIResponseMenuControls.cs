using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000266 RID: 614
	[Serializable]
	public abstract class AbstractUIResponseMenuControls : AbstractUIControls
	{
		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x06001A86 RID: 6790
		public abstract AbstractUISubtitleControls SubtitleReminder { get; }

		// Token: 0x06001A87 RID: 6791
		protected abstract void ClearResponseButtons();

		// Token: 0x06001A88 RID: 6792
		protected abstract void SetResponseButtons(Response[] responses, Transform target);

		// Token: 0x06001A89 RID: 6793
		public abstract void StartTimer(float timeout);

		// Token: 0x06001A8A RID: 6794 RVA: 0x0002D5A0 File Offset: 0x0002B7A0
		public virtual void ShowResponses(Subtitle subtitle, Response[] responses, Transform target)
		{
			if (responses != null && responses.Length > 0)
			{
				this.SubtitleReminder.ShowSubtitle(subtitle);
				this.ClearResponseButtons();
				this.SetResponseButtons(responses, target);
				base.Show();
			}
			else
			{
				base.Hide();
			}
		}

		// Token: 0x06001A8B RID: 6795 RVA: 0x0002D5E8 File Offset: 0x0002B7E8
		public virtual void SetPCPortrait(Texture2D portraitTexture, string portraitName)
		{
		}

		// Token: 0x06001A8C RID: 6796 RVA: 0x0002D5EC File Offset: 0x0002B7EC
		public virtual void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
		}

		// Token: 0x04000EFE RID: 3838
		public ResponseButtonAlignment buttonAlignment;

		// Token: 0x04000EFF RID: 3839
		public bool showUnusedButtons;
	}
}
