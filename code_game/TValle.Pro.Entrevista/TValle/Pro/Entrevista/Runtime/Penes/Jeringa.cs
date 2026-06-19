using System;
using System.Collections.Generic;
using Assets.Scripts.MeshCalcules;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets.TValle.BeachGirl.Runtime.Characteres.Props;
using Assets.TValle.BeachGirl.Runtime.Skins.Physics;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.Triangles.SkinningShaping;
using Assets.TValle.Pro.Entrevista.Runtime.Penes.AI.ReactoresDeEstimulos;
using Assets.TValle.Pro.Entrevista.Runtime.Penes.Historiales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using Assets._ReusableScripts.PhysicsScripts.Historiales;
using RootMotion.Dynamics;
using TValleCustomClases;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x02000087 RID: 135
	public class Jeringa : AplicableBehaviour, IPeneSimple, IPertenecibleDeCharacter, IComponentStartable, PedidoDePhyscisBakeDeSkin.IUser
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0001F1F3 File Offset: 0x0001D3F3
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0001F1FB File Offset: 0x0001D3FB
		public Transform root
		{
			get
			{
				return this.m_grabbableProp.skeletonRoot;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0001F208 File Offset: 0x0001D408
		public float worldScale
		{
			get
			{
				return this.m_worldScale;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0001F210 File Offset: 0x0001D410
		public float worldMaxWidth
		{
			get
			{
				return this.m_agujaCollider.radius * 2f * this.m_worldScale;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0001F22A File Offset: 0x0001D42A
		public ICharacter inmediateOwner
		{
			get
			{
				return this.m_character.inmediateOwner;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0001F237 File Offset: 0x0001D437
		public Transform tipBone
		{
			get
			{
				return this.m_tipBone;
			}
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001F240 File Offset: 0x0001D440
		private void AwakePenetrationLogic()
		{
			this.m_DelayedReEnableAgujaColliderDelegate = new Action(this.DelayedReEnableAgujaCollider);
			this.m_InyectorDeCalculoDePinchazoConJeringa = base.GetComponent<InyectorDeCalculoDePinchazoConJeringa>();
			if (this.m_InyectorDeCalculoDePinchazoConJeringa == null)
			{
				throw new ArgumentNullException("m_InyectorDeCalculoDePinchazoConJeringa", "m_InyectorDeCalculoDePinchazoConJeringa null reference.");
			}
			this.m_tipPenetratingCollider = this.m_tipBone.CreateChild("SkinPenetration").gameObject.AddComponent<CapsuleCollider>();
			this.m_tipPenetratingCollider.gameObject.layer = ConfiguracionGlobal.layersStatic.toSkinCollider;
			this.m_tipPenetratingCollider.direction = 2;
			this.m_tipPenetratingCollider.radius = this.m_agujaCollider.radius * 0.5f;
			this.m_tipPenetratingCollider.height = this.m_agujaCollider.height * 1.5f;
			this.m_tipPenetratingCollider.center = new Vector3(0f, 0f, -this.m_tipPenetratingCollider.height * 0.5f);
			this.m_tipPenetratingCollider.isTrigger = true;
			this.m_tipPenetratingCollider.gameObject.AddComponent<Rigidbody>().isKinematic = true;
			PuntaDeJeringaColisionable puntaDeJeringaColisionable = this.m_tipPenetratingCollider.gameObject.AddComponent<PuntaDeJeringaColisionable>();
			this.m_velocitySaver = this.m_tipPenetratingCollider.gameObject.AddComponent<EmulatedStepVelocitySaver>();
			puntaDeJeringaColisionable.Init(this.m_velocitySaver, this.m_tipPenetratingCollider);
			HistorialDeCollisonesEmuladasDeRigidBodies historialDeCollisonesEmuladasDeRigidBodies = this.m_tipPenetratingCollider.gameObject.AddComponent<HistorialDeCollisonesEmuladasDeRigidBodies>();
			this.m_tipTocante = this.m_tipPenetratingCollider.gameObject.AddComponent<TocanteObjeto>();
			this.m_agujaCollider.height = this.m_agujaCollider.height - 0.0027781278f;
			historialDeCollisonesEmuladasDeRigidBodies.ManualStart();
			historialDeCollisonesEmuladasDeRigidBodies.historial.collisionEnterBase += this.Historial_collisionEnterBase;
			historialDeCollisonesEmuladasDeRigidBodies.historial.collisionStayBase += this.Historial_collisionStayBase;
			historialDeCollisonesEmuladasDeRigidBodies.historial.collisionExitBase += this.Historial_collisionExitBase;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001F418 File Offset: 0x0001D618
		private void AwakeAplicandoLogic()
		{
			this.m_pumpAccion.fireActionUpdated += this.M_pumpAccion_fireActionUpdated;
			((GrabbableDefinedPropConSensores)this.m_grabbableProp).updatingSensoresData += this.Jeringa_updatingSensoresData;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001F44D File Offset: 0x0001D64D
		private void OnDisablePenetrationLogic()
		{
			this.Clear();
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001F458 File Offset: 0x0001D658
		private void OnUpdateApplication()
		{
			this.m_lastPenetrando = ((this.penetrando != null) ? this.penetrando : this.m_lastPenetrando);
			try
			{
				float num;
				if (!this.m_buffer.IsBuffered(!this.m_applicatedFrame, out num) && this.m_aplicatingWeight > this.m_lastAplicatingWeight)
				{
					try
					{
						Action<float, HitSkinBasica> onAplicating = this.OnAplicating;
						if (onAplicating != null)
						{
							onAplicating(this.m_aplicatingWeight, this.m_lastPenetrando);
						}
					}
					finally
					{
						this.m_lastAplicatingWeight = this.m_aplicatingWeight;
					}
				}
			}
			finally
			{
				this.m_applicatedFrame = false;
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001F500 File Offset: 0x0001D700
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_grabbableProp = base.GetComponent<GrabbableProp>();
			this.m_pumpAccion = base.GetComponent<JeringaAction>();
			if (this.m_grabbableProp == null)
			{
				throw new ArgumentNullException("m_grabbableProp", "m_grabbableProp null reference.");
			}
			this.m_character = base.GetComponent<DummyCharacterParaProps>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			if (this.m_tipBone == null)
			{
				throw new ArgumentNullException("m_tipBone", "m_tipBone null reference.");
			}
			if (this.m_pumpAccion == null)
			{
				throw new ArgumentNullException("m_tipBone", "m_tipBone null reference.");
			}
			if (!this.m_grabbableProp.isAwaken)
			{
				this.m_grabbableProp.ManualAwake();
			}
			this.m_handPositionFormTipBone = this.m_tipBone.InverseTransformPoint(this.m_grabbableProp.handRInteractionTarget.transform.position);
			this.m_handRotationFormTipBone = Quaternion.Inverse(this.m_tipBone.rotation) * this.m_grabbableProp.handRInteractionTarget.transform.rotation;
			this.AwakePenetrationLogic();
			this.AwakeAplicandoLogic();
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001F629 File Offset: 0x0001D829
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.OnDisablePenetrationLogic();
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001F638 File Offset: 0x0001D838
		public void GetColliders(List<Collider> todosResult)
		{
			for (int i = 0; i < this.m_character.colliders.Count; i++)
			{
				Collider collider = this.m_character.colliders[i];
				if (collider.gameObject.activeInHierarchy)
				{
					todosResult.Add(collider);
				}
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0001F686 File Offset: 0x0001D886
		public override void OnUpdateEvent1()
		{
			if (this.root != null)
			{
				this.m_worldScale = this.root.lossyScale.Escala();
			}
			this.OnUpdateApplication();
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001F6B2 File Offset: 0x0001D8B2
		public IPenetrable TryGetPenetratingObject()
		{
			return this.m_penetrando;
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000570 RID: 1392 RVA: 0x0001F6BC File Offset: 0x0001D8BC
		// (remove) Token: 0x06000571 RID: 1393 RVA: 0x0001F6F4 File Offset: 0x0001D8F4
		public event Action<float, HitSkinBasica> OnAplicating;

		// Token: 0x06000572 RID: 1394 RVA: 0x0001F72C File Offset: 0x0001D92C
		private void Jeringa_updatingSensoresData(EmulatedSphereTrigger[] arg1, GrabbableDefinedPropConSensores arg2)
		{
			if (arg1 == null || arg1.Length < 2)
			{
				return;
			}
			EmulatedSphereTrigger emulatedSphereTrigger = arg1[0];
			EmulatedSphereTrigger emulatedSphereTrigger2 = arg1[1];
			if (emulatedSphereTrigger2 == null || emulatedSphereTrigger == null)
			{
				return;
			}
			if (this.m_estadoDeInyeccionPenetracion != Jeringa.EstadoDeInyeccionPenetracion.aplicando || this.m_TriangleAttachmentUser == null || !this.m_TriangleAttachmentUser.initiated)
			{
				emulatedSphereTrigger2.radius = (emulatedSphereTrigger.radius = 1E-05f);
				emulatedSphereTrigger.transform.localPosition = new Vector3(0f, 0f, -0.0075f);
				emulatedSphereTrigger2.transform.localPosition = new Vector3(0f, 0f, 0.0075f);
				return;
			}
			Vector3 vector = this.m_tipBone.InverseTransformPoint(this.m_TriangleAttachmentUser.constrained.position);
			emulatedSphereTrigger.transform.localPosition = new Vector3(0f, 0f, -0.0075f + vector.z);
			emulatedSphereTrigger2.transform.localPosition = new Vector3(0f, 0f, 0.0075f + vector.z);
			float num = Mathf.Max(0.02f, this.m_lastCollisionData.collisionVelocityMag * 0.1f);
			Vector3 normalized = (this.m_lastCollisionData.agujaPos - this.m_lastCollisionData.skinPos).normalized;
			float num2 = Vector3.Dot(this.m_lastCollisionData.agujaVelocity - this.m_lastCollisionData.skinVelocity, normalized);
			float num3 = 1E-05f;
			float num4 = 1E-05f;
			float num5 = 1f;
			if (num2 < -num)
			{
				num3 = 0.01f;
			}
			else if (num2 > num)
			{
				num4 = 0.01f;
			}
			else
			{
				num5 = 0.1f;
			}
			emulatedSphereTrigger.radius = Mathf.MoveTowards(emulatedSphereTrigger.radius, num3, Time.deltaTime * 0.01f * 10f * num5);
			emulatedSphereTrigger2.radius = Mathf.MoveTowards(emulatedSphereTrigger2.radius, num4, Time.deltaTime * 0.01f * 10f * num5);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001F92C File Offset: 0x0001DB2C
		private void M_pumpAccion_fireActionUpdated(float lastValue, float currentValue, float changeVelocityPerSecond, bool changed, bool increasing, GrabbablePropFireAction sender)
		{
			if (this.m_estadoDeInyeccionPenetracion == Jeringa.EstadoDeInyeccionPenetracion.aplicando && increasing && currentValue > lastValue)
			{
				this.m_aplicatingWeight += currentValue - lastValue;
				this.m_applicatedFrame = true;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0001F956 File Offset: 0x0001DB56
		public bool isPenetrating
		{
			get
			{
				return this.m_estadoDeInyeccionPenetracion == Jeringa.EstadoDeInyeccionPenetracion.aplicando;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0001F961 File Offset: 0x0001DB61
		public Jeringa.EstadoDeInyeccionPenetracion estadoDeInyeccionPenetracion
		{
			get
			{
				return this.m_estadoDeInyeccionPenetracion;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0001F969 File Offset: 0x0001DB69
		public HitSkinBasica penetrando
		{
			get
			{
				return this.m_penetrando;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0001F971 File Offset: 0x0001DB71
		public TocanteObjeto tipTocante
		{
			get
			{
				return this.m_tipTocante;
			}
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001F979 File Offset: 0x0001DB79
		private void Historial_collisionEnterBase(ColisionBasicaV2 obj)
		{
			if (this.m_estadoDeInyeccionPenetracion == Jeringa.EstadoDeInyeccionPenetracion.None)
			{
				this.TryStartPenetration_Grabbed(obj);
			}
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001F98C File Offset: 0x0001DB8C
		private void Historial_collisionStayBase(ColisionBasicaV2 obj)
		{
			switch (this.m_estadoDeInyeccionPenetracion)
			{
			case Jeringa.EstadoDeInyeccionPenetracion.None:
				this.TryStartPenetration_Grabbed(obj);
				return;
			case Jeringa.EstadoDeInyeccionPenetracion.contacto:
			case Jeringa.EstadoDeInyeccionPenetracion.penetrando:
				break;
			case Jeringa.EstadoDeInyeccionPenetracion.aplicando:
				if (this.m_penetrandoCollider == obj.colliderChocandonos)
				{
					this.TryUpdatePenetration_Grabbed(obj);
					return;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_estadoDeInyeccionPenetracion.ToString());
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001F9F2 File Offset: 0x0001DBF2
		private void Historial_collisionExitBase(ColisionBasicaV2 obj)
		{
			if (this.m_penetrandoCollider == obj.colliderChocandonos)
			{
				this.Clear();
				return;
			}
			if (this.m_intentadoPenetrandoCollider == obj.colliderChocandonos)
			{
				this.Clear();
			}
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001FA28 File Offset: 0x0001DC28
		private void TryUpdatePenetration_Grabbed(ColisionBasicaV2 obj)
		{
			this.m_lastCollisionData = default(InyectorDeCalculoDePinchazoConJeringa.CollisionData);
			this.m_lastCollisionData.collisionPoint = obj.point.ObtenerVectorGlobal();
			this.m_lastCollisionData.collisionNormal = obj.normalDeSuperficie.ObtenerVectorGlobal();
			this.m_lastCollisionData.collisionVelocity = obj.velocidadEmuladaRelativa;
			this.m_lastCollisionData.collisionVelocityMag = this.m_lastCollisionData.collisionVelocity.magnitude;
			IStepVelocitySaverEmulated nosotrosVelocitySaver = obj.nosotrosVelocitySaver;
			this.m_lastCollisionData.agujaVelocity = ((nosotrosVelocitySaver != null) ? new Vector3?(nosotrosVelocitySaver.metrosPorSegundo) : null).GetValueOrDefault();
			IStepVelocitySaverEmulated otherVelocitySaver = obj.otherVelocitySaver;
			this.m_lastCollisionData.skinVelocity = ((otherVelocitySaver != null) ? new Vector3?(otherVelocitySaver.metrosPorSegundo) : null).GetValueOrDefault();
			this.m_lastCollisionData.agujaPos = this.m_tipPenetratingCollider.transform.position;
			this.m_lastCollisionData.skinPos = obj.colliderChocandonos.transform.position;
			float pumpScore = this.GetPumpScore();
			this.m_InyectorDeCalculoDePinchazoConJeringa.UpdatePinchazo(ref this.m_lastCollisionData, pumpScore);
			if (this.m_TriangleAttachmentUser != null && this.m_TriangleAttachmentUser.initiated && this.m_penetrationJoint != null)
			{
				Vector3 vector = this.CalculeJointConnectedAnchor();
				Jeringa.ConfigJoint(this.m_penetrationJoint, this.m_tipPenetratingCollider, vector);
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0001FB94 File Offset: 0x0001DD94
		private void TryStartPenetration_Grabbed(ColisionBasicaV2 obj)
		{
			if (this.m_grabbableProp.estado != GrabbablePropEstado.Grabbed)
			{
				return;
			}
			if (this.m_grabbableProp.agarradoPor == null)
			{
				return;
			}
			this.Clear();
			HitSkinBasica hitSkinBasica = HitSkinBasica.ObtenerSkinDeCollider(obj.colliderChocandonos);
			if (!(hitSkinBasica == null))
			{
				ArmatureSkins owner = hitSkinBasica.owner;
				if (((owner != null) ? owner.character : null) != null)
				{
					float num = Vector3.Angle(-this.m_tipPenetratingCollider.transform.forward, obj.normalDeSuperficie.ObtenerVectorGlobal());
					float num2;
					if (this.m_InyectorDeCalculoDePinchazoConJeringa.IgnorarPinchazoPenetracionPorAngulo(num, out num2))
					{
						return;
					}
					this.m_lastCollisionData = default(InyectorDeCalculoDePinchazoConJeringa.CollisionData);
					this.m_lastCollisionData.collisionPoint = obj.point.ObtenerVectorGlobal();
					this.m_lastCollisionData.collisionNormal = obj.normalDeSuperficie.ObtenerVectorGlobal();
					this.m_lastCollisionData.collisionVelocity = obj.velocidadEmuladaRelativa;
					this.m_lastCollisionData.collisionVelocityMag = this.m_lastCollisionData.collisionVelocity.magnitude;
					IStepVelocitySaverEmulated nosotrosVelocitySaver = obj.nosotrosVelocitySaver;
					this.m_lastCollisionData.agujaVelocity = ((nosotrosVelocitySaver != null) ? new Vector3?(nosotrosVelocitySaver.metrosPorSegundo) : null).GetValueOrDefault();
					IStepVelocitySaverEmulated otherVelocitySaver = obj.otherVelocitySaver;
					this.m_lastCollisionData.skinVelocity = ((otherVelocitySaver != null) ? new Vector3?(otherVelocitySaver.metrosPorSegundo) : null).GetValueOrDefault();
					this.m_lastCollisionData.agujaPos = this.m_tipPenetratingCollider.transform.position;
					this.m_lastCollisionData.skinPos = obj.colliderChocandonos.transform.position;
					float pumpScore = this.GetPumpScore();
					if (num2 <= 0f)
					{
						this.m_InyectorDeCalculoDePinchazoConJeringa.OneTimePinchazo(hitSkinBasica.owner.character, hitSkinBasica, obj.colliderChocandonos, ref this.m_lastCollisionData, num2, pumpScore, 1f);
						return;
					}
					if (hitSkinBasica.visualSkin == null || !hitSkinBasica.visualSkin.isCookable || !hitSkinBasica.visualSkin.CheckIfIsTriangleAttachable())
					{
						this.m_InyectorDeCalculoDePinchazoConJeringa.OneTimePinchazo(hitSkinBasica.owner.character, hitSkinBasica, obj.colliderChocandonos, ref this.m_lastCollisionData, num2, pumpScore, 0f);
						return;
					}
					AgarranteObjeto agarradoPor = this.m_grabbableProp.agarradoPor;
					Muscle muscle;
					if (agarradoPor == null)
					{
						muscle = null;
					}
					else
					{
						IAgarranteCharacter owner2 = agarradoPor.owner;
						if (owner2 == null)
						{
							muscle = null;
						}
						else
						{
							Character character = owner2.character;
							if (character == null)
							{
								muscle = null;
							}
							else
							{
								PuppetMaster componentEnRoot = character.GetComponentEnRoot<PuppetMaster>();
								muscle = ((componentEnRoot != null) ? componentEnRoot.GetMuscle(this.m_grabbableProp.grabbedBySide, Muscle.GroupCompleto.Hand) : null);
							}
						}
					}
					Muscle muscle2 = muscle;
					if (muscle2 == null)
					{
						Debug.LogError("no se pudo obtener el musculo de ");
						return;
					}
					Jeringa.CookExtradata cookExtradata = new Jeringa.CookExtradata();
					cookExtradata.point = obj.point;
					cookExtradata.normal = obj.normalDeSuperficie;
					cookExtradata.distanceAdd = this.m_tipPenetratingCollider.radius * this.m_worldScale;
					cookExtradata.angleScore = num2;
					cookExtradata.pumpScore = pumpScore;
					cookExtradata.dominateBone = muscle2.target;
					cookExtradata.dominateRigid = muscle2.rigidbody;
					cookExtradata.chocandonos = obj.colliderChocandonos;
					cookExtradata.collisionData = this.m_lastCollisionData;
					cookExtradata.pinchada = hitSkinBasica;
					this.m_intentadoPenetrandoCollider = obj.colliderChocandonos;
					hitSkinBasica.visualSkin.Cook(this, false, cookExtradata);
					this.ChangeEstadoDePenetracion(Jeringa.EstadoDeInyeccionPenetracion.contacto);
					return;
				}
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001FEC8 File Offset: 0x0001E0C8
		private Vector3 CalculeJointConnectedAnchor()
		{
			Vector3 position = this.m_TriangleAttachmentUser.transform.position;
			Quaternion rotation = this.m_TriangleAttachmentUser.transform.rotation;
			float magnitude = (Math3d.ProjectPointOnLine(position, rotation * Vector3.forward, this.m_tipBone.position) - position).magnitude;
			Vector3 lossyScale = this.m_tipBone.lossyScale;
			float num = lossyScale.Escala();
			float num2 = magnitude / num;
			Vector3 initialConectorAnchor = this.m_initialConectorAnchor;
			Vector3 vector = Matrix4x4.TRS(position, rotation, lossyScale).MultiplyPoint3x4(this.m_handPositionFormTipBone);
			Quaternion quaternion = rotation * this.m_handRotationFormTipBone;
			Vector3 vector2 = Matrix4x4.TRS(vector + rotation * (Vector3.forward * num2), quaternion, lossyScale).inverse.MultiplyPoint3x4(position);
			if (num2 < 0.0025f)
			{
				return initialConectorAnchor;
			}
			if (num2 < 0.01f)
			{
				float num3 = Mathf.InverseLerp(0.0025f, 0.01f, num2);
				return Vector3.Lerp(initialConectorAnchor, vector2, num3);
			}
			return vector2;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001FFD0 File Offset: 0x0001E1D0
		private float GetPumpScore()
		{
			if (this.m_pumpAccion.currentFireActionSpeedPerSecond > 0f)
			{
				return Mathf.InverseLerp(this.m_pumpAccion.fireInActionSpeed * 2f, this.m_pumpAccion.fireInActionSpeed * 0.5f, this.m_pumpAccion.currentFireActionSpeedPerSecond);
			}
			return 1f;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00020028 File Offset: 0x0001E228
		void PedidoDePhyscisBakeDeSkin.IUser.OnCooked(Mesh mesh, MeshCollider collider, object ExtraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender)
		{
			if (this.m_estadoDeInyeccionPenetracion != Jeringa.EstadoDeInyeccionPenetracion.contacto)
			{
				return;
			}
			Jeringa.CookExtradata extraData = ExtraData as Jeringa.CookExtradata;
			RaycastHit hit;
			if (!Jeringa.TryCastToCookedCollider(collider, extraData, sender, out hit))
			{
				this.ChangeEstadoDePenetracion(Jeringa.EstadoDeInyeccionPenetracion.None);
				return;
			}
			Transform transform = this.m_tipPenetratingCollider.transform;
			Vector3 barycentricCoordinate = hit.barycentricCoordinate;
			int vertexIndex0;
			int vertexIndex1;
			int vertexIndex2;
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			Vector3 vector4;
			Vector3 vector5;
			Vector3 vector6;
			Vector3 vector7;
			Vector3 vector8;
			Vector3 vector9;
			Vector3 vector10;
			Vector3 vector11;
			Vector3 vector12;
			Vector3 vector13;
			Vector3 vector14;
			Vector3 vector15;
			Vector3 vector16;
			Vector3 vector17;
			Vector3 vector18;
			sender.GetWorldVerticesOfTriangle(hit.triangleIndex, out vertexIndex0, out vertexIndex1, out vertexIndex2, out vector, out vector2, out vector3, out vector4, out vector5, out vector6, out vector7, out vector8, out vector9, out vector10, out vector11, out vector12, out vector13, out vector14, out vector15, out vector16, out vector17, out vector18);
			Quaternion.Inverse(sender.owner.skinnedMeshRenderer.transform.rotation) * transform.rotation;
			Vector3 vector19 = vector13 * barycentricCoordinate.x + vector14 * barycentricCoordinate.y + vector15 * barycentricCoordinate.z;
			Vector3 vector20 = vector16 * barycentricCoordinate.x + vector17 * barycentricCoordinate.y + vector18 * barycentricCoordinate.z;
			Quaternion quaternion = Quaternion.LookRotation(vector19, vector20);
			Transform transform2 = base.transform.CreateChild("InyeccionPoint");
			transform2.SetPositionAndRotation(hit.point, transform.rotation);
			this.m_TriangleAttachmentUser = transform2.gameObject.AddComponent<SkinAndShapeTransformToTriangleSurfaceUser>();
			this.m_TriangleAttachmentUser.onSystemaDisabled += this.M_TriangleAttachmentUser_onSystemaDisabled;
			this.m_TriangleAttachmentUser.onSystemaDestroyed += this.M_TriangleAttachmentUser_onSystemaDisabled;
			this.m_TriangleAttachmentUser.barycentricsCoordinates = barycentricCoordinate;
			this.m_TriangleAttachmentUser.deltaRotation = Quaternion.Inverse(quaternion) * transform.rotation;
			this.m_TriangleAttachmentUser.deltaPosition = new Vector3(0f, 0f, 0f);
			this.m_TriangleAttachmentUser.Init(cooked.triangleAttachmentSystem, this.m_TriangleAttachmentUser.transform, hit.triangleIndex);
			this.ChangeEstadoDePenetracion(Jeringa.EstadoDeInyeccionPenetracion.penetrando);
			SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser = this.m_TriangleAttachmentUser;
			triangleAttachmentUser.onFirstUpdated = (Action<SkinAndShapeTransformToTriangleSurfaceUser>)Delegate.Combine(triangleAttachmentUser.onFirstUpdated, new Action<SkinAndShapeTransformToTriangleSurfaceUser>(delegate(SkinAndShapeTransformToTriangleSurfaceUser c)
			{
				if (this.m_estadoDeInyeccionPenetracion != Jeringa.EstadoDeInyeccionPenetracion.penetrando)
				{
					return;
				}
				this.m_penetrando = extraData.pinchada;
				this.m_penetrandoCollider = extraData.chocandonos;
				this.m_intentadoPenetrandoCollider = null;
				this.m_penetrationJoint = Jeringa.CreateJoint(this.m_TriangleAttachmentUser.gameObject, extraData.dominateRigid);
				Matrix4x4 matrix4x = Matrix4x4.TRS(extraData.dominateBone.position, extraData.dominateBone.rotation, extraData.dominateBone.lossyScale);
				this.m_initialConectorAnchor = matrix4x.inverse.MultiplyPoint3x4(hit.point);
				Jeringa.ConfigJoint(this.m_penetrationJoint, this.m_tipPenetratingCollider, this.m_initialConectorAnchor);
				float num = ((!this.m_TriangleAttachmentUser.initiated) ? 1f : Jeringa.GetInyectionNalgasScore(this.m_TriangleAttachmentUser, new int3(vertexIndex0, vertexIndex1, vertexIndex2), barycentricCoordinate));
				num = num.OutPow(3f);
				this.ChangeEstadoDePenetracion(Jeringa.EstadoDeInyeccionPenetracion.aplicando);
				this.m_InyectorDeCalculoDePinchazoConJeringa.StartPinchazo(cooked.owner.character, extraData.pinchada, extraData.chocandonos, ref extraData.collisionData, extraData.angleScore, extraData.pumpScore, num);
			}));
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x000202A8 File Offset: 0x0001E4A8
		private static float GetInyectionNalgasScore(SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser, int3 triangle, Vector3 bary)
		{
			LocalSystemSkinAndShapeTransformToTriangleSurface system = triangleAttachmentUser.system;
			IWorkingMesh workingMesh = ((system != null) ? system.meshData : null);
			IMeshSkeleton meshSkeleton = ((workingMesh != null) ? workingMesh.meshSkeleton : null);
			if (meshSkeleton == null)
			{
				Debug.LogError("injection was not valid attached", triangleAttachmentUser);
				return 0f;
			}
			NativeParallelMultiHashMap<int, BoneWeight1> allBoneWeightsPerVertIndex = workingMesh.allBoneWeightsPerVertIndex;
			float num;
			Jeringa.VertexHasNalgas(triangle.x, meshSkeleton, allBoneWeightsPerVertIndex, out num);
			float num2;
			Jeringa.VertexHasNalgas(triangle.y, meshSkeleton, allBoneWeightsPerVertIndex, out num2);
			float num3;
			Jeringa.VertexHasNalgas(triangle.z, meshSkeleton, allBoneWeightsPerVertIndex, out num3);
			return num * bary.x + num2 * bary.y + num3 * bary.z;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0002033C File Offset: 0x0001E53C
		private static bool VertexHasNalgas(int vertexIndex, IMeshSkeleton meshSkeleton, NativeParallelMultiHashMap<int, BoneWeight1> boneMap, out float score)
		{
			score = 0f;
			BoneWeight1 boneWeight;
			NativeParallelMultiHashMapIterator<int> nativeParallelMultiHashMapIterator;
			if (boneMap.TryGetFirstValue(vertexIndex, out boneWeight, out nativeParallelMultiHashMapIterator))
			{
				for (;;)
				{
					string text = meshSkeleton.NameDeBone(boneWeight.boneIndex);
					if (Jeringa.m_VG_Nalgas.Contains(text))
					{
						break;
					}
					if (!boneMap.TryGetNextValue(out boneWeight, ref nativeParallelMultiHashMapIterator))
					{
						return false;
					}
				}
				score = boneWeight.weight;
				return true;
			}
			return false;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00020392 File Offset: 0x0001E592
		private static ConfigurableJoint CreateJoint(GameObject owner, Rigidbody target)
		{
			owner.GetComponentNotNull<Rigidbody>().isKinematic = true;
			ConfigurableJoint componentNotNull = owner.GetComponentNotNull<ConfigurableJoint>();
			componentNotNull.autoConfigureConnectedAnchor = false;
			componentNotNull.connectedBody = target;
			return componentNotNull;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x000203B4 File Offset: 0x0001E5B4
		private static void ConfigJoint(ConfigurableJoint joint, CapsuleCollider agujaCollider, Vector3 connectedAnchor)
		{
			joint.connectedAnchor = connectedAnchor;
			joint.xMotion = (joint.yMotion = (joint.zMotion = ConfigurableJointMotion.Locked));
			joint.angularXMotion = (joint.angularYMotion = (joint.angularZMotion = ConfigurableJointMotion.Locked));
			joint.zMotion = ConfigurableJointMotion.Limited;
			joint.linearLimit = new SoftJointLimit
			{
				limit = agujaCollider.height * agujaCollider.transform.lossyScale.Escala() * 0.6666667f * 1.1f
			};
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0002043C File Offset: 0x0001E63C
		private void ChangeEstadoDePenetracion(Jeringa.EstadoDeInyeccionPenetracion newEstado)
		{
			GlobalUpdater.instancia.CancelarInvocacionPorDelegado(this.m_DelayedReEnableAgujaColliderDelegate);
			switch (newEstado)
			{
			case Jeringa.EstadoDeInyeccionPenetracion.None:
				GlobalUpdater.instancia.Invokar(this.m_DelayedReEnableAgujaColliderDelegate, 0.333f);
				this.m_grabbableProp.alwaysFollowHandBoneOnGrabbedOverride = null;
				break;
			case Jeringa.EstadoDeInyeccionPenetracion.contacto:
				this.m_agujaCollider.enabled = false;
				this.m_grabbableProp.alwaysFollowHandBoneOnGrabbedOverride = null;
				break;
			case Jeringa.EstadoDeInyeccionPenetracion.penetrando:
				this.m_agujaCollider.enabled = false;
				this.m_grabbableProp.alwaysFollowHandBoneOnGrabbedOverride = new bool?(false);
				break;
			case Jeringa.EstadoDeInyeccionPenetracion.aplicando:
				this.m_agujaCollider.enabled = false;
				this.m_grabbableProp.alwaysFollowHandBoneOnGrabbedOverride = new bool?(false);
				break;
			default:
				throw new ArgumentOutOfRangeException(newEstado.ToString());
			}
			this.m_estadoDeInyeccionPenetracion = newEstado;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0002051B File Offset: 0x0001E71B
		private void DelayedReEnableAgujaCollider()
		{
			if (this.m_agujaCollider != null)
			{
				this.m_agujaCollider.enabled = true;
			}
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00020538 File Offset: 0x0001E738
		private void Clear()
		{
			SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser = this.m_TriangleAttachmentUser;
			if (((triangleAttachmentUser != null) ? triangleAttachmentUser.gameObject : null) != null)
			{
				Object.Destroy(this.m_TriangleAttachmentUser.gameObject);
			}
			this.m_TriangleAttachmentUser = null;
			this.m_penetrationJoint = null;
			this.m_penetrando = null;
			this.m_penetrandoCollider = null;
			this.m_intentadoPenetrandoCollider = null;
			this.ChangeEstadoDePenetracion(Jeringa.EstadoDeInyeccionPenetracion.None);
			InyectorDeCalculoDePinchazoConJeringa inyectorDeCalculoDePinchazoConJeringa = this.m_InyectorDeCalculoDePinchazoConJeringa;
			if (inyectorDeCalculoDePinchazoConJeringa == null)
			{
				return;
			}
			inyectorDeCalculoDePinchazoConJeringa.DetenerPinchazo();
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x000205AC File Offset: 0x0001E7AC
		private static bool TryCastToCookedCollider(MeshCollider collider, Jeringa.CookExtradata extraData, PedidoDePhyscisBakeDeSkin pedido, out RaycastHit hit)
		{
			hit = default(RaycastHit);
			if (extraData == null)
			{
				return false;
			}
			Vector3 vector = extraData.point.ObtenerVectorGlobal();
			Vector3 vector2 = extraData.normal.ObtenerVectorGlobal();
			return ExtendedMonoBehaviour.TryGetHitFormCollider(collider, vector, -vector2, false, out hit, extraData.distanceAdd, 1f, false, 1f) && pedido.TriangleIndexIsValid(hit.triangleIndex) && hit.distance > 0f;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00020621 File Offset: 0x0001E821
		private void M_TriangleAttachmentUser_onSystemaDisabled(SkinAndShapeTransformToTriangleSurfaceUser obj)
		{
			this.Clear();
		}

		// Token: 0x0400034A RID: 842
		[Header("General")]
		[SerializeField]
		private Transform m_tipBone;

		// Token: 0x0400034B RID: 843
		[SerializeField]
		private CapsuleCollider m_agujaCollider;

		// Token: 0x0400034C RID: 844
		[ReadOnlyUI]
		[SerializeField]
		private float m_worldScale;

		// Token: 0x0400034D RID: 845
		private GrabbableProp m_grabbableProp;

		// Token: 0x0400034E RID: 846
		private DummyCharacterParaProps m_character;

		// Token: 0x0400034F RID: 847
		private JeringaAction m_pumpAccion;

		// Token: 0x04000350 RID: 848
		private Vector3 m_handPositionFormTipBone;

		// Token: 0x04000351 RID: 849
		private Quaternion m_handRotationFormTipBone;

		// Token: 0x04000352 RID: 850
		[Header("Aplication")]
		[SerializeField]
		[ReadOnlyUI]
		private float m_aplicatingWeight;

		// Token: 0x04000353 RID: 851
		private BufferedCoolDown m_buffer = new BufferedCoolDown();

		// Token: 0x04000354 RID: 852
		[NonSerialized]
		private bool m_applicatedFrame;

		// Token: 0x04000355 RID: 853
		[NonSerialized]
		private float m_lastAplicatingWeight;

		// Token: 0x04000357 RID: 855
		[NonSerialized]
		private HitSkinBasica m_lastPenetrando;

		// Token: 0x04000358 RID: 856
		private static readonly HashSet<string> m_VG_Nalgas = new HashSet<string> { "DEF_Glute.L", "DEF_Glute.R" };

		// Token: 0x04000359 RID: 857
		private CapsuleCollider m_tipPenetratingCollider;

		// Token: 0x0400035A RID: 858
		private InyectorDeCalculoDePinchazoConJeringa m_InyectorDeCalculoDePinchazoConJeringa;

		// Token: 0x0400035B RID: 859
		private TocanteObjeto m_tipTocante;

		// Token: 0x0400035C RID: 860
		private EmulatedStepVelocitySaver m_velocitySaver;

		// Token: 0x0400035D RID: 861
		[Header("Penetration")]
		[SerializeField]
		[ReadOnlyUI]
		private Jeringa.EstadoDeInyeccionPenetracion m_estadoDeInyeccionPenetracion;

		// Token: 0x0400035E RID: 862
		[ReadOnlyUI]
		[SerializeField]
		private SkinAndShapeTransformToTriangleSurfaceUser m_TriangleAttachmentUser;

		// Token: 0x0400035F RID: 863
		[ReadOnlyUI]
		[SerializeField]
		private HitSkinBasica m_penetrando;

		// Token: 0x04000360 RID: 864
		[ReadOnlyUI]
		[SerializeField]
		private Collider m_penetrandoCollider;

		// Token: 0x04000361 RID: 865
		[ReadOnlyUI]
		[SerializeField]
		private Collider m_intentadoPenetrandoCollider;

		// Token: 0x04000362 RID: 866
		[ReadOnlyUI]
		[SerializeField]
		private ConfigurableJoint m_penetrationJoint;

		// Token: 0x04000363 RID: 867
		private const float AgujaHeightBonus = 1.5f;

		// Token: 0x04000364 RID: 868
		private const float AgujaHeightReduccion = 0.0027781278f;

		// Token: 0x04000365 RID: 869
		[SerializeField]
		[ReadOnly]
		private InyectorDeCalculoDePinchazoConJeringa.CollisionData m_lastCollisionData;

		// Token: 0x04000366 RID: 870
		private Vector3 m_initialConectorAnchor;

		// Token: 0x04000367 RID: 871
		private Action m_DelayedReEnableAgujaColliderDelegate;

		// Token: 0x02000211 RID: 529
		private class CookExtradata
		{
			// Token: 0x040009FE RID: 2558
			public Vector point;

			// Token: 0x040009FF RID: 2559
			public Vector normal;

			// Token: 0x04000A00 RID: 2560
			public HitSkinBasica pinchada;

			// Token: 0x04000A01 RID: 2561
			public Transform dominateBone;

			// Token: 0x04000A02 RID: 2562
			public Rigidbody dominateRigid;

			// Token: 0x04000A03 RID: 2563
			public Collider chocandonos;

			// Token: 0x04000A04 RID: 2564
			public float distanceAdd;

			// Token: 0x04000A05 RID: 2565
			public float angleScore;

			// Token: 0x04000A06 RID: 2566
			public float pumpScore;

			// Token: 0x04000A07 RID: 2567
			public InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData;
		}

		// Token: 0x02000212 RID: 530
		public enum EstadoDeInyeccionPenetracion
		{
			// Token: 0x04000A09 RID: 2569
			None,
			// Token: 0x04000A0A RID: 2570
			contacto,
			// Token: 0x04000A0B RID: 2571
			penetrando,
			// Token: 0x04000A0C RID: 2572
			aplicando
		}
	}
}
