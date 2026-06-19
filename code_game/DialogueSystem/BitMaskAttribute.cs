using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000254 RID: 596
	public class BitMaskAttribute : PropertyAttribute
	{
		// Token: 0x06001A12 RID: 6674 RVA: 0x0002C250 File Offset: 0x0002A450
		public BitMaskAttribute(Type propType)
		{
			this.propType = propType;
		}

		// Token: 0x04000ED9 RID: 3801
		public Type propType;
	}
}
