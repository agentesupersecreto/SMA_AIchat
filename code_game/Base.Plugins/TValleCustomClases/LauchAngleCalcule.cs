using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200006F RID: 111
	public static class LauchAngleCalcule
	{
		// Token: 0x06000358 RID: 856 RVA: 0x0000E740 File Offset: 0x0000C940
		public static bool IsDirectLaunchPosible(Transform sight, Vector3 targetPosition, out Vector3 localLaunchDirection, out ProyectilLaunchCalculeResult resultEmulated)
		{
			resultEmulated = default(ProyectilLaunchCalculeResult);
			Vector3 vector = targetPosition - sight.position;
			localLaunchDirection = sight.InverseTransformDirection(vector);
			resultEmulated.altitude = localLaunchDirection.y;
			resultEmulated.initialVelocity = float.PositiveInfinity;
			resultEmulated.launchAngle = Mathf.Atan2(localLaunchDirection.y, localLaunchDirection.z) * 57.29578f;
			resultEmulated.range = ProyectilLaunchCalcule.Range(vector);
			return true;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
		public static bool IsParabolicLaunchPosible(Transform sight, Vector3 targetPosition, ProyectilLaunchMode mode, float initialVelocity, out Vector3 localLaunchDirection, out ProyectilLaunchCalculeResult proyectilLaunchCalculeResult)
		{
			localLaunchDirection = default(Vector3);
			proyectilLaunchCalculeResult = default(ProyectilLaunchCalculeResult);
			if (initialVelocity <= 0f)
			{
				return false;
			}
			Vector3 vector = targetPosition - sight.position;
			if (ProyectilLaunchCalcule.Calculate(initialVelocity, vector, mode, out proyectilLaunchCalculeResult))
			{
				Vector3 vector2 = LauchAngleCalcule.CalculeLaunchDir(vector, proyectilLaunchCalculeResult.launchAngle);
				localLaunchDirection = sight.InverseTransformDirection(vector2);
				return true;
			}
			return false;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000E810 File Offset: 0x0000CA10
		public static bool IsDirectBallisticLaunchPosible(Transform sight, Rigidbody target, Transform targetTransform, Rigidbody launcher, float initialVelocity, out Vector3 worldTargetFuturePosition, out Vector3 localLaunchDirection, out ProyectilLaunchCalculeResult resultEmulated)
		{
			worldTargetFuturePosition = target.position;
			localLaunchDirection = default(Vector3);
			resultEmulated = default(ProyectilLaunchCalculeResult);
			if (initialVelocity <= 0f)
			{
				return false;
			}
			if (targetTransform == null)
			{
				return false;
			}
			Vector3 vector;
			if (!LauchAngleCalcule.IsBallisticsPosibleDirect(target, targetTransform, sight, initialVelocity, out vector, launcher))
			{
				return false;
			}
			Vector3 vector2 = vector - sight.position;
			worldTargetFuturePosition = vector;
			localLaunchDirection = sight.InverseTransformDirection(vector2);
			resultEmulated.altitude = localLaunchDirection.y;
			resultEmulated.initialVelocity = initialVelocity;
			resultEmulated.launchAngle = Mathf.Atan2(localLaunchDirection.y, localLaunchDirection.z) * 57.29578f;
			resultEmulated.range = ProyectilLaunchCalcule.Range(vector2);
			return true;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000E8CC File Offset: 0x0000CACC
		public static bool IsParabolicBallisticLaunchPosible(Transform sight, Rigidbody target, Transform targetTransform, Rigidbody launcher, ProyectilLaunchMode mode, float initialVelocity, out Vector3 worldTargetFuturePosition, out Vector3 localLaunchDirection, out ProyectilLaunchCalculeResult proyectilLaunchCalculeResult)
		{
			worldTargetFuturePosition = target.position;
			localLaunchDirection = default(Vector3);
			proyectilLaunchCalculeResult = default(ProyectilLaunchCalculeResult);
			if (initialVelocity <= 0f)
			{
				return false;
			}
			if (targetTransform == null)
			{
				return false;
			}
			Vector3 vector;
			if (!LauchAngleCalcule.IsBallisticsPosibleParabolic(target, targetTransform, sight, initialVelocity, out vector, launcher, mode))
			{
				return false;
			}
			worldTargetFuturePosition = vector;
			Vector3 vector2 = vector - sight.position;
			if (ProyectilLaunchCalcule.Calculate(initialVelocity, vector2, mode, out proyectilLaunchCalculeResult))
			{
				Vector3 vector3 = LauchAngleCalcule.CalculeLaunchDir(vector2, proyectilLaunchCalculeResult.launchAngle);
				localLaunchDirection = sight.InverseTransformDirection(vector3);
				return true;
			}
			return false;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000E961 File Offset: 0x0000CB61
		public static float GetXAngle(Vector3 LocalTargetDirection)
		{
			LocalTargetDirection.y = 0f;
			return Vector3.Angle(Vector3.forward, LocalTargetDirection) * LauchAngleCalcule.GetHpolarity(LocalTargetDirection);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000E981 File Offset: 0x0000CB81
		public static float GetYAngle(Vector3 LocalTargetDirection)
		{
			LocalTargetDirection.x = 0f;
			return Vector3.Angle(Vector3.forward, LocalTargetDirection) * LauchAngleCalcule.GetVpolarity(LocalTargetDirection);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000E9A1 File Offset: 0x0000CBA1
		private static float GetVpolarity(Vector3 invertDir)
		{
			if (invertDir.y >= 0f)
			{
				return -1f;
			}
			return 1f;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000E9BB File Offset: 0x0000CBBB
		private static float GetHpolarity(Vector3 invertDir)
		{
			if (invertDir.x >= 0f)
			{
				return 1f;
			}
			return -1f;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000E9D8 File Offset: 0x0000CBD8
		public static float GetCurrentSightAngle(Vector3 SightForward)
		{
			Vector3 vector = SightForward;
			vector.y = 0f;
			return Vector3.Angle(vector, SightForward) * (float)((SightForward.y > 0f) ? 1 : (-1));
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000EA10 File Offset: 0x0000CC10
		[Obsolete("if direct launch, the angle is not needed ")]
		private static float GetAngleDirectLaunch(Vector3 TargetDirecction)
		{
			Vector3 vector = TargetDirecction;
			vector.y = 0f;
			return Vector3.Angle(vector, TargetDirecction) * (float)((TargetDirecction.y > 0f) ? 1 : (-1));
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000EA48 File Offset: 0x0000CC48
		private static bool IsBallisticsPosibleDirect(Rigidbody target, Transform targetTransform, Transform sight, float proyectilInitialVelocity, out Vector3 futurePosition, Rigidbody launcher)
		{
			if (proyectilInitialVelocity <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (target == null && launcher == null)
			{
				throw new ArgumentNullException();
			}
			Vector3 position = targetTransform.position;
			futurePosition = position;
			Vector3 vector = target.velocity;
			vector -= launcher.velocity;
			Vector3 vector2 = position - sight.position;
			if (vector.sqrMagnitude < 1f && vector2.sqrMagnitude < 100f)
			{
				futurePosition = position;
				return true;
			}
			return BallisticsCalcule.TryGetFuturePositionDirect(proyectilInitialVelocity, vector2, position, vector, out futurePosition);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000EAE4 File Offset: 0x0000CCE4
		private static bool IsBallisticsPosibleParabolic(Rigidbody target, Transform targetTransform, Transform sight, float proyectilInitialVelocity, out Vector3 futurePosition, Rigidbody launcher, ProyectilLaunchMode mode)
		{
			if (proyectilInitialVelocity <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (target == null && launcher == null)
			{
				throw new ArgumentNullException();
			}
			Vector3 position = targetTransform.position;
			futurePosition = position;
			Vector3 vector = target.velocity;
			vector -= launcher.velocity;
			Vector3 vector2 = position - sight.position;
			if (vector.sqrMagnitude < 1f || vector2.sqrMagnitude < 100f)
			{
				futurePosition = position;
				return true;
			}
			float num;
			return ProyectilLaunchCalcule.Calculate(proyectilInitialVelocity, vector2, mode, out num) && BallisticsCalcule.TryGetFuturePositionParabolic(proyectilInitialVelocity, ProyectilLaunchCalcule.Range(vector2), num, position, vector, out futurePosition);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000EB94 File Offset: 0x0000CD94
		[Obsolete]
		private static bool IsBallisticsPosible(Rigidbody target, Transform targetTransform, Transform sight, float proyectilInitialVelocity, LauchAngleCalcule.Tipo tipo, out Vector3 futurePosition, Rigidbody launcher)
		{
			futurePosition = default(Vector3);
			if (proyectilInitialVelocity <= 0f || target == null)
			{
				return false;
			}
			if (target == null && launcher == null)
			{
				return false;
			}
			Vector3 position = targetTransform.position;
			Vector3 vector = Vector3.zero;
			if (target != null)
			{
				vector = target.velocity;
			}
			if (launcher != null)
			{
				vector -= launcher.velocity;
			}
			Vector3 vector2 = position - sight.position;
			if (vector.sqrMagnitude < 1f && vector2.sqrMagnitude < 100f)
			{
				futurePosition = position;
				return true;
			}
			if (tipo != LauchAngleCalcule.Tipo.direct)
			{
				if (tipo != LauchAngleCalcule.Tipo.parabolic)
				{
					throw new ArgumentOutOfRangeException();
				}
				float currentSightAngle = LauchAngleCalcule.GetCurrentSightAngle(sight.forward);
				if (BallisticsCalcule.TryGetFuturePositionParabolic(proyectilInitialVelocity, ProyectilLaunchCalcule.Range(vector2), currentSightAngle, position, vector, out futurePosition))
				{
					return true;
				}
			}
			else if (BallisticsCalcule.TryGetFuturePositionDirect(proyectilInitialVelocity, vector2, position, vector, out futurePosition))
			{
				return true;
			}
			return false;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000EC7F File Offset: 0x0000CE7F
		private static Vector3 CalculeLaunchDir(Vector3 TargetDirecction, float AngleLaunch)
		{
			return LauchAngleCalcule.getRot(TargetDirecction, AngleLaunch) * Vector3.forward;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000EC94 File Offset: 0x0000CE94
		private static Quaternion getRot(Vector3 TargetDirecction, float AngleLaunch)
		{
			Vector3 vector = TargetDirecction;
			vector.y = 0f;
			Quaternion quaternion = Quaternion.LookRotation(vector);
			Quaternion quaternion2 = Quaternion.AngleAxis(AngleLaunch, -Vector3.right);
			return quaternion * quaternion2;
		}

		// Token: 0x040000BA RID: 186
		private const float minTargetVelocityToBallistics = 1f;

		// Token: 0x040000BB RID: 187
		private const float minTargetDistanceToBallistics = 10f;

		// Token: 0x020001B0 RID: 432
		public enum Tipo
		{
			// Token: 0x04000409 RID: 1033
			direct,
			// Token: 0x0400040A RID: 1034
			parabolic
		}
	}
}
