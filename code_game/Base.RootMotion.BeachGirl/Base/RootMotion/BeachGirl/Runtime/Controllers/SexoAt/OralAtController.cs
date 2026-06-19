using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt
{
	// Token: 0x02000031 RID: 49
	public sealed class OralAtController : ControllerColaDePrioridadBase<OralAtController.Estado, OralAtController.Orden, OralAtController.Cola, OralAtController, int>
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000BCBE File Offset: 0x00009EBE
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterOralAt);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000BCC7 File Offset: 0x00009EC7
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000BCCA File Offset: 0x00009ECA
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000BCCD File Offset: 0x00009ECD
		public Transform mainBone
		{
			get
			{
				return this.m_IOralAt.mainBone;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000BCDA File Offset: 0x00009EDA
		public LookAtEstadisticas estadisticasHaciaTarget
		{
			get
			{
				return this.m_IOralAt.estadisticasHaciaTarget;
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x0600020C RID: 524 RVA: 0x0000BCE8 File Offset: 0x00009EE8
		// (remove) Token: 0x0600020D RID: 525 RVA: 0x0000BD20 File Offset: 0x00009F20
		private event Action<OralAtController> onOralAtIKUpdated;

		// Token: 0x0600020E RID: 526 RVA: 0x0000BD58 File Offset: 0x00009F58
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IOralAt = this.GetComponentEnRoot(false);
			if (this.m_IOralAt == null)
			{
				throw new ArgumentNullException("m_IOralAt", "m_IOralAt null reference.");
			}
			this.m_lookAtConstroller = this.GetComponentEnRoot(false);
			if (this.m_lookAtConstroller == null)
			{
				throw new ArgumentNullException("m_lookAtConstroller", "m_lookAtConstroller null reference.");
			}
			this.m_char = this.GetComponentEnRoot(false);
			if (this.m_char == null)
			{
				throw new ArgumentNullException("m_char", "m_char null reference.");
			}
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_muscle = this.GetComponentEnRoot(false).GetMuscle(HumanBodyBones.Head);
			if (this.m_muscle == null)
			{
				throw new ArgumentNullException("m_muscle", "m_muscle null reference.");
			}
			this.m_effector = ((Behaviour)this.m_IOralAt).GetComponentNotNull<WorldEffectorOffset>();
			this.m_effector.Init(IKLayerFlag.primero, IKOrderFlag.primero, IKPassOrderFlag.ultimo);
			this.m_effector.modifying += this.M_effector_modifying;
			this.m_effector.usaBodyOffset = false;
			this.m_effector.usaLeftThighOffset = false;
			this.m_effector.usaRightThighOffset = false;
			this.m_effector.usaLeftHandOffset = false;
			this.m_effector.usaRightHandOffset = false;
			this.m_effector.usaLeftFootOffset = false;
			this.m_effector.usaRightFootOffset = false;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000BEC1 File Offset: 0x0000A0C1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IOralAt.updating += this.M_IOralAt_updating;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000BEE0 File Offset: 0x0000A0E0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IOralAt != null)
			{
				this.m_IOralAt.updating -= this.M_IOralAt_updating;
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000BF08 File Offset: 0x0000A108
		private void M_effector_modifying(TValleOffsetModifier obj)
		{
			this.m_ChestPosition = this.m_char.bones.chest.transform.position;
			this.m_ChestBocaOffset = this.m_IBocaHole.entrada.position - this.m_ChestPosition;
			this.m_BocaPlaneNormal = this.m_IBocaHole.worldOutHoleDirection;
			this.m_BocaPlanePoint = this.m_IBocaHole.entrada.position;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000BF7D File Offset: 0x0000A17D
		private void M_IOralAt_updating(ISexAt obj)
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000BF86 File Offset: 0x0000A186
		public override void OnUpdateEvent2()
		{
			Action<OralAtController> action = this.onOralAtIKUpdated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000BF9C File Offset: 0x0000A19C
		public bool BocaHacia(Transform directionTarget, Vector3 directionTargetLocalOffset, Transform positionTarget, Vector3 positionTargetLocalOffset, float positionTargetMaxDistance, float weigth, float proyeccion, Vector3 anglesOffset, LookAtControllerV2.LookAtType evade, bool doSmoothTarget, float smoothDirectionVelocityMod, float smoothPositionVelocityMod, int prioridad, float duracion, ControllerPrioridadConfig priConfig, Func<OralAtController.Orden, bool> EsValidoMirarHacia = null)
		{
			if (directionTarget == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			if (base.OrdenAnuladaPorPrioridadBaja(priConfig, 0))
			{
				return false;
			}
			OralAtController.Orden orden;
			bool flag;
			if (base.EstaOcupadoV2(priConfig, prioridad, 0, false, out orden, out flag))
			{
				return false;
			}
			if (EsValidoMirarHacia == null)
			{
				EsValidoMirarHacia = OralAtController.m_EsValidoMirarHaciaDEFAULT;
			}
			OralAtController.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, 0, out tipoDeReUsoDeOrden) && (doSmoothTarget || orden2.directionTarget == directionTarget) && (doSmoothTarget || orden2.evade == evade))
			{
				orden2.esValidoMirarHacia = EsValidoMirarHacia;
				orden2.SetPrioridad(prioridad);
				orden2.priConfig = priConfig;
				orden2.directionTarget = directionTarget;
				orden2.directionTargetLocalOffset = directionTargetLocalOffset;
				orden2.positionTarget = positionTarget;
				orden2.positionTargetLocalOffset = positionTargetLocalOffset;
				orden2.positionTargetMaxDistance = positionTargetMaxDistance;
				orden2.weigth = weigth;
				orden2.evade = evade;
				orden2.smoothDirectionVelocityMod = smoothDirectionVelocityMod;
				orden2.smoothPositionVelocityMod = smoothPositionVelocityMod;
				orden2.doSmoothTarget = doSmoothTarget;
				orden2.proyeccion = proyeccion;
				orden2.anglesOffset = anglesOffset;
				base.AcumularseORevivir(orden2, duracion, prioridad, tipoDeReUsoDeOrden, null, null);
				return true;
			}
			if (base.EntraraACola(orden, flag, priConfig) && !base.PuedePonerEnCola(0))
			{
				return false;
			}
			OralAtController.Orden orden3 = new OralAtController.Orden(EsValidoMirarHacia, directionTarget, directionTargetLocalOffset, positionTarget, positionTargetLocalOffset, positionTargetMaxDistance, weigth, proyeccion, anglesOffset, evade, doSmoothTarget, smoothDirectionVelocityMod, smoothPositionVelocityMod, 0, prioridad, duracion, priConfig);
			base.Procesar(orden == null, flag, priConfig, orden3, priConfig == ControllerPrioridadConfig.interrumpir, false);
			return true;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000C0FE File Offset: 0x0000A2FE
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000C101 File Offset: 0x0000A301
		public override int ParseTipoIdToindex(int id)
		{
			return id;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000C104 File Offset: 0x0000A304
		protected override OralAtController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x0400017E RID: 382
		private IAnimatorCharacter m_char;

		// Token: 0x0400017F RID: 383
		private IBocaHole m_IBocaHole;

		// Token: 0x04000180 RID: 384
		private IOralAt m_IOralAt;

		// Token: 0x04000181 RID: 385
		private LookAtControllerV2 m_lookAtConstroller;

		// Token: 0x04000182 RID: 386
		[ReadOnlyUI]
		[SerializeField]
		private WorldEffectorOffset m_effector;

		// Token: 0x04000183 RID: 387
		private Vector3 m_ChestPosition;

		// Token: 0x04000184 RID: 388
		private Vector3 m_ChestBocaOffset;

		// Token: 0x04000185 RID: 389
		private Vector3 m_BocaPlaneNormal;

		// Token: 0x04000186 RID: 390
		private Vector3 m_BocaPlanePoint;

		// Token: 0x04000187 RID: 391
		public float velocidadDeEffector = 0.0333f;

		// Token: 0x04000189 RID: 393
		[NonSerialized]
		private Muscle m_muscle;

		// Token: 0x0400018A RID: 394
		private static Func<OralAtController.Orden, bool> m_EsValidoMirarHaciaDEFAULT = (OralAtController.Orden o) => true;

		// Token: 0x02000121 RID: 289
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<OralAtController.Estado, OralAtController.Orden, OralAtController.Cola, OralAtController, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000AB7 RID: 2743 RVA: 0x0002F62C File Offset: 0x0002D82C
			public Orden(Func<OralAtController.Orden, bool> EsValidoMirarHacia, Transform directionTarget, Vector3 directionTargetLocalOffset, Transform positionTarget, Vector3 positionTargetLocalOffset, float positionTargetDistance, float weigth, float proyeccion, Vector3 AnglesOffset, LookAtControllerV2.LookAtType evade, bool doSmoothTarget, float smoothDirectionVelocityMod, float smoothPositionVelocityMod, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig)
				: base(tipoId, prioridad, duracion, priConfig, false)
			{
				if (directionTarget == null)
				{
					throw new ArgumentNullException("targetHead", "targetHead null reference.");
				}
				this.directionTarget = directionTarget;
				this.directionTargetLocalOffset = directionTargetLocalOffset;
				this.positionTarget = positionTarget;
				this.positionTargetLocalOffset = positionTargetLocalOffset;
				this.positionTargetMaxDistance = positionTargetDistance;
				this.esValidoMirarHacia = EsValidoMirarHacia;
				this.evade = evade;
				this.weigth = Mathf.Clamp01(weigth);
				this.doSmoothTarget = doSmoothTarget;
				this.smoothDirectionVelocityMod = smoothDirectionVelocityMod;
				this.smoothPositionVelocityMod = smoothPositionVelocityMod;
				this.proyeccion = proyeccion;
				this.anglesOffset = AnglesOffset;
			}

			// Token: 0x06000AB8 RID: 2744 RVA: 0x0002F6FE File Offset: 0x0002D8FE
			protected override void OnDetenidaPorUsuario(OralAtController dataUpdate)
			{
			}

			// Token: 0x06000AB9 RID: 2745 RVA: 0x0002F700 File Offset: 0x0002D900
			protected override bool OnTerminando(OralAtController dataUpdate, bool primerUpdate, OralAtController.Orden esperandoDetencion)
			{
				this.m_terminando = true;
				dataUpdate.m_IOralAt.weight = 0f;
				dataUpdate.m_IOralAt.proyeccionWeight = 0.5f;
				dataUpdate.m_IOralAt.anglesOffset = Vector3.zero;
				dataUpdate.m_effector.velocity = dataUpdate.velocidadDeEffector;
				dataUpdate.m_effector.rightShoulderOffset = (dataUpdate.m_effector.leftShoulderOffset = Vector3.zero);
				return (this.m_MuscleToAnimJoint == null || (this.m_MuscleToAnimJoint.xDrive.positionSpring == 0f && this.m_MuscleToAnimJoint.angularXDrive.positionSpring == 0f)) && dataUpdate.m_IOralAt.ikWeight == 0f && dataUpdate.m_effector.currentRightShoulderOffset == Vector3.zero && dataUpdate.m_effector.currentLeftShoulderOffset == Vector3.zero;
			}

			// Token: 0x06000ABA RID: 2746 RVA: 0x0002F800 File Offset: 0x0002DA00
			protected override void OnTerminada(OralAtController dataUpdate, bool abruptamente)
			{
				dataUpdate.onOralAtIKUpdated -= this.DataUpdate_onOralAtIKUpdated;
				if (this.m_MuscleToAnimJoint != null)
				{
					Object.Destroy(this.m_MuscleToAnimJoint.gameObject);
					this.m_MuscleToAnimJoint = null;
				}
				dataUpdate.m_IOralAt.weight = 0f;
				dataUpdate.m_IOralAt.doSmoothTarget = true;
				dataUpdate.m_IOralAt.smoothTargetVelocityMod = 1f;
				dataUpdate.m_IOralAt.proyeccionWeight = 0.5f;
				dataUpdate.m_IOralAt.anglesOffset = Vector3.zero;
				dataUpdate.m_effector.velocity = dataUpdate.velocidadDeEffector;
				dataUpdate.m_effector.rightShoulderOffset = (dataUpdate.m_effector.leftShoulderOffset = Vector3.zero);
			}

			// Token: 0x06000ABB RID: 2747 RVA: 0x0002F8BF File Offset: 0x0002DABF
			public override bool Termino()
			{
				return base.Termino() || this.directionTarget == null;
			}

			// Token: 0x06000ABC RID: 2748 RVA: 0x0002F8D7 File Offset: 0x0002DAD7
			protected override void OnStart(OralAtController dataUpdate)
			{
				dataUpdate.onOralAtIKUpdated -= this.DataUpdate_onOralAtIKUpdated;
				dataUpdate.onOralAtIKUpdated += this.DataUpdate_onOralAtIKUpdated;
			}

			// Token: 0x06000ABD RID: 2749 RVA: 0x0002F900 File Offset: 0x0002DB00
			private void DataUpdate_onOralAtIKUpdated(OralAtController dataUpdate)
			{
				float jointForceNoPenetrated = this.m_JointForceNoPenetrated;
				float jointAngularForceNoPenetrated = this.m_JointAngularForceNoPenetrated;
				if (this.usarJoint && this.m_MuscleToAnimJoint == null)
				{
					this.m_MuscleToAnimJoint = dataUpdate.m_muscle.GenerateFollowerJoint(dataUpdate.transform);
					this.m_MuscleToAnimJoint.UpdateDrivers(false, dataUpdate.m_muscle, 0f, 0f, false, ref this.m_currentForceVelocity, jointForceNoPenetrated, jointForceNoPenetrated, 1f);
					this.m_MuscleToAnimJoint.UpdateAngularDrivers(false, dataUpdate.m_muscle, 0f, 0f, false, ref this.m_currentAngularForceVelocity, jointAngularForceNoPenetrated, jointAngularForceNoPenetrated, 1f);
					return;
				}
				this.m_MuscleToAnimJoint.transform.SetPositionAndRotation(dataUpdate.m_muscle.target.position, dataUpdate.m_muscle.target.rotation);
				bool flag;
				float num;
				float num2;
				if (this.usarJoint && !this.m_terminando)
				{
					if (!dataUpdate.m_IBocaHole.isPenetrated)
					{
						flag = true;
						num = this.m_JointForceNoPenetrated;
						num2 = this.m_JointAngularForceNoPenetrated;
					}
					else
					{
						flag = false;
						num = this.m_JointForcePenetrated;
						num2 = this.m_JointAngularForcePenetrated;
					}
				}
				else
				{
					num2 = (num = 0f);
					flag = false;
				}
				this.m_MuscleToAnimJoint.UpdateDrivers(flag, dataUpdate.m_muscle, this.m_MuscleToAnimJoint.xDrive.positionSpring, Time.deltaTime, false, ref this.m_currentForceVelocity, num, jointForceNoPenetrated, 1f);
				this.m_MuscleToAnimJoint.UpdateAngularDrivers(flag, dataUpdate.m_muscle, this.m_MuscleToAnimJoint.angularXDrive.positionSpring, Time.deltaTime, false, ref this.m_currentAngularForceVelocity, num2, jointAngularForceNoPenetrated, 1f);
			}

			// Token: 0x06000ABE RID: 2750 RVA: 0x0002FA90 File Offset: 0x0002DC90
			protected override bool UpdateOrden(OralAtController dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino() || !this.esValidoMirarHacia(this))
				{
					return false;
				}
				this.m_terminando = false;
				if (!esPrimerUpdate)
				{
					base.DisminuirPrioridadAcumulativaDelta(0.0333f);
				}
				dataUpdate.m_IOralAt.weight = this.weigth;
				dataUpdate.m_IOralAt.doSmoothTarget = this.doSmoothTarget;
				dataUpdate.m_IOralAt.smoothTargetVelocityMod = this.smoothDirectionVelocityMod;
				dataUpdate.m_IOralAt.proyeccionWeight = this.proyeccion;
				dataUpdate.m_IOralAt.anglesOffset = this.anglesOffset;
				Vector3 vector = OralAtController.Orden.UpdateTarget(dataUpdate, this.directionTarget, this.directionTargetLocalOffset, this.evade);
				dataUpdate.m_IOralAt.target = vector;
				if (esPrimerUpdate && dataUpdate.m_IOralAt.ikWeight < 0.333f)
				{
					dataUpdate.m_IOralAt.SetIKTarget(vector);
				}
				dataUpdate.m_effector.velocity = dataUpdate.velocidadDeEffector * this.smoothPositionVelocityMod;
				if (this.evade == LookAtControllerV2.LookAtType.fijamente && this.anglesOffset == Vector3.zero && this.positionTarget != null)
				{
					Vector3 vector2 = dataUpdate.m_ChestPosition + dataUpdate.m_ChestBocaOffset;
					Vector3 vector3 = this.positionTarget.TransformPoint(this.positionTargetLocalOffset);
					Vector3 vector4 = vector3 - vector2;
					Vector3 normalized = vector4.normalized;
					bool flag = Vector3.Dot(dataUpdate.m_BocaPlaneNormal, normalized) <= 0f;
					Vector3 vector5 = vector4.ClampMagnitudDisminutionReturn(this.positionTargetMaxDistance, 2f);
					vector3 = vector2 + vector5;
					Vector3 vector6 = Math3d.ProjectPointOnPlane(dataUpdate.m_BocaPlaneNormal, dataUpdate.m_BocaPlanePoint, vector3);
					if (!flag)
					{
						vector3 = vector6;
					}
					else
					{
						Vector3 vector7 = vector3 - vector6;
						vector3 = vector6 + vector7 * 0.666f;
					}
					dataUpdate.m_effector.rightShoulderOffset = (dataUpdate.m_effector.leftShoulderOffset = vector3 - vector2);
				}
				else
				{
					dataUpdate.m_effector.rightShoulderOffset = (dataUpdate.m_effector.leftShoulderOffset = Vector3.zero);
				}
				return true;
			}

			// Token: 0x06000ABF RID: 2751 RVA: 0x0002FC94 File Offset: 0x0002DE94
			private static Vector3 UpdateTarget(OralAtController dataUpdate, Transform target, Vector3 localSffset, LookAtControllerV2.LookAtType lookAtType)
			{
				Vector3 vector = target.TransformPoint(localSffset);
				if (lookAtType == LookAtControllerV2.LookAtType.fijamente)
				{
					return vector;
				}
				return dataUpdate.m_lookAtConstroller.GetEvadePosition(lookAtType, vector, false);
			}

			// Token: 0x040006C0 RID: 1728
			public Transform directionTarget;

			// Token: 0x040006C1 RID: 1729
			public Vector3 directionTargetLocalOffset;

			// Token: 0x040006C2 RID: 1730
			public Transform positionTarget;

			// Token: 0x040006C3 RID: 1731
			public Vector3 positionTargetLocalOffset;

			// Token: 0x040006C4 RID: 1732
			public float positionTargetMaxDistance;

			// Token: 0x040006C5 RID: 1733
			public bool doSmoothTarget;

			// Token: 0x040006C6 RID: 1734
			public float smoothDirectionVelocityMod;

			// Token: 0x040006C7 RID: 1735
			public float smoothPositionVelocityMod;

			// Token: 0x040006C8 RID: 1736
			public float weigth;

			// Token: 0x040006C9 RID: 1737
			public LookAtControllerV2.LookAtType evade;

			// Token: 0x040006CA RID: 1738
			public float proyeccion;

			// Token: 0x040006CB RID: 1739
			public Vector3 anglesOffset;

			// Token: 0x040006CC RID: 1740
			public Func<OralAtController.Orden, bool> esValidoMirarHacia;

			// Token: 0x040006CD RID: 1741
			public bool usarJoint = true;

			// Token: 0x040006CE RID: 1742
			[ReadOnlyUI]
			[SerializeField]
			private ConfigurableJoint m_MuscleToAnimJoint;

			// Token: 0x040006CF RID: 1743
			[ReadOnlyUI]
			[SerializeField]
			private bool m_terminando;

			// Token: 0x040006D0 RID: 1744
			[SerializeField]
			private float m_JointForceNoPenetrated = 750000f;

			// Token: 0x040006D1 RID: 1745
			[SerializeField]
			private float m_JointAngularForceNoPenetrated = 15000f;

			// Token: 0x040006D2 RID: 1746
			[SerializeField]
			private float m_JointForcePenetrated = 75000f;

			// Token: 0x040006D3 RID: 1747
			[SerializeField]
			private float m_JointAngularForcePenetrated = 1500f;

			// Token: 0x040006D4 RID: 1748
			private float m_currentForceVelocity;

			// Token: 0x040006D5 RID: 1749
			private float m_currentAngularForceVelocity;
		}

		// Token: 0x02000122 RID: 290
		public sealed class Estado : ControllerColaDePrioridadBase<OralAtController.Estado, OralAtController.Orden, OralAtController.Cola, OralAtController, int>.StadoBase
		{
		}

		// Token: 0x02000123 RID: 291
		public sealed class Cola : ControllerColaDePrioridadBase<OralAtController.Estado, OralAtController.Orden, OralAtController.Cola, OralAtController, int>.ColasBase
		{
		}
	}
}
