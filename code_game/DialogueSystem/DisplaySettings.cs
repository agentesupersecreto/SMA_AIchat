using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000249 RID: 585
	[Serializable]
	public class DisplaySettings
	{
		// Token: 0x060019F7 RID: 6647 RVA: 0x0002BCF8 File Offset: 0x00029EF8
		public bool ShouldUseOverrides()
		{
			return this.conversationOverrideSettings != null && this.conversationOverrideSettings.useOverrides;
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x0002BD14 File Offset: 0x00029F14
		public bool ShouldUseSubtitleOverrides()
		{
			return this.ShouldUseOverrides() && this.conversationOverrideSettings.overrideSubtitleSettings;
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x0002BD30 File Offset: 0x00029F30
		public bool GetShowNPCSubtitlesDuringLine()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? (this.subtitleSettings == null || this.subtitleSettings.showNPCSubtitlesDuringLine) : this.conversationOverrideSettings.showNPCSubtitlesDuringLine;
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x0002BD6C File Offset: 0x00029F6C
		public bool GetShowNPCSubtitlesWithResponses()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? (this.subtitleSettings == null || this.subtitleSettings.showNPCSubtitlesWithResponses) : this.conversationOverrideSettings.showNPCSubtitlesWithResponses;
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0002BDA8 File Offset: 0x00029FA8
		public bool GetShowPCSubtitlesDuringLine()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? (this.subtitleSettings == null || this.subtitleSettings.showPCSubtitlesDuringLine) : this.conversationOverrideSettings.showPCSubtitlesDuringLine;
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x0002BDE4 File Offset: 0x00029FE4
		public bool GetSkipPCSubtitleAfterResponseMenu()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? (this.subtitleSettings == null || this.subtitleSettings.skipPCSubtitleAfterResponseMenu) : this.conversationOverrideSettings.skipPCSubtitleAfterResponseMenu;
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x0002BE20 File Offset: 0x0002A020
		public float GetSubtitleCharsPerSecond()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? ((this.subtitleSettings == null) ? 30f : this.subtitleSettings.subtitleCharsPerSecond) : this.conversationOverrideSettings.subtitleCharsPerSecond;
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x0002BE60 File Offset: 0x0002A060
		public float GetMinSubtitleSeconds()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? ((this.subtitleSettings == null) ? 2f : this.subtitleSettings.minSubtitleSeconds) : this.conversationOverrideSettings.minSubtitleSeconds;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x0002BEA0 File Offset: 0x0002A0A0
		public DisplaySettings.SubtitleSettings.ContinueButtonMode GetContinueButtonMode()
		{
			return (!this.ShouldUseSubtitleOverrides()) ? ((this.subtitleSettings == null) ? DisplaySettings.SubtitleSettings.ContinueButtonMode.Never : this.subtitleSettings.continueButton) : this.conversationOverrideSettings.continueButton;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x0002BEDC File Offset: 0x0002A0DC
		public bool ShouldUseSequenceOverrides()
		{
			return this.ShouldUseOverrides() && this.conversationOverrideSettings.overrideSequenceSettings;
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x0002BEF8 File Offset: 0x0002A0F8
		public string GetDefaultSequence()
		{
			return (!this.ShouldUseSequenceOverrides() || string.IsNullOrEmpty(this.conversationOverrideSettings.defaultSequence)) ? ((this.cameraSettings == null) ? string.Empty : this.cameraSettings.defaultSequence) : this.conversationOverrideSettings.defaultSequence;
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x0002BF58 File Offset: 0x0002A158
		public string GetDefaultPlayerSequence()
		{
			return (!this.ShouldUseSequenceOverrides() || string.IsNullOrEmpty(this.conversationOverrideSettings.defaultPlayerSequence)) ? ((this.cameraSettings == null) ? string.Empty : this.cameraSettings.defaultPlayerSequence) : this.conversationOverrideSettings.defaultPlayerSequence;
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x0002BFB8 File Offset: 0x0002A1B8
		public string GetDefaultResponseMenuSequence()
		{
			return (!this.ShouldUseSequenceOverrides() || string.IsNullOrEmpty(this.conversationOverrideSettings.defaultResponseMenuSequence)) ? ((this.cameraSettings == null) ? string.Empty : this.cameraSettings.defaultResponseMenuSequence) : this.conversationOverrideSettings.defaultResponseMenuSequence;
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x0002C018 File Offset: 0x0002A218
		public bool ShouldUseInputOverrides()
		{
			return this.ShouldUseOverrides() && this.conversationOverrideSettings.overrideInputSettings;
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x0002C034 File Offset: 0x0002A234
		public bool GetAlwaysForceResponseMenu()
		{
			return (!this.ShouldUseInputOverrides()) ? (this.inputSettings == null || this.inputSettings.alwaysForceResponseMenu) : this.conversationOverrideSettings.alwaysForceResponseMenu;
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x0002C070 File Offset: 0x0002A270
		public float GetResponseTimeout()
		{
			return (!this.ShouldUseInputOverrides()) ? ((this.inputSettings == null) ? 0f : this.inputSettings.responseTimeout) : this.conversationOverrideSettings.responseTimeout;
		}

		// Token: 0x04000E92 RID: 3730
		[HideInInspector]
		public ConversationOverrideDisplaySettings conversationOverrideSettings;

		// Token: 0x04000E93 RID: 3731
		[Tooltip("Assign a GameObject that contains an active dialogue UI component.")]
		public GameObject dialogueUI;

		// Token: 0x04000E94 RID: 3732
		public DisplaySettings.LocalizationSettings localizationSettings = new DisplaySettings.LocalizationSettings();

		// Token: 0x04000E95 RID: 3733
		public DisplaySettings.SubtitleSettings subtitleSettings = new DisplaySettings.SubtitleSettings();

		// Token: 0x04000E96 RID: 3734
		public DisplaySettings.CameraSettings cameraSettings = new DisplaySettings.CameraSettings();

		// Token: 0x04000E97 RID: 3735
		public DisplaySettings.InputSettings inputSettings = new DisplaySettings.InputSettings();

		// Token: 0x04000E98 RID: 3736
		public DisplaySettings.BarkSettings barkSettings = new DisplaySettings.BarkSettings();

		// Token: 0x04000E99 RID: 3737
		public DisplaySettings.AlertSettings alertSettings = new DisplaySettings.AlertSettings();

		// Token: 0x0200024A RID: 586
		[Serializable]
		public class LocalizationSettings
		{
			// Token: 0x04000E9A RID: 3738
			[Tooltip("Current language, or blank to use the default language.")]
			public string language = string.Empty;

			// Token: 0x04000E9B RID: 3739
			[Tooltip("Use the system language at startup.")]
			public bool useSystemLanguage;

			// Token: 0x04000E9C RID: 3740
			[Tooltip("Optional localized text for alerts and other general text.")]
			public LocalizedTextTable localizedText;
		}

		// Token: 0x0200024B RID: 587
		[Serializable]
		public class SubtitleSettings
		{
			// Token: 0x04000E9D RID: 3741
			[Tooltip("Show NPC subtitle text while NPC speaks a line of dialogue.")]
			public bool showNPCSubtitlesDuringLine = true;

			// Token: 0x04000E9E RID: 3742
			[Tooltip("Show NPC subtitle reminder text while showing the player response menu.")]
			public bool showNPCSubtitlesWithResponses = true;

			// Token: 0x04000E9F RID: 3743
			[Tooltip("Show PC subtitle text while PC speaks a line of dialogue.")]
			public bool showPCSubtitlesDuringLine;

			// Token: 0x04000EA0 RID: 3744
			[Tooltip("Allow PC subtitles to be used for reminder text while showing the response menu.")]
			public bool allowPCSubtitleReminders;

			// Token: 0x04000EA1 RID: 3745
			[Tooltip("If the PC's subtitle came from a response menu selection, don't show the subtitle even if Show PC Subtitles During Line is ticked.")]
			public bool skipPCSubtitleAfterResponseMenu;

			// Token: 0x04000EA2 RID: 3746
			[Tooltip("Used to compute default duration to display subtitle. Typewriter effects have their own separate setting.")]
			public float subtitleCharsPerSecond = 30f;

			// Token: 0x04000EA3 RID: 3747
			[Tooltip("Minimum default duration to display subtitle.")]
			public float minSubtitleSeconds = 2f;

			// Token: 0x04000EA4 RID: 3748
			public DisplaySettings.SubtitleSettings.ContinueButtonMode continueButton;

			// Token: 0x04000EA5 RID: 3749
			[Tooltip("Convert [em#] tags to rich text codes.")]
			public bool richTextEmphases;

			// Token: 0x04000EA6 RID: 3750
			[Tooltip("Send OnSequenceStart and OnSequenceEnd messages with every dialogue entry's sequence.")]
			public bool informSequenceStartAndEnd;

			// Token: 0x0200024C RID: 588
			public enum ContinueButtonMode
			{
				// Token: 0x04000EA8 RID: 3752
				Never,
				// Token: 0x04000EA9 RID: 3753
				Always,
				// Token: 0x04000EAA RID: 3754
				Optional,
				// Token: 0x04000EAB RID: 3755
				OptionalBeforeResponseMenu,
				// Token: 0x04000EAC RID: 3756
				NotBeforeResponseMenu,
				// Token: 0x04000EAD RID: 3757
				OptionalBeforePCAutoresponseOrMenu,
				// Token: 0x04000EAE RID: 3758
				NotBeforePCAutoresponseOrMenu,
				// Token: 0x04000EAF RID: 3759
				OptionalForPC,
				// Token: 0x04000EB0 RID: 3760
				NotForPC,
				// Token: 0x04000EB1 RID: 3761
				OptionalForPCOrBeforeResponseMenu,
				// Token: 0x04000EB2 RID: 3762
				NotForPCOrBeforeResponseMenu,
				// Token: 0x04000EB3 RID: 3763
				OptionalForPCOrBeforePCAutoresponseOrMenu,
				// Token: 0x04000EB4 RID: 3764
				NotForPCOrBeforePCAutoresponseOrMenu
			}
		}

		// Token: 0x0200024D RID: 589
		[Serializable]
		public class CameraSettings
		{
			// Token: 0x04000EB5 RID: 3765
			[Tooltip("Camera or prefab to use for sequences. If unassigned, sequences use the current main camera.")]
			public Camera sequencerCamera;

			// Token: 0x04000EB6 RID: 3766
			[Tooltip("If assigned, use instead of Sequencer Camera -- for example, Oculus VR GameObject. Can't be a prefab.")]
			public GameObject alternateCameraObject;

			// Token: 0x04000EB7 RID: 3767
			[Tooltip("Camera angle object or prefab. If unassigned, uses default camera angle definitions.")]
			public GameObject cameraAngles;

			// Token: 0x04000EB8 RID: 3768
			[Tooltip("Used when a dialogue entry doesn't define its own Sequence. Set to Delay({{end}}) to leave the camera untouched.")]
			public string defaultSequence = "Delay({{end}})";

			// Token: 0x04000EB9 RID: 3769
			[Tooltip("If defined, overrides Default Sequence for player (PC) lines only.")]
			public string defaultPlayerSequence = string.Empty;

			// Token: 0x04000EBA RID: 3770
			[Tooltip("Used when a dialogue entry doesn't define its own Response Menu Sequence.")]
			public string defaultResponseMenuSequence = string.Empty;

			// Token: 0x04000EBB RID: 3771
			[Tooltip("Format to use for the 'entrytag' keyword.")]
			public EntrytagFormat entrytagFormat;

			// Token: 0x04000EBC RID: 3772
			[HideInInspector]
			public bool disableInternalSequencerCommands;
		}

		// Token: 0x0200024E RID: 590
		[Serializable]
		public class InputSettings
		{
			// Token: 0x04000EBD RID: 3773
			[Tooltip("Show the response menu even if there's only one response.")]
			public bool alwaysForceResponseMenu = true;

			// Token: 0x04000EBE RID: 3774
			[Tooltip("Include responses whose Conditions are false. typically shown in a disabled state.")]
			public bool includeInvalidEntries;

			// Token: 0x04000EBF RID: 3775
			[Tooltip("If nonzero, the duration in seconds until the response menu times out.")]
			public float responseTimeout;

			// Token: 0x04000EC0 RID: 3776
			[Tooltip("What to do if the response menu times out.")]
			public ResponseTimeoutAction responseTimeoutAction;

			// Token: 0x04000EC1 RID: 3777
			[Tooltip("The [em#] tag to wrap around responses that have been previously chosen.")]
			public EmTag emTagForOldResponses;

			// Token: 0x04000EC2 RID: 3778
			[Tooltip("The [em#] tag to wrap around invalid responses. These responses are only shown if Include Invalid Entries is ticked.")]
			public EmTag emTagForInvalidResponses;

			// Token: 0x04000EC3 RID: 3779
			public string[] qteButtons = new string[] { "Fire1", "Fire2" };

			// Token: 0x04000EC4 RID: 3780
			[Tooltip("Cancels subtitle sequences.")]
			public InputTrigger cancel = new InputTrigger(KeyCode.Escape);

			// Token: 0x04000EC5 RID: 3781
			[Tooltip("Cancels the active conversation.")]
			public InputTrigger cancelConversation = new InputTrigger(KeyCode.Escape);
		}

		// Token: 0x0200024F RID: 591
		[Serializable]
		public class BarkSettings
		{
			// Token: 0x04000EC6 RID: 3782
			[Tooltip("Allow barks to play during conversations.")]
			public bool allowBarksDuringConversations = true;

			// Token: 0x04000EC7 RID: 3783
			[Tooltip("Show barks for this many characters per second. If zero, use Subtitle Settings > Subtitle Chars Per Second.")]
			public float barkCharsPerSecond;

			// Token: 0x04000EC8 RID: 3784
			[Tooltip("Show barks  for at least this many seconds. If zero, use Subtitle Settings > Min Subtitle Seconds.")]
			public float minBarkSeconds;
		}

		// Token: 0x02000250 RID: 592
		[Serializable]
		public class AlertSettings
		{
			// Token: 0x04000EC9 RID: 3785
			[Tooltip("Allow the dialogue UI to show alerts during conversations.")]
			public bool allowAlertsDuringConversations;

			// Token: 0x04000ECA RID: 3786
			[Tooltip("If nonzero, check Variable['Alert'] at this frequency to show alert messages.")]
			public float alertCheckFrequency;

			// Token: 0x04000ECB RID: 3787
			[Tooltip("Show alerts for this many characters per second. If zero, use Subtitle Settings > Subtitle Chars Per Second.")]
			public float alertCharsPerSecond;

			// Token: 0x04000ECC RID: 3788
			[Tooltip("Show alerts for at least this many seconds. If zero, use Subtitle Settings > Min Subtitle Seconds.")]
			public float minAlertSeconds;
		}
	}
}
