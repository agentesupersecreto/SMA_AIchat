using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.Splines;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x02000173 RID: 371
	public abstract class PuntosGuiasRecorridoLinear : AplicableBehaviour
	{
		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060008A7 RID: 2215 RVA: 0x00027B38 File Offset: 0x00025D38
		// (remove) Token: 0x060008A8 RID: 2216 RVA: 0x00027B70 File Offset: 0x00025D70
		public event PuntosGuiasRecorridoLinear.OnWeigthChangedHandler weigthChanged;

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0000E0F9 File Offset: 0x0000C2F9
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeDynamicColliders);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00027BA5 File Offset: 0x00025DA5
		public Vector3 currentProyectedPoint
		{
			get
			{
				return this.m_currentProyectedPoint;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x00027BAD File Offset: 0x00025DAD
		public Quaternion currentRotationFromTangnts
		{
			get
			{
				return Quaternion.LookRotation(this.m_currentTangent, this.m_currentCrossTangent);
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x00027BC0 File Offset: 0x00025DC0
		public Vector3 currentTangent
		{
			get
			{
				return this.m_currentTangent;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x00027BC8 File Offset: 0x00025DC8
		public Vector3 currentCrossTangent
		{
			get
			{
				return this.m_currentCrossTangent;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00027BD0 File Offset: 0x00025DD0
		public float currentRecorridoWeigth
		{
			get
			{
				return this.m_currentRecorridoWeigth;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x00027BD8 File Offset: 0x00025DD8
		public bool recorriendo
		{
			get
			{
				return this.m_recorriendo;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00027BE0 File Offset: 0x00025DE0
		public bool paused
		{
			get
			{
				return this.m_paused;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x00027BE8 File Offset: 0x00025DE8
		public PuntosGuiasRecorridoCircular.Curvas curvas
		{
			get
			{
				return this.m_Curvas;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00027BF0 File Offset: 0x00025DF0
		public bool init
		{
			get
			{
				return this.m_init;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x00027BF8 File Offset: 0x00025DF8
		public ICharacter character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060008B4 RID: 2228 RVA: 0x00027C00 File Offset: 0x00025E00
		// (remove) Token: 0x060008B5 RID: 2229 RVA: 0x00027C38 File Offset: 0x00025E38
		public event Action updatingCurvas;

		// Token: 0x060008B6 RID: 2230 RVA: 0x000260E0 File Offset: 0x000242E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00027C6D File Offset: 0x00025E6D
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00024829 File Offset: 0x00022A29
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00027C82 File Offset: 0x00025E82
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00026EF4 File Offset: 0x000250F4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00027C94 File Offset: 0x00025E94
		public void Init(PuntosGuiasRecorridoLinear.Config Config, params Transform[] ExtraPuntos)
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
			this.m_end = this.puntos.Last<Transform>();
			this.ReInitCurvas();
			this.Clear();
			PuntosGuiasRecorridoLinear.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
			this.UpdateTargetTransform();
			this.m_init = true;
			base.ManualStart();
		}

		// Token: 0x060008BC RID: 2236
		public abstract void UpdateTargetTransform();

		// Token: 0x060008BD RID: 2237 RVA: 0x00027D64 File Offset: 0x00025F64
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

		// Token: 0x060008BE RID: 2238 RVA: 0x00027DF0 File Offset: 0x00025FF0
		private void UpdateCurvas()
		{
			Action action = this.updatingCurvas;
			if (action != null)
			{
				action();
			}
			Transform transform = null;
			Transform transform2 = this.puntos[0];
			float num = 0f;
			float num2 = 0f;
			this.m_Curvas.largo = 0f;
			for (int i = 1; i < this.puntos.Count; i++)
			{
				int num3 = i - 1;
				Transform transform3 = this.puntos[i];
				Vector3 vector = transform3.position - transform2.position;
				float magnitude = vector.magnitude;
				Vector3 vector2 = transform3.TransformDirection(this.config.localForward * Mathf.LerpUnclamped(1f, magnitude, this.config.tangetDistanceW) * this.config.tangetDistanceMod);
				vector2 = (-vector2 + -vector * this.config.startEndDistanceMod) / 2f;
				Vector3 vector3 = ((transform == null) ? Vector3.zero : transform.TransformDirection(this.config.localForward * Mathf.LerpUnclamped(1f, magnitude, this.config.tangetDistanceW) * this.config.tangetDistanceMod));
				vector3 = (vector3 + vector * this.config.startEndDistanceMod) / 2f;
				BezierCurve bezierCurve = BezierCurve.FromTangent(transform2.position, vector3, transform3.position, vector2);
				this.m_Curvas.curvas[num3] = bezierCurve;
				this.m_Curvas.points[num3] = new ValueTuple<Transform, Transform>(transform2, transform3);
				transform = transform2;
				transform2 = transform3;
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

		// Token: 0x060008BF RID: 2239 RVA: 0x000280B6 File Offset: 0x000262B6
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

		// Token: 0x060008C0 RID: 2240 RVA: 0x000280E3 File Offset: 0x000262E3
		public void PauseRecorrido()
		{
			if (!this.m_recorriendo)
			{
				throw new InvalidOperationException();
			}
			this.m_paused = true;
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x000280FA File Offset: 0x000262FA
		public void StopRecorrido()
		{
			if (!this.m_recorriendo)
			{
				throw new InvalidOperationException();
			}
			this.m_recorriendo = false;
			this.m_paused = false;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00028118 File Offset: 0x00026318
		public void UpdateTo(float W, bool updateTargetTransform)
		{
			this.recorridoWeigthTarget = Mathf.Clamp(W, this.minWeigth, 1f);
			this.m_currentRecorridoWeigth = this.recorridoWeigthTarget;
			this.UpdateCurvas();
			PuntosGuiasRecorridoLinear.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
			if (updateTargetTransform)
			{
				this.UpdateTargetTransform();
			}
			this.CheckWeigthChanged();
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00028198 File Offset: 0x00026398
		public void Evaluate(float W, out Vector3 position, out Quaternion rotation)
		{
			W = Mathf.Clamp(W, this.minWeigth, 1f);
			Vector3 vector;
			Vector3 vector2;
			PuntosGuiasRecorridoLinear.GetTrayecto(W, this.m_Curvas, this.config.localForward, this.config.localUp, out position, out vector, out vector2);
			rotation = Quaternion.LookRotation(vector, vector2);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x000281EC File Offset: 0x000263EC
		public void ResetRecorrido()
		{
			this.Clear();
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000281F4 File Offset: 0x000263F4
		public override void OnUpdateEvent2()
		{
			this.minWeigth = Mathf.Clamp(this.minWeigth, 0f, 1f);
			this.recorridoWeigthTarget = Mathf.Clamp(this.recorridoWeigthTarget, this.minWeigth, 1f);
			this.UpdateCurvas();
			if (this.m_paused)
			{
				PuntosGuiasRecorridoLinear.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
				return;
			}
			try
			{
				if (!this.m_recorriendo)
				{
					this.m_currentRecorridoWeigth = Mathf.MoveTowards(this.m_currentRecorridoWeigth, this.recorridoWeigthTarget, Time.deltaTime * this.config.velocidad * 2f);
					PuntosGuiasRecorridoLinear.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
					if (this.m_currentRecorridoWeigth == this.recorridoWeigthTarget || this.m_currentRecorridoWeigth.AlmostEqualV2(this.recorridoWeigthTarget, 1E-45f))
					{
						base.enabled = false;
					}
				}
				else
				{
					this.m_currentRecorridoWeigth = Mathf.Clamp(this.m_currentRecorridoWeigth, this.minWeigth, 1f);
					if (this.m_subiendo)
					{
						this.recorridoWeigthTarget = 1f;
						if (this.m_currentRecorridoWeigth >= 1f || this.m_currentRecorridoWeigth.AlmostEqualV2(1f, 1E-45f))
						{
							this.recorridoWeigthTarget = this.minWeigth;
							this.m_currentRecorridoWeigth = 1f;
							this.m_subiendo = false;
						}
					}
					else
					{
						this.recorridoWeigthTarget = 0f;
						if (this.m_currentRecorridoWeigth <= this.minWeigth || this.m_currentRecorridoWeigth.AlmostEqualV2(this.minWeigth, 1E-45f))
						{
							this.recorridoWeigthTarget = 1f;
							this.m_currentRecorridoWeigth = this.minWeigth;
							this.m_subiendo = true;
						}
					}
					this.m_currentRecorridoWeigth = Mathf.MoveTowards(this.m_currentRecorridoWeigth, this.recorridoWeigthTarget, Time.deltaTime * this.config.velocidad);
					PuntosGuiasRecorridoLinear.GetTrayecto(this.m_currentRecorridoWeigth, this.m_Curvas, this.config.localForward, this.config.localUp, out this.m_currentProyectedPoint, out this.m_currentTangent, out this.m_currentCrossTangent);
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

		// Token: 0x060008C6 RID: 2246 RVA: 0x00028480 File Offset: 0x00026680
		private void CheckWeigthChanged()
		{
			if (this.m_lastWeigth != this.m_currentRecorridoWeigth)
			{
				this.OnWeigthChanged(this.m_lastWeigth, this.m_currentRecorridoWeigth);
			}
			this.m_lastWeigth = this.m_currentRecorridoWeigth;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000284AE File Offset: 0x000266AE
		private void OnWeigthChanged(float last, float current)
		{
			PuntosGuiasRecorridoLinear.OnWeigthChangedHandler onWeigthChangedHandler = this.weigthChanged;
			if (onWeigthChangedHandler == null)
			{
				return;
			}
			onWeigthChangedHandler(last, current, this);
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x000284C4 File Offset: 0x000266C4
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

		// Token: 0x060008C9 RID: 2249 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnDrawGizmosSelected()
		{
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000285AC File Offset: 0x000267AC
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
			this.m_paused = false;
			this.m_subiendo = true;
		}

		// Token: 0x040006B6 RID: 1718
		public PuntosGuiasRecorridoLinear.Config config = new PuntosGuiasRecorridoLinear.Config();

		// Token: 0x040006B7 RID: 1719
		public float recorridoWeigthTarget;

		// Token: 0x040006B8 RID: 1720
		public float minWeigth;

		// Token: 0x040006B9 RID: 1721
		[NonSerialized]
		public readonly float maxWeigth = 1f;

		// Token: 0x040006BA RID: 1722
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_start;

		// Token: 0x040006BB RID: 1723
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_end;

		// Token: 0x040006BC RID: 1724
		public List<Transform> puntos = new List<Transform>();

		// Token: 0x040006BD RID: 1725
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentRecorridoWeigth;

		// Token: 0x040006BE RID: 1726
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentProyectedPoint;

		// Token: 0x040006BF RID: 1727
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentTangent;

		// Token: 0x040006C0 RID: 1728
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_currentCrossTangent;

		// Token: 0x040006C1 RID: 1729
		private float m_lastWeigth;

		// Token: 0x040006C2 RID: 1730
		[ReadOnlyUI]
		[SerializeField]
		private bool m_recorriendo;

		// Token: 0x040006C3 RID: 1731
		[ReadOnlyUI]
		[SerializeField]
		private bool m_paused;

		// Token: 0x040006C4 RID: 1732
		[ReadOnlyUI]
		[SerializeField]
		private PuntosGuiasRecorridoCircular.Curvas m_Curvas;

		// Token: 0x040006C5 RID: 1733
		[ReadOnlyUI]
		[SerializeField]
		private bool m_init;

		// Token: 0x040006C6 RID: 1734
		private ICharacter m_character;

		// Token: 0x040006C7 RID: 1735
		[ReadOnlyUI]
		[SerializeField]
		private bool m_subiendo;

		// Token: 0x02000174 RID: 372
		// (Invoke) Token: 0x060008CD RID: 2253
		public delegate void OnWeigthChangedHandler(float last, float current, PuntosGuiasRecorridoLinear sender);

		// Token: 0x02000175 RID: 373
		[Serializable]
		public class Config
		{
			// Token: 0x040006C9 RID: 1737
			public float velocidad = 1f;

			// Token: 0x040006CA RID: 1738
			public float tangetDistanceW = 1f;

			// Token: 0x040006CB RID: 1739
			public float tangetDistanceMod = 0.333f;

			// Token: 0x040006CC RID: 1740
			public float startEndDistanceMod = 0.333f;

			// Token: 0x040006CD RID: 1741
			public Vector3 localForward = Vector3.up;

			// Token: 0x040006CE RID: 1742
			public Vector3 localUp = Vector3.forward;
		}
	}
}
