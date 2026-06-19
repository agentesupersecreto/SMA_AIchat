using System;
using System.Text;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200025A RID: 602
	public static class EncodingTypeTools
	{
		// Token: 0x06001A21 RID: 6689 RVA: 0x0002C434 File Offset: 0x0002A634
		public static Encoding GetEncoding(EncodingType encodingType)
		{
			switch (encodingType)
			{
			case EncodingType.ASCII:
				return Encoding.UTF8;
			case EncodingType.Unicode:
				return Encoding.Unicode;
			case EncodingType.UTF7:
				return Encoding.Unicode;
			case EncodingType.UTF8:
				return Encoding.UTF8;
			case EncodingType.UTF32:
				return Encoding.Unicode;
			case EncodingType.ISO_8859_1:
				return Encoding.GetEncoding("iso-8859-1");
			default:
				return Encoding.UTF8;
			}
		}
	}
}
