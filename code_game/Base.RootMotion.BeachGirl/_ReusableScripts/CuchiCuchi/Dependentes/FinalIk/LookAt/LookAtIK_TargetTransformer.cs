using System;
using System.Collections.Generic;
using Assets.FinalIk;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt.Transformadores;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt
{
	// Token: 0x02000090 RID: 144
	[RequireComponent(typeof(LookAtIK))]
	[RequireComponent(typeof(LookAtIKUpdater))]
	[RequireComponent(typeof(LookAtIK_TargetTransformer.IProveedorDeData))]
	[RequireComponent(typeof(PostSuavizadorDeRotacionesGenerico))]
	public sealed class LookAtIK_TargetTransformer : CustomMonobehaviour
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0001C52A File Offset: 0x0001A72A
		public bool estaMirandoDerecha
		{
			get
			{
				return this.m_lastVSide <= 0;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0001C538 File Offset: 0x0001A738
		public bool estaMirandoIzquierda
		{
			get
			{
				return this.m_lastVSide >= 0;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001C546 File Offset: 0x0001A746
		public float weight
		{
			get
			{
				return this.internalW;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0001C54E File Offset: 0x0001A74E
		public LookAtIK lookAtIK
		{
			get
			{
				return this.m_LookAt;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001C556 File Offset: 0x0001A756
		public Vector3 lastProvidedTargetPosition
		{
			get
			{
				return this.m_lastProvidedTargetPosition;
			}
		}

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x060005A6 RID: 1446 RVA: 0x0001C560 File Offset: 0x0001A760
		// (remove) Token: 0x060005A7 RID: 1447 RVA: 0x0001C598 File Offset: 0x0001A798
		public event Action<LookAtIK_TargetTransformer> updating;

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x060005A8 RID: 1448 RVA: 0x0001C5D0 File Offset: 0x0001A7D0
		// (remove) Token: 0x060005A9 RID: 1449 RVA: 0x0001C608 File Offset: 0x0001A808
		public event Action<LookAtIK_TargetTransformer> updated;

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x060005AA RID: 1450 RVA: 0x0001C640 File Offset: 0x0001A840
		// (remove) Token: 0x060005AB RID: 1451 RVA: 0x0001C678 File Offset: 0x0001A878
		public event Action<LookAtIK_TargetTransformer> onCambioDeOrientacionHorizontal;

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0001C6AD File Offset: 0x0001A8AD
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x0001C6B5 File Offset: 0x0001A8B5
		public Vector3 preUpdateHeadPosition { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0001C6BE File Offset: 0x0001A8BE
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x0001C6C6 File Offset: 0x0001A8C6
		public Quaternion preUpdateHeadRotation { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0001C6CF File Offset: 0x0001A8CF
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0001C6D7 File Offset: 0x0001A8D7
		public Vector3 preUpdateSpinePosition { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0001C6E0 File Offset: 0x0001A8E0
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0001C6E8 File Offset: 0x0001A8E8
		public Quaternion preUpdateSpineRotation { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0001C6F1 File Offset: 0x0001A8F1
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0001C6F9 File Offset: 0x0001A8F9
		public Vector3 postUpdateHeadPosition { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x0001C702 File Offset: 0x0001A902
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x0001C70A File Offset: 0x0001A90A
		public Quaternion postUpdateHeadRotation { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0001C713 File Offset: 0x0001A913
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0001C71B File Offset: 0x0001A91B
		public Vector3 postUpdateSpinePosition { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0001C724 File Offset: 0x0001A924
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0001C72C File Offset: 0x0001A92C
		public Quaternion postUpdateSpineRotation { get; set; }

		// Token: 0x060005BC RID: 1468 RVA: 0x0001C738 File Offset: 0x0001A938
		private bool EstaEnAngle(Vector3 headPosition, Vector3 bodyForward, Vector3 posicionGlobal)
		{
			Vector3 vector = posicionGlobal - headPosition;
			return Vector3.Angle(bodyForward, vector) <= this.maxAngleToTarget;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001C760 File Offset: 0x0001A960
		protected override void AwakeUnityEvent()
		{
			this.evaluadorDeAnguloRango = new LookAtTargetWieghtParCollection.EvaluadorDeRango(this.EstaEnAngle);
			base.AwakeUnityEvent();
			this.m_Character = base.GetComponentInParent<ICharacter>();
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_LookAt = base.GetComponent<LookAtIK>();
			this.m_updater = base.GetComponent<LookAtIKUpdater>();
			this.m_suavizador = base.GetComponent<PostSuavizadorDeRotacionesGenerico>();
			this.m_proveedorDeTarget = base.GetComponentInParent<LookAtIK_TargetTransformer.IProveedorDeTarget>();
			this.m_proveedorDeData = base.GetComponent<LookAtIK_TargetTransformer.IProveedorDeData>();
			if (this.m_suavizador == null)
			{
				throw new ArgumentNullException("m_suavizador", "m_suavizador null reference.");
			}
			if (this.m_proveedorDeTarget == null)
			{
				throw new ArgumentNullException("m_proveedorDeTarget", "m_proveedorDeTarget null reference.");
			}
			if (this.m_proveedorDeData == null)
			{
				throw new ArgumentNullException("m_proveedorDeData", "m_proveedorDeData null reference.");
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001C834 File Offset: 0x0001AA34
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			base.GetComponentsInChildren<ILookAtIKTargetTransformer>(this.m_transformadores);
			this.m_transformadores.Sort((ILookAtIKTargetTransformer x, ILookAtIKTargetTransformer y) => x.order.CompareTo(y.order));
			this.m_updater.updating += this.OnUpdating;
			this.m_updater.updated += this.OnUpdated;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001C8AC File Offset: 0x0001AAAC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.updating -= this.OnUpdating;
				this.m_updater.updated -= this.OnUpdated;
			}
			this.internalW = 0f;
			this.m_lastTime = null;
			this.m_transformadores.Clear();
			this.m_suavizador.modificadorDeVelocidad.moded = 1f;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001C933 File Offset: 0x0001AB33
		private void OnUpdating(LookAtIKUpdater obj)
		{
			this.Actualizar();
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001C93C File Offset: 0x0001AB3C
		private static Vector3 ObtenerDirectionW(float headWeight, float neckWeight, float chestWeight, float spineWeight, Vector3 headDirection, Vector3 neckDirection, Vector3 chestDirection, Vector3 spineDirection)
		{
			Vector3 zero = Vector3.zero;
			headDirection = Vector3.Lerp(zero, headDirection, headWeight);
			neckDirection = Vector3.Lerp(zero, neckDirection, neckWeight);
			chestDirection = Vector3.Lerp(zero, chestDirection, chestWeight);
			spineDirection = Vector3.Lerp(zero, spineDirection, spineWeight);
			return (headDirection + neckDirection + chestDirection + spineDirection).normalized;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001C998 File Offset: 0x0001AB98
		private void OnUpdated(LookAtIKUpdater obj)
		{
			BoneState boneState = this.m_proveedorDeData.ObtenerHeadPostIKEstado();
			BoneState boneState2 = this.m_proveedorDeData.ObtenerNeckPostIKEstado();
			BoneState boneState3 = this.m_proveedorDeData.ObtenerChestPostIKEstado();
			BoneState boneState4 = this.m_proveedorDeData.ObtenerSpinePostIKEstado();
			Vector3 vector = LookAtIK_TargetTransformer.ObtenerDirectionW(this.headWeight, this.neckWeight, this.chestWeight, this.spineWeight, boneState.up, boneState2.up, boneState3.up, boneState4.up);
			Vector3 vector2 = LookAtIK_TargetTransformer.ObtenerDirectionW(this.headWeight, this.neckWeight, this.chestWeight, this.spineWeight, boneState.forward, boneState2.forward, boneState3.forward, boneState4.forward);
			this.estadisticasHead.Actualizar(vector2, vector, boneState.forward);
			this.postUpdateHeadPosition = boneState.position;
			this.postUpdateHeadRotation = Quaternion.LookRotation(boneState.forward, boneState.up);
			this.postUpdateSpinePosition = boneState3.position;
			this.postUpdateSpineRotation = Quaternion.LookRotation(vector2, vector);
			Action<LookAtIK_TargetTransformer> action = this.updated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0001CAA8 File Offset: 0x0001ACA8
		private void Actualizar()
		{
			int lastVSide = this.m_lastVSide;
			if (this.m_lastTime == null)
			{
				this.m_deltaTime = Time.deltaTime;
			}
			else
			{
				this.m_deltaTime = Time.time - this.m_lastTime.Value;
			}
			float num = 0f;
			float num2 = 1f;
			BoneState boneState = this.m_proveedorDeData.ObtenerHeadPreIKEstado();
			BoneState boneState2 = this.m_proveedorDeData.ObtenerNeckPreIKEstado();
			BoneState boneState3 = this.m_proveedorDeData.ObtenerChestPreIKEstado();
			BoneState boneState4 = this.m_proveedorDeData.ObtenerSpinePreIKEstado();
			BoneState boneState5 = this.m_proveedorDeData.ObtenerLastBonePreIKEstado();
			Vector3 vector = LookAtIK_TargetTransformer.ObtenerDirectionW(this.headWeight, this.neckWeight, this.chestWeight, this.spineWeight, boneState.up, boneState2.up, boneState3.up, boneState4.up);
			Vector3 vector2 = LookAtIK_TargetTransformer.ObtenerDirectionW(this.headWeight, this.neckWeight, this.chestWeight, this.spineWeight, boneState.forward, boneState2.forward, boneState3.forward, boneState4.forward);
			Vector3 position = boneState5.position;
			Quaternion quaternion = Quaternion.LookRotation(vector2, vector);
			bool flag = this.debugDraw;
			this.preUpdateHeadPosition = boneState.position;
			this.preUpdateHeadRotation = Quaternion.LookRotation(boneState.forward, boneState.up);
			this.preUpdateSpinePosition = boneState3.position;
			this.preUpdateSpineRotation = Quaternion.LookRotation(vector2, vector);
			Action<LookAtIK_TargetTransformer> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			Vector3 vector3 = (this.m_lastProvidedTargetPosition = position + boneState.forward);
			try
			{
				Vector3 vector4;
				if (this.m_proveedorDeTarget.TryObtener(this.evaluadorDeAnguloRango, vector2, position, this.minDistanceTarget, out vector4, out num2, out num))
				{
					this.m_lastProvidedTargetPosition = Vector3.Lerp(vector3, vector4, num * this.TransformerWeight);
					vector3 = vector4;
					this.estadisticasHaciaTargetTransformado.Actualizar(vector2, vector, vector4 - position);
					float escala = this.m_Character.escala;
					if (this.anguloMuertoHaciaAtrasConfig.activar)
					{
						vector4 = LookAtIK_TargetTransformer.AnguloMuertoHaciaAtras(ref this.m_lastVSide, vector4, this.anguloMuertoHaciaAtrasConfig.anguloMuerto, this.anguloMuertoHaciaAtrasConfig.weight, this.anguloMuertoHaciaAtrasConfig.verticalMods, this.estadisticasHaciaTargetTransformado, vector2, vector, position, this.anguloMuertoHaciaAtrasConfig.debugDraw);
					}
					this.estadisticasHaciaTargetTransformado.Actualizar(vector2, vector, vector4 - position);
					if (this.anguloMuertoHaciaAbajoConfig.activar)
					{
						vector4 = LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajo(ref this.m_lastHSide, ref this.m_lastAlguloMuertoHaciaAbajo, vector4, this.anguloMuertoHaciaAbajoConfig.angulosFrontales.keepTrack, this.anguloMuertoHaciaAbajoConfig.angulosTrasero.keepTrack, this.anguloMuertoHaciaAbajoConfig.weight, this.anguloMuertoHaciaAbajoConfig.consevarMagnitud, this.anguloMuertoHaciaAbajoConfig.verticalMods, this.estadisticasHaciaTargetTransformado, vector2, vector, position, this.anguloMuertoHaciaAbajoConfig.debugDraw);
					}
					for (int i = 0; i < this.m_transformadores.Count; i++)
					{
						ILookAtIKTargetTransformer lookAtIKTargetTransformer = this.m_transformadores[i];
						if (lookAtIKTargetTransformer.isActiveAndEnabled)
						{
							vector4 = lookAtIKTargetTransformer.Transformar(position, quaternion, vector4);
						}
					}
					this.estadisticasHaciaTargetTransformado.Actualizar(vector2, vector, vector4 - position);
					this.m_LookAt.solver.IKPosition = vector4;
				}
			}
			finally
			{
				bool flag2 = this.debugDraw;
				this.estadisticasHaciaTarget.Actualizar(vector2, vector, vector3 - position);
				this.internalW = Mathf.MoveTowards(this.internalW, num * this.TransformerWeight, this.m_deltaTime * this.LookAtWeightChangeVelocity);
				this.m_LookAt.solver.IKPositionWeight = this.internalW;
				this.m_lastTime = new float?(Time.time);
				this.m_lastVelocityMod = Mathf.MoveTowards(this.m_lastVelocityMod, num2, this.m_deltaTime * this.LookAtWeightChangeVelocity * 0.5f);
				this.m_suavizador.modificadorDeAceleracion.moded = (this.m_suavizador.modificadorDeVelocidad.moded = this.m_lastVelocityMod);
				if (!this.anguloMuertoHaciaAtrasConfig.activar)
				{
					this.m_lastVSide = ((this.estadisticasHaciaTargetTransformado.anguloHorizontal >= 0f) ? (-1) : 1);
				}
				if (this.m_lastVSide != lastVSide)
				{
					Action<LookAtIK_TargetTransformer> action2 = this.onCambioDeOrientacionHorizontal;
					if (action2 != null)
					{
						action2(this);
					}
				}
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001CF08 File Offset: 0x0001B108
		private static Vector3 AnguloMuertoHaciaAbajo(ref int lastSide, ref float keepTrackAngle, Vector3 punto, float keepTrackAngleFrontal, float keepTrackAngleTrasero, float weight, float consevarMagnitud, OrientacionMod verticalMods, LookAtEstadisticas estadisticas, Vector3 forward, Vector3 up, Vector3 position, bool debugdraw)
		{
			if (lastSide == 0)
			{
				lastSide = 1;
			}
			if (lastSide == 1)
			{
				keepTrackAngle = keepTrackAngleTrasero;
			}
			else
			{
				keepTrackAngle = keepTrackAngleFrontal;
			}
			float anguloVerticalOnPlane = estadisticas.anguloVerticalOnPlane;
			float haciaAbajoAprox = estadisticas.haciaAbajoAprox;
			bool flag = haciaAbajoAprox == 0f;
			float num = Mathf.InverseLerp(0f, -90f, anguloVerticalOnPlane);
			num = Mathf.Lerp(90f, 0f, num);
			bool flag2 = num >= 90f || flag || num > keepTrackAngle;
			bool flag3 = estadisticas.anguloHorizontalAbs <= 90f;
			if (flag2)
			{
				lastSide = (flag3 ? (-1) : 1);
				return punto;
			}
			Quaternion quaternion = Quaternion.LookRotation(forward, up);
			Quaternion quaternion2 = Quaternion.AngleAxis(keepTrackAngle * (float)lastSide, Vector3.right);
			Vector3 vector = quaternion * quaternion2 * Vector3.forward;
			Vector3 vector2 = punto - position;
			Vector3 vector3 = Math3d.ProjectPointOnPlane(vector, position, punto);
			Vector3 vector4 = vector3 - position;
			vector3 = position + vector4.SetMagnitud(vector2, consevarMagnitud);
			float num2 = verticalMods.weight * haciaAbajoAprox.InPow(verticalMods.power);
			int num3 = 1;
			return Vector3.Slerp(punto, vector3, weight * (float)num3 * num2);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001D030 File Offset: 0x0001B230
		private static Vector3 AnguloMuertoHaciaAtras(ref int lastSide, Vector3 punto, float anguloMuerto, float weight, OrientacionMod verticalMods, LookAtEstadisticas estadisticas, Vector3 forward, Vector3 up, Vector3 position, bool debugdraw)
		{
			if (lastSide == 0)
			{
				lastSide = 1;
			}
			anguloMuerto = Mathf.Abs(anguloMuerto);
			float anguloHorizontal = estadisticas.anguloHorizontal;
			if (Mathf.Abs(anguloHorizontal) < 180f - anguloMuerto)
			{
				lastSide = ((anguloHorizontal >= 0f) ? (-1) : 1);
				return punto;
			}
			Quaternion quaternion = Quaternion.LookRotation(forward, up);
			Quaternion quaternion2 = Quaternion.AngleAxis(anguloMuerto * (float)lastSide, Vector3.up);
			Vector3 vector = Math3d.ProjectPointOnPlane(quaternion * quaternion2 * Vector3.right, position, punto);
			Vector3 vector2 = punto - position;
			Vector3 vector3 = vector - position;
			vector = position + vector3.SetMagnitud(vector2, 0.5f);
			float num = 1f - Mathf.Clamp01(estadisticas.verticalMod.InPow(verticalMods.power) * verticalMods.weight * weight);
			return Vector3.Slerp(punto, vector, weight * num);
		}

		// Token: 0x040003E1 RID: 993
		[Range(0f, 1f)]
		public float TransformerWeight = 1f;

		// Token: 0x040003E2 RID: 994
		public bool debugDraw;

		// Token: 0x040003E3 RID: 995
		private LookAtIK_TargetTransformer.IProveedorDeTarget m_proveedorDeTarget;

		// Token: 0x040003E4 RID: 996
		private LookAtIK_TargetTransformer.IProveedorDeData m_proveedorDeData;

		// Token: 0x040003E5 RID: 997
		private LookAtIK m_LookAt;

		// Token: 0x040003E6 RID: 998
		private LookAtIKUpdater m_updater;

		// Token: 0x040003E7 RID: 999
		private PostSuavizadorDeRotacionesGenerico m_suavizador;

		// Token: 0x040003E8 RID: 1000
		[ReadOnlyUI]
		[SerializeField]
		private float internalW;

		// Token: 0x040003E9 RID: 1001
		[Range(0f, 180f)]
		public float maxAngleToTarget = 90f;

		// Token: 0x040003EA RID: 1002
		public float minDistanceTarget = 0.2f;

		// Token: 0x040003EB RID: 1003
		[Range(0f, 1f)]
		public float headWeight;

		// Token: 0x040003EC RID: 1004
		[Range(0f, 1f)]
		public float neckWeight;

		// Token: 0x040003ED RID: 1005
		[Range(0f, 1f)]
		public float chestWeight = 1f;

		// Token: 0x040003EE RID: 1006
		[Range(0f, 1f)]
		public float spineWeight = 1f;

		// Token: 0x040003EF RID: 1007
		[NonSerialized]
		private float? m_lastTime;

		// Token: 0x040003F0 RID: 1008
		public LookAtIK_TargetTransformer.AnguloMuertoHaciaAtrasConfig anguloMuertoHaciaAtrasConfig = new LookAtIK_TargetTransformer.AnguloMuertoHaciaAtrasConfig();

		// Token: 0x040003F1 RID: 1009
		public LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajoConfig anguloMuertoHaciaAbajoConfig = new LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajoConfig();

		// Token: 0x040003F2 RID: 1010
		public float LookAtWeightChangeVelocity = 3f;

		// Token: 0x040003F3 RID: 1011
		private ICharacter m_Character;

		// Token: 0x040003F4 RID: 1012
		public LookAtEstadisticas estadisticasHaciaTarget;

		// Token: 0x040003F5 RID: 1013
		public LookAtEstadisticas estadisticasHead;

		// Token: 0x040003F6 RID: 1014
		private LookAtEstadisticas estadisticasHaciaTargetTransformado;

		// Token: 0x040003F7 RID: 1015
		[SerializeField]
		[ReadOnlyUI]
		private Vector3 m_lastProvidedTargetPosition;

		// Token: 0x040003F8 RID: 1016
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastVelocityMod = 1f;

		// Token: 0x040003F9 RID: 1017
		[ReadOnlyUI]
		[SerializeField]
		private int m_lastVSide;

		// Token: 0x040003FA RID: 1018
		[ReadOnlyUI]
		[SerializeField]
		private int m_lastHSide;

		// Token: 0x040003FB RID: 1019
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastAlguloMuertoHaciaAbajo;

		// Token: 0x040003FC RID: 1020
		private List<ILookAtIKTargetTransformer> m_transformadores = new List<ILookAtIKTargetTransformer>();

		// Token: 0x040003FD RID: 1021
		[ReadOnlyUI]
		[SerializeField]
		private float m_deltaTime;

		// Token: 0x040003FE RID: 1022
		private LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorDeAnguloRango;

		// Token: 0x02000180 RID: 384
		public interface IProveedorDeTarget
		{
			// Token: 0x06000C25 RID: 3109
			bool TryObtener(LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, Vector3 bodyForward, Vector3 posicionGlobalOrigen, float minDistance, out Vector3 targetPosition, out float velocityMod, out float w);
		}

		// Token: 0x02000181 RID: 385
		public interface IProveedorDeData
		{
			// Token: 0x06000C26 RID: 3110
			BoneState ObtenerLastBonePreIKEstado();

			// Token: 0x06000C27 RID: 3111
			BoneState ObtenerHeadPreIKEstado();

			// Token: 0x06000C28 RID: 3112
			BoneState ObtenerNeckPreIKEstado();

			// Token: 0x06000C29 RID: 3113
			BoneState ObtenerChestPreIKEstado();

			// Token: 0x06000C2A RID: 3114
			BoneState ObtenerSpinePreIKEstado();

			// Token: 0x06000C2B RID: 3115
			BoneState ObtenerLastBonePostIKEstado();

			// Token: 0x06000C2C RID: 3116
			BoneState ObtenerHeadPostIKEstado();

			// Token: 0x06000C2D RID: 3117
			BoneState ObtenerNeckPostIKEstado();

			// Token: 0x06000C2E RID: 3118
			BoneState ObtenerChestPostIKEstado();

			// Token: 0x06000C2F RID: 3119
			BoneState ObtenerSpinePostIKEstado();
		}

		// Token: 0x02000182 RID: 386
		[Serializable]
		public class AnguloMuertoHaciaAbajoConfig
		{
			// Token: 0x040008BA RID: 2234
			public bool debugDraw;

			// Token: 0x040008BB RID: 2235
			public bool activar = true;

			// Token: 0x040008BC RID: 2236
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x040008BD RID: 2237
			public LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajoConfig.Angles angulosFrontales = new LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajoConfig.Angles
			{
				keepTrack = 15f,
				clamp = 10f
			};

			// Token: 0x040008BE RID: 2238
			public LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajoConfig.Angles angulosTrasero = new LookAtIK_TargetTransformer.AnguloMuertoHaciaAbajoConfig.Angles
			{
				keepTrack = 10f,
				clamp = 10f
			};

			// Token: 0x040008BF RID: 2239
			[Range(0f, 1f)]
			public float consevarMagnitud = 0.5f;

			// Token: 0x040008C0 RID: 2240
			public OrientacionMod verticalMods = new OrientacionMod
			{
				power = 0.33f,
				weight = 1f
			};

			// Token: 0x020001E7 RID: 487
			[Serializable]
			public struct Angles
			{
				// Token: 0x04000A47 RID: 2631
				[Range(0f, 89.9f)]
				public float keepTrack;

				// Token: 0x04000A48 RID: 2632
				[Range(0f, 179.9f)]
				public float clamp;
			}
		}

		// Token: 0x02000183 RID: 387
		[Serializable]
		public class AnguloMuertoHaciaAtrasConfig
		{
			// Token: 0x040008C1 RID: 2241
			public bool debugDraw;

			// Token: 0x040008C2 RID: 2242
			public bool activar = true;

			// Token: 0x040008C3 RID: 2243
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x040008C4 RID: 2244
			[Range(0f, 89.9f)]
			public float anguloMuerto = 35f;

			// Token: 0x040008C5 RID: 2245
			public OrientacionMod verticalMods = new OrientacionMod
			{
				power = 3f,
				weight = 1f
			};
		}
	}
}
