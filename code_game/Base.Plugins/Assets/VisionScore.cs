using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200014B RID: 331
	[Serializable]
	public class VisionScore
	{
		// Token: 0x060009E5 RID: 2533 RVA: 0x00020358 File Offset: 0x0001E558
		public VisionScore()
		{
			this.m_calculedHorizontalScore = float.MaxValue;
			this.m_calculedVerticalScore = float.MaxValue;
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x000203AD File Offset: 0x0001E5AD
		public bool esIzquierda
		{
			get
			{
				return this.m_esIzquierda;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x000203B5 File Offset: 0x0001E5B5
		public bool esPorAbajo
		{
			get
			{
				return this.m_esPorAbajo;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x000203BD File Offset: 0x0001E5BD
		public bool esPorDetras
		{
			get
			{
				return this.m_esPorDetras;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x000203C5 File Offset: 0x0001E5C5
		public bool esScoreRange
		{
			get
			{
				return this.m_esScoreHorizontalRange && this.m_esScoreVerticalRange;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x000203D7 File Offset: 0x0001E5D7
		public float calculedHorizontalScore
		{
			get
			{
				return this.m_calculedHorizontalScore;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x000203DF File Offset: 0x0001E5DF
		public float calculedVerticalScore
		{
			get
			{
				return this.m_calculedHorizontalScore;
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x000203E7 File Offset: 0x0001E5E7
		public void SetDebugDrawData(float duration, Vector3 lookingHitPoint)
		{
			this.m_duration = duration;
			this.m_lookingHitPoint = lookingHitPoint;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x000203F8 File Offset: 0x0001E5F8
		public void Update(Quaternion chest, Vector3 lookForwardDirection, float scoreMods = 1f)
		{
			Vector3 vector = chest * Vector3.up;
			Vector3 vector2 = chest * Vector3.forward;
			Vector3 vector3 = chest * Vector3.right;
			vector = vector.normalized;
			vector2 = vector2.normalized;
			vector3 = vector3.normalized;
			Vector3 vector4 = Math3d.ProjectVectorOnPlane(vector, -lookForwardDirection);
			Vector3 vector5 = Math3d.InverseTransformDirectionMath(chest, vector4);
			this.m_esIzquierda = vector5.x < 0f;
			float num = Vector3.Dot(vector2, vector4.normalized);
			this.m_esPorDetras = num < 0f;
			this.m_calculedHorizontalScore = 1f - Mathf.Abs(num);
			this.m_esScoreHorizontalRange = this.m_calculedHorizontalScore * scoreMods >= this.scoreMinHorizontal && this.m_calculedHorizontalScore / scoreMods <= this.scoreMaxHorizontal;
			bool flag = this.debugDrawHorizontal;
			float num2 = Vector3.Dot(vector, Math3d.ProjectVectorOnPlane(vector3, -lookForwardDirection).normalized);
			this.m_esPorAbajo = num2 < 0f;
			this.m_calculedVerticalScore = Mathf.Abs(num2);
			this.m_esScoreVerticalRange = this.m_calculedVerticalScore * scoreMods >= this.scoreMinVertical && this.m_calculedVerticalScore / scoreMods <= this.scoreMaxVertical;
			bool flag2 = this.debugDrawVertical;
		}

		// Token: 0x04000274 RID: 628
		public bool debugDrawHorizontal;

		// Token: 0x04000275 RID: 629
		public bool debugDrawVertical;

		// Token: 0x04000276 RID: 630
		[Range(0f, 1f)]
		public float scoreMinHorizontal;

		// Token: 0x04000277 RID: 631
		[Range(0f, 1f)]
		public float scoreMaxHorizontal = 0.5f;

		// Token: 0x04000278 RID: 632
		[Range(0f, 1f)]
		public float scoreMinVertical;

		// Token: 0x04000279 RID: 633
		[Range(0f, 1f)]
		public float scoreMaxVertical = 0.5f;

		// Token: 0x0400027A RID: 634
		[SerializeField]
		[ReadOnlyUI]
		private bool m_esIzquierda;

		// Token: 0x0400027B RID: 635
		[SerializeField]
		[ReadOnlyUI]
		private bool m_esPorAbajo;

		// Token: 0x0400027C RID: 636
		[SerializeField]
		[ReadOnlyUI]
		private bool m_esPorDetras;

		// Token: 0x0400027D RID: 637
		[SerializeField]
		[ReadOnlyUI]
		private bool m_esScoreHorizontalRange;

		// Token: 0x0400027E RID: 638
		[SerializeField]
		[ReadOnlyUI]
		private bool m_esScoreVerticalRange;

		// Token: 0x0400027F RID: 639
		[Header("1 si esta a los lados, 0 si esta justo detras o adelante")]
		[SerializeField]
		[ReadOnlyUI]
		private float m_calculedHorizontalScore = float.MaxValue;

		// Token: 0x04000280 RID: 640
		[Header("1 si esta arriba o abajo, 0 si esta en medio")]
		[SerializeField]
		[ReadOnlyUI]
		private float m_calculedVerticalScore = float.MaxValue;

		// Token: 0x04000281 RID: 641
		private float m_duration;

		// Token: 0x04000282 RID: 642
		private Vector3 m_lookingHitPoint;
	}
}
