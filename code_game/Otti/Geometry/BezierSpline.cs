using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000045 RID: 69
	public class BezierSpline : MonoBehaviour
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000343 RID: 835 RVA: 0x000106BB File Offset: 0x0000E8BB
		public Vector3[] Points
		{
			get
			{
				return this.mPoints;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000344 RID: 836 RVA: 0x000106C3 File Offset: 0x0000E8C3
		// (set) Token: 0x06000345 RID: 837 RVA: 0x000106CB File Offset: 0x0000E8CB
		public int Segments
		{
			get
			{
				return this.mSegments;
			}
			set
			{
				this.mSegments = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000346 RID: 838 RVA: 0x000106D4 File Offset: 0x0000E8D4
		// (set) Token: 0x06000347 RID: 839 RVA: 0x000106DC File Offset: 0x0000E8DC
		public bool Loop
		{
			get
			{
				return this.mLoop;
			}
			set
			{
				this.mLoop = value;
				if (this.mLoop)
				{
					this.mControlConstraints[this.mControlConstraints.Length - 1] = this.mControlConstraints[0];
					this.SetControlPoint(this.ControlPointCount - 1, this.GetControlPoint(0));
				}
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0001071B File Offset: 0x0000E91B
		public float Length
		{
			get
			{
				if (this.mLength == 0f)
				{
					this.CalculateCurveLengths();
				}
				return this.mLength;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00010737 File Offset: 0x0000E937
		public int ControlPointCount
		{
			get
			{
				return (this.mPoints.Length - 1) / 3 + 1;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00010747 File Offset: 0x0000E947
		public int CurveCount
		{
			get
			{
				return (this.mPoints.Length - 1) / 3;
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00010755 File Offset: 0x0000E955
		public void Awake()
		{
			this.CalculateCurveLengths();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00010760 File Offset: 0x0000E960
		public void Reset()
		{
			this.mLoop = false;
			this.mLength = 0f;
			this.mPoints = new Vector3[]
			{
				new Vector3(0f, 0f, 0f),
				new Vector3(0f, 0f, 1f),
				new Vector3(0f, 0f, 2f),
				new Vector3(0f, 0f, 3f)
			};
			this.mCurveLengths = new float[] { 3f };
			this.mControlConstraints = new int[2];
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00010818 File Offset: 0x0000EA18
		public void AddControlPoint()
		{
			if (this.mPoints == null)
			{
				this.Reset();
			}
			int num = this.mPoints.Length;
			Vector3 vector = this.mPoints[this.mPoints.Length - 1];
			Array.Resize<Vector3>(ref this.mPoints, num + 3);
			Array.Resize<float>(ref this.mCurveLengths, (this.mPoints.Length - 1) / 3);
			Array.Resize<int>(ref this.mControlConstraints, this.mCurveLengths.Length + 1);
			vector.z += 1f;
			this.mPoints[num++] = vector;
			vector.z += 1f;
			this.mPoints[num++] = vector;
			vector.z += 1f;
			this.mPoints[num++] = vector;
			this.mControlConstraints[this.mControlConstraints.Length - 1] = this.mControlConstraints[this.mControlConstraints.Length - 2];
			if (this.mLoop)
			{
				this.mControlConstraints[this.mControlConstraints.Length - 1] = this.mControlConstraints[0];
				this.SetControlPoint(this.ControlPointCount - 1, this.GetControlPoint(0));
			}
			this.CalculateCurveLengths();
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00010950 File Offset: 0x0000EB50
		public void InsertControlPoint(int rIndex)
		{
			if (this.mPoints == null)
			{
				this.Reset();
			}
			if (rIndex < 0 || rIndex >= this.ControlPointCount)
			{
				this.AddControlPoint();
				return;
			}
			if (rIndex == 0)
			{
				rIndex = 1;
			}
			Array.Resize<Vector3>(ref this.mPoints, this.mPoints.Length + 3);
			for (int i = this.mPoints.Length - 4; i >= rIndex * 3; i--)
			{
				this.mPoints[i + 3] = this.mPoints[i];
			}
			int num = rIndex * 3;
			int num2 = (rIndex - 1) * 3;
			int num3 = (rIndex + 1) * 3;
			this.mPoints[num3 - 1] = this.mPoints[num - 1];
			this.mPoints[num] = (this.mPoints[num - 3] + this.mPoints[num + 3]) / 2f;
			this.mPoints[num + 1] = this.mPoints[num] + (this.mPoints[num3] - this.mPoints[num]) / 2f;
			this.mPoints[num - 1] = this.mPoints[num] + (this.mPoints[num2] - this.mPoints[num]) / 2f;
			Array.Resize<float>(ref this.mCurveLengths, this.mCurveLengths.Length + 1);
			for (int j = this.mCurveLengths.Length - 1; j >= rIndex; j--)
			{
				this.mCurveLengths[j] = this.mCurveLengths[j - 1];
			}
			Array.Resize<int>(ref this.mControlConstraints, this.mCurveLengths.Length + 1);
			for (int k = this.mControlConstraints.Length - 1; k >= rIndex; k--)
			{
				this.mControlConstraints[k] = this.mControlConstraints[k - 1];
			}
			this.CalculateCurveLengths();
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00010B48 File Offset: 0x0000ED48
		public void DeleteControlPoint(int rIndex)
		{
			if (rIndex < 0 || rIndex >= this.ControlPointCount)
			{
				return;
			}
			if (this.mPoints.Length <= 4)
			{
				return;
			}
			for (int i = ((rIndex == 0) ? 0 : (rIndex * 3 - 1)); i < this.mPoints.Length - 3; i++)
			{
				this.mPoints[i] = this.mPoints[i + 3];
			}
			Array.Resize<Vector3>(ref this.mPoints, this.mPoints.Length - 3);
			for (int j = rIndex; j < this.mCurveLengths.Length - 1; j++)
			{
				this.mCurveLengths[j] = this.mCurveLengths[j + 1];
			}
			Array.Resize<float>(ref this.mCurveLengths, this.mCurveLengths.Length - 1);
			for (int k = rIndex; k < this.mControlConstraints.Length - 1; k++)
			{
				this.mControlConstraints[k] = this.mControlConstraints[k + 1];
			}
			Array.Resize<int>(ref this.mControlConstraints, this.mControlConstraints.Length - 1);
			this.CalculateCurveLengths();
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00010C3C File Offset: 0x0000EE3C
		public Vector3 GetControlPoint(int rIndex)
		{
			rIndex *= 3;
			if (rIndex < 0 || rIndex >= this.mPoints.Length)
			{
				return Vector3.zero;
			}
			return this.mPoints[rIndex];
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00010C64 File Offset: 0x0000EE64
		public void SetControlPoint(int rIndex, Vector3 rPoint)
		{
			int controlPointCount = this.ControlPointCount;
			int num = rIndex * 3;
			if (num < 0 || num >= this.mPoints.Length)
			{
				return;
			}
			Vector3 vector = rPoint - this.mPoints[num];
			this.mPoints[num] = rPoint;
			if (this.mLoop)
			{
				if (rIndex == 0)
				{
					this.mPoints[this.mPoints.Length - 1] = this.mPoints[0];
				}
				else if (rIndex == controlPointCount - 1)
				{
					this.mPoints[0] = this.mPoints[this.mPoints.Length - 1];
				}
			}
			this.SetBackwardTangentPoint(rIndex, this.GetBackwardTangentPoint(rIndex) + vector);
			if (this.GetControlPointConstraint(rIndex) == 1)
			{
				this.SetForwardTangentPoint(rIndex, this.GetForwardTangentPoint(rIndex) + vector);
			}
			this.CalculateCurveLengths();
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00010D3A File Offset: 0x0000EF3A
		public int GetControlPointConstraint(int rIndex)
		{
			if (rIndex < 0 || rIndex >= this.mControlConstraints.Length)
			{
				return 0;
			}
			return this.mControlConstraints[rIndex];
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00010D58 File Offset: 0x0000EF58
		public void SetControlPointConstraint(int rIndex, int rConstraint)
		{
			if (rIndex < 0 || rIndex >= this.mControlConstraints.Length)
			{
				return;
			}
			this.mControlConstraints[rIndex] = rConstraint;
			if (this.mLoop)
			{
				if (rIndex == 0)
				{
					this.mControlConstraints[this.mControlConstraints.Length - 1] = rConstraint;
				}
				else if (rIndex == this.mControlConstraints.Length - 1)
				{
					this.mControlConstraints[0] = rConstraint;
				}
			}
			this.ApplyControlPointConstraint(rIndex, true);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00010DBC File Offset: 0x0000EFBC
		public Vector3 GetBackwardTangentPoint(int rIndex)
		{
			rIndex *= 3;
			if (rIndex < 0 || rIndex >= this.mPoints.Length)
			{
				return Vector3.zero;
			}
			rIndex--;
			if (rIndex < 0)
			{
				if (!this.mLoop)
				{
					return Vector3.zero;
				}
				rIndex = this.mPoints.Length - 2;
			}
			return this.mPoints[rIndex];
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00010E14 File Offset: 0x0000F014
		public void SetBackwardTangentPoint(int rIndex, Vector3 rPoint)
		{
			int num = rIndex * 3;
			if (num < 0 || num >= this.mPoints.Length)
			{
				return;
			}
			num--;
			if (num < 0)
			{
				if (!this.mLoop)
				{
					return;
				}
				num = this.mPoints.Length - 2;
			}
			this.mPoints[num] = rPoint;
			this.ApplyControlPointConstraint(rIndex, true);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00010E68 File Offset: 0x0000F068
		public Vector3 GetForwardTangentPoint(int rIndex)
		{
			rIndex *= 3;
			if (rIndex < 0 || rIndex >= this.mPoints.Length)
			{
				return Vector3.zero;
			}
			rIndex++;
			if (rIndex >= this.mPoints.Length)
			{
				if (!this.mLoop)
				{
					return Vector3.zero;
				}
				rIndex = 1;
			}
			return this.mPoints[rIndex];
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00010EC0 File Offset: 0x0000F0C0
		public void SetForwardTangentPoint(int rIndex, Vector3 rPoint)
		{
			int num = rIndex * 3;
			if (num < 0 || num >= this.mPoints.Length)
			{
				return;
			}
			num++;
			if (num >= this.mPoints.Length)
			{
				if (!this.mLoop)
				{
					return;
				}
				num = 1;
			}
			this.mPoints[num] = rPoint;
			this.ApplyControlPointConstraint(rIndex, false);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00010F14 File Offset: 0x0000F114
		public Vector3 GetPoint(float rPercent)
		{
			int num = 0;
			float num2 = 0f;
			this.GetCurvePercent(rPercent, ref num, ref num2);
			return this.GetPoint(num, num2);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00010F3C File Offset: 0x0000F13C
		public Vector3 GetPoint(int rCurveIndex, float rPercent)
		{
			if (rPercent < -1f || rPercent > 1f)
			{
				rPercent %= 1f;
			}
			if (rPercent < 0f)
			{
				rPercent = 1f + rPercent;
			}
			rCurveIndex *= 3;
			Vector3 cubicPoint = BezierSpline.GetCubicPoint(this.mPoints[rCurveIndex], this.mPoints[rCurveIndex + 1], this.mPoints[rCurveIndex + 2], this.mPoints[rCurveIndex + 3], rPercent);
			return base.transform.TransformPoint(cubicPoint);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00010FC4 File Offset: 0x0000F1C4
		public Vector3 GetVelocity(float rPercent)
		{
			int num = 0;
			float num2 = 0f;
			this.GetCurvePercent(rPercent, ref num, ref num2);
			return this.GetVelocity(num, num2);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00010FEC File Offset: 0x0000F1EC
		public Vector3 GetVelocity(int rCurveIndex, float rPercent)
		{
			if (rPercent < -1f || rPercent > 1f)
			{
				rPercent %= 1f;
			}
			if (rPercent < 0f)
			{
				rPercent = 1f + rPercent;
			}
			rCurveIndex *= 3;
			Vector3 vector = BezierSpline.GetFirstCubicDerivative(this.mPoints[rCurveIndex], this.mPoints[rCurveIndex + 1], this.mPoints[rCurveIndex + 2], this.mPoints[rCurveIndex + 3], rPercent) - base.transform.position;
			return base.transform.TransformPoint(vector);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00011084 File Offset: 0x0000F284
		public Vector3 GetDirection(float rPercent)
		{
			int num = 0;
			float num2 = 0f;
			this.GetCurvePercent(rPercent, ref num, ref num2);
			return this.GetDirection(num, num2);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000110AC File Offset: 0x0000F2AC
		public Vector3 GetDirection(int rCurveIndex, float rPercent)
		{
			return this.GetVelocity(rCurveIndex, rPercent).normalized;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000110CC File Offset: 0x0000F2CC
		public void GetCurvePercent(float rPercent, ref int rCurveIndex, ref float rCurvePercent)
		{
			if (this.mLength == 0f)
			{
				this.CalculateCurveLengths();
			}
			if (rPercent < -1f || rPercent > 1f)
			{
				rPercent %= 1f;
			}
			if (rPercent < 0f)
			{
				rPercent = 1f + rPercent;
			}
			if (rPercent == 0f)
			{
				rCurveIndex = 0;
				rCurvePercent = 0f;
				return;
			}
			if (rPercent == 1f)
			{
				rCurveIndex = this.CurveCount - 1;
				rCurvePercent = 1f;
				return;
			}
			float num = this.mLength * rPercent;
			float num2 = 0f;
			int num3 = 0;
			while (num3 < this.CurveCount && num >= num2 + this.mCurveLengths[num3])
			{
				num2 += this.mCurveLengths[num3];
				num3++;
			}
			num -= num2;
			rCurveIndex = num3;
			rCurvePercent = num / this.mCurveLengths[num3];
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00011194 File Offset: 0x0000F394
		public void ApplyControlPointConstraint(int rIndex, bool rLeadWithBackwardCP)
		{
			if (!this.mLoop && rIndex <= 0)
			{
				return;
			}
			if (!this.mLoop && rIndex >= this.ControlPointCount - 1)
			{
				return;
			}
			int controlPointConstraint = this.GetControlPointConstraint(rIndex);
			if (controlPointConstraint != 1)
			{
				Vector3 controlPoint = this.GetControlPoint(rIndex);
				int num = rIndex * 3 - 1;
				if (num < 0)
				{
					num = this.mPoints.Length - 2;
				}
				Vector3 backwardTangentPoint = this.GetBackwardTangentPoint(rIndex);
				int num2 = rIndex * 3 + 1;
				if (num2 >= this.mPoints.Length)
				{
					num2 = 1;
				}
				Vector3 forwardTangentPoint = this.GetForwardTangentPoint(rIndex);
				if (controlPointConstraint == 0)
				{
					if (rLeadWithBackwardCP)
					{
						Vector3 vector = backwardTangentPoint - controlPoint;
						this.mPoints[num2] = controlPoint - vector;
					}
					else
					{
						Vector3 vector2 = forwardTangentPoint - controlPoint;
						this.mPoints[num] = controlPoint - vector2;
					}
				}
				else if (controlPointConstraint == 2)
				{
					if (rLeadWithBackwardCP)
					{
						Vector3 vector3 = (controlPoint - backwardTangentPoint).normalized * Vector3.Distance(controlPoint, forwardTangentPoint);
						this.mPoints[num2] = controlPoint - vector3;
					}
					else
					{
						Vector3 vector4 = (controlPoint - forwardTangentPoint).normalized * Vector3.Distance(controlPoint, backwardTangentPoint);
						this.mPoints[num] = controlPoint - vector4;
					}
				}
			}
			this.CalculateCurveLengths();
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000112D8 File Offset: 0x0000F4D8
		public float CalculateCurveLengths()
		{
			this.mLength = 0f;
			if (this.mCurveLengths == null || this.mCurveLengths.Length == 0)
			{
				this.mCurveLengths = new float[this.CurveCount];
			}
			Vector3 vector = this.GetPoint(0, 0f);
			for (int i = 0; i < this.CurveCount; i++)
			{
				float num = 0f;
				for (int j = 1; j <= this.mSegments; j++)
				{
					float num2 = (float)j / (float)this.mSegments;
					Vector3 point = this.GetPoint(i, num2);
					num += Vector3.Distance(vector, point);
					vector = point;
				}
				this.mCurveLengths[i] = num;
				this.mLength += num;
			}
			return this.mLength;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0001138C File Offset: 0x0000F58C
		public static Vector3 GetQuadradicPoint(Vector3 rP0, Vector3 rP1, Vector3 rP2, float rTime)
		{
			rTime = Mathf.Clamp01(rTime);
			float num = 1f - rTime;
			return num * num * rP0 + 2f * num * rTime * rP1 + rTime * rTime * rP2;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000113D4 File Offset: 0x0000F5D4
		public static Vector3 GetFirstQuadradicDerivative(Vector3 rP0, Vector3 rP1, Vector3 rP2, float rTime)
		{
			return 2f * (1f - rTime) * (rP1 - rP0) + 2f * rTime * (rP2 - rP1);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00011408 File Offset: 0x0000F608
		public static Vector3 GetCubicPoint(Vector3 rP0, Vector3 rP1, Vector3 rP2, Vector3 rP3, float rTime)
		{
			rTime = Mathf.Clamp01(rTime);
			float num = 1f - rTime;
			return num * num * num * rP0 + 3f * num * num * rTime * rP1 + 3f * num * rTime * rTime * rP2 + rTime * rTime * rTime * rP3;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00011474 File Offset: 0x0000F674
		public static Vector3 GetFirstCubicDerivative(Vector3 rP0, Vector3 rP1, Vector3 rP2, Vector3 rP3, float rTime)
		{
			rTime = Mathf.Clamp01(rTime);
			float num = 1f - rTime;
			return 3f * num * num * (rP1 - rP0) + 6f * num * rTime * (rP2 - rP1) + 3f * rTime * rTime * (rP3 - rP2);
		}

		// Token: 0x040001DD RID: 477
		[SerializeField]
		private Vector3[] mPoints;

		// Token: 0x040001DE RID: 478
		[SerializeField]
		private int[] mControlConstraints;

		// Token: 0x040001DF RID: 479
		[SerializeField]
		private int mSegments = 10;

		// Token: 0x040001E0 RID: 480
		[SerializeField]
		private bool mLoop;

		// Token: 0x040001E1 RID: 481
		private float mLength;

		// Token: 0x040001E2 RID: 482
		private float[] mCurveLengths;
	}
}
