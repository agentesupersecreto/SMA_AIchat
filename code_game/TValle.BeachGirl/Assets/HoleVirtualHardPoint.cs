using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	public class HoleVirtualHardPoint
	{
		// Token: 0x0600003E RID: 62 RVA: 0x000020F7 File Offset: 0x000002F7
		public void SetProfundidadLocal(float radius)
		{
			this.m_profundidadLocal = radius;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002100 File Offset: 0x00000300
		public float GetProfundidadLocalFromInternals()
		{
			return this.m_profundidadLocal;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002108 File Offset: 0x00000308
		public float GetProfundidadLocalFromHole(float worldInternalScale, float worldHoleScale)
		{
			return this.m_profundidadLocal * worldInternalScale / worldHoleScale;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002114 File Offset: 0x00000314
		public float GetWorldProfundidad(float worldInternalScale)
		{
			return this.m_profundidadLocal * worldInternalScale;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000211E File Offset: 0x0000031E
		public void SetRadiusLocal(float radius)
		{
			this.m_radiusLocal = radius;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002127 File Offset: 0x00000327
		public float GetLocalRadiusFromInternals()
		{
			return this.m_radiusLocal;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000212F File Offset: 0x0000032F
		public float GetLocalRadiusFromHole(float worldInternalScale, float worldHoleScale)
		{
			return this.m_radiusLocal * worldInternalScale / worldHoleScale;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000213B File Offset: 0x0000033B
		public float GetWorldRadius(float worldInternalScale)
		{
			return this.m_radiusLocal * worldInternalScale;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002145 File Offset: 0x00000345
		public float LinealWeight(float currentPenetracionProfundidadLocal)
		{
			return MathfExtension.InverseLerpConMedio(this.m_profundidadLocal - this.m_radiusLocal, this.m_profundidadLocal, this.m_profundidadLocal + this.m_radiusLocal, currentPenetracionProfundidadLocal);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000216D File Offset: 0x0000036D
		public float ToCenterWeight(float currentPenetracionProfundidadLocal)
		{
			return MathfExtension.InverseLerpAlMedio(this.m_profundidadLocal - this.m_radiusLocal, this.m_profundidadLocal, this.m_profundidadLocal + this.m_radiusLocal, currentPenetracionProfundidadLocal);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002198 File Offset: 0x00000398
		public float ToCenterWeightResistanciaInfluenced(float currentPenetracionProfundidadLocal)
		{
			return MathfExtension.InverseLerpAlMedio(Mathf.Lerp(this.m_profundidadLocal, this.m_profundidadLocal - this.m_radiusLocal, this.resistenciaMod), this.m_profundidadLocal, Mathf.Lerp(this.m_profundidadLocal, this.m_profundidadLocal + this.m_radiusLocal, this.resistenciaMod), currentPenetracionProfundidadLocal);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000021ED File Offset: 0x000003ED
		public float RadiusResistanciaInfluenced()
		{
			return this.m_radiusLocal * Mathf.Clamp01(this.resistenciaMod);
		}

		// Token: 0x0400000F RID: 15
		public string id;

		// Token: 0x04000010 RID: 16
		[SerializeField]
		private float m_profundidadLocal;

		// Token: 0x04000011 RID: 17
		[SerializeField]
		private float m_radiusLocal;

		// Token: 0x04000012 RID: 18
		public float resistenciaMod;

		// Token: 0x04000013 RID: 19
		public float passResistenciaMod;

		// Token: 0x04000014 RID: 20
		public float desgaste;

		// Token: 0x04000015 RID: 21
		public float maxDesgastePorSegundo;

		// Token: 0x04000016 RID: 22
		public float aiWeight = 1f;
	}
}
