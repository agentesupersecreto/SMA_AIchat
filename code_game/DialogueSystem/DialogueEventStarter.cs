using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A2 RID: 674
	public class DialogueEventStarter : MonoBehaviour
	{
		// Token: 0x06001C5E RID: 7262 RVA: 0x00034774 File Offset: 0x00032974
		protected void DestroyIfOnce()
		{
			if (this.once)
			{
				Object.Destroy(this);
			}
		}

		// Token: 0x04001003 RID: 4099
		[Tooltip("Only trigger once for this instance of the scene, then destroy this component. NOTE: This is not persistent across scene changes or saved games. It only applies to the current instance of this scene. To make something only happen once for the player's playthrough (including scene changes and saved games), use persistent data components.")]
		public bool once;
	}
}
