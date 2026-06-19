using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

// Token: 0x0200000A RID: 10
public static class DebugExtension
{
	// Token: 0x0600000B RID: 11 RVA: 0x000021A6 File Offset: 0x000003A6
	[Conditional("UNITY_EDITOR")]
	public static void DebugWorldRotataion(Vector3 position, Quaternion worldRotation, float distance, float duration = 0f, bool depthTest = true, float colorMod = 1f)
	{
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000021A8 File Offset: 0x000003A8
	[Conditional("UNITY_EDITOR")]
	public static void DebugWorldRotataionSimple(Vector3 position, Quaternion worldRotation, float distance, float duration = 0f, bool depthTest = true, float colorMod = 1f)
	{
		Debug.DrawRay(position, worldRotation * Vector3.forward * distance, Color.blue * colorMod, duration, depthTest);
		Debug.DrawRay(position, worldRotation * Vector3.up * distance, Color.green * colorMod, duration, depthTest);
		Debug.DrawRay(position, worldRotation * Vector3.right * distance, Color.red * colorMod, duration, depthTest);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002228 File Offset: 0x00000428
	[Conditional("UNITY_EDITOR")]
	public static void DebugWorldPose(Matrix4x4 Pose, float colorMod, float largo, float duracion, bool depthTest)
	{
		Vector3 vector = DebugExtension.Posicion(ref Pose);
		Quaternion quaternion = DebugExtension.Rotacion(ref Pose);
		Vector3 vector2 = DebugExtension.Scale(ref Pose);
		Debug.DrawRay(vector, quaternion * Vector3.forward * largo * vector2.z, Color.blue * colorMod, duracion, depthTest);
		Debug.DrawRay(vector, quaternion * Vector3.up * largo * vector2.y, Color.green * colorMod, duracion, depthTest);
		Debug.DrawRay(vector, quaternion * Vector3.right * largo * vector2.x, Color.red * colorMod, duracion, depthTest);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000022DC File Offset: 0x000004DC
	public static void DebugLocalPose(Transform parent, Matrix4x4 localPose, float colorMod, float largo, float duracion, bool depthTest)
	{
		if (!Application.isEditor)
		{
			Debug.LogError("Tratando de DrawRay en build.");
		}
		Vector3 vector = DebugExtension.Posicion(ref localPose);
		Quaternion quaternion = DebugExtension.Rotacion(ref localPose);
		Vector3 vector2 = DebugExtension.Scale(ref localPose);
		Debug.DrawRay(parent.TransformPoint(vector), parent.TransformDirection(quaternion * Vector3.forward) * largo * vector2.z, Color.blue * colorMod, duracion, depthTest);
		Debug.DrawRay(parent.TransformPoint(vector), parent.TransformDirection(quaternion * Vector3.up) * largo * vector2.y, Color.green * colorMod, duracion, depthTest);
		Debug.DrawRay(parent.TransformPoint(vector), parent.TransformDirection(quaternion * Vector3.right) * largo * vector2.x, Color.red * colorMod, duracion, depthTest);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000023C9 File Offset: 0x000005C9
	public static Vector3 Posicion(ref Matrix4x4 matrix)
	{
		return matrix.GetColumn(3);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000023D7 File Offset: 0x000005D7
	public static Quaternion Rotacion(ref Matrix4x4 matrix)
	{
		return Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000023F8 File Offset: 0x000005F8
	public static Vector3 Scale(ref Matrix4x4 m)
	{
		return new Vector3(m.GetColumn(0).magnitude, m.GetColumn(1).magnitude, m.GetColumn(2).magnitude);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002438 File Offset: 0x00000638
	[Conditional("UNITY_EDITOR")]
	public static void DebugPlane(Vector3 position, Vector3 normal, float duration = 0f, bool depthTest = true)
	{
		Vector3 vector;
		if (normal.normalized != Vector3.forward)
		{
			vector = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
		}
		else
		{
			vector = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude;
		}
		Vector3 vector2 = position + vector;
		Vector3 vector3 = position - vector;
		vector = Quaternion.AngleAxis(90f, normal) * vector;
		Vector3 vector4 = position + vector;
		Vector3 vector5 = position - vector;
		Debug.DrawLine(vector2, vector3, Color.green, duration, depthTest);
		Debug.DrawLine(vector4, vector5, Color.green, duration, depthTest);
		Debug.DrawLine(vector2, vector4, Color.green, duration, depthTest);
		Debug.DrawLine(vector4, vector3, Color.green, duration, depthTest);
		Debug.DrawLine(vector3, vector5, Color.green, duration, depthTest);
		Debug.DrawLine(vector5, vector2, Color.green, duration, depthTest);
		Debug.DrawRay(position, normal, Color.red, duration, depthTest);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002534 File Offset: 0x00000734
	[Conditional("UNITY_EDITOR")]
	public static void DebugCube(Vector3 position, Vector3 extents, Quaternion orientation, Color color, float duration = 0f, bool depthTest = true)
	{
		Vector3 vector = position + orientation * extents;
		Vector3 vector2 = position + orientation * new Vector3(-extents.x, extents.y, extents.z);
		Vector3 vector3 = position + orientation * new Vector3(extents.x, -extents.y, extents.z);
		Vector3 vector4 = position + orientation * new Vector3(-extents.x, -extents.y, extents.z);
		Vector3 vector5 = position + orientation * new Vector3(extents.x, extents.y, -extents.z);
		Vector3 vector6 = position + orientation * new Vector3(-extents.x, extents.y, -extents.z);
		Vector3 vector7 = position + orientation * new Vector3(extents.x, -extents.y, -extents.z);
		Vector3 vector8 = position + orientation * new Vector3(-extents.x, -extents.y, -extents.z);
		Debug.DrawLine(vector, vector2, color, duration, depthTest);
		Debug.DrawLine(vector3, vector4, color, duration, depthTest);
		Debug.DrawLine(vector5, vector6, color, duration, depthTest);
		Debug.DrawLine(vector7, vector8, color, duration, depthTest);
		Debug.DrawLine(vector, vector5, color, duration, depthTest);
		Debug.DrawLine(vector2, vector6, color, duration, depthTest);
		Debug.DrawLine(vector3, vector7, color, duration, depthTest);
		Debug.DrawLine(vector4, vector8, color, duration, depthTest);
		Debug.DrawLine(vector, vector3, color, duration, depthTest);
		Debug.DrawLine(vector2, vector4, color, duration, depthTest);
		Debug.DrawLine(vector5, vector7, color, duration, depthTest);
		Debug.DrawLine(vector6, vector8, color, duration, depthTest);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000026F4 File Offset: 0x000008F4
	[Conditional("UNITY_EDITOR")]
	public static void DebugPoint(Vector3 position, Color color, float scale = 1f, float duration = 0f, bool depthTest = true)
	{
		color = ((color == default(Color)) ? Color.white : color);
		Debug.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale, color, duration, depthTest);
		Debug.DrawRay(position + Vector3.right * (scale * 0.5f), -Vector3.right * scale, color, duration, depthTest);
		Debug.DrawRay(position + Vector3.forward * (scale * 0.5f), -Vector3.forward * scale, color, duration, depthTest);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000027AC File Offset: 0x000009AC
	[Conditional("UNITY_EDITOR")]
	public static void DebugPoint(Vector3 position, float scale = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000027B0 File Offset: 0x000009B0
	[Conditional("UNITY_EDITOR")]
	public static void DebugBounds(Bounds bounds, Color color, float duration = 0f, bool depthTest = true)
	{
		Vector3 center = bounds.center;
		float x = bounds.extents.x;
		float y = bounds.extents.y;
		float z = bounds.extents.z;
		Vector3 vector = center + new Vector3(x, y, z);
		Vector3 vector2 = center + new Vector3(x, y, -z);
		Vector3 vector3 = center + new Vector3(-x, y, z);
		Vector3 vector4 = center + new Vector3(-x, y, -z);
		Vector3 vector5 = center + new Vector3(x, -y, z);
		Vector3 vector6 = center + new Vector3(x, -y, -z);
		Vector3 vector7 = center + new Vector3(-x, -y, z);
		Vector3 vector8 = center + new Vector3(-x, -y, -z);
		Debug.DrawLine(vector, vector3, color, duration, depthTest);
		Debug.DrawLine(vector, vector2, color, duration, depthTest);
		Debug.DrawLine(vector3, vector4, color, duration, depthTest);
		Debug.DrawLine(vector2, vector4, color, duration, depthTest);
		Debug.DrawLine(vector, vector5, color, duration, depthTest);
		Debug.DrawLine(vector2, vector6, color, duration, depthTest);
		Debug.DrawLine(vector3, vector7, color, duration, depthTest);
		Debug.DrawLine(vector4, vector8, color, duration, depthTest);
		Debug.DrawLine(vector5, vector7, color, duration, depthTest);
		Debug.DrawLine(vector5, vector6, color, duration, depthTest);
		Debug.DrawLine(vector7, vector8, color, duration, depthTest);
		Debug.DrawLine(vector8, vector6, color, duration, depthTest);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002902 File Offset: 0x00000B02
	[Conditional("UNITY_EDITOR")]
	public static void DebugBounds(Bounds bounds, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002904 File Offset: 0x00000B04
	[Conditional("UNITY_EDITOR")]
	public static void DebugLocalCube(Transform transform, Vector3 size, Color color, Vector3 center = default(Vector3), float duration = 0f, bool depthTest = true)
	{
		Vector3 vector = transform.TransformPoint(center + -size * 0.5f);
		Vector3 vector2 = transform.TransformPoint(center + new Vector3(size.x, -size.y, -size.z) * 0.5f);
		Vector3 vector3 = transform.TransformPoint(center + new Vector3(size.x, -size.y, size.z) * 0.5f);
		Vector3 vector4 = transform.TransformPoint(center + new Vector3(-size.x, -size.y, size.z) * 0.5f);
		Vector3 vector5 = transform.TransformPoint(center + new Vector3(-size.x, size.y, -size.z) * 0.5f);
		Vector3 vector6 = transform.TransformPoint(center + new Vector3(size.x, size.y, -size.z) * 0.5f);
		Vector3 vector7 = transform.TransformPoint(center + size * 0.5f);
		Vector3 vector8 = transform.TransformPoint(center + new Vector3(-size.x, size.y, size.z) * 0.5f);
		Debug.DrawLine(vector, vector2, color, duration, depthTest);
		Debug.DrawLine(vector2, vector3, color, duration, depthTest);
		Debug.DrawLine(vector3, vector4, color, duration, depthTest);
		Debug.DrawLine(vector4, vector, color, duration, depthTest);
		Debug.DrawLine(vector5, vector6, color, duration, depthTest);
		Debug.DrawLine(vector6, vector7, color, duration, depthTest);
		Debug.DrawLine(vector7, vector8, color, duration, depthTest);
		Debug.DrawLine(vector8, vector5, color, duration, depthTest);
		Debug.DrawLine(vector, vector5, color, duration, depthTest);
		Debug.DrawLine(vector2, vector6, color, duration, depthTest);
		Debug.DrawLine(vector3, vector7, color, duration, depthTest);
		Debug.DrawLine(vector4, vector8, color, duration, depthTest);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002B03 File Offset: 0x00000D03
	[Conditional("UNITY_EDITOR")]
	public static void DebugLocalCube(Transform transform, Vector3 size, Vector3 center = default(Vector3), float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002B08 File Offset: 0x00000D08
	[Conditional("UNITY_EDITOR")]
	public static void DebugLocalCube(Matrix4x4 space, Vector3 size, Color color, Vector3 center = default(Vector3), float duration = 0f, bool depthTest = true)
	{
		color = ((color == default(Color)) ? Color.white : color);
		Vector3 vector = space.MultiplyPoint3x4(center + -size * 0.5f);
		Vector3 vector2 = space.MultiplyPoint3x4(center + new Vector3(size.x, -size.y, -size.z) * 0.5f);
		Vector3 vector3 = space.MultiplyPoint3x4(center + new Vector3(size.x, -size.y, size.z) * 0.5f);
		Vector3 vector4 = space.MultiplyPoint3x4(center + new Vector3(-size.x, -size.y, size.z) * 0.5f);
		Vector3 vector5 = space.MultiplyPoint3x4(center + new Vector3(-size.x, size.y, -size.z) * 0.5f);
		Vector3 vector6 = space.MultiplyPoint3x4(center + new Vector3(size.x, size.y, -size.z) * 0.5f);
		Vector3 vector7 = space.MultiplyPoint3x4(center + size * 0.5f);
		Vector3 vector8 = space.MultiplyPoint3x4(center + new Vector3(-size.x, size.y, size.z) * 0.5f);
		Debug.DrawLine(vector, vector2, color, duration, depthTest);
		Debug.DrawLine(vector2, vector3, color, duration, depthTest);
		Debug.DrawLine(vector3, vector4, color, duration, depthTest);
		Debug.DrawLine(vector4, vector, color, duration, depthTest);
		Debug.DrawLine(vector5, vector6, color, duration, depthTest);
		Debug.DrawLine(vector6, vector7, color, duration, depthTest);
		Debug.DrawLine(vector7, vector8, color, duration, depthTest);
		Debug.DrawLine(vector8, vector5, color, duration, depthTest);
		Debug.DrawLine(vector, vector5, color, duration, depthTest);
		Debug.DrawLine(vector2, vector6, color, duration, depthTest);
		Debug.DrawLine(vector3, vector7, color, duration, depthTest);
		Debug.DrawLine(vector4, vector8, color, duration, depthTest);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002D2B File Offset: 0x00000F2B
	[Conditional("UNITY_EDITOR")]
	public static void DebugLocalCube(Matrix4x4 space, Vector3 size, Vector3 center = default(Vector3), float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002D30 File Offset: 0x00000F30
	[Conditional("UNITY_EDITOR")]
	public static void DebugCircle(Vector3 position, Vector3 up, Color color, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
		Vector3 vector = up.normalized * radius;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
		Matrix4x4 matrix4x = default(Matrix4x4);
		matrix4x[0] = vector3.x;
		matrix4x[1] = vector3.y;
		matrix4x[2] = vector3.z;
		matrix4x[4] = vector.x;
		matrix4x[5] = vector.y;
		matrix4x[6] = vector.z;
		matrix4x[8] = vector2.x;
		matrix4x[9] = vector2.y;
		matrix4x[10] = vector2.z;
		Vector3 vector4 = position + matrix4x.MultiplyPoint3x4(new Vector3(Mathf.Cos(0f), 0f, Mathf.Sin(0f)));
		Vector3 vector5 = Vector3.zero;
		color = ((color == default(Color)) ? Color.white : color);
		for (int i = 0; i < 91; i++)
		{
			vector5.x = Mathf.Cos((float)(i * 4) * 0.017453292f);
			vector5.z = Mathf.Sin((float)(i * 4) * 0.017453292f);
			vector5.y = 0f;
			vector5 = position + matrix4x.MultiplyPoint3x4(vector5);
			Debug.DrawLine(vector4, vector5, color, duration, depthTest);
			vector4 = vector5;
		}
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002EBA File Offset: 0x000010BA
	[Conditional("UNITY_EDITOR")]
	public static void DebugCircle(Vector3 position, Color color, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002EBC File Offset: 0x000010BC
	[Conditional("UNITY_EDITOR")]
	public static void DebugCircle(Vector3 position, Vector3 up, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002EBE File Offset: 0x000010BE
	[Conditional("UNITY_EDITOR")]
	public static void DebugCircle(Vector3 position, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00002EC0 File Offset: 0x000010C0
	[Conditional("UNITY_EDITOR")]
	public static void DebugWireSphere(Vector3 position, Color color, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
		float num = 10f;
		Vector3 vector = new Vector3(position.x, position.y + radius * Mathf.Sin(0f), position.z + radius * Mathf.Cos(0f));
		Vector3 vector2 = new Vector3(position.x + radius * Mathf.Cos(0f), position.y, position.z + radius * Mathf.Sin(0f));
		Vector3 vector3 = new Vector3(position.x + radius * Mathf.Cos(0f), position.y + radius * Mathf.Sin(0f), position.z);
		for (int i = 1; i < 37; i++)
		{
			Vector3 vector4 = new Vector3(position.x, position.y + radius * Mathf.Sin(num * (float)i * 0.017453292f), position.z + radius * Mathf.Cos(num * (float)i * 0.017453292f));
			Vector3 vector5 = new Vector3(position.x + radius * Mathf.Cos(num * (float)i * 0.017453292f), position.y, position.z + radius * Mathf.Sin(num * (float)i * 0.017453292f));
			Vector3 vector6 = new Vector3(position.x + radius * Mathf.Cos(num * (float)i * 0.017453292f), position.y + radius * Mathf.Sin(num * (float)i * 0.017453292f), position.z);
			Debug.DrawLine(vector, vector4, color, duration, depthTest);
			Debug.DrawLine(vector2, vector5, color, duration, depthTest);
			Debug.DrawLine(vector3, vector6, color, duration, depthTest);
			vector = vector4;
			vector2 = vector5;
			vector3 = vector6;
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x0000306D File Offset: 0x0000126D
	[Conditional("UNITY_EDITOR")]
	public static void DebugWireSphere(Vector3 position, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00003070 File Offset: 0x00001270
	[Conditional("UNITY_EDITOR")]
	public static void DebugCylinder(Vector3 start, Vector3 end, Color color, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
		Vector3 vector = (end - start).normalized * radius;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
		Debug.DrawLine(start + vector3, end + vector3, color, duration, depthTest);
		Debug.DrawLine(start - vector3, end - vector3, color, duration, depthTest);
		Debug.DrawLine(start + vector2, end + vector2, color, duration, depthTest);
		Debug.DrawLine(start - vector2, end - vector2, color, duration, depthTest);
		Debug.DrawLine(start - vector3, start + vector3, color, duration, depthTest);
		Debug.DrawLine(start - vector2, start + vector2, color, duration, depthTest);
		Debug.DrawLine(end - vector3, end + vector3, color, duration, depthTest);
		Debug.DrawLine(end - vector2, end + vector2, color, duration, depthTest);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00003179 File Offset: 0x00001379
	[Conditional("UNITY_EDITOR")]
	public static void DebugCylinder(Vector3 start, Vector3 end, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000024 RID: 36 RVA: 0x0000317C File Offset: 0x0000137C
	[Conditional("UNITY_EDITOR")]
	public static void DebugCone(Vector3 position, Vector3 direction, Color color, float angle = 45f, float duration = 0f, bool depthTest = true)
	{
		float magnitude = direction.magnitude;
		Vector3 vector = direction;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * magnitude;
		direction = direction.normalized;
		Vector3 vector4 = Vector3.Slerp(vector, vector2, angle / 90f);
		Plane plane = new Plane(-direction, position + vector);
		Ray ray = new Ray(position, vector4);
		float num;
		plane.Raycast(ray, out num);
		Debug.DrawRay(position, vector4.normalized * num, color);
		Debug.DrawRay(position, Vector3.Slerp(vector, -vector2, angle / 90f).normalized * num, color, duration, depthTest);
		Debug.DrawRay(position, Vector3.Slerp(vector, vector3, angle / 90f).normalized * num, color, duration, depthTest);
		Debug.DrawRay(position, Vector3.Slerp(vector, -vector3, angle / 90f).normalized * num, color, duration, depthTest);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00003299 File Offset: 0x00001499
	[Conditional("UNITY_EDITOR")]
	public static void DebugCone(Vector3 position, Vector3 direction, float angle = 45f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000026 RID: 38 RVA: 0x0000329B File Offset: 0x0000149B
	[Conditional("UNITY_EDITOR")]
	public static void DebugCone(Vector3 position, Color color, float angle = 45f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000329D File Offset: 0x0000149D
	[Conditional("UNITY_EDITOR")]
	public static void DebugCone(Vector3 position, float angle = 45f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x06000028 RID: 40 RVA: 0x0000329F File Offset: 0x0000149F
	[Conditional("UNITY_EDITOR")]
	public static void DebugArrow(Vector3 position, Vector3 direction, Color color, float duration = 0f, bool depthTest = true)
	{
		Debug.DrawRay(position, direction, color, duration, depthTest);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x000032AC File Offset: 0x000014AC
	[Conditional("UNITY_EDITOR")]
	public static void DebugArrow(Vector3 position, Vector3 direction, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000032B0 File Offset: 0x000014B0
	[Conditional("UNITY_EDITOR")]
	public static void DebugCapsule(Vector3 start, Vector3 end, Color color, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
		Vector3 vector = (end - start).normalized * radius;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
		float magnitude = (start - end).magnitude;
		float num = Mathf.Max(0f, magnitude * 0.5f - radius);
		Vector3 vector4 = (end + start) * 0.5f;
		start = vector4 + (start - vector4).normalized * num;
		end = vector4 + (end - vector4).normalized * num;
		Debug.DrawLine(start + vector3, end + vector3, color, duration, depthTest);
		Debug.DrawLine(start - vector3, end - vector3, color, duration, depthTest);
		Debug.DrawLine(start + vector2, end + vector2, color, duration, depthTest);
		Debug.DrawLine(start - vector2, end - vector2, color, duration, depthTest);
		for (int i = 1; i < 26; i++)
		{
			Debug.DrawLine(Vector3.Slerp(vector3, -vector, (float)i / 25f) + start, Vector3.Slerp(vector3, -vector, (float)(i - 1) / 25f) + start, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(-vector3, -vector, (float)i / 25f) + start, Vector3.Slerp(-vector3, -vector, (float)(i - 1) / 25f) + start, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(vector2, -vector, (float)i / 25f) + start, Vector3.Slerp(vector2, -vector, (float)(i - 1) / 25f) + start, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(-vector2, -vector, (float)i / 25f) + start, Vector3.Slerp(-vector2, -vector, (float)(i - 1) / 25f) + start, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(vector3, vector, (float)i / 25f) + end, Vector3.Slerp(vector3, vector, (float)(i - 1) / 25f) + end, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(-vector3, vector, (float)i / 25f) + end, Vector3.Slerp(-vector3, vector, (float)(i - 1) / 25f) + end, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(vector2, vector, (float)i / 25f) + end, Vector3.Slerp(vector2, vector, (float)(i - 1) / 25f) + end, color, duration, depthTest);
			Debug.DrawLine(Vector3.Slerp(-vector2, vector, (float)i / 25f) + end, Vector3.Slerp(-vector2, vector, (float)(i - 1) / 25f) + end, color, duration, depthTest);
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000035FF File Offset: 0x000017FF
	[Conditional("UNITY_EDITOR")]
	public static void DebugCapsule(Vector3 start, Vector3 end, float radius = 1f, float duration = 0f, bool depthTest = true)
	{
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00003604 File Offset: 0x00001804
	[Conditional("UNITY_EDITOR")]
	public static void DrawWorldRotataion(Vector3 position, Quaternion worldRotation, float distance, float colorMod = 1f)
	{
		DebugExtension.DrawArrow(position, worldRotation * Vector3.forward * distance, Color.blue * colorMod);
		DebugExtension.DrawArrow(position, worldRotation * Vector3.up * distance, Color.green * colorMod);
		DebugExtension.DrawArrow(position, worldRotation * Vector3.right * distance, Color.red * colorMod);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00003678 File Offset: 0x00001878
	public static void DrawPoint(Vector3 position, Color color, float scale = 1f)
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale);
		Gizmos.DrawRay(position + Vector3.right * (scale * 0.5f), -Vector3.right * scale);
		Gizmos.DrawRay(position + Vector3.forward * (scale * 0.5f), -Vector3.forward * scale);
		Gizmos.color = color2;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003719 File Offset: 0x00001919
	public static void DrawPoint(Vector3 position, float scale = 1f)
	{
		DebugExtension.DrawPoint(position, Color.white, scale);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003728 File Offset: 0x00001928
	public static void DrawBounds(Bounds bounds, Color color)
	{
		Vector3 center = bounds.center;
		float x = bounds.extents.x;
		float y = bounds.extents.y;
		float z = bounds.extents.z;
		Vector3 vector = center + new Vector3(x, y, z);
		Vector3 vector2 = center + new Vector3(x, y, -z);
		Vector3 vector3 = center + new Vector3(-x, y, z);
		Vector3 vector4 = center + new Vector3(-x, y, -z);
		Vector3 vector5 = center + new Vector3(x, -y, z);
		Vector3 vector6 = center + new Vector3(x, -y, -z);
		Vector3 vector7 = center + new Vector3(-x, -y, z);
		Vector3 vector8 = center + new Vector3(-x, -y, -z);
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawLine(vector, vector3);
		Gizmos.DrawLine(vector, vector2);
		Gizmos.DrawLine(vector3, vector4);
		Gizmos.DrawLine(vector2, vector4);
		Gizmos.DrawLine(vector, vector5);
		Gizmos.DrawLine(vector2, vector6);
		Gizmos.DrawLine(vector3, vector7);
		Gizmos.DrawLine(vector4, vector8);
		Gizmos.DrawLine(vector5, vector7);
		Gizmos.DrawLine(vector5, vector6);
		Gizmos.DrawLine(vector7, vector8);
		Gizmos.DrawLine(vector8, vector6);
		Gizmos.color = color2;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00003866 File Offset: 0x00001A66
	public static void DrawBounds(Bounds bounds)
	{
		DebugExtension.DrawBounds(bounds, Color.white);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00003874 File Offset: 0x00001A74
	public static void DrawLocalCube(Transform transform, Vector3 size, Color color, Vector3 center = default(Vector3))
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Vector3 vector = transform.TransformPoint(center + -size * 0.5f);
		Vector3 vector2 = transform.TransformPoint(center + new Vector3(size.x, -size.y, -size.z) * 0.5f);
		Vector3 vector3 = transform.TransformPoint(center + new Vector3(size.x, -size.y, size.z) * 0.5f);
		Vector3 vector4 = transform.TransformPoint(center + new Vector3(-size.x, -size.y, size.z) * 0.5f);
		Vector3 vector5 = transform.TransformPoint(center + new Vector3(-size.x, size.y, -size.z) * 0.5f);
		Vector3 vector6 = transform.TransformPoint(center + new Vector3(size.x, size.y, -size.z) * 0.5f);
		Vector3 vector7 = transform.TransformPoint(center + size * 0.5f);
		Vector3 vector8 = transform.TransformPoint(center + new Vector3(-size.x, size.y, size.z) * 0.5f);
		Gizmos.DrawLine(vector, vector2);
		Gizmos.DrawLine(vector2, vector3);
		Gizmos.DrawLine(vector3, vector4);
		Gizmos.DrawLine(vector4, vector);
		Gizmos.DrawLine(vector5, vector6);
		Gizmos.DrawLine(vector6, vector7);
		Gizmos.DrawLine(vector7, vector8);
		Gizmos.DrawLine(vector8, vector5);
		Gizmos.DrawLine(vector, vector5);
		Gizmos.DrawLine(vector2, vector6);
		Gizmos.DrawLine(vector3, vector7);
		Gizmos.DrawLine(vector4, vector8);
		Gizmos.color = color2;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00003A47 File Offset: 0x00001C47
	public static void DrawLocalCube(Transform transform, Vector3 size, Vector3 center = default(Vector3))
	{
		DebugExtension.DrawLocalCube(transform, size, Color.white, center);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00003A58 File Offset: 0x00001C58
	public static void DrawLocalCube(Matrix4x4 space, Vector3 size, Color color, Vector3 center = default(Vector3))
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Vector3 vector = space.MultiplyPoint3x4(center + -size * 0.5f);
		Vector3 vector2 = space.MultiplyPoint3x4(center + new Vector3(size.x, -size.y, -size.z) * 0.5f);
		Vector3 vector3 = space.MultiplyPoint3x4(center + new Vector3(size.x, -size.y, size.z) * 0.5f);
		Vector3 vector4 = space.MultiplyPoint3x4(center + new Vector3(-size.x, -size.y, size.z) * 0.5f);
		Vector3 vector5 = space.MultiplyPoint3x4(center + new Vector3(-size.x, size.y, -size.z) * 0.5f);
		Vector3 vector6 = space.MultiplyPoint3x4(center + new Vector3(size.x, size.y, -size.z) * 0.5f);
		Vector3 vector7 = space.MultiplyPoint3x4(center + size * 0.5f);
		Vector3 vector8 = space.MultiplyPoint3x4(center + new Vector3(-size.x, size.y, size.z) * 0.5f);
		Gizmos.DrawLine(vector, vector2);
		Gizmos.DrawLine(vector2, vector3);
		Gizmos.DrawLine(vector3, vector4);
		Gizmos.DrawLine(vector4, vector);
		Gizmos.DrawLine(vector5, vector6);
		Gizmos.DrawLine(vector6, vector7);
		Gizmos.DrawLine(vector7, vector8);
		Gizmos.DrawLine(vector8, vector5);
		Gizmos.DrawLine(vector, vector5);
		Gizmos.DrawLine(vector2, vector6);
		Gizmos.DrawLine(vector3, vector7);
		Gizmos.DrawLine(vector4, vector8);
		Gizmos.color = color2;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00003C33 File Offset: 0x00001E33
	public static void DrawLocalCube(Matrix4x4 space, Vector3 size, Vector3 center = default(Vector3))
	{
		DebugExtension.DrawLocalCube(space, size, Color.white, center);
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00003C44 File Offset: 0x00001E44
	public static void DrawCircle(Vector3 position, Vector3 up, Color color, float radius = 1f)
	{
		up = ((up == Vector3.zero) ? Vector3.up : up).normalized * radius;
		Vector3 vector = Vector3.Slerp(up, -up, 0.5f);
		Vector3 vector2 = Vector3.Cross(up, vector).normalized * radius;
		Matrix4x4 matrix4x = default(Matrix4x4);
		matrix4x[0] = vector2.x;
		matrix4x[1] = vector2.y;
		matrix4x[2] = vector2.z;
		matrix4x[4] = up.x;
		matrix4x[5] = up.y;
		matrix4x[6] = up.z;
		matrix4x[8] = vector.x;
		matrix4x[9] = vector.y;
		matrix4x[10] = vector.z;
		Vector3 vector3 = position + matrix4x.MultiplyPoint3x4(new Vector3(Mathf.Cos(0f), 0f, Mathf.Sin(0f)));
		Vector3 vector4 = Vector3.zero;
		Color color2 = Gizmos.color;
		Gizmos.color = ((color == default(Color)) ? Color.white : color);
		for (int i = 0; i < 91; i++)
		{
			vector4.x = Mathf.Cos((float)(i * 4) * 0.017453292f);
			vector4.z = Mathf.Sin((float)(i * 4) * 0.017453292f);
			vector4.y = 0f;
			vector4 = position + matrix4x.MultiplyPoint3x4(vector4);
			Gizmos.DrawLine(vector3, vector4);
			vector3 = vector4;
		}
		Gizmos.color = color2;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00003DEF File Offset: 0x00001FEF
	public static void DrawCircle(Vector3 position, Color color, float radius = 1f)
	{
		DebugExtension.DrawCircle(position, Vector3.up, color, radius);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003DFE File Offset: 0x00001FFE
	public static void DrawCircle(Vector3 position, Vector3 up, float radius = 1f)
	{
		DebugExtension.DrawCircle(position, position, Color.white, radius);
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00003E0D File Offset: 0x0000200D
	public static void DrawCircle(Vector3 position, float radius = 1f)
	{
		DebugExtension.DrawCircle(position, Vector3.up, Color.white, radius);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00003E20 File Offset: 0x00002020
	public static void DrawCylinder(Vector3 start, Vector3 end, Color color, float radius = 1f)
	{
		Vector3 vector = (end - start).normalized * radius;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
		DebugExtension.DrawCircle(start, vector, color, radius);
		DebugExtension.DrawCircle(end, -vector, color, radius);
		DebugExtension.DrawCircle((start + end) * 0.5f, vector, color, radius);
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawLine(start + vector3, end + vector3);
		Gizmos.DrawLine(start - vector3, end - vector3);
		Gizmos.DrawLine(start + vector2, end + vector2);
		Gizmos.DrawLine(start - vector2, end - vector2);
		Gizmos.DrawLine(start - vector3, start + vector3);
		Gizmos.DrawLine(start - vector2, start + vector2);
		Gizmos.DrawLine(end - vector3, end + vector3);
		Gizmos.DrawLine(end - vector2, end + vector2);
		Gizmos.color = color2;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00003F43 File Offset: 0x00002143
	public static void DrawCylinder(Vector3 start, Vector3 end, float radius = 1f)
	{
		DebugExtension.DrawCylinder(start, end, Color.white, radius);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00003F54 File Offset: 0x00002154
	public static void DrawCone(Vector3 position, Vector3 direction, Color color, float angle = 45f)
	{
		float magnitude = direction.magnitude;
		Vector3 vector = direction;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * magnitude;
		direction = direction.normalized;
		Vector3 vector4 = Vector3.Slerp(vector, vector2, angle / 90f);
		Plane plane = new Plane(-direction, position + vector);
		Ray ray = new Ray(position, vector4);
		float num;
		plane.Raycast(ray, out num);
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawRay(position, vector4.normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, -vector2, angle / 90f).normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, vector3, angle / 90f).normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, -vector3, angle / 90f).normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, (-vector2 + vector3).normalized, angle / 90f).normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, (vector2 + vector3).normalized, angle / 90f).normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, (-vector2 - vector3).normalized, angle / 90f).normalized * num);
		Gizmos.DrawRay(position, Vector3.Slerp(vector, (vector2 - vector3).normalized, angle / 90f).normalized * num);
		DebugExtension.DrawCircle(position + vector, direction, color, (vector - vector4.normalized * num).magnitude);
		DebugExtension.DrawCircle(position + vector * 0.5f, direction, color, (vector * 0.5f - vector4.normalized * (num * 0.5f)).magnitude);
		Gizmos.color = color2;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x000041B7 File Offset: 0x000023B7
	public static void DrawCone(Vector3 position, Vector3 direction, float angle = 45f)
	{
		DebugExtension.DrawCone(position, direction, Color.white, angle);
	}

	// Token: 0x0600003D RID: 61 RVA: 0x000041C6 File Offset: 0x000023C6
	public static void DrawCone(Vector3 position, Color color, float angle = 45f)
	{
		DebugExtension.DrawCone(position, Vector3.up, color, angle);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x000041D5 File Offset: 0x000023D5
	public static void DrawCone(Vector3 position, float angle = 45f)
	{
		DebugExtension.DrawCone(position, Vector3.up, Color.white, angle);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000041E8 File Offset: 0x000023E8
	public static void DrawArrow(Vector3 position, Vector3 direction, Color color)
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		Gizmos.DrawRay(position, direction);
		DebugExtension.DrawCone(position + direction, -direction * 0.333f, color, 15f);
		Gizmos.color = color2;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00004223 File Offset: 0x00002423
	public static void DrawArrow(Vector3 position, Vector3 direction)
	{
		DebugExtension.DrawArrow(position, direction, Color.white);
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00004234 File Offset: 0x00002434
	public static void DrawCapsule(Vector3 start, Vector3 end, Color color, float radius = 1f)
	{
		Vector3 vector = (end - start).normalized * radius;
		Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
		Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		float magnitude = (start - end).magnitude;
		float num = Mathf.Max(0f, magnitude * 0.5f - radius);
		Vector3 vector4 = (end + start) * 0.5f;
		start = vector4 + (start - vector4).normalized * num;
		end = vector4 + (end - vector4).normalized * num;
		DebugExtension.DrawCircle(start, vector, color, radius);
		DebugExtension.DrawCircle(end, -vector, color, radius);
		Gizmos.DrawLine(start + vector3, end + vector3);
		Gizmos.DrawLine(start - vector3, end - vector3);
		Gizmos.DrawLine(start + vector2, end + vector2);
		Gizmos.DrawLine(start - vector2, end - vector2);
		for (int i = 1; i < 26; i++)
		{
			Gizmos.DrawLine(Vector3.Slerp(vector3, -vector, (float)i / 25f) + start, Vector3.Slerp(vector3, -vector, (float)(i - 1) / 25f) + start);
			Gizmos.DrawLine(Vector3.Slerp(-vector3, -vector, (float)i / 25f) + start, Vector3.Slerp(-vector3, -vector, (float)(i - 1) / 25f) + start);
			Gizmos.DrawLine(Vector3.Slerp(vector2, -vector, (float)i / 25f) + start, Vector3.Slerp(vector2, -vector, (float)(i - 1) / 25f) + start);
			Gizmos.DrawLine(Vector3.Slerp(-vector2, -vector, (float)i / 25f) + start, Vector3.Slerp(-vector2, -vector, (float)(i - 1) / 25f) + start);
			Gizmos.DrawLine(Vector3.Slerp(vector3, vector, (float)i / 25f) + end, Vector3.Slerp(vector3, vector, (float)(i - 1) / 25f) + end);
			Gizmos.DrawLine(Vector3.Slerp(-vector3, vector, (float)i / 25f) + end, Vector3.Slerp(-vector3, vector, (float)(i - 1) / 25f) + end);
			Gizmos.DrawLine(Vector3.Slerp(vector2, vector, (float)i / 25f) + end, Vector3.Slerp(vector2, vector, (float)(i - 1) / 25f) + end);
			Gizmos.DrawLine(Vector3.Slerp(-vector2, vector, (float)i / 25f) + end, Vector3.Slerp(-vector2, vector, (float)(i - 1) / 25f) + end);
		}
		Gizmos.color = color2;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00004572 File Offset: 0x00002772
	public static void DrawCapsule(Vector3 start, Vector3 end, float radius = 1f)
	{
		DebugExtension.DrawCapsule(start, end, Color.white, radius);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00004584 File Offset: 0x00002784
	public static string MethodsOfObject(object obj, bool includeInfo = false)
	{
		string text = "";
		MethodInfo[] methods = obj.GetType().GetMethods();
		for (int i = 0; i < methods.Length; i++)
		{
			if (includeInfo)
			{
				string text2 = text;
				MethodInfo methodInfo = methods[i];
				text = text2 + ((methodInfo != null) ? methodInfo.ToString() : null) + "\n";
			}
			else
			{
				text = text + methods[i].Name + "\n";
			}
		}
		return text;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000045E8 File Offset: 0x000027E8
	public static string MethodsOfType(Type type, bool includeInfo = false)
	{
		string text = "";
		MethodInfo[] methods = type.GetMethods();
		for (int i = 0; i < methods.Length; i++)
		{
			if (includeInfo)
			{
				string text2 = text;
				MethodInfo methodInfo = methods[i];
				text = text2 + ((methodInfo != null) ? methodInfo.ToString() : null) + "\n";
			}
			else
			{
				text = text + methods[i].Name + "\n";
			}
		}
		return text;
	}
}
