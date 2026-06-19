using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000080 RID: 128
	[RequireComponent(typeof(LookAtIK))]
	[RequireComponent(typeof(LookAtManagerV2))]
	[Obsolete("", true)]
	public class LookAtIKModificadores : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060004F5 RID: 1269 RVA: 0x000182E3 File Offset: 0x000164E3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtManagerV2 = base.GetComponent<LookAtManagerV2>();
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00018303 File Offset: 0x00016503
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_LookAtManagerV2.targetCalculed += this.M_LookAtManagerV2_targetCalculado;
			this.m_LookAtManagerV2.lookAtIKUpdated += this.M_LookAtManagerV2_Updated;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00018339 File Offset: 0x00016539
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_LookAtManagerV2.targetCalculed -= this.M_LookAtManagerV2_targetCalculado;
			this.m_LookAtManagerV2.lookAtIKUpdated -= this.M_LookAtManagerV2_Updated;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00018370 File Offset: 0x00016570
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_defaults.body = this.m_LookAtIK.solver.bodyWeight;
			this.m_defaults.head = this.m_LookAtIK.solver.headWeight;
			this.m_defaults.clampHead = this.m_LookAtIK.solver.clampWeightHead;
			this.m_defaults.clampBody = this.m_LookAtIK.solver.clampWeight;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x000183F0 File Offset: 0x000165F0
		private void M_LookAtManagerV2_targetCalculado(LookAtManagerV2.TargetCalculadoEventArgs args)
		{
			if (this.config.correcionDeAlturaCuandoTargetAtras <= 0f)
			{
				this.m_internalWeight.ZeroSmooth(this.config.SetModificadoresVelocity * 3f);
				return;
			}
			Vector3 headPosition = args.vectoresConAnimacionYPrimerIk.headPosition;
			Vector3 normalized = args.vectoresConAnimacionYPrimerIk.promedioForward.normalized;
			Vector3 vector = args.vectoresConAnimacionYPrimerIk.promedioUp.normalized;
			Vector3 normalized2 = (args.IKPosition - headPosition).normalized;
			if (Vector3.Dot(normalized, normalized2) >= 0f)
			{
				this.m_internalWeight.ZeroSmooth(this.config.SetModificadoresVelocity * 3f);
				return;
			}
			Quaternion quaternion = Quaternion.LookRotation(normalized, vector);
			float num;
			float num2;
			Math3dTvalle.GetDirectionAngle(out num, out num2, quaternion, normalized2, false);
			if (num2 > 170f)
			{
				vector = Vector3.RotateTowards(vector, normalized, this.config.horizontalFixAngle, 0f);
			}
			bool debugDrawcorrecionDeAltura = this.config.debugDrawcorrecionDeAltura;
			Vector3 vector2 = Math3d.ProjectPointOnPlane(vector, headPosition, args.IKPosition);
			float num3 = Vector3.Dot(normalized, (vector2 - headPosition).normalized);
			if (num3 > 0f)
			{
				this.m_internalWeight.ZeroSmooth(this.config.SetModificadoresVelocity * 3f);
				return;
			}
			num3 *= -1f;
			this.m_internalWeight.SetSmooth(1f, this.config.SetModificadoresVelocity * 3f, true, 0.25f);
			float num4 = this.config.correcionDeAlturaCuandoTargetAtras * this.m_internalWeight.valor;
			float num5 = 1f;
			if (num > 0f)
			{
				num5 = 1f - Mathf.InverseLerp(30f, 90f, num);
				num5 = num5.OutPow(2f);
			}
			num4 *= num5;
			if (num3 < this.config.correcionDeAlturaCuandoTargetMaxDot)
			{
				num4 *= Mathf.InverseLerp(0f, this.config.correcionDeAlturaCuandoTargetMaxDot, num3);
			}
			if (num4 < 1f)
			{
				vector2 = Vector3.Slerp(args.IKPosition, vector2, num4);
			}
			args.IKPosition = vector2;
			bool debugDrawcorrecionDeAltura2 = this.config.debugDrawcorrecionDeAltura;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0001860F File Offset: 0x0001680F
		private void M_LookAtManagerV2_Updated(LookAtManagerV2 obj)
		{
			this.UpdateWieghts();
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00018618 File Offset: 0x00016818
		public void UpdateWieghts()
		{
			this.UpdateWieghtsAtras();
			this.UpdateWieghtsVertical();
			this.UpdateWieghtsAlFrente();
			this.m_LookAtIK.solver.bodyWeight = Mathf.Clamp01(this.m_defaults.body * this.m_abajoWeightsMods.body * this.m_muyAbajoWeightsMods.body * this.m_arribaWeightsMods.body * this.m_muyArribaWeightsMods.body * this.m_atrasWeightsMods.body * this.m_justoAlFrenteWeightsMods.body);
			this.m_LookAtIK.solver.headWeight = Mathf.Clamp01(this.m_defaults.head * this.m_abajoWeightsMods.head * this.m_muyAbajoWeightsMods.head * this.m_arribaWeightsMods.head * this.m_muyArribaWeightsMods.head * this.m_atrasWeightsMods.head * this.m_justoAlFrenteWeightsMods.head);
			this.m_LookAtIK.solver.clampWeight = Mathf.Clamp01(this.m_defaults.clampBody * this.m_muyAbajoWeightsMods.clampBody * this.m_muyArribaWeightsMods.clampBody);
			this.m_LookAtIK.solver.clampWeightHead = Mathf.Clamp01(this.m_defaults.clampHead * this.m_muyAbajoWeightsMods.clampHead * this.m_muyArribaWeightsMods.clampHead);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00018778 File Offset: 0x00016978
		private void UpdateWieghtsAlFrente()
		{
			float num = Mathf.Abs(this.m_LookAtManagerV2.targetHorizontalAngle);
			float head = this.config.modificadores.mirandoJustoAlFrente.modificador.head;
			float body = this.config.modificadores.mirandoJustoAlFrente.modificador.body;
			float head2 = this.config.modificadores.mirandoJustoAlFrente.anguloParaAplicarMod.head;
			float body2 = this.config.modificadores.mirandoJustoAlFrente.anguloParaAplicarMod.body;
			float num2 = Mathf.Abs(this.m_LookAtManagerV2.targetVerticalAngle);
			float num3 = Mathf.InverseLerp(head2, head2 * 2f, num2);
			float num4 = Mathf.InverseLerp(body2, body2 * 2f, num2);
			float num5 = Mathf.Lerp(num / head2, 1f, num3);
			float num6 = Mathf.Lerp(num / body2, 1f, num4);
			this.m_justoAlFrenteWeightsMods.SetSmoothHead(Mathf.Lerp(head, 1f, num5), this.config.SetModificadoresVelocity, true, 0.25f);
			this.m_justoAlFrenteWeightsMods.SetSmoothBody(Mathf.Lerp(body, 1f, num6), this.config.SetModificadoresVelocity, true, 0.25f);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x000188A8 File Offset: 0x00016AA8
		private void UpdateWieghtsVertical()
		{
			float num = Mathf.Abs(this.m_LookAtManagerV2.targetVerticalAngle);
			if (num > 90f)
			{
				this.m_abajoWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
				this.m_arribaWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
				return;
			}
			if (this.m_LookAtManagerV2.targetVerticalAngle >= 0f)
			{
				if (this.m_LookAtManagerV2.targetVerticalAngle > 0f)
				{
					this.m_abajoWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
					this.m_muyAbajoWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
					this.m_arribaWeightsMods.SetSmoothHead(Mathf.Lerp(1f, this.config.modificadores.mirandoArriba.modificador.head, num / this.config.modificadores.mirandoArriba.anguloParaAplicarMod.head), this.config.SetModificadoresVelocity, true, 0.25f);
					this.m_arribaWeightsMods.SetSmoothBody(Mathf.Lerp(1f, this.config.modificadores.mirandoArriba.modificador.body, num / this.config.modificadores.mirandoArriba.anguloParaAplicarMod.body), this.config.SetModificadoresVelocity, true, 0.25f);
					if (this.m_LookAtManagerV2.targetVerticalAngle > 40f)
					{
						this.m_muyArribaWeightsMods.SetSmoothHead(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyArriba.modificador.head, (num - 40f) / this.config.modificadores.mirandoMuyArriba.anguloParaAplicarMod.head), this.config.SetModificadoresVelocity, true, 0.25f);
						this.m_muyArribaWeightsMods.SetSmoothBody(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyArriba.modificador.body, (num - 40f) / this.config.modificadores.mirandoMuyArriba.anguloParaAplicarMod.body), this.config.SetModificadoresVelocity, true, 0.25f);
						this.m_muyArribaWeightsMods.SetSmoothClampHead(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyArriba.modificador.clampHead, (num - 40f) / this.config.modificadores.mirandoMuyArriba.anguloParaAplicarMod.head), this.config.SetModificadoresVelocity * 1.5f, true, 0.25f);
						this.m_muyArribaWeightsMods.SetSmoothClampBody(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyArriba.modificador.clampBody, (num - 40f) / this.config.modificadores.mirandoMuyArriba.anguloParaAplicarMod.body), this.config.SetModificadoresVelocity * 1.5f, true, 0.25f);
						return;
					}
					this.m_muyArribaWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
				}
				return;
			}
			this.m_arribaWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
			this.m_muyArribaWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
			this.m_abajoWeightsMods.SetSmoothHead(Mathf.Lerp(1f, this.config.modificadores.mirandoAbajo.modificador.head, num / this.config.modificadores.mirandoAbajo.anguloParaAplicarMod.head), this.config.SetModificadoresVelocity, true, 0.25f);
			this.m_abajoWeightsMods.SetSmoothBody(Mathf.Lerp(1f, this.config.modificadores.mirandoAbajo.modificador.body, num / this.config.modificadores.mirandoAbajo.anguloParaAplicarMod.body), this.config.SetModificadoresVelocity, true, 0.25f);
			if (this.m_LookAtManagerV2.targetVerticalAngle < -40f)
			{
				this.m_muyAbajoWeightsMods.SetSmoothHead(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyAbajo.modificador.head, (num - 40f) / this.config.modificadores.mirandoMuyAbajo.anguloParaAplicarMod.head), this.config.SetModificadoresVelocity, true, 0.25f);
				this.m_muyAbajoWeightsMods.SetSmoothBody(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyAbajo.modificador.body, (num - 40f) / this.config.modificadores.mirandoMuyAbajo.anguloParaAplicarMod.body), this.config.SetModificadoresVelocity, true, 0.25f);
				this.m_muyAbajoWeightsMods.SetSmoothClampHead(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyAbajo.modificador.clampHead, (num - 40f) / this.config.modificadores.mirandoMuyAbajo.anguloParaAplicarMod.head), this.config.SetModificadoresVelocity * 1.5f, true, 0.25f);
				this.m_muyAbajoWeightsMods.SetSmoothClampBody(Mathf.Lerp(1f, this.config.modificadores.mirandoMuyAbajo.modificador.clampBody, (num - 40f) / this.config.modificadores.mirandoMuyAbajo.anguloParaAplicarMod.body), this.config.SetModificadoresVelocity * 1.5f, true, 0.25f);
				return;
			}
			this.m_muyAbajoWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00018E70 File Offset: 0x00017070
		private void UpdateWieghtsAtras()
		{
			float num = Mathf.Abs(this.m_LookAtManagerV2.targetHorizontalAngle);
			if (num < 90f)
			{
				this.m_atrasWeightsMods.ResetSmooth(this.config.SetModificadoresVelocity);
				return;
			}
			float num2 = num - 90f;
			float num3 = this.config.modificadores.mirandoAtras.modificador.head;
			float num4 = this.config.modificadores.mirandoAtras.modificador.body;
			num3 = Mathf.Lerp(1f, num3, num2 / this.config.modificadores.mirandoAtras.anguloParaAplicarMod.head);
			num4 = Mathf.Lerp(1f, num4, num2 / this.config.modificadores.mirandoAtras.anguloParaAplicarMod.body);
			this.m_atrasWeightsMods.SetSmoothHead(num3, this.config.SetModificadoresVelocity, true, 0.25f);
			this.m_atrasWeightsMods.SetSmoothBody(num4, this.config.SetModificadoresVelocity, true, 0.25f);
		}

		// Token: 0x04000343 RID: 835
		[SerializeField]
		private SmoothWeight m_internalWeight;

		// Token: 0x04000344 RID: 836
		[SerializeField]
		private LookAtIKModificadores.WeightsClamped m_defaults = new LookAtIKModificadores.WeightsClamped();

		// Token: 0x04000345 RID: 837
		[SerializeField]
		private LookAtIKModificadores.Weights m_atrasWeightsMods = new LookAtIKModificadores.Weights();

		// Token: 0x04000346 RID: 838
		[SerializeField]
		private LookAtIKModificadores.Weights m_arribaWeightsMods = new LookAtIKModificadores.Weights();

		// Token: 0x04000347 RID: 839
		[SerializeField]
		private LookAtIKModificadores.Weights m_abajoWeightsMods = new LookAtIKModificadores.Weights();

		// Token: 0x04000348 RID: 840
		[SerializeField]
		private LookAtIKModificadores.WeightsClamped m_muyAbajoWeightsMods = new LookAtIKModificadores.WeightsClamped();

		// Token: 0x04000349 RID: 841
		[SerializeField]
		private LookAtIKModificadores.WeightsClamped m_muyArribaWeightsMods = new LookAtIKModificadores.WeightsClamped();

		// Token: 0x0400034A RID: 842
		[SerializeField]
		private LookAtIKModificadores.Weights m_justoAlFrenteWeightsMods = new LookAtIKModificadores.Weights();

		// Token: 0x0400034B RID: 843
		public LookAtIKModificadores.Config config = new LookAtIKModificadores.Config();

		// Token: 0x0400034C RID: 844
		private LookAtIK m_LookAtIK;

		// Token: 0x0400034D RID: 845
		private LookAtManagerV2 m_LookAtManagerV2;

		// Token: 0x02000174 RID: 372
		[Serializable]
		public class Config
		{
			// Token: 0x0400087C RID: 2172
			[Range(0f, 1f)]
			public float correcionDeAlturaCuandoTargetAtras = 1f;

			// Token: 0x0400087D RID: 2173
			[Range(0f, 1f)]
			public float correcionDeAlturaCuandoTargetMaxDot = 0.25f;

			// Token: 0x0400087E RID: 2174
			public bool debugDrawcorrecionDeAltura;

			// Token: 0x0400087F RID: 2175
			[Range(0f, 1000f)]
			public float SetModificadoresVelocity = 0.5f;

			// Token: 0x04000880 RID: 2176
			public float horizontalFixAngle = 0.08f;

			// Token: 0x04000881 RID: 2177
			public LookAtIKModificadores.Config.Modificadores modificadores = new LookAtIKModificadores.Config.Modificadores();

			// Token: 0x020001E4 RID: 484
			[Serializable]
			public class Modificadores
			{
				// Token: 0x04000A34 RID: 2612
				public LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar mirandoJustoAlFrente = new LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar
				{
					anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 25f,
						body = 25f
					},
					modificador = new LookAtIKModificadores.Weights
					{
						head = 0.65f,
						body = 0.65f
					}
				};

				// Token: 0x04000A35 RID: 2613
				public LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar mirandoAtras = new LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar
				{
					anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 25f,
						body = 25f
					},
					modificador = new LookAtIKModificadores.Weights
					{
						head = 1f,
						body = 1f
					}
				};

				// Token: 0x04000A36 RID: 2614
				public LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar mirandoArriba = new LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar
				{
					anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 15f,
						body = 15f
					},
					modificador = new LookAtIKModificadores.Weights
					{
						head = 0.85f,
						body = 0.85f
					}
				};

				// Token: 0x04000A37 RID: 2615
				public LookAtIKModificadores.Config.Modificadores.ModificadorAngleParClaped mirandoMuyArriba = new LookAtIKModificadores.Config.Modificadores.ModificadorAngleParClaped
				{
					anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 25f,
						body = 25f
					},
					modificador = new LookAtIKModificadores.WeightsClamped
					{
						head = 1.333f,
						body = 1.333f,
						clampBody = 1f,
						clampHead = 1f
					}
				};

				// Token: 0x04000A38 RID: 2616
				public LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar mirandoAbajo = new LookAtIKModificadores.Config.Modificadores.ModificadorAnglePar
				{
					anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 25f,
						body = 25f
					},
					modificador = new LookAtIKModificadores.Weights
					{
						head = 1.1f,
						body = 1.1f
					}
				};

				// Token: 0x04000A39 RID: 2617
				public LookAtIKModificadores.Config.Modificadores.ModificadorAngleParClaped mirandoMuyAbajo = new LookAtIKModificadores.Config.Modificadores.ModificadorAngleParClaped
				{
					anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 25f,
						body = 25f
					},
					modificador = new LookAtIKModificadores.WeightsClamped
					{
						head = 1.1f,
						body = 1.1f,
						clampBody = 1f,
						clampHead = 1f
					}
				};

				// Token: 0x020001EF RID: 495
				[Serializable]
				public class ModificadorAnglePar
				{
					// Token: 0x04000A68 RID: 2664
					public LookAtIKModificadores.Weights modificador = new LookAtIKModificadores.Weights
					{
						head = 1f,
						body = 1f
					};

					// Token: 0x04000A69 RID: 2665
					public LookAtIKModificadores.Weights anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 20f,
						body = 20f
					};
				}

				// Token: 0x020001F0 RID: 496
				[Serializable]
				public class ModificadorAngleParClaped
				{
					// Token: 0x04000A6A RID: 2666
					public LookAtIKModificadores.WeightsClamped modificador = new LookAtIKModificadores.WeightsClamped
					{
						head = 1f,
						body = 1f
					};

					// Token: 0x04000A6B RID: 2667
					public LookAtIKModificadores.Weights anguloParaAplicarMod = new LookAtIKModificadores.Weights
					{
						head = 20f,
						body = 20f
					};
				}
			}
		}

		// Token: 0x02000175 RID: 373
		[Serializable]
		public class WeightsClamped : LookAtIKModificadores.Weights
		{
			// Token: 0x17000241 RID: 577
			// (get) Token: 0x06000BED RID: 3053 RVA: 0x00036555 File Offset: 0x00034755
			// (set) Token: 0x06000BEE RID: 3054 RVA: 0x0003655D File Offset: 0x0003475D
			public float clampBody
			{
				get
				{
					return this.m_clampBody;
				}
				set
				{
					this.m_clampBody = value;
				}
			}

			// Token: 0x17000242 RID: 578
			// (get) Token: 0x06000BEF RID: 3055 RVA: 0x00036566 File Offset: 0x00034766
			// (set) Token: 0x06000BF0 RID: 3056 RVA: 0x0003656E File Offset: 0x0003476E
			public float clampHead
			{
				get
				{
					return this.m_clampHead;
				}
				set
				{
					this.m_clampHead = value;
				}
			}

			// Token: 0x06000BF1 RID: 3057 RVA: 0x00036578 File Offset: 0x00034778
			public void SetSmoothClampBody(float value, float velocity, bool smoothEnds = true, float distanceToSmooth = 0.25f)
			{
				float num = 1f;
				if (smoothEnds)
				{
					num = Mathf.Clamp01(Mathf.Abs(this.clampBody - value) / distanceToSmooth).InPow(1.2f);
				}
				this.clampBody = Mathf.MoveTowards(this.clampBody, value, Time.deltaTime * velocity * num);
			}

			// Token: 0x06000BF2 RID: 3058 RVA: 0x000365CC File Offset: 0x000347CC
			public void SetSmoothClampHead(float value, float velocity, bool smoothEnds = true, float distanceToSmooth = 0.25f)
			{
				float num = 1f;
				if (smoothEnds)
				{
					num = Mathf.Clamp01(Mathf.Abs(this.clampHead - value) / distanceToSmooth).InPow(1.2f);
				}
				this.clampHead = Mathf.MoveTowards(this.clampHead, value, Time.deltaTime * velocity * num);
			}

			// Token: 0x06000BF3 RID: 3059 RVA: 0x00036620 File Offset: 0x00034820
			public override void ResetSmooth(float velocity)
			{
				base.ResetSmooth(velocity);
				if (this.clampBody != 1f)
				{
					this.clampBody = Mathf.MoveTowards(this.clampBody, 1f, Time.deltaTime * velocity);
				}
				if (this.clampHead != 1f)
				{
					this.clampHead = Mathf.MoveTowards(this.clampHead, 1f, Time.deltaTime * velocity);
				}
			}

			// Token: 0x06000BF4 RID: 3060 RVA: 0x00036688 File Offset: 0x00034888
			public override void Reset()
			{
				base.Reset();
				this.clampBody = 1f;
				this.clampHead = 1f;
			}

			// Token: 0x04000882 RID: 2178
			[SerializeField]
			[Range(0f, 10f)]
			private float m_clampBody = 1f;

			// Token: 0x04000883 RID: 2179
			[SerializeField]
			[Range(0f, 10f)]
			private float m_clampHead = 1f;
		}

		// Token: 0x02000176 RID: 374
		[Serializable]
		public class Weights
		{
			// Token: 0x17000243 RID: 579
			// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x000366C4 File Offset: 0x000348C4
			// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x000366CC File Offset: 0x000348CC
			public float head
			{
				get
				{
					return this.m_head;
				}
				set
				{
					this.m_head = value;
				}
			}

			// Token: 0x17000244 RID: 580
			// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x000366D5 File Offset: 0x000348D5
			// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x000366DD File Offset: 0x000348DD
			public float body
			{
				get
				{
					return this.m_body;
				}
				set
				{
					this.m_body = value;
				}
			}

			// Token: 0x17000245 RID: 581
			// (get) Token: 0x06000BFA RID: 3066 RVA: 0x000366E6 File Offset: 0x000348E6
			// (set) Token: 0x06000BFB RID: 3067 RVA: 0x000366EE File Offset: 0x000348EE
			[Obsolete]
			public float eyes
			{
				get
				{
					return this.m_eyes;
				}
				set
				{
					this.m_eyes = value;
				}
			}

			// Token: 0x06000BFC RID: 3068 RVA: 0x000366F7 File Offset: 0x000348F7
			public LookAtIKModificadores.Weights Copia()
			{
				return (LookAtIKModificadores.Weights)base.MemberwiseClone();
			}

			// Token: 0x06000BFD RID: 3069 RVA: 0x00036704 File Offset: 0x00034904
			public void SetSmoothHead(float value, float velocity, bool smoothEnds = true, float distanceToSmooth = 0.25f)
			{
				float num = 1f;
				if (smoothEnds)
				{
					num = Mathf.Clamp01(Mathf.Abs(this.head - value) / distanceToSmooth).InPow(1.2f);
				}
				this.head = Mathf.MoveTowards(this.head, value, Time.deltaTime * velocity * num);
			}

			// Token: 0x06000BFE RID: 3070 RVA: 0x00036758 File Offset: 0x00034958
			public void SetSmoothBody(float value, float velocity, bool smoothEnds = true, float distanceToSmooth = 0.25f)
			{
				float num = 1f;
				if (smoothEnds)
				{
					num = Mathf.Clamp01(Mathf.Abs(this.body - value) / distanceToSmooth).InPow(1.2f);
				}
				this.body = Mathf.MoveTowards(this.body, value, Time.deltaTime * velocity * num);
			}

			// Token: 0x06000BFF RID: 3071 RVA: 0x000367AC File Offset: 0x000349AC
			public virtual void ResetSmooth(float velocity)
			{
				if (this.head != 1f)
				{
					this.head = Mathf.MoveTowards(this.head, 1f, Time.deltaTime * velocity);
				}
				if (this.body != 1f)
				{
					this.body = Mathf.MoveTowards(this.body, 1f, Time.deltaTime * velocity);
				}
			}

			// Token: 0x06000C00 RID: 3072 RVA: 0x0003680D File Offset: 0x00034A0D
			public virtual void Reset()
			{
				this.head = 1f;
				this.body = 1f;
			}

			// Token: 0x04000884 RID: 2180
			[SerializeField]
			[Range(0f, 50f)]
			private float m_head = 1f;

			// Token: 0x04000885 RID: 2181
			[SerializeField]
			[Range(0f, 50f)]
			private float m_body = 1f;

			// Token: 0x04000886 RID: 2182
			[Obsolete]
			[Range(0f, 50f)]
			[NonSerialized]
			private float m_eyes = 1f;
		}
	}
}
