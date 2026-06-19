using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex
{
	// Token: 0x02000045 RID: 69
	[Obsolete("usar version 2")]
	public class ControlladorDeAutoSexOral : ControllerColaDePrioridadBase<ControlladorDeAutoSexOral.Stado, ControlladorDeAutoSexOral.Orden, ControlladorDeAutoSexOral.Colas, ControlladorDeAutoSexOral, int>
	{
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000F623 File Offset: 0x0000D823
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterOralAt);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0000F62C File Offset: 0x0000D82C
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000F62F File Offset: 0x0000D82F
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000F632 File Offset: 0x0000D832
		public BoneStretchedChain bocaHole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000F63C File Offset: 0x0000D83C
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
			this.m_effector = this.m_char.bodyAnimator.transform.CreateChild("EffectorDe_" + base.GetType().Name).gameObject.AddComponent<WorldEffectorOffsetComplejo>();
			this.m_effector.Init(IKLayerFlag.primero, IKOrderFlag.primero, IKPassOrderFlag.ultimo);
			this.m_effector.modifying += this.M_effector_modifying;
			this.m_hole = this.m_char.GetComponentInChildren<BocaHole>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000F728 File Offset: 0x0000D928
		private void M_effector_modifying(TValleOffsetModifier obj)
		{
			this.m_chestPosition = this.m_char.bones.chest.transform.position;
			this.m_bocaEntradaPosition = this.m_char.bones.bocaEntrada.transform.position;
			this.m_chestForward = this.m_char.bones.chest.currentForward;
			this.m_OffsetChestBoca = this.m_hole.entrada.position - this.m_chestPosition;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000F7B1 File Offset: 0x0000D9B1
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_effector)
			{
				this.m_effector.modifying -= this.M_effector_modifying;
				Object.Destroy(this.m_effector.gameObject);
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000F7F0 File Offset: 0x0000D9F0
		public bool DoAutoSex(float weight, ParteQuePuedeEstimular parte, ControlladorDeAutoSexOral.GetRangeDeTolerancia toleranciaVelocidad, ControlladorDeAutoSexOral.GetRangeDeTolerancia toleranciaProfundidad, int prioridad, ControllerPrioridadConfig priConfig, float duracion)
		{
			if (!this.m_hole.isPenetrated)
			{
				throw new NotSupportedException();
			}
			bool flag = false;
			ControlladorDeAutoSexOral.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			ControlladorDeAutoSexOral.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, 0, out tipoDeReUsoDeOrden) && orden2.parte == parte)
			{
				orden2.weight = weight;
				base.AcumularseORevivir(orden2, duracion, prioridad, tipoDeReUsoDeOrden, null, null);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			ControlladorDeAutoSexOral.Orden orden3 = new ControlladorDeAutoSexOral.Orden(weight, parte, toleranciaVelocidad, toleranciaProfundidad, duracion, prioridad, priConfig);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000F88A File Offset: 0x0000DA8A
		protected override ControlladorDeAutoSexOral ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000F88D File Offset: 0x0000DA8D
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000F890 File Offset: 0x0000DA90
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x040001FA RID: 506
		[ReadOnlyUI]
		[SerializeField]
		private WorldEffectorOffsetComplejo m_effector;

		// Token: 0x040001FB RID: 507
		private BoneStretchedChain m_hole;

		// Token: 0x040001FC RID: 508
		private IAnimatorCharacter m_char;

		// Token: 0x040001FD RID: 509
		private ICharacterRespirador m_respirador;

		// Token: 0x040001FE RID: 510
		public bool debugDraw;

		// Token: 0x040001FF RID: 511
		public float rangeWeightVelThresholdToResetStateTime = 0.333f;

		// Token: 0x04000200 RID: 512
		public float maxTimeOnAState = 0.2f;

		// Token: 0x04000201 RID: 513
		public float maxTimeNonPenetrated = 3f;

		// Token: 0x04000202 RID: 514
		public ControlladorDeAutoSexOral.EffectorConfig effectorConfig = new ControlladorDeAutoSexOral.EffectorConfig();

		// Token: 0x04000203 RID: 515
		[Header("Rangos Por AI")]
		[Range(0f, 1f)]
		public float minProfundidadMinRange = 0.25f;

		// Token: 0x04000204 RID: 516
		[Range(0f, 1f)]
		public float minProfundidadMaxRange = 0.2f;

		// Token: 0x04000205 RID: 517
		[Range(0f, 1f)]
		public float maxProfundidadMinRange = 0.65f;

		// Token: 0x04000206 RID: 518
		[Range(0f, 1f)]
		public float maxProfundidadMaxRange = 0.725f;

		// Token: 0x04000207 RID: 519
		[Header("Rangos Por Holes/Pene")]
		[Range(0f, 1f)]
		public float minHoleProfundidad = 0.1f;

		// Token: 0x04000208 RID: 520
		[Range(0f, 1f)]
		public float maxHoleProfundidad = 0.9f;

		// Token: 0x04000209 RID: 521
		[Range(0f, 1f)]
		public float minPenisProfundidad = 0.1f;

		// Token: 0x0400020A RID: 522
		[Range(0f, 1f)]
		public float maxPenisProfundidad = 0.9f;

		// Token: 0x0400020B RID: 523
		[Header("Dif En Vel Por Ai Segun Oxigeno")]
		[Range(0f, 1f)]
		public float canzadaMinRange = 0.22f;

		// Token: 0x0400020C RID: 524
		[Range(0f, 1f)]
		public float canzadaMaxRange = 0.33f;

		// Token: 0x0400020D RID: 525
		[Range(0f, 1f)]
		public float descanzadaMinRange = 0.44f;

		// Token: 0x0400020E RID: 526
		[Range(0f, 1f)]
		public float descanzadaMaxRange = 0.75f;

		// Token: 0x0400020F RID: 527
		private Vector3 m_chestPosition;

		// Token: 0x04000210 RID: 528
		private Vector3 m_bocaEntradaPosition;

		// Token: 0x04000211 RID: 529
		private Vector3 m_chestForward;

		// Token: 0x04000212 RID: 530
		private Vector3 m_OffsetChestBoca;

		// Token: 0x0200013B RID: 315
		// (Invoke) Token: 0x06000B1B RID: 2843
		public delegate RangeValueV2 GetRangeDeTolerancia(ParteQuePuedeEstimular estimulante);

		// Token: 0x0200013C RID: 316
		[Serializable]
		public class EffectorConfig
		{
			// Token: 0x04000725 RID: 1829
			[Tooltip("false para usar direccion chesst forward")]
			public bool usarDirToPenisRoot = true;

			// Token: 0x04000726 RID: 1830
			public float maxVelocidadEffector = 0.2f;

			// Token: 0x04000727 RID: 1831
			public float entrandoMaxLocalMagnitudEffector = 0.2f;

			// Token: 0x04000728 RID: 1832
			public float saliendoMaxLocalMagnitudEffector = 0.4f;

			// Token: 0x04000729 RID: 1833
			public float minVelModPorLimites = 0.333f;

			// Token: 0x0400072A RID: 1834
			public float velModPorLimitesOutPower = 2f;

			// Token: 0x0400072B RID: 1835
			public float maxVelModPorInverseDot = 3f;

			// Token: 0x0400072C RID: 1836
			public float penisRootOffset = -0.2f;

			// Token: 0x0400072D RID: 1837
			public float penisLenghtOffset = -0.2f;

			// Token: 0x0400072E RID: 1838
			public float overridingPositionWieghtVelocity = 0.5f;
		}

		// Token: 0x0200013D RID: 317
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeAutoSexOral.Stado, ControlladorDeAutoSexOral.Orden, ControlladorDeAutoSexOral.Colas, ControlladorDeAutoSexOral, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000B1F RID: 2847 RVA: 0x0003103D File Offset: 0x0002F23D
			public Orden(float Weight, ParteQuePuedeEstimular Parte, ControlladorDeAutoSexOral.GetRangeDeTolerancia toleranciaVelocidad, ControlladorDeAutoSexOral.GetRangeDeTolerancia toleranciaProfundidad, float duracion, int prioridad, ControllerPrioridadConfig priConfig)
				: base(0, prioridad, duracion, priConfig, false)
			{
				this.parte = Parte;
				this.m_toleranciaVelocidad = toleranciaVelocidad;
				this.m_toleranciaProfundidad = toleranciaProfundidad;
				this.weight = Weight;
			}

			// Token: 0x06000B20 RID: 2848 RVA: 0x0003107C File Offset: 0x0002F27C
			protected override void OnStart(ControlladorDeAutoSexOral dataUpdate)
			{
				this.m_wasMaxDeep = false;
				this.m_wasWellPenetrated = true;
				this.m_PenisOffsetSaliendo = dataUpdate.effectorConfig.penisLenghtOffset;
				this.m_PenisOffsetEntrando = dataUpdate.effectorConfig.penisRootOffset;
				dataUpdate.m_effector.leftShoulderOverridenWeight = (dataUpdate.m_effector.rightShoulderOverridenWeight = 0f);
				float worldScale = dataUpdate.m_hole.worldScale;
				HolePointsDataCollector component = dataUpdate.m_hole.GetComponent<HolePointsDataCollector>();
				this.m_worldPolarizedCurrentVelocity = (this.m_worldCurrentVelocity = ((component != null) ? new float?(component.stepData.localHoleDeepVelocity) : null).GetValueOrDefault() * worldScale);
				this.m_worldLastDeep = dataUpdate.m_hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals * worldScale;
				this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado;
				dataUpdate.m_effector.velocity = ((this.parte == ParteQuePuedeEstimular.dedo) ? (dataUpdate.effectorConfig.maxVelocidadEffector * 0.333f) : dataUpdate.effectorConfig.maxVelocidadEffector);
			}

			// Token: 0x06000B21 RID: 2849 RVA: 0x00031180 File Offset: 0x0002F380
			protected override bool UpdateOrden(ControlladorDeAutoSexOral dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				bool isPenetrated = dataUpdate.m_hole.isPenetrated;
				if (!isPenetrated && esPrimerUpdate)
				{
					return false;
				}
				if (dataUpdate.m_respirador.canzado)
				{
					this.canzada = true;
				}
				if (this.canzada && dataUpdate.m_respirador.descanzado)
				{
					this.canzada = false;
				}
				if (!isPenetrated)
				{
					this.m_timeNotPenetrated += base.estadoDeltaTime;
				}
				else
				{
					this.m_timeNotPenetrated = 0f;
				}
				if (this.m_timeNotPenetrated > dataUpdate.maxTimeNonPenetrated)
				{
					this.m_timeNotPenetrated = 0f;
					return false;
				}
				bool flag2;
				try
				{
					IPene pene;
					if (isPenetrated)
					{
						pene = dataUpdate.m_hole.penetraciones.currentHits.primero.penis;
					}
					else
					{
						pene = null;
					}
					float worldScale = dataUpdate.m_hole.worldScale;
					if (!esPrimerUpdate)
					{
						float num = dataUpdate.m_hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals * worldScale;
						this.m_worldPolarizedCurrentVelocity = (num - this.m_worldLastDeep) / base.estadoDeltaTime;
						this.m_worldCurrentVelocity = Mathf.Abs(this.m_worldPolarizedCurrentVelocity);
						float num2 = MathfExtension.InverseLerpUnclamped(this.m_minWorldPenetration, this.m_maxWorldPenetration, this.m_worldLastDeep);
						float num3 = MathfExtension.InverseLerpUnclamped(this.m_minWorldPenetration, this.m_maxWorldPenetration, num);
						this.m_rangeWeightVelocity = Mathf.Abs(num3 - num2) / base.estadoDeltaTime;
						if (this.m_rangeWeightVelocity >= dataUpdate.rangeWeightVelThresholdToResetStateTime)
						{
							this.m_tiempoEnCurrentEstado = 0f;
						}
						else
						{
							this.m_tiempoEnCurrentEstado += base.estadoDeltaTime;
						}
						this.m_worldLastDeep = num;
					}
					if (isPenetrated && (esPrimerUpdate || !this.coolDown.isOn))
					{
						this.velRange = this.m_toleranciaVelocidad(this.parte);
						this.proRange = this.m_toleranciaProfundidad(this.parte);
						this.coolDown.Apply();
						if (Mathf.Abs(this.proRange.min - this.proRange.max) < 0.005f)
						{
							return false;
						}
					}
					if (this.canzada)
					{
						this.m_worldTargetVelocity = Mathf.Lerp(this.velRange.min, this.velRange.max, Mathf.Lerp(dataUpdate.canzadaMinRange, dataUpdate.canzadaMaxRange, this.weight)) * worldScale;
					}
					else
					{
						this.m_worldTargetVelocity = Mathf.Lerp(this.velRange.min, this.velRange.max, Mathf.Lerp(dataUpdate.descanzadaMinRange, dataUpdate.descanzadaMaxRange, this.weight)) * worldScale;
					}
					this.m_minWorldPenetration = Mathf.Lerp(this.proRange.min, this.proRange.max, Mathf.Lerp(dataUpdate.minProfundidadMinRange, dataUpdate.minProfundidadMaxRange, this.weight));
					this.m_maxWorldPenetration = Mathf.Lerp(this.proRange.min, this.proRange.max, Mathf.Lerp(dataUpdate.maxProfundidadMinRange, dataUpdate.maxProfundidadMaxRange, this.weight));
					float num4 = ((pene != null) ? pene.worldLength : 10f) / worldScale;
					this.m_maxWorldPenetration = Mathf.Clamp(this.m_maxWorldPenetration, this.m_minWorldPenetration, num4);
					this.m_maxWorldPenetration = Mathf.Clamp(this.m_maxWorldPenetration * worldScale, 0.002f * worldScale, float.MaxValue);
					this.m_minWorldPenetration = Mathf.Clamp(this.m_minWorldPenetration * worldScale, 0.001f * worldScale, this.m_maxWorldPenetration);
					ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad estadoDeProfunidad = this.m_EstadoDeProfunidad;
					this.UpdateEstadoDeProfunidad(dataUpdate, worldScale, this.m_minWorldPenetration, this.m_maxWorldPenetration, pene);
					bool flag = estadoDeProfunidad != this.m_EstadoDeProfunidad;
					this.UpdateShoulders(dataUpdate, worldScale, pene, this.m_worldTargetVelocity, this.m_worldCurrentVelocity, flag);
					bool debugDraw = dataUpdate.debugDraw;
					flag2 = true;
				}
				catch (Exception ex)
				{
					Debug.LogException(ex, dataUpdate);
					flag2 = false;
				}
				return flag2;
			}

			// Token: 0x06000B22 RID: 2850 RVA: 0x00031550 File Offset: 0x0002F750
			private void UpdateEstadoDeProfunidad(ControlladorDeAutoSexOral dataUpdate, float charScale, float minWorldPenetration, float maxWorldPenetration, IPene pene)
			{
				bool flag = pene != null;
				float profundidadInternalsLocalActual = dataUpdate.m_hole.profundidadInternalsLocalActual;
				bool flag2 = profundidadInternalsLocalActual >= this.proRange.max;
				float num = this.m_worldPolarizedCurrentVelocity * base.estadoDeltaTime;
				float num2 = (flag ? pene.penetratingLengthMod : 0f);
				float profundidadVirtualUnClampWeigth = dataUpdate.m_hole.profundidadVirtualUnClampWeigth;
				bool flag3 = flag && profundidadInternalsLocalActual >= 0.005f;
				float num3 = dataUpdate.m_hole.maxProfundidadVirtualLocal * charScale;
				float num4 = this.m_worldLastDeep + num;
				flag2 = flag2 || num4 >= maxWorldPenetration;
				bool flag4 = false;
				bool flag5 = false;
				if (this.m_wasWellPenetrated != flag3)
				{
					if (!flag3)
					{
						this.m_PenisOffsetSaliendo -= 0.05f;
					}
					this.m_wasWellPenetrated = flag3;
				}
				if (this.m_wasMaxDeep != flag2)
				{
					if (flag2)
					{
						this.m_PenisOffsetEntrando -= 0.0075f;
						this.m_PenisOffsetSaliendo += 0.0075f;
					}
					this.m_wasMaxDeep = flag2;
				}
				this.m_velocidadModShouldersPorCercaLimites = 1f;
				if (flag)
				{
					if (this.m_tiempoEnCurrentEstado > dataUpdate.maxTimeOnAState)
					{
						if (this.m_EstadoDeProfunidad == ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado)
						{
							this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo;
							if (!flag2)
							{
								this.m_PenisOffsetEntrando += 0.1f;
							}
						}
						else if (this.m_EstadoDeProfunidad == ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo)
						{
							this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado;
							this.m_PenisOffsetSaliendo += 0.05f;
						}
						this.m_tiempoEnCurrentEstado = 0f;
					}
					else if (num4 >= maxWorldPenetration)
					{
						this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo;
					}
					else if (num4 <= minWorldPenetration)
					{
						this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado;
					}
					else if (profundidadVirtualUnClampWeigth >= dataUpdate.maxHoleProfundidad)
					{
						flag5 = true;
						this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo;
					}
					else if (profundidadVirtualUnClampWeigth <= dataUpdate.minHoleProfundidad)
					{
						flag5 = true;
						this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado;
					}
					else if (num2 >= dataUpdate.maxPenisProfundidad)
					{
						flag4 = true;
						this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo;
					}
					else if (num2 <= dataUpdate.minPenisProfundidad)
					{
						flag4 = true;
						this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado;
					}
				}
				else
				{
					this.m_EstadoDeProfunidad = ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado;
				}
				this.m_velocidadModShouldersPorCercaLimites = Mathf.Min(this.m_velocidadModShouldersPorCercaLimites, ControlladorDeAutoSexOral.Orden.CalculeVelModPorLimites(dataUpdate, this.m_EstadoDeProfunidad, minWorldPenetration, maxWorldPenetration, num4, dataUpdate.effectorConfig.velModPorLimitesOutPower, dataUpdate.effectorConfig.minVelModPorLimites));
				if (flag)
				{
					float worldLength = pene.worldLength;
					bool flag6 = num3 <= worldLength;
					if (flag6 || flag5)
					{
						this.m_velocidadModShouldersPorCercaLimites = Mathf.Min(this.m_velocidadModShouldersPorCercaLimites, ControlladorDeAutoSexOral.Orden.CalculeVelModPorLimites(dataUpdate, this.m_EstadoDeProfunidad, dataUpdate.minHoleProfundidad, dataUpdate.maxHoleProfundidad, profundidadVirtualUnClampWeigth, dataUpdate.effectorConfig.velModPorLimitesOutPower, dataUpdate.effectorConfig.minVelModPorLimites));
					}
					if (!flag6 || flag4)
					{
						this.m_velocidadModShouldersPorCercaLimites = Mathf.Min(this.m_velocidadModShouldersPorCercaLimites, ControlladorDeAutoSexOral.Orden.CalculeVelModPorLimites(dataUpdate, this.m_EstadoDeProfunidad, dataUpdate.minPenisProfundidad, dataUpdate.maxPenisProfundidad, num2, dataUpdate.effectorConfig.velModPorLimitesOutPower, dataUpdate.effectorConfig.minVelModPorLimites));
					}
				}
			}

			// Token: 0x06000B23 RID: 2851 RVA: 0x0003181C File Offset: 0x0002FA1C
			private static float CalculeVelModPorLimites(ControlladorDeAutoSexOral dataUpdate, ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad estadoDeProfunidad, float minLimite, float maxLimite, float currentValue, float outPower, float minMod)
			{
				float num = MathfExtension.InverseLerpAlMedio(minLimite, (minLimite + maxLimite) / 2f, maxLimite, currentValue);
				num = num.OutPow(outPower);
				return Mathf.Lerp(minMod, 1f, num);
			}

			// Token: 0x06000B24 RID: 2852 RVA: 0x00031854 File Offset: 0x0002FA54
			private static float CalculeVelModPorLimitesV2(ControlladorDeAutoSexOral dataUpdate, ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad estadoDeProfunidad, float minLimite, float maxLimite, float currentValue, float outPower, float minMod)
			{
				switch (estadoDeProfunidad)
				{
				case ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.inMovil:
					return 1f;
				case ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado:
					return ControlladorDeAutoSexOral.Orden.CalculeVelModPorLimitesV2(dataUpdate, maxLimite, minLimite, currentValue, outPower, minMod);
				case ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo:
					return ControlladorDeAutoSexOral.Orden.CalculeVelModPorLimitesV2(dataUpdate, minLimite, maxLimite, currentValue, outPower, minMod);
				default:
					throw new ArgumentOutOfRangeException(estadoDeProfunidad.ToString());
				}
			}

			// Token: 0x06000B25 RID: 2853 RVA: 0x000318AC File Offset: 0x0002FAAC
			private static float CalculeVelModPorLimitesV2(ControlladorDeAutoSexOral dataUpdate, float minLimite, float maxLimite, float currentValue, float outPower, float minMod)
			{
				float num = Mathf.InverseLerp(minLimite, maxLimite, currentValue);
				num = num.OutPow(outPower);
				return Mathf.Lerp(minMod, 1f, num);
			}

			// Token: 0x06000B26 RID: 2854 RVA: 0x000318DC File Offset: 0x0002FADC
			private void UpdateShoulders(ControlladorDeAutoSexOral dataUpdate, float scala, IPene pene, float worldTargetVelocityShoulder, float worldCurrentVelocityShoulder, bool estadoCambio)
			{
				float num;
				Vector3 vector2;
				if (pene != null)
				{
					Vector3 chestPosition = dataUpdate.m_chestPosition;
					Vector3 chestForward = dataUpdate.m_chestForward;
					Vector3 vector;
					if (!dataUpdate.effectorConfig.usarDirToPenisRoot)
					{
						vector = dataUpdate.m_chestForward;
					}
					else
					{
						vector = pene.root.position - chestPosition;
					}
					Vector3 offsetChestBoca = dataUpdate.m_OffsetChestBoca;
					if (this.m_EstadoDeProfunidad == ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.inMovil)
					{
						num = 0f;
						vector2 = dataUpdate.m_effector.currentLeftShoulderOffset;
					}
					else
					{
						Vector3 rootDefaultForwardWorldDirection = pene.rootDefaultForwardWorldDirection;
						Vector3 centerOfMassForwardDirection = pene.GetRootOwner().centerOfMassForwardDirection;
						float num2 = Vector3.Angle(-chestForward, centerOfMassForwardDirection);
						float num3 = Mathf.InverseLerp(60f, 0f, num2).OutPow(4f);
						Vector3 normalized = (-vector + rootDefaultForwardWorldDirection).normalized;
						Vector3 vector3 = Quaternion.Lerp(Quaternion.LookRotation((dataUpdate.m_bocaEntradaPosition - pene.root.position).normalized), Quaternion.LookRotation(normalized), num3) * Vector3.forward;
						bool debugDraw = dataUpdate.debugDraw;
						float num4 = pene.worldLengthFromUnderSkin - pene.worldLength;
						float num6;
						Vector3 vector4;
						switch (this.m_EstadoDeProfunidad)
						{
						case ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.entrado:
						{
							float num5 = pene.worldLength * this.m_PenisOffsetEntrando;
							num6 = dataUpdate.effectorConfig.entrandoMaxLocalMagnitudEffector + num5;
							num = 1f;
							vector4 = pene.root.position + -vector3 * (num5 - num4);
							if (dataUpdate.debugDraw)
							{
								goto IL_020D;
							}
							goto IL_020D;
						}
						case ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad.saliendo:
						{
							float num7 = pene.worldLength * (1f + this.m_PenisOffsetSaliendo);
							num6 = dataUpdate.effectorConfig.saliendoMaxLocalMagnitudEffector + (num7 - pene.worldLength);
							num7 += num4 * (1f + this.m_PenisOffsetSaliendo);
							num = -1f;
							vector4 = pene.root.position + vector3 * num7;
							if (dataUpdate.debugDraw)
							{
								goto IL_020D;
							}
							goto IL_020D;
						}
						}
						throw new ArgumentOutOfRangeException(this.m_EstadoDeProfunidad.ToString());
						IL_020D:
						vector4 -= offsetChestBoca;
						bool debugDraw2 = dataUpdate.debugDraw;
						vector2 = vector4 - chestPosition;
						vector2 = vector2.ClampMagnitud(0f, num6 * scala);
					}
				}
				else
				{
					vector2 = Vector3.zero;
					num = 0f;
				}
				float num8 = 1f;
				if (this.m_rangeWeightVelocity < dataUpdate.rangeWeightVelThresholdToResetStateTime * 0.5f || num * this.m_worldPolarizedCurrentVelocity < 0f)
				{
					num8 = dataUpdate.effectorConfig.maxVelModPorInverseDot;
				}
				this.m_velocidadModShouldersPorInvertedDot = Mathf.MoveTowards(this.m_velocidadModShouldersPorInvertedDot, num8, base.estadoDeltaTime * dataUpdate.effectorConfig.maxVelModPorInverseDot * 5f);
				dataUpdate.m_effector.leftShoulderOverridenWeight = (dataUpdate.m_effector.rightShoulderOverridenWeight = Mathf.MoveTowards(dataUpdate.m_effector.leftShoulderOverridenWeight, 1f, base.estadoDeltaTime * dataUpdate.effectorConfig.overridingPositionWieghtVelocity));
				this.m_velocidadModShoulders = Mathf.Clamp(this.m_velocidadModShouldersPorInvertedDot * this.m_velocidadModShouldersPorCercaLimites, 0.0001f, float.MaxValue);
				dataUpdate.m_effector.velocity = ((this.parte == ParteQuePuedeEstimular.dedo) ? (dataUpdate.effectorConfig.maxVelocidadEffector * 0.333f) : dataUpdate.effectorConfig.maxVelocidadEffector);
				dataUpdate.m_effector.leftShoulderOffset = (dataUpdate.m_effector.rightShoulderOffset = Vector3.MoveTowards(dataUpdate.m_effector.leftShoulderOffset, vector2, worldTargetVelocityShoulder * base.estadoDeltaTime * this.m_velocidadModShoulders));
			}

			// Token: 0x06000B27 RID: 2855 RVA: 0x00031C67 File Offset: 0x0002FE67
			private void UpdateNeck()
			{
			}

			// Token: 0x06000B28 RID: 2856 RVA: 0x00031C69 File Offset: 0x0002FE69
			protected override void OnDetenidaPorUsuario(ControlladorDeAutoSexOral dataUpdate)
			{
			}

			// Token: 0x06000B29 RID: 2857 RVA: 0x00031C6C File Offset: 0x0002FE6C
			protected override bool OnTerminando(ControlladorDeAutoSexOral dataUpdate, bool primerUpdate, ControlladorDeAutoSexOral.Orden ordenEsperandoDetencion)
			{
				dataUpdate.m_effector.leftShoulderOverridenWeight = (dataUpdate.m_effector.rightShoulderOverridenWeight = Mathf.MoveTowards(dataUpdate.m_effector.leftShoulderOverridenWeight, 0f, base.estadoDeltaTime * dataUpdate.effectorConfig.overridingPositionWieghtVelocity));
				return dataUpdate.m_effector.leftShoulderOverridenWeight == 0f;
			}

			// Token: 0x06000B2A RID: 2858 RVA: 0x00031CCC File Offset: 0x0002FECC
			protected override void OnTerminada(ControlladorDeAutoSexOral dataUpdate, bool abruptamente)
			{
				this.m_PenisOffsetSaliendo = (this.m_PenisOffsetEntrando = 0f);
				dataUpdate.m_effector.leftShoulderOffset = (dataUpdate.m_effector.rightShoulderOffset = Vector3.zero);
				dataUpdate.m_effector.velocity = ((this.parte == ParteQuePuedeEstimular.dedo) ? (dataUpdate.effectorConfig.maxVelocidadEffector * 0.333f) : dataUpdate.effectorConfig.maxVelocidadEffector);
			}

			// Token: 0x0400072F RID: 1839
			public bool canzada;

			// Token: 0x04000730 RID: 1840
			public float weight;

			// Token: 0x04000731 RID: 1841
			public ParteQuePuedeEstimular parte;

			// Token: 0x04000732 RID: 1842
			private ControlladorDeAutoSexOral.GetRangeDeTolerancia m_toleranciaVelocidad;

			// Token: 0x04000733 RID: 1843
			private ControlladorDeAutoSexOral.GetRangeDeTolerancia m_toleranciaProfundidad;

			// Token: 0x04000734 RID: 1844
			[ReadOnlyUI]
			[SerializeField]
			private float m_worldLastDeep;

			// Token: 0x04000735 RID: 1845
			[ReadOnlyUI]
			[SerializeField]
			private float m_minWorldPenetration;

			// Token: 0x04000736 RID: 1846
			[ReadOnlyUI]
			[SerializeField]
			private float m_maxWorldPenetration;

			// Token: 0x04000737 RID: 1847
			[ReadOnlyUI]
			[SerializeField]
			private ControlladorDeAutoSexOral.Orden.EstadoDeProfunidad m_EstadoDeProfunidad;

			// Token: 0x04000738 RID: 1848
			[ReadOnlyUI]
			[SerializeField]
			private float m_tiempoEnCurrentEstado;

			// Token: 0x04000739 RID: 1849
			[ReadOnlyUI]
			[SerializeField]
			private float m_worldPolarizedCurrentVelocity;

			// Token: 0x0400073A RID: 1850
			[ReadOnlyUI]
			[SerializeField]
			private float m_worldCurrentVelocity;

			// Token: 0x0400073B RID: 1851
			[ReadOnlyUI]
			[SerializeField]
			private float m_worldTargetVelocity;

			// Token: 0x0400073C RID: 1852
			[ReadOnlyUI]
			[SerializeField]
			private float m_rangeWeightVelocity;

			// Token: 0x0400073D RID: 1853
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadModShouldersPorInvertedDot;

			// Token: 0x0400073E RID: 1854
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadModShouldersPorCercaLimites;

			// Token: 0x0400073F RID: 1855
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadModShoulders;

			// Token: 0x04000740 RID: 1856
			[ReadOnlyUI]
			[SerializeField]
			private float m_timeNotPenetrated;

			// Token: 0x04000741 RID: 1857
			[ReadOnlyUI]
			[SerializeField]
			private bool m_wasWellPenetrated;

			// Token: 0x04000742 RID: 1858
			[ReadOnlyUI]
			[SerializeField]
			private bool m_wasMaxDeep;

			// Token: 0x04000743 RID: 1859
			[SerializeField]
			private float m_PenisOffsetEntrando;

			// Token: 0x04000744 RID: 1860
			[SerializeField]
			private float m_PenisOffsetSaliendo;

			// Token: 0x04000745 RID: 1861
			[ReadOnlyUI]
			[SerializeField]
			private RangeValueV2 velRange;

			// Token: 0x04000746 RID: 1862
			[ReadOnlyUI]
			[SerializeField]
			private RangeValueV2 proRange;

			// Token: 0x04000747 RID: 1863
			private CoolDown coolDown = new CoolDown(0.25f);

			// Token: 0x020001D8 RID: 472
			public enum EstadoDeProfunidad
			{
				// Token: 0x04000A12 RID: 2578
				inMovil,
				// Token: 0x04000A13 RID: 2579
				entrado,
				// Token: 0x04000A14 RID: 2580
				saliendo
			}
		}

		// Token: 0x0200013E RID: 318
		public sealed class Colas : ControllerColaDePrioridadBase<ControlladorDeAutoSexOral.Stado, ControlladorDeAutoSexOral.Orden, ControlladorDeAutoSexOral.Colas, ControlladorDeAutoSexOral, int>.ColasBase
		{
		}

		// Token: 0x0200013F RID: 319
		public sealed class Stado : ControllerColaDePrioridadBase<ControlladorDeAutoSexOral.Stado, ControlladorDeAutoSexOral.Orden, ControlladorDeAutoSexOral.Colas, ControlladorDeAutoSexOral, int>.StadoBase
		{
		}
	}
}
