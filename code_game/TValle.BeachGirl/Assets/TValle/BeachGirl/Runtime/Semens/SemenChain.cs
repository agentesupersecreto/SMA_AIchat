using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.Abstracts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Puntos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Semens
{
	// Token: 0x0200006E RID: 110
	public sealed class SemenChain : LinearChainDestruible<PuntoGenerico, PuntoGenerico.Configuracion>
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00005C88 File Offset: 0x00003E88
		public IReadOnlyList<SemenPunto> semenPuntos
		{
			get
			{
				return this.m_semenPuntos;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00005C90 File Offset: 0x00003E90
		public override int cantidadDePuntos
		{
			get
			{
				return this.m_puntosTransform.Length - 1;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00005C9C File Offset: 0x00003E9C
		public EmisorDeSemenChain emisor
		{
			get
			{
				return this.m_EmisorDeSemenChain;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00005CA4 File Offset: 0x00003EA4
		public Object sender
		{
			get
			{
				return this.m_sender;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00005CAC File Offset: 0x00003EAC
		// (set) Token: 0x0600021A RID: 538 RVA: 0x00005CB9 File Offset: 0x00003EB9
		public ICharacter owner
		{
			get
			{
				return this.m_owner as ICharacter;
			}
			private set
			{
				this.m_owner = value as Object;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00005CC7 File Offset: 0x00003EC7
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00005CD4 File Offset: 0x00003ED4
		public IPeneSimple ownerPene
		{
			get
			{
				return this.m_ownerPene as IPeneSimple;
			}
			private set
			{
				this.m_ownerPene = value as Object;
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00005CE2 File Offset: 0x00003EE2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00005CEC File Offset: 0x00003EEC
		public void SetReferences(PuntoGenerico.Configuracion PuntosConfig, SemenPunto.Config SemenPuntoConfig, TipoDeSemen SemenPuntoTipo, ICharacter Owner, IPeneSimple OwnerPene, EmisorDeSemenChain Emisor, Object Sender, IReadOnlyList<Transform> puntos)
		{
			if (puntos == null || puntos.Count == 0)
			{
				throw new InvalidOperationException("there are no semen points");
			}
			this.puntosConfig = PuntosConfig;
			this.semenPuntoTipo = SemenPuntoTipo;
			this.semenPuntoConfig = SemenPuntoConfig;
			this.owner = Owner;
			this.ownerPene = OwnerPene;
			this.m_EmisorDeSemenChain = Emisor;
			this.m_sender = Sender;
			this.m_puntosTransform = puntos.ToArray<Transform>();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00005D54 File Offset: 0x00003F54
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			while (this.owner == null)
			{
				this.owner = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character;
			}
			for (int i = 0; i < this.m_puntosTransform.Length; i++)
			{
				Transform transform = this.m_puntosTransform[i];
				Transform transform2 = transform.FindDeepChildStartWith("Bone1", true);
				Transform transform3 = transform2.Copy("Body");
				transform3.parent = transform;
				Rigidbody rigidbody = transform3.gameObject.AddComponent<Rigidbody>();
				this.m_SkeletonAndBodyDePunto.Add(transform, new ValueTuple<Transform, Rigidbody>(transform2, rigidbody));
			}
			Transform transform4 = this.m_puntosTransform[this.m_puntosTransform.Length - 1];
			this.LoadPuntos();
			this.m_lastSemenPunto = this.AddPunto(transform4);
			base.StartPoints();
			this.m_lastPointJointBodyAdmin = this.m_SkeletonAndBodyDePunto[transform4].Item2.GetComponentNotNull<JointBodyAdmin>();
			this.m_lastPointJointBodyAdmin.configuracion = this.puntosConfig.jointBodyAdmin;
			this.AddCollider(this.m_lastPointJointBodyAdmin.ownTransform);
			this.m_lastPointJointBodyAdmin.Fix();
			this.InitSemenPuntos();
			this.StartSemenPuntos();
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = ConfiguracionGlobal.layersStatic.touchingHand;
			}, true);
			this.IgnorarCollisiones();
			for (int j = 0; j < this.m_semenPuntos.Count; j++)
			{
				this.m_semenPuntos[j].transform.parent = null;
			}
			GlobalUpdater.instancia.Invokar(new Action(this.SelfDestroy), 1f);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00005EE0 File Offset: 0x000040E0
		private void SelfDestroy()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00005EF0 File Offset: 0x000040F0
		protected override Transform GetCharBoneTargetTransformOfPoint(int index)
		{
			Transform transform = this.m_puntosTransform[index];
			return this.m_SkeletonAndBodyDePunto[transform].Item1;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00005F18 File Offset: 0x00004118
		protected override Transform GetJointTransformOfPoint(int index)
		{
			Transform transform = this.m_puntosTransform[index];
			return this.m_SkeletonAndBodyDePunto[transform].Item2.transform;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00005F44 File Offset: 0x00004144
		protected override Transform GetTargetBodyTransformOfPoint(int index)
		{
			Transform transform = this.m_puntosTransform[index + 1];
			return this.m_SkeletonAndBodyDePunto[transform].Item2.transform;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00005F74 File Offset: 0x00004174
		protected override void CustomizarPunto(PuntoGenerico punto, int index)
		{
			base.CustomizarPunto(punto, index);
			punto.isInverted = false;
			SemenPunto semenPunto = this.AddPunto(this.m_puntosTransform[index]);
			this.m_indexDeSemenPunto.Add(semenPunto, index);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00005FAC File Offset: 0x000041AC
		private SemenPunto AddPunto(Transform trans)
		{
			SemenPunto componentNotNull = trans.GetComponentNotNull<SemenPunto>();
			componentNotNull.SetTipo(this.semenPuntoTipo);
			this.m_semenPuntos.Add(componentNotNull);
			this.m_puntoSemenDePunto.Add(trans, componentNotNull);
			componentNotNull.config = this.semenPuntoConfig;
			return componentNotNull;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00005FF2 File Offset: 0x000041F2
		protected override void AfterStartPoint(PuntoGenerico point)
		{
			base.AfterStartPoint(point);
			this.AddCollider(point.jointTransform);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00006008 File Offset: 0x00004208
		private void AddCollider(Transform trans)
		{
			SphereCollider sphereCollider = trans.gameObject.AddComponent<SphereCollider>();
			sphereCollider.contactOffset = this.semenPuntoConfig.colliderRadius / 2f;
			sphereCollider.radius = this.semenPuntoConfig.colliderRadius;
			switch (this.semenPuntoTipo)
			{
			case TipoDeSemen.semen:
				sphereCollider.sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.semen;
				break;
			case TipoDeSemen.water:
				sphereCollider.sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.water;
				break;
			case TipoDeSemen.lubricante:
				sphereCollider.sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.lube;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.semenPuntoTipo.ToString());
			}
			this.m_puntosColliders.Add(sphereCollider);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000060C0 File Offset: 0x000042C0
		private void InitSemenPuntos()
		{
			for (int i = 0; i < this.m_semenPuntos.Count; i++)
			{
				Transform transform = this.m_puntosTransform[i];
				SemenPunto semenPunto = null;
				SemenPunto semenPunto2 = null;
				if (i > 0)
				{
					semenPunto = this.m_semenPuntos[i - 1];
				}
				if (!i.IsLastIndex(this.m_semenPuntos.Count))
				{
					semenPunto2 = this.m_semenPuntos[i + 1];
				}
				SemenPunto semenPunto3 = this.m_semenPuntos[i];
				semenPunto3.Init(this.owner, this.ownerPene, i, semenPunto, semenPunto2, this.m_SkeletonAndBodyDePunto[transform].Item2, this.m_puntosColliders[i], semenPunto3.GetComponentInChildren<Renderer>());
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00006174 File Offset: 0x00004374
		private void StartSemenPuntos()
		{
			for (int i = 0; i < this.m_semenPuntos.Count; i++)
			{
				this.m_semenPuntos[i].ManualStart();
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000061A8 File Offset: 0x000043A8
		private void IgnorarCollisiones()
		{
			ExtendedMonoBehaviour.IgnorarCollisionesV2(this.m_puntosColliders, true);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000061B6 File Offset: 0x000043B6
		public override void FixEnOrdenAsc()
		{
			base.FixEnOrdenAsc();
			this.m_lastPointJointBodyAdmin.Fix();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000061C9 File Offset: 0x000043C9
		public override void KillForces()
		{
			base.KillForces();
			this.m_lastPointJointBodyAdmin.KillForces();
		}

		// Token: 0x04000150 RID: 336
		public SemenPunto.Config semenPuntoConfig = new SemenPunto.Config();

		// Token: 0x04000151 RID: 337
		public TipoDeSemen semenPuntoTipo;

		// Token: 0x04000152 RID: 338
		[SerializeField]
		private Transform[] m_puntosTransform;

		// Token: 0x04000153 RID: 339
		[SerializeField]
		private List<SphereCollider> m_puntosColliders = new List<SphereCollider>();

		// Token: 0x04000154 RID: 340
		[SerializeField]
		private List<SemenPunto> m_semenPuntos = new List<SemenPunto>();

		// Token: 0x04000155 RID: 341
		private Dictionary<Transform, SemenPunto> m_puntoSemenDePunto = new Dictionary<Transform, SemenPunto>();

		// Token: 0x04000156 RID: 342
		private Dictionary<SemenPunto, int> m_indexDeSemenPunto = new Dictionary<SemenPunto, int>();

		// Token: 0x04000157 RID: 343
		[ConstraintType(typeof(ICharacter), true)]
		[SerializeField]
		private Object m_owner;

		// Token: 0x04000158 RID: 344
		[ConstraintType(typeof(IPeneSimple), true)]
		[SerializeField]
		private Object m_ownerPene;

		// Token: 0x04000159 RID: 345
		[SerializeField]
		private EmisorDeSemenChain m_EmisorDeSemenChain;

		// Token: 0x0400015A RID: 346
		[SerializeField]
		private Object m_sender;

		// Token: 0x0400015B RID: 347
		private JointBodyAdmin m_lastPointJointBodyAdmin;

		// Token: 0x0400015C RID: 348
		private SemenPunto m_lastSemenPunto;

		// Token: 0x0400015D RID: 349
		private Dictionary<Transform, ValueTuple<Transform, Rigidbody>> m_SkeletonAndBodyDePunto = new Dictionary<Transform, ValueTuple<Transform, Rigidbody>>();
	}
}
