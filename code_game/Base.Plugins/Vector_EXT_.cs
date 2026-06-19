using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
public static class Vector_EXT_
{
	// Token: 0x0600020E RID: 526 RVA: 0x0000B644 File Offset: 0x00009844
	public static Vector3 Dividir(this Vector3 vec, Vector3 otro)
	{
		float num = ((otro.x == 0f) ? 0f : (vec.x / otro.x));
		float num2 = ((otro.y == 0f) ? 0f : (vec.y / otro.y));
		float num3 = ((otro.z == 0f) ? 0f : (vec.z / otro.z));
		return new Vector3(num, num2, num3);
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0000B6C0 File Offset: 0x000098C0
	public static float Escala(this Vector3 vec)
	{
		float num = (Mathf.Abs(vec.x) + Mathf.Abs(vec.y) + Mathf.Abs(vec.z)) / 3f;
		return Mathf.Max(float.Epsilon, num);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0000B704 File Offset: 0x00009904
	public static float Middle(this Vector3 vec)
	{
		float num = vec.Min();
		float num2 = vec.Max();
		if (vec.x != num && vec.x != num2)
		{
			return vec.x;
		}
		if (vec.y != num && vec.y != num2)
		{
			return vec.y;
		}
		if (vec.z != num && vec.z != num2)
		{
			return vec.z;
		}
		return num;
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0000B76C File Offset: 0x0000996C
	public static float Min(this Vector3 vec)
	{
		if (vec.x <= vec.y && vec.x <= vec.z)
		{
			return vec.x;
		}
		if (vec.y <= vec.x && vec.y <= vec.z)
		{
			return vec.y;
		}
		if (vec.z <= vec.x && vec.z <= vec.y)
		{
			return vec.z;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000212 RID: 530 RVA: 0x0000B7E8 File Offset: 0x000099E8
	public static float Max(this Vector3 vec)
	{
		if (vec.x >= vec.y && vec.x >= vec.z)
		{
			return vec.x;
		}
		if (vec.y >= vec.x && vec.y >= vec.z)
		{
			return vec.y;
		}
		if (vec.z >= vec.x && vec.z >= vec.y)
		{
			return vec.z;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0000B863 File Offset: 0x00009A63
	public static float Suma(this Vector3 vec)
	{
		return vec.x + vec.y + vec.z;
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0000B879 File Offset: 0x00009A79
	public static Vector3 Abs(this Vector3 vec)
	{
		return new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z));
	}

	// Token: 0x06000215 RID: 533 RVA: 0x0000B8A4 File Offset: 0x00009AA4
	public static Vector3 PolarizarAngulos(this Vector3 eu)
	{
		float num = eu.x % 360f;
		float num2 = eu.y % 360f;
		float num3 = eu.z % 360f;
		num = ((num > 180f) ? (num - 360f) : num);
		num2 = ((num2 > 180f) ? (num2 - 360f) : num2);
		num3 = ((num3 > 180f) ? (num3 - 360f) : num3);
		return new Vector3(num, num2, num3);
	}

	// Token: 0x06000216 RID: 534 RVA: 0x0000B91C File Offset: 0x00009B1C
	public static Vector3 SetMagnitud(this Vector3 vec, Vector3 copi, float t)
	{
		if (vec.sqrMagnitude == copi.sqrMagnitude)
		{
			return vec;
		}
		float magnitude = copi.magnitude;
		float magnitude2 = vec.magnitude;
		return vec.normalized * Mathf.Lerp(magnitude2, magnitude, t);
	}

	// Token: 0x06000217 RID: 535 RVA: 0x0000B95F File Offset: 0x00009B5F
	public static Vector3 SetMagnitud(this Vector3 vec, Vector3 copiMag)
	{
		if (vec.sqrMagnitude == copiMag.sqrMagnitude)
		{
			return vec;
		}
		return vec.normalized * copiMag.magnitude;
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0000B986 File Offset: 0x00009B86
	public static Vector3 SetMagnitud(this Vector3 vec, float magnitude)
	{
		if (vec.sqrMagnitude == magnitude * magnitude)
		{
			return vec;
		}
		return vec.normalized * magnitude;
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0000B9A4 File Offset: 0x00009BA4
	public static Vector3 AddMagnitud(this Vector3 vec, float adding)
	{
		if (adding == 0f)
		{
			return vec;
		}
		float num = vec.magnitude + adding;
		return vec.normalized * num;
	}

	// Token: 0x0600021A RID: 538 RVA: 0x0000B9D4 File Offset: 0x00009BD4
	public static Vector3 ModMagnitud(this Vector3 vec, float mod)
	{
		if (mod == 0f)
		{
			return Vector3.zero;
		}
		float num = vec.magnitude * mod;
		return vec.normalized * num;
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0000BA06 File Offset: 0x00009C06
	public static Vector3 ClampMagnitud(this Vector3 vec, float min, float max)
	{
		return vec.normalized * Mathf.Clamp(vec.magnitude, min, max);
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0000BA24 File Offset: 0x00009C24
	public static Vector3 ClampMagnitudDisminutionReturn(this Vector3 vec, float max, float inPower)
	{
		float magnitude = vec.magnitude;
		if (magnitude <= max)
		{
			return vec;
		}
		float num = (max / magnitude).InPow(inPower);
		Vector3 vector = vec.normalized * max;
		return vector + (vec - vector) * num;
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0000BA6C File Offset: 0x00009C6C
	public static bool EnCono(this Vector3 posicion, Vector3 puntoDeCono, Vector3 directionDeCono, float maxAngle, out float modAngle, out float modDistance, float maxDistance = float.PositiveInfinity)
	{
		Vector3 vector = posicion - puntoDeCono;
		if (vector.sqrMagnitude > maxDistance * maxDistance)
		{
			modDistance = (modAngle = 0f);
			return false;
		}
		float num = Vector3.Angle(directionDeCono, vector);
		if (num <= maxAngle)
		{
			modAngle = Mathf.InverseLerp(maxAngle, 0f, num);
			modDistance = Mathf.InverseLerp(maxDistance, 0f, vector.magnitude);
			return true;
		}
		modDistance = (modAngle = 0f);
		return false;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0000BAE4 File Offset: 0x00009CE4
	public static bool EnRadius(this Vector3 posicion, Vector3 punto, float radius, out float modDistance)
	{
		Vector3 vector = posicion - punto;
		if (vector.sqrMagnitude > radius * radius)
		{
			modDistance = 0f;
			return false;
		}
		modDistance = Mathf.InverseLerp(radius, 0f, vector.magnitude);
		return true;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0000BB24 File Offset: 0x00009D24
	public static void ScaleAround(this Transform target, Vector3 pivot, Vector3 newScale)
	{
		if (newScale == Vector3.zero)
		{
			target.localScale = Vector3.zero;
			target.localPosition = pivot;
		}
		Vector3 vector = target.localPosition - pivot;
		float num = 0f;
		Vector3 localScale = target.localScale;
		if (newScale != Vector3.zero)
		{
			num = newScale.x * newScale.y * newScale.z / localScale.x * localScale.y * localScale.z;
		}
		Vector3 vector2 = pivot + vector * num;
		target.localScale = newScale;
		target.localPosition = vector2;
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0000BBC4 File Offset: 0x00009DC4
	public static bool EnCono(this Vector3 posicion, Vector3 punto, Vector3 direction, float maxAngle, float maxDistance = float.PositiveInfinity)
	{
		float num;
		float num2;
		return posicion.EnCono(punto, direction, maxAngle, out num, out num2, maxDistance);
	}

	// Token: 0x06000221 RID: 545 RVA: 0x0000BBE0 File Offset: 0x00009DE0
	public static bool EnRadius(this Vector3 posicion, Vector3 punto, float radius)
	{
		float num;
		return posicion.EnRadius(punto, radius, out num);
	}
}
