using System;
using TValleCustomClases;
using UnityEngine;

// Token: 0x02000038 RID: 56
public static class RigidBodyAttributesExt
{
	// Token: 0x06000207 RID: 519 RVA: 0x0000B5A9 File Offset: 0x000097A9
	public static float GetDensity(this Rigidbody rb, RigidbodyMaterial madeOf)
	{
		return (float)madeOf / 1000f;
	}

	// Token: 0x06000208 RID: 520 RVA: 0x0000B5B4 File Offset: 0x000097B4
	public static float GetVolumen(this Bounds bounds)
	{
		Vector3 size = bounds.size;
		return size.x * size.y * size.z * 1000000f;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0000B5E4 File Offset: 0x000097E4
	public static void UpdateMass(this Rigidbody rb, Bounds LocalBounds, RigidbodyMaterial madeOf)
	{
		float volumen = LocalBounds.GetVolumen();
		float num = rb.GetDensity(madeOf) * volumen / 1000f;
		rb.mass = num;
	}

	// Token: 0x0600020A RID: 522 RVA: 0x0000B60F File Offset: 0x0000980F
	public static void SetMediumSleepThreshold(this Rigidbody rb)
	{
		rb.sleepThreshold = 0.01f;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0000B61C File Offset: 0x0000981C
	public static void SetFastSleepThreshold(this Rigidbody rb)
	{
		rb.sleepThreshold = 0.3333f;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000B629 File Offset: 0x00009829
	public static void SetVeryFastSleepThreshold(this Rigidbody rb)
	{
		rb.sleepThreshold = 1f;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0000B636 File Offset: 0x00009836
	public static void ResetSleepThreshold(this Rigidbody rb)
	{
		rb.sleepThreshold = Physics.sleepThreshold;
	}
}
