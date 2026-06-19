using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.Splines;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x0200016E RID: 366
	public abstract class PuntosGuiasRecorridoCircular : AplicableBehaviour
	{
		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000877 RID: 2167 RVA: 0x00026E00 File Offset: 0x00025000
		// (remove) Token: 0x06000878 RID: 2168 RVA: 0x00026E38 File Offset: 0x00025038
		public event PuntosGuiasRecorridoCircular.OnWeigthChangedHandler weigthChanged;

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0000E0F9 File Offset: 0x0000C2F9
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeDynamicColliders);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x00026E6D File Offset: 0x0002506D
		public Vector3 currentProyectedPoint
		{
			get
			{
				return this.m_currentProyectedPoint;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x00026E75 File Offset: 0x00025075
		public Quaternion currentRotationFromTangnts
		{
			get
			{
				return Quaternion.LookRotation(this.m_currentTangent, this.m_currentCrossTangent);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x00026E88 File Offset: 0x00025088
		public Vector3 currentTangent
		{
			get
			{
				return this.m_currentTangent;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x0600087D RID: 2173 RVA: 0x00026E90 File Offset: 0x00025090
		public Vector3 currentCrossTangent
		{
			get
			{
				return this.m_currentCrossTangent;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x00026E98 File Offset: 0x00025098
		public float currentRecorridoWeigth
		{
			get
			{
				return this.m_currentRecorridoWeigth;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x00026EA0 File Offset: 0x000250A0
		public bool recorriendo
		{
			get
			{
				return this.m_recorriendo;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x00026EA8 File Offset: 0x000250A8
		public bool paused
		{
			get
			{
				return this.m_paused;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x00026EB0 File Offset: 0x000250B0
		public Transform start
		{
			get
			{
				return this.m_start;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00026EB8 File Offset: 0x000250B8
		public PuntosGuiasRecorridoCircular.Curvas curvas
		{
			get
			{
				return this.m_Curvas;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x00026EC0 File Offset: 0x000250C0
		public bool init
		{
			get
			{
				return this.m_init;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x00026EC8 File Offset: 0x000250C8
		public ICharacter character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x000260E0 File Offset: 0x000242E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00026ED0 File Offset: 0x000250D0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00024829 File Offset: 0x00022A29
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00026EE5 File Offset: 0x000250E5
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00026EF4 File Offset: 0x000250F4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00026F00 File Offset: 0x00025100
		public void Init(PuntosGuiasRecorridoCircular.Config Config, params Transform[] ExtraPuntos)
		{
			if (this.m_init)
			{
				return;
			}
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			if (Config != null)
			{
				this.config = Config;
			}
			if (ExtraPuntos != null && ExtraPuntos.Length != 0)
			{
				this.puntos.AddRange(ExtraPuntos);
			}
			if (this.puntos.Count < 2)
			{
				throw new InvalidOperationException();
			}
			this.m_start = this.puntos.First<Transform>();
			if (this.puntos.Last<Transform>() != this.m_start)
			{
				this.puntos.Add(this.m_start);
			}
			this.ReInitCurvas();
			this.Clear();
			PuntosGuiasRecorridoCircular.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
			this.UpdateTargetTransform();
			this.m_init = true;
			base.ManualStart();
		}

		// Token: 0x0600088B RID: 2187
		public abstract void UpdateTargetTransform();

		// Token: 0x0600088C RID: 2188 RVA: 0x00026FE8 File Offset: 0x000251E8
		public void ReInitCurvas()
		{
			this.m_Curvas = new PuntosGuiasRecorridoCircular.Curvas();
			int num = this.puntos.Count - 1;
			BezierCurve[] array = new BezierCurve[num];
			ValueTuple<Transform, Transform>[] array2 = new ValueTuple<Transform, Transform>[num];
			ValueTuple<float, float, int>[] array3 = new ValueTuple<float, float, int>[num];
			DistanceToInterpolation[][] array4 = new DistanceToInterpolation[num][];
			this.m_Curvas.curvas = array;
			this.m_Curvas.distanceToindex = array3;
			this.m_Curvas.distanceToInterpolations = array4;
			this.m_Curvas.points = array2;
			ValueTuple<float, float, int>[] array5 = new ValueTuple<float, float, int>[num];
			this.m_Curvas.globalWeightToindex = array5;
			this.UpdateCurvas();
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00027074 File Offset: 0x00025274
		private void UpdateCurvas()
		{
			Transform transform = this.puntos[0];
			float num = 0f;
			float num2 = 0f;
			this.m_Curvas.largo = 0f;
			for (int i = 1; i < this.puntos.Count; i++)
			{
				int num3 = i - 1;
				Transform transform2 = this.puntos[i];
				float num4 = Vector3.Distance(transform2.position, transform.position);
				BezierCurve bezierCurve = BezierCurve.FromTangent(transform.position, transform.TransformDirection(this.config.localStartTan * Mathf.LerpUnclamped(1f, num4, this.config.tangetDistanceW) * this.config.tangetDistanceMod), transform2.position, transform2.TransformDirection(this.config.locaEndTan * Mathf.LerpUnclamped(1f, num4, this.config.tangetDistanceW) * this.config.tangetDistanceMod));
				this.m_Curvas.curvas[num3] = bezierCurve;
				this.m_Curvas.points[num3] = new ValueTuple<Transform, Transform>(transform, transform2);
				transform = transform2;
				DistanceToInterpolation[] array = new DistanceToInterpolation[20];
				CurveUtility.CalculateCurveLengths(bezierCurve, array);
				num2 += array[array.Length - 1].Distance;
				ValueTuple<float, float, int> valueTuple = new ValueTuple<float, float, int>(num, num2, num3);
				num = num2;
				this.m_Curvas.distanceToindex[num3] = valueTuple;
				this.m_Curvas.distanceToInterpolations[num3] = array;
			}
			this.m_Curvas.largo = num2;
			for (int j = 0; j < this.m_Curvas.distanceToindex.Length; j++)
			{
				ValueTuple<float, float, int> valueTuple2 = this.m_Curvas.distanceToindex[j];
				ValueTuple<float, float, int> valueTuple3 = new ValueTuple<float, float, int>(Mathf.InverseLerp(0f, this.m_Curvas.largo, valueTuple2.Item1), Mathf.InverseLerp(0f, this.m_Curvas.largo, valueTuple2.Item2), j);
				this.m_Curvas.globalWeightToindex[j] = valueTuple3;
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x000272AA File Offset: 0x000254AA
		public void StartRecorrido()
		{
			if (this.m_recorriendo && !this.m_paused)
			{
				throw new InvalidOperationException();
			}
			this.m_recorriendo = true;
			this.m_paused = false;
			base.enabled = true;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x000272D7 File Offset: 0x000254D7
		public void PauseRecorrido()
		{
			if (!this.m_recorriendo)
			{
				throw new InvalidOperationException();
			}
			this.m_paused = true;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x000272EE File Offset: 0x000254EE
		public void StopRecorrido()
		{
			if (!this.m_recorriendo)
			{
				throw new InvalidOperationException();
			}
			this.m_recorriendo = false;
			this.m_paused = false;
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0002730C File Offset: 0x0002550C
		public void UpdateTo(float W, bool updateTargetTransform)
		{
			W = Mathf.Clamp(W, 0f, 1f);
			this.m_currentRecorridoWeigth = W;
			this.UpdateCurvas();
			PuntosGuiasRecorridoCircular.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
			if (updateTargetTransform)
			{
				this.UpdateTargetTransform();
			}
			this.CheckWeigthChanged();
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00027380 File Offset: 0x00025580
		public void Evaluate(float W, out Vector3 position, out Quaternion rotation)
		{
			W = Mathf.Clamp(W, 0f, 1f);
			Vector3 vector;
			Vector3 vector2;
			PuntosGuiasRecorridoCircular.GetTrayecto(W, this.m_Curvas, this.config.localForward, this.config.localUp, out position, out vector, out vector2);
			rotation = Quaternion.LookRotation(vector, vector2);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x000273D3 File Offset: 0x000255D3
		public void ResetRecorrido()
		{
			this.Clear();
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000273DC File Offset: 0x000255DC
		public override void OnUpdateEvent2()
		{
			this.UpdateCurvas();
			if (this.m_paused)
			{
				PuntosGuiasRecorridoCircular.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
				return;
			}
			try
			{
				if (!this.m_recorriendo)
				{
					PuntosGuiasRecorridoCircular.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
					base.enabled = false;
				}
				else
				{
					float num = this.m_currentRecorridoWeigth + this.configVelocityByTangentChange.step;
					PuntosGuiasRecorridoCircular.Clamp01(ref num);
					Vector3 vector;
					PuntosGuiasRecorridoCircular.GetTrayectoTangent(num, this.m_Curvas, out vector);
					float num2 = Vector3.Angle(vector, this.m_currentTangent);
					float num3 = Mathf.InverseLerp(0f, this.configVelocityByTangentChange.angleToMinVelMod, num2).OutPow(this.configVelocityByTangentChange.angleInPower);
					this.m_velModByTangets = Mathf.Lerp(1f, this.configVelocityByTangentChange.minVelMod, num3);
					this.m_currentRecorridoWeigth += Time.deltaTime * this.config.velocidad * this.m_currentRecorridoVelModByTangets;
					PuntosGuiasRecorridoCircular.Clamp01(ref this.m_currentRecorridoWeigth);
					PuntosGuiasRecorridoCircular.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
					if (this.m_velModByTangets < this.m_currentRecorridoVelModByTangets)
					{
						this.m_currentRecorridoVelModByTangets = Mathf.MoveTowards(this.m_currentRecorridoVelModByTangets, this.m_velModByTangets, Time.deltaTime * this.configVelocityByTangentChange.deAcceleration * this.config.velocidad);
					}
					else
					{
						this.m_currentRecorridoVelModByTangets = Mathf.MoveTowards(this.m_currentRecorridoVelModByTangets, this.m_velModByTangets, Time.deltaTime * this.configVelocityByTangentChange.acceleration * this.config.velocidad);
					}
				}
				if (base.enabled)
				{
					this.UpdateTargetTransform();
				}
			}
			finally
			{
				this.CheckWeigthChanged();
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0002760C File Offset: 0x0002580C
		private void CheckWeigthChanged()
		{
			if (this.m_lastWeigth != this.m_currentRecorridoWeigth)
			{
				this.OnWeigthChanged(this.m_lastWeigth, this.m_currentRecorridoWeigth);
			}
			this.m_lastWeigth = this.m_currentRecorridoWeigth;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0002763A File Offset: 0x0002583A
		private void OnWeigthChanged(float last, float current)
		{
			PuntosGuiasRecorridoCircular.OnWeigthChangedHandler onWeigthChangedHandler = this.weigthChanged;
			if (onWeigthChangedHandler == null)
			{
				return;
			}
			onWeigthChangedHandler(last, current, this);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0002764F File Offset: 0x0002584F
		private static void Clamp01(ref float value)
		{
			if (value >= 1f)
			{
				value = Mathf.Clamp(value - 1f, 0f, 1f);
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00027674 File Offset: 0x00025874
		private static void GetTrayectoTangent(float w, PuntosGuiasRecorridoCircular.Curvas curvas, out Vector3 proyectedRecorridoTangent)
		{
			w = Mathf.Clamp01(w);
			int num = -1;
			float num2 = -1f;
			for (int i = 0; i < curvas.globalWeightToindex.Length; i++)
			{
				ValueTuple<float, float, int> valueTuple = curvas.globalWeightToindex[i];
				if (w >= valueTuple.Item1 && w <= valueTuple.Item2)
				{
					num = valueTuple.Item3;
					num2 = Mathf.InverseLerp(valueTuple.Item1, valueTuple.Item2, w);
					break;
				}
			}
			if (num < 0)
			{
				throw new InvalidOperationException();
			}
			BezierCurve bezierCurve = curvas.curvas[num];
			ValueTuple<Transform, Transform>[] points = curvas.points;
			proyectedRecorridoTangent = CurveUtility.EvaluateTangent(bezierCurve, num2);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0002771C File Offset: 0x0002591C
		private static void GetTrayecto(float w, PuntosGuiasRecorridoCircular.Curvas curvas, Vector3 localTangetVector, Vector3 localCrossTangetVector, out Vector3 proyectedRecorridoPoint, out Vector3 proyectedRecorridoTangent, out Vector3 proyectedRecorridoCrossTangent)
		{
			w = Mathf.Clamp01(w);
			int num = -1;
			float num2 = -1f;
			for (int i = 0; i < curvas.globalWeightToindex.Length; i++)
			{
				ValueTuple<float, float, int> valueTuple = curvas.globalWeightToindex[i];
				if (w >= valueTuple.Item1 && w <= valueTuple.Item2)
				{
					num = valueTuple.Item3;
					num2 = Mathf.InverseLerp(valueTuple.Item1, valueTuple.Item2, w);
					break;
				}
			}
			if (num < 0)
			{
				throw new InvalidOperationException();
			}
			BezierCurve bezierCurve = curvas.curvas[num];
			ValueTuple<Transform, Transform> valueTuple2 = curvas.points[num];
			proyectedRecorridoPoint = CurveUtility.EvaluatePosition(bezierCurve, num2);
			proyectedRecorridoTangent = CurveUtility.EvaluateTangent(bezierCurve, num2);
			proyectedRecorridoCrossTangent = Vector3.Slerp(valueTuple2.Item1.TransformDirection(localCrossTangetVector), valueTuple2.Item2.TransformDirection(localCrossTangetVector), num2);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00027804 File Offset: 0x00025A04
		public Vector3 FindFarthestPointFrom(Vector3 form, out float worldWeight)
		{
			worldWeight = 0f;
			PuntosGuiasRecorridoCircular.Curvas curvas = this.m_Curvas;
			if (((curvas != null) ? curvas.curvas : null) == null)
			{
				return form;
			}
			Vector3 vector = form;
			float num = float.MinValue;
			for (int i = 0; i < this.m_Curvas.curvas.Length; i++)
			{
				BezierCurve bezierCurve = this.m_Curvas.curvas[i];
				ValueTuple<float, float, int> valueTuple = this.m_Curvas.globalWeightToindex[i];
				for (int j = 0; j <= 8; j++)
				{
					float num2 = (float)j / 8f;
					Vector3 vector2 = CurveUtility.EvaluatePosition(bezierCurve, num2);
					float sqrMagnitude = (form - vector2).sqrMagnitude;
					if (sqrMagnitude > num)
					{
						num = sqrMagnitude;
						vector = vector2;
						worldWeight = Mathf.Lerp(valueTuple.Item1, valueTuple.Item2, num2);
					}
				}
			}
			return vector;
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnDrawGizmosSelected()
		{
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000278DC File Offset: 0x00025ADC
		protected virtual void Clear()
		{
			if (this.m_start == null)
			{
				this.m_currentProyectedPoint = Vector3.zero;
				this.m_currentTangent = Vector3.forward;
				this.m_currentCrossTangent = Vector3.up;
			}
			else
			{
				this.m_currentProyectedPoint = this.m_start.position;
				this.m_currentTangent = this.m_start.TransformDirection(this.config.localForward);
				this.m_currentCrossTangent = this.m_start.TransformDirection(this.config.localUp);
			}
			this.m_currentRecorridoWeigth = 0f;
			this.m_lastWeigth = 0f;
			this.m_recorriendo = false;
		}

		// Token: 0x04000692 RID: 1682
		public PuntosGuiasRecorridoCircular.Config config = new PuntosGuiasRecorridoCircular.Config();

		// Token: 0x04000693 RID: 1683
		public PuntosGuiasRecorridoCircular.ConfigVelocityByTangentChange configVelocityByTangentChange = new PuntosGuiasRecorridoCircular.ConfigVelocityByTangentChange();

		// Token: 0x04000694 RID: 1684
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_start;

		// Token: 0x04000695 RID: 1685
		public List<Transform> puntos = new List<Transform>();

		// Token: 0x04000696 RID: 1686
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentRecorridoWeigth;

		// Token: 0x04000697 RID: 1687
		[ReadOnlyUI]
		[SerializeField]
		private float m_velModByTangets;

		// Token: 0x04000698 RID: 1688
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentRecorridoVelModByTangets;

		// Token: 0x04000699 RID: 1689
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentProyectedPoint;

		// Token: 0x0400069A RID: 1690
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentTangent;

		// Token: 0x0400069B RID: 1691
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentCrossTangent;

		// Token: 0x0400069C RID: 1692
		private float m_lastWeigth;

		// Token: 0x0400069D RID: 1693
		[ReadOnlyUI]
		[SerializeField]
		private bool m_recorriendo;

		// Token: 0x0400069E RID: 1694
		[ReadOnlyUI]
		[SerializeField]
		private bool m_paused;

		// Token: 0x0400069F RID: 1695
		[ReadOnlyUI]
		[SerializeField]
		private PuntosGuiasRecorridoCircular.Curvas m_Curvas;

		// Token: 0x040006A0 RID: 1696
		[ReadOnlyUI]
		[SerializeField]
		private bool m_init;

		// Token: 0x040006A1 RID: 1697
		private ICharacter m_character;

		// Token: 0x0200016F RID: 367
		// (Invoke) Token: 0x0600089F RID: 2207
		public delegate void OnWeigthChangedHandler(float last, float current, PuntosGuiasRecorridoCircular sender);

		// Token: 0x02000170 RID: 368
		[Serializable]
		public class Curvas
		{
			// Token: 0x060008A2 RID: 2210 RVA: 0x000279AC File Offset: 0x00025BAC
			public int GetCurveIndex(float worldLargo, out float startDistance, out float endDistance)
			{
				for (int i = 0; i < this.distanceToindex.Length; i++)
				{
					ValueTuple<float, float, int> valueTuple = this.distanceToindex[i];
					if (worldLargo >= valueTuple.Item1 && worldLargo <= valueTuple.Item2)
					{
						startDistance = valueTuple.Item1;
						endDistance = valueTuple.Item2;
						return i;
					}
				}
				startDistance = 0f;
				endDistance = 0f;
				return -1;
			}

			// Token: 0x060008A3 RID: 2211 RVA: 0x00027A0C File Offset: 0x00025C0C
			public float GetWorldWeight(float worldLargo)
			{
				float num;
				float num2;
				int curveIndex = this.GetCurveIndex(worldLargo, out num, out num2);
				if (curveIndex < 0)
				{
					return 1f;
				}
				float num3 = Mathf.InverseLerp(num, num2, worldLargo);
				ValueTuple<float, float, int> valueTuple = this.globalWeightToindex[curveIndex];
				float item = valueTuple.Item1;
				float item2 = valueTuple.Item2;
				return Mathf.Lerp(item, item2, num3);
			}

			// Token: 0x040006A2 RID: 1698
			[TupleElementNames(new string[] { "start", "end" })]
			public ValueTuple<Transform, Transform>[] points;

			// Token: 0x040006A3 RID: 1699
			public BezierCurve[] curvas;

			// Token: 0x040006A4 RID: 1700
			public DistanceToInterpolation[][] distanceToInterpolations;

			// Token: 0x040006A5 RID: 1701
			[TupleElementNames(new string[] { "startDistance", "endDistance", "index" })]
			public ValueTuple<float, float, int>[] distanceToindex;

			// Token: 0x040006A6 RID: 1702
			[TupleElementNames(new string[] { "startW", "endW", "index" })]
			public ValueTuple<float, float, int>[] globalWeightToindex;

			// Token: 0x040006A7 RID: 1703
			public float largo;
		}

		// Token: 0x02000171 RID: 369
		[Serializable]
		public class Config
		{
			// Token: 0x040006A8 RID: 1704
			public float velocidad = 1f;

			// Token: 0x040006A9 RID: 1705
			public float tangetDistanceW = 1f;

			// Token: 0x040006AA RID: 1706
			public float tangetDistanceMod = 0.333f;

			// Token: 0x040006AB RID: 1707
			public Vector3 localForward = Vector3.up;

			// Token: 0x040006AC RID: 1708
			public Vector3 localUp = Vector3.forward;

			// Token: 0x040006AD RID: 1709
			public Vector3 localStartTan = new Vector3(-0.5f, 1f, 0f);

			// Token: 0x040006AE RID: 1710
			public Vector3 locaEndTan = new Vector3(0.5f, -1f, 0f);
		}

		// Token: 0x02000172 RID: 370
		[Serializable]
		public class ConfigVelocityByTangentChange
		{
			// Token: 0x040006AF RID: 1711
			public float step = 0.075f;

			// Token: 0x040006B0 RID: 1712
			public float angleToMinVelMod = 180f;

			// Token: 0x040006B1 RID: 1713
			public float angleInPower = 3f;

			// Token: 0x040006B2 RID: 1714
			public float minVelMod = 0.01f;

			// Token: 0x040006B3 RID: 1715
			public float acceleration = 0.333f;

			// Token: 0x040006B4 RID: 1716
			public float deAcceleration = 2.25f;
		}
	}
}
