using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000229 RID: 553
	[AddComponentMenu("Dialogue System/UI/Miscellaneous/Textless Bark UI")]
	public class TextlessBarkUI : MonoBehaviour, IBarkUI
	{
		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x060018E9 RID: 6377 RVA: 0x000247E4 File Offset: 0x000229E4
		public bool IsPlaying
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x000247E8 File Offset: 0x000229E8
		public void Bark(Subtitle subtitle)
		{
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x000247EC File Offset: 0x000229EC
		public void Hide()
		{
		}
	}
}
