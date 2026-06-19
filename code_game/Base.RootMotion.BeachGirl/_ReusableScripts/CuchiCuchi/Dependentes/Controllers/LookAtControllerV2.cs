using System;
using Assets.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020000D1 RID: 209
	public sealed class LookAtControllerV2 : ControllerColaDePrioridadBase<LookAtControllerV2.Estado, LookAtControllerV2.Orden, LookAtControllerV2.Cola, LookAtControllerV2, int>
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00024987 File Offset: 0x00022B87
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x0002498A File Offset: 0x00022B8A
		protected override int cantidadDeEstados
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x0002498D File Offset: 0x00022B8D
		public ILookAtIK lookAt
		{
			get
			{
				return this.m_LookAtHead;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x00024995 File Offset: 0x00022B95
		public ILookAtIKOjos lookAtOjos
		{
			get
			{
				return this.m_LookAtOjos;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x0002499D File Offset: 0x00022B9D
		public LookAtTargetWieghtPar masterSlotHead
		{
			get
			{
				return this.m_LookAtHead.targets.primarios.master;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x000249B4 File Offset: 0x00022BB4
		public LookAtTargetWieghtPar masterSlotOjos
		{
			get
			{
				return this.m_LookAtOjos.targets.primarios.master;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x000249CB File Offset: 0x00022BCB
		public LookAtTargetWieghtPar slaveSlotHead
		{
			get
			{
				return this.m_LookAtHead.targets.primarios.slot1;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x000249E2 File Offset: 0x00022BE2
		public LookAtTargetWieghtPar slaveSlotOjos
		{
			get
			{
				return this.m_LookAtOjos.targets.primarios.slot1;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x000249F9 File Offset: 0x00022BF9
		[Obsolete("", true)]
		public LookAtManagerV2 manager
		{
			get
			{
				return this.m_LookAtManager;
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00024A04 File Offset: 0x00022C04
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			this.m_LookAtOjos = componentInParent.GetComponentInChildren<ILookAtIKOjos>();
			this.m_LookAtHead = componentInParent.GetComponentInChildren<ILookAtIK>();
			this.m_IIKUpdater = componentInParent.GetComponentInChildren<IIKUpdater>();
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("m_IKBeforePhysicsV2", "m_IKBeforePhysicsV2 null reference.");
			}
			if (this.m_LookAtOjos == null)
			{
				throw new ArgumentNullException("m_LookAtOjos", "m_LookAtOjos null reference.");
			}
			if (this.m_LookAtHead == null)
			{
				throw new ArgumentNullException("m_LookAtHead", "m_LookAtHead null reference.");
			}
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00024A8A File Offset: 0x00022C8A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_LookAtHead.updating += this.OnLookAtUpdating;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00024AA9 File Offset: 0x00022CA9
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_LookAtHead.updating -= this.OnLookAtUpdating;
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00024AC9 File Offset: 0x00022CC9
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00024AD1 File Offset: 0x00022CD1
		private void OnLookAtUpdating(ILookAtIK obj)
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00024ADC File Offset: 0x00022CDC
		public bool Mirar(float weigth, float weigthOjos, Transform target, LookAtControllerV2.LookAtType evade, bool evadeConstantemente, LookAtControllerV2.LookAtType evadeEyes, bool evadeConstantementeEyes, float lookAtVelocityMod, int prioridad, float duracion, ControllerPrioridadConfig priConfig, Vector3 localOffSet = default(Vector3), bool usarMaster = true, float timeToZeroPrioridad = 5f)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			int num = (usarMaster ? 0 : 1);
			if (base.OrdenAnuladaPorPrioridadBaja(priConfig, num))
			{
				return false;
			}
			LookAtControllerV2.Orden orden;
			bool flag;
			if (base.EstaOcupadoV2(priConfig, prioridad, num, false, out orden, out flag))
			{
				return false;
			}
			if (base.PuedeAcumularse(orden, priConfig, num) && orden.headTarget.transform == target && orden.headTarget.tipo == LookAtTarget.Tipo.transform && orden.evade == evade)
			{
				orden.SetPrioridad(prioridad);
				orden.priConfig = priConfig;
				orden.weigth = weigth;
				orden.lookAtVelocityMod = lookAtVelocityMod;
				orden.evadeConstantemente = evadeConstantemente;
				orden.evadeConstantementeEyes = evadeConstantementeEyes;
				if (localOffSet == Vector3.zero)
				{
					orden.headTarget.Set(target);
					orden.ojosTarget.Set(target);
				}
				else
				{
					orden.headTarget.Set(target, localOffSet);
					orden.ojosTarget.Set(target, localOffSet);
				}
				orden.weigthOjos = weigthOjos;
				orden.evadeEyes = evadeEyes;
				orden.timeToZeroPrioridad = (orden.timeToZeroPrioridad + timeToZeroPrioridad) / 2f;
				base.ResusarOrden(orden, duracion, prioridad, null, null);
				return true;
			}
			if (base.EntraraACola(orden, flag, priConfig) && !base.PuedePonerEnCola(num))
			{
				return false;
			}
			LookAtControllerV2.Orden orden2 = new LookAtControllerV2.Orden(target, localOffSet, weigth, weigthOjos, evade, evadeConstantemente, evadeEyes, evadeConstantementeEyes, lookAtVelocityMod, num, prioridad, duracion, priConfig, timeToZeroPrioridad);
			base.Procesar(orden == null, flag, priConfig, orden2, true, false);
			return true;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00024C5C File Offset: 0x00022E5C
		public bool TryDejarDeMirar(Transform target, bool usarMaster = true)
		{
			int num = (usarMaster ? 0 : 1);
			LookAtControllerV2.Orden orden;
			if (base.TipoDeOrdenEstaLibre(num, out orden))
			{
				return false;
			}
			if (orden.headTarget != null && orden.headTarget.transform != target)
			{
				return false;
			}
			if (orden.ojosTarget != null && orden.ojosTarget.transform != target)
			{
				return false;
			}
			base.currentStado.DetenerOrden(orden);
			return true;
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00024CC5 File Offset: 0x00022EC5
		protected override void OnOrderBeforePrimerUpdate(LookAtControllerV2.Orden orden)
		{
			base.OnOrderBeforePrimerUpdate(orden);
			orden.LoadInitialWs(this);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00024CD8 File Offset: 0x00022ED8
		public Vector3 GetEvadePosition(LookAtControllerV2.LookAtType type, Vector3 position, bool esOjos = false)
		{
			float num = LookAtControllerV2.GetEvadeAngle(type);
			if (num == 0f)
			{
				return position;
			}
			if (esOjos)
			{
				num *= 1.5f;
			}
			Vector3 vector = position - this.m_LookAtHead.preUpdateHeadPosition;
			Quaternion quaternion = Quaternion.LookRotation(vector, this.m_LookAtHead.preUpdateHeadRotation * Vector3.up);
			Vector3 evadeVector = LookAtControllerV2.GetEvadeVector(type);
			Vector3 vector2 = (quaternion * Quaternion.AngleAxis(num, evadeVector) * Vector3.forward).normalized * vector.magnitude;
			return this.m_LookAtHead.preUpdateHeadPosition + vector2;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00024D74 File Offset: 0x00022F74
		private static Vector3 GetEvadeVector(LookAtControllerV2.LookAtType type)
		{
			switch (type)
			{
			case LookAtControllerV2.LookAtType.fijamente:
				return Vector3.zero;
			case LookAtControllerV2.LookAtType.evadirCercaL:
			case LookAtControllerV2.LookAtType.evadirL:
				return Vector3.down;
			case LookAtControllerV2.LookAtType.evadirCercaR:
			case LookAtControllerV2.LookAtType.evadirR:
				return Vector3.up;
			case LookAtControllerV2.LookAtType.evadirCercaLUp:
			case LookAtControllerV2.LookAtType.evadirLUp:
				return LookAtControllerV2.diagonalLArriba;
			case LookAtControllerV2.LookAtType.evadirCercaRUp:
			case LookAtControllerV2.LookAtType.evadirRUp:
				return LookAtControllerV2.diagonalRArriba;
			case LookAtControllerV2.LookAtType.evadirCercaLDown:
			case LookAtControllerV2.LookAtType.evadirLDown:
				return LookAtControllerV2.diagonalLAbajo;
			case LookAtControllerV2.LookAtType.evadirCercaRDown:
			case LookAtControllerV2.LookAtType.evadirRDown:
				return LookAtControllerV2.diagonalRAbajo;
			case LookAtControllerV2.LookAtType.evadirUp:
				return Vector3.left;
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00024E04 File Offset: 0x00023004
		private static float GetEvadeAngle(LookAtControllerV2.LookAtType type)
		{
			switch (type)
			{
			case LookAtControllerV2.LookAtType.fijamente:
				return 0f;
			case LookAtControllerV2.LookAtType.evadirCercaL:
			case LookAtControllerV2.LookAtType.evadirCercaR:
				return 22f;
			case LookAtControllerV2.LookAtType.evadirL:
			case LookAtControllerV2.LookAtType.evadirR:
				return 45f;
			case LookAtControllerV2.LookAtType.evadirCercaLUp:
			case LookAtControllerV2.LookAtType.evadirCercaRUp:
			case LookAtControllerV2.LookAtType.evadirCercaLDown:
			case LookAtControllerV2.LookAtType.evadirCercaRDown:
				return 15f;
			case LookAtControllerV2.LookAtType.evadirLUp:
			case LookAtControllerV2.LookAtType.evadirRUp:
			case LookAtControllerV2.LookAtType.evadirLDown:
			case LookAtControllerV2.LookAtType.evadirRDown:
				return 22f;
			case LookAtControllerV2.LookAtType.evadirUp:
				return 45f;
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00024E87 File Offset: 0x00023087
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00024E8A File Offset: 0x0002308A
		public override int ParseTipoIdToindex(int id)
		{
			return id;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00024E8D File Offset: 0x0002308D
		protected override LookAtControllerV2 ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x04000524 RID: 1316
		private static Vector3 diagonalRArriba = (Vector3.up + Vector3.left).normalized;

		// Token: 0x04000525 RID: 1317
		private static Vector3 diagonalRAbajo = (Vector3.up + Vector3.left).normalized;

		// Token: 0x04000526 RID: 1318
		private static Vector3 diagonalLArriba = (Vector3.down + Vector3.right).normalized;

		// Token: 0x04000527 RID: 1319
		private static Vector3 diagonalLAbajo = (Vector3.down + Vector3.right).normalized;

		// Token: 0x04000528 RID: 1320
		[Obsolete]
		public float w = 1f;

		// Token: 0x04000529 RID: 1321
		[SerializeField]
		[ReadOnlyUI]
		[Obsolete]
		private float InternalHeadW;

		// Token: 0x0400052A RID: 1322
		[Obsolete]
		[SerializeField]
		[ReadOnlyUI]
		private float InternalOjosW;

		// Token: 0x0400052B RID: 1323
		private IIKUpdater m_IIKUpdater;

		// Token: 0x0400052C RID: 1324
		private ILookAtIKOjos m_LookAtOjos;

		// Token: 0x0400052D RID: 1325
		private ILookAtIK m_LookAtHead;

		// Token: 0x0400052E RID: 1326
		[Obsolete("", true)]
		private LookAtManagerV2 m_LookAtManager;

		// Token: 0x0400052F RID: 1327
		[Obsolete("", true)]
		private OjosLookAtManager m_OjosManager;

		// Token: 0x020001AD RID: 429
		public enum LookAtType
		{
			// Token: 0x04000984 RID: 2436
			fijamente,
			// Token: 0x04000985 RID: 2437
			evadirCercaL,
			// Token: 0x04000986 RID: 2438
			evadirCercaR,
			// Token: 0x04000987 RID: 2439
			evadirL,
			// Token: 0x04000988 RID: 2440
			evadirR,
			// Token: 0x04000989 RID: 2441
			evadirCercaLUp,
			// Token: 0x0400098A RID: 2442
			evadirCercaRUp,
			// Token: 0x0400098B RID: 2443
			evadirLUp,
			// Token: 0x0400098C RID: 2444
			evadirRUp,
			// Token: 0x0400098D RID: 2445
			evadirCercaLDown,
			// Token: 0x0400098E RID: 2446
			evadirCercaRDown,
			// Token: 0x0400098F RID: 2447
			evadirLDown,
			// Token: 0x04000990 RID: 2448
			evadirRDown,
			// Token: 0x04000991 RID: 2449
			evadirUp
		}

		// Token: 0x020001AE RID: 430
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<LookAtControllerV2.Estado, LookAtControllerV2.Orden, LookAtControllerV2.Cola, LookAtControllerV2, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000CA6 RID: 3238 RVA: 0x00038DAC File Offset: 0x00036FAC
			public Orden(Transform targetReference, Vector3 targetLocalPosition, float weigth, float weigthOjos, LookAtControllerV2.LookAtType evade, bool evadeConstantemente, LookAtControllerV2.LookAtType evadeEyes, bool evadeConstantementeEyes, float lookAtVelocityMod, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float timeToZeroPrioridad)
				: this(targetReference, targetLocalPosition, targetReference, targetLocalPosition, weigth, weigthOjos, evade, evadeConstantemente, evadeEyes, evadeConstantementeEyes, lookAtVelocityMod, tipoId, prioridad, duracion, priConfig, timeToZeroPrioridad)
			{
			}

			// Token: 0x06000CA7 RID: 3239 RVA: 0x00038DDC File Offset: 0x00036FDC
			public Orden(Transform targetHeadReference, Vector3 targetHeadLocalPosition, Transform targetOjosReference, Vector3 targetOjosLocalPosition, float weigth, float weigthOjos, LookAtControllerV2.LookAtType evade, bool evadeConstantemente, LookAtControllerV2.LookAtType evadeEyes, bool evadeConstantementeEyes, float lookAtVelocityMod, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float timeToZeroPrioridad)
			{
				this.timeToZeroPrioridad = 5f;
				base..ctor(tipoId, prioridad, duracion, priConfig, false);
				if (targetHeadReference == null)
				{
					throw new ArgumentNullException("targetHeadReference", "targetHeadReference null reference.");
				}
				if (targetOjosReference == null)
				{
					throw new ArgumentNullException("targetOjosReference", "targetOjosReference null reference.");
				}
				this.CrearLookAtTarget(ref this.m_headTarget, targetHeadReference, targetHeadLocalPosition, false, lookAtVelocityMod, evadeConstantemente);
				this.evade = evade;
				this.weigth = Mathf.Clamp01(weigth);
				this.CrearLookAtTarget(ref this.m_ojosTarget, targetOjosReference, targetOjosLocalPosition, false, lookAtVelocityMod, evadeConstantementeEyes);
				this.evadeEyes = evadeEyes;
				this.weigthOjos = Mathf.Clamp01(weigthOjos);
				this.evadeConstantemente = evadeConstantemente;
				this.evadeConstantementeEyes = evadeConstantementeEyes;
				this.lookAtVelocityMod = lookAtVelocityMod;
				this.timeToZeroPrioridad = timeToZeroPrioridad;
			}

			// Token: 0x06000CA8 RID: 3240 RVA: 0x00038EA8 File Offset: 0x000370A8
			public Orden(Transform targetHead, Transform targetOjos, float weigth, float weigthOjos, LookAtControllerV2.LookAtType evade, bool evadeConstantemente, LookAtControllerV2.LookAtType evadeEyes, bool evadeConstantementeEyes, float lookAtVelocityMod, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float timeToZeroPrioridad)
			{
				this.timeToZeroPrioridad = 5f;
				base..ctor(tipoId, prioridad, duracion, priConfig, false);
				if (targetHead == null)
				{
					throw new ArgumentNullException("targetHead", "targetHead null reference.");
				}
				if (targetOjos == null)
				{
					throw new ArgumentNullException("targetOjos", "targetOjos null reference.");
				}
				this.CrearLookAtTarget(ref this.m_headTarget, targetHead, false, lookAtVelocityMod, evadeConstantemente);
				this.evade = evade;
				this.weigth = Mathf.Clamp01(weigth);
				this.CrearLookAtTarget(ref this.m_ojosTarget, targetOjos, false, lookAtVelocityMod, evadeConstantementeEyes);
				this.evadeEyes = evadeEyes;
				this.weigthOjos = Mathf.Clamp01(weigthOjos);
				this.evadeConstantemente = evadeConstantemente;
				this.evadeConstantementeEyes = evadeConstantementeEyes;
				this.lookAtVelocityMod = lookAtVelocityMod;
				this.timeToZeroPrioridad = timeToZeroPrioridad;
			}

			// Token: 0x06000CA9 RID: 3241 RVA: 0x00038F70 File Offset: 0x00037170
			public Orden(Transform target, float weigth, float weigthOjos, LookAtControllerV2.LookAtType evade, bool evadeConstantemente, LookAtControllerV2.LookAtType evadeEyes, bool evadeConstantementeEyes, float lookAtVelocityMod, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float timeToZeroPrioridad)
				: this(target, target, weigth, weigthOjos, evade, evadeConstantemente, evadeEyes, evadeConstantementeEyes, lookAtVelocityMod, tipoId, prioridad, duracion, priConfig, timeToZeroPrioridad)
			{
			}

			// Token: 0x17000265 RID: 613
			// (get) Token: 0x06000CAA RID: 3242 RVA: 0x00038F9B File Offset: 0x0003719B
			public LookAtTarget headTarget
			{
				get
				{
					return this.m_headTarget;
				}
			}

			// Token: 0x17000266 RID: 614
			// (get) Token: 0x06000CAB RID: 3243 RVA: 0x00038FA3 File Offset: 0x000371A3
			public LookAtTarget ojosTarget
			{
				get
				{
					return this.m_ojosTarget;
				}
			}

			// Token: 0x06000CAC RID: 3244 RVA: 0x00038FAC File Offset: 0x000371AC
			protected override void OnStart(LookAtControllerV2 dataUpdate)
			{
				if (base.tipoId == 0)
				{
					this.slotHead = dataUpdate.masterSlotHead;
					this.slotOjos = dataUpdate.masterSlotOjos;
					return;
				}
				if (base.tipoId == 1)
				{
					this.slotHead = dataUpdate.slaveSlotHead;
					this.slotOjos = dataUpdate.slaveSlotOjos;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x06000CAD RID: 3245 RVA: 0x00039004 File Offset: 0x00037204
			protected override bool UpdateOrden(LookAtControllerV2 dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				if (!esPrimerUpdate)
				{
					base.DisminuirPrioridadDeltaTime(this.timeToZeroPrioridad);
				}
				this.m_headTarget.config.lookAtVelocityMod = this.lookAtVelocityMod;
				this.m_headTarget.config.puedeActualizarce = this.evadeConstantemente;
				if (this.m_headTarget.config.puedeActualizarce || esPrimerUpdate)
				{
					LookAtControllerV2.Orden.UpdateTarget(dataUpdate, this.m_headTarget, this.evade, this.slotHead, false);
				}
				this.slotHead.weight = this.weigth;
				if (this.weigthOjos > 0f)
				{
					this.m_ojosTarget.config.lookAtVelocityMod = this.lookAtVelocityMod;
					this.m_ojosTarget.config.puedeActualizarce = this.evadeConstantementeEyes;
					if (this.m_ojosTarget != null && this.m_ojosTarget.esValido && (this.m_ojosTarget.config.puedeActualizarce || esPrimerUpdate))
					{
						LookAtControllerV2.Orden.UpdateTarget(dataUpdate, this.m_ojosTarget, this.evadeEyes, this.slotOjos, true);
					}
					this.slotOjos.weight = this.weigthOjos;
				}
				return true;
			}

			// Token: 0x06000CAE RID: 3246 RVA: 0x00039128 File Offset: 0x00037328
			private static void UpdateTarget(LookAtControllerV2 dataUpdate, LookAtTarget lookAtTarget, LookAtControllerV2.LookAtType lookAtType, LookAtTargetWieghtPar par, bool esOjos = false)
			{
				par.LookAtTarget.config.CopyFrom(lookAtTarget.config);
				if (lookAtType == LookAtControllerV2.LookAtType.fijamente && lookAtTarget.tipo == LookAtTarget.Tipo.transform)
				{
					par.LookAtTarget.Set(lookAtTarget.transform);
					return;
				}
				lookAtTarget.Update();
				Vector3 evadePosition = dataUpdate.GetEvadePosition(lookAtType, lookAtTarget.posicionGlobal, esOjos);
				par.LookAtTarget.Set(evadePosition);
			}

			// Token: 0x06000CAF RID: 3247 RVA: 0x0003918B File Offset: 0x0003738B
			[Obsolete]
			private void GetW(out float weightHead, out float weightOjos)
			{
				throw new NotSupportedException();
			}

			// Token: 0x06000CB0 RID: 3248 RVA: 0x00039192 File Offset: 0x00037392
			public void LoadInitialWs(LookAtControllerV2 controller)
			{
			}

			// Token: 0x06000CB1 RID: 3249 RVA: 0x00039194 File Offset: 0x00037394
			private void CrearLookAtTarget(ref LookAtTarget lookAtTarget, Vector3 posicionGlobal, bool usarMaxAngleDeVision, float lookAtVelocityMod = 1f, bool puedeActualizarce = true)
			{
				lookAtTarget = new LookAtTarget();
				lookAtTarget.Set(posicionGlobal);
				this.SetLookAtTargetConfig(lookAtTarget, usarMaxAngleDeVision, lookAtVelocityMod, puedeActualizarce);
			}

			// Token: 0x06000CB2 RID: 3250 RVA: 0x000391B2 File Offset: 0x000373B2
			private void CrearLookAtTarget(ref LookAtTarget lookAtTarget, Transform reference, Vector3 localPosition, bool usarMaxAngleDeVision, float lookAtVelocityMod = 1f, bool puedeActualizarce = true)
			{
				if (localPosition == Vector3.zero)
				{
					this.CrearLookAtTarget(ref lookAtTarget, reference, usarMaxAngleDeVision, lookAtVelocityMod, puedeActualizarce);
					return;
				}
				lookAtTarget = new LookAtTarget();
				lookAtTarget.Set(reference, localPosition);
				this.SetLookAtTargetConfig(lookAtTarget, usarMaxAngleDeVision, lookAtVelocityMod, puedeActualizarce);
			}

			// Token: 0x06000CB3 RID: 3251 RVA: 0x000391EE File Offset: 0x000373EE
			private void CrearLookAtTarget(ref LookAtTarget lookAtTarget, Transform target, bool usarMaxAngleDeVision, float lookAtVelocityMod = 1f, bool puedeActualizarce = true)
			{
				lookAtTarget = new LookAtTarget();
				lookAtTarget.Set(target);
				this.SetLookAtTargetConfig(lookAtTarget, usarMaxAngleDeVision, lookAtVelocityMod, puedeActualizarce);
			}

			// Token: 0x06000CB4 RID: 3252 RVA: 0x0003920C File Offset: 0x0003740C
			private void SetLookAtTargetConfig(LookAtTarget target, bool usarMaxAngleDeVision, float lookAtVelocityMod = 1f, bool puedeActualizarce = true)
			{
				target.config.usarMaxAngleDeVision = usarMaxAngleDeVision;
				target.config.lookAtVelocityMod = lookAtVelocityMod;
				target.config.puedeActualizarce = puedeActualizarce;
			}

			// Token: 0x06000CB5 RID: 3253 RVA: 0x00039233 File Offset: 0x00037433
			protected override void OnDetenidaPorUsuario(LookAtControllerV2 dataUpdate)
			{
			}

			// Token: 0x06000CB6 RID: 3254 RVA: 0x00039235 File Offset: 0x00037435
			protected override bool OnTerminando(LookAtControllerV2 dataUpdate, bool primerUpdate, LookAtControllerV2.Orden esperandoDetencion)
			{
				return true;
			}

			// Token: 0x06000CB7 RID: 3255 RVA: 0x00039238 File Offset: 0x00037438
			protected override void OnTerminada(LookAtControllerV2 dataUpdate, bool abruptamente)
			{
				LookAtTargetWieghtPar lookAtTargetWieghtPar = this.slotHead;
				if (lookAtTargetWieghtPar != null)
				{
					lookAtTargetWieghtPar.Clear();
				}
				LookAtTargetWieghtPar lookAtTargetWieghtPar2 = this.slotOjos;
				if (lookAtTargetWieghtPar2 == null)
				{
					return;
				}
				lookAtTargetWieghtPar2.Clear();
			}

			// Token: 0x06000CB8 RID: 3256 RVA: 0x0003925B File Offset: 0x0003745B
			public override bool Termino()
			{
				return base.Termino() || !this.m_headTarget.esValido;
			}

			// Token: 0x04000992 RID: 2450
			public bool evadeConstantemente;

			// Token: 0x04000993 RID: 2451
			public bool evadeConstantementeEyes;

			// Token: 0x04000994 RID: 2452
			public float lookAtVelocityMod;

			// Token: 0x04000995 RID: 2453
			[SerializeField]
			private LookAtTarget m_headTarget;

			// Token: 0x04000996 RID: 2454
			[SerializeField]
			private LookAtTarget m_ojosTarget;

			// Token: 0x04000997 RID: 2455
			public float weigth;

			// Token: 0x04000998 RID: 2456
			public float weigthOjos;

			// Token: 0x04000999 RID: 2457
			public LookAtControllerV2.LookAtType evade;

			// Token: 0x0400099A RID: 2458
			public LookAtControllerV2.LookAtType evadeEyes;

			// Token: 0x0400099B RID: 2459
			public float timeToZeroPrioridad;

			// Token: 0x0400099C RID: 2460
			private LookAtTargetWieghtPar slotHead;

			// Token: 0x0400099D RID: 2461
			private LookAtTargetWieghtPar slotOjos;
		}

		// Token: 0x020001AF RID: 431
		public sealed class Estado : ControllerColaDePrioridadBase<LookAtControllerV2.Estado, LookAtControllerV2.Orden, LookAtControllerV2.Cola, LookAtControllerV2, int>.StadoBase
		{
		}

		// Token: 0x020001B0 RID: 432
		public sealed class Cola : ControllerColaDePrioridadBase<LookAtControllerV2.Estado, LookAtControllerV2.Orden, LookAtControllerV2.Cola, LookAtControllerV2, int>.ColasBase
		{
		}

		// Token: 0x020001B1 RID: 433
		[Serializable]
		public class Weights : ILookAtWeights
		{
			// Token: 0x17000267 RID: 615
			// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00039285 File Offset: 0x00037485
			float ILookAtWeights.body
			{
				get
				{
					return this.body;
				}
			}

			// Token: 0x17000268 RID: 616
			// (get) Token: 0x06000CBC RID: 3260 RVA: 0x0003928D File Offset: 0x0003748D
			float ILookAtWeights.head
			{
				get
				{
					return this.head;
				}
			}

			// Token: 0x17000269 RID: 617
			// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00039295 File Offset: 0x00037495
			float ILookAtWeights.eyes
			{
				get
				{
					return this.eyes;
				}
			}

			// Token: 0x06000CBE RID: 3262 RVA: 0x0003929D File Offset: 0x0003749D
			public LookAtControllerV2.Weights Copia()
			{
				return (LookAtControllerV2.Weights)base.MemberwiseClone();
			}

			// Token: 0x0400099E RID: 2462
			[Range(0f, 5f)]
			public float head = 1f;

			// Token: 0x0400099F RID: 2463
			[Range(0f, 5f)]
			public float body = 1f;

			// Token: 0x040009A0 RID: 2464
			[Range(0f, 5f)]
			public float eyes = 1f;
		}
	}
}
