using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000025 RID: 37
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Unity UI Color Text")]
	public class UnityUIColorText : MonoBehaviour
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000578C File Offset: 0x0000398C
		private void Awake()
		{
			if (this.text == null)
			{
				this.text = base.GetComponentInChildren<Text>();
			}
			if (this.text != null)
			{
				this.originalColor = this.text.color;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000057C7 File Offset: 0x000039C7
		public void ApplyColor()
		{
			if (this.text != null)
			{
				this.originalColor = this.text.color;
				this.text.color = this.color;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000057F9 File Offset: 0x000039F9
		public void UndoColor()
		{
			if (this.text != null)
			{
				this.text.color = this.originalColor;
			}
		}

		// Token: 0x0400009C RID: 156
		public Color color;

		// Token: 0x0400009D RID: 157
		public Text text;

		// Token: 0x0400009E RID: 158
		private Color originalColor;
	}
}
