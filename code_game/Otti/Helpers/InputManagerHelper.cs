using System;
using UnityEngine;

namespace com.ootii.Helpers
{
	// Token: 0x02000031 RID: 49
	public class InputManagerHelper
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0000BDE4 File Offset: 0x00009FE4
		public static void ConvertToRadialInput(ref float rInputX, ref float rInputY, ref float rMagnitude, float rMultiplier = 1f)
		{
			if (rMagnitude > 1f)
			{
				rMagnitude = 1f;
			}
			float num = Mathf.Atan2(rInputX, rInputY) - 1.5708f;
			rInputX = rMagnitude * Mathf.Cos(num);
			rInputY = rMagnitude * -Mathf.Sin(num);
			rMagnitude = Mathf.Sqrt(rInputX * rInputX + rInputY * rInputY);
			if (rMultiplier != 1f)
			{
				rInputX *= rMultiplier;
				rInputY *= rMultiplier;
				rMagnitude *= rMultiplier;
			}
		}
	}
}
