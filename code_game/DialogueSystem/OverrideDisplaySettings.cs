using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000230 RID: 560
	[AddComponentMenu("Dialogue System/UI/Override/Override Display Settings")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/override_display_settings.html")]
	public class OverrideDisplaySettings : OverrideUIBase
	{
		// Token: 0x04000DFC RID: 3580
		[Tooltip("Use these display settings for this GameObject.")]
		public DisplaySettings displaySettings;
	}
}
