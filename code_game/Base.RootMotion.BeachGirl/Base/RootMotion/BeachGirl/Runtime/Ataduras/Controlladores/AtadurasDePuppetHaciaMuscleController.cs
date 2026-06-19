using System;
using Assets._ReusableScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Ataduras.Controlladores
{
	// Token: 0x02000047 RID: 71
	[Obsolete("hace conflicto con interacciones segundarias", true)]
	public class AtadurasDePuppetHaciaMuscleController : ControllerColaDePrioridadBase<AtadurasDePuppetHaciaMuscleController.Stado, AtadurasDePuppetHaciaMuscleController.Orden, AtadurasDePuppetHaciaMuscleController.Colas, AtadurasDePuppetHaciaMuscleController, TipoDeMuscleAlQueSePuedeAtar>
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0001001D File Offset: 0x0000E21D
		protected override int cantidadDeEstados
		{
			get
			{
				return typeof(TipoDeMuscleAlQueSePuedeAtar).GetEnumCount();
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0001002E File Offset: 0x0000E22E
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00010034 File Offset: 0x0000E234
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

		// Token: 0x0600031A RID: 794 RVA: 0x000100C1 File Offset: 0x0000E2C1
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onAllIKsUpdated += this.m_updater_updated;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000100E0 File Offset: 0x0000E2E0
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_updater.onAllIKsUpdated -= this.m_updater_updated;
			base.DetenerOrdenes();
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00010106 File Offset: 0x0000E306
		private void m_updater_updated(IIKUpdater obj)
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0001010F File Offset: 0x0000E30F
		public bool Atar(TipoDeMuscleAlQueSePuedeAtar from, TipoDeMuscleAlQueSePuedeAtar to)
		{
			return this.Atar(from, to, null, null);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0001011C File Offset: 0x0000E31C
		public bool Atar(TipoDeMuscleAlQueSePuedeAtar from, TipoDeMuscleAlQueSePuedeAtar to, Action<AtadurasDePuppetHaciaMuscleController.Orden> comenzadaCallBack, Action<AtadurasDePuppetHaciaMuscleController.Orden> terminadaCallBack)
		{
			bool flag = false;
			AtadurasDePuppetHaciaMuscleController.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, from, 2147483647, ControllerPrioridadConfig.prioridad, out flag3, ref flag, true))
			{
				return false;
			}
			AtadurasDePuppetHaciaMuscleController.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, ControllerPrioridadConfig.prioridad, from, out tipoDeReUsoDeOrden) && orden2.to == to)
			{
				base.AcumularseORevivir(orden2, -1f, int.MaxValue, tipoDeReUsoDeOrden, comenzadaCallBack, terminadaCallBack);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			AtadurasDePuppetHaciaMuscleController.Orden orden3 = new AtadurasDePuppetHaciaMuscleController.Orden(from, to, false, false, comenzadaCallBack, terminadaCallBack);
			base.Procesar(orden == null, flag2, ControllerPrioridadConfig.prioridad, orden3, false, false);
			return true;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0001019E File Offset: 0x0000E39E
		public bool Atado(TipoDeMuscleAlQueSePuedeAtar from)
		{
			return !base.TipoDeOrdenEstaLibre(from);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000101AC File Offset: 0x0000E3AC
		public bool Atado(HumanBodyBones humanBodyBones)
		{
			TipoDeMuscleAlQueSePuedeAtar tipoDeMuscleAlQueSePuedeAtar;
			return this.TryParseHumanBodyBonesToTipo(humanBodyBones, out tipoDeMuscleAlQueSePuedeAtar) && this.Atado(tipoDeMuscleAlQueSePuedeAtar);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000101D0 File Offset: 0x0000E3D0
		public bool TryParseHumanBodyBonesToTipo(HumanBodyBones humanBodyBones, out TipoDeMuscleAlQueSePuedeAtar tipo)
		{
			switch (humanBodyBones)
			{
			case HumanBodyBones.Hips:
				tipo = TipoDeMuscleAlQueSePuedeAtar.Hips;
				break;
			case HumanBodyBones.LeftUpperLeg:
				tipo = TipoDeMuscleAlQueSePuedeAtar.LegL;
				break;
			case HumanBodyBones.RightUpperLeg:
				tipo = TipoDeMuscleAlQueSePuedeAtar.LegR;
				break;
			case HumanBodyBones.LeftLowerLeg:
				tipo = TipoDeMuscleAlQueSePuedeAtar.CalfL;
				break;
			case HumanBodyBones.RightLowerLeg:
				tipo = TipoDeMuscleAlQueSePuedeAtar.CalfR;
				break;
			case HumanBodyBones.LeftFoot:
				tipo = TipoDeMuscleAlQueSePuedeAtar.FootL;
				break;
			case HumanBodyBones.RightFoot:
				tipo = TipoDeMuscleAlQueSePuedeAtar.FootR;
				break;
			case HumanBodyBones.Spine:
				tipo = TipoDeMuscleAlQueSePuedeAtar.Spine;
				break;
			case HumanBodyBones.Chest:
				tipo = TipoDeMuscleAlQueSePuedeAtar.Chest;
				break;
			case HumanBodyBones.Neck:
				tipo = TipoDeMuscleAlQueSePuedeAtar.Neck;
				break;
			case HumanBodyBones.Head:
				tipo = TipoDeMuscleAlQueSePuedeAtar.Head;
				break;
			case HumanBodyBones.LeftShoulder:
				tipo = TipoDeMuscleAlQueSePuedeAtar.ShoulderL;
				break;
			case HumanBodyBones.RightShoulder:
				tipo = TipoDeMuscleAlQueSePuedeAtar.ShoulderR;
				break;
			case HumanBodyBones.LeftUpperArm:
				tipo = TipoDeMuscleAlQueSePuedeAtar.ArmL;
				break;
			case HumanBodyBones.RightUpperArm:
				tipo = TipoDeMuscleAlQueSePuedeAtar.ArmR;
				break;
			case HumanBodyBones.LeftLowerArm:
				tipo = TipoDeMuscleAlQueSePuedeAtar.ForeArmL;
				break;
			case HumanBodyBones.RightLowerArm:
				tipo = TipoDeMuscleAlQueSePuedeAtar.ForeArmR;
				break;
			case HumanBodyBones.LeftHand:
				tipo = TipoDeMuscleAlQueSePuedeAtar.HandL;
				break;
			case HumanBodyBones.RightHand:
				tipo = TipoDeMuscleAlQueSePuedeAtar.HandR;
				break;
			default:
				tipo = TipoDeMuscleAlQueSePuedeAtar.Hips;
				return false;
			}
			return true;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000102A0 File Offset: 0x0000E4A0
		public HumanBodyBones ParseTipoIdToHumanBodyBones(TipoDeMuscleAlQueSePuedeAtar tipoId)
		{
			switch (tipoId)
			{
			case TipoDeMuscleAlQueSePuedeAtar.Hips:
				return HumanBodyBones.Hips;
			case TipoDeMuscleAlQueSePuedeAtar.Spine:
				return HumanBodyBones.Spine;
			case TipoDeMuscleAlQueSePuedeAtar.Head:
				return HumanBodyBones.Head;
			case TipoDeMuscleAlQueSePuedeAtar.ArmL:
				return HumanBodyBones.LeftUpperArm;
			case TipoDeMuscleAlQueSePuedeAtar.ArmR:
				return HumanBodyBones.RightUpperArm;
			case TipoDeMuscleAlQueSePuedeAtar.HandL:
				return HumanBodyBones.LeftHand;
			case TipoDeMuscleAlQueSePuedeAtar.HandR:
				return HumanBodyBones.RightHand;
			case TipoDeMuscleAlQueSePuedeAtar.LegL:
				return HumanBodyBones.LeftUpperLeg;
			case TipoDeMuscleAlQueSePuedeAtar.LegR:
				return HumanBodyBones.RightUpperLeg;
			case TipoDeMuscleAlQueSePuedeAtar.FootL:
				return HumanBodyBones.LeftFoot;
			case TipoDeMuscleAlQueSePuedeAtar.FootR:
				return HumanBodyBones.RightFoot;
			case TipoDeMuscleAlQueSePuedeAtar.Tail:
				throw new NotImplementedException();
			case TipoDeMuscleAlQueSePuedeAtar.Prop:
				throw new NotImplementedException();
			case TipoDeMuscleAlQueSePuedeAtar.Neck:
				return HumanBodyBones.Neck;
			case TipoDeMuscleAlQueSePuedeAtar.Chest:
				return HumanBodyBones.Chest;
			case TipoDeMuscleAlQueSePuedeAtar.ForeArmL:
				return HumanBodyBones.LeftLowerArm;
			case TipoDeMuscleAlQueSePuedeAtar.ForeArmR:
				return HumanBodyBones.RightLowerArm;
			case TipoDeMuscleAlQueSePuedeAtar.CalfL:
				return HumanBodyBones.LeftLowerLeg;
			case TipoDeMuscleAlQueSePuedeAtar.CalfR:
				return HumanBodyBones.RightLowerLeg;
			case TipoDeMuscleAlQueSePuedeAtar.ShoulderL:
				return HumanBodyBones.LeftShoulder;
			case TipoDeMuscleAlQueSePuedeAtar.ShoulderR:
				return HumanBodyBones.RightShoulder;
			default:
				throw new ArgumentOutOfRangeException(tipoId.ToString());
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00010358 File Offset: 0x0000E558
		public Transform ParseTipoIdToBone(TipoDeMuscleAlQueSePuedeAtar tipoId)
		{
			HumanBodyBones humanBodyBones = this.ParseTipoIdToHumanBodyBones(tipoId);
			return this.m_Animator.GetBoneTransform(humanBodyBones);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00010379 File Offset: 0x0000E579
		public override TipoDeMuscleAlQueSePuedeAtar ParseIndexToTipoId(int index)
		{
			return (TipoDeMuscleAlQueSePuedeAtar)index;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0001037C File Offset: 0x0000E57C
		public override int ParseTipoIdToindex(TipoDeMuscleAlQueSePuedeAtar tipoId)
		{
			return (int)tipoId;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0001037F File Offset: 0x0000E57F
		protected override AtadurasDePuppetHaciaMuscleController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x04000236 RID: 566
		public float damperMod;

		// Token: 0x04000237 RID: 567
		public float damperAngularMod;

		// Token: 0x04000238 RID: 568
		public float maximoSping = 500000000f;

		// Token: 0x04000239 RID: 569
		public float maximoAngularSpring = 5000000f;

		// Token: 0x0400023A RID: 570
		private IIKUpdater m_updater;

		// Token: 0x0400023B RID: 571
		private Animator m_Animator;

		// Token: 0x0400023C RID: 572
		private PuppetMaster m_PuppetMaster;

		// Token: 0x0200014A RID: 330
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<AtadurasDePuppetHaciaMuscleController.Stado, AtadurasDePuppetHaciaMuscleController.Orden, AtadurasDePuppetHaciaMuscleController.Colas, AtadurasDePuppetHaciaMuscleController, TipoDeMuscleAlQueSePuedeAtar>.OrdenBaseDeControllador
		{
			// Token: 0x06000B66 RID: 2918 RVA: 0x000344F0 File Offset: 0x000326F0
			public Orden(TipoDeMuscleAlQueSePuedeAtar Form, TipoDeMuscleAlQueSePuedeAtar To, bool lockOnSpringMax, bool angularLockOnSpringMax, Action<AtadurasDePuppetHaciaMuscleController.Orden> comenzadaCallBack, Action<AtadurasDePuppetHaciaMuscleController.Orden> terminadaCallBack)
				: base(Form, int.MaxValue, -1f, ControllerPrioridadConfig.prioridad, comenzadaCallBack, terminadaCallBack)
			{
				this.lockOnSpringMax = lockOnSpringMax;
				this.angularLockOnSpringMax = angularLockOnSpringMax;
				this.to = To;
			}

			// Token: 0x17000234 RID: 564
			// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0003456A File Offset: 0x0003276A
			public TipoDeMuscleAlQueSePuedeAtar from
			{
				get
				{
					return base.tipoId;
				}
			}

			// Token: 0x06000B68 RID: 2920 RVA: 0x00034574 File Offset: 0x00032774
			protected override void OnStart(AtadurasDePuppetHaciaMuscleController dataUpdate)
			{
				Transform transform = dataUpdate.ParseTipoIdToBone(this.from);
				Transform transform2 = dataUpdate.ParseTipoIdToBone(this.to);
				this.fromMuscle = dataUpdate.m_PuppetMaster.GetMuscle(transform);
				this.toMuscle = dataUpdate.m_PuppetMaster.GetMuscle(transform2);
				this.kinematic = dataUpdate.transform.CreateChild("Atadura " + this.from.ToString() + " hacia " + this.to.ToString()).gameObject.AddComponent<Rigidbody>();
				this.kinematic.isKinematic = true;
				Vector3 position = this.fromMuscle.rigidbody.transform.position;
				Quaternion rotation = this.fromMuscle.rigidbody.transform.rotation;
				AtadurasDePuppetHaciaMuscleController.Orden.SyncKinematicToBone(this.toMuscle.rigidbody, this.toMuscle.target);
				Vector3 position2 = this.fromMuscle.rigidbody.transform.position;
				Quaternion rotation2 = this.fromMuscle.rigidbody.transform.rotation;
				AtadurasDePuppetHaciaMuscleController.Orden.SyncKinematicToBone(this.fromMuscle.rigidbody, this.fromMuscle.target);
				AtadurasDePuppetHaciaMuscleController.Orden.SyncKinematicToBone(this.kinematic, this.toMuscle.target);
				this.joint = this.kinematic.gameObject.AddComponent<ConfigurableJoint>();
				this.joint.autoConfigureConnectedAnchor = true;
				this.joint.projectionMode = JointProjectionMode.PositionAndRotation;
				this.UpdateConnectedBody();
				this.toMuscle.rigidbody.transform.SetPositionAndRotation(position, rotation);
				this.fromMuscle.rigidbody.transform.SetPositionAndRotation(position2, rotation2);
			}

			// Token: 0x06000B69 RID: 2921 RVA: 0x00034728 File Offset: 0x00032928
			protected override bool UpdateOrden(AtadurasDePuppetHaciaMuscleController dataUpdate, bool esPrimerUpdate)
			{
				if (!esPrimerUpdate)
				{
					AtadurasDePuppetHaciaMuscleController.Orden.SyncKinematicToBone(this.kinematic, this.toMuscle.rigidbody.transform);
				}
				bool flag = AtadurasDePuppetHaciaMuscleController.Orden.CalculeDriver(ref this.drive, this.fromMuscle.rigidbody, this.joint, dataUpdate.maximoSping, this.springVelocityMod, dataUpdate.damperMod, base.estadoDeltaTime);
				bool flag2 = AtadurasDePuppetHaciaMuscleController.Orden.CalculeDriver(ref this.angularDrive, this.fromMuscle.rigidbody, this.joint, dataUpdate.maximoAngularSpring, this.springVelocityMod, dataUpdate.damperAngularMod, base.estadoDeltaTime);
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
				if (!esPrimerUpdate)
				{
					this.UpdateConnectedBody();
				}
				return true;
			}

			// Token: 0x06000B6A RID: 2922 RVA: 0x00034801 File Offset: 0x00032A01
			protected override void OnDetenidaPorUsuario(AtadurasDePuppetHaciaMuscleController dataUpdate)
			{
			}

			// Token: 0x06000B6B RID: 2923 RVA: 0x00034804 File Offset: 0x00032A04
			protected override bool OnTerminando(AtadurasDePuppetHaciaMuscleController dataUpdate, bool primerUpdate, AtadurasDePuppetHaciaMuscleController.Orden esperandoDetencion)
			{
				bool flag = AtadurasDePuppetHaciaMuscleController.Orden.CalculeDisminucionDriver(ref this.drive, this.fromMuscle.rigidbody, this.joint, dataUpdate.maximoSping, this.springVelocityMod, dataUpdate.damperMod, base.estadoDeltaTime);
				bool flag2 = AtadurasDePuppetHaciaMuscleController.Orden.CalculeDisminucionDriver(ref this.angularDrive, this.fromMuscle.rigidbody, this.joint, dataUpdate.maximoAngularSpring, this.springVelocityMod, dataUpdate.damperAngularMod, base.estadoDeltaTime);
				if ((flag && flag2) || float.IsNaN(this.drive.positionSpring) || float.IsNaN(this.drive.positionDamper) || float.IsNaN(this.angularDrive.positionSpring) || float.IsNaN(this.angularDrive.positionDamper))
				{
					return true;
				}
				this.CambiarMotions(ConfigurableJointMotion.Free);
				this.CambiarAngularMotions(ConfigurableJointMotion.Free);
				AtadurasDePuppetHaciaMuscleController.Orden.SyncKinematicToBone(this.kinematic, this.toMuscle.rigidbody.transform);
				this.UpdateDrivers();
				return false;
			}

			// Token: 0x06000B6C RID: 2924 RVA: 0x000348F8 File Offset: 0x00032AF8
			protected override void OnTerminada(AtadurasDePuppetHaciaMuscleController dataUpdate, bool abruptamente)
			{
				Rigidbody rigidbody = this.kinematic;
				if ((rigidbody != null) ? rigidbody.gameObject : null)
				{
					Object.Destroy(this.kinematic.gameObject);
				}
				this.joint = null;
				this.kinematic = null;
				this.fromMuscle = null;
				this.toMuscle = null;
			}

			// Token: 0x06000B6D RID: 2925 RVA: 0x0003494C File Offset: 0x00032B4C
			private void UpdateConnectedBody()
			{
				if (this.fromMuscle.rigidbody.gameObject.activeInHierarchy && !this.fromMuscle.rigidbody.isKinematic)
				{
					if (this.joint.connectedBody != this.fromMuscle.rigidbody)
					{
						this.joint.connectedBody = this.fromMuscle.rigidbody;
						return;
					}
				}
				else
				{
					this.joint.connectedBody = null;
				}
			}

			// Token: 0x06000B6E RID: 2926 RVA: 0x000349C4 File Offset: 0x00032BC4
			public void CambiarMotions(ConfigurableJointMotion motion)
			{
				ConfigurableJoint configurableJoint = this.joint;
				ConfigurableJoint configurableJoint2 = this.joint;
				this.joint.yMotion = motion;
				configurableJoint2.zMotion = motion;
				configurableJoint.xMotion = motion;
			}

			// Token: 0x06000B6F RID: 2927 RVA: 0x000349FC File Offset: 0x00032BFC
			public void CambiarAngularMotions(ConfigurableJointMotion motion)
			{
				ConfigurableJoint configurableJoint = this.joint;
				ConfigurableJoint configurableJoint2 = this.joint;
				this.joint.angularYMotion = motion;
				configurableJoint2.angularZMotion = motion;
				configurableJoint.angularXMotion = motion;
			}

			// Token: 0x06000B70 RID: 2928 RVA: 0x00034A34 File Offset: 0x00032C34
			public static bool CalculeDisminucionDriver(ref JointDrive drive, Rigidbody rigid, ConfigurableJoint joint, float maximaRigidez, float velocityMod, float damperMod, float deltatime)
			{
				if (drive.positionSpring <= 0f)
				{
					return true;
				}
				float mass = rigid.mass;
				float num = drive.positionSpring / mass;
				if (num <= 0f)
				{
					return true;
				}
				float num2 = Mathf.Max(0.1f, num) * velocityMod;
				float num3 = Mathf.MoveTowards(num, 0f, num2 * deltatime);
				drive.positionSpring = num3 * mass;
				drive.positionDamper = drive.positionSpring * damperMod;
				return false;
			}

			// Token: 0x06000B71 RID: 2929 RVA: 0x00034AA4 File Offset: 0x00032CA4
			public static bool CalculeDriver(ref JointDrive drive, Rigidbody rigid, ConfigurableJoint joint, float maximaRigidez, float velocityMod, float damperMod, float deltatime)
			{
				float mass = rigid.mass;
				float num = drive.positionSpring / mass;
				float num2 = Mathf.Max(0.1f, num) * velocityMod;
				float num3 = Mathf.MoveTowards(num, maximaRigidez, num2 * deltatime);
				drive.positionSpring = num3 * mass;
				drive.positionDamper = drive.positionSpring * damperMod;
				float num4 = maximaRigidez * mass;
				return drive.positionSpring >= num4;
			}

			// Token: 0x06000B72 RID: 2930 RVA: 0x00034B08 File Offset: 0x00032D08
			public void UpdateDrivers()
			{
				this.joint.zDrive = (this.joint.yDrive = (this.joint.xDrive = this.drive));
				this.joint.angularYZDrive = (this.joint.angularXDrive = this.angularDrive);
			}

			// Token: 0x06000B73 RID: 2931 RVA: 0x00034B61 File Offset: 0x00032D61
			public static void SyncKinematicToBone(Rigidbody kinematic, Transform bone)
			{
				kinematic.transform.SetPositionAndRotation(bone.position, bone.rotation);
			}

			// Token: 0x040007B0 RID: 1968
			public TipoDeMuscleAlQueSePuedeAtar to;

			// Token: 0x040007B1 RID: 1969
			public float springVelocityMod = 10f;

			// Token: 0x040007B2 RID: 1970
			public ConfigurableJoint joint;

			// Token: 0x040007B3 RID: 1971
			public Rigidbody kinematic;

			// Token: 0x040007B4 RID: 1972
			public Muscle fromMuscle;

			// Token: 0x040007B5 RID: 1973
			public Muscle toMuscle;

			// Token: 0x040007B6 RID: 1974
			public JointDrive drive = new JointDrive
			{
				maximumForce = float.MaxValue
			};

			// Token: 0x040007B7 RID: 1975
			public JointDrive angularDrive = new JointDrive
			{
				maximumForce = float.MaxValue
			};

			// Token: 0x040007B8 RID: 1976
			public bool lockOnSpringMax;

			// Token: 0x040007B9 RID: 1977
			public bool angularLockOnSpringMax;
		}

		// Token: 0x0200014B RID: 331
		public sealed class Colas : ControllerColaDePrioridadBase<AtadurasDePuppetHaciaMuscleController.Stado, AtadurasDePuppetHaciaMuscleController.Orden, AtadurasDePuppetHaciaMuscleController.Colas, AtadurasDePuppetHaciaMuscleController, TipoDeMuscleAlQueSePuedeAtar>.ColasBase
		{
		}

		// Token: 0x0200014C RID: 332
		public sealed class Stado : ControllerColaDePrioridadBase<AtadurasDePuppetHaciaMuscleController.Stado, AtadurasDePuppetHaciaMuscleController.Orden, AtadurasDePuppetHaciaMuscleController.Colas, AtadurasDePuppetHaciaMuscleController, TipoDeMuscleAlQueSePuedeAtar>.StadoBase
		{
		}
	}
}
