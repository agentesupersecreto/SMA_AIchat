using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200006E RID: 110
	public static class BallisticsCalcule
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000350 RID: 848 RVA: 0x0000E574 File Offset: 0x0000C774
		public static float MaxTargetVelocity
		{
			get
			{
				return Mathf.Sqrt(90000f);
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000E580 File Offset: 0x0000C780
		private static float abs(float v)
		{
			if (v < 0f)
			{
				return v * -1f;
			}
			return v;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000E593 File Offset: 0x0000C793
		private static float timeOfFlightDirect(float velocity, float distance)
		{
			return distance / velocity;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000E598 File Offset: 0x0000C798
		private static float timeOfFlight(float velocity, float range, float angle)
		{
			float num = Mathf.Cos(angle * 0.017453292f);
			float num2 = velocity * num;
			return range / num2;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000E5BC File Offset: 0x0000C7BC
		private static Vector3 FuturePositionDirect(float velocity, float Distance, Vector3 position, Vector3 targetVelocity)
		{
			Vector3 vector = BallisticsCalcule.timeOfFlightDirect(velocity, Distance) * targetVelocity;
			return position + vector;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		private static Vector3 FuturePositionParabolic(float velocity, float range, float angle, Vector3 position, Vector3 targetVelocity)
		{
			angle = BallisticsCalcule.abs(angle);
			if (angle >= 90f)
			{
				return position;
			}
			float num = BallisticsCalcule.timeOfFlight(velocity, range, angle);
			if (num > 60f)
			{
				return position;
			}
			Vector3 vector = num * targetVelocity;
			return position + vector;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000E624 File Offset: 0x0000C824
		public static bool TryGetFuturePositionDirect(float velocity, Vector3 targetDirection, Vector3 currentTargetposition, Vector3 targetVelocity, out Vector3 futurePosition)
		{
			if (90000f < targetVelocity.sqrMagnitude || velocity <= 0f)
			{
				futurePosition = Vector3.zero;
				return false;
			}
			futurePosition = BallisticsCalcule.FuturePositionDirect(velocity, targetDirection.magnitude, currentTargetposition, targetVelocity);
			if (float.IsNaN(futurePosition.x) || float.IsNaN(futurePosition.y) || float.IsNaN(futurePosition.z) || float.IsPositiveInfinity(targetVelocity.sqrMagnitude))
			{
				futurePosition = Vector3.zero;
				return false;
			}
			return true;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
		public static bool TryGetFuturePositionParabolic(float velocity, float range, float angleLaunch, Vector3 currentTargetposition, Vector3 targetVelocity, out Vector3 futurePosition)
		{
			if (90000f < targetVelocity.sqrMagnitude || velocity <= 0f)
			{
				futurePosition = Vector3.zero;
				return false;
			}
			futurePosition = BallisticsCalcule.FuturePositionParabolic(velocity, range, angleLaunch, currentTargetposition, targetVelocity);
			if (float.IsNaN(futurePosition.x) || float.IsNaN(futurePosition.y) || float.IsNaN(futurePosition.z) || float.IsPositiveInfinity(targetVelocity.sqrMagnitude))
			{
				futurePosition = Vector3.zero;
				return false;
			}
			return true;
		}

		// Token: 0x040000B8 RID: 184
		private const float maxSqrTargetVelocity = 90000f;

		// Token: 0x040000B9 RID: 185
		private const float maxTimeOfFlight = 60f;
	}
}
