using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000051 RID: 81
	public class CalculeAimAngleLimits
	{
		// Token: 0x06000286 RID: 646 RVA: 0x0000CE88 File Offset: 0x0000B088
		public static float LocalVerticalAngle(Vector3 localDirectionToTarget)
		{
			float num = Mathf.Sqrt(localDirectionToTarget.z * localDirectionToTarget.z + localDirectionToTarget.x * localDirectionToTarget.x);
			float num2 = Mathf.Atan2(localDirectionToTarget.y, num) * 57.29578f;
			if (num2 > 90f)
			{
				num2 = 90f - (num2 - 90f);
			}
			else if (num2 < -90f)
			{
				num2 = -90f - (num2 + 90f);
			}
			return num2;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000CEF8 File Offset: 0x0000B0F8
		public static float LocalHorizontalAngle(Vector3 localDirectionToTarget)
		{
			float num = Mathf.Atan2(localDirectionToTarget.x, localDirectionToTarget.z) * 57.29578f;
			if (num < 0f)
			{
				return num * -1f;
			}
			return num;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000CF2E File Offset: 0x0000B12E
		public static float LocalHorizontalAngleRaw(Vector3 localDirectionToTarget)
		{
			return Mathf.Atan2(localDirectionToTarget.x, localDirectionToTarget.z) * 57.29578f;
		}
	}
}
