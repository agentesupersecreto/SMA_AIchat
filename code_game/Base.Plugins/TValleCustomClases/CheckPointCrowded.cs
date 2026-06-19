using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200004E RID: 78
	public static class CheckPointCrowded
	{
		// Token: 0x06000278 RID: 632 RVA: 0x0000C968 File Offset: 0x0000AB68
		public static bool Check(Vector3 pointPosition, Rigidbody vehicle, Vector3 checkOffSet, float rayRadius, float rayLength, int hitsToCrowed, float debugtime, bool isdebug)
		{
			Quaternion rotation = vehicle.rotation;
			Vector3 vector;
			if (checkOffSet != Vector3.zero)
			{
				vector = pointPosition + rotation * checkOffSet;
			}
			else
			{
				vector = pointPosition;
			}
			int num = 0;
			if (CheckPointCrowded.ObstacleInPoint(vector, rayRadius, debugtime, isdebug))
			{
				num++;
			}
			Vector3[] array = CheckPointCrowded.GetRaysWorldDirections(rotation);
			bool flag = false;
			for (int i = 0; i < 8; i++)
			{
				if (CheckPointCrowded.ObstacleInRay(new Ray(vector, array[i]), rayRadius, rayLength, debugtime, isdebug))
				{
					num++;
				}
				flag = num >= hitsToCrowed;
				if (flag)
				{
					break;
				}
			}
			return flag;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000C9F8 File Offset: 0x0000ABF8
		private static bool ObstacleInPoint(Vector3 point, float radius, float debugtime, bool isdebug = false)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000CA00 File Offset: 0x0000AC00
		private static bool ObstacleInRay(Ray ray, float radius, float length, float debugtime, bool isdebug = false)
		{
			RaycastHit raycastHit;
			bool flag = Physics.SphereCast(ray, radius, out raycastHit, length, -1, QueryTriggerInteraction.Ignore);
			if (isdebug && flag)
			{
				Debug.DrawLine(ray.origin, raycastHit.point, Color.red, debugtime, false);
			}
			return flag;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000CA3C File Offset: 0x0000AC3C
		private static Vector3[] GetRaysWorldDirections(Quaternion rotation)
		{
			for (int i = 0; i < 8; i++)
			{
				CheckPointCrowded.raysWorldDirections[i] = rotation * CheckPointCrowded.raysLocalDirections[i];
			}
			return CheckPointCrowded.raysWorldDirections;
		}

		// Token: 0x04000089 RID: 137
		private static Vector3[] raysWorldDirections = new Vector3[8];

		// Token: 0x0400008A RID: 138
		private static Vector3[] raysLocalDirections = new Vector3[]
		{
			new Vector3(0f, 0f, 1f),
			-new Vector3(0f, 0f, 1f),
			new Vector3(1f, 0f, 0f),
			-new Vector3(1f, 0f, 0f),
			new Vector3(0.70710677f, 0f, 0.70710677f),
			-new Vector3(0.70710677f, 0f, 0.70710677f),
			new Vector3(-0.70710677f, 0f, 0.70710677f),
			-new Vector3(-0.70710677f, 0f, 0.70710677f)
		};
	}
}
