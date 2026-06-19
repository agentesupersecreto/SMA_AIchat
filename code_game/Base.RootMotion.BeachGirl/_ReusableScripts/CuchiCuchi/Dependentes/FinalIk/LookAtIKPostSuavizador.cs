using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000081 RID: 129
	[RequireComponent(typeof(LookAtIK))]
	[Obsolete("", true)]
	public class LookAtIKPostSuavizador : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000500 RID: 1280 RVA: 0x00018FE3 File Offset: 0x000171E3
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAt = base.GetComponent<LookAtIK>();
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00018FF8 File Offset: 0x000171F8
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			IKSolver iksolver = this.m_LookAt.GetIKSolver();
			iksolver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
			IKSolver iksolver2 = this.m_LookAt.GetIKSolver();
			iksolver2.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver2.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00019064 File Offset: 0x00017264
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			IKSolver iksolver = this.m_LookAt.GetIKSolver();
			iksolver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(iksolver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
			IKSolver iksolver2 = this.m_LookAt.GetIKSolver();
			iksolver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(iksolver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
			this.modificadorDeVelocidad.moded = 1f;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000190E0 File Offset: 0x000172E0
		private void Validar()
		{
			IKSolverLookAt.LookAtBone[] spine = this.m_LookAt.solver.spine;
			for (int i = 1; i < spine.Length; i++)
			{
				IKSolverLookAt.LookAtBone lookAtBone = spine[i - 1];
				if (spine[i].transform.parent != lookAtBone.transform)
				{
					throw new InvalidOperationException();
				}
			}
			if (this.m_LookAt.solver.head.transform.parent != spine[spine.Length - 1].transform)
			{
				throw new InvalidOperationException();
			}
			float num = 1f / (float)(spine.Length - 1);
			for (int j = 0; j < spine.Length; j++)
			{
				this.puntosSpine.Add(new LookAtIKPostSuavizador.Punto(spine[j].transform, num * (float)j, this.m_LookAt.solver.spineWeightCurve));
			}
			this.puntoHead = new LookAtIKPostSuavizador.Punto(this.m_LookAt.solver.head.transform, 1f, this.m_LookAt.solver.spineWeightCurve);
			this.validado = true;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000191F0 File Offset: 0x000173F0
		private void OnPreUpdate()
		{
			if (!this.m_LookAt.fixTransforms)
			{
				throw new InvalidOperationException();
			}
			if (!this.validado && this.m_LookAt.solver.IsValid())
			{
				this.Validar();
			}
			if (this.m_LookAt.solver.bodyWeight > 0f)
			{
				for (int i = 0; i < this.puntosSpine.Count; i++)
				{
					this.puntosSpine[i].SavePreUpdate();
				}
			}
			if (this.m_LookAt.solver.headWeight > 0f)
			{
				this.puntoHead.SavePreUpdate();
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00019290 File Offset: 0x00017490
		private void OnPostUpdate()
		{
			if (!this.validado)
			{
				return;
			}
			if (this.m_LookAt.solver.bodyWeight > 0f)
			{
				for (int i = 0; i < this.puntosSpine.Count; i++)
				{
					this.puntosSpine[i].Limitar(this.bodyVelocityMod * this.degreesPerSecond * Time.deltaTime * (this.normalizarConWieght ? this.m_LookAt.solver.bodyWeight : 1f) * this.modificadorDeVelocidad.total, this.normalizarConCurva, this.smoothEnds, this.debugPrint, this.angleToSmoothTerminando);
				}
			}
			if (this.m_LookAt.solver.headWeight > 0f)
			{
				this.puntoHead.Limitar(this.headVelocityMod * this.degreesPerSecond * Time.deltaTime * (this.normalizarConWieght ? this.m_LookAt.solver.headWeight : 1f) * this.modificadorDeVelocidad.total, this.normalizarConCurva, this.smoothEnds, this.debugPrint, this.angleToSmoothTerminando);
			}
			if (this.m_LookAt.solver.bodyWeight > 0f)
			{
				for (int j = 0; j < this.puntosSpine.Count; j++)
				{
					this.puntosSpine[j].SavePostUpdate();
				}
			}
			if (this.m_LookAt.solver.headWeight > 0f)
			{
				this.puntoHead.SavePostUpdate();
			}
			this.modificadorDeVelocidad.moded = 1f;
		}

		// Token: 0x0400034E RID: 846
		private LookAtIK m_LookAt;

		// Token: 0x0400034F RID: 847
		private bool validado;

		// Token: 0x04000350 RID: 848
		public bool debugPrint;

		// Token: 0x04000351 RID: 849
		private List<LookAtIKPostSuavizador.Punto> puntosSpine = new List<LookAtIKPostSuavizador.Punto>();

		// Token: 0x04000352 RID: 850
		private LookAtIKPostSuavizador.Punto puntoHead;

		// Token: 0x04000353 RID: 851
		public float bodyVelocityMod = 1f;

		// Token: 0x04000354 RID: 852
		public float headVelocityMod = 1f;

		// Token: 0x04000355 RID: 853
		public float degreesPerSecond = 120f;

		// Token: 0x04000356 RID: 854
		public ValorModificable modificadorDeVelocidad = new ValorModificable(1f);

		// Token: 0x04000357 RID: 855
		public bool smoothEnds = true;

		// Token: 0x04000358 RID: 856
		public float angleToSmoothTerminando = 20f;

		// Token: 0x04000359 RID: 857
		public bool normalizarConWieght;

		// Token: 0x0400035A RID: 858
		public bool normalizarConCurva;

		// Token: 0x02000177 RID: 375
		private class Punto
		{
			// Token: 0x06000C02 RID: 3074 RVA: 0x0003684E File Offset: 0x00034A4E
			public Punto(Transform transform, float curveTime, AnimationCurve curve)
			{
				this.transform = transform;
				this.curveTime = curveTime;
				this.curve = curve;
			}

			// Token: 0x06000C03 RID: 3075 RVA: 0x0003686B File Offset: 0x00034A6B
			public void SavePreUpdate()
			{
				this.preUpdateRotation = new Quaternion?(this.transform.localRotation);
			}

			// Token: 0x06000C04 RID: 3076 RVA: 0x00036884 File Offset: 0x00034A84
			public void Limitar(float maxDegreesDelta, bool usarCurva, bool smoothEnds, bool debug = false, float angleToSmoothEnd = 25f)
			{
				usarCurva = usarCurva && this.curve != null;
				if (this.lastFrameGivenRotation == null || this.preUpdateRotation == null)
				{
					this.transform.localRotation = this.preUpdateRotation.Value;
					return;
				}
				maxDegreesDelta = ((this.curveTime >= 1f || !usarCurva) ? maxDegreesDelta : (this.curve.Evaluate(this.curveTime) * maxDegreesDelta));
				float num = 1f;
				Quaternion localRotation = this.transform.localRotation;
				Quaternion quaternion = this.preUpdateRotation.Value * this.lastFrameGivenRotation.Value;
				if (debug)
				{
					MonoBehaviour.print(Quaternion.Angle(localRotation, quaternion));
				}
				if (smoothEnds)
				{
					float num2 = Quaternion.Angle(localRotation, quaternion);
					if (num2 <= angleToSmoothEnd)
					{
						num = Mathf.Clamp01(num2 / angleToSmoothEnd);
					}
				}
				Quaternion quaternion2 = Quaternion.RotateTowards(quaternion, this.transform.localRotation, maxDegreesDelta * num);
				this.transform.localRotation = quaternion2;
			}

			// Token: 0x06000C05 RID: 3077 RVA: 0x0003697C File Offset: 0x00034B7C
			public void SavePostUpdate()
			{
				this.lastFrameGivenRotation = new Quaternion?(Quaternion.Inverse(this.preUpdateRotation.Value) * this.transform.localRotation);
			}

			// Token: 0x06000C06 RID: 3078 RVA: 0x000369A9 File Offset: 0x00034BA9
			public void Clear()
			{
				this.lastFrameGivenRotation = null;
				this.preUpdateRotation = null;
			}

			// Token: 0x04000887 RID: 2183
			public readonly AnimationCurve curve;

			// Token: 0x04000888 RID: 2184
			public readonly float curveTime;

			// Token: 0x04000889 RID: 2185
			public readonly Transform transform;

			// Token: 0x0400088A RID: 2186
			public Quaternion? preUpdateRotation;

			// Token: 0x0400088B RID: 2187
			public Quaternion? lastFrameGivenRotation;
		}
	}
}
