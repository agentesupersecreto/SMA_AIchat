using System;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x02000206 RID: 518
	[XmlRoot("ChatMapperProject")]
	public class ChatMapperProject
	{
		// Token: 0x060017CD RID: 6093 RVA: 0x0001E3E8 File Offset: 0x0001C5E8
		public DialogueDatabase ToDialogueDatabase()
		{
			return ChatMapperToDialogueDatabase.ConvertToDialogueDatabase(this);
		}

		// Token: 0x04000D45 RID: 3397
		[XmlAttribute("Title")]
		public string Title;

		// Token: 0x04000D46 RID: 3398
		[XmlAttribute("Version")]
		public string Version;

		// Token: 0x04000D47 RID: 3399
		[XmlAttribute("Author")]
		public string Author;

		// Token: 0x04000D48 RID: 3400
		[XmlAttribute("EmphasisColor1Label")]
		public string EmphasisColor1Label = string.Empty;

		// Token: 0x04000D49 RID: 3401
		[XmlAttribute("EmphasisColor1")]
		public string EmphasisColor1;

		// Token: 0x04000D4A RID: 3402
		[XmlAttribute("EmphasisStyle1")]
		public string EmphasisStyle1;

		// Token: 0x04000D4B RID: 3403
		[XmlAttribute("EmphasisColor2Label")]
		public string EmphasisColor2Label = string.Empty;

		// Token: 0x04000D4C RID: 3404
		[XmlAttribute("EmphasisColor2")]
		public string EmphasisColor2;

		// Token: 0x04000D4D RID: 3405
		[XmlAttribute("EmphasisStyle2")]
		public string EmphasisStyle2;

		// Token: 0x04000D4E RID: 3406
		[XmlAttribute("EmphasisColor3Label")]
		public string EmphasisColor3Label = string.Empty;

		// Token: 0x04000D4F RID: 3407
		[XmlAttribute("EmphasisColor3")]
		public string EmphasisColor3;

		// Token: 0x04000D50 RID: 3408
		[XmlAttribute("EmphasisStyle3")]
		public string EmphasisStyle3;

		// Token: 0x04000D51 RID: 3409
		[XmlAttribute("EmphasisColor4Label")]
		public string EmphasisColor4Label = string.Empty;

		// Token: 0x04000D52 RID: 3410
		[XmlAttribute("EmphasisColor4")]
		public string EmphasisColor4;

		// Token: 0x04000D53 RID: 3411
		[XmlAttribute("EmphasisStyle4")]
		public string EmphasisStyle4;

		// Token: 0x04000D54 RID: 3412
		public string Description;

		// Token: 0x04000D55 RID: 3413
		public string UserScript;

		// Token: 0x04000D56 RID: 3414
		public Assets Assets;
	}
}
