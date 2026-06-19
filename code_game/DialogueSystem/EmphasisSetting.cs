using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001F RID: 31
	[Serializable]
	public class EmphasisSetting
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x00008504 File Offset: 0x00006704
		public EmphasisSetting(Color color, bool bold, bool italic, bool underline)
		{
			this.color = color;
			this.bold = bold;
			this.italic = italic;
			this.underline = underline;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00008540 File Offset: 0x00006740
		public EmphasisSetting(string colorCode, string styleCode)
		{
			this.color = Tools.WebColor(colorCode);
			this.bold = !string.IsNullOrEmpty(styleCode) && styleCode.Length > 0 && styleCode[0] == 'b';
			this.italic = !string.IsNullOrEmpty(styleCode) && styleCode.Length > 1 && styleCode[1] == 'i';
			this.underline = !string.IsNullOrEmpty(styleCode) && styleCode.Length > 2 && styleCode[2] == 'u';
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x000085EC File Offset: 0x000067EC
		public bool IsEmpty
		{
			get
			{
				return this.color == Color.black && !this.bold && !this.italic && !this.underline;
			}
		}

		// Token: 0x040000B8 RID: 184
		public Color color = Color.black;

		// Token: 0x040000B9 RID: 185
		public bool bold;

		// Token: 0x040000BA RID: 186
		public bool italic;

		// Token: 0x040000BB RID: 187
		public bool underline;
	}
}
