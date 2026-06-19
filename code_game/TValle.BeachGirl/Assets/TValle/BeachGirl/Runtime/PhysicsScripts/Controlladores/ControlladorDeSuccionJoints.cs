using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Controlladores
{
	// Token: 0x02000078 RID: 120
	public class ControlladorDeSuccionJoints : ControllerColaDePrioridadBase<ControlladorDeSuccionJoints.Stado, ControlladorDeSuccionJoints.Orden, ControlladorDeSuccionJoints.Colas, ControlladorDeSuccionJoints, int>
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00008476 File Offset: 0x00006676
		protected override int cantidadDeEstados
		{
			get
			{
				return 20;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000847A File Offset: 0x0000667A
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.fixedUpdate1);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00008483 File Offset: 0x00006683
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00008486 File Offset: 0x00006686
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_boca = this.GetComponentEnRoot(false);
			if (this.m_boca == null)
			{
				throw new ArgumentNullException("m_boca", "m_boca null reference.");
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000084B3 File Offset: 0x000066B3
		private bool OrdenEnConpatible(ControlladorDeSuccionJoints.Orden ordenAReusar, int SlotID, Rigidbody source, Rigidbody target)
		{
			return ordenAReusar.tipoId == SlotID && ordenAReusar.source == source && ordenAReusar.target == target;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000084DB File Offset: 0x000066DB
		private void UpdateDataDeOrdenAResuar(Func<bool> isValidToJoint, float weigth, float maxWorldDistance, ControlladorDeSuccionJoints.Orden ordenAReusar, float InTime, float OutTime, float breakForce)
		{
			ordenAReusar.isValidToJoint = isValidToJoint;
			ordenAReusar.weigth = weigth;
			ordenAReusar.maxWorldDistance = maxWorldDistance;
			ordenAReusar.inTime = InTime;
			ordenAReusar.outTime = OutTime;
			ordenAReusar.breakForce = breakForce;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00008510 File Offset: 0x00006710
		public bool DoSuccion(float weigth, float maxWorldDistance, int slotID, Rigidbody target, int prioridad, ControllerPrioridadConfig priConfig, float duracion, float InTime, float OutTime, float breakForce, Func<bool> isValidToJoint = null)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			Rigidbody rootParaNoPenetracionSuckJoints = this.m_boca.rootParaNoPenetracionSuckJoints;
			if (rootParaNoPenetracionSuckJoints == null)
			{
				throw new ArgumentNullException("source", "source null reference.");
			}
			bool flag = false;
			ControlladorDeSuccionJoints.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, slotID, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			if (isValidToJoint == null)
			{
				isValidToJoint = this.m_ConstantTrue;
			}
			if (orden == null)
			{
				ControlladorDeSuccionJoints.Orden orden2;
				if (base.currentStado.ExisteOrdenDeteniendose(slotID, out orden2) && (base.PuedeReusarse(orden2, priConfig, slotID) && this.OrdenEnConpatible(orden2, slotID, rootParaNoPenetracionSuckJoints, target)) && base.currentStado.TryRevivirOrden(orden2))
				{
					this.UpdateDataDeOrdenAResuar(isValidToJoint, weigth, maxWorldDistance, orden2, InTime, OutTime, breakForce);
					base.ResusarOrden(orden2, duracion, prioridad, null, null);
					return true;
				}
			}
			else if (base.PuedeAcumularse(orden, priConfig, slotID) && this.OrdenEnConpatible(orden, slotID, rootParaNoPenetracionSuckJoints, target))
			{
				this.UpdateDataDeOrdenAResuar(isValidToJoint, weigth, maxWorldDistance, orden, InTime, OutTime, breakForce);
				base.ResusarOrden(orden, duracion, prioridad, null, null);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			ControlladorDeSuccionJoints.Orden orden3 = new ControlladorDeSuccionJoints.Orden(isValidToJoint, weigth, maxWorldDistance, slotID, rootParaNoPenetracionSuckJoints, target, prioridad, priConfig, duracion, InTime, OutTime, breakForce);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00008656 File Offset: 0x00006856
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00008659 File Offset: 0x00006859
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000865C File Offset: 0x0000685C
		protected override ControlladorDeSuccionJoints ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00008660 File Offset: 0x00006860
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			IFemaleChar firstFem = (IFemaleChar)Singleton<CharacteresActivos>.instance.characteres.First((ICharacterUnico c) => c is IFemaleChar);
			PenisPart penisPart = (from c in Physics.OverlapSphere(firstFem.bocaHole.entrada.position, 10f, Singleton<ConfiguracionGeneral>.instance.layers.penes.ToLayerMask(), QueryTriggerInteraction.Ignore)
				select c.GetComponentInParent<PenisPart>() into p
				where p != null
				orderby Vector3.Distance(p.physicBone.transform.position, firstFem.bocaHole.entrada.position)
				select p).First<PenisPart>();
			this.DoSuccion(1f, 1f, 9, penisPart.physicBone, int.MaxValue, ControllerPrioridadConfig.prioridad, 5f, 0.0333f, 0.333f, this.defaultBreakForce, null);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000877A File Offset: 0x0000697A
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "TEST do joint with first female againts closes part 10 meters"
			};
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00008794 File Offset: 0x00006994
		protected override void OnAplicar3()
		{
			base.OnAplicar2();
			IEnumerable<PenisPart> enumerable = from c in Physics.OverlapSphere(((IFemaleChar)Singleton<CharacteresActivos>.instance.characteres.First((ICharacterUnico c) => c is IFemaleChar)).bocaHole.entrada.position, 10f, Singleton<ConfiguracionGeneral>.instance.layers.penes.ToLayerMask(), QueryTriggerInteraction.Ignore)
				select c.GetComponentInParent<PenisPart>() into p
				where p != null
				select p;
			int num = Random.Range(0, enumerable.Count<PenisPart>());
			PenisPart penisPart = enumerable.ElementAt(num);
			this.DoSuccion(1f, 1f, num, penisPart.physicBone, int.MaxValue, ControllerPrioridadConfig.prioridad, 5f, 0.0333f, 0.333f, this.defaultBreakForce, null);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000889A File Offset: 0x00006A9A
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "TEST do joint with first female againts random Part"
			};
		}

		// Token: 0x040001AB RID: 427
		public bool debugLog;

		// Token: 0x040001AC RID: 428
		public float damperMod = 1f;

		// Token: 0x040001AD RID: 429
		public float maximoSping = 20000f;

		// Token: 0x040001AE RID: 430
		public float minPenisSpringMod = 0.074925f;

		// Token: 0x040001AF RID: 431
		public float defaultBreakForce = 1f;

		// Token: 0x040001B0 RID: 432
		private IBocaHole m_boca;

		// Token: 0x040001B1 RID: 433
		private Func<bool> m_ConstantTrue = () => true;

		// Token: 0x02000167 RID: 359
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeSuccionJoints.Stado, ControlladorDeSuccionJoints.Orden, ControlladorDeSuccionJoints.Colas, ControlladorDeSuccionJoints, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000E29 RID: 3625 RVA: 0x00030EC4 File Offset: 0x0002F0C4
			public Orden(Func<bool> IsValidToJoint, float weigth, float maxWorldDistance, int SlotID, Rigidbody Source, Rigidbody Target, int prioridad, ControllerPrioridadConfig priConfig, float duracion, float InTime, float OutTime, float breakForce)
				: base(SlotID, prioridad, duracion, priConfig, false)
			{
				this.isValidToJoint = IsValidToJoint;
				this.source = Source;
				this.target = Target;
				this.inTime = InTime;
				this.outTime = OutTime;
				this.weigth = weigth;
				this.maxWorldDistance = maxWorldDistance;
				this.breakForce = breakForce;
			}

			// Token: 0x06000E2A RID: 3626 RVA: 0x00030F59 File Offset: 0x0002F159
			protected override void OnDetenidaPorUsuario(ControlladorDeSuccionJoints dataUpdate)
			{
			}

			// Token: 0x06000E2B RID: 3627 RVA: 0x00030F5C File Offset: 0x0002F15C
			protected override bool OnTerminando(ControlladorDeSuccionJoints dataUpdate, bool primerUpdate, ControlladorDeSuccionJoints.Orden ordenEsperandoDetencion)
			{
				if (this.joint == null)
				{
					return true;
				}
				bool flag = ControlladorDeSuccionJoints.Orden.CalculeDisminucionDriver(ref this.drive, this.weigth, this.target, this.joint, dataUpdate.maximoSping, this.outTime, dataUpdate.damperMod, base.estadoDeltaTime);
				ModificadorDeDriversDeJoint modDrivers = this.m_modDrivers;
				if (((modDrivers != null) ? modDrivers.spring : null) != null)
				{
					this.m_modDrivers.spring.z = Mathf.MoveTowards(this.m_modDrivers.spring.z, 1f, 1f / this.outTime * base.estadoDeltaTime);
				}
				if (flag || float.IsNaN(this.drive.positionSpring) || float.IsNaN(this.drive.positionDamper))
				{
					return true;
				}
				if (this.joint != null)
				{
					this.CambiarMotions(ConfigurableJointMotion.Free);
					this.CambiarAngularMotions(ConfigurableJointMotion.Free);
					this.UpdateDrivers();
				}
				return false;
			}

			// Token: 0x06000E2C RID: 3628 RVA: 0x0003104C File Offset: 0x0002F24C
			protected override void OnTerminada(ControlladorDeSuccionJoints dataUpdate, bool abruptamente)
			{
				if (this.joint)
				{
					Object.Destroy(this.joint);
				}
				ModificadorDeDriversDeJoint modDrivers = this.m_modDrivers;
				if (((modDrivers != null) ? modDrivers.spring : null) != null)
				{
					this.m_modDrivers.spring.z = 0f;
				}
				if (this.m_modEstirable != null)
				{
					this.m_modEstirable.valor.valor = false;
				}
				this.source = null;
				this.target = null;
				this.joint = null;
				this.ClearMods();
			}

			// Token: 0x06000E2D RID: 3629 RVA: 0x000310D0 File Offset: 0x0002F2D0
			protected override void OnStart(ControlladorDeSuccionJoints dataUpdate)
			{
				this.joint = this.source.gameObject.AddComponent<ConfigurableJoint>();
				this.joint.autoConfigureConnectedAnchor = false;
				this.joint.connectedAnchor = Vector3.zero;
				this.joint.anchor = -Vector3.forward * this.source.transform.localScale.Escala() * 0.015f;
				this.joint.projectionMode = JointProjectionMode.PositionAndRotation;
				this.joint.connectedBody = this.target;
				this.estirableTarget = this.target.GetComponentInParent<IPeneEstirable>();
				this.StartMods();
			}

			// Token: 0x06000E2E RID: 3630 RVA: 0x0003117C File Offset: 0x0002F37C
			private void ClearMods()
			{
				ModificadorDeBool modEstirable = this.m_modEstirable;
				if (modEstirable != null)
				{
					modEstirable.TryRemoverDeOwner(true);
				}
				IPeneEstirable peneEstirable = this.estirableTarget;
				if (peneEstirable == null)
				{
					return;
				}
				DriversDeJointModificable suavisable = peneEstirable.suavisable;
				if (suavisable == null)
				{
					return;
				}
				suavisable.TryRemoverModificador(this.m_modDrivers);
			}

			// Token: 0x06000E2F RID: 3631 RVA: 0x000311B4 File Offset: 0x0002F3B4
			private void StartMods()
			{
				if (this.estirableTarget != null)
				{
					this.m_modEstirable = this.estirableTarget.estirandoOR.ObtenerModificadorNotNull(this.GetHashCode());
					this.m_modEstirable.valor.valor = true;
					this.m_modDrivers = this.estirableTarget.suavisable.ObtenerModificadorNotNull(this.GetHashCode());
				}
			}

			// Token: 0x06000E30 RID: 3632 RVA: 0x00031214 File Offset: 0x0002F414
			protected override bool UpdateOrden(ControlladorDeSuccionJoints dataUpdate, bool esPrimerUpdate)
			{
				if (this.joint == null)
				{
					if (dataUpdate.debugLog)
					{
						Debug.Log("Joint broked");
					}
					return false;
				}
				if (this.Termino() || !this.isValidToJoint())
				{
					return false;
				}
				if (Vector3.Distance(this.target.position, this.source.position) > this.maxWorldDistance)
				{
					return false;
				}
				this.m_modDrivers.spring.z = Mathf.MoveTowards(this.m_modDrivers.spring.z, dataUpdate.minPenisSpringMod, 1f / this.inTime * base.estadoDeltaTime);
				if (ControlladorDeSuccionJoints.Orden.CalculeDriver(ref this.drive, this.weigth, this.target, this.joint, dataUpdate.maximoSping, this.inTime, dataUpdate.damperMod, base.estadoDeltaTime))
				{
					this.joint.zMotion = ConfigurableJointMotion.Limited;
				}
				this.UpdateDrivers();
				this.joint.breakTorque = (this.joint.breakForce = ((this.breakForce >= 0f) ? (this.breakForce * this.joint.connectedBody.mass) : (dataUpdate.defaultBreakForce * this.joint.connectedBody.mass)));
				this.joint.linearLimit = new SoftJointLimit
				{
					limit = this.maxWorldDistance * 0.95f,
					contactDistance = this.maxWorldDistance * 0.95f * 0.5f
				};
				return true;
			}

			// Token: 0x06000E31 RID: 3633 RVA: 0x000313A0 File Offset: 0x0002F5A0
			public void UpdateDrivers()
			{
				this.joint.zDrive = (this.joint.yDrive = (this.joint.xDrive = this.drive));
			}

			// Token: 0x06000E32 RID: 3634 RVA: 0x000313DC File Offset: 0x0002F5DC
			public void CambiarMotions(ConfigurableJointMotion motion)
			{
				ConfigurableJoint configurableJoint = this.joint;
				ConfigurableJoint configurableJoint2 = this.joint;
				this.joint.yMotion = motion;
				configurableJoint2.zMotion = motion;
				configurableJoint.xMotion = motion;
			}

			// Token: 0x06000E33 RID: 3635 RVA: 0x00031414 File Offset: 0x0002F614
			public void CambiarAngularMotions(ConfigurableJointMotion motion)
			{
				ConfigurableJoint configurableJoint = this.joint;
				ConfigurableJoint configurableJoint2 = this.joint;
				this.joint.angularYMotion = motion;
				configurableJoint2.angularZMotion = motion;
				configurableJoint.angularXMotion = motion;
			}

			// Token: 0x06000E34 RID: 3636 RVA: 0x0003144C File Offset: 0x0002F64C
			public static bool CalculeDisminucionDriver(ref JointDrive drive, float weigth, Rigidbody rigid, ConfigurableJoint joint, float maximaRigidez, float Time, float damperMod, float deltatime)
			{
				if (drive.positionSpring <= 0f)
				{
					return true;
				}
				maximaRigidez *= weigth * rigid.mass;
				float num = Mathf.MoveTowards(drive.positionSpring, 0f, Mathf.Clamp(Mathf.Max(maximaRigidez, drive.positionSpring), 0.001f, float.MaxValue) * (1f / Time) * deltatime);
				drive.positionSpring = num;
				drive.positionDamper = drive.positionSpring * damperMod;
				return false;
			}

			// Token: 0x06000E35 RID: 3637 RVA: 0x000314C8 File Offset: 0x0002F6C8
			public static bool CalculeDriver(ref JointDrive drive, float weigth, Rigidbody rigid, ConfigurableJoint joint, float maximaRigidez, float Time, float damperMod, float deltatime)
			{
				maximaRigidez *= weigth * rigid.mass;
				float num = Mathf.MoveTowards(drive.positionSpring, maximaRigidez, Mathf.Clamp(Mathf.Max(maximaRigidez, drive.positionSpring), 0.001f, float.MaxValue) * (1f / Time) * deltatime);
				drive.positionSpring = num;
				drive.positionDamper = drive.positionSpring * damperMod;
				return drive.positionSpring >= maximaRigidez;
			}

			// Token: 0x04000858 RID: 2136
			public Func<bool> isValidToJoint;

			// Token: 0x04000859 RID: 2137
			public float weigth;

			// Token: 0x0400085A RID: 2138
			public float maxWorldDistance;

			// Token: 0x0400085B RID: 2139
			public ConfigurableJoint joint;

			// Token: 0x0400085C RID: 2140
			public Rigidbody source;

			// Token: 0x0400085D RID: 2141
			public Rigidbody target;

			// Token: 0x0400085E RID: 2142
			public float inTime = 1f;

			// Token: 0x0400085F RID: 2143
			public float outTime = 1f;

			// Token: 0x04000860 RID: 2144
			public float breakForce = 1f;

			// Token: 0x04000861 RID: 2145
			public JointDrive drive = new JointDrive
			{
				maximumForce = float.MaxValue
			};

			// Token: 0x04000862 RID: 2146
			public IPeneEstirable estirableTarget;

			// Token: 0x04000863 RID: 2147
			[SerializeField]
			private ModificadorDeBool m_modEstirable;

			// Token: 0x04000864 RID: 2148
			[SerializeField]
			private ModificadorDeDriversDeJoint m_modDrivers;
		}

		// Token: 0x02000168 RID: 360
		public sealed class Colas : ControllerColaDePrioridadBase<ControlladorDeSuccionJoints.Stado, ControlladorDeSuccionJoints.Orden, ControlladorDeSuccionJoints.Colas, ControlladorDeSuccionJoints, int>.ColasBase
		{
		}

		// Token: 0x02000169 RID: 361
		public sealed class Stado : ControllerColaDePrioridadBase<ControlladorDeSuccionJoints.Stado, ControlladorDeSuccionJoints.Orden, ControlladorDeSuccionJoints.Colas, ControlladorDeSuccionJoints, int>.StadoBase
		{
		}
	}
}
