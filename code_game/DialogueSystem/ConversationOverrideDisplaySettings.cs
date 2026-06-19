using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class ConversationOverrideDisplaySettings
	{
		// Token: 0x04000081 RID: 129
		public bool useOverrides;

		// Token: 0x04000082 RID: 130
		public bool overrideSubtitleSettings;

		// Token: 0x04000083 RID: 131
		public bool showNPCSubtitlesDuringLine = true;

		// Token: 0x04000084 RID: 132
		public bool showNPCSubtitlesWithResponses = true;

		// Token: 0x04000085 RID: 133
		public bool showPCSubtitlesDuringLine;

		// Token: 0x04000086 RID: 134
		public bool skipPCSubtitleAfterResponseMenu;

		// Token: 0x04000087 RID: 135
		public float subtitleCharsPerSecond = 30f;

		// Token: 0x04000088 RID: 136
		public float minSubtitleSeconds = 2f;

		// Token: 0x04000089 RID: 137
		public DisplaySettings.SubtitleSettings.ContinueButtonMode continueButton;

		// Token: 0x0400008A RID: 138
		public bool overrideSequenceSettings;

		// Token: 0x0400008B RID: 139
		public string defaultSequence;

		// Token: 0x0400008C RID: 140
		public string defaultPlayerSequence;

		// Token: 0x0400008D RID: 141
		public string defaultResponseMenuSequence;

		// Token: 0x0400008E RID: 142
		public bool overrideInputSettings;

		// Token: 0x0400008F RID: 143
		public bool alwaysForceResponseMenu = true;

		// Token: 0x04000090 RID: 144
		public float responseTimeout;
	}
}
