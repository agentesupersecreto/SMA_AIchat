using System;
using System.Collections;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000052 RID: 82
	public class RaycastHitDistanceComparer : IComparer
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x00018C4C File Offset: 0x00016E4C
		int IComparer.Compare(object rCompare1, object rCompare2)
		{
			RaycastHit raycastHit = (RaycastHit)rCompare1;
			RaycastHit raycastHit2 = (RaycastHit)rCompare2;
			if (raycastHit.distance > raycastHit2.distance)
			{
				return 1;
			}
			if (raycastHit.distance < raycastHit2.distance)
			{
				return -1;
			}
			return 0;
		}
	}
}
