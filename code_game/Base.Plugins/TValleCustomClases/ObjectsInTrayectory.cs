using System;
using System.Collections.Generic;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000070 RID: 112
	public static class ObjectsInTrayectory
	{
		// Token: 0x06000367 RID: 871 RVA: 0x0000ECCC File Offset: 0x0000CECC
		public static void FindAllByParabolic<T>(ObjectsInTrayectory.TryFind<T> finder, Vector3 launchPosition, Vector3 launchDirection, float v0, float angle, float y0, float g, List<T> result, HashSet<Collider> ignoring, int precision = 5, float findRange = float.PositiveInfinity, bool debugDraw = false, float debugDrawDuration = 1f)
		{
			if (result.Count > 0)
			{
				result.Clear();
			}
			ObjectsInTrayectory.setPoints(launchPosition, launchDirection, v0, angle, y0, g, precision, findRange, debugDraw, debugDrawDuration);
			if (ObjectsInTrayectory.points.Count == 0)
			{
				return;
			}
			for (int i = 1; i < ObjectsInTrayectory.points.Count; i++)
			{
				Vector3 vector = ObjectsInTrayectory.points[i - 1];
				Vector3 vector2 = ObjectsInTrayectory.points[i] - vector;
				int num = Physics.RaycastNonAlloc(vector, vector2, ObjectsInTrayectory.hitResults, vector2.magnitude, -1, QueryTriggerInteraction.Ignore);
				ObjectsInTrayectory.findItemsByDelegate<T>(finder, num, ObjectsInTrayectory.hitResults, result, ignoring);
				Array.Clear(ObjectsInTrayectory.hitResults, 0, num);
			}
			ObjectsInTrayectory.points.Clear();
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000ED84 File Offset: 0x0000CF84
		public static void FindAllByDirect<T>(ObjectsInTrayectory.TryFind<T> finder, Vector3 launchPosition, Vector3 targetPosition, List<T> result, HashSet<Collider> ignoring, bool debugDraw = false, float debugDrawDuration = 1f)
		{
			if (result.Count > 0)
			{
				result.Clear();
			}
			ObjectsInTrayectory.points.Add(launchPosition);
			ObjectsInTrayectory.points.Add(targetPosition);
			for (int i = 1; i < ObjectsInTrayectory.points.Count; i++)
			{
				Vector3 vector = ObjectsInTrayectory.points[i - 1];
				Vector3 vector2 = ObjectsInTrayectory.points[i] - vector;
				int num = Physics.RaycastNonAlloc(vector, vector2, ObjectsInTrayectory.hitResults, vector2.magnitude, -1, QueryTriggerInteraction.Ignore);
				ObjectsInTrayectory.findItemsByDelegate<T>(finder, num, ObjectsInTrayectory.hitResults, result, ignoring);
				Array.Clear(ObjectsInTrayectory.hitResults, 0, num);
			}
			ObjectsInTrayectory.points.Clear();
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000EE2C File Offset: 0x0000D02C
		public static void FindCollidersParabolic(Vector3 launchPosition, Vector3 launchDirection, float v0, float angle, float y0, float g, List<Collider> result, int precision = 5, float findRange = float.PositiveInfinity, bool debugDraw = false, float debugDrawDuration = 1f)
		{
			if (result.Count > 0)
			{
				result.Clear();
			}
			ObjectsInTrayectory.setPoints(launchPosition, launchDirection, v0, angle, y0, g, precision, findRange, debugDraw, debugDrawDuration);
			if (ObjectsInTrayectory.points.Count == 0)
			{
				return;
			}
			for (int i = 1; i < ObjectsInTrayectory.points.Count; i++)
			{
				Vector3 vector = ObjectsInTrayectory.points[i - 1];
				Vector3 vector2 = ObjectsInTrayectory.points[i] - vector;
				int num = Physics.RaycastNonAlloc(vector, vector2, ObjectsInTrayectory.hitResults, vector2.magnitude, -1, QueryTriggerInteraction.Ignore);
				ObjectsInTrayectory.addColliders(num, ObjectsInTrayectory.hitResults, result);
				Array.Clear(ObjectsInTrayectory.hitResults, 0, num);
			}
			ObjectsInTrayectory.points.Clear();
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
		private static void setPoints(Vector3 launchPosition, Vector3 launchDirection, float v0, float angle, float y0, float g, int precision, float findRange, bool debugDraw, float debugDrawDuration)
		{
			if (ObjectsInTrayectory.points.Count > 0)
			{
				ObjectsInTrayectory.points.Clear();
			}
			if (precision < 2)
			{
				return;
			}
			if (findRange < 0f)
			{
				return;
			}
			y0 += 0.25f;
			float num = ProyectilTrayectory.MaxHorizontalDistanceTraveled(v0, angle, g, y0);
			if (num <= 0f)
			{
				return;
			}
			findRange = ((findRange > num) ? num : findRange);
			Vector3 vector = launchDirection;
			vector.y = 0f;
			vector.Normalize();
			ObjectsInTrayectory.points.Add(launchPosition);
			for (int i = 0; i < precision; i++)
			{
				float num2 = findRange / (float)precision * (float)(i + 1);
				float num3 = ProyectilTrayectory.HeightAtX(num2, v0, angle, g, 0f);
				Vector3 vector2 = vector * num2;
				vector2.y += num3;
				vector2 += launchPosition;
				ObjectsInTrayectory.points.Add(vector2);
			}
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000EFB8 File Offset: 0x0000D1B8
		private static void addColliders(int length, RaycastHit[] a, List<Collider> b)
		{
			for (int i = 0; i < length; i++)
			{
				b.Add(a[i].collider);
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000EFE4 File Offset: 0x0000D1E4
		private static void findItemsByDelegate<T>(ObjectsInTrayectory.TryFind<T> finder, int length, RaycastHit[] a, List<T> b, HashSet<Collider> ignoring)
		{
			for (int i = 0; i < length; i++)
			{
				RaycastHit raycastHit = a[i];
				Collider collider = raycastHit.collider;
				T t;
				if (!ignoring.Contains(collider) && finder(raycastHit, out t))
				{
					b.Add(t);
				}
			}
		}

		// Token: 0x040000BC RID: 188
		private static List<Vector3> points = new List<Vector3>();

		// Token: 0x040000BD RID: 189
		private static RaycastHit[] hitResults = new RaycastHit[100];

		// Token: 0x020001B1 RID: 433
		// (Invoke) Token: 0x06000C15 RID: 3093
		public delegate bool TryFind<T>(RaycastHit hit, out T itemFound);
	}
}
