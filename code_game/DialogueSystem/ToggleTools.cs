using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200025F RID: 607
	public static class ToggleTools
	{
		// Token: 0x06001A28 RID: 6696 RVA: 0x0002C500 File Offset: 0x0002A700
		public static bool GetNewValue(bool oldValue, Toggle state)
		{
			switch (state)
			{
			case Toggle.True:
				return true;
			case Toggle.False:
				return false;
			}
			return !oldValue;
		}
	}
}
