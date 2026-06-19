using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using TValleCustomClases;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex
{
	// Token: 0x02000046 RID: 70
	public sealed class ControlladorDeAutoSexV2 : ControllerColaDePrioridadBase<ControlladorDeAutoSexV2.Stado, ControlladorDeAutoSexV2.Orden, ControlladorDeAutoSexV2.Colas, ControlladorDeAutoSexV2, int>
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000F957 File Offset: 0x0000DB57
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateAfterFinalIK);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000F960 File Offset: 0x0000DB60
		public override GlobalUpdater.UpdateType? updateEvent3
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterOralAt);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000F969 File Offset: 0x0000DB69
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.fixedUpdate1);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000F972 File Offset: 0x0000DB72
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000F975 File Offset: 0x0000DB75
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000304 RID: 772 RVA: 0x0000F978 File Offset: 0x0000DB78
		// (remove) Token: 0x06000305 RID: 773 RVA: 0x0000F9B0 File Offset: 0x0000DBB0
		private event Action<ControlladorDeAutoSexV2> onAllIKsUpdated;

		// Token: 0x06000306 RID: 774 RVA: 0x0000F9E8 File Offset: 0x0000DBE8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_char = this.GetComponentEnRoot(false);
			if (this.m_char == null)
			{
				throw new ArgumentNullException("m_char", "m_char null reference.");
			}
			this.m_respirador = this.GetComponentEnRoot(false);
			if (this.m_respirador == null)
			{
				throw new ArgumentNullException("m_respirador", "m_respirador null reference.");
			}
			this.m_IIKUpdater = this.GetComponentEnRoot(false);
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("m_IIKUpdater", "m_IIKUpdater null reference.");
			}
			this.m_AfterOralAtAccion = new Action<ControlladorDeAutoSexV2.Orden>(this.AfterOralAtAccion);
			this.m_effector = this.m_char.bodyAnimator.transform.CreateChild("EffectorDe_" + base.GetType().Name).gameObject.AddComponent<WorldEffectorOffsetComplejo>();
			this.m_effector.Init(IKLayerFlag.segundo, IKOrderFlag.primero, IKPassOrderFlag.primero);
			this.m_effector.modifying += this.M_effector_modifying;
			this.m_effector.usaBodyOffset = false;
			this.m_effector.usaLeftHandOffset = false;
			this.m_effector.usaRightHandOffset = false;
			this.m_effector.usaLeftFootOffset = false;
			this.m_effector.usaRightFootOffset = false;
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_IVagHole = this.GetComponentEnRoot(false);
			if (this.m_IVagHole == null)
			{
				throw new ArgumentNullException("m_IVagHole", "m_IVagHole null reference.");
			}
			this.m_IAnusHole = this.GetComponentEnRoot(false);
			if (this.m_IAnusHole == null)
			{
				throw new ArgumentNullException("m_IAnusHole", "m_IAnusHole null reference.");
			}
			this.m_IAutoSexRangesGetter = this.GetComponentEnRoot(false);
			if (this.m_IAutoSexRangesGetter == null)
			{
				throw new ArgumentNullException("m_IAutoSexRangesGetter", "m_IAutoSexRangesGetter null reference.");
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000FBAB File Offset: 0x0000DDAB
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IIKUpdater.onAllIKsUpdated += this.M_IIKUpdater_onAllIKsUpdated;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000FBCA File Offset: 0x0000DDCA
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onAllIKsUpdated -= this.M_IIKUpdater_onAllIKsUpdated;
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000FBF2 File Offset: 0x0000DDF2
		private void M_IIKUpdater_onAllIKsUpdated(IIKUpdater obj)
		{
			Action<ControlladorDeAutoSexV2> action = this.onAllIKsUpdated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000FC08 File Offset: 0x0000DE08
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			PuppetMusclePropMods componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("propMods", "propMods null reference.");
			}
			this.m_puppet = this.GetComponentEnRoot(false);
			if (this.m_puppet == null)
			{
				throw new ArgumentNullException("m_puppet", "m_puppet null reference.");
			}
			this.m_HeadMinPinsDePuppet.Init(componentEnRoot, this.m_puppet, this);
			this.m_HeadMinSpringDePuppet.Init(componentEnRoot, this.m_puppet, this);
			this.m_HipsMinPinsDePuppet.Init(componentEnRoot, this.m_puppet, this);
			this.m_HipsMinSpringDePuppet.Init(componentEnRoot, this.m_puppet, this);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000FCB4 File Offset: 0x0000DEB4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ControlladorDeAutoSexV2.HeadMinPinsDePuppet headMinPinsDePuppet = this.m_HeadMinPinsDePuppet;
			if (headMinPinsDePuppet != null)
			{
				headMinPinsDePuppet.Destroy();
			}
			ControlladorDeAutoSexV2.HeadMinSpringDePuppet headMinSpringDePuppet = this.m_HeadMinSpringDePuppet;
			if (headMinSpringDePuppet != null)
			{
				headMinSpringDePuppet.Destroy();
			}
			ControlladorDeAutoSexV2.HipsMinPinsDePuppet hipsMinPinsDePuppet = this.m_HipsMinPinsDePuppet;
			if (hipsMinPinsDePuppet != null)
			{
				hipsMinPinsDePuppet.Destroy();
			}
			ControlladorDeAutoSexV2.ThigsMinSpringDePuppet hipsMinSpringDePuppet = this.m_HipsMinSpringDePuppet;
			if (hipsMinSpringDePuppet == null)
			{
				return;
			}
			hipsMinSpringDePuppet.Destroy();
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000FD0B File Offset: 0x0000DF0B
		private void AfterOralAtAccion(ControlladorDeAutoSexV2.Orden orden)
		{
			orden.AfterOralAtAccion(this);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000FD14 File Offset: 0x0000DF14
		private void M_effector_modifying(TValleOffsetModifier obj)
		{
			this.m_ChestPosition = this.m_char.bones.chest.transform.position;
			this.m_ChestBocaOffset = this.m_IBocaHole.entrada.position - this.m_ChestPosition;
			this.m_HipsPosition = this.m_char.bones.hips.transform.position;
			this.m_HipsVagOffset = this.m_IVagHole.entrada.position - this.m_HipsPosition;
			this.m_HipsAnusOffset = this.m_IAnusHole.entrada.position - this.m_HipsPosition;
			this.m_BocaPlaneNormal = this.m_IBocaHole.worldOutHoleDirection;
			this.m_BocaPlanePoint = this.m_IBocaHole.entrada.position;
			this.m_VagPlaneNormal = this.m_IVagHole.worldOutHoleDirection;
			this.m_VagPlanePoint = this.m_IVagHole.entrada.position;
			this.m_AnusPlaneNormal = this.m_IAnusHole.worldOutHoleDirection;
			this.m_AnusPlanePoint = this.m_IAnusHole.entrada.position;
			bool flag = this.debugDrawTrayectoria;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000FE40 File Offset: 0x0000E040
		public override void OnUpdateEvent2()
		{
			this.m_posicionDeBocaSinLookAtNiOralAt = this.m_IBocaHole.entrada.position;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000FE58 File Offset: 0x0000E058
		public override void OnUpdateEvent3()
		{
			base.currentStado.EjecutarEnEjecutandose(this.m_AfterOralAtAccion);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000FE6B File Offset: 0x0000E06B
		protected override void ControllerUpdating()
		{
			this.m_posicionDeBocaConLookAtAndOralAt = this.m_IBocaHole.entrada.position;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000FE84 File Offset: 0x0000E084
		public bool DoAutoSex(Func<ControlladorDeAutoSexV2.Orden, bool> puedeSeguirEnAutoSex, float weight, ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante, int prioridad, ControllerPrioridadConfig priConfig, float duracion)
		{
			if (puedeSeguirEnAutoSex == null)
			{
				puedeSeguirEnAutoSex = ControlladorDeAutoSexV2.m_autoSexEsValidoDEFAULT;
			}
			IHole hole;
			Muscle muscle;
			if (estimulado != ParteDelCuerpoHumano.bocaInterno)
			{
				if (estimulado != ParteDelCuerpoHumano.ano)
				{
					if (estimulado != ParteDelCuerpoHumano.vag)
					{
						throw new ArgumentOutOfRangeException(estimulado.ToString());
					}
					hole = this.m_IVagHole;
					muscle = this.m_puppet.GetMuscle(HumanBodyBones.Hips);
				}
				else
				{
					hole = this.m_IAnusHole;
					muscle = this.m_puppet.GetMuscle(HumanBodyBones.Hips);
				}
			}
			else
			{
				hole = this.m_IBocaHole;
				muscle = this.m_puppet.GetMuscle(HumanBodyBones.Head);
			}
			if (hole == null)
			{
				throw new ArgumentNullException("hole", "hole null reference.");
			}
			if (!hole.isPenetrated)
			{
				throw new NotSupportedException();
			}
			bool flag = false;
			ControlladorDeAutoSexV2.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			ControlladorDeAutoSexV2.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, 0, out tipoDeReUsoDeOrden) && orden2.estimulante == estimulante && orden2.estimulado == estimulado && orden2.hole == hole)
			{
				orden2.weight = weight;
				orden2.puedeSeguirEnAutoSex = puedeSeguirEnAutoSex;
				base.AcumularseORevivir(orden2, duracion, prioridad, tipoDeReUsoDeOrden, null, null);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			ControlladorDeAutoSexV2.Orden orden3 = new ControlladorDeAutoSexV2.Orden(puedeSeguirEnAutoSex, weight, hole, muscle, estimulado, estimulante, duracion, prioridad, priConfig);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000FFBE File Offset: 0x0000E1BE
		protected override ControlladorDeAutoSexV2 ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000FFC1 File Offset: 0x0000E1C1
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x04000213 RID: 531
		private const float maxDistanciaLocalEntrando = 0.4f;

		// Token: 0x04000214 RID: 532
		private const float maxDistanciaLocalSaliendo = 0.666f;

		// Token: 0x04000215 RID: 533
		public bool debugDraw;

		// Token: 0x04000216 RID: 534
		public bool debugDrawTrayectoria;

		// Token: 0x04000217 RID: 535
		public bool debugDrawMaxMinProfundidades;

		// Token: 0x04000218 RID: 536
		public ControlladorDeAutoSexV2.Config config = new ControlladorDeAutoSexV2.Config();

		// Token: 0x04000219 RID: 537
		[ReadOnlyUI]
		[SerializeField]
		private WorldEffectorOffsetComplejo m_effector;

		// Token: 0x0400021A RID: 538
		private ICharacterRespirador m_respirador;

		// Token: 0x0400021B RID: 539
		private IAnimatorCharacter m_char;

		// Token: 0x0400021C RID: 540
		private IBocaHole m_IBocaHole;

		// Token: 0x0400021D RID: 541
		private IVagHole m_IVagHole;

		// Token: 0x0400021E RID: 542
		private IAnusHole m_IAnusHole;

		// Token: 0x0400021F RID: 543
		private Action<ControlladorDeAutoSexV2.Orden> m_AfterOralAtAccion;

		// Token: 0x04000220 RID: 544
		private Vector3 m_ChestPosition;

		// Token: 0x04000221 RID: 545
		private Vector3 m_ChestBocaOffset;

		// Token: 0x04000222 RID: 546
		private Vector3 m_HipsPosition;

		// Token: 0x04000223 RID: 547
		private Vector3 m_HipsVagOffset;

		// Token: 0x04000224 RID: 548
		private Vector3 m_HipsAnusOffset;

		// Token: 0x04000225 RID: 549
		private Vector3 m_BocaPlaneNormal;

		// Token: 0x04000226 RID: 550
		private Vector3 m_BocaPlanePoint;

		// Token: 0x04000227 RID: 551
		private Vector3 m_VagPlaneNormal;

		// Token: 0x04000228 RID: 552
		private Vector3 m_VagPlanePoint;

		// Token: 0x04000229 RID: 553
		private Vector3 m_AnusPlaneNormal;

		// Token: 0x0400022A RID: 554
		private Vector3 m_AnusPlanePoint;

		// Token: 0x0400022B RID: 555
		private Vector3 m_posicionDeBocaSinLookAtNiOralAt;

		// Token: 0x0400022C RID: 556
		private Vector3 m_posicionDeBocaConLookAtAndOralAt;

		// Token: 0x0400022D RID: 557
		private IAutoSexRangesGetter m_IAutoSexRangesGetter;

		// Token: 0x0400022E RID: 558
		[Header("Modificadores")]
		[SerializeField]
		private ControlladorDeAutoSexV2.HeadMinPinsDePuppet m_HeadMinPinsDePuppet = new ControlladorDeAutoSexV2.HeadMinPinsDePuppet();

		// Token: 0x0400022F RID: 559
		[SerializeField]
		private ControlladorDeAutoSexV2.HeadMinSpringDePuppet m_HeadMinSpringDePuppet = new ControlladorDeAutoSexV2.HeadMinSpringDePuppet();

		// Token: 0x04000230 RID: 560
		[SerializeField]
		private ControlladorDeAutoSexV2.HipsMinPinsDePuppet m_HipsMinPinsDePuppet = new ControlladorDeAutoSexV2.HipsMinPinsDePuppet();

		// Token: 0x04000231 RID: 561
		[SerializeField]
		private ControlladorDeAutoSexV2.ThigsMinSpringDePuppet m_HipsMinSpringDePuppet = new ControlladorDeAutoSexV2.ThigsMinSpringDePuppet();

		// Token: 0x04000232 RID: 562
		private PuppetMaster m_puppet;

		// Token: 0x04000233 RID: 563
		private IIKUpdater m_IIKUpdater;

		// Token: 0x04000235 RID: 565
		private static Func<ControlladorDeAutoSexV2.Orden, bool> m_autoSexEsValidoDEFAULT = (ControlladorDeAutoSexV2.Orden o) => true;

		// Token: 0x02000140 RID: 320
		[Serializable]
		public class Config
		{
			// Token: 0x04000748 RID: 1864
			public float minPinOnHeadSex = 1f;

			// Token: 0x04000749 RID: 1865
			public float minSpringOnHeadSex = 1f;

			// Token: 0x0400074A RID: 1866
			public float minPinOnPelvisSex = 1f;

			// Token: 0x0400074B RID: 1867
			public float minSpringOnPelvisSex = 1f;

			// Token: 0x0400074C RID: 1868
			public float minTiempoParaDesplazarceDeInicioAfin = 0.075f;

			// Token: 0x0400074D RID: 1869
			public float slowThresholdMin = 0.09f;

			// Token: 0x0400074E RID: 1870
			public float slowThresholdMax = 0.4f;

			// Token: 0x0400074F RID: 1871
			public AnimationCurve entrandoSlow = AnimationCurveTValle.EaseInOut(0f, 0.001f, 0.75f, 0.45f, 1f, 0.001f);

			// Token: 0x04000750 RID: 1872
			public AnimationCurve saliendoSlow = AnimationCurveTValle.EaseInOut(0f, 0.001f, 0.75f, 0.3f, 1f, 0.001f);

			// Token: 0x04000751 RID: 1873
			public AnimationCurve entrandoFast = AnimationCurveTValle.EaseInOut(0f, 0.75f, 0.25f, 1f, 1f, 0.5f);

			// Token: 0x04000752 RID: 1874
			public AnimationCurve saliendoFast = AnimationCurveTValle.EaseInOut(0f, 0.5f, 0.5f, 1f, 1f, 0.75f);

			// Token: 0x04000753 RID: 1875
			public float maxTiempoSinPenetracion = 3f;

			// Token: 0x04000754 RID: 1876
			[Obsolete("se considera la velocidad min local por la scala, como la velocidad para estancarse", true)]
			[NonSerialized]
			public float velocidadAlaCualSeConsideraEstancado = 0.01f;

			// Token: 0x04000755 RID: 1877
			public float maxTiempoEstancado = 0.666f;

			// Token: 0x04000756 RID: 1878
			public float maxTiempoEstancadoCollision = 0.05f;

			// Token: 0x04000757 RID: 1879
			[Range(0f, 1f)]
			public float minHoleMod = 0.05f;

			// Token: 0x04000758 RID: 1880
			[Range(0f, 1f)]
			public float maxHoleMod = 0.95f;

			// Token: 0x04000759 RID: 1881
			public float minMaxHoleLocal = 0.01f;

			// Token: 0x0400075A RID: 1882
			[Range(0f, 1f)]
			public float minPenisModAtMinSpeed = 0.25f;

			// Token: 0x0400075B RID: 1883
			[Range(0f, 1f)]
			public float minPenisModAtMaxSpeed = 0.55f;

			// Token: 0x0400075C RID: 1884
			[Range(0f, 1f)]
			public float maxPenisMod = 0.9f;

			// Token: 0x0400075D RID: 1885
			[Range(0f, 1f)]
			public float minFingerMod = 0.15f;

			// Token: 0x0400075E RID: 1886
			[Range(0f, 1f)]
			public float maxFingerMod = 0.5f;

			// Token: 0x0400075F RID: 1887
			public float minPenisLocalVelocity = 0.001f;

			// Token: 0x04000760 RID: 1888
			public float maxPenisLocalVelocity = 0.7f;

			// Token: 0x04000761 RID: 1889
			public float minFingerLocalVelocity = 0.0005f;

			// Token: 0x04000762 RID: 1890
			public float maxFingerLocalVelocity = 0.05f;

			// Token: 0x04000763 RID: 1891
			[Range(0f, 1f)]
			public float maxVelPorPerMod = 0.9f;

			// Token: 0x04000764 RID: 1892
			[Range(0f, 1f)]
			public float minVelPorPerMod = 0.1f;

			// Token: 0x04000765 RID: 1893
			[Range(0f, 1f)]
			public float minMaxVelPorPerMod = 0.2f;
		}

		// Token: 0x02000141 RID: 321
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeAutoSexV2.Stado, ControlladorDeAutoSexV2.Orden, ControlladorDeAutoSexV2.Colas, ControlladorDeAutoSexV2, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000B2E RID: 2862 RVA: 0x00031F2C File Offset: 0x0003012C
			public Orden(Func<ControlladorDeAutoSexV2.Orden, bool> puedeSeguirEnAutoSex, float Weight, IHole Hole, Muscle Muscle, ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante, float duracion, int prioridad, ControllerPrioridadConfig priConfig)
				: base(0, prioridad, duracion, priConfig, false)
			{
				if (Hole == null)
				{
					throw new ArgumentNullException("Hole", "Hole null reference.");
				}
				if (Muscle == null)
				{
					throw new ArgumentNullException("Muscle", "Muscle null reference.");
				}
				this.hole = Hole;
				this.muscle = Muscle;
				this.weight = Weight;
				this.estimulante = estimulante;
				this.estimulado = estimulado;
				this.puedeSeguirEnAutoSex = puedeSeguirEnAutoSex;
				this.muscleCollisionEventos = Muscle.rigidbody.GetComponent<IHistorialColisionesEventos>();
				if (this.muscleCollisionEventos == null)
				{
					throw new ArgumentNullException("muscleCollisionEventos", "muscleCollisionEventos null reference.");
				}
			}

			// Token: 0x06000B2F RID: 2863 RVA: 0x00032000 File Offset: 0x00030200
			protected override void OnStart(ControlladorDeAutoSexV2 dataUpdate)
			{
				if (this.m_pinMods != null)
				{
					this.m_pinMods.SetAllToZero();
					Debug.LogError("Pin Mod no era null");
				}
				if (this.m_springMods != null)
				{
					this.m_springMods.SetAllToZero();
					Debug.LogError("Spring Mod no era null");
				}
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.estimulado;
				if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno)
				{
					if (parteDelCuerpoHumano - ParteDelCuerpoHumano.ano > 1)
					{
						throw new ArgumentOutOfRangeException(this.estimulado.ToString());
					}
					this.m_pinMods = dataUpdate.m_HipsMinPinsDePuppet;
					this.m_springMods = dataUpdate.m_HipsMinSpringDePuppet;
					this.MainBonePositionGetter = () => dataUpdate.m_HipsPosition;
					ParteDelCuerpoHumano parteDelCuerpoHumano2 = this.estimulado;
					if (parteDelCuerpoHumano2 != ParteDelCuerpoHumano.ano)
					{
						if (parteDelCuerpoHumano2 != ParteDelCuerpoHumano.vag)
						{
							throw new ArgumentOutOfRangeException(this.estimulado.ToString());
						}
						this.MainBoneOffsetToHoleGetter = () => dataUpdate.m_HipsVagOffset;
						this.HolePlaneNormalGetter = () => dataUpdate.m_VagPlaneNormal;
						this.HolePlanePointGetter = () => dataUpdate.m_VagPlanePoint;
					}
					else
					{
						this.MainBoneOffsetToHoleGetter = () => dataUpdate.m_HipsAnusOffset;
						this.HolePlaneNormalGetter = () => dataUpdate.m_AnusPlaneNormal;
						this.HolePlanePointGetter = () => dataUpdate.m_AnusPlanePoint;
					}
					this.MoveEffectorTowardsL = delegate(Vector3 target, float maxDistanceDelta)
					{
						dataUpdate.m_effector.leftThighOffset = Vector3.MoveTowards(dataUpdate.m_effector.leftThighOffset, target, maxDistanceDelta);
						return dataUpdate.m_effector.leftThighOffset;
					};
					this.MoveEffectorTowardsR = delegate(Vector3 target, float maxDistanceDelta)
					{
						dataUpdate.m_effector.rightThighOffset = Vector3.MoveTowards(dataUpdate.m_effector.rightThighOffset, target, maxDistanceDelta);
						return dataUpdate.m_effector.rightThighOffset;
					};
					this.MoveWeightTowardsL = delegate(float target, float maxDelta)
					{
						dataUpdate.m_effector.leftThighOverridenWeight = Mathf.MoveTowards(dataUpdate.m_effector.leftThighOverridenWeight, target, maxDelta);
						return dataUpdate.m_effector.leftThighOverridenWeight;
					};
					this.MoveWeightTowardsR = delegate(float target, float maxDelta)
					{
						dataUpdate.m_effector.rightThighOverridenWeight = Mathf.MoveTowards(dataUpdate.m_effector.rightThighOverridenWeight, target, maxDelta);
						return dataUpdate.m_effector.rightThighOverridenWeight;
					};
					this.SetEffectorOffSetL = delegate(Vector3 v)
					{
						dataUpdate.m_effector.leftThighOffset = v;
					};
					this.SetEffectorOffSetR = delegate(Vector3 v)
					{
						dataUpdate.m_effector.rightThighOffset = v;
					};
					this.Get_CURRENT_EffectorOffSetL = () => dataUpdate.m_effector.currentLeftThighOffset;
					this.Get_CURRENT_EffectorOffSetR = () => dataUpdate.m_effector.currentRightThighOffset;
					this.GetEffectorOffSetWeightL = () => dataUpdate.m_effector.leftThighOverridenWeight;
					this.GetEffectorOffSetWeightR = () => dataUpdate.m_effector.rightThighOverridenWeight;
				}
				else
				{
					this.m_pinMods = dataUpdate.m_HeadMinPinsDePuppet;
					this.m_springMods = dataUpdate.m_HeadMinSpringDePuppet;
					this.MainBonePositionGetter = () => dataUpdate.m_ChestPosition;
					this.MainBoneOffsetToHoleGetter = () => dataUpdate.m_ChestBocaOffset;
					this.HolePlaneNormalGetter = () => dataUpdate.m_BocaPlaneNormal;
					this.HolePlanePointGetter = () => dataUpdate.m_BocaPlanePoint;
					this.MoveEffectorTowardsL = delegate(Vector3 target, float maxDistanceDelta)
					{
						dataUpdate.m_effector.leftShoulderOffset = Vector3.MoveTowards(dataUpdate.m_effector.leftShoulderOffset, target, maxDistanceDelta);
						return dataUpdate.m_effector.leftShoulderOffset;
					};
					this.MoveEffectorTowardsR = delegate(Vector3 target, float maxDistanceDelta)
					{
						dataUpdate.m_effector.rightShoulderOffset = Vector3.MoveTowards(dataUpdate.m_effector.rightShoulderOffset, target, maxDistanceDelta);
						return dataUpdate.m_effector.rightShoulderOffset;
					};
					this.MoveWeightTowardsL = delegate(float target, float maxDelta)
					{
						dataUpdate.m_effector.leftShoulderOverridenWeight = Mathf.MoveTowards(dataUpdate.m_effector.leftShoulderOverridenWeight, target, maxDelta);
						return dataUpdate.m_effector.leftShoulderOverridenWeight;
					};
					this.MoveWeightTowardsR = delegate(float target, float maxDelta)
					{
						dataUpdate.m_effector.rightShoulderOverridenWeight = Mathf.MoveTowards(dataUpdate.m_effector.rightShoulderOverridenWeight, target, maxDelta);
						return dataUpdate.m_effector.rightShoulderOverridenWeight;
					};
					this.SetEffectorOffSetL = delegate(Vector3 v)
					{
						dataUpdate.m_effector.leftShoulderOffset = v;
					};
					this.SetEffectorOffSetR = delegate(Vector3 v)
					{
						dataUpdate.m_effector.rightShoulderOffset = v;
					};
					this.Get_CURRENT_EffectorOffSetL = () => dataUpdate.m_effector.currentLeftShoulderOffset;
					this.Get_CURRENT_EffectorOffSetR = () => dataUpdate.m_effector.currentRightShoulderOffset;
					this.GetEffectorOffSetWeightL = () => dataUpdate.m_effector.leftShoulderOverridenWeight;
					this.GetEffectorOffSetWeightR = () => dataUpdate.m_effector.rightShoulderOverridenWeight;
				}
				if (this.m_pinMods == null || this.m_springMods == null)
				{
					throw new NullReferenceException();
				}
				if (this.m_pinMods == this.m_springMods || this.m_pinMods == this.m_springMods)
				{
					throw new InvalidOperationException();
				}
				this.ResetData(dataUpdate, false);
				dataUpdate.onAllIKsUpdated -= this.DataUpdate_onAllIKsUpdated;
				dataUpdate.onAllIKsUpdated += this.DataUpdate_onAllIKsUpdated;
				this.muscleCollisionEventos.collisionStayBase -= this.MuscleCollisionEventos_collisionStayBase;
				this.muscleCollisionEventos.collisionStayBase += this.MuscleCollisionEventos_collisionStayBase;
				this.m_demandaDeOxigeno = dataUpdate.m_respirador.demandaDeOxigenoModificable.ObtenerModificadorNotNull(dataUpdate);
				this.m_demandaDeOxigeno.valor.valor = 1f;
			}

			// Token: 0x06000B30 RID: 2864 RVA: 0x00032404 File Offset: 0x00030604
			private void ResetData(ControlladorDeAutoSexV2 dataUpdate, bool esTerminado)
			{
				IHole hole = this.hole;
				float valueOrDefault = ((hole != null) ? new float?(hole.worldScaleReal) : null).GetValueOrDefault(1f);
				this.m_seAtasco = false;
				this.m_LastEstadoDeMovimiento = (this.m_EstadoDeMovimiento = ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado);
				this.m_framesEnElEstadoActual = 1;
				this.m_tiempoEnElEstadoActual = 0f;
				this.m_currentModDeVelocidadPorRangosPequenos = (this.m_currentModDeVelocidadPorDefectos = (this.m_modDeVelocidadPorRangosPequenos = (this.m_modDeVelocidadPorDefectos = 1f)));
				ParteQuePuedeEstimular parteQuePuedeEstimular = this.estimulante;
				if (parteQuePuedeEstimular != ParteQuePuedeEstimular.pene && parteQuePuedeEstimular != ParteQuePuedeEstimular.propSexToy)
				{
					if (parteQuePuedeEstimular != ParteQuePuedeEstimular.dedo)
					{
						throw new ArgumentOutOfRangeException(this.estimulante.ToString());
					}
					dataUpdate.m_effector.velocity = dataUpdate.config.minFingerLocalVelocity * valueOrDefault;
				}
				else
				{
					dataUpdate.m_effector.velocity = dataUpdate.config.minPenisLocalVelocity * valueOrDefault;
				}
				if (this.MainBonePositionGetter != null)
				{
					this.m_effectorMaxPosition = (this.m_currentEffectorPosition = this.MainBonePositionGetter());
				}
				if (esTerminado)
				{
					this.m_currentWeight = 0f;
					dataUpdate.m_HeadMinPinsDePuppet.SetAllToZero();
					dataUpdate.m_HeadMinSpringDePuppet.SetAllToZero();
					dataUpdate.m_HipsMinPinsDePuppet.SetAllToZero();
					dataUpdate.m_HipsMinSpringDePuppet.SetAllToZero();
					dataUpdate.m_effector.leftShoulderOffset = (dataUpdate.m_effector.rightShoulderOffset = (dataUpdate.m_effector.leftThighOffset = (dataUpdate.m_effector.rightThighOffset = Vector3.zero)));
					dataUpdate.m_effector.rightShoulderOverridenWeight = (dataUpdate.m_effector.leftShoulderOverridenWeight = (dataUpdate.m_effector.rightThighOverridenWeight = (dataUpdate.m_effector.leftThighOverridenWeight = 0f)));
				}
			}

			// Token: 0x06000B31 RID: 2865 RVA: 0x000325D4 File Offset: 0x000307D4
			public void AfterOralAtAccion(ControlladorDeAutoSexV2 dataUpdate)
			{
				if (this.m_LastEstadoDeMovimiento == this.m_EstadoDeMovimiento)
				{
					this.m_tiempoEnElEstadoActual = Time.deltaTime;
					this.m_framesEnElEstadoActual++;
				}
				else
				{
					this.m_tiempoEnElEstadoActual = 0f;
					this.m_framesEnElEstadoActual = 1;
				}
				this.m_LastEstadoDeMovimiento = this.m_EstadoDeMovimiento;
				if (this.Termino() || base.finalizada || !this.puedeSeguirEnAutoSex(this))
				{
					return;
				}
				bool isPenetrated = this.hole.isPenetrated;
				IPene pene = (isPenetrated ? this.hole.PenetradoPor() : this.hole.Cercano());
				float num = Mathf.Abs(this.m_maxProfundidad - this.m_minProfundidad);
				float num2 = this.m_currentVelocityReal * Time.deltaTime * 1.01f;
				float num3 = 0f;
				float num4 = 0f;
				ControlladorDeAutoSexV2.Orden.CalcularVelocidadActual(ref this.m_lastDirectionToHole, ref this.m_currentVelocityReal, Time.deltaTime, base.firstUpdate, this.hole, pene);
				if (isPenetrated)
				{
					float penetratingWorldLength = pene.penetratingWorldLength;
					num3 = penetratingWorldLength + this.m_currentVelocityReal * Time.deltaTime;
					num4 = penetratingWorldLength - this.m_currentVelocityReal * Time.deltaTime;
					bool flag = !base.firstUpdate && num2 > num;
					if (this.m_framesEnElEstadoActual == 1)
					{
						flag = flag || (this.m_EstadoDeMovimiento == ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado && num3 >= this.m_maxProfundidad) || (this.m_EstadoDeMovimiento == ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo && num4 <= this.m_minProfundidad);
					}
					ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento estadoDeMovimiento = this.m_EstadoDeMovimiento;
					if (estadoDeMovimiento != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado)
					{
						if (estadoDeMovimiento != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo)
						{
							this.m_nextFrameProfundidad = 0f;
						}
						else
						{
							this.m_nextFrameProfundidad = num4;
						}
					}
					else if (flag)
					{
						this.m_nextFrameProfundidad = penetratingWorldLength;
					}
					else
					{
						this.m_nextFrameProfundidad = num3;
					}
				}
				else
				{
					this.m_nextFrameProfundidad = 0f;
				}
				if (!base.firstUpdate)
				{
					this.m_modDeVelocidadPorDefectos = Mathf.Clamp(this.m_currentVelocidadPorPersonalidad / Mathf.Clamp(this.m_currentVelocityReal, 1E-05f, 100000f), 0.1f, 10f);
					this.m_modDeVelocidadPorRangosPequenos = Mathf.Clamp(num / Mathf.Clamp(num2, 1E-05f, 100000f), 0.01f, 1f);
					if (isPenetrated)
					{
						ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento estadoDeMovimiento = this.m_EstadoDeMovimiento;
						if (estadoDeMovimiento == ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado)
						{
							this.m_modDeVelocidadPorRangosPequenos *= 1f / Mathf.Clamp(MathfExtension.InverseLerpUnclamped(this.m_minProfundidad, this.m_maxProfundidad, num3 * 1.01f), 1f, 100f);
							return;
						}
						if (estadoDeMovimiento != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo)
						{
							throw new ArgumentOutOfRangeException(this.m_EstadoDeMovimiento.ToString());
						}
						this.m_modDeVelocidadPorRangosPequenos *= 1f / Mathf.Clamp(MathfExtension.InverseLerpUnclamped(this.m_maxProfundidad, this.m_minProfundidad, num4 * 0.99f), 1f, 100f);
						return;
					}
				}
			}

			// Token: 0x06000B32 RID: 2866 RVA: 0x000328B4 File Offset: 0x00030AB4
			protected override bool UpdateOrden(ControlladorDeAutoSexV2 dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino() || !this.puedeSeguirEnAutoSex(this))
				{
					return false;
				}
				this.m_terminando = false;
				dataUpdate.m_effector.debugDraw = dataUpdate.debugDraw || dataUpdate.debugDrawTrayectoria || dataUpdate.debugDrawMaxMinProfundidades;
				bool isPenetrated = this.hole.isPenetrated;
				if (!isPenetrated && esPrimerUpdate)
				{
					return false;
				}
				if (ControlladorDeAutoSexV2.Orden.MuchoTiempoSinPenetracion(isPenetrated, base.estadoDeltaTime, dataUpdate.config.maxTiempoSinPenetracion, ref this.m_timeNotPenetrated))
				{
					return false;
				}
				float worldScaleReal = this.hole.worldScaleReal;
				IPene pene = (isPenetrated ? this.hole.PenetradoPor() : this.hole.Cercano());
				if (isPenetrated && pene == null)
				{
					Debug.LogError("Hole era penetraco pero penis era null", dataUpdate);
					return false;
				}
				if (isPenetrated && (esPrimerUpdate || !this.coolDownDeActualizarPorPersonalidad.isOn))
				{
					this.m_velLocalRangeCurrent = dataUpdate.m_IAutoSexRangesGetter.GetRangeDeVelocidadDeAutoSex(this.estimulado, this.estimulante);
					if (esPrimerUpdate)
					{
						this.m_velLocalRangeSmoothed = this.m_velLocalRangeCurrent;
					}
					this.m_proLocalRange = dataUpdate.m_IAutoSexRangesGetter.GetRangeDeProfuncidadDeAutoSex(this.estimulado, this.estimulante);
					this.coolDownDeActualizarPorPersonalidad.Apply();
					ControlladorDeAutoSexV2.Orden.CalcularRangoProfundiadSegunPersonalidad(ref this.m_CurrentRangos.minPersonalidadProfundidad, ref this.m_CurrentRangos.maxPersonalidadProfundidad, this.m_proLocalRange, worldScaleReal, pene, this.hole);
				}
				if (Mathf.Abs(this.m_CurrentRangos.minPersonalidadProfundidad - this.m_CurrentRangos.maxPersonalidadProfundidad) < 0.04f)
				{
					return false;
				}
				ControlladorDeAutoSexV2.Orden.CalcularRangoProfundiadSegunHole(ref this.m_CurrentRangos.minHoleProfundidad, ref this.m_CurrentRangos.maxHoleProfundidad, this.hole, worldScaleReal, dataUpdate.config.minHoleMod, dataUpdate.config.maxHoleMod, dataUpdate.config.minMaxHoleLocal);
				ParteQuePuedeEstimular parteQuePuedeEstimular = this.estimulante;
				float num;
				float num2;
				if (parteQuePuedeEstimular != ParteQuePuedeEstimular.pene && parteQuePuedeEstimular != ParteQuePuedeEstimular.propSexToy)
				{
					if (parteQuePuedeEstimular != ParteQuePuedeEstimular.dedo)
					{
						throw new ArgumentOutOfRangeException(this.estimulante.ToString());
					}
					num = dataUpdate.config.minFingerMod;
					num2 = dataUpdate.config.maxFingerMod;
				}
				else
				{
					if (esPrimerUpdate)
					{
						num = dataUpdate.config.minPenisModAtMaxSpeed;
					}
					else if (this.m_currentMaxVelocidadLocalSinThresholdCurvas < dataUpdate.config.slowThresholdMin)
					{
						num = dataUpdate.config.minPenisModAtMinSpeed;
					}
					else if (this.m_currentMaxVelocidadLocalSinThresholdCurvas > dataUpdate.config.slowThresholdMax)
					{
						num = dataUpdate.config.minPenisModAtMaxSpeed;
					}
					else
					{
						float num3 = Mathf.InverseLerp(dataUpdate.config.slowThresholdMin, dataUpdate.config.slowThresholdMax, this.m_currentMaxVelocidadLocalSinThresholdCurvas);
						num = Mathf.Lerp(dataUpdate.config.minPenisModAtMinSpeed, dataUpdate.config.minPenisModAtMaxSpeed, num3);
					}
					num2 = dataUpdate.config.maxPenisMod;
				}
				ControlladorDeAutoSexV2.Orden.CalcularRangoProfundiadSegunPene(ref this.m_CurrentRangos.minPeneProfundidad, ref this.m_CurrentRangos.maxPeneProfundidad, pene, num, num2);
				ControlladorDeAutoSexV2.Orden.ActualizarSobrePasoDePlano(ref this.m_planoSobrePasado, pene, this.m_CurrentRangos.maxPeneProfundidad, this.hole, dataUpdate.debugDrawMaxMinProfundidades);
				if (this.m_planoSobrePasado && esPrimerUpdate)
				{
					Debug.LogError("No se puede hacer auto sex a un pene cuyo plano ha sido sobrepasado al inicio", dataUpdate);
					return false;
				}
				ControlladorDeAutoSexV2.Orden.CalcularRangoProfundiad(ref this.m_minProfundidad, ref this.m_maxProfundidad, this.m_CurrentRangos, worldScaleReal, this.m_currentWeight);
				this.m_currentPenetrationWeigth = ControlladorDeAutoSexV2.Orden.CalcularCurrentPenetractionWeigth(ref this.m_currentProfundidad, isPenetrated, pene, this.m_minProfundidad, this.m_maxProfundidad);
				this.m_currentModDeVelocidadPorDefectos = Mathf.MoveTowards(this.m_currentModDeVelocidadPorDefectos, this.m_modDeVelocidadPorDefectos, base.estadoDeltaTime);
				this.m_currentModDeVelocidadPorRangosPequenos = Mathf.MoveTowards(this.m_currentModDeVelocidadPorRangosPequenos, this.m_modDeVelocidadPorRangosPequenos, base.estadoDeltaTime);
				if (!base.firstUpdate)
				{
					ControlladorDeAutoSexV2.Orden.ActualizarEstancamiento(ref this.m_seAtasco, ref this.m_tiempoEstancada, isPenetrated, base.estadoDeltaTime, this.m_currentVelocityReal, this.m_currentVelocidadPorPersonalidad, dataUpdate.config.maxTiempoEstancado);
					ControlladorDeAutoSexV2.Orden.ActualizarEstancamientoPorCollision(ref this.m_seAtascoPorCollision, ref this.m_tiempoEstancadaPorCollision, isPenetrated, base.estadoDeltaTime, dataUpdate.config.maxTiempoEstancadoCollision, this.m_collisionandoContraHipsOrHands);
					this.m_collisionandoContraHipsOrHands = false;
				}
				Vector3 vector = this.MainBonePositionGetter();
				Vector3 vector2 = this.MainBoneOffsetToHoleGetter();
				Vector3 vector3 = this.HolePlaneNormalGetter();
				Vector3 vector4 = this.HolePlanePointGetter();
				Vector3 vector5 = this.m_currentEffectorPosition - vector;
				ControlladorDeAutoSexV2.Orden.ObtenerEstadoDeProfunidadYMovimiento(ref this.m_EstadoDeProfunidad, ref this.m_EstadoDeMovimiento, ref this.m_tiempoEstancada, ref this.m_seAtasco, ref this.m_seAtascoPorCollision, this.m_planoSobrePasado, isPenetrated, this.m_nextFrameProfundidad, this.m_minProfundidad, this.m_maxProfundidad, vector5, worldScaleReal, (float)this.m_framesEnElEstadoActual, dataUpdate.config.minTiempoParaDesplazarceDeInicioAfin);
				ControlladorDeAutoSexV2.Orden.ActualizarTargetMaxEnEffectorPosition(ref this.m_effectorMaxPosition, vector, vector2, vector3, vector4, isPenetrated, pene, this.m_minProfundidad, worldScaleReal, this.m_EstadoDeMovimiento, base.estadoDeltaTime, dataUpdate.debugDraw, dataUpdate.debugDrawTrayectoria);
				parteQuePuedeEstimular = this.estimulante;
				float num4;
				if (parteQuePuedeEstimular != ParteQuePuedeEstimular.pene && parteQuePuedeEstimular != ParteQuePuedeEstimular.propSexToy)
				{
					if (parteQuePuedeEstimular != ParteQuePuedeEstimular.dedo)
					{
						throw new ArgumentOutOfRangeException(this.estimulante.ToString());
					}
					num4 = dataUpdate.config.minFingerLocalVelocity;
					this.m_currentMaxLocalVelocity = dataUpdate.config.maxFingerLocalVelocity;
				}
				else
				{
					num4 = dataUpdate.config.minPenisLocalVelocity;
					this.m_currentMaxLocalVelocity = dataUpdate.config.maxPenisLocalVelocity;
				}
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.estimulado;
				float num5;
				float num6;
				if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno)
				{
					if (parteDelCuerpoHumano - ParteDelCuerpoHumano.ano > 1)
					{
						throw new ArgumentOutOfRangeException(this.estimulado.ToString());
					}
					num5 = dataUpdate.config.minPinOnPelvisSex;
					num6 = dataUpdate.config.minSpringOnPelvisSex;
				}
				else
				{
					num5 = dataUpdate.config.minPinOnHeadSex;
					num6 = dataUpdate.config.minSpringOnHeadSex;
				}
				this.m_velLocalRangeSmoothed.MoveTowards(this.m_velLocalRangeCurrent, base.estadoDeltaTime);
				ControlladorDeAutoSexV2.Orden.CalcularMaxVelocidadPorRangoDeMovimiento(ref this.m_currentMaxLocalVelocity, this.m_minProfundidad, this.m_maxProfundidad, worldScaleReal, dataUpdate.config.minTiempoParaDesplazarceDeInicioAfin);
				this.m_currentMaxLocalVelocity = ((this.m_currentMaxLocalVelocity < num4) ? num4 : this.m_currentMaxLocalVelocity);
				float num7;
				this.m_currentVelocidadPorPersonalidad = ControlladorDeAutoSexV2.Orden.CalcularVelocidadPorCurvasYPersonalidad(this.m_currentPenetrationWeigth, this.m_EstadoDeMovimiento, dataUpdate.config.slowThresholdMin, dataUpdate.config.slowThresholdMax, dataUpdate.config.entrandoSlow, dataUpdate.config.saliendoSlow, dataUpdate.config.entrandoFast, dataUpdate.config.saliendoFast, num4, this.m_currentMaxLocalVelocity, this.m_velLocalRangeSmoothed, dataUpdate.config.minVelPorPerMod, dataUpdate.config.maxVelPorPerMod, dataUpdate.config.minMaxVelPorPerMod, worldScaleReal, this.m_currentWeight, out num7, out this.m_currentMaxVelocidadLocalSinThresholdCurvas);
				this.UpdateOxigeno(dataUpdate, num4 * worldScaleReal, this.m_currentMaxLocalVelocity * worldScaleReal, this.m_currentVelocityReal, this.estimulado == ParteDelCuerpoHumano.bocaInterno);
				float num8 = Mathf.Lerp(1f, this.m_velocidadModSegunSaturacionDeOxigeno, num7);
				this.m_currentVelocidadPorPersonalidad *= num8;
				ControlladorDeAutoSexV2.Orden.MoverHaciaEffectorTargetPosition(ref this.m_currentEffectorPosition, this.m_effectorMaxPosition, this.m_currentVelocidadPorPersonalidad, base.estadoDeltaTime);
				vector5 = this.m_currentEffectorPosition - vector;
				if (dataUpdate.debugDrawTrayectoria)
				{
					vector + vector2;
				}
				this.SetEffectorOffSetL(vector5);
				this.SetEffectorOffSetR(vector5);
				dataUpdate.m_effector.velocity = this.m_currentVelocidadPorPersonalidad * this.m_currentModDeVelocidadPorDefectos * this.m_currentModDeVelocidadPorRangosPequenos;
				if (isPenetrated)
				{
					this.m_pinMods.MoveTo(num5, base.estadoDeltaTime * 0.333f);
					this.m_springMods.MoveTo(num6, base.estadoDeltaTime * Mathf.Clamp(num6, 1f, 1000f) * 0.2f);
					this.MoveWeightTowardsL(1f, base.estadoDeltaTime * 0.2f);
					this.MoveWeightTowardsR(1f, base.estadoDeltaTime * 0.2f);
					this.m_currentWeight = Mathf.MoveTowards(this.m_currentWeight, this.weight, base.estadoDeltaTime * 0.2f);
				}
				else
				{
					this.m_pinMods.MoveTo(0f, base.estadoDeltaTime * 0.333f);
					this.m_springMods.MoveTo(0f, base.estadoDeltaTime * Mathf.Clamp(num6, 1f, 1000f) * 0.2f);
					this.MoveWeightTowardsL(0f, base.estadoDeltaTime * 0.2f);
					this.MoveWeightTowardsR(0f, base.estadoDeltaTime * 0.2f);
					this.m_currentWeight = Mathf.MoveTowards(this.m_currentWeight, 0f, base.estadoDeltaTime * 0.2f);
				}
				return true;
			}

			// Token: 0x06000B33 RID: 2867 RVA: 0x00033143 File Offset: 0x00031343
			protected override void OnDetenidaPorUsuario(ControlladorDeAutoSexV2 dataUpdate)
			{
			}

			// Token: 0x06000B34 RID: 2868 RVA: 0x00033148 File Offset: 0x00031348
			protected override bool OnTerminando(ControlladorDeAutoSexV2 dataUpdate, bool primerUpdate, ControlladorDeAutoSexV2.Orden ordenEsperandoDetencion)
			{
				this.m_terminando = true;
				this.m_collisionandoContraHipsOrHands = false;
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.estimulado;
				float num;
				if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno)
				{
					if (parteDelCuerpoHumano - ParteDelCuerpoHumano.ano > 1)
					{
						throw new ArgumentOutOfRangeException(this.estimulado.ToString());
					}
					num = dataUpdate.config.minSpringOnPelvisSex;
				}
				else
				{
					num = dataUpdate.config.minSpringOnHeadSex;
				}
				this.m_pinMods.MoveTo(0f, base.estadoDeltaTime * 0.5f);
				this.m_springMods.MoveTo(0f, base.estadoDeltaTime * Mathf.Clamp(num, 1f, 1000f) * 0.5f);
				bool flag = this.m_pinMods.AtZero() && this.m_springMods.AtZero();
				this.m_currentWeight = Mathf.MoveTowards(this.m_currentWeight, 0f, base.estadoDeltaTime * 0.5f);
				this.MoveWeightTowardsL(0f, base.estadoDeltaTime * 0.25f);
				this.MoveWeightTowardsR(0f, base.estadoDeltaTime * 0.25f);
				this.MoveEffectorTowardsL(Vector3.zero, base.estadoDeltaTime);
				this.MoveEffectorTowardsR(Vector3.zero, base.estadoDeltaTime);
				return (this.m_MuscleToAnimJoint == null || (this.m_MuscleToAnimJoint.xDrive.positionSpring == 0f && this.m_MuscleToAnimJoint.angularXDrive.positionSpring == 0f)) && this.GetEffectorOffSetWeightL() == 0f && this.GetEffectorOffSetWeightR() == 0f && flag && this.m_currentWeight == 0f && this.Get_CURRENT_EffectorOffSetL() == Vector3.zero && this.Get_CURRENT_EffectorOffSetR() == Vector3.zero;
			}

			// Token: 0x06000B35 RID: 2869 RVA: 0x0003334C File Offset: 0x0003154C
			protected override void OnTerminada(ControlladorDeAutoSexV2 dataUpdate, bool abruptamente)
			{
				this.muscleCollisionEventos.collisionStayBase -= this.MuscleCollisionEventos_collisionStayBase;
				dataUpdate.onAllIKsUpdated -= this.DataUpdate_onAllIKsUpdated;
				ModificadorDeFloat demandaDeOxigeno = this.m_demandaDeOxigeno;
				if (demandaDeOxigeno != null)
				{
					demandaDeOxigeno.TryRemoverDeOwner(true);
				}
				if (this.m_MuscleToAnimJoint != null)
				{
					Object.Destroy(this.m_MuscleToAnimJoint.gameObject);
					this.m_MuscleToAnimJoint = null;
				}
				this.ResetData(dataUpdate, true);
			}

			// Token: 0x06000B36 RID: 2870 RVA: 0x000333C4 File Offset: 0x000315C4
			private void UpdateOxigeno(ControlladorDeAutoSexV2 dataUpdate, float minWorldVel, float maxWorldVel, float currentWorldVel, bool esFacial)
			{
				switch (dataUpdate.m_respirador.cansancioEstado)
				{
				case CanzancioEstado.descanzado:
				case CanzancioEstado.estaCanzandonse:
					this.m_velocidadModSegunSaturacionDeOxigeno = Mathf.MoveTowards(this.m_velocidadModSegunSaturacionDeOxigeno, 1f, base.estadoDeltaTime * 0.25f);
					break;
				case CanzancioEstado.canzado:
				case CanzancioEstado.estaDescanzandose:
					this.m_velocidadModSegunSaturacionDeOxigeno = Mathf.MoveTowards(this.m_velocidadModSegunSaturacionDeOxigeno, 0.1f, base.estadoDeltaTime * 0.5f);
					break;
				default:
					throw new ArgumentOutOfRangeException(dataUpdate.m_respirador.cansancioEstado.ToString());
				}
				float num = Mathf.InverseLerp(minWorldVel, maxWorldVel, currentWorldVel * this.m_velocidadModSegunSaturacionDeOxigeno).InInOutOutPow(3f, 1f, 0.3333f);
				if (esFacial)
				{
					this.m_demandaDeOxigeno.valor.valor = MathfExtension.LerpConMedio(1f, 5f, 20f, num);
					return;
				}
				this.m_demandaDeOxigeno.valor.valor = MathfExtension.LerpConMedio(1f, 15f, 60f, num);
			}

			// Token: 0x06000B37 RID: 2871 RVA: 0x000334D0 File Offset: 0x000316D0
			private void DataUpdate_onAllIKsUpdated(ControlladorDeAutoSexV2 dataUpdate)
			{
				float jointForce = this.m_JointForce;
				float jointAngularForce = this.m_JointAngularForce;
				if (this.usarJoint && this.m_MuscleToAnimJoint == null)
				{
					this.m_MuscleToAnimJoint = this.muscle.GenerateFollowerJoint(dataUpdate.transform);
					this.m_MuscleToAnimJoint.UpdateDrivers(false, this.muscle, 0f, 0f, false, ref this.m_currentForceVelocity, jointForce, jointForce, 1f);
					this.m_MuscleToAnimJoint.UpdateAngularDrivers(false, this.muscle, 0f, 0f, false, ref this.m_currentAngularForceVelocity, jointAngularForce, jointAngularForce, 1f);
					return;
				}
				this.m_MuscleToAnimJoint.transform.SetPositionAndRotation(this.muscle.target.position, this.muscle.target.rotation);
				bool flag;
				float num;
				float num2;
				if (this.usarJoint && !this.m_terminando)
				{
					if (!this.hole.isPenetrated)
					{
						flag = false;
						num = 0f;
						num2 = 0f;
					}
					else
					{
						flag = true;
						num = this.m_JointForce;
						num2 = this.m_JointAngularForce;
					}
				}
				else
				{
					num2 = (num = 0f);
					flag = false;
				}
				this.m_MuscleToAnimJoint.UpdateDrivers(flag, this.muscle, this.m_MuscleToAnimJoint.xDrive.positionSpring, Time.deltaTime, false, ref this.m_currentForceVelocity, num, jointForce, 1f);
				this.m_MuscleToAnimJoint.UpdateAngularDrivers(flag, this.muscle, this.m_MuscleToAnimJoint.angularXDrive.positionSpring, Time.deltaTime, false, ref this.m_currentAngularForceVelocity, num2, jointAngularForce, 1f);
			}

			// Token: 0x06000B38 RID: 2872 RVA: 0x00033660 File Offset: 0x00031860
			private void MuscleCollisionEventos_collisionStayBase(ColisionBasicaV2 obj)
			{
				this.m_collisionandoContraHipsOrHands = this.m_collisionandoContraHipsOrHands || (obj.colliderChocandonos.gameObject.layer == ConfiguracionGlobal.layersStatic.ragdoll && !obj.colliderChocandonos.transform.IsChildOf(this.muscle.rigidbody.transform.parent));
			}

			// Token: 0x06000B39 RID: 2873 RVA: 0x000336C8 File Offset: 0x000318C8
			private static void CalcularMaxVelocidadPorRangoDeMovimiento(ref float maxLocalVelocity, float minProfundidad, float maxProfundidad, float scala, float minTiempoParaDesplazarceDeInicioAfin)
			{
				float num = minProfundidad / scala;
				float num2 = Mathf.Abs(maxProfundidad / scala - num) / minTiempoParaDesplazarceDeInicioAfin;
				maxLocalVelocity = ((maxLocalVelocity > num2) ? num2 : maxLocalVelocity);
			}

			// Token: 0x06000B3A RID: 2874 RVA: 0x000336F3 File Offset: 0x000318F3
			private static void MoverHaciaEffectorTargetPosition(ref Vector3 currentEffectorPosition, Vector3 effectorMaxTargetPosition, float effectorVelocidad, float deltaTime)
			{
				currentEffectorPosition = Vector3.MoveTowards(currentEffectorPosition, effectorMaxTargetPosition, effectorVelocidad * deltaTime);
			}

			// Token: 0x06000B3B RID: 2875 RVA: 0x0003370C File Offset: 0x0003190C
			private static float CalcularVelocidadPorCurvasYPersonalidad(float currentPenetracionWeigth, ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento movimiento, float thresholdMin, float thresholdMax, AnimationCurve entrandoCurveSlow, AnimationCurve saliendoCurveSlow, AnimationCurve entrandoCurveFast, AnimationCurve saliendoCurveFast, float minLocalVelocity, float maxLocalVelocity, RangeValueV2 personalidadVelLocalRange, float minPerRange, float maxPerRange, float minMaxPerRange, float holescala, float weigth, out float TDeVelocidadPorThresholdCurvas, out float maxVelocidadLocalSinThresholdCurvas)
			{
				float num;
				AnimationCurve animationCurve;
				AnimationCurve animationCurve2;
				if (movimiento != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado)
				{
					if (movimiento != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo)
					{
						throw new ArgumentOutOfRangeException(movimiento.ToString());
					}
					num = 1f - currentPenetracionWeigth;
					animationCurve = saliendoCurveSlow;
					animationCurve2 = saliendoCurveFast;
				}
				else
				{
					num = currentPenetracionWeigth;
					animationCurve = entrandoCurveSlow;
					animationCurve2 = entrandoCurveFast;
				}
				float num2 = Mathf.Lerp(personalidadVelLocalRange.min, personalidadVelLocalRange.max, minPerRange);
				float num3 = Mathf.Lerp(personalidadVelLocalRange.min, personalidadVelLocalRange.max, maxPerRange);
				num2 = Mathf.Clamp(num2, minLocalVelocity, maxLocalVelocity);
				num3 = Mathf.Clamp(num3, minLocalVelocity, maxLocalVelocity);
				if (num2 > num3)
				{
					num2 = num3;
				}
				if (num3 - num2 < minLocalVelocity)
				{
					num2 = num3 - minLocalVelocity;
				}
				num3 = Mathf.Lerp(num2, num3, Mathf.Lerp(0.2f, 1f, weigth));
				num2 = Mathf.Max(num3 * minMaxPerRange, num2);
				if (num3 >= thresholdMin && num3 <= thresholdMax)
				{
					float num4 = Mathf.InverseLerp(thresholdMin, thresholdMax, num3);
					float num5 = animationCurve.Evaluate(num);
					float num6 = animationCurve2.Evaluate(num);
					TDeVelocidadPorThresholdCurvas = Mathf.Lerp(num5, num6, num4);
				}
				else if (num3 > thresholdMax)
				{
					TDeVelocidadPorThresholdCurvas = animationCurve2.Evaluate(num);
				}
				else
				{
					if (num3 >= thresholdMin)
					{
						throw new ArgumentOutOfRangeException();
					}
					TDeVelocidadPorThresholdCurvas = animationCurve.Evaluate(num);
				}
				float num7 = Mathf.Clamp(Mathf.Lerp(num2, num3, TDeVelocidadPorThresholdCurvas), minLocalVelocity, maxLocalVelocity) * holescala;
				maxVelocidadLocalSinThresholdCurvas = num3;
				return num7;
			}

			// Token: 0x06000B3C RID: 2876 RVA: 0x0003384C File Offset: 0x00031A4C
			private static void ObtenerEstadoDeProfunidadYMovimiento(ref ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad estadoDeProfunidad, ref ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento estadoDeMovimiento, ref float tiempoEstancada, ref bool estaAtascada, ref bool estaAtascadaPorCollision, bool planoSobrePasado, bool ispenetrating, float nextFrameProfundidad, float minProfundidad, float maxProfundidad, Vector3 currentOffsetTarget, float scala, float tiempoEnCurrentEstado, float minTiempoParaDesplazarceDeInicioAfin)
			{
				if (ispenetrating && planoSobrePasado)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMax;
				}
				else if (estaAtascada)
				{
					ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento estadoDeMovimiento2 = estadoDeMovimiento;
					if (estadoDeMovimiento2 != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado)
					{
						if (estadoDeMovimiento2 != ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo)
						{
							throw new ArgumentOutOfRangeException(estadoDeMovimiento.ToString());
						}
						estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMin;
					}
					else
					{
						estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMax;
					}
					estaAtascada = false;
					tiempoEstancada = 0f;
				}
				else if (estaAtascadaPorCollision)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMax;
					estaAtascadaPorCollision = false;
				}
				else if (!ispenetrating)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMin;
				}
				else if (estadoDeMovimiento == ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado && currentOffsetTarget.magnitude >= 0.4f * scala)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMax;
				}
				else if (estadoDeMovimiento == ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo && currentOffsetTarget.magnitude >= 0.666f * scala)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMin;
				}
				else if (nextFrameProfundidad >= maxProfundidad)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMax;
				}
				else if (nextFrameProfundidad <= minProfundidad)
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMin;
				}
				else
				{
					estadoDeProfunidad = ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.intermedio;
				}
				ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad estadoDeProfunidad2 = estadoDeProfunidad;
				if (estadoDeProfunidad2 != ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMax)
				{
					if (estadoDeProfunidad2 != ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad.enMin)
					{
						return;
					}
					estaAtascada = false;
					tiempoEstancada = 0f;
					estadoDeMovimiento = ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado;
				}
				else if (tiempoEnCurrentEstado > minTiempoParaDesplazarceDeInicioAfin)
				{
					estaAtascada = false;
					tiempoEstancada = 0f;
					estadoDeMovimiento = ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.saliendo;
					return;
				}
			}

			// Token: 0x06000B3D RID: 2877 RVA: 0x00033934 File Offset: 0x00031B34
			private static void ActualizarTargetMaxEnEffectorPosition(ref Vector3 effectorMaxPosition, Vector3 bonePosition, Vector3 boneHoleOffset, Vector3 holePlaneNormal, Vector3 holePlanePosition, bool ispenetrated, IPene pene, float minProfundidad, float scala, ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento estado, float deltatime, bool debugDraw, bool debugDrawTrayectoria)
			{
				if (pene == null)
				{
					effectorMaxPosition = Vector3.MoveTowards(effectorMaxPosition, bonePosition, deltatime * 0.333f);
					return;
				}
				holePlanePosition += holePlaneNormal * pene.worldLength * 0.2f;
				Vector3 position = pene.root.position;
				Vector3 vector = bonePosition + boneHoleOffset;
				Vector3 normalized = pene.rootDefaultForwardWorldDirection.normalized;
				Vector3 normalized2 = (vector - position).normalized;
				float num = Vector3.Dot((position - holePlanePosition).normalized, holePlaneNormal);
				float num2 = Mathf.InverseLerp(0f, 0.25f, num);
				Vector3 vector2 = Vector3.Slerp(normalized, normalized2, num2);
				if (debugDrawTrayectoria)
				{
					Debug.DrawRay(vector, -vector2, Color.blue, Time.deltaTime, false);
				}
				Vector3 vector3 = position + vector2 * pene.worldLengthFromUnderSkin;
				Vector3 vector4 = vector3 - boneHoleOffset;
				float num3;
				Vector3 vector5;
				if (!ispenetrated)
				{
					num3 = 0.4f;
					vector5 = vector4 + -vector2 * minProfundidad;
				}
				else if (estado == ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento.entrado)
				{
					num3 = 0.4f;
					vector5 = vector4 + -vector2 * scala;
				}
				else
				{
					num3 = 0.666f;
					vector5 = vector4 + vector2 * scala;
				}
				if (debugDraw)
				{
					Debug.DrawLine(vector4 + boneHoleOffset, vector5 + boneHoleOffset, Color.white, Time.deltaTime, false);
				}
				Vector3 vector6 = vector5 - bonePosition;
				vector6 = vector6.ClampMagnitud(0f, num3 * scala);
				effectorMaxPosition = bonePosition + vector6;
				if (debugDraw)
				{
					Debug.DrawLine(position, vector3, Color.black, Time.deltaTime, false);
				}
			}

			// Token: 0x06000B3E RID: 2878 RVA: 0x00033AF1 File Offset: 0x00031CF1
			private static float CalcularCurrentPenetractionWeigth(ref float currentProfuncidad, bool ispenetrating, IPene pene, float minProfundidad, float maxProfundidad)
			{
				currentProfuncidad = 0f;
				if (!ispenetrating)
				{
					return 0f;
				}
				currentProfuncidad = pene.penetratingWorldLength;
				return Mathf.InverseLerp(minProfundidad, maxProfundidad, currentProfuncidad);
			}

			// Token: 0x06000B3F RID: 2879 RVA: 0x00033B18 File Offset: 0x00031D18
			private static void ActualizarEstancamiento(ref bool atascada, ref float tiempoEstancada, bool ispenetrated, float deltaTime, float currentVelocity, float velocidadParaEstancarse, float tiempoParaAtascarse)
			{
				if (!ispenetrated)
				{
					tiempoEstancada = 0f;
					atascada = false;
					return;
				}
				if (currentVelocity < velocidadParaEstancarse)
				{
					float num = 1f - currentVelocity / velocidadParaEstancarse;
					tiempoEstancada += deltaTime * num;
				}
				else
				{
					tiempoEstancada = 0f;
				}
				atascada = tiempoEstancada >= tiempoParaAtascarse;
				if (atascada)
				{
					tiempoEstancada = 0f;
				}
			}

			// Token: 0x06000B40 RID: 2880 RVA: 0x00033B6C File Offset: 0x00031D6C
			private static void ActualizarEstancamientoPorCollision(ref bool atascada, ref float tiempoEstancada, bool ispenetrated, float deltaTime, float tiempoParaAtascarse, bool collisionandoConHipsOrHand)
			{
				if (!ispenetrated)
				{
					tiempoEstancada = 0f;
					atascada = false;
					return;
				}
				if (collisionandoConHipsOrHand)
				{
					tiempoEstancada += deltaTime;
				}
				else
				{
					tiempoEstancada = 0f;
				}
				atascada = tiempoEstancada >= tiempoParaAtascarse;
				if (atascada)
				{
					tiempoEstancada = 0f;
				}
			}

			// Token: 0x06000B41 RID: 2881 RVA: 0x00033BA8 File Offset: 0x00031DA8
			private static void ActualizarSobrePasoDePlano(ref bool planoSobrePasado, IPene pene, float maxPeneProfundidad, IHole hole, bool debugDraw)
			{
				if (pene == null)
				{
					planoSobrePasado = false;
					return;
				}
				float num = pene.worldLength - maxPeneProfundidad;
				Vector3 rootDefaultForwardWorldDirection = pene.rootDefaultForwardWorldDirection;
				Vector3 vector = pene.root.position + rootDefaultForwardWorldDirection * num;
				planoSobrePasado = !Math3dTvalle.PuntoEstaDelanteDePlano(rootDefaultForwardWorldDirection, vector, hole.entrada.position);
			}

			// Token: 0x06000B42 RID: 2882 RVA: 0x00033C00 File Offset: 0x00031E00
			private static void CalcularVelocidadActual(ref Vector3 lastDirectionToHole, ref float currentVelocity, float deltaTime, bool primerUpdate, IHole hole, IPene pene)
			{
				currentVelocity = 0f;
				if (pene != null)
				{
					Vector3? vector = null;
					if (!primerUpdate)
					{
						Vector3 position = pene.root.position;
						Vector3 vector2 = position + lastDirectionToHole;
						Vector3 position2 = hole.entrada.position;
						vector = new Vector3?(position2 - position);
						currentVelocity = (vector2 - position2).magnitude / deltaTime;
					}
					lastDirectionToHole = ((vector != null) ? vector.Value : (hole.entrada.position - pene.root.position));
				}
			}

			// Token: 0x06000B43 RID: 2883 RVA: 0x00033CA4 File Offset: 0x00031EA4
			private static bool MuchoTiempoSinPenetracion(bool ispenetrated, float deltaTime, float maxTimepoSinPenetracion, ref float timeNotPenetrated)
			{
				if (!ispenetrated)
				{
					timeNotPenetrated += deltaTime;
				}
				else
				{
					timeNotPenetrated = 0f;
				}
				if (timeNotPenetrated > maxTimepoSinPenetracion)
				{
					timeNotPenetrated = 0f;
					return true;
				}
				return false;
			}

			// Token: 0x06000B44 RID: 2884 RVA: 0x00033CC8 File Offset: 0x00031EC8
			private static void CalcularRangoProfundiadSegunPene(ref float minPeneProfundidad, ref float maxPeneProfundidad, IPene pene, float minPeneMod, float maxPeneMod)
			{
				if (pene == null)
				{
					minPeneProfundidad = float.MinValue;
					maxPeneProfundidad = float.MaxValue;
					return;
				}
				float worldLength = pene.worldLength;
				minPeneProfundidad = worldLength * minPeneMod;
				maxPeneProfundidad = worldLength * maxPeneMod;
			}

			// Token: 0x06000B45 RID: 2885 RVA: 0x00033CFC File Offset: 0x00031EFC
			private static void CalcularRangoProfundiadSegunHole(ref float minHoleProfundidad, ref float maxHoleProfundidad, IHole hole, float scala, float minHoleMod, float maxHoleMod, float minHoleLocal)
			{
				if (hole == null)
				{
					minHoleProfundidad = float.MinValue;
					maxHoleProfundidad = float.MaxValue;
					return;
				}
				float num = hole.maxProfundidadPhysicsLocal * scala;
				minHoleProfundidad = Mathf.Clamp(num * minHoleMod, 0f, minHoleLocal * scala);
				maxHoleProfundidad = num * maxHoleMod;
			}

			// Token: 0x06000B46 RID: 2886 RVA: 0x00033D40 File Offset: 0x00031F40
			private static void CalcularRangoProfundiadSegunPersonalidad(ref float minProfundidad, ref float maxProfundidad, RangeValueV2 velLocalRange, float scala, IPene pene, IHole hole)
			{
				minProfundidad = velLocalRange.min * scala;
				maxProfundidad = velLocalRange.max * scala;
				float num;
				if (pene != null)
				{
					num = Mathf.Max(pene.worldLength, hole.maxProfundidadPhysicsLocal * scala);
				}
				else
				{
					num = hole.maxProfundidadPhysicsLocal * scala;
				}
				if (minProfundidad > num)
				{
					minProfundidad = num;
				}
				if (maxProfundidad > num)
				{
					maxProfundidad = num;
				}
			}

			// Token: 0x06000B47 RID: 2887 RVA: 0x00033D9C File Offset: 0x00031F9C
			private static void CalcularRangoProfundiad(ref float minProfundidad, ref float maxProfundidad, ControlladorDeAutoSexV2.Orden.CurrentRangos currentRangos, float scala, float weigth)
			{
				minProfundidad = Mathf.Max(currentRangos.minPersonalidadProfundidad, Mathf.Max(currentRangos.minHoleProfundidad, currentRangos.minPeneProfundidad));
				maxProfundidad = Mathf.Min(currentRangos.maxPersonalidadProfundidad, Mathf.Min(currentRangos.maxHoleProfundidad, currentRangos.maxPeneProfundidad));
				minProfundidad = Mathf.Lerp(maxProfundidad, minProfundidad, Mathf.Lerp(0.2f, 1f, weigth));
				if (minProfundidad > maxProfundidad)
				{
					minProfundidad = maxProfundidad;
				}
				float num = (maxProfundidad - minProfundidad) / scala;
				float num2 = (Mathf.Abs(maxProfundidad / scala) + Mathf.Abs(minProfundidad / scala)) / 2f;
				if (num < 0.015f)
				{
					minProfundidad = num2 * scala - 0.0075f * scala;
					maxProfundidad = num2 * scala + 0.0075f * scala;
				}
				if (num2 <= 0.015f)
				{
					minProfundidad = 0.015f * scala;
					maxProfundidad = 0.03f * scala;
					return;
				}
				if (num2 + 0.015f >= maxProfundidad / scala)
				{
					minProfundidad = maxProfundidad - 0.03f * scala;
					maxProfundidad -= 0.015f * scala;
				}
			}

			// Token: 0x04000766 RID: 1894
			public Func<ControlladorDeAutoSexV2.Orden, bool> puedeSeguirEnAutoSex;

			// Token: 0x04000767 RID: 1895
			public float weight;

			// Token: 0x04000768 RID: 1896
			public ParteQuePuedeEstimular estimulante;

			// Token: 0x04000769 RID: 1897
			public ParteDelCuerpoHumano estimulado;

			// Token: 0x0400076A RID: 1898
			public IHole hole;

			// Token: 0x0400076B RID: 1899
			[ReadOnlyUI]
			[SerializeField]
			private float m_currentWeight;

			// Token: 0x0400076C RID: 1900
			[ReadOnlyUI]
			[SerializeField]
			private ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento m_EstadoDeMovimiento;

			// Token: 0x0400076D RID: 1901
			[ReadOnlyUI]
			[SerializeField]
			private ControlladorDeAutoSexV2.Orden.EstadoDeProfunidad m_EstadoDeProfunidad;

			// Token: 0x0400076E RID: 1902
			[ReadOnlyUI]
			[SerializeField]
			private ControlladorDeAutoSexV2.Orden.CurrentRangos m_CurrentRangos = new ControlladorDeAutoSexV2.Orden.CurrentRangos();

			// Token: 0x0400076F RID: 1903
			[ReadOnlyUI]
			[SerializeField]
			private RangeValueV2 m_velLocalRangeCurrent;

			// Token: 0x04000770 RID: 1904
			[ReadOnlyUI]
			[SerializeField]
			private RangeValueV2 m_velLocalRangeSmoothed;

			// Token: 0x04000771 RID: 1905
			[ReadOnlyUI]
			[SerializeField]
			private RangeValueV2 m_proLocalRange;

			// Token: 0x04000772 RID: 1906
			[SerializeField]
			[ReadOnlyUI]
			private float m_timeNotPenetrated;

			// Token: 0x04000773 RID: 1907
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentVelocityReal;

			// Token: 0x04000774 RID: 1908
			[SerializeField]
			[ReadOnlyUI]
			private float m_nextFrameProfundidad;

			// Token: 0x04000775 RID: 1909
			[SerializeField]
			[ReadOnlyUI]
			private float m_tiempoEstancada;

			// Token: 0x04000776 RID: 1910
			[SerializeField]
			[ReadOnlyUI]
			private float m_tiempoEstancadaPorCollision;

			// Token: 0x04000777 RID: 1911
			[SerializeField]
			[ReadOnlyUI]
			private bool m_collisionandoContraHipsOrHands;

			// Token: 0x04000778 RID: 1912
			[SerializeField]
			[ReadOnlyUI]
			private bool m_seAtasco;

			// Token: 0x04000779 RID: 1913
			[SerializeField]
			[ReadOnlyUI]
			private bool m_seAtascoPorCollision;

			// Token: 0x0400077A RID: 1914
			[SerializeField]
			[ReadOnlyUI]
			private bool m_planoSobrePasado;

			// Token: 0x0400077B RID: 1915
			[SerializeField]
			[ReadOnlyUI]
			private float m_minProfundidad;

			// Token: 0x0400077C RID: 1916
			[SerializeField]
			[ReadOnlyUI]
			private float m_maxProfundidad;

			// Token: 0x0400077D RID: 1917
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentProfundidad;

			// Token: 0x0400077E RID: 1918
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentPenetrationWeigth;

			// Token: 0x0400077F RID: 1919
			[SerializeField]
			[ReadOnlyUI]
			private Vector3 m_effectorMaxPosition;

			// Token: 0x04000780 RID: 1920
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentVelocidadPorPersonalidad;

			// Token: 0x04000781 RID: 1921
			[SerializeField]
			[ReadOnlyUI]
			private Vector3 m_currentEffectorPosition;

			// Token: 0x04000782 RID: 1922
			[SerializeField]
			[ReadOnlyUI]
			private float m_modDeVelocidadPorDefectos;

			// Token: 0x04000783 RID: 1923
			[SerializeField]
			[ReadOnlyUI]
			private float m_modDeVelocidadPorRangosPequenos;

			// Token: 0x04000784 RID: 1924
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentModDeVelocidadPorDefectos;

			// Token: 0x04000785 RID: 1925
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentModDeVelocidadPorRangosPequenos;

			// Token: 0x04000786 RID: 1926
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentMaxLocalVelocity;

			// Token: 0x04000787 RID: 1927
			private ControlladorDeAutoSexV2.ModificadoresDePuppet m_pinMods;

			// Token: 0x04000788 RID: 1928
			private ControlladorDeAutoSexV2.ModificadoresDePuppet m_springMods;

			// Token: 0x04000789 RID: 1929
			private Vector3 m_lastDirectionToHole;

			// Token: 0x0400078A RID: 1930
			private CoolDown coolDownDeActualizarPorPersonalidad = new CoolDown(0.25f);

			// Token: 0x0400078B RID: 1931
			private ControlladorDeAutoSexV2.Orden.EstadoDeMovimiento m_LastEstadoDeMovimiento;

			// Token: 0x0400078C RID: 1932
			private int m_framesEnElEstadoActual;

			// Token: 0x0400078D RID: 1933
			private float m_tiempoEnElEstadoActual;

			// Token: 0x0400078E RID: 1934
			private Func<Vector3> MainBonePositionGetter;

			// Token: 0x0400078F RID: 1935
			private Func<Vector3> MainBoneOffsetToHoleGetter;

			// Token: 0x04000790 RID: 1936
			private Func<Vector3> HolePlaneNormalGetter;

			// Token: 0x04000791 RID: 1937
			private Func<Vector3> HolePlanePointGetter;

			// Token: 0x04000792 RID: 1938
			private ControlladorDeAutoSexV2.Orden.MoveEffectorTowards MoveEffectorTowardsL;

			// Token: 0x04000793 RID: 1939
			private ControlladorDeAutoSexV2.Orden.MoveEffectorTowards MoveEffectorTowardsR;

			// Token: 0x04000794 RID: 1940
			private ControlladorDeAutoSexV2.Orden.MoveWeightTowards MoveWeightTowardsL;

			// Token: 0x04000795 RID: 1941
			private ControlladorDeAutoSexV2.Orden.MoveWeightTowards MoveWeightTowardsR;

			// Token: 0x04000796 RID: 1942
			private Action<Vector3> SetEffectorOffSetL;

			// Token: 0x04000797 RID: 1943
			private Action<Vector3> SetEffectorOffSetR;

			// Token: 0x04000798 RID: 1944
			private Func<Vector3> Get_CURRENT_EffectorOffSetL;

			// Token: 0x04000799 RID: 1945
			private Func<Vector3> Get_CURRENT_EffectorOffSetR;

			// Token: 0x0400079A RID: 1946
			private Func<float> GetEffectorOffSetWeightL;

			// Token: 0x0400079B RID: 1947
			private Func<float> GetEffectorOffSetWeightR;

			// Token: 0x0400079C RID: 1948
			public Muscle muscle;

			// Token: 0x0400079D RID: 1949
			public IHistorialColisionesEventos muscleCollisionEventos;

			// Token: 0x0400079E RID: 1950
			public bool usarJoint = true;

			// Token: 0x0400079F RID: 1951
			[ReadOnlyUI]
			[SerializeField]
			private ConfigurableJoint m_MuscleToAnimJoint;

			// Token: 0x040007A0 RID: 1952
			[ReadOnlyUI]
			[SerializeField]
			private bool m_terminando;

			// Token: 0x040007A1 RID: 1953
			[SerializeField]
			private float m_JointForce = 750000f;

			// Token: 0x040007A2 RID: 1954
			[SerializeField]
			private float m_JointAngularForce = 15000f;

			// Token: 0x040007A3 RID: 1955
			private float m_currentForceVelocity;

			// Token: 0x040007A4 RID: 1956
			private float m_currentAngularForceVelocity;

			// Token: 0x040007A5 RID: 1957
			[SerializeField]
			[ReadOnlyUI]
			private ModificadorDeFloat m_demandaDeOxigeno;

			// Token: 0x040007A6 RID: 1958
			[SerializeField]
			[ReadOnlyUI]
			private float m_velocidadModSegunSaturacionDeOxigeno;

			// Token: 0x040007A7 RID: 1959
			[SerializeField]
			[ReadOnlyUI]
			private float m_currentMaxVelocidadLocalSinThresholdCurvas;

			// Token: 0x020001D9 RID: 473
			// (Invoke) Token: 0x06000D43 RID: 3395
			private delegate Vector3 MoveEffectorTowards(Vector3 target, float maxDistanceDelta);

			// Token: 0x020001DA RID: 474
			// (Invoke) Token: 0x06000D47 RID: 3399
			private delegate float MoveWeightTowards(float target, float maxDelta);

			// Token: 0x020001DB RID: 475
			[Serializable]
			public class CurrentRangos
			{
				// Token: 0x04000A15 RID: 2581
				public float minPeneProfundidad;

				// Token: 0x04000A16 RID: 2582
				public float maxPeneProfundidad;

				// Token: 0x04000A17 RID: 2583
				public float minHoleProfundidad;

				// Token: 0x04000A18 RID: 2584
				public float maxHoleProfundidad;

				// Token: 0x04000A19 RID: 2585
				public float minPersonalidadProfundidad;

				// Token: 0x04000A1A RID: 2586
				public float maxPersonalidadProfundidad;
			}

			// Token: 0x020001DC RID: 476
			public enum EstadoDeProfunidad
			{
				// Token: 0x04000A1C RID: 2588
				intermedio,
				// Token: 0x04000A1D RID: 2589
				enMax,
				// Token: 0x04000A1E RID: 2590
				enMin
			}

			// Token: 0x020001DD RID: 477
			public enum EstadoDeMovimiento
			{
				// Token: 0x04000A20 RID: 2592
				entrado,
				// Token: 0x04000A21 RID: 2593
				saliendo
			}
		}

		// Token: 0x02000142 RID: 322
		public sealed class Colas : ControllerColaDePrioridadBase<ControlladorDeAutoSexV2.Stado, ControlladorDeAutoSexV2.Orden, ControlladorDeAutoSexV2.Colas, ControlladorDeAutoSexV2, int>.ColasBase
		{
		}

		// Token: 0x02000143 RID: 323
		public sealed class Stado : ControllerColaDePrioridadBase<ControlladorDeAutoSexV2.Stado, ControlladorDeAutoSexV2.Orden, ControlladorDeAutoSexV2.Colas, ControlladorDeAutoSexV2, int>.StadoBase
		{
		}

		// Token: 0x02000144 RID: 324
		public abstract class ModificadoresDePuppet
		{
			// Token: 0x06000B4A RID: 2890 RVA: 0x00033EA0 File Offset: 0x000320A0
			public void Init(PuppetMusclePropMods mods, PuppetMaster puppet, ControlladorDeAutoSexV2 controller)
			{
				PuppetMusclePropMods.PropModificables propModificables = mods.Obtener(puppet.GetMuscle(HumanBodyBones.Head));
				PuppetMusclePropMods.PropModificables propModificables2 = mods.Obtener(puppet.GetMuscle(HumanBodyBones.Neck));
				PuppetMusclePropMods.PropModificables propModificables3 = mods.Obtener(puppet.GetMuscle(HumanBodyBones.Chest));
				PuppetMusclePropMods.PropModificables propModificables4 = mods.Obtener(puppet.GetMuscle(HumanBodyBones.Spine));
				PuppetMusclePropMods.PropModificables propModificables5 = mods.Obtener(puppet.GetMuscle(HumanBodyBones.Hips));
				PuppetMusclePropMods.PropModificables propModificables6 = mods.Obtener(puppet.GetMuscle(HumanBodyBones.LeftUpperLeg));
				PuppetMusclePropMods.PropModificables propModificables7 = mods.Obtener(puppet.GetMuscle(HumanBodyBones.RightUpperLeg));
				ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo tipo = this.tipo;
				if (tipo == ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo.minPin)
				{
					this.head = propModificables.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					this.neck = propModificables2.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					this.chest = propModificables3.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					this.spine = propModificables4.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					this.hips = propModificables5.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					this.thigsL = propModificables6.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					this.thigsR = propModificables7.valoresMinimos.pinWeight.ObtenerModificadorNotNull(controller);
					return;
				}
				if (tipo != ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo.minSpring)
				{
					throw new ArgumentOutOfRangeException(this.tipo.ToString());
				}
				this.head = propModificables.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
				this.neck = propModificables2.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
				this.chest = propModificables3.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
				this.spine = propModificables4.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
				this.hips = propModificables5.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
				this.thigsL = propModificables6.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
				this.thigsR = propModificables7.valoresMinimos.muscleWeight.ObtenerModificadorNotNull(controller);
			}

			// Token: 0x1700022F RID: 559
			// (get) Token: 0x06000B4B RID: 2891
			public abstract ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo tipo { get; }

			// Token: 0x06000B4C RID: 2892 RVA: 0x00034094 File Offset: 0x00032294
			public bool AtZeroAll()
			{
				return this.head.valor.valor == 0f && this.neck.valor.valor == 0f && this.chest.valor.valor == 0f && this.spine.valor.valor == 0f && this.hips.valor.valor == 0f && this.thigsL.valor.valor == 0f && this.thigsR.valor.valor == 0f;
			}

			// Token: 0x06000B4D RID: 2893
			public abstract void MoveTo(float target, float maxDelta);

			// Token: 0x06000B4E RID: 2894
			public abstract bool AtZero();

			// Token: 0x06000B4F RID: 2895 RVA: 0x00034148 File Offset: 0x00032348
			public void SetAllToZero()
			{
				this.head.valor.valor = (this.neck.valor.valor = (this.chest.valor.valor = (this.spine.valor.valor = (this.hips.valor.valor = (this.thigsL.valor.valor = (this.thigsR.valor.valor = 0f))))));
			}

			// Token: 0x06000B50 RID: 2896 RVA: 0x000341DC File Offset: 0x000323DC
			public void SetAllToMax()
			{
				this.head.valor.valor = (this.neck.valor.valor = (this.chest.valor.valor = (this.spine.valor.valor = (this.hips.valor.valor = (this.thigsL.valor.valor = (this.thigsR.valor.valor = float.MaxValue))))));
			}

			// Token: 0x06000B51 RID: 2897 RVA: 0x00034270 File Offset: 0x00032470
			public void Destroy()
			{
				ModificadorDeFloat modificadorDeFloat = this.head;
				if (modificadorDeFloat != null)
				{
					modificadorDeFloat.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat2 = this.neck;
				if (modificadorDeFloat2 != null)
				{
					modificadorDeFloat2.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat3 = this.chest;
				if (modificadorDeFloat3 != null)
				{
					modificadorDeFloat3.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat4 = this.spine;
				if (modificadorDeFloat4 != null)
				{
					modificadorDeFloat4.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat5 = this.hips;
				if (modificadorDeFloat5 != null)
				{
					modificadorDeFloat5.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat6 = this.thigsL;
				if (modificadorDeFloat6 != null)
				{
					modificadorDeFloat6.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat7 = this.thigsR;
				if (modificadorDeFloat7 == null)
				{
					return;
				}
				modificadorDeFloat7.TryRemoverDeOwner(true);
			}

			// Token: 0x040007A8 RID: 1960
			public ModificadorDeFloat head;

			// Token: 0x040007A9 RID: 1961
			public ModificadorDeFloat neck;

			// Token: 0x040007AA RID: 1962
			public ModificadorDeFloat chest;

			// Token: 0x040007AB RID: 1963
			public ModificadorDeFloat spine;

			// Token: 0x040007AC RID: 1964
			public ModificadorDeFloat hips;

			// Token: 0x040007AD RID: 1965
			public ModificadorDeFloat thigsL;

			// Token: 0x040007AE RID: 1966
			public ModificadorDeFloat thigsR;

			// Token: 0x020001DF RID: 479
			public enum Tipo
			{
				// Token: 0x04000A24 RID: 2596
				minPin,
				// Token: 0x04000A25 RID: 2597
				minSpring
			}
		}

		// Token: 0x02000145 RID: 325
		[Serializable]
		public class HeadMinPinsDePuppet : ControlladorDeAutoSexV2.ModificadoresDePuppet
		{
			// Token: 0x17000230 RID: 560
			// (get) Token: 0x06000B53 RID: 2899 RVA: 0x00034309 File Offset: 0x00032509
			public override ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo tipo
			{
				get
				{
					return ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo.minPin;
				}
			}

			// Token: 0x06000B54 RID: 2900 RVA: 0x0003430C File Offset: 0x0003250C
			public override void MoveTo(float target, float maxDelta)
			{
				this.head.valor.valor = Mathf.MoveTowards(this.head.valor.valor, target, maxDelta);
			}

			// Token: 0x06000B55 RID: 2901 RVA: 0x00034335 File Offset: 0x00032535
			public override bool AtZero()
			{
				return this.head.valor.valor == 0f;
			}
		}

		// Token: 0x02000146 RID: 326
		[Serializable]
		public class HeadMinSpringDePuppet : ControlladorDeAutoSexV2.ModificadoresDePuppet
		{
			// Token: 0x17000231 RID: 561
			// (get) Token: 0x06000B57 RID: 2903 RVA: 0x00034356 File Offset: 0x00032556
			public override ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo tipo
			{
				get
				{
					return ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo.minSpring;
				}
			}

			// Token: 0x06000B58 RID: 2904 RVA: 0x0003435C File Offset: 0x0003255C
			public override void MoveTo(float target, float maxDelta)
			{
				this.chest.valor.valor = Mathf.MoveTowards(this.chest.valor.valor, target, maxDelta);
				this.spine.valor.valor = Mathf.MoveTowards(this.spine.valor.valor, target, maxDelta);
			}

			// Token: 0x06000B59 RID: 2905 RVA: 0x000343B7 File Offset: 0x000325B7
			public override bool AtZero()
			{
				return this.chest.valor.valor == 0f && this.spine.valor.valor == 0f;
			}
		}

		// Token: 0x02000147 RID: 327
		[Serializable]
		public class HipsMinPinsDePuppet : ControlladorDeAutoSexV2.ModificadoresDePuppet
		{
			// Token: 0x17000232 RID: 562
			// (get) Token: 0x06000B5B RID: 2907 RVA: 0x000343F1 File Offset: 0x000325F1
			public override ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo tipo
			{
				get
				{
					return ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo.minPin;
				}
			}

			// Token: 0x06000B5C RID: 2908 RVA: 0x000343F4 File Offset: 0x000325F4
			public override void MoveTo(float target, float maxDelta)
			{
				this.hips.valor.valor = Mathf.MoveTowards(this.hips.valor.valor, target, maxDelta);
			}

			// Token: 0x06000B5D RID: 2909 RVA: 0x0003441D File Offset: 0x0003261D
			public override bool AtZero()
			{
				return this.hips.valor.valor == 0f;
			}
		}

		// Token: 0x02000148 RID: 328
		[Serializable]
		public class ThigsMinSpringDePuppet : ControlladorDeAutoSexV2.ModificadoresDePuppet
		{
			// Token: 0x17000233 RID: 563
			// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0003443E File Offset: 0x0003263E
			public override ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo tipo
			{
				get
				{
					return ControlladorDeAutoSexV2.ModificadoresDePuppet.Tipo.minSpring;
				}
			}

			// Token: 0x06000B60 RID: 2912 RVA: 0x00034444 File Offset: 0x00032644
			public override void MoveTo(float target, float maxDelta)
			{
				this.thigsL.valor.valor = Mathf.MoveTowards(this.thigsL.valor.valor, target, maxDelta);
				this.thigsR.valor.valor = Mathf.MoveTowards(this.thigsR.valor.valor, target, maxDelta);
			}

			// Token: 0x06000B61 RID: 2913 RVA: 0x0003449F File Offset: 0x0003269F
			public override bool AtZero()
			{
				return this.thigsL.valor.valor == 0f && this.thigsR.valor.valor == 0f;
			}
		}
	}
}
