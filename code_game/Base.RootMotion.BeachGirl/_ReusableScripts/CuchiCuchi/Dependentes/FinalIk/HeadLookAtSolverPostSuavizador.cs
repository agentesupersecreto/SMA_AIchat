using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000079 RID: 121
	[RequireComponent(typeof(HeadLookAtSolver))]
	public class HeadLookAtSolverPostSuavizador : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x00015AF5 File Offset: 0x00013CF5
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Solver = base.GetComponent<HeadLookAtSolver>();
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00015B09 File Offset: 0x00013D09
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Solver.onPostSolve += this.OnPostUpdate;
			this.m_Solver.onPreSolve += this.OnPreUpdate;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00015B40 File Offset: 0x00013D40
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_Solver.onPreSolve -= this.OnPreUpdate;
			this.m_Solver.onPostSolve -= this.OnPostUpdate;
			this.modificadorDeVelocidad.moded = 1f;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00015B92 File Offset: 0x00013D92
		private void Validar()
		{
			this.puntoHead = new HeadLookAtSolverPostSuavizador.Punto(this.m_Solver.head);
			this.validado = true;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00015BB1 File Offset: 0x00013DB1
		private void OnPreUpdate(HeadLookAtSolver solver)
		{
			if (!this.validado && this.m_Solver.IsValid())
			{
				this.Validar();
			}
			if (this.m_Solver.headWeight > 0f)
			{
				this.puntoHead.SavePreUpdate();
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00015BEC File Offset: 0x00013DEC
		private void OnPostUpdate(HeadLookAtSolver solvers)
		{
			if (!this.validado)
			{
				return;
			}
			if (this.m_Solver.headWeight > 0f)
			{
				this.puntoHead.Limitar(this.headVelocityMod * this.degreesPerSecond * Time.deltaTime * (this.normalizarConWieght ? this.m_Solver.headWeight : 1f) * this.modificadorDeVelocidad.total, this.smoothEnds, this.debugPrint, this.angleToSmoothTerminando);
			}
			if (this.m_Solver.headWeight > 0f)
			{
				this.puntoHead.SavePostUpdate();
			}
			this.modificadorDeVelocidad.moded = 1f;
		}

		// Token: 0x0400030D RID: 781
		private HeadLookAtSolver m_Solver;

		// Token: 0x0400030E RID: 782
		private bool validado;

		// Token: 0x0400030F RID: 783
		public bool debugPrint;

		// Token: 0x04000310 RID: 784
		private HeadLookAtSolverPostSuavizador.Punto puntoHead;

		// Token: 0x04000311 RID: 785
		public float headVelocityMod = 1f;

		// Token: 0x04000312 RID: 786
		public float degreesPerSecond = 40f;

		// Token: 0x04000313 RID: 787
		public ValorModificable modificadorDeVelocidad = new ValorModificable(1f);

		// Token: 0x04000314 RID: 788
		public bool smoothEnds = true;

		// Token: 0x04000315 RID: 789
		public float angleToSmoothTerminando = 6f;

		// Token: 0x04000316 RID: 790
		public bool normalizarConWieght;

		// Token: 0x02000169 RID: 361
		private class Punto
		{
			// Token: 0x06000BC5 RID: 3013 RVA: 0x00036079 File Offset: 0x00034279
			public Punto(Transform transform)
			{
				this.transform = transform;
			}

			// Token: 0x06000BC6 RID: 3014 RVA: 0x00036088 File Offset: 0x00034288
			public void SavePreUpdate()
			{
				this.preUpdateRotation = new Quaternion?(this.transform.localRotation);
			}

			// Token: 0x06000BC7 RID: 3015 RVA: 0x000360A0 File Offset: 0x000342A0
			public void Limitar(float maxDegreesDelta, bool smoothEnds, bool debug = false, float angleToSmoothEnd = 25f)
			{
				if (this.lastFrameGivenRotation == null || this.preUpdateRotation == null)
				{
					this.transform.localRotation = this.preUpdateRotation.Value;
					return;
				}
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

			// Token: 0x06000BC8 RID: 3016 RVA: 0x0003615E File Offset: 0x0003435E
			public void SavePostUpdate()
			{
				this.lastFrameGivenRotation = new Quaternion?(Quaternion.Inverse(this.preUpdateRotation.Value) * this.transform.localRotation);
			}

			// Token: 0x06000BC9 RID: 3017 RVA: 0x0003618B File Offset: 0x0003438B
			public void Clear()
			{
				this.lastFrameGivenRotation = null;
				this.preUpdateRotation = null;
			}

			// Token: 0x04000842 RID: 2114
			public readonly Transform transform;

			// Token: 0x04000843 RID: 2115
			public Quaternion? preUpdateRotation;

			// Token: 0x04000844 RID: 2116
			public Quaternion? lastFrameGivenRotation;
		}
	}
}
