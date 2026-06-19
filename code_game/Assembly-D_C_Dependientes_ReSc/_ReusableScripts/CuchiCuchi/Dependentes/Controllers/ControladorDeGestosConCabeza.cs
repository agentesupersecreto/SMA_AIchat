using System;
using Assets.Base.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x0200019B RID: 411
	public sealed class ControladorDeGestosConCabeza : ControllerColaDePrioridadBase<ControladorDeGestosConCabeza.Stado, ControladorDeGestosConCabeza.Orden, ControladorDeGestosConCabeza.Colas, ControladorDeGestosConCabeza, int>, IControladorDeGestosConCabeza
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x00014CB2 File Offset: 0x00012EB2
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0002FC64 File Offset: 0x0002DE64
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			IUserFullBodyBipedIK componentEnRoot = this.GetComponentEnRoot(false);
			FullBodyBipedIK fullBodyBipedIK = ((componentEnRoot != null) ? componentEnRoot.IK : null);
			if (fullBodyBipedIK == null)
			{
				throw new ArgumentNullException("userIK", "userIK null reference.");
			}
			this.m_userHeadEffector = fullBodyBipedIK.GetComponent<HeadChainEffectorTValle>();
			if (this.m_userHeadEffector == null)
			{
				throw new ArgumentNullException("m_userHeadEffector", "m_userHeadEffector null reference.");
			}
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0002FCCE File Offset: 0x0002DECE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_userHeadEffector.updating += this.M_userHeadEffector_updating;
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0002FCED File Offset: 0x0002DEED
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_userHeadEffector.updating -= this.M_userHeadEffector_updating;
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0002FD0D File Offset: 0x0002DF0D
		private void M_userHeadEffector_updating(HeadChainEffectorTValle obj)
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0002FD18 File Offset: 0x0002DF18
		public bool GestuarConPausa(TipoDeGestoDeCabeza tipo, float amplitudMod, float duracion, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConCabeza.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(tipo);
			if (configDeTipo == null)
			{
				return false;
			}
			if (configDeTipo.loops != 1)
			{
				Debug.LogError("Pause is Not Comptible with many loops");
			}
			float num = ((configDeTipo.x.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.x.amplitudEnGrados) : configDeTipo.x.amplitudEnGrados);
			float num2 = ((configDeTipo.y.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.y.amplitudEnGrados) : configDeTipo.y.amplitudEnGrados);
			float num3 = ((configDeTipo.z.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.z.amplitudEnGrados) : configDeTipo.z.amplitudEnGrados);
			num *= amplitudMod;
			num2 *= amplitudMod;
			num3 *= amplitudMod;
			return this.Gestuar(configDeTipo.x.curva, num, configDeTipo.y.curva, num2, configDeTipo.z.curva, num3, configDeTipo.loops, configDeTipo.duracionPorCiclo, duracion, configDeTipo.middleToPause, 0, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0002FE40 File Offset: 0x0002E040
		public bool GestuarOverridingDuracion(TipoDeGestoDeCabeza tipo, float amplitudMod, float duracion, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConCabeza.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(tipo);
			if (configDeTipo == null)
			{
				return false;
			}
			float num = ((configDeTipo.x.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.x.amplitudEnGrados) : configDeTipo.x.amplitudEnGrados);
			float num2 = ((configDeTipo.y.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.y.amplitudEnGrados) : configDeTipo.y.amplitudEnGrados);
			float num3 = ((configDeTipo.z.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.z.amplitudEnGrados) : configDeTipo.z.amplitudEnGrados);
			num *= amplitudMod;
			num2 *= amplitudMod;
			num3 *= amplitudMod;
			return this.Gestuar(configDeTipo.x.curva, num, configDeTipo.y.curva, num2, configDeTipo.z.curva, num3, configDeTipo.loops, duracion, duracion, configDeTipo.middleToPause, 0, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0002FF50 File Offset: 0x0002E150
		public bool Gestuar(TipoDeGestoDeCabeza tipo, float amplitudMod, float duracionMod, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConCabeza.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(tipo);
			return configDeTipo != null && this.GestuarOverridingDuracion(tipo, amplitudMod, configDeTipo.duracionPorCiclo * duracionMod, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0002FF84 File Offset: 0x0002E184
		public bool Gestuar(TipoDeGestoDeCabeza tipo, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConCabeza.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(tipo);
			if (configDeTipo == null)
			{
				return false;
			}
			float num = ((configDeTipo.x.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.x.amplitudEnGrados) : configDeTipo.x.amplitudEnGrados);
			float num2 = ((configDeTipo.y.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.y.amplitudEnGrados) : configDeTipo.y.amplitudEnGrados);
			float num3 = ((configDeTipo.z.puedeInvertirse && 0.333f.ProcMod(1f)) ? (-configDeTipo.z.amplitudEnGrados) : configDeTipo.z.amplitudEnGrados);
			return this.Gestuar(configDeTipo.x.curva, num, configDeTipo.y.curva, num2, configDeTipo.z.curva, num3, configDeTipo.loops, configDeTipo.duracionPorCiclo, configDeTipo.duracionPorCiclo, configDeTipo.middleToPause, 0, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00030090 File Offset: 0x0002E290
		public bool Gestuar(AnimationCurve x, float amplitudX, AnimationCurve y, float amplitudY, AnimationCurve z, float amplitudZ, int loops, float duracionPorCiclo, float duracionTotal, float middleTimeCicloMod, int tipoId, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			if (!x.ContieneData() && !y.ContieneData() && !z.ContieneData())
			{
				return false;
			}
			ControladorDeGestosConCabeza.Orden orden;
			bool flag;
			bool flag2;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag, tipoId, 0, priConfig, out flag2, ref puedePonerEnCola, false))
			{
				return false;
			}
			loops = Mathf.Clamp(loops, 1, int.MaxValue);
			duracionPorCiclo = Mathf.Clamp(duracionPorCiclo, 0.001f, 1200f);
			ControladorDeGestosConCabeza.Orden orden2 = new ControladorDeGestosConCabeza.Orden(x, amplitudX, y, amplitudY, z, amplitudZ, loops, duracionPorCiclo, duracionTotal, middleTimeCicloMod, tipoId, 0, priConfig);
			base.Procesar(orden == null, flag, priConfig, orden2, false, false);
			return true;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x0003011F File Offset: 0x0002E31F
		protected override ControladorDeGestosConCabeza ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00030122 File Offset: 0x0002E322
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Gestuar DebugearTipo"
			};
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0003013B File Offset: 0x0002E33B
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Gestuar(this.m_DebugearTipo, this.m_amplitudMod, this.m_duracionMod, ControllerPrioridadConfig.interrumpir, false);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0003015E File Offset: 0x0002E35E
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Gestuar Con Pausa DebugearTipo"
			};
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00030177 File Offset: 0x0002E377
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.GestuarConPausa(this.m_DebugearTipo, this.m_amplitudMod, this.m_duracionMod, ControllerPrioridadConfig.interrumpir, false);
		}

		// Token: 0x04000742 RID: 1858
		public const float probToInvert = 0.333f;

		// Token: 0x04000743 RID: 1859
		private HeadChainEffectorTValle m_userHeadEffector;

		// Token: 0x04000744 RID: 1860
		[Header("***Debbuging")]
		[SerializeField]
		private TipoDeGestoDeCabeza m_DebugearTipo;

		// Token: 0x04000745 RID: 1861
		[SerializeField]
		private float m_amplitudMod = 1f;

		// Token: 0x04000746 RID: 1862
		[SerializeField]
		private float m_duracionMod = 1f;

		// Token: 0x0200019C RID: 412
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControladorDeGestosConCabeza.Stado, ControladorDeGestosConCabeza.Orden, ControladorDeGestosConCabeza.Colas, ControladorDeGestosConCabeza, int>.OrdenBaseDeControllador
		{
			// Token: 0x060009BE RID: 2494 RVA: 0x000301B8 File Offset: 0x0002E3B8
			public Orden(AnimationCurve x, float amplitudX, AnimationCurve y, float amplitudY, AnimationCurve z, float amplitudZ, int loops, float duracionPorCiclo, float duracionTotal, float middleTimeCicloMod, int tipoId, int prioridad, ControllerPrioridadConfig priConfig)
				: base(tipoId, prioridad, duracionTotal * (float)loops, priConfig, false)
			{
				amplitudX = Mathf.Clamp(amplitudX, -180f, 180f);
				amplitudY = Mathf.Clamp(amplitudY, -180f, 180f);
				amplitudZ = Mathf.Clamp(amplitudZ, -180f, 180f);
				this.m_x = x;
				this.m_amplitudX = amplitudX;
				this.m_y = y;
				this.m_amplitudY = amplitudY;
				this.m_z = z;
				this.m_amplitudZ = amplitudZ;
				this.m_loops = loops;
				this.m_duracionPorCiclo = duracionPorCiclo;
				this.m_middleTimeCicloMod = middleTimeCicloMod;
				if (this.m_loops == 1 && duracionTotal > duracionPorCiclo)
				{
					this.m_pauseAtMiddle = true;
					return;
				}
				this.m_pauseAtMiddle = false;
				this.m_duracionPorCiclo = duracionTotal;
			}

			// Token: 0x060009BF RID: 2495 RVA: 0x0003027B File Offset: 0x0002E47B
			protected override void OnStart(ControladorDeGestosConCabeza dataUpdate)
			{
				this.m_currentFramesToWaitToEnd = 0;
			}

			// Token: 0x060009C0 RID: 2496 RVA: 0x00030284 File Offset: 0x0002E484
			protected override bool UpdateOrden(ControladorDeGestosConCabeza dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino() || dataUpdate.m_userHeadEffector == null)
				{
					return false;
				}
				float currentTime = base.currentTime;
				float num3;
				if (this.m_pauseAtMiddle)
				{
					float num = this.m_duracionPorCiclo * this.m_middleTimeCicloMod;
					float num2 = this.m_duracionPorCiclo * (1f - this.m_middleTimeCicloMod);
					if (currentTime < num)
					{
						num3 = Mathf.InverseLerp(0f, num, currentTime);
						num3 = Mathf.Lerp(0f, this.m_middleTimeCicloMod, num3);
					}
					else if (currentTime > base.duracion - num2)
					{
						num3 = Mathf.InverseLerp(base.duracion - num2, base.duracion, currentTime);
						num3 = Mathf.Lerp(this.m_middleTimeCicloMod, 1f, num3);
					}
					else
					{
						num3 = this.m_middleTimeCicloMod;
					}
				}
				else
				{
					float num4 = currentTime % this.m_duracionPorCiclo;
					num3 = Mathf.InverseLerp(0f, this.m_duracionPorCiclo, num4);
				}
				Vector3 currentAnglesFromRoot = dataUpdate.m_userHeadEffector.head.currentAnglesFromRoot;
				float angle = this.GetAngle(this.m_x, this.m_amplitudX, num3, 85f, currentAnglesFromRoot.x);
				float angle2 = this.GetAngle(this.m_y, this.m_amplitudY, num3, 75f, currentAnglesFromRoot.y);
				float angle3 = this.GetAngle(this.m_z, this.m_amplitudZ, num3, 65f, currentAnglesFromRoot.z);
				this.m_lastTarget = new Vector3(angle, angle2, angle3);
				if (dataUpdate.m_userHeadEffector.head.resetOffsetRotation)
				{
					dataUpdate.m_userHeadEffector.head.offsetRotation += this.m_lastTarget;
				}
				else
				{
					dataUpdate.m_userHeadEffector.head.offsetRotation = this.m_lastTarget;
				}
				return true;
			}

			// Token: 0x060009C1 RID: 2497 RVA: 0x00030444 File Offset: 0x0002E644
			private float GetAngle(AnimationCurve curva, float amplitud, float modDeCiclo, float maxAngle, float currentAngle)
			{
				if (curva == null || curva.length == 0)
				{
					return 0f;
				}
				currentAngle = Mathf.Abs(currentAngle);
				float num = curva.Evaluate(modDeCiclo);
				num *= amplitud;
				float num2 = ((num < 0f) ? (-1f) : 1f);
				num = Mathf.Abs(num);
				if (currentAngle + num > maxAngle)
				{
					float num3 = maxAngle - currentAngle;
					num3 = ((num3 < 0f) ? 0f : num3);
					num = Mathf.Lerp(num, num3, 0.9f);
				}
				return num * num2;
			}

			// Token: 0x060009C2 RID: 2498 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnDetenidaPorUsuario(ControladorDeGestosConCabeza dataUpdate)
			{
			}

			// Token: 0x060009C3 RID: 2499 RVA: 0x000304C4 File Offset: 0x0002E6C4
			protected override bool OnTerminando(ControladorDeGestosConCabeza dataUpdate, bool primerUpdate, ControladorDeGestosConCabeza.Orden ordenEsperandoDetencion)
			{
				if (primerUpdate)
				{
					if (dataUpdate.m_userHeadEffector.head.resetOffsetRotation)
					{
						dataUpdate.m_userHeadEffector.head.offsetRotation += this.m_lastTarget;
					}
					else
					{
						dataUpdate.m_userHeadEffector.head.offsetRotation = this.m_lastTarget;
					}
					dataUpdate.m_userHeadEffector.head.ForceSmooth();
				}
				this.m_currentFramesToWaitToEnd++;
				return this.m_currentFramesToWaitToEnd >= 600 || ExtendedMonoBehaviour.AlmostEqual(Vector3.zero, dataUpdate.m_userHeadEffector.head.currentSmoothOffsetRotation, 0.01f);
			}

			// Token: 0x060009C4 RID: 2500 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnTerminada(ControladorDeGestosConCabeza dataUpdate, bool abruptamente)
			{
			}

			// Token: 0x04000747 RID: 1863
			private const int maxFramesToWaitToEnd = 600;

			// Token: 0x04000748 RID: 1864
			private int m_currentFramesToWaitToEnd;

			// Token: 0x04000749 RID: 1865
			private AnimationCurve m_x;

			// Token: 0x0400074A RID: 1866
			private float m_amplitudX;

			// Token: 0x0400074B RID: 1867
			private AnimationCurve m_y;

			// Token: 0x0400074C RID: 1868
			private float m_amplitudY;

			// Token: 0x0400074D RID: 1869
			private AnimationCurve m_z;

			// Token: 0x0400074E RID: 1870
			private float m_amplitudZ;

			// Token: 0x0400074F RID: 1871
			private int m_loops;

			// Token: 0x04000750 RID: 1872
			private float m_middleTimeCicloMod;

			// Token: 0x04000751 RID: 1873
			private float m_duracionPorCiclo;

			// Token: 0x04000752 RID: 1874
			private bool m_pauseAtMiddle;

			// Token: 0x04000753 RID: 1875
			private Vector3 m_lastTarget;
		}

		// Token: 0x0200019D RID: 413
		public sealed class Colas : ControllerColaDePrioridadBase<ControladorDeGestosConCabeza.Stado, ControladorDeGestosConCabeza.Orden, ControladorDeGestosConCabeza.Colas, ControladorDeGestosConCabeza, int>.ColasBase
		{
		}

		// Token: 0x0200019E RID: 414
		public sealed class Stado : ControllerColaDePrioridadBase<ControladorDeGestosConCabeza.Stado, ControladorDeGestosConCabeza.Orden, ControladorDeGestosConCabeza.Colas, ControladorDeGestosConCabeza, int>.StadoBase
		{
		}
	}
}
