using System;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000011 RID: 17
	[Serializable]
	public class ShowAlertBehaviour : PlayableBehaviour
	{
		// Token: 0x04000018 RID: 24
		[Tooltip("Show this message using the Dialogue System's alert panel.")]
		public string message;

		// Token: 0x04000019 RID: 25
		[Tooltip("Show alert for duration based on text length, not duration of playable clip.")]
		public bool useTextLengthForDuration;
	}
}
