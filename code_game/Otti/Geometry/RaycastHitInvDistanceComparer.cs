using System;
using System.Collections;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000053 RID: 83
	public class RaycastHitInvDistanceComparer : IComparer
	{
		// Token: 0x06000406 RID: 1030 RVA: 0x00018C94 File Offset: 0x00016E94
		int IComparer.Compare(object rCompare1, object rCompare2)
		{
			RaycastHit raycastHit = (RaycastHit)rCompare2;
			RaycastHit raycastHit2 = (RaycastHit)rCompare1;
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
