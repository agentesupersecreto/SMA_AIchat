using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000236 RID: 566
	public class RespiracionDeIK : CustomMonobehaviour
	{
		// Token: 0x06000F09 RID: 3849 RVA: 0x00043024 File Offset: 0x00041224
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.config.localDirection = this.config.localDirection.normalized;
			Character componentInParent = base.GetComponentInParent<Character>();
			Transform boneTransform = componentInParent.bodyAnimator.GetBoneTransform(HumanBodyBones.Chest);
			this.m_effector = boneTransform.transform.CreateChild("EffectorDe_" + base.GetType().Name).gameObject.AddComponent<LocalDefaultEffectorOffset>();
			this.m_effector.usaLeftThighOffset = false;
			this.m_effector.usaRightThighOffset = false;
			this.m_effector.usaLeftFootOffset = false;
			this.m_effector.usaRightFootOffset = false;
			this.m_RespiracionEngine = componentInParent.GetComponentInChildren<RespiracionEngine>();
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x000430F0 File Offset: 0x000412F0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_effector)
			{
				Object.Destroy(this.m_effector.gameObject);
			}
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x00043118 File Offset: 0x00041318
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_effector.weight = 1f;
			this.m_RespiracionEngine.updated += this.M_RespiracionEngine_updated;
			this.m_displacementCurrent = (this.m_displacementTarget = Vector3.zero);
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x00043166 File Offset: 0x00041366
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_effector.weight = 0f;
			this.m_RespiracionEngine.updated -= this.M_RespiracionEngine_updated;
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x00043196 File Offset: 0x00041396
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_effector.Init(IKLayerFlag.primero, IKOrderFlag.primero, IKPassOrderFlag.primero);
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x000431AC File Offset: 0x000413AC
		private void M_RespiracionEngine_updated(float deltaTime, RespiracionEngine sender)
		{
			float num = sender.capacidad;
			switch (sender.estado)
			{
			case TipoDeRespiracion.reposo:
				break;
			case TipoDeRespiracion.inhalacion:
				num = num.InPow(this.config.inhalacionInPow);
				break;
			case TipoDeRespiracion.exhalacion:
				num = num.OutPow(this.config.exhalacionOutPow);
				break;
			default:
				throw new ArgumentOutOfRangeException(sender.estado.ToString());
			}
			this.m_currentCurveTime = MathfExtension.LerpConMedio(-1f, 0f, 1f, num);
			float num2 = Mathf.Lerp(1f, 1.5f, Mathf.InverseLerp(0.5f, 8f, sender.currentFrecuenciaDeRespiracion));
			this.m_displacementTarget = -this.config.localDirection * (this.config.amplitudV2 * this.amplitudMod * num2 * this.m_currentCurveTime);
			float num3 = Mathf.InverseLerp(0.5f, 8f, sender.currentFrecuenciaDeRespiracion);
			float num4 = 1f;
			if (this.config.smoothVelocidadDeCambio)
			{
				float num5 = Mathf.Abs(MathfExtension.LerpConMedio(-1f, 0f, 1f, sender.capacidad));
				num4 = (1f - num5).OutPow(this.config.smoothVelocidadDeCambioOutPower);
			}
			this.m_displacementCurrent = Vector3.MoveTowards(this.m_displacementCurrent, this.m_displacementTarget, deltaTime * this.config.velocidadDeCambioV2 * num4 * num3);
			if (this.config.usarHombros)
			{
				this.m_effector.leftShoulderOffset = (this.m_effector.rightShoulderOffset = this.m_displacementCurrent * this.config.hombrosMod);
			}
			if (this.config.usarBody)
			{
				this.m_effector.bodyOffset = this.m_displacementCurrent * (this.config.invertirBody ? (-1f) : 1f) * this.config.bodyMod;
				if (this.config.manosMod > 0f)
				{
					this.m_effector.leftHandOffset = (this.m_effector.rightHandOffset = this.m_effector.bodyOffset * this.config.manosMod);
				}
			}
		}

		// Token: 0x04000A3A RID: 2618
		[ReadOnlyUI]
		[SerializeField]
		private LocalDefaultEffectorOffset m_effector;

		// Token: 0x04000A3B RID: 2619
		public float amplitudMod = 1f;

		// Token: 0x04000A3C RID: 2620
		public RespiracionDeIK.Config config = new RespiracionDeIK.Config();

		// Token: 0x04000A3D RID: 2621
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000A3E RID: 2622
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentCurveTime;

		// Token: 0x04000A3F RID: 2623
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_displacementTarget;

		// Token: 0x04000A40 RID: 2624
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_displacementCurrent;

		// Token: 0x02000237 RID: 567
		[Serializable]
		public class Config
		{
			// Token: 0x04000A41 RID: 2625
			public float velocidadDeCambioV2 = 0.015f;

			// Token: 0x04000A42 RID: 2626
			public bool smoothVelocidadDeCambio;

			// Token: 0x04000A43 RID: 2627
			public float smoothVelocidadDeCambioOutPower = 1f;

			// Token: 0x04000A44 RID: 2628
			public bool invertirBody = true;

			// Token: 0x04000A45 RID: 2629
			public float amplitudV2 = 0.005f;

			// Token: 0x04000A46 RID: 2630
			public float inhalacionInPow = 1f;

			// Token: 0x04000A47 RID: 2631
			public float exhalacionOutPow = 2f;

			// Token: 0x04000A48 RID: 2632
			public bool usarHombros = true;

			// Token: 0x04000A49 RID: 2633
			public bool usarBody = true;

			// Token: 0x04000A4A RID: 2634
			[Range(0f, 1f)]
			public float hombrosMod = 0.1f;

			// Token: 0x04000A4B RID: 2635
			[Range(0f, 1f)]
			public float manosMod = 0.75f;

			// Token: 0x04000A4C RID: 2636
			[Range(0f, 1f)]
			public float bodyMod = 1f;

			// Token: 0x04000A4D RID: 2637
			public Vector3 localDirection = new Vector3(0f, 1f, -0.21f);
		}
	}
}
