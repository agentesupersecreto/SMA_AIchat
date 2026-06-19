using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F7 RID: 247
	public class GenericPenetrationJointCreator : AplicableBehaviour
	{
		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000A7C RID: 2684 RVA: 0x000220A0 File Offset: 0x000202A0
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedUpdate1);
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x000220A9 File Offset: 0x000202A9
		public Penetrador dick
		{
			get
			{
				return this.m_dick;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000A7E RID: 2686 RVA: 0x000220B1 File Offset: 0x000202B1
		public Transform hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x000220B9 File Offset: 0x000202B9
		public Vector3 holeWorldOutHoleDirection
		{
			get
			{
				return this.m_hole.TransformDirection(this.m_localHoleOutDirection);
			}
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x000220CC File Offset: 0x000202CC
		public void Init(Penetrador Dick, Transform Hole, Vector3 localHoleOutDirection, bool PartsPenetratesInversed)
		{
			if (this.m_initiated)
			{
				throw new InvalidOperationException();
			}
			this.m_partsPenetratesInversed = PartsPenetratesInversed;
			this.m_hole = Hole;
			this.m_dick = Dick;
			this.m_localHoleOutDirection = localHoleOutDirection;
			this.m_initiated = true;
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00022100 File Offset: 0x00020300
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.LimpiarJoints();
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0002210F File Offset: 0x0002030F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.LimpiarJoints();
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00022120 File Offset: 0x00020320
		public override void OnUpdateEvent1()
		{
			float worldScale = this.m_dick.worldScale;
			for (int i = 0; i < this.m_dick.partesEnOrden.Count; i++)
			{
				PenisPart penisPart = this.m_dick.partesEnOrden[i];
				float num;
				float num2;
				float num3;
				float num4;
				penisPart.CalculeDeep(worldScale, 1f, this.m_hole.position, this.holeWorldOutHoleDirection, this.m_partsPenetratesInversed, out num, out num2, out num3, out num4);
				this.OnPenetration(penisPart, num4);
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0002219C File Offset: 0x0002039C
		public void LimpiarJoints()
		{
			foreach (KeyValuePair<PenisPart, ConfigurableJoint> keyValuePair in this.m_historial)
			{
				this.DestroyJoint(keyValuePair.Value);
			}
			this.m_historial.Clear();
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00022200 File Offset: 0x00020400
		private void DestroyJoint(ConfigurableJoint joint)
		{
			if (joint != null)
			{
				Object.Destroy(joint);
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00022214 File Offset: 0x00020414
		private float GetDeepMod(PenisPart parte)
		{
			float num;
			float num2;
			float num3;
			float num4;
			parte.CalculeDeep(parte.pene.worldScale, 1f, this.m_hole.position, this.holeWorldOutHoleDirection, this.m_partsPenetratesInversed, out num, out num2, out num3, out num4);
			return num4;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00022258 File Offset: 0x00020458
		public void OnPenetration(PenisPart parte, float deepMod)
		{
			bool flag = this.m_historial.ContainsKey(parte);
			if (deepMod <= 0f)
			{
				if (!flag)
				{
					return;
				}
				this.OnPenetrationExit(parte, deepMod);
				return;
			}
			else
			{
				if (!flag)
				{
					this.OnPenetrationEnter(parte, deepMod);
					return;
				}
				this.OnPenetrationStay(parte, deepMod);
				return;
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0002229B File Offset: 0x0002049B
		public void OnPenetrationEnter(PenisPart parte)
		{
			this.OnPenetrationEnter(parte, this.GetDeepMod(parte));
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x000222AC File Offset: 0x000204AC
		public void OnPenetrationEnter(PenisPart parte, float deepMod)
		{
			ConfigurableJoint configurableJoint = null;
			try
			{
				configurableJoint = this.GetJoint(parte);
				this.ConfigurarJoint(configurableJoint, parte, deepMod);
			}
			finally
			{
				if (configurableJoint == null)
				{
					throw new ArgumentNullException("created", "created null reference.");
				}
				this.m_historial.Add(parte, configurableJoint);
			}
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00022308 File Offset: 0x00020508
		public void OnPenetrationStay(PenisPart parte)
		{
			this.OnPenetrationStay(parte, this.GetDeepMod(parte));
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00022318 File Offset: 0x00020518
		public void OnPenetrationStay(PenisPart parte, float deepMod)
		{
			try
			{
				ConfigurableJoint configurableJoint;
				if (!this.m_historial.TryGetValue(parte, out configurableJoint))
				{
					Debug.LogError("parte " + parte.name + " Stay. Pero no estaba registrada como estando adentro", this);
				}
				else
				{
					this.ActualizarJoint(parte, deepMod, configurableJoint);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("exepcion en Penetraciones_onPenetrationStay: " + ex.Message, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0002238C File Offset: 0x0002058C
		public void OnPenetrationExit(PenisPart parte)
		{
			this.OnPenetrationExit(parte, this.GetDeepMod(parte));
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0002239C File Offset: 0x0002059C
		public void OnPenetrationExit(PenisPart parte, float deepMod)
		{
			try
			{
				ConfigurableJoint configurableJoint;
				if (this.m_historial.TryGetValue(parte, out configurableJoint))
				{
					this.m_historial.Remove(parte);
					this.DestroyJoint(configurableJoint);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("exepcion en Penetraciones_onPenetrationOut: " + ex.Message, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00022400 File Offset: 0x00020600
		public void OnPenetrationOut()
		{
			this.LimpiarJoints();
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00022408 File Offset: 0x00020608
		private void ActualizarJoint(PenisPart parte, float deepMod, ConfigurableJoint joint)
		{
			this.SetJointDrivers(joint, parte, deepMod);
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00022413 File Offset: 0x00020613
		private ConfigurableJoint GetJoint(PenisPart parte)
		{
			return this.m_hole.gameObject.AddComponent<ConfigurableJoint>();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00022428 File Offset: 0x00020628
		private void ConfigurarJoint(ConfigurableJoint joint, PenisPart parte, float deepMod)
		{
			Rigidbody physicBone = parte.physicBone;
			joint.swapBodies = true;
			PenisPoint.Configuracion configuracion = parte.puntoConnectadoAEstaParte.configuracion;
			joint.axis = configuracion.jointAxisAdmin.localRightAxis;
			joint.secondaryAxis = configuracion.jointAxisAdmin.localUpAxis;
			joint.xMotion = ConfigurableJointMotion.Free;
			joint.yMotion = ConfigurableJointMotion.Free;
			joint.zMotion = ConfigurableJointMotion.Free;
			joint.angularXMotion = ConfigurableJointMotion.Free;
			joint.angularYMotion = ConfigurableJointMotion.Free;
			joint.angularZMotion = ConfigurableJointMotion.Free;
			joint.connectedBody = physicBone;
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = Vector3.zero;
			this.SetJointDrivers(joint, parte, deepMod);
			if (this.calcularTargetRotation)
			{
				Vector3 vector = ((!this.m_partsPenetratesInversed) ? parte.worldForward : (-parte.worldForward));
				Vector3 vector2 = -this.m_hole.TransformDirection(this.m_localHoleOutDirection);
				Vector3 worldUp = parte.worldUp;
				Vector3 vector3 = joint.transform.InverseTransformDirection(vector);
				Vector3 vector4 = joint.transform.InverseTransformDirection(vector2);
				Vector3 vector5 = joint.transform.InverseTransformDirection(worldUp);
				Vector3 vector6 = joint.transform.InverseTransformDirection(worldUp);
				Quaternion quaternion = Quaternion.LookRotation(vector3, vector5);
				Quaternion quaternion2 = Quaternion.LookRotation(vector4, vector6);
				joint.targetRotation = quaternion2 * Quaternion.Inverse(quaternion);
			}
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00022564 File Offset: 0x00020764
		private void SetJointDrivers(ConfigurableJoint joint, PenisPart parte, float deepMod)
		{
			Rigidbody physicBone = parte.physicBone;
			float num = 1f;
			bool flag = true;
			if (this.configuracionV2.suavizarAlEntrarHole)
			{
				num = this.GetCurrentModDeEntrada(parte, deepMod, this.configuracionV2.suavizacion, out flag);
			}
			float num2 = 1f;
			bool flag2 = true;
			if (this.configuracionV2.suavizarAlEntrarHoleAngular)
			{
				num2 = this.GetCurrentModDeEntrada(parte, deepMod, this.configuracionV2.suavizacionAngular, out flag2);
			}
			float num3 = this.zDamperMod;
			float num4 = MathfExtension.LerpConMedio(0f, this.configuracionV2.zDriveDamperToSpring * 0.1f, this.configuracionV2.zDriveDamperToSpring, this.zDriveDamperToSpringWeigth);
			joint.xDrive = PenetrationJointCreator.GetDrive(this.configuracionV2.xDriveMassMod, this.configuracionV2.xDriveSpring, this.configuracionV2.xSpringToDamper, physicBone.mass, num);
			joint.yDrive = PenetrationJointCreator.GetDrive(this.configuracionV2.yDriveMassMod, this.configuracionV2.yDriveSpring, this.configuracionV2.ySpringToDamper, physicBone.mass, num);
			joint.zDrive = PenetrationJointCreator.GetZDrive(this.configuracionV2.zDriveMassMod, this.configuracionV2.zDriveDamperV2 * num3, physicBone.mass, num, num4);
			joint.angularXDrive = PenetrationJointCreator.GetDrive(this.configuracionV2.xAngularDriveMassMod, this.configuracionV2.xAngularDriveSpring, this.configuracionV2.xAngularSpringToDamper, physicBone.mass, num2);
			joint.angularYZDrive = PenetrationJointCreator.GetDrive(this.configuracionV2.yzAngularDriveMassMod, this.configuracionV2.yzAngularDriveSpring, this.configuracionV2.yzAngularSpringToDamper, physicBone.mass, num2);
			if (this.configuracionV2.lockAngularSiMaxAlcanzado && flag2)
			{
				joint.angularYZDrive = (joint.angularXDrive = new JointDrive
				{
					maximumForce = 3.402823E+38f,
					positionSpring = 1E+21f
				});
			}
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00022744 File Offset: 0x00020944
		private float GetCurrentModDeEntrada(PenisPart parte, float deepMod, Suavizacion suavizacion, out bool alMaximo)
		{
			alMaximo = true;
			float num;
			if (deepMod >= suavizacion.penetracionDeParteWParaMaxValores)
			{
				num = 1f;
			}
			else
			{
				num = Mathf.InverseLerp(0f, suavizacion.penetracionDeParteWParaMaxValores, deepMod).InPow(suavizacion.inPower);
			}
			alMaximo = num >= 1f;
			return num;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x00022792 File Offset: 0x00020992
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Limpiar joints",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x000227AB File Offset: 0x000209AB
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.LimpiarJoints();
		}

		// Token: 0x04000595 RID: 1429
		public GenericPenetrationJointCreator.Configuracion configuracionV2 = new GenericPenetrationJointCreator.Configuracion();

		// Token: 0x04000596 RID: 1430
		public bool calcularTargetRotation = true;

		// Token: 0x04000597 RID: 1431
		public float zDamperMod = 1f;

		// Token: 0x04000598 RID: 1432
		public float zDriveDamperToSpringWeigth = 1f;

		// Token: 0x04000599 RID: 1433
		private Dictionary<PenisPart, ConfigurableJoint> m_historial = new Dictionary<PenisPart, ConfigurableJoint>();

		// Token: 0x0400059A RID: 1434
		private bool m_initiated;

		// Token: 0x0400059B RID: 1435
		[SerializeField]
		[ReadOnlyUI]
		private Penetrador m_dick;

		// Token: 0x0400059C RID: 1436
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_hole;

		// Token: 0x0400059D RID: 1437
		[SerializeField]
		[ReadOnlyUI]
		private Vector3 m_localHoleOutDirection;

		// Token: 0x0400059E RID: 1438
		[SerializeField]
		[ReadOnlyUI]
		private bool m_partsPenetratesInversed;

		// Token: 0x020001D0 RID: 464
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000A2B RID: 2603
			[Range(0f, 1f)]
			public float xDriveMassMod = 1f;

			// Token: 0x04000A2C RID: 2604
			[Range(0f, 1f)]
			public float yDriveMassMod = 1f;

			// Token: 0x04000A2D RID: 2605
			[Range(0f, 1f)]
			public float zDriveMassMod = 1f;

			// Token: 0x04000A2E RID: 2606
			[Range(0f, 1f)]
			public float xAngularDriveMassMod = 1f;

			// Token: 0x04000A2F RID: 2607
			[Range(0f, 1f)]
			public float yzAngularDriveMassMod = 1f;

			// Token: 0x04000A30 RID: 2608
			[Obsolete("", true)]
			[NonSerialized]
			public float maxSpringToDamper = 0.1f;

			// Token: 0x04000A31 RID: 2609
			[Obsolete("", true)]
			[NonSerialized]
			public float maxAngularSpringToDamper = 2f;

			// Token: 0x04000A32 RID: 2610
			public float xDriveSpring = 20000000f;

			// Token: 0x04000A33 RID: 2611
			public float xSpringToDamper = 0.0005f;

			// Token: 0x04000A34 RID: 2612
			public float yDriveSpring = 20000000f;

			// Token: 0x04000A35 RID: 2613
			public float ySpringToDamper = 0.0005f;

			// Token: 0x04000A36 RID: 2614
			public float zDriveDamperToSpring = 3f;

			// Token: 0x04000A37 RID: 2615
			public float zDriveDamperV2 = 1500f;

			// Token: 0x04000A38 RID: 2616
			public float xAngularDriveSpring = 1500f;

			// Token: 0x04000A39 RID: 2617
			public float xAngularSpringToDamper = 0.15f;

			// Token: 0x04000A3A RID: 2618
			public float yzAngularDriveSpring = 1500f;

			// Token: 0x04000A3B RID: 2619
			public float yzAngularSpringToDamper = 0.15f;

			// Token: 0x04000A3C RID: 2620
			public bool lockAngularSiMaxAlcanzado = true;

			// Token: 0x04000A3D RID: 2621
			[Header("suavizado del joint")]
			public bool suavizarAlEntrarHole = true;

			// Token: 0x04000A3E RID: 2622
			public Suavizacion suavizacion = new Suavizacion
			{
				penetracionDeParteWParaMaxValores = 0.99f,
				inPower = 3f,
				mod = 1f
			};

			// Token: 0x04000A3F RID: 2623
			[Header("suavizado del joint")]
			public bool suavizarAlEntrarHoleAngular = true;

			// Token: 0x04000A40 RID: 2624
			public Suavizacion suavizacionAngular = new Suavizacion
			{
				penetracionDeParteWParaMaxValores = 0.99f,
				inPower = 3f,
				mod = 1f
			};
		}
	}
}
