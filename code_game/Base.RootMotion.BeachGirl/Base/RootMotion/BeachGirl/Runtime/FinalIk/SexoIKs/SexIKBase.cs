using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.IK;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000023 RID: 35
	[RequireComponent(typeof(LookAtIK))]
	public abstract class SexIKBase<TIKInitializador> : CustomMonobehaviour, ISexAt, IComponentStartable, ILookAtSolverIK, ILookAt where TIKInitializador : IIKInitializador
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00007618 File Offset: 0x00005818
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00007620 File Offset: 0x00005820
		public virtual TipoDeSexIK tipo
		{
			get
			{
				return this.m_tipoDeSexIK;
			}
			set
			{
				this.m_tipoDeSexIK = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00007629 File Offset: 0x00005829
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00007631 File Offset: 0x00005831
		public TipoDeSexIK tipoDeSexIK
		{
			get
			{
				return this.m_tipoDeSexIK;
			}
			set
			{
				this.m_tipoDeSexIK = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600011C RID: 284 RVA: 0x0000763A File Offset: 0x0000583A
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00007642 File Offset: 0x00005842
		public float weight
		{
			get
			{
				return this.m_weight;
			}
			set
			{
				this.m_weight = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0000764B File Offset: 0x0000584B
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00007653 File Offset: 0x00005853
		public Vector3 target
		{
			get
			{
				return this.m_target;
			}
			set
			{
				this.m_target = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0000765C File Offset: 0x0000585C
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00007664 File Offset: 0x00005864
		public bool doSmoothTarget
		{
			get
			{
				return this.m_doSmoothTarget;
			}
			set
			{
				this.m_doSmoothTarget = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000122 RID: 290 RVA: 0x0000766D File Offset: 0x0000586D
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00007675 File Offset: 0x00005875
		public float smoothTargetVelocityMod
		{
			get
			{
				return this.m_smoothTargetVelocityMod;
			}
			set
			{
				this.m_smoothTargetVelocityMod = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000124 RID: 292 RVA: 0x0000767E File Offset: 0x0000587E
		public float ikWeight
		{
			get
			{
				return this.m_LookAtIK.solver.IKPositionWeight;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00007690 File Offset: 0x00005890
		public Vector3 ikTarget
		{
			get
			{
				return this.m_LookAtIK.solver.IKPosition;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000126 RID: 294 RVA: 0x000076A2 File Offset: 0x000058A2
		// (set) Token: 0x06000127 RID: 295 RVA: 0x000076AA File Offset: 0x000058AA
		public float proyeccionWeight
		{
			get
			{
				return this.m_proyectionWeight;
			}
			set
			{
				this.m_proyectionWeight = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000128 RID: 296 RVA: 0x000076B3 File Offset: 0x000058B3
		// (set) Token: 0x06000129 RID: 297 RVA: 0x000076BB File Offset: 0x000058BB
		public Vector3 anglesOffset
		{
			get
			{
				return this.m_AngleOffset;
			}
			set
			{
				this.m_AngleOffset = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600012A RID: 298 RVA: 0x000076C4 File Offset: 0x000058C4
		public Transform mainBone
		{
			get
			{
				return this.m_LookAtIK.solver.head.transform;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600012B RID: 299 RVA: 0x000076DB File Offset: 0x000058DB
		LookAtEstadisticas ISexAt.estadisticasHaciaTarget
		{
			get
			{
				return this.estadisticasHaciaTarget;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600012C RID: 300 RVA: 0x000076E3 File Offset: 0x000058E3
		LookAtEstadisticas ISexAt.estadisticasHead
		{
			get
			{
				return this.estadisticasHead;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600012D RID: 301 RVA: 0x000076EB File Offset: 0x000058EB
		public LookAtIK mainLookAtIK
		{
			get
			{
				return this.m_LookAtIK;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600012E RID: 302 RVA: 0x000076F3 File Offset: 0x000058F3
		public Vector3 mirandoWorldPosition
		{
			get
			{
				return this.m_LookAtIK.solver.IKPosition;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00007705 File Offset: 0x00005905
		public float proyeccionBaseWorldDistance
		{
			get
			{
				return this.m_proyectionBaseWorldDistance;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0000770D File Offset: 0x0000590D
		public ModificableDeFloat modificableDeProyeccionChange
		{
			get
			{
				return this.m_modificableDeProyeccionChange;
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000131 RID: 305 RVA: 0x00007718 File Offset: 0x00005918
		// (remove) Token: 0x06000132 RID: 306 RVA: 0x00007750 File Offset: 0x00005950
		public event Action<ISexAt> updating;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000133 RID: 307 RVA: 0x00007788 File Offset: 0x00005988
		// (remove) Token: 0x06000134 RID: 308 RVA: 0x000077C0 File Offset: 0x000059C0
		public event Action<ISexAt> updated;

		// Token: 0x06000135 RID: 309 RVA: 0x000077F8 File Offset: 0x000059F8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			this.m_IKInitializador = base.GetComponent<TIKInitializador>();
			if (this.m_IKInitializador == null)
			{
				throw new ArgumentNullException("m_IKInitializador", "m_IKInitializador null reference.");
			}
			this.m_IAnimatorCharacter = this.GetComponentEnRoot(false);
			if (this.m_IAnimatorCharacter == null)
			{
				throw new ArgumentNullException("m_IAnimatorCharacter", "m_IAnimatorCharacter null reference.");
			}
			IKSolverLookAt solver = this.m_LookAtIK.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
			IKSolverLookAt solver2 = this.m_LookAtIK.solver;
			solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000078BD File Offset: 0x00005ABD
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_targetHaSidoProyectado = false;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000078D0 File Offset: 0x00005AD0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_LookAtIK)
			{
				IKSolverLookAt solver = this.m_LookAtIK.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
				IKSolverLookAt solver2 = this.m_LookAtIK.solver;
				solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostUpdate));
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00007949 File Offset: 0x00005B49
		private void OnPreUpdate()
		{
			Action<ISexAt> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			this.DoUpdate();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00007963 File Offset: 0x00005B63
		private void OnPostUpdate()
		{
			this.DoPostUpdate();
			Action<ISexAt> action = this.updated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000797C File Offset: 0x00005B7C
		public void DoUpdate()
		{
			try
			{
				float num = Mathf.Abs(this.weight - this.m_LookAtIK.solver.IKPositionWeight);
				if (num > 0f)
				{
					float num2 = 1f;
					if (num < this.configWeight.distanceToSmooth)
					{
						num2 = Mathf.Clamp(num / this.configWeight.distanceToSmooth, 0.001f, 1f).OutPow(this.configWeight.smoothPower);
					}
					this.m_LookAtIK.solver.IKPositionWeight = Mathf.MoveTowards(this.m_LookAtIK.solver.IKPositionWeight, this.weight, Time.deltaTime * num2 * this.configWeight.changeVel);
				}
				float num3 = Quaternion.Angle(Quaternion.Euler(this.m_IKInitializador.axisEurleOffset), Quaternion.Euler(this.m_AngleOffset));
				if (num3 != 0f)
				{
					float num4 = Mathf.Clamp(num3 / this.config.angleOffsetAngleToSmooth, 0.001f, 1f).OutPow(this.configWeight.smoothPower);
					this.m_IKInitializador.axisEurleOffset = Vector3.MoveTowards(this.m_IKInitializador.axisEurleOffset, this.m_AngleOffset, num4 * Time.deltaTime * this.config.angleOffsetChangeVelV2);
				}
			}
			finally
			{
				if (this.m_LookAtIK.solver.IKPositionWeight > 0f)
				{
					if (Application.isEditor && this.m_debugTarget != null)
					{
						this.m_target = this.m_debugTarget.position;
					}
					Vector3 vector = this.m_target;
					if (this.config.proyectionMode == SexIKBase<TIKInitializador>.ProyectionMode.onIK)
					{
						this.UpdateProyection();
					}
					if (this.m_targetHaSidoProyectado)
					{
						vector = this.m_proyectedTarget;
					}
					float num5 = (this.m_doSmoothTarget ? (this.configTarget.smoothingAmountMod * this.m_smoothTargetVelocityMod) : 1f);
					if (num5 != this.m_smoothTargetWeightMod)
					{
						this.m_smoothTargetWeightMod = Mathf.MoveTowards(this.m_smoothTargetWeightMod, num5, Time.deltaTime * this.configTarget.smoothingChangeVel);
					}
					vector = Vector3.Lerp(this.m_LookAtIK.solver.IKPosition, vector, num5 * Time.deltaTime * this.configTarget.smoothingAmount);
					this.m_LookAtIK.solver.IKPosition = vector;
				}
				if (this.m_LookAtIK.solver.IKPositionWeight > 0f)
				{
					this.m_IKInitializador.FixAxis(this.m_tipoDeSexIK);
				}
				this.UpdateEstadisticasHaciaTarget();
			}
		}

		// Token: 0x0600013B RID: 315
		protected abstract void UpdateEstadisticasHaciaTarget();

		// Token: 0x0600013C RID: 316
		protected abstract void UpdateEstadisticasHead();

		// Token: 0x0600013D RID: 317 RVA: 0x00007C1C File Offset: 0x00005E1C
		private void UpdateProyection()
		{
			this.m_targetHaSidoProyectado = false;
			if (this.m_proyectionWeight != this.m_CurrentProyection)
			{
				this.m_CurrentProyection = Mathf.MoveTowards(this.m_CurrentProyection, this.m_proyectionWeight, Time.deltaTime * this.m_modificableDeProyeccionChange.ModificarValor(this.config.proyectionChangeVel));
			}
			if (this.m_LookAtIK.solver.IKPositionWeight > 0f)
			{
				this.m_currentProyectionModValue = MathfExtension.LerpConMedio(this.config.proyectionMinMod, this.config.proyectionMedMod, this.config.proyectionMaxMod, this.m_CurrentProyection);
				Vector3 position = this.m_LookAtIK.solver.head.transform.position;
				this.m_proyectionBaseWorldDistance = (this.m_IKInitializador.lokingBone.position - position).magnitude;
				float num = this.m_proyectionBaseWorldDistance * this.m_currentProyectionModValue;
				Vector3 vector = this.m_target - position;
				vector = vector.SetMagnitud(num);
				Vector3 vector2 = position + vector;
				this.m_proyectedTarget = vector2;
				this.m_targetHaSidoProyectado = true;
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00007D3D File Offset: 0x00005F3D
		public void DoPostUpdate()
		{
			if (this.config.proyectionMode == SexIKBase<TIKInitializador>.ProyectionMode.postIK)
			{
				this.UpdateProyection();
			}
			this.UpdateEstadisticasHead();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00007D58 File Offset: 0x00005F58
		public void SetIKTarget(Vector3 target)
		{
			this.m_LookAtIK.solver.IKPosition = target;
		}

		// Token: 0x040000C4 RID: 196
		[SerializeField]
		private TipoDeSexIK m_tipoDeSexIK;

		// Token: 0x040000C5 RID: 197
		[Range(0f, 1f)]
		[SerializeField]
		private float m_weight;

		// Token: 0x040000C6 RID: 198
		[SerializeField]
		protected Vector3 m_target;

		// Token: 0x040000C7 RID: 199
		[SerializeField]
		private Vector3 m_proyectedTarget;

		// Token: 0x040000C8 RID: 200
		[SerializeField]
		private bool m_doSmoothTarget;

		// Token: 0x040000C9 RID: 201
		[SerializeField]
		private Transform m_debugTarget;

		// Token: 0x040000CA RID: 202
		[SerializeField]
		private float m_smoothTargetVelocityMod = 1f;

		// Token: 0x040000CB RID: 203
		[SerializeField]
		[Range(0f, 1f)]
		private float m_proyectionWeight = 0.5f;

		// Token: 0x040000CC RID: 204
		[ReadOnlyUI]
		[SerializeField]
		private float m_smoothTargetWeightMod;

		// Token: 0x040000CD RID: 205
		[ReadOnlyUI]
		[SerializeField]
		private float m_CurrentProyection;

		// Token: 0x040000CE RID: 206
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_AngleOffset;

		// Token: 0x040000CF RID: 207
		[ReadOnlyUI]
		[SerializeField]
		private float m_proyectionBaseWorldDistance;

		// Token: 0x040000D0 RID: 208
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentProyectionModValue;

		// Token: 0x040000D1 RID: 209
		protected LookAtIK m_LookAtIK;

		// Token: 0x040000D2 RID: 210
		private TIKInitializador m_IKInitializador;

		// Token: 0x040000D3 RID: 211
		public SexIKBase<TIKInitializador>.Config config = new SexIKBase<TIKInitializador>.Config();

		// Token: 0x040000D4 RID: 212
		public SexIKBase<TIKInitializador>.ConfigWeight configWeight = new SexIKBase<TIKInitializador>.ConfigWeight();

		// Token: 0x040000D5 RID: 213
		public SexIKBase<TIKInitializador>.ConfigTarget configTarget = new SexIKBase<TIKInitializador>.ConfigTarget();

		// Token: 0x040000D6 RID: 214
		[SerializeField]
		private ModificableDeFloat m_modificableDeProyeccionChange = new ModificableDeFloat(1f);

		// Token: 0x040000D7 RID: 215
		public LookAtEstadisticas estadisticasHaciaTarget;

		// Token: 0x040000D8 RID: 216
		public LookAtEstadisticas estadisticasHead;

		// Token: 0x040000DB RID: 219
		private bool m_targetHaSidoProyectado;

		// Token: 0x040000DC RID: 220
		protected IAnimatorCharacter m_IAnimatorCharacter;

		// Token: 0x02000119 RID: 281
		public enum ProyectionMode
		{
			// Token: 0x040006A1 RID: 1697
			postIK,
			// Token: 0x040006A2 RID: 1698
			onIK
		}

		// Token: 0x0200011A RID: 282
		[Serializable]
		public class Config
		{
			// Token: 0x040006A3 RID: 1699
			public SexIKBase<TIKInitializador>.ProyectionMode proyectionMode;

			// Token: 0x040006A4 RID: 1700
			public float proyectionChangeVel = 5f;

			// Token: 0x040006A5 RID: 1701
			public float proyectionMinMod = 0.666f;

			// Token: 0x040006A6 RID: 1702
			public float proyectionMedMod = 1f;

			// Token: 0x040006A7 RID: 1703
			public float proyectionMaxMod = 6f;

			// Token: 0x040006A8 RID: 1704
			public float angleOffsetChangeVelV2 = 200f;

			// Token: 0x040006A9 RID: 1705
			public float angleOffsetAngleToSmooth = 75f;
		}

		// Token: 0x0200011B RID: 283
		[Serializable]
		public class ConfigWeight
		{
			// Token: 0x040006AA RID: 1706
			public float changeVel = 1.75f;

			// Token: 0x040006AB RID: 1707
			[Range(0f, 1f)]
			public float distanceToSmooth = 0.5f;

			// Token: 0x040006AC RID: 1708
			public float smoothPower = 1f;
		}

		// Token: 0x0200011C RID: 284
		[Serializable]
		public class ConfigTarget
		{
			// Token: 0x040006AD RID: 1709
			public float smoothingAmount = 60f;

			// Token: 0x040006AE RID: 1710
			[Range(0f, 1f)]
			public float smoothingAmountMod = 0.05f;

			// Token: 0x040006AF RID: 1711
			public float smoothingChangeVel = 1f;
		}
	}
}
