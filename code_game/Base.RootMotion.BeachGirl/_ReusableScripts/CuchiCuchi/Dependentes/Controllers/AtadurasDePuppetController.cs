using System;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020000CA RID: 202
	public sealed class AtadurasDePuppetController : ControllerColaDePrioridadBase<AtadurasDePuppetController.Stado, AtadurasDePuppetController.Orden, AtadurasDePuppetController.Colas, AtadurasDePuppetController, TipoDeAtaduraDePuppet>
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00023889 File Offset: 0x00021A89
		protected override int cantidadDeEstados
		{
			get
			{
				return typeof(TipoDeAtaduraDePuppet).GetEnumCount();
			}
		}

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x06000752 RID: 1874 RVA: 0x0002389C File Offset: 0x00021A9C
		// (remove) Token: 0x06000753 RID: 1875 RVA: 0x000238D4 File Offset: 0x00021AD4
		private event Action<AtadurasDePuppetController> afterFirstPassOfFirstLayer;

		// Token: 0x06000754 RID: 1876 RVA: 0x0002390C File Offset: 0x00021B0C
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = base.GetComponentInParent<IIKUpdater>();
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_Animator = this.GetComponentEnRoot(false);
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
			this.m_PuppetMaster = this.GetComponentEnRoot(false);
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00023999 File Offset: 0x00021B99
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onAllIKsUpdated += this.m_updater_updated;
			this.m_updater.onSingleIKUpdatedPass3 += this.M_updater_onSingleIKUpdatedPass3;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x000239D0 File Offset: 0x00021BD0
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.onAllIKsUpdated -= this.m_updater_updated;
				this.m_updater.onSingleIKUpdatedPass3 += this.M_updater_onSingleIKUpdatedPass3;
			}
			base.DetenerOrdenes();
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00023A20 File Offset: 0x00021C20
		private void m_updater_updated(IIKUpdater obj)
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00023A29 File Offset: 0x00021C29
		private void M_updater_onSingleIKUpdatedPass3(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (IKEventData.layer != 0)
			{
				return;
			}
			if (PassEventData.index != 0)
			{
				return;
			}
			Action<AtadurasDePuppetController> action = this.afterFirstPassOfFirstLayer;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00023A4F File Offset: 0x00021C4F
		public void Apoyar(TipoDeAtaduraDePuppet tipo, float weigth, Muscle AtarA = null)
		{
			this.Apoyar(tipo, weigth, null, null, AtarA);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00023A5C File Offset: 0x00021C5C
		public void Apoyar(TipoDeAtaduraDePuppet tipo, float weigth, Action<AtadurasDePuppetController.Orden> comenzadaCallBack, Action<AtadurasDePuppetController.Orden> terminadaCallBack, Muscle AtarA = null)
		{
			AtadurasDePuppetController.Orden orden;
			if (base.OrdenAnuladaPorPrioridadBaja(ControllerPrioridadConfig.baja, tipo, out orden))
			{
				orden.weigth = weigth;
				orden.atarAMuscle = AtarA;
				return;
			}
			AtadurasDePuppetController.Orden orden2;
			if (base.currentStado.TryDejarDeDetenerPrimerOrden(tipo, out orden2))
			{
				orden2.weigth = weigth;
				orden2.atarAMuscle = AtarA;
				base.ResusarOrden(orden2, -1f, -1, comenzadaCallBack, terminadaCallBack);
				return;
			}
			AtadurasDePuppetController.Orden orden3 = new AtadurasDePuppetController.Orden(weigth, tipo, false, false, comenzadaCallBack, terminadaCallBack, AtarA);
			base.Inyectar(orden3, true);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00023ACC File Offset: 0x00021CCC
		public bool Apoyando(TipoDeAtaduraDePuppet tipo)
		{
			return !base.TipoDeOrdenEstaLibre(tipo);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00023AD8 File Offset: 0x00021CD8
		public bool Apoyando(HumanBodyBones humanBodyBones)
		{
			TipoDeAtaduraDePuppet tipoDeAtaduraDePuppet;
			return this.TryParseHumanBodyBonesToTipo(humanBodyBones, out tipoDeAtaduraDePuppet) && this.Apoyando(tipoDeAtaduraDePuppet);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00023AFC File Offset: 0x00021CFC
		public bool TryParseHumanBodyBonesToTipo(HumanBodyBones humanBodyBones, out TipoDeAtaduraDePuppet tipo)
		{
			switch (humanBodyBones)
			{
			case HumanBodyBones.LeftUpperLeg:
				tipo = TipoDeAtaduraDePuppet.caderaL;
				return true;
			case HumanBodyBones.RightUpperLeg:
				tipo = TipoDeAtaduraDePuppet.caderaR;
				return true;
			case HumanBodyBones.LeftLowerLeg:
				tipo = TipoDeAtaduraDePuppet.rodillaL;
				return true;
			case HumanBodyBones.RightLowerLeg:
				tipo = TipoDeAtaduraDePuppet.rodillaR;
				return true;
			case HumanBodyBones.LeftFoot:
				tipo = TipoDeAtaduraDePuppet.pieL;
				return true;
			case HumanBodyBones.RightFoot:
				tipo = TipoDeAtaduraDePuppet.pieR;
				return true;
			case HumanBodyBones.LeftUpperArm:
				tipo = TipoDeAtaduraDePuppet.hombroL;
				return true;
			case HumanBodyBones.RightUpperArm:
				tipo = TipoDeAtaduraDePuppet.hombroR;
				return true;
			case HumanBodyBones.LeftLowerArm:
				tipo = TipoDeAtaduraDePuppet.codoL;
				return true;
			case HumanBodyBones.RightLowerArm:
				tipo = TipoDeAtaduraDePuppet.codoR;
				return true;
			case HumanBodyBones.LeftHand:
				tipo = TipoDeAtaduraDePuppet.manoL;
				return true;
			case HumanBodyBones.RightHand:
				tipo = TipoDeAtaduraDePuppet.manoR;
				return true;
			}
			tipo = TipoDeAtaduraDePuppet.hombroL;
			return false;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00023BA0 File Offset: 0x00021DA0
		public HumanBodyBones ParseTipoIdToHumanBodyBones(TipoDeAtaduraDePuppet tipoId)
		{
			HumanBodyBones humanBodyBones;
			switch (tipoId)
			{
			case TipoDeAtaduraDePuppet.hombroL:
				humanBodyBones = HumanBodyBones.LeftUpperArm;
				break;
			case TipoDeAtaduraDePuppet.hombroR:
				humanBodyBones = HumanBodyBones.RightUpperArm;
				break;
			case TipoDeAtaduraDePuppet.codoL:
				humanBodyBones = HumanBodyBones.LeftLowerArm;
				break;
			case TipoDeAtaduraDePuppet.codoR:
				humanBodyBones = HumanBodyBones.RightLowerArm;
				break;
			case TipoDeAtaduraDePuppet.manoL:
				humanBodyBones = HumanBodyBones.LeftHand;
				break;
			case TipoDeAtaduraDePuppet.manoR:
				humanBodyBones = HumanBodyBones.RightHand;
				break;
			case TipoDeAtaduraDePuppet.caderaL:
				humanBodyBones = HumanBodyBones.LeftUpperLeg;
				break;
			case TipoDeAtaduraDePuppet.caderaR:
				humanBodyBones = HumanBodyBones.RightUpperLeg;
				break;
			case TipoDeAtaduraDePuppet.rodillaL:
				humanBodyBones = HumanBodyBones.LeftLowerLeg;
				break;
			case TipoDeAtaduraDePuppet.rodillaR:
				humanBodyBones = HumanBodyBones.RightLowerLeg;
				break;
			case TipoDeAtaduraDePuppet.pieL:
				humanBodyBones = HumanBodyBones.LeftFoot;
				break;
			case TipoDeAtaduraDePuppet.pieR:
				humanBodyBones = HumanBodyBones.RightFoot;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipoId.ToString());
			}
			return humanBodyBones;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x00023C30 File Offset: 0x00021E30
		public Transform ParseTipoIdToBone(TipoDeAtaduraDePuppet tipoId)
		{
			HumanBodyBones humanBodyBones = this.ParseTipoIdToHumanBodyBones(tipoId);
			return this.m_Animator.GetBoneTransform(humanBodyBones);
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00023C51 File Offset: 0x00021E51
		public override TipoDeAtaduraDePuppet ParseIndexToTipoId(int index)
		{
			return (TipoDeAtaduraDePuppet)index;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00023C54 File Offset: 0x00021E54
		public override int ParseTipoIdToindex(TipoDeAtaduraDePuppet tipoId)
		{
			return (int)tipoId;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00023C57 File Offset: 0x00021E57
		protected override AtadurasDePuppetController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00023C5A File Offset: 0x00021E5A
		public bool CanCreateAtaduras()
		{
			return this.m_PuppetMaster.isActiveAndEnabled && !this.m_PuppetMaster.isBlending && this.m_PuppetMaster.state == PuppetMaster.State.Alive && this.m_PuppetMaster.mode == PuppetMaster.Mode.Active;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00023C94 File Offset: 0x00021E94
		public static FullBodyBipedEffector TipoAEffector(TipoDeAtaduraDePuppet tipo, out bool esExtencion)
		{
			esExtencion = false;
			switch (tipo)
			{
			case TipoDeAtaduraDePuppet.hombroL:
				return FullBodyBipedEffector.LeftShoulder;
			case TipoDeAtaduraDePuppet.hombroR:
				return FullBodyBipedEffector.RightShoulder;
			case TipoDeAtaduraDePuppet.codoL:
				esExtencion = true;
				return FullBodyBipedEffector.LeftHand;
			case TipoDeAtaduraDePuppet.codoR:
				esExtencion = true;
				return FullBodyBipedEffector.RightHand;
			case TipoDeAtaduraDePuppet.manoL:
				return FullBodyBipedEffector.LeftHand;
			case TipoDeAtaduraDePuppet.manoR:
				return FullBodyBipedEffector.RightHand;
			case TipoDeAtaduraDePuppet.caderaL:
				return FullBodyBipedEffector.LeftThigh;
			case TipoDeAtaduraDePuppet.caderaR:
				return FullBodyBipedEffector.RightThigh;
			case TipoDeAtaduraDePuppet.rodillaL:
				esExtencion = true;
				return FullBodyBipedEffector.LeftFoot;
			case TipoDeAtaduraDePuppet.rodillaR:
				esExtencion = true;
				return FullBodyBipedEffector.RightFoot;
			case TipoDeAtaduraDePuppet.pieL:
				return FullBodyBipedEffector.LeftFoot;
			case TipoDeAtaduraDePuppet.pieR:
				return FullBodyBipedEffector.RightFoot;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x040004FB RID: 1275
		public float damperMod;

		// Token: 0x040004FC RID: 1276
		public float damperAngularMod;

		// Token: 0x040004FD RID: 1277
		public float maximoSping = 10000000f;

		// Token: 0x040004FE RID: 1278
		public float maximoAngularSpring = 1000000f;

		// Token: 0x040004FF RID: 1279
		[Tooltip("tiempo para q driver sea maximo")]
		public float inTime = 1.25f;

		// Token: 0x04000500 RID: 1280
		[Tooltip("tiempo para q driver sea zero, al terminar")]
		public float outTime = 2f;

		// Token: 0x04000501 RID: 1281
		private IIKUpdater m_updater;

		// Token: 0x04000502 RID: 1282
		private Animator m_Animator;

		// Token: 0x04000503 RID: 1283
		private PuppetMaster m_PuppetMaster;

		// Token: 0x0200019D RID: 413
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<AtadurasDePuppetController.Stado, AtadurasDePuppetController.Orden, AtadurasDePuppetController.Colas, AtadurasDePuppetController, TipoDeAtaduraDePuppet>.OrdenBaseDeControllador
		{
			// Token: 0x06000C73 RID: 3187 RVA: 0x00037E98 File Offset: 0x00036098
			public Orden(float Weigth, TipoDeAtaduraDePuppet tipoId, bool lockOnSpringMax, bool angularLockOnSpringMax, Action<AtadurasDePuppetController.Orden> comenzadaCallBack, Action<AtadurasDePuppetController.Orden> terminadaCallBack, Muscle AtarA = null)
				: base(tipoId, comenzadaCallBack, terminadaCallBack)
			{
				this.lockOnSpringMax = lockOnSpringMax;
				this.angularLockOnSpringMax = angularLockOnSpringMax;
				this.weigth = Weigth;
				this.atarAMuscle = AtarA;
			}

			// Token: 0x06000C74 RID: 3188 RVA: 0x00037F28 File Offset: 0x00036128
			protected override void OnStart(AtadurasDePuppetController dataUpdate)
			{
				this.bone = dataUpdate.ParseTipoIdToBone(base.tipoId);
				this.musculo = dataUpdate.m_PuppetMaster.GetMuscle(this.bone);
				AtadurasDePuppetController.Orden.SyncKinematicToBone(this.musculo.rigidbody, this.bone);
				if (this.atarAMuscle != null)
				{
					AtadurasDePuppetController.Orden.SyncKinematicToBone(this.atarAMuscle.rigidbody, this.atarAMuscle.target);
				}
				this.kinematic = dataUpdate.transform.CreateChild("Atadura_" + base.tipoId.ToString()).gameObject.AddComponent<Rigidbody>();
				this.kinematic.isKinematic = true;
				if (this.atarAMuscle == null || !this.m_atadoAMusculoEnLY0PS0)
				{
					AtadurasDePuppetController.Orden.SyncKinematicToBone(this.kinematic, this.bone);
				}
				else
				{
					AtadurasDePuppetController.Orden.SyncKinematicToBone(this.m_savedLocalPosLY0PS0, this.m_savedLocalRotLY0PS0, this.kinematic, this.atarAMuscle);
				}
				this.joint = this.kinematic.gameObject.AddComponent<ConfigurableJoint>();
				this.joint.autoConfigureConnectedAnchor = false;
				this.joint.connectedAnchor = Vector3.zero;
				this.joint.projectionMode = JointProjectionMode.PositionAndRotation;
				dataUpdate.afterFirstPassOfFirstLayer += this.DataUpdate_afterFirstPassOfFirstLayer;
			}

			// Token: 0x06000C75 RID: 3189 RVA: 0x0003806C File Offset: 0x0003626C
			protected override bool UpdateOrden(AtadurasDePuppetController dataUpdate, bool esPrimerUpdate)
			{
				if (!esPrimerUpdate)
				{
					if (this.atarAMuscle == null || !this.m_atadoAMusculoEnLY0PS0)
					{
						AtadurasDePuppetController.Orden.SyncKinematicToBone(this.kinematic, this.bone);
					}
					else
					{
						AtadurasDePuppetController.Orden.SyncKinematicToBone(this.m_savedLocalPosLY0PS0, this.m_savedLocalRotLY0PS0, this.kinematic, this.atarAMuscle);
					}
				}
				bool flag = AtadurasDePuppetController.Orden.CalculeDriverV2(ref this.drive, ref this.m_currentPositionSpringVelocity, this.weigth, this.musculo.rigidbody, this.joint, dataUpdate.maximoSping, dataUpdate.inTime, dataUpdate.damperMod, base.estadoDeltaTime);
				bool flag2 = AtadurasDePuppetController.Orden.CalculeDriverV2(ref this.angularDrive, ref this.m_currentRotationSpringVelocity, this.weigth, this.musculo.rigidbody, this.joint, dataUpdate.maximoAngularSpring, dataUpdate.inTime, dataUpdate.damperAngularMod, base.estadoDeltaTime);
				if (flag)
				{
					if (this.lockOnSpringMax)
					{
						this.CambiarMotions(ConfigurableJointMotion.Locked);
					}
					else
					{
						this.CambiarMotions(ConfigurableJointMotion.Free);
					}
				}
				if (flag2)
				{
					if (this.angularLockOnSpringMax)
					{
						this.CambiarAngularMotions(ConfigurableJointMotion.Locked);
					}
					else
					{
						this.CambiarAngularMotions(ConfigurableJointMotion.Free);
					}
				}
				this.UpdateDrivers();
				this.UpdateConnectedBody();
				return true;
			}

			// Token: 0x06000C76 RID: 3190 RVA: 0x0003817F File Offset: 0x0003637F
			protected override void OnDetenidaPorUsuario(AtadurasDePuppetController dataUpdate)
			{
			}

			// Token: 0x06000C77 RID: 3191 RVA: 0x00038184 File Offset: 0x00036384
			protected override bool OnTerminando(AtadurasDePuppetController dataUpdate, bool primerUpdate, AtadurasDePuppetController.Orden esperandoDetencion)
			{
				bool flag = AtadurasDePuppetController.Orden.CalculeDisminucionDriverV2(ref this.drive, ref this.m_currentPositionSpringVelocity, this.weigth, this.musculo.rigidbody, this.joint, dataUpdate.maximoSping, dataUpdate.outTime, dataUpdate.damperMod, base.estadoDeltaTime);
				bool flag2 = AtadurasDePuppetController.Orden.CalculeDisminucionDriverV2(ref this.angularDrive, ref this.m_currentRotationSpringVelocity, this.weigth, this.musculo.rigidbody, this.joint, dataUpdate.maximoAngularSpring, dataUpdate.outTime, dataUpdate.damperAngularMod, base.estadoDeltaTime);
				if (flag && flag2)
				{
					return true;
				}
				this.CambiarMotions(ConfigurableJointMotion.Free);
				this.CambiarAngularMotions(ConfigurableJointMotion.Free);
				if (this.atarAMuscle == null || !this.m_atadoAMusculoEnLY0PS0)
				{
					AtadurasDePuppetController.Orden.SyncKinematicToBone(this.kinematic, this.bone);
				}
				else
				{
					AtadurasDePuppetController.Orden.SyncKinematicToBone(this.m_savedLocalPosLY0PS0, this.m_savedLocalRotLY0PS0, this.kinematic, this.atarAMuscle);
				}
				this.UpdateDrivers();
				return false;
			}

			// Token: 0x06000C78 RID: 3192 RVA: 0x00038270 File Offset: 0x00036470
			protected override void OnTerminada(AtadurasDePuppetController dataUpdate, bool abruptamente)
			{
				if (this.kinematic.gameObject)
				{
					Object.Destroy(this.kinematic.gameObject);
				}
				this.bone = null;
				this.musculo = null;
				this.joint = null;
				this.kinematic = null;
				dataUpdate.afterFirstPassOfFirstLayer -= this.DataUpdate_afterFirstPassOfFirstLayer;
			}

			// Token: 0x06000C79 RID: 3193 RVA: 0x000382D0 File Offset: 0x000364D0
			private void UpdateConnectedBody()
			{
				if (this.musculo.rigidbody.gameObject.activeInHierarchy && !this.musculo.rigidbody.isKinematic)
				{
					if (this.joint.connectedBody != this.musculo.rigidbody)
					{
						this.joint.connectedBody = this.musculo.rigidbody;
						return;
					}
				}
				else
				{
					this.joint.connectedBody = null;
				}
			}

			// Token: 0x06000C7A RID: 3194 RVA: 0x00038348 File Offset: 0x00036548
			public void CambiarMotions(ConfigurableJointMotion motion)
			{
				ConfigurableJoint configurableJoint = this.joint;
				ConfigurableJoint configurableJoint2 = this.joint;
				this.joint.yMotion = motion;
				configurableJoint2.zMotion = motion;
				configurableJoint.xMotion = motion;
			}

			// Token: 0x06000C7B RID: 3195 RVA: 0x00038380 File Offset: 0x00036580
			public void CambiarAngularMotions(ConfigurableJointMotion motion)
			{
				ConfigurableJoint configurableJoint = this.joint;
				ConfigurableJoint configurableJoint2 = this.joint;
				this.joint.angularYMotion = motion;
				configurableJoint2.angularZMotion = motion;
				configurableJoint.angularXMotion = motion;
			}

			// Token: 0x06000C7C RID: 3196 RVA: 0x000383B8 File Offset: 0x000365B8
			public void UpdateDrivers()
			{
				this.joint.zDrive = (this.joint.yDrive = (this.joint.xDrive = this.drive));
				this.joint.angularYZDrive = (this.joint.angularXDrive = this.angularDrive);
			}

			// Token: 0x06000C7D RID: 3197 RVA: 0x00038414 File Offset: 0x00036614
			private void DataUpdate_afterFirstPassOfFirstLayer(AtadurasDePuppetController obj)
			{
				this.m_atadoAMusculoEnLY0PS0 = this.atarAMuscle != null && this.atarAMuscle.target != null;
				if (!this.m_atadoAMusculoEnLY0PS0)
				{
					this.m_savedLocalPosLY0PS0 = Vector3.zero;
					this.m_savedLocalRotLY0PS0 = Quaternion.identity;
					return;
				}
				Transform target = this.atarAMuscle.target;
				this.m_savedLocalPosLY0PS0 = target.InverseTransformPoint(this.bone.position);
				this.m_savedLocalRotLY0PS0 = Quaternion.Inverse(target.rotation) * this.bone.rotation;
			}

			// Token: 0x06000C7E RID: 3198 RVA: 0x000384A8 File Offset: 0x000366A8
			public static void SyncKinematicToBone(Vector3 localPos, Quaternion localRot, Rigidbody kinematic, Muscle atarAMuscle)
			{
				Transform transform = atarAMuscle.rigidbody.transform;
				Vector3 vector = transform.TransformPoint(localPos);
				Quaternion quaternion = transform.rotation * localRot;
				kinematic.transform.SetPositionAndRotation(vector, quaternion);
			}

			// Token: 0x06000C7F RID: 3199 RVA: 0x000384E1 File Offset: 0x000366E1
			public static void SyncKinematicToBone(Rigidbody kinematic, Transform bone)
			{
				kinematic.transform.SetPositionAndRotation(bone.position, bone.rotation);
			}

			// Token: 0x06000C80 RID: 3200 RVA: 0x000384FC File Offset: 0x000366FC
			public static bool CalculeDisminucionDriverV2(ref JointDrive drive, ref float currentVelocity, float weigth, Rigidbody rigid, ConfigurableJoint joint, float maximaRigidez, float Time, float damperMod, float deltatime)
			{
				if (drive.positionSpring <= 1E-05f)
				{
					return true;
				}
				float num = Mathf.SmoothDamp(drive.positionSpring, 0f, ref currentVelocity, Time, float.PositiveInfinity, deltatime);
				drive.positionSpring = num;
				drive.positionDamper = drive.positionSpring * damperMod;
				return false;
			}

			// Token: 0x06000C81 RID: 3201 RVA: 0x0003854C File Offset: 0x0003674C
			public static bool CalculeDriverV2(ref JointDrive drive, ref float currentVelocity, float weigth, Rigidbody rigid, ConfigurableJoint joint, float maximaRigidez, float Time, float damperMod, float deltatime)
			{
				maximaRigidez *= weigth * rigid.mass;
				float num = Mathf.SmoothDamp(drive.positionSpring, maximaRigidez, ref currentVelocity, Time, float.PositiveInfinity, deltatime);
				drive.positionSpring = num;
				drive.positionDamper = drive.positionSpring * damperMod;
				return drive.positionSpring >= maximaRigidez;
			}

			// Token: 0x04000941 RID: 2369
			public float weigth;

			// Token: 0x04000942 RID: 2370
			[Obsolete("", true)]
			public float springVelocityMod = 10f;

			// Token: 0x04000943 RID: 2371
			public Rigidbody kinematic;

			// Token: 0x04000944 RID: 2372
			public ConfigurableJoint joint;

			// Token: 0x04000945 RID: 2373
			public Transform bone;

			// Token: 0x04000946 RID: 2374
			public Muscle musculo;

			// Token: 0x04000947 RID: 2375
			public JointDrive drive = new JointDrive
			{
				maximumForce = float.MaxValue
			};

			// Token: 0x04000948 RID: 2376
			public JointDrive angularDrive = new JointDrive
			{
				maximumForce = float.MaxValue
			};

			// Token: 0x04000949 RID: 2377
			public bool lockOnSpringMax;

			// Token: 0x0400094A RID: 2378
			public bool angularLockOnSpringMax;

			// Token: 0x0400094B RID: 2379
			private float m_currentPositionSpringVelocity;

			// Token: 0x0400094C RID: 2380
			private float m_currentRotationSpringVelocity;

			// Token: 0x0400094D RID: 2381
			[SerializeReference]
			public Muscle atarAMuscle;

			// Token: 0x0400094E RID: 2382
			private bool m_atadoAMusculoEnLY0PS0;

			// Token: 0x0400094F RID: 2383
			private Vector3 m_savedLocalPosLY0PS0 = Vector3.zero;

			// Token: 0x04000950 RID: 2384
			private Quaternion m_savedLocalRotLY0PS0 = Quaternion.identity;
		}

		// Token: 0x0200019E RID: 414
		public sealed class Colas : ControllerColaDePrioridadBase<AtadurasDePuppetController.Stado, AtadurasDePuppetController.Orden, AtadurasDePuppetController.Colas, AtadurasDePuppetController, TipoDeAtaduraDePuppet>.ColasBase
		{
		}

		// Token: 0x0200019F RID: 415
		public sealed class Stado : ControllerColaDePrioridadBase<AtadurasDePuppetController.Stado, AtadurasDePuppetController.Orden, AtadurasDePuppetController.Colas, AtadurasDePuppetController, TipoDeAtaduraDePuppet>.StadoBase
		{
		}
	}
}
