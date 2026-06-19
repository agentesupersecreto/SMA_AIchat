using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt
{
	// Token: 0x02000032 RID: 50
	public class SexoAtController : ControllerColaDePrioridadBase<SexoAtController.Estado, SexoAtController.Orden, SexoAtController.Cola, SexoAtController, int>
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600021A RID: 538 RVA: 0x0000C131 File Offset: 0x0000A331
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000C134 File Offset: 0x0000A334
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600021C RID: 540 RVA: 0x0000C137 File Offset: 0x0000A337
		public Transform mainBone
		{
			get
			{
				return this.m_ISexAt.mainBone;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000C144 File Offset: 0x0000A344
		public LookAtEstadisticas estadisticasHaciaTarget
		{
			get
			{
				return this.m_ISexAt.estadisticasHaciaTarget;
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000C154 File Offset: 0x0000A354
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ISexAt = this.GetComponentEnRoot(false);
			if (this.m_ISexAt == null)
			{
				throw new ArgumentNullException("m_IOralAt", "m_IOralAt null reference.");
			}
			this.m_SexIKInitializador = this.GetComponentEnRoot(false);
			if (this.m_SexIKInitializador == null)
			{
				throw new ArgumentNullException("m_SexIKInitializador", "m_SexIKInitializador null reference.");
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
			this.m_IVagHole = this.GetComponentEnRoot(false);
			if (this.m_IVagHole == null)
			{
				throw new ArgumentNullException("m_IVagHole", "m_IVagHole null reference.");
			}
			this.m_IAnusHole = this.GetComponentEnRoot(false);
			if (this.m_IAnusHole == null)
			{
				throw new ArgumentNullException("m_AnusHole", "m_AnusHole null reference.");
			}
			this.m_effector = ((Behaviour)this.m_ISexAt).GetComponentNotNull<WorldEffectorOffset>();
			this.m_effector.Init(IKLayerFlag.primero, IKOrderFlag.primero, IKPassOrderFlag.ultimo);
			this.m_effector.usaLeftShoulderOffset = false;
			this.m_effector.usaRightShoulderOffset = false;
			this.m_effector.usaLeftHandOffset = false;
			this.m_effector.usaRightHandOffset = false;
			this.m_effector.usaLeftFootOffset = false;
			this.m_effector.usaRightFootOffset = false;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000C2BE File Offset: 0x0000A4BE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ISexAt.updating += this.M_ISexAt_updating;
			this.m_ISexAt.updated += this.M_ISexAt_updated;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000C2F4 File Offset: 0x0000A4F4
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_ISexAt != null)
			{
				this.m_ISexAt.updating -= this.M_ISexAt_updating;
				this.m_ISexAt.updated -= this.M_ISexAt_updated;
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000C334 File Offset: 0x0000A534
		private void M_effector_modifying(TValleOffsetModifier obj)
		{
			this.m_ChestPosition = this.m_char.bones.chest.transform.position;
			this.m_ChestVagOffset = this.m_IVagHole.entrada.position - this.m_ChestPosition;
			this.m_ChestAnusOffset = this.m_IAnusHole.entrada.position - this.m_ChestPosition;
			this.m_VagPlaneNormal = this.m_IVagHole.worldOutHoleDirection;
			this.m_VagPlanePoint = this.m_IVagHole.entrada.position;
			this.m_AnusPlaneNormal = this.m_IAnusHole.worldOutHoleDirection;
			this.m_AnusPlanePoint = this.m_IAnusHole.entrada.position;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000C3F4 File Offset: 0x0000A5F4
		private void M_ISexAt_updated(ISexAt obj)
		{
			if (!this.aplicarOffsetsDirectamente)
			{
				this.m_effector.rightThighOffset = this.m_SexIKInitializador.thingsRProxy.position - this.m_SexIKInitializador.thingsRReal.position;
				this.m_effector.leftThighOffset = this.m_SexIKInitializador.thingsLProxy.position - this.m_SexIKInitializador.thingsLReal.position;
				this.m_effector.bodyOffset = -(this.m_effector.rightThighOffset + this.m_effector.leftThighOffset) / 2f;
				return;
			}
			this.m_effector.rightThighOffset = Vector3.zero;
			this.m_effector.leftThighOffset = Vector3.zero;
			this.m_effector.bodyOffset = Vector3.zero;
			this.m_SexIKInitializador.hipsBone.SetPositionAndRotation(this.m_SexIKInitializador.hipsProxy.position, this.m_SexIKInitializador.hipsProxy.rotation);
			this.m_SexIKInitializador.spine01Bone.SetPositionAndRotation(this.m_SexIKInitializador.spine01Proxy.position, this.m_SexIKInitializador.spine01Proxy.rotation);
			this.m_SexIKInitializador.thingsLBone.SetPositionAndRotation(this.m_SexIKInitializador.thingsLProxy.position, this.m_SexIKInitializador.thingsLProxy.rotation);
			this.m_SexIKInitializador.thingsRBone.SetPositionAndRotation(this.m_SexIKInitializador.thingsRProxy.position, this.m_SexIKInitializador.thingsRProxy.rotation);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000C592 File Offset: 0x0000A792
		private void M_ISexAt_updating(ISexAt obj)
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000C59C File Offset: 0x0000A79C
		public bool HoleHacia(Transform directionTarget, Vector3 directionTargetLocalOffset, Transform positionTarget, Vector3 positionTargetLocalOffset, FemalePenetracionTipo tipoDeHole, float weigth, float proyeccion, Vector3 anglesOffset, LookAtControllerV2.LookAtType evade, bool doSmoothTarget, float smoothDirectionVelocityMod, float smoothPositionVelocityMod, int prioridad, float duracion, ControllerPrioridadConfig priConfig, Func<SexoAtController.Orden, bool> EsValidoMirarHacia = null)
		{
			if (directionTarget == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			if (base.OrdenAnuladaPorPrioridadBaja(priConfig, 0))
			{
				return false;
			}
			SexoAtController.Orden orden;
			bool flag;
			if (base.EstaOcupadoV2(priConfig, prioridad, 0, false, out orden, out flag))
			{
				return false;
			}
			if (EsValidoMirarHacia == null)
			{
				EsValidoMirarHacia = SexoAtController.m_EsValidoMirarHaciaDEFAULT;
			}
			if (base.PuedeAcumularse(orden, priConfig, 0) && (doSmoothTarget || orden.directionTarget == directionTarget) && (doSmoothTarget || orden.evade == evade))
			{
				orden.esValidoMirarHacia = EsValidoMirarHacia;
				orden.SetPrioridad(prioridad);
				orden.priConfig = priConfig;
				orden.directionTarget = directionTarget;
				orden.directionTargetLocalOffset = directionTargetLocalOffset;
				orden.positionTarget = positionTarget;
				orden.positionTargetLocalOffset = positionTargetLocalOffset;
				orden.weigth = weigth;
				orden.evade = evade;
				orden.smoothDirectionVelocityMod = smoothDirectionVelocityMod;
				orden.smoothPositionVelocityMod = smoothPositionVelocityMod;
				orden.doSmoothTarget = doSmoothTarget;
				orden.proyeccion = proyeccion;
				orden.anglesOffset = anglesOffset;
				orden.tipoDeHole = tipoDeHole;
				base.ResusarOrden(orden, duracion, prioridad, null, null);
				return true;
			}
			if (base.EntraraACola(orden, flag, priConfig) && !base.PuedePonerEnCola(0))
			{
				return false;
			}
			SexoAtController.Orden orden2 = new SexoAtController.Orden(EsValidoMirarHacia, directionTarget, directionTargetLocalOffset, positionTarget, positionTargetLocalOffset, tipoDeHole, weigth, proyeccion, anglesOffset, evade, doSmoothTarget, smoothDirectionVelocityMod, smoothPositionVelocityMod, 0, prioridad, duracion, priConfig);
			base.Procesar(orden == null, flag, priConfig, orden2, priConfig == ControllerPrioridadConfig.interrumpir, false);
			return true;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000C6F7 File Offset: 0x0000A8F7
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000C6FA File Offset: 0x0000A8FA
		public override int ParseTipoIdToindex(int id)
		{
			return id;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000C6FD File Offset: 0x0000A8FD
		protected override SexoAtController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x0400018B RID: 395
		private IAnimatorCharacter m_char;

		// Token: 0x0400018C RID: 396
		private IVagHole m_IVagHole;

		// Token: 0x0400018D RID: 397
		private IAnusHole m_IAnusHole;

		// Token: 0x0400018E RID: 398
		private IVagAnalAt m_ISexAt;

		// Token: 0x0400018F RID: 399
		private SexIKInitializador m_SexIKInitializador;

		// Token: 0x04000190 RID: 400
		private LookAtControllerV2 m_lookAtConstroller;

		// Token: 0x04000191 RID: 401
		public bool aplicarOffsetsDirectamente;

		// Token: 0x04000192 RID: 402
		[ReadOnlyUI]
		[SerializeField]
		private WorldEffectorOffset m_effector;

		// Token: 0x04000193 RID: 403
		private Vector3 m_ChestPosition;

		// Token: 0x04000194 RID: 404
		private Vector3 m_ChestVagOffset;

		// Token: 0x04000195 RID: 405
		private Vector3 m_ChestAnusOffset;

		// Token: 0x04000196 RID: 406
		private Vector3 m_VagPlaneNormal;

		// Token: 0x04000197 RID: 407
		private Vector3 m_VagPlanePoint;

		// Token: 0x04000198 RID: 408
		private Vector3 m_AnusPlaneNormal;

		// Token: 0x04000199 RID: 409
		private Vector3 m_AnusPlanePoint;

		// Token: 0x0400019A RID: 410
		public float velocidadDeEffector = 0.2f;

		// Token: 0x0400019B RID: 411
		private static Func<SexoAtController.Orden, bool> m_EsValidoMirarHaciaDEFAULT = (SexoAtController.Orden o) => true;

		// Token: 0x02000125 RID: 293
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<SexoAtController.Estado, SexoAtController.Orden, SexoAtController.Cola, SexoAtController, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000AC5 RID: 2757 RVA: 0x0002FCE4 File Offset: 0x0002DEE4
			public Orden(Func<SexoAtController.Orden, bool> EsValidoMirarHacia, Transform directionTarget, Vector3 directionTargetLocalOffset, Transform positionTarget, Vector3 positionTargetLocalOffset, FemalePenetracionTipo tipoDeHole, float weigth, float proyeccion, Vector3 AnglesOffset, LookAtControllerV2.LookAtType evade, bool doSmoothTarget, float smoothDirectionVelocityMod, float smoothPositionVelocityMod, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig)
				: base(tipoId, prioridad, duracion, priConfig, false)
			{
				if (directionTarget == null)
				{
					throw new ArgumentNullException("targetHead", "targetHead null reference.");
				}
				this.tipoDeHole = tipoDeHole;
				this.directionTarget = directionTarget;
				this.directionTargetLocalOffset = directionTargetLocalOffset;
				this.positionTarget = positionTarget;
				this.positionTargetLocalOffset = positionTargetLocalOffset;
				this.esValidoMirarHacia = EsValidoMirarHacia;
				this.evade = evade;
				this.weigth = Mathf.Clamp01(weigth);
				this.doSmoothTarget = doSmoothTarget;
				this.smoothDirectionVelocityMod = smoothDirectionVelocityMod;
				this.smoothPositionVelocityMod = smoothPositionVelocityMod;
				this.proyeccion = proyeccion;
				this.anglesOffset = AnglesOffset;
			}

			// Token: 0x06000AC6 RID: 2758 RVA: 0x0002FD83 File Offset: 0x0002DF83
			protected override void OnDetenidaPorUsuario(SexoAtController dataUpdate)
			{
			}

			// Token: 0x06000AC7 RID: 2759 RVA: 0x0002FD88 File Offset: 0x0002DF88
			protected override bool OnTerminando(SexoAtController dataUpdate, bool primerUpdate, SexoAtController.Orden esperandoDetencion)
			{
				dataUpdate.m_ISexAt.weight = 0f;
				dataUpdate.m_ISexAt.proyeccionWeight = 0.5f;
				dataUpdate.m_ISexAt.anglesOffset = Vector3.zero;
				dataUpdate.m_effector.velocity = dataUpdate.velocidadDeEffector;
				dataUpdate.m_effector.rightThighOffset = (dataUpdate.m_effector.leftThighOffset = (dataUpdate.m_effector.bodyOffset = Vector3.zero));
				return dataUpdate.m_ISexAt.ikWeight == 0f && dataUpdate.m_effector.currentRightThighOffset == Vector3.zero && dataUpdate.m_effector.currentLeftThighOffset == Vector3.zero && dataUpdate.m_effector.currentBodyOffset == Vector3.zero;
			}

			// Token: 0x06000AC8 RID: 2760 RVA: 0x0002FE5C File Offset: 0x0002E05C
			protected override void OnTerminada(SexoAtController dataUpdate, bool abruptamente)
			{
				dataUpdate.m_ISexAt.weight = 0f;
				dataUpdate.m_ISexAt.doSmoothTarget = true;
				dataUpdate.m_ISexAt.smoothTargetVelocityMod = 1f;
				dataUpdate.m_ISexAt.proyeccionWeight = 0.5f;
				dataUpdate.m_ISexAt.anglesOffset = Vector3.zero;
				dataUpdate.m_effector.velocity = dataUpdate.velocidadDeEffector;
				dataUpdate.m_effector.rightThighOffset = (dataUpdate.m_effector.leftThighOffset = (dataUpdate.m_effector.bodyOffset = Vector3.zero));
			}

			// Token: 0x06000AC9 RID: 2761 RVA: 0x0002FEF2 File Offset: 0x0002E0F2
			public override bool Termino()
			{
				return base.Termino() || this.directionTarget == null;
			}

			// Token: 0x06000ACA RID: 2762 RVA: 0x0002FF0C File Offset: 0x0002E10C
			protected override bool UpdateOrden(SexoAtController dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino() || !this.esValidoMirarHacia(this))
				{
					return false;
				}
				if (!esPrimerUpdate)
				{
					base.DisminuirPrioridadAcumulativaDelta(0.0333f);
				}
				switch (this.tipoDeHole)
				{
				case FemalePenetracionTipo.anus:
					dataUpdate.m_ISexAt.tipo = TipoDeSexIK.anal;
					goto IL_0074;
				case FemalePenetracionTipo.vag:
					dataUpdate.m_ISexAt.tipo = TipoDeSexIK.vag;
					goto IL_0074;
				}
				throw new ArgumentOutOfRangeException(this.tipoDeHole.ToString());
				IL_0074:
				dataUpdate.m_ISexAt.weight = this.weigth;
				dataUpdate.m_ISexAt.doSmoothTarget = this.doSmoothTarget;
				dataUpdate.m_ISexAt.smoothTargetVelocityMod = this.smoothDirectionVelocityMod;
				dataUpdate.m_ISexAt.proyeccionWeight = this.proyeccion;
				dataUpdate.m_ISexAt.anglesOffset = this.anglesOffset;
				Vector3 vector = SexoAtController.Orden.UpdateTarget(dataUpdate, this.directionTarget, this.directionTargetLocalOffset, this.evade);
				dataUpdate.m_ISexAt.target = vector;
				if (esPrimerUpdate && dataUpdate.m_ISexAt.ikWeight < 0.333f)
				{
					dataUpdate.m_ISexAt.SetIKTarget(vector);
				}
				dataUpdate.M_effector_modifying(dataUpdate.m_effector);
				dataUpdate.m_effector.rightThighOffset = (dataUpdate.m_effector.leftThighOffset = (dataUpdate.m_effector.bodyOffset = Vector3.zero));
				return true;
			}

			// Token: 0x06000ACB RID: 2763 RVA: 0x00030064 File Offset: 0x0002E264
			private static Vector3 UpdateTarget(SexoAtController dataUpdate, Transform target, Vector3 localSffset, LookAtControllerV2.LookAtType lookAtType)
			{
				Vector3 vector = target.TransformPoint(localSffset);
				if (lookAtType == LookAtControllerV2.LookAtType.fijamente)
				{
					return vector;
				}
				return dataUpdate.m_lookAtConstroller.GetEvadePosition(lookAtType, vector, false);
			}

			// Token: 0x06000ACC RID: 2764 RVA: 0x0003008C File Offset: 0x0002E28C
			protected override void OnStart(SexoAtController dataUpdate)
			{
			}

			// Token: 0x040006D7 RID: 1751
			public FemalePenetracionTipo tipoDeHole;

			// Token: 0x040006D8 RID: 1752
			public Transform directionTarget;

			// Token: 0x040006D9 RID: 1753
			public Vector3 directionTargetLocalOffset;

			// Token: 0x040006DA RID: 1754
			public Transform positionTarget;

			// Token: 0x040006DB RID: 1755
			public Vector3 positionTargetLocalOffset;

			// Token: 0x040006DC RID: 1756
			public bool doSmoothTarget;

			// Token: 0x040006DD RID: 1757
			public float smoothDirectionVelocityMod;

			// Token: 0x040006DE RID: 1758
			public float smoothPositionVelocityMod;

			// Token: 0x040006DF RID: 1759
			public float weigth;

			// Token: 0x040006E0 RID: 1760
			public LookAtControllerV2.LookAtType evade;

			// Token: 0x040006E1 RID: 1761
			public float proyeccion;

			// Token: 0x040006E2 RID: 1762
			public Vector3 anglesOffset;

			// Token: 0x040006E3 RID: 1763
			public Func<SexoAtController.Orden, bool> esValidoMirarHacia;
		}

		// Token: 0x02000126 RID: 294
		public sealed class Estado : ControllerColaDePrioridadBase<SexoAtController.Estado, SexoAtController.Orden, SexoAtController.Cola, SexoAtController, int>.StadoBase
		{
		}

		// Token: 0x02000127 RID: 295
		public sealed class Cola : ControllerColaDePrioridadBase<SexoAtController.Estado, SexoAtController.Orden, SexoAtController.Cola, SexoAtController, int>.ColasBase
		{
		}
	}
}
