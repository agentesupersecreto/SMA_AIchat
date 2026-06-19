using System;
using Assets.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000085 RID: 133
	[RequireComponent(typeof(LookAtIK))]
	[RequireComponent(typeof(LookAtIKTargets))]
	[Obsolete("", true)]
	public class LookAtManagerV2 : LookAtInitializador, IInteractionSystemLookAtGetter
	{
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x000197FF File Offset: 0x000179FF
		LookAtIK IInteractionSystemLookAtGetter.interactionLookAtIK
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x00019806 File Offset: 0x00017A06
		public LookAtIKTargets targets
		{
			get
			{
				return this.m_LookAtIKTargets;
			}
		}

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06000516 RID: 1302 RVA: 0x00019810 File Offset: 0x00017A10
		// (remove) Token: 0x06000517 RID: 1303 RVA: 0x00019848 File Offset: 0x00017A48
		public event Action<LookAtManagerV2.TargetCalculadoEventArgs> targetCalculed;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x06000518 RID: 1304 RVA: 0x00019880 File Offset: 0x00017A80
		// (remove) Token: 0x06000519 RID: 1305 RVA: 0x000198B8 File Offset: 0x00017AB8
		public event Action<LookAtManagerV2.TargetCalculadoEventArgs> targetSmoothed;

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x0600051A RID: 1306 RVA: 0x000198F0 File Offset: 0x00017AF0
		// (remove) Token: 0x0600051B RID: 1307 RVA: 0x00019928 File Offset: 0x00017B28
		public event Action<LookAtManagerV2.TargetCalculadoEventArgs> targetSetToLookAtIK;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x0600051C RID: 1308 RVA: 0x00019960 File Offset: 0x00017B60
		// (remove) Token: 0x0600051D RID: 1309 RVA: 0x00019998 File Offset: 0x00017B98
		public event Action<LookAtManagerV2> lookAtIKUpdated;

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x000199CD File Offset: 0x00017BCD
		public HeadLookAtSolver postPhysicsLookAtIK
		{
			get
			{
				return this.m_PostPhysicsLookAtIK;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x000199D5 File Offset: 0x00017BD5
		public Quaternion headMatrix
		{
			get
			{
				return Quaternion.LookRotation(this.m_head.TransformDirection(this.m_HeadInits.initialLocalForward), this.m_head.TransformDirection(this.m_HeadInits.initialLocalUp));
			}
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00019A08 File Offset: 0x00017C08
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_postSuavizador = base.GetComponent<LookAtIKPostSuavizador>();
			this.m_LookAtIKTargets = base.GetComponent<LookAtIKTargets>();
			if (this.m_LookAtIKTargets == null)
			{
				throw new ArgumentNullException("m_LookAtIKTargets", "m_LookAtIKTargets null reference.");
			}
			Transform transform = base.transform.CreateChild("PostPhysicsLookAtIK");
			this.m_PostPhysicsLookAtIK = transform.GetComponentNotNull<HeadLookAtSolver>();
			this.m_PostPhysicsLookAtIK.Init(this.m_Animator);
			this.m_PostPhysicsLookAtIKSuavizador = this.m_PostPhysicsLookAtIK.gameObject.AddComponent<HeadLookAtSolverPostSuavizador>();
			this.evaluadorEnRango = new LookAtTargetWieghtParCollection.EvaluadorDeRango(this.EstaEnAngle);
			this.m_HeadInits = new LookAtManagerV2.Iniciales(this.m_head, this.m_Animator);
			this.m_ChestInits = new LookAtManagerV2.Iniciales(this.m_chest, this.m_Animator);
			this.m_SpineInits = new LookAtManagerV2.Iniciales(this.m_spine, this.m_Animator);
			this.m_HipsInits = new LookAtManagerV2.Iniciales(this.m_hips, this.m_Animator);
			this.m_updater = base.GetComponentInParent<IIKUpdater>();
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("updater", "updater null reference.");
			}
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00019B28 File Offset: 0x00017D28
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.lookAtIKsBodyUpdating += this.M_updater_lookAtIKsBodyUpdating;
			this.m_updater.lookAtIKsHeadUpdating += this.Updater_lookAtIKsHeadUpdating;
			this.m_updater.lookAtIKsHeadUpdated += this.M_updater_lookAtIKsHeadUpdated;
			this.m_updater.onPhysicsIKUpdated += this.M_updater_puppetUpdated;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00019B98 File Offset: 0x00017D98
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_updater.lookAtIKsBodyUpdating -= this.M_updater_lookAtIKsBodyUpdating;
			this.m_updater.lookAtIKsHeadUpdating -= this.Updater_lookAtIKsHeadUpdating;
			this.m_updater.lookAtIKsHeadUpdated -= this.M_updater_lookAtIKsHeadUpdated;
			this.m_updater.onPhysicsIKUpdated -= this.M_updater_puppetUpdated;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00019C08 File Offset: 0x00017E08
		private bool EstaEnAngle(Vector3 headPosition, Vector3 bodyForward, Vector3 posicionGlobal)
		{
			Vector3 vector = posicionGlobal - headPosition;
			return Vector3.Angle(bodyForward, vector) <= this.config.maxAngleToLookAt;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x00019C34 File Offset: 0x00017E34
		private void M_updater_lookAtIKsBodyUpdating(IIKUpdater obj)
		{
			this.headPositionConAnimacionMasPrimerIKSinLookAtIk = this.m_head.position;
			this.headForwardConAnimacionMasPrimerIKSinLookAtIk = this.m_head.TransformDirection(this.m_HeadInits.initialLocalForward).normalized;
			this.headUpConAnimacionMasPrimerIKSinLookAtIk = base.head.TransformDirection(this.m_HeadInits.initialLocalUp).normalized;
			this.chestUpOnAnimationAndPrimerPasoIk = this.m_chest.TransformDirection(this.m_ChestInits.initialLocalUp).normalized;
			this.chestForwardOnAnimationAndPrimerPasoIk = this.m_chest.TransformDirection(this.m_ChestInits.initialLocalForward).normalized;
			this.spineUpOnAnimationAndPrimerPasoIk = this.m_SpineInits.up;
			this.spineForwardOnAnimationAndPrimerPasoIk = this.m_SpineInits.forward;
			this.hipsUpOnAnimationAndPrimerPasoIk = this.m_HipsInits.up;
			this.hipsForwardOnAnimationAndPrimerPasoIk = this.m_HipsInits.forward;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00019D28 File Offset: 0x00017F28
		private void Updater_lookAtIKsHeadUpdating(IIKUpdater obj)
		{
			Vector3 vector = this.headPositionConAnimacionMasPrimerIKSinLookAtIk;
			Vector3 vector2 = base.lookAtIK.solver.IKPosition;
			Vector3 vector3 = base.lookAtIK.solver.IKPosition;
			Vector3 vector4 = vector + this.headForwardConAnimacionMasPrimerIKSinLookAtIk * 2f;
			float num = 0f;
			float num2 = 1f;
			try
			{
				Vector3 vector5;
				float num3;
				float num4;
				if (LookAtTargetWieghtParCollection.CalcularCurrentTargetConPrioridad(this.targets.primariosCollection, this.targets.segundariosCollection, this.evaluadorEnRango, this.chestForwardOnAnimationAndPrimerPasoIk, vector, out vector5, out num3, out num4, this.config.minTargetDistance))
				{
					num2 = num4;
					vector2 = vector5;
					num = Mathf.Clamp01(num3);
				}
			}
			finally
			{
				vector2 = FinalIKUtils.CalculeCurrentTargetPosition(vector, vector4, vector2, num, this.debugDraw);
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.chestF = this.chestForwardOnAnimationAndPrimerPasoIk;
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.chestU = this.chestUpOnAnimationAndPrimerPasoIk;
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.headPosition = this.headPositionConAnimacionMasPrimerIKSinLookAtIk;
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.headF = this.headForwardConAnimacionMasPrimerIKSinLookAtIk;
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.headU = this.headUpConAnimacionMasPrimerIKSinLookAtIk;
				this.m_TargetCalculadoEventArgs.IKPosition = vector2;
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.promedioForward = (this.chestForwardOnAnimationAndPrimerPasoIk + this.spineForwardOnAnimationAndPrimerPasoIk + this.hipsForwardOnAnimationAndPrimerPasoIk) / 3f;
				this.m_TargetCalculadoEventArgs.vectoresConAnimacionYPrimerIk.promedioUp = (this.chestUpOnAnimationAndPrimerPasoIk + this.spineUpOnAnimationAndPrimerPasoIk + this.hipsUpOnAnimationAndPrimerPasoIk) / 3f;
				this.OnTargetCalculed(this.m_TargetCalculadoEventArgs);
				vector2 = this.m_TargetCalculadoEventArgs.IKPosition;
				if (this.config.invertirLocalZSiLadosSonContrarios && this.TargetEstaAtrasFix1(vector, vector2, vector3, vector4))
				{
					vector3 = LookAtManagerV2.Invertir(vector3, vector, this.headForwardConAnimacionMasPrimerIKSinLookAtIk, this.headUpConAnimacionMasPrimerIKSinLookAtIk);
				}
				Vector3 vector6 = FinalIKUtils.CalculeDirection(vector, vector3, vector2);
				if (this.m_postSuavizador)
				{
					LookAtIKPostSuavizador postSuavizador = this.m_postSuavizador;
					postSuavizador.modificadorDeVelocidad.moded = postSuavizador.modificadorDeVelocidad.moded * num2;
				}
				if (this.m_PostPhysicsLookAtIKSuavizador)
				{
					HeadLookAtSolverPostSuavizador postPhysicsLookAtIKSuavizador = this.m_PostPhysicsLookAtIKSuavizador;
					postPhysicsLookAtIKSuavizador.modificadorDeVelocidad.moded = postPhysicsLookAtIKSuavizador.modificadorDeVelocidad.moded * num2;
				}
				float num5 = FinalIKUtils.ResolverLookAtIKWeight(base.lookAtIK.solver.IKPositionWeight, num, this.config.weightCambioVelocidad * num2, base.lookAtIK.solver.IKPosition, vector, this.headForwardConAnimacionMasPrimerIKSinLookAtIk, 5f);
				base.lookAtIK.solver.IKPositionWeight = num5 * this.weight;
				this.OnTargetSmoothed(vector6);
				base.lookAtIK.solver.IKPosition = this.m_TargetCalculadoEventArgs.IKPosition;
				this.UpdateTargetAngles();
				this.OnTargetSetToLookAtIK();
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001A010 File Offset: 0x00018210
		private bool TargetEstaAtras(Vector3 currentTarget)
		{
			Vector3 vector = currentTarget - base.head.position;
			return Vector3.Dot(this.headForwardConAnimacionMasPrimerIKSinLookAtIk.normalized, vector) < 0f;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001A048 File Offset: 0x00018248
		private bool TargetEstaAtrasFix1(Vector3 position, Vector3 targetFinal, Vector3 targetActual, Vector3 defaultTarget)
		{
			Vector3 normalized = (defaultTarget - position).normalized;
			Vector3 normalized2 = (targetFinal - position).normalized;
			Vector3 normalized3 = (targetActual - position).normalized;
			if (Vector3.Angle(normalized2, normalized3) < this.config.minAnguloNecesarioParaInvertir)
			{
				return false;
			}
			bool flag = Vector3.Dot(normalized2, normalized) < 0f;
			return Vector3.Dot(normalized3, normalized) < 0f != flag;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001A0C4 File Offset: 0x000182C4
		private static Vector3 Invertir(Vector3 target, Vector3 position, Vector3 forward, Vector3 up)
		{
			Quaternion quaternion = Quaternion.LookRotation(forward, up);
			Vector3 vector = Quaternion.Inverse(quaternion) * (target - position);
			vector.z *= -1f;
			target = position + quaternion * vector;
			return target;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0001A10F File Offset: 0x0001830F
		private void M_updater_lookAtIKsHeadUpdated(IIKUpdater obj)
		{
			this.UpdateHeadAngles();
			this.OnIKUpdated();
			this.headForwardBeforePhysics = this.m_head.TransformDirection(this.m_HeadInits.initialLocalForward);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001A139 File Offset: 0x00018339
		private void M_updater_puppetUpdated(IIKUpdater obj)
		{
			this.headForwardAfterPhysics = this.m_head.TransformDirection(this.m_HeadInits.initialLocalForward);
			this.UpdatePostPhysicsLookAtIK();
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001A160 File Offset: 0x00018360
		private void UpdatePostPhysicsLookAtIK()
		{
			this.m_PostPhysicsLookAtIK.enabled = false;
			float num = 0f;
			try
			{
				if (this.config.postPhysicsLookAt.usar && this.m_LookAtIK.solver.IKPositionWeight != 0f)
				{
					float num2 = Vector3.Angle(this.headForwardBeforePhysics, this.headForwardAfterPhysics);
					if (num2 >= this.config.postPhysicsLookAt.minAngle)
					{
						float num3 = Mathf.InverseLerp(this.config.postPhysicsLookAt.minAngle, this.config.postPhysicsLookAt.maxAngle, num2);
						num = this.config.postPhysicsLookAt.maxWeight * num3;
						Vector3 vector = this.m_head.TransformDirection(this.m_HeadInits.initialLocalUp);
						this.m_PostPhysicsLookAtIK.IKPosition = Math3d.ProjectPointOnPlane(vector, this.m_head.position, this.m_LookAtIK.solver.IKPosition);
						this.m_PostPhysicsLookAtIK.headWeight = this.config.postPhysicsLookAt.headWeight;
						this.m_PostPhysicsLookAtIK.clampWeightHead = this.config.postPhysicsLookAt.clampWeightHead;
						this.m_PostPhysicsLookAtIK.clampSmoothing = this.m_LookAtIK.solver.clampSmoothing;
					}
				}
			}
			finally
			{
				this.m_PostPhysicsLookAtIK.IKPositionWeight = Mathf.MoveTowards(this.m_PostPhysicsLookAtIK.IKPositionWeight, num, this.config.weightCambioVelocidad * Time.deltaTime);
				this.m_PostPhysicsLookAtIK.IKPositionWeight = Mathf.Lerp(0f, this.m_PostPhysicsLookAtIK.IKPositionWeight, this.m_LookAtIK.solver.IKPositionWeight);
				this.m_PostPhysicsLookAtIK.Solve();
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001A32C File Offset: 0x0001852C
		private void UpdateHeadAngles()
		{
			Vector3 normalized = this.m_head.TransformDirection(this.m_HeadInits.initialLocalForward).normalized;
			Vector3 normalized2 = this.m_chest.TransformDirection(this.m_ChestInits.initialLocalForward).normalized;
			Vector3 vector = this.m_chest.TransformDirection(this.m_ChestInits.initialLocalUp);
			Quaternion quaternion = Quaternion.LookRotation(normalized2, vector);
			Math3dTvalle.GetDirectionAngle(out this.verticalAngle, out this.horizontalAngle, quaternion, normalized, true);
			this.mirandoAtras = Vector3.Dot(normalized2, normalized) < 0f;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001A3C0 File Offset: 0x000185C0
		private void UpdateTargetAngles()
		{
			Vector3 normalized = this.m_chest.TransformDirection(this.m_ChestInits.initialLocalForward).normalized;
			Vector3 vector = this.m_chest.TransformDirection(this.m_ChestInits.initialLocalUp);
			Vector3 normalized2 = (base.lookAtIK.solver.IKPosition - this.m_head.position).normalized;
			Quaternion quaternion = Quaternion.LookRotation(normalized, vector);
			this.targetEstaAtras = Vector3.Dot(normalized, normalized2) < 0f;
			Math3dTvalle.GetDirectionAngle(out this.targetVerticalAngle, out this.targetHorizontalAngle, quaternion, normalized2, true);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001A460 File Offset: 0x00018660
		protected virtual void OnTargetCalculed(LookAtManagerV2.TargetCalculadoEventArgs args)
		{
			Action<LookAtManagerV2.TargetCalculadoEventArgs> action = this.targetCalculed;
			if (action != null)
			{
				action(this.m_TargetCalculadoEventArgs);
			}
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001A484 File Offset: 0x00018684
		protected virtual void OnTargetSmoothed(Vector3 target)
		{
			this.m_TargetCalculadoEventArgs.IKPosition = target;
			Action<LookAtManagerV2.TargetCalculadoEventArgs> action = this.targetSmoothed;
			if (action != null)
			{
				action(this.m_TargetCalculadoEventArgs);
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001A4B4 File Offset: 0x000186B4
		protected virtual void OnTargetSetToLookAtIK()
		{
			Action<LookAtManagerV2.TargetCalculadoEventArgs> action = this.targetSetToLookAtIK;
			if (action != null)
			{
				action(this.m_TargetCalculadoEventArgs);
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001A4D8 File Offset: 0x000186D8
		protected virtual void OnIKUpdated()
		{
			Action<LookAtManagerV2> action = this.lookAtIKUpdated;
			if (action != null)
			{
				action(this);
			}
		}

		// Token: 0x04000366 RID: 870
		private LookAtIKTargets m_LookAtIKTargets;

		// Token: 0x04000367 RID: 871
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000368 RID: 872
		public bool debugDraw;

		// Token: 0x04000369 RID: 873
		public float verticalAngle;

		// Token: 0x0400036A RID: 874
		public float horizontalAngle;

		// Token: 0x0400036B RID: 875
		public bool mirandoAtras;

		// Token: 0x0400036C RID: 876
		public float targetVerticalAngle;

		// Token: 0x0400036D RID: 877
		public float targetHorizontalAngle;

		// Token: 0x0400036E RID: 878
		[Obsolete]
		[NonSerialized]
		public float targetAngleFaltante;

		// Token: 0x0400036F RID: 879
		public bool targetEstaAtras;

		// Token: 0x04000370 RID: 880
		public LookAtManagerV2.Config config = new LookAtManagerV2.Config();

		// Token: 0x04000371 RID: 881
		private IIKUpdater m_updater;

		// Token: 0x04000372 RID: 882
		private LookAtIKPostSuavizador m_postSuavizador;

		// Token: 0x04000373 RID: 883
		private HeadLookAtSolver m_PostPhysicsLookAtIK;

		// Token: 0x04000374 RID: 884
		private HeadLookAtSolverPostSuavizador m_PostPhysicsLookAtIKSuavizador;

		// Token: 0x04000375 RID: 885
		private LookAtManagerV2.TargetCalculadoEventArgs m_TargetCalculadoEventArgs = new LookAtManagerV2.TargetCalculadoEventArgs();

		// Token: 0x0400037A RID: 890
		private LookAtManagerV2.Iniciales m_HeadInits;

		// Token: 0x0400037B RID: 891
		private LookAtManagerV2.Iniciales m_ChestInits;

		// Token: 0x0400037C RID: 892
		private LookAtManagerV2.Iniciales m_SpineInits;

		// Token: 0x0400037D RID: 893
		private LookAtManagerV2.Iniciales m_HipsInits;

		// Token: 0x0400037E RID: 894
		[Obsolete]
		[NonSerialized]
		public Vector3 chestForwardOnAnimationAndIKAndLookAtBody;

		// Token: 0x0400037F RID: 895
		public Vector3 headPositionConAnimacionMasPrimerIKSinLookAtIk;

		// Token: 0x04000380 RID: 896
		public Vector3 headForwardConAnimacionMasPrimerIKSinLookAtIk;

		// Token: 0x04000381 RID: 897
		public Vector3 headUpConAnimacionMasPrimerIKSinLookAtIk;

		// Token: 0x04000382 RID: 898
		public Vector3 chestUpOnAnimationAndPrimerPasoIk;

		// Token: 0x04000383 RID: 899
		public Vector3 chestForwardOnAnimationAndPrimerPasoIk;

		// Token: 0x04000384 RID: 900
		public Vector3 spineUpOnAnimationAndPrimerPasoIk;

		// Token: 0x04000385 RID: 901
		public Vector3 spineForwardOnAnimationAndPrimerPasoIk;

		// Token: 0x04000386 RID: 902
		public Vector3 hipsUpOnAnimationAndPrimerPasoIk;

		// Token: 0x04000387 RID: 903
		public Vector3 hipsForwardOnAnimationAndPrimerPasoIk;

		// Token: 0x04000388 RID: 904
		public Vector3 headForwardBeforePhysics;

		// Token: 0x04000389 RID: 905
		public Vector3 headForwardAfterPhysics;

		// Token: 0x0400038A RID: 906
		private LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango;

		// Token: 0x02000178 RID: 376
		private class Iniciales
		{
			// Token: 0x06000C07 RID: 3079 RVA: 0x000369C4 File Offset: 0x00034BC4
			public Iniciales(Transform bone, Animator anim)
			{
				if (bone == null)
				{
					throw new ArgumentNullException("bone", "bone null reference.");
				}
				this.bone = bone;
				this.initialLocalForward = bone.InverseTransformDirection(anim.transform.forward);
				this.initialLocalUp = bone.InverseTransformDirection(anim.transform.up);
			}

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x06000C08 RID: 3080 RVA: 0x00036A28 File Offset: 0x00034C28
			public Vector3 forward
			{
				get
				{
					return this.bone.TransformDirection(this.initialLocalForward).normalized;
				}
			}

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x06000C09 RID: 3081 RVA: 0x00036A50 File Offset: 0x00034C50
			public Vector3 up
			{
				get
				{
					return this.bone.TransformDirection(this.initialLocalUp).normalized;
				}
			}

			// Token: 0x0400088C RID: 2188
			public Transform bone;

			// Token: 0x0400088D RID: 2189
			public Vector3 initialLocalForward;

			// Token: 0x0400088E RID: 2190
			public Vector3 initialLocalUp;
		}

		// Token: 0x02000179 RID: 377
		[Serializable]
		public class TargetCalculadoEventArgs
		{
			// Token: 0x0400088F RID: 2191
			public Vector3 IKPosition;

			// Token: 0x04000890 RID: 2192
			public LookAtManagerV2.TargetCalculadoEventArgs.Vectores vectoresConAnimacionYPrimerIk = new LookAtManagerV2.TargetCalculadoEventArgs.Vectores();

			// Token: 0x020001E5 RID: 485
			[SerializeField]
			public class Vectores
			{
				// Token: 0x04000A3A RID: 2618
				public Vector3 headPosition;

				// Token: 0x04000A3B RID: 2619
				public Vector3 chestF;

				// Token: 0x04000A3C RID: 2620
				public Vector3 chestU;

				// Token: 0x04000A3D RID: 2621
				public Vector3 headF;

				// Token: 0x04000A3E RID: 2622
				public Vector3 headU;

				// Token: 0x04000A3F RID: 2623
				public Vector3 promedioUp;

				// Token: 0x04000A40 RID: 2624
				public Vector3 promedioForward;
			}
		}

		// Token: 0x0200017A RID: 378
		[Serializable]
		public class Config
		{
			// Token: 0x04000891 RID: 2193
			public bool invertirLocalZSiLadosSonContrarios = true;

			// Token: 0x04000892 RID: 2194
			public float minAnguloNecesarioParaInvertir = 35f;

			// Token: 0x04000893 RID: 2195
			public float maxAngleToLookAt = 90f;

			// Token: 0x04000894 RID: 2196
			public float minTargetDistance = 0.2f;

			// Token: 0x04000895 RID: 2197
			[Obsolete]
			[NonSerialized]
			public float targetGradosVelocidad = 900f;

			// Token: 0x04000896 RID: 2198
			public bool targetSmooth = true;

			// Token: 0x04000897 RID: 2199
			public float weightCambioVelocidad = 2.5f;

			// Token: 0x04000898 RID: 2200
			public LookAtManagerV2.Config.PostPhysicsLookAt postPhysicsLookAt = new LookAtManagerV2.Config.PostPhysicsLookAt();

			// Token: 0x020001E6 RID: 486
			[Serializable]
			public class PostPhysicsLookAt
			{
				// Token: 0x04000A41 RID: 2625
				public bool usar = true;

				// Token: 0x04000A42 RID: 2626
				[Range(0f, 1f)]
				public float maxWeight = 1f;

				// Token: 0x04000A43 RID: 2627
				public float minAngle = 3f;

				// Token: 0x04000A44 RID: 2628
				public float maxAngle = 25f;

				// Token: 0x04000A45 RID: 2629
				[Range(0f, 1f)]
				public float headWeight = 0.5f;

				// Token: 0x04000A46 RID: 2630
				[Range(0f, 1f)]
				public float clampWeightHead = 0.8f;
			}
		}
	}
}
