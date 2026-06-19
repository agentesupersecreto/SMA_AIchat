using System;
using UnityEngine;

namespace com.ootii.Helpers
{
	// Token: 0x02000034 RID: 52
	public class ObjectHelper
	{
		// Token: 0x06000284 RID: 644 RVA: 0x0000C434 File Offset: 0x0000A634
		public static float IsObjectVisible(Vector3 rPosition, Vector3 rForward, float rFOV, float rDistance, Transform rTarget)
		{
			Vector3 position = rTarget.transform.position;
			if (Mathf.Abs(NumberHelper.GetHorizontalAngle(rForward, position - rPosition)) < rFOV * 0.5f)
			{
				float num = Vector3.Distance(rPosition, position);
				if (num <= rDistance)
				{
					return num;
				}
			}
			return 0f;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000C47C File Offset: 0x0000A67C
		public static GameObject IsObjectVisible(Vector3 rPosition, Vector3 rForward, float rFOV, float rDistance, LayerMask rTargetLayerMask, bool rClosest)
		{
			GameObject gameObject = null;
			Collider[] array = Physics.OverlapSphere(rPosition, rDistance, rTargetLayerMask);
			if (array != null)
			{
				if (!rClosest)
				{
					return array[0].gameObject;
				}
				float num = float.MaxValue;
				for (int i = 0; i < array.Length; i++)
				{
					GameObject gameObject2 = array[i].gameObject;
					if (gameObject2 != null)
					{
						float num2 = ObjectHelper.IsObjectVisible(rPosition, rForward, rFOV, rDistance, gameObject2.transform);
						if (num2 > 0f && num2 < num)
						{
							num = num2;
							gameObject = gameObject2;
						}
					}
				}
			}
			return gameObject;
		}
	}
}
