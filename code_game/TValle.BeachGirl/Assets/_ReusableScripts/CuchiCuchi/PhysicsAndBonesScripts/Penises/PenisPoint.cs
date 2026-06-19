using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises
{
	// Token: 0x02000108 RID: 264
	public sealed class PenisPoint : RecalculableJoint<PenisPoint.Configuracion>
	{
		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x000263E2 File Offset: 0x000245E2
		// (set) Token: 0x06000B78 RID: 2936 RVA: 0x000263EA File Offset: 0x000245EA
		[Obsolete("", true)]
		public PenisPointCollider pointCollider
		{
			get
			{
				return this.m_penisCollider;
			}
			set
			{
				this.m_penisCollider = value;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x000263F3 File Offset: 0x000245F3
		public PenisPointCollider mainCollider
		{
			get
			{
				return this.m_mainCollider;
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x000263FB File Offset: 0x000245FB
		public PenisPointCollider complementoCollider
		{
			get
			{
				return this.m_complementoCollider;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x00026403 File Offset: 0x00024603
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x0002640B File Offset: 0x0002460B
		public override PenisPoint.Configuracion configuracion
		{
			get
			{
				return this.m_Configuracion;
			}
			set
			{
				this.m_Configuracion = value;
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00026414 File Offset: 0x00024614
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x0002641C File Offset: 0x0002461C
		public override Transform jointTransform
		{
			get
			{
				return this.m_jointTransform;
			}
			set
			{
				this.m_jointTransform = value;
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x00026425 File Offset: 0x00024625
		// (set) Token: 0x06000B80 RID: 2944 RVA: 0x0002642D File Offset: 0x0002462D
		public override Transform targetBodyTransform
		{
			get
			{
				return this.m_targetTransform;
			}
			set
			{
				this.m_targetTransform = value;
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x00026436 File Offset: 0x00024636
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x0002643E File Offset: 0x0002463E
		public override Transform scalerBone
		{
			get
			{
				return this.m_targetBoneTransform;
			}
			set
			{
				this.m_targetBoneTransform = value;
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x00026447 File Offset: 0x00024647
		public override Transform scaleProxy
		{
			get
			{
				return this.m_targetTransform;
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x0002644F File Offset: 0x0002464F
		public override bool jointIsInverted
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x00026452 File Offset: 0x00024652
		public override bool useScaleChangedBroadcaster
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x00026455 File Offset: 0x00024655
		protected override bool fixOnEnable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000B87 RID: 2951 RVA: 0x00026458 File Offset: 0x00024658
		// (set) Token: 0x06000B88 RID: 2952 RVA: 0x00026460 File Offset: 0x00024660
		public PenisLinearChain chain
		{
			get
			{
				return this.m_chain;
			}
			set
			{
				this.m_chain = value;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x00026469 File Offset: 0x00024669
		public bool isLast
		{
			get
			{
				return this.chain.cantidadDePuntos == this.index + 1;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x00026480 File Offset: 0x00024680
		public bool isRoot
		{
			get
			{
				return this.index == -1;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0002648B File Offset: 0x0002468B
		// (set) Token: 0x06000B8C RID: 2956 RVA: 0x00026493 File Offset: 0x00024693
		public int index
		{
			get
			{
				return this.m_index;
			}
			set
			{
				this.m_index = value;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0002649C File Offset: 0x0002469C
		// (set) Token: 0x06000B8E RID: 2958 RVA: 0x000264A4 File Offset: 0x000246A4
		public Vector3 connectedDefautLocalPosition
		{
			get
			{
				return this.m_connectedDefautLocalPosition;
			}
			set
			{
				this.m_connectedDefautLocalPosition = value;
			}
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x000264B0 File Offset: 0x000246B0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.isRoot)
			{
				this.AddCollider();
			}
			this.m_modificadorDeDrivers = this.m_JointDrivesAdmin.suavisable.ObtenerModificadorNotNull(this);
			this.m_modificadorDeDrivers.spring.z = Mathf.Lerp(0.05f, 1f, Mathf.InverseLerp(-1f, (float)(this.m_chain.cantidadDePuntos - 1), (float)this.index).InPow(2f));
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x00026530 File Offset: 0x00024730
		public bool ContainsCollider(Collider col)
		{
			return this.m_mainCollider.collidersSet.Contains(col) || this.m_complementoCollider.collidersSet.Contains(col);
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00026558 File Offset: 0x00024758
		public bool ContainsRigidbody(Rigidbody rigid)
		{
			return base.principal == rigid;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x00026566 File Offset: 0x00024766
		public bool ContainsTransform(Transform trans)
		{
			return trans.IsChildOf(base.principal.transform);
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0002657C File Offset: 0x0002477C
		private void AddCollider()
		{
			this.m_mainCollider = this.GetComponentNotNull<PenisPointCollider>();
			this.m_mainCollider.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.penes;
			Transform transform = base.transform.CreateChild(base.name + "_Complementario", false);
			transform.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.penesComplemento;
			this.m_complementoCollider = transform.GetComponentNotNull<PenisPointCollider>();
			int capsuleDirection = ExtendedMonoBehaviour.GetCapsuleDirection(this.configuracion.jointAxisAdmin.localUpAxis, this.configuracion.jointAxisAdmin.localRightAxis);
			PenisPoint penisPoint = this.m_chain[this.m_index + 1];
			if (penisPoint == null)
			{
				if (this.colliderSizeGetter != null)
				{
					float num;
					float num2;
					this.colliderSizeGetter(this, this.m_index, this.m_mainCollider.transform, this.m_chain.punta.transform, out num, out num2);
					this.m_mainCollider.Crear(this.m_chain, num, num2, capsuleDirection);
				}
				else
				{
					this.m_mainCollider.Crear(this.m_chain, this.m_chain.punta.transform, capsuleDirection);
				}
			}
			else if (this.colliderSizeGetter != null)
			{
				float num3;
				float num4;
				this.colliderSizeGetter(this, this.m_index, this.m_mainCollider.transform, penisPoint.transform, out num3, out num4);
				this.m_mainCollider.Crear(this.m_chain, num3, num4, capsuleDirection);
			}
			else
			{
				this.m_mainCollider.Crear(this.m_chain, penisPoint.transform, capsuleDirection);
			}
			this.m_complementoCollider.CrearCopiando(this.m_chain, this.m_mainCollider);
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x00026728 File Offset: 0x00024928
		public float UpdateMass()
		{
			float num2;
			try
			{
				if (this.m_chain.redistribuirMasa)
				{
					PenisPoint penisPoint = this.m_chain.Next(this);
					float num = 0f;
					if (penisPoint != null)
					{
						num = penisPoint.UpdateMass();
					}
					JointBodyAdmin jointBodyAdmin = this.m_JointBodyAdmin;
					jointBodyAdmin.densityMod = Mathf.Lerp(0.5f, 1f, Mathf.InverseLerp((float)(this.m_chain.cantidadDePuntos - 1), -1f, (float)this.index));
					jointBodyAdmin.massAmountMod = num;
					num2 = jointBodyAdmin.UpdateMass() * 0.666f;
				}
				else
				{
					JointBodyAdmin jointBodyAdmin2 = this.m_JointBodyAdmin;
					jointBodyAdmin2.densityMod = 1f;
					jointBodyAdmin2.massAmountMod = 0f;
					num2 = jointBodyAdmin2.UpdateMass();
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception calculando massas de puntos de pene ", base.gameObject);
				throw ex;
			}
			finally
			{
				this.MassUpdated();
			}
			return num2;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x00026810 File Offset: 0x00024A10
		private void MassUpdated()
		{
			if (!this.chain.redistribuirMasa)
			{
				return;
			}
			float num = 0f;
			for (int i = this.index; i < this.m_chain.cantidadDePuntos - 1; i++)
			{
				PenisPoint penisPoint = this.m_chain[i];
				PenisPoint penisPoint2 = this.m_chain.Next(penisPoint);
				num += penisPoint2.m_JointBodyAdmin.body.mass;
			}
			this.m_JointDrivesAdmin.addedMass = num;
		}

		// Token: 0x04000626 RID: 1574
		public PenisPointColliderSizeGetterHandler colliderSizeGetter;

		// Token: 0x04000627 RID: 1575
		[Obsolete("", true)]
		private PenisPointCollider m_penisCollider;

		// Token: 0x04000628 RID: 1576
		private PenisPointCollider m_mainCollider;

		// Token: 0x04000629 RID: 1577
		private PenisPointCollider m_complementoCollider;

		// Token: 0x0400062A RID: 1578
		[SerializeField]
		private Vector3 m_connectedDefautLocalPosition;

		// Token: 0x0400062B RID: 1579
		[NonSerialized]
		private PenisPoint.Configuracion m_Configuracion;

		// Token: 0x0400062C RID: 1580
		[SerializeField]
		private Transform m_jointTransform;

		// Token: 0x0400062D RID: 1581
		[SerializeField]
		private Transform m_targetTransform;

		// Token: 0x0400062E RID: 1582
		[SerializeField]
		private Transform m_targetBoneTransform;

		// Token: 0x0400062F RID: 1583
		[ReadOnlyUI]
		[SerializeField]
		private PenisLinearChain m_chain;

		// Token: 0x04000630 RID: 1584
		[ReadOnlyUI]
		[SerializeField]
		private int m_index = int.MinValue;

		// Token: 0x04000631 RID: 1585
		public TrasnformCopier trasnformCopier;

		// Token: 0x04000632 RID: 1586
		[SerializeField]
		private ModificadorDeDriversDeJoint m_modificadorDeDrivers;

		// Token: 0x020001E5 RID: 485
		[Serializable]
		public class Configuracion : RecalculableJointBase.JointConfiguracion
		{
			// Token: 0x17000526 RID: 1318
			// (get) Token: 0x06000F9C RID: 3996 RVA: 0x00034E35 File Offset: 0x00033035
			// (set) Token: 0x06000F9D RID: 3997 RVA: 0x00034E3D File Offset: 0x0003303D
			public override RecalculableJointBase.LimitacionDeMotionConfig limitacionDeMotionConfig
			{
				get
				{
					return this.m_LimitacionDeMotionConfig;
				}
				set
				{
					this.m_LimitacionDeMotionConfig = value;
				}
			}

			// Token: 0x17000527 RID: 1319
			// (get) Token: 0x06000F9E RID: 3998 RVA: 0x00034E46 File Offset: 0x00033046
			// (set) Token: 0x06000F9F RID: 3999 RVA: 0x00034E4E File Offset: 0x0003304E
			public override JointAnglesAdmin.Configuracion jointAnglesAdmin
			{
				get
				{
					return this.m_JointAnglesAdmin;
				}
				set
				{
					this.m_JointAnglesAdmin = value;
				}
			}

			// Token: 0x17000528 RID: 1320
			// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x00034E57 File Offset: 0x00033057
			// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x00034E5F File Offset: 0x0003305F
			public override JointAxisAdmin.Configuracion jointAxisAdmin
			{
				get
				{
					return this.m_JointAxisAdmin;
				}
				set
				{
					this.m_JointAxisAdmin = value;
				}
			}

			// Token: 0x17000529 RID: 1321
			// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x00034E68 File Offset: 0x00033068
			// (set) Token: 0x06000FA3 RID: 4003 RVA: 0x00034E70 File Offset: 0x00033070
			public override JointBodyAdmin.Configuracion jointBodyAdmin
			{
				get
				{
					return this.m_JointBodyAdmin;
				}
				set
				{
					this.m_JointBodyAdmin = value;
				}
			}

			// Token: 0x1700052A RID: 1322
			// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x00034E79 File Offset: 0x00033079
			// (set) Token: 0x06000FA5 RID: 4005 RVA: 0x00034E81 File Offset: 0x00033081
			public override JointDistancesAdmin.Configuracion jointDistancesAdmin
			{
				get
				{
					return this.m_JointDistancesAdmin;
				}
				set
				{
					this.m_JointDistancesAdmin = value;
				}
			}

			// Token: 0x1700052B RID: 1323
			// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x00034E8A File Offset: 0x0003308A
			// (set) Token: 0x06000FA7 RID: 4007 RVA: 0x00034E92 File Offset: 0x00033092
			public override JointDrivesAdminV2.Configuracion jointDrivesAdminV2
			{
				get
				{
					return this.m_JointDrivesAdminV2;
				}
				set
				{
					this.m_JointDrivesAdminV2 = value;
				}
			}

			// Token: 0x1700052C RID: 1324
			// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x00034E9B File Offset: 0x0003309B
			// (set) Token: 0x06000FA9 RID: 4009 RVA: 0x00034EA3 File Offset: 0x000330A3
			public override JointMotionsAdmin.Configuracion jointMotionsAdmin
			{
				get
				{
					return this.m_JointMotionsAdmin;
				}
				set
				{
					this.m_JointMotionsAdmin = value;
				}
			}

			// Token: 0x04000A9D RID: 2717
			[SerializeField]
			protected RecalculableJointBase.LimitacionDeMotionConfig m_LimitacionDeMotionConfig;

			// Token: 0x04000A9E RID: 2718
			[SerializeField]
			protected JointAnglesAdmin.Configuracion m_JointAnglesAdmin;

			// Token: 0x04000A9F RID: 2719
			[SerializeField]
			protected JointAxisAdmin.Configuracion m_JointAxisAdmin;

			// Token: 0x04000AA0 RID: 2720
			[SerializeField]
			protected JointBodyAdmin.Configuracion m_JointBodyAdmin;

			// Token: 0x04000AA1 RID: 2721
			[SerializeField]
			protected JointDistancesAdmin.Configuracion m_JointDistancesAdmin;

			// Token: 0x04000AA2 RID: 2722
			[SerializeField]
			protected JointDrivesAdminV2.Configuracion m_JointDrivesAdminV2;

			// Token: 0x04000AA3 RID: 2723
			[SerializeField]
			protected JointMotionsAdmin.Configuracion m_JointMotionsAdmin;
		}

		// Token: 0x020001E6 RID: 486
		[Serializable]
		public sealed class PenisConfiguracion : PenisPoint.Configuracion
		{
			// Token: 0x06000FAB RID: 4011 RVA: 0x00034EB4 File Offset: 0x000330B4
			public PenisConfiguracion()
			{
				this.m_LimitacionDeMotionConfig = new PenisPoint.PenisConfigs.LimitacionesDeMotionConfig();
				this.m_JointAnglesAdmin = new PenisPoint.PenisConfigs.JointAnglesAdminConfig();
				this.m_JointAxisAdmin = new PenisPoint.PenisConfigs.JointAxisConfig();
				this.m_JointBodyAdmin = new PenisPoint.PenisConfigs.JointBodyConfig();
				this.m_JointDistancesAdmin = new PenisPoint.PenisConfigs.JointDistancesConfig();
				this.m_JointDrivesAdminV2 = new PenisPoint.PenisConfigs.JointDriveConfig();
				this.m_JointMotionsAdmin = new PenisPoint.PenisConfigs.JointMotionsConfig();
			}
		}

		// Token: 0x020001E7 RID: 487
		[Serializable]
		public sealed class FingerPenisConfiguracion : PenisPoint.Configuracion
		{
			// Token: 0x06000FAC RID: 4012 RVA: 0x00034F14 File Offset: 0x00033114
			public FingerPenisConfiguracion()
			{
				this.m_LimitacionDeMotionConfig = new PenisPoint.FingerPenisConfigs.LimitacionesDeMotionConfig();
				this.m_JointAnglesAdmin = new PenisPoint.FingerPenisConfigs.JointAnglesAdminConfig();
				this.m_JointAxisAdmin = new PenisPoint.FingerPenisConfigs.JointAxisConfig();
				this.m_JointBodyAdmin = new PenisPoint.FingerPenisConfigs.JointBodyConfig();
				this.m_JointDistancesAdmin = new PenisPoint.FingerPenisConfigs.JointDistancesConfig();
				this.m_JointDrivesAdminV2 = new PenisPoint.FingerPenisConfigs.JointDriveConfig();
				this.m_JointMotionsAdmin = new PenisPoint.FingerPenisConfigs.JointMotionsConfig();
			}
		}

		// Token: 0x020001E8 RID: 488
		public static class PenisConfigs
		{
			// Token: 0x02000252 RID: 594
			public class LimitacionesDeMotionConfig : RecalculableJointBase.LimitacionDeMotionConfig
			{
				// Token: 0x06001083 RID: 4227 RVA: 0x000371DC File Offset: 0x000353DC
				public LimitacionesDeMotionConfig()
				{
					this.usar = true;
					this.limitaciones = new List<LimitarPolaridadDeAxis.Configuracion>
					{
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.zPositive,
							toleranceMod = 0f
						}
					};
				}
			}

			// Token: 0x02000253 RID: 595
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
				// Token: 0x06001084 RID: 4228 RVA: 0x00037213 File Offset: 0x00035413
				public JointAnglesAdminConfig()
				{
					this.lowAngularXLimit = -90f;
					this.highAngularXLimit = 90f;
					this.angularYLimit = 90f;
					this.angularZLimit = 0f;
				}
			}

			// Token: 0x02000254 RID: 596
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x06001085 RID: 4229 RVA: 0x00037247 File Offset: 0x00035447
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.up;
				}
			}

			// Token: 0x02000255 RID: 597
			public class JointBodyConfig : JointBodyAdmin.Configuracion
			{
				// Token: 0x06001086 RID: 4230 RVA: 0x0003725C File Offset: 0x0003545C
				public JointBodyConfig()
				{
					this.isInverted = true;
					this.density = 0.1f;
					this.massScale = 1f;
					this.ownRigidIsKinematic = false;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.useGravity = true;
					this.solverIterations = 25;
					this.solverVelocityIterations = 1;
				}
			}

			// Token: 0x02000256 RID: 598
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x06001087 RID: 4231 RVA: 0x000372BC File Offset: 0x000354BC
				public JointDistancesConfig()
				{
					this.worldLinearLimit = 0f;
					this.invertirConnectedAnchorPorAnchor = true;
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.porcentajeZ;
					this.targetPosition.porcentajeOptions.PorcentajeDistance = 200f;
					this.fixigOptions.fixOtherPosition = true;
					this.fixigOptions.fixOwnPosition = false;
					this.RestoreJointPositionAndRotationAfterFix = false;
					this.RestoreOtherBodyPositionAndRotationAfterFix = true;
				}
			}

			// Token: 0x02000257 RID: 599
			public class JointDriveConfig : JointDrivesAdminV2.Configuracion
			{
				// Token: 0x06001088 RID: 4232 RVA: 0x00037328 File Offset: 0x00035528
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xDrive = new JointDriveConfiguration(120000f)
					{
						addingSpringToDamperPercent = 0.01f
					};
					this.yDrive = new JointDriveConfiguration(120000f)
					{
						addingSpringToDamperPercent = 0.01f
					};
					this.zDrive = new JointDriveConfiguration(1050000f)
					{
						addingSpringToDamperPercent = 1.33f,
						addedMassMod = 1f
					};
					this.xAngularDrive = new JointDriveConfiguration(8f, 0f)
					{
						addingSpringToDamperPercent = 0.75f
					};
					this.yzAngularDrive = new JointDriveConfiguration(8f, 0f)
					{
						addingSpringToDamperPercent = 0.75f
					};
				}
			}

			// Token: 0x02000258 RID: 600
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x06001089 RID: 4233 RVA: 0x000373DE File Offset: 0x000355DE
				public JointMotionsConfig()
				{
					this.xMotion = ConfigurableJointMotion.Limited;
					this.yMotion = ConfigurableJointMotion.Limited;
					this.zMotion = ConfigurableJointMotion.Limited;
					this.angularXMotion = ConfigurableJointMotion.Limited;
					this.angularYMotion = ConfigurableJointMotion.Limited;
					this.angularZMotion = ConfigurableJointMotion.Free;
				}
			}
		}

		// Token: 0x020001E9 RID: 489
		public static class FingerPenisConfigs
		{
			// Token: 0x02000259 RID: 601
			public class LimitacionesDeMotionConfig : RecalculableJointBase.LimitacionDeMotionConfig
			{
				// Token: 0x0600108A RID: 4234 RVA: 0x00037410 File Offset: 0x00035610
				public LimitacionesDeMotionConfig()
				{
					this.usar = false;
					this.limitaciones = new List<LimitarPolaridadDeAxis.Configuracion>
					{
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.xPositive,
							toleranceMod = 0f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.yPositive,
							toleranceMod = 0f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.zPositive,
							toleranceMod = 0f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.xNegative,
							toleranceMod = 0f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.yNegative,
							toleranceMod = 0f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.zNegative,
							toleranceMod = 0f
						}
					};
				}
			}

			// Token: 0x0200025A RID: 602
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
				// Token: 0x0600108B RID: 4235 RVA: 0x000374E5 File Offset: 0x000356E5
				public JointAnglesAdminConfig()
				{
					this.lowAngularXLimit = -15f;
					this.highAngularXLimit = 100f;
					this.angularYLimit = 5f;
					this.angularZLimit = 5f;
				}
			}

			// Token: 0x0200025B RID: 603
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x0600108C RID: 4236 RVA: 0x00037519 File Offset: 0x00035719
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.up;
				}
			}

			// Token: 0x0200025C RID: 604
			public class JointBodyConfig : JointBodyAdmin.Configuracion
			{
				// Token: 0x0600108D RID: 4237 RVA: 0x0003752C File Offset: 0x0003572C
				public JointBodyConfig()
				{
					this.isInverted = true;
					this.density = 0.01f;
					this.massScale = 1f;
					this.ownRigidIsKinematic = false;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.useGravity = false;
					this.solverIterations = 100;
					this.solverVelocityIterations = 1;
					this.maxDepenetrationVelocity = 10f;
				}
			}

			// Token: 0x0200025D RID: 605
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x0600108E RID: 4238 RVA: 0x00037598 File Offset: 0x00035798
				public JointDistancesConfig()
				{
					this.worldLinearLimit = 0f;
					this.invertirConnectedAnchorPorAnchor = true;
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.freeTrack;
					this.targetPosition.freeTrackOptions.maxDistanceMod = 1f;
					this.targetPosition.freeTrackOptions.minDistanceMod = 1f;
					this.fixigOptions.fixOtherPosition = true;
					this.fixigOptions.fixOwnPosition = false;
					this.RestoreJointPositionAndRotationAfterFix = false;
					this.RestoreOtherBodyPositionAndRotationAfterFix = true;
				}
			}

			// Token: 0x0200025E RID: 606
			public class JointDriveConfig : JointDrivesAdminV2.Configuracion
			{
				// Token: 0x0600108F RID: 4239 RVA: 0x0003761C File Offset: 0x0003581C
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xDrive = new JointDriveConfiguration(1E+17f)
					{
						addingSpringToDamperPercent = 0f,
						massMod = 0f
					};
					this.yDrive = new JointDriveConfiguration(1E+17f)
					{
						addingSpringToDamperPercent = 0f,
						massMod = 0f
					};
					this.zDrive = new JointDriveConfiguration(1E+17f)
					{
						addingSpringToDamperPercent = 0f,
						massMod = 0f,
						addedMassMod = 1f
					};
					this.xAngularDrive = new JointDriveConfiguration(800f, 0f)
					{
						addingSpringToDamperPercent = 1f
					};
					this.yzAngularDrive = new JointDriveConfiguration(3200f, 0f)
					{
						addingSpringToDamperPercent = 1f
					};
				}
			}

			// Token: 0x0200025F RID: 607
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x06001090 RID: 4240 RVA: 0x000376F3 File Offset: 0x000358F3
				public JointMotionsConfig()
				{
					this.xMotion = ConfigurableJointMotion.Locked;
					this.yMotion = ConfigurableJointMotion.Locked;
					this.zMotion = ConfigurableJointMotion.Locked;
					this.angularXMotion = ConfigurableJointMotion.Limited;
					this.angularYMotion = ConfigurableJointMotion.Limited;
					this.angularZMotion = ConfigurableJointMotion.Free;
				}
			}
		}
	}
}
