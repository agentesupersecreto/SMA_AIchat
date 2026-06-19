using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Moddding
{
	// Token: 0x02000030 RID: 48
	[Serializable]
	public class InGameObjectiveText
	{
		// Token: 0x04000047 RID: 71
		[Tooltip("Right now, the game is only compatible with English.")]
		public Language language = Language.en;

		// Token: 0x04000048 RID: 72
		[Tooltip("Ex: 'Take a Phooto of her glutes'")]
		public string desc;

		// Token: 0x04000049 RID: 73
		[Tooltip("Ex: 'press NUM 3 to draw the camera and take a photo of her lower back'")]
		[TextArea]
		public string tips;
	}
}
