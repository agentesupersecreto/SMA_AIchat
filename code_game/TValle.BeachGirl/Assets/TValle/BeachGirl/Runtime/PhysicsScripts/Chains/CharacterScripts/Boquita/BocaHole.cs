using System;
using Assets.Base.Joints;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000085 RID: 133
	public sealed class BocaHole : GenericFemaleHole2, IBocaHole, IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole
	{
		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000B0AB File Offset: 0x000092AB
		public sealed override GlobalUpdater.UpdateType? updateEvent3
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x0000B0B4 File Offset: 0x000092B4
		public TipoDeOralSex currentOralSexTipo
		{
			get
			{
				return this.m_currentOralSexTipo;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000B0BC File Offset: 0x000092BC
		protected override ChainPointStretcherJoint.ConfigTipo wallJointsConfigTipo
		{
			get
			{
				return ChainPointStretcherJoint.ConfigTipo.bocaHole;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000B0BF File Offset: 0x000092BF
		public override bool usarLimitadorDePolaridad
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x0000B0C2 File Offset: 0x000092C2
		protected override PhysicMaterial wallMaterial
		{
			get
			{
				return Singleton<ColecionDePhysicsMaterials>.instance.innerBoca;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0000B0CE File Offset: 0x000092CE
		protected override string boneRootName
		{
			get
			{
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabiosRoot;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x0000B0DA File Offset: 0x000092DA
		protected override string boneEntradaName
		{
			get
			{
				return this.m_entradaName;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060003AA RID: 938 RVA: 0x0000B0E2 File Offset: 0x000092E2
		protected override bool useScaleBroadcaster
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060003AB RID: 939 RVA: 0x0000B0E5 File Offset: 0x000092E5
		protected override string _12Name
		{
			get
			{
				return "Boca.Entrada.Up";
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060003AC RID: 940 RVA: 0x0000B0EC File Offset: 0x000092EC
		protected override string _6Name
		{
			get
			{
				return "Boca.Entrada.Down";
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0000B0F3 File Offset: 0x000092F3
		protected override bool chainRigidbodyIsKinematic
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060003AE RID: 942 RVA: 0x0000B0F6 File Offset: 0x000092F6
		public Rigidbody rootParaNoPenetracionSuckJoints
		{
			get
			{
				return this.m_nonPenetratedSuckJointsRoot;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0000B0FE File Offset: 0x000092FE
		public override IHoleInternals internals
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000B104 File Offset: 0x00009304
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.holeConfig = new BoneStretchedChain.HoleConfig();
			this.holeConfig.hasVirtualProfundidad = true;
			this.holeConfig.fixedVirtualProfundidad = 0.35f;
			this.holeConfig.fondoLocalPosition = -this.holeConfig.outLocalDirection.normalized * 0.06f;
			this.holeConfig.wallCollidersProfundidad = 0.03f;
			this.holeConfig.maxAnchuraVirtual = 0.03f;
			this.penetracionesConfig = new Penetraciones.Config();
			this.penetracionesConfig.activarHelpler = false;
			this.polaridadLimiterConfig = new LimitarPolaridadDeAxis.Configuracion();
			this.polaridadLimiterConfig.axisPolarizado = AxisPolarizado.None;
			this.creatorConfig = new CircularChainPointStretcherCreator.Configuracion();
			this.creatorConfig.distance = 0.02f;
			this.creatorConfig.overrideOutDirection = true;
			this.creatorConfig.overridingOutDirection = Vector3.up;
			this.colliderConfig = new HoleWallPointCollider.Configuracion();
			this.colliderConfig.penetratedRadius = 0.005f;
			this.colliderConfig.initialRadius = 0.005f;
			this.colliderConfig.direction = 2;
			this.puntosCreationConfig = new BocaHole.PuntosCreationConfig();
			this.puntosCreationConfig.upwardsOffset = new Vector3(0f, 0.001f, 0.006f);
			this.puntosCreationConfig.downwardsOffset = new Vector3(0f, -0.001f, 0.002f);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000B270 File Offset: 0x00009470
		protected override void AwakeUnityEvent()
		{
			this.m_hardPointDeGarganta.id = "GARGANTA";
			this.m_hardPointDeGarganta.SetProfundidadLocal(0.095f);
			this.m_hardPointDeGarganta.SetRadiusLocal(0.03333334f);
			this.m_hardPointDeGarganta.resistenciaMod = 1f;
			this.m_hardPointDeGarganta.passResistenciaMod = 2f;
			this.m_hardPointDeGarganta.maxDesgastePorSegundo = 0.005f;
			this.m_hardPointDeGarganta.aiWeight = 1f;
			base.AddOrReplacePunto(this.m_hardPointDeGarganta);
			this.m_entradaName = MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabiosEntrada + "_Entrada";
			base.transform.CreateChild(this.m_entradaName);
			base.AwakeUnityEvent();
			this.m_nonPenetratedSuckJointsRoot = base.entrada.CreateChild("nonPenetratedSuckJointsRoot", true).gameObject.AddComponent<Rigidbody>();
			this.m_nonPenetratedSuckJointsRoot.isKinematic = true;
			this.m_nonPenetratedSuckJointsRoot.transform.localPosition = -Vector3.forward * 0.01f;
			Transform transform = base.transform.CreateChild(this._12Name);
			Transform transform2 = base.transform.CreateChild(this._6Name);
			transform.rotation = (transform2.rotation = base.entradaTransform.rotation);
			transform2.rotation *= Quaternion.AngleAxis(180f, Vector3.forward);
			transform.position = base.entradaTransform.TransformPoint(this.puntosCreationConfig.upwardsOffset);
			transform2.position = base.entradaTransform.TransformPoint(this.puntosCreationConfig.downwardsOffset);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000B410 File Offset: 0x00009610
		protected sealed override bool CercaDeHardPointsExtra()
		{
			return this.m_currentOralSexTipo == TipoDeOralSex.conEsofago || this.m_currentOralSexTipo == TipoDeOralSex.conGarganta;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000B426 File Offset: 0x00009626
		protected override void CrearPuntoCreandoStretchBase(CircularChainPointStretcherCreator creadorDePunto, Transform pointParent, float upOffset, int puntoID)
		{
			base.CrearPuntoCreandoStretchBase(creadorDePunto, pointParent, upOffset, puntoID);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000B434 File Offset: 0x00009634
		public sealed override void OnUpdateEvent3()
		{
			if (!this.isPenetrated)
			{
				this.m_currentOralSexTipo = TipoDeOralSex.None;
				return;
			}
			HoleVirtualHardPoint holeVirtualHardPoint;
			base.hardPoints.TryGetValue("GARGANTA", out holeVirtualHardPoint);
			if (holeVirtualHardPoint == null)
			{
				this.m_currentOralSexTipo = TipoDeOralSex.conBoca;
				return;
			}
			this.m_lastGargantaLinealWeight = holeVirtualHardPoint.LinealWeight(base.estadoDePuntos.actualLocal.penetratedDepthLocalInternals);
			if (holeVirtualHardPoint.resistenciaMod > 0f)
			{
				if (this.m_lastGargantaLinealWeight < 0.25f)
				{
					this.m_currentOralSexTipo = TipoDeOralSex.conBoca;
					return;
				}
				if (this.m_lastGargantaLinealWeight < 1f)
				{
					this.m_currentOralSexTipo = TipoDeOralSex.conGarganta;
					return;
				}
				this.m_currentOralSexTipo = TipoDeOralSex.conEsofago;
				return;
			}
			else
			{
				if (this.m_lastGargantaLinealWeight < 0.5f)
				{
					this.m_currentOralSexTipo = TipoDeOralSex.conBoca;
					return;
				}
				this.m_currentOralSexTipo = TipoDeOralSex.conEsofago;
				return;
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000B4E6 File Offset: 0x000096E6
		protected override void UpdateWallColliders()
		{
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000B4E8 File Offset: 0x000096E8
		private void OnDrawGizmosSelected()
		{
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000B508 File Offset: 0x00009708
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04000224 RID: 548
		[SerializeField]
		private HoleVirtualHardPoint m_hardPointDeGarganta = new HoleVirtualHardPoint();

		// Token: 0x04000225 RID: 549
		[ReadOnlyUI]
		[SerializeField]
		private TipoDeOralSex m_currentOralSexTipo;

		// Token: 0x04000226 RID: 550
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastGargantaLinealWeight;

		// Token: 0x04000227 RID: 551
		private string m_entradaName;

		// Token: 0x04000228 RID: 552
		public BocaHole.PuntosCreationConfig puntosCreationConfig = new BocaHole.PuntosCreationConfig();

		// Token: 0x04000229 RID: 553
		private Rigidbody m_nonPenetratedSuckJointsRoot;

		// Token: 0x0200017A RID: 378
		[Serializable]
		public class PuntosCreationConfig
		{
			// Token: 0x04000894 RID: 2196
			public Vector3 upwardsOffset;

			// Token: 0x04000895 RID: 2197
			public Vector3 downwardsOffset;
		}
	}
}
