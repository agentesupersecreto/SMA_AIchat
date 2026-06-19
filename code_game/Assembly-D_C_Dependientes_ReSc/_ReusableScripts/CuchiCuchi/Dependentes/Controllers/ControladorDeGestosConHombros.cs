using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x0200019F RID: 415
	public sealed class ControladorDeGestosConHombros : ControllerColaDePrioridadBase<ControladorDeGestosConHombros.Stado, ControladorDeGestosConHombros.Orden, ControladorDeGestosConHombros.Colas, ControladorDeGestosConHombros, int>, IControladorDeGestosConHombros
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x00014CB2 File Offset: 0x00012EB2
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0003057C File Offset: 0x0002E77C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IKUpdater = this.GetComponentEnRoot(false);
			IIKUpdater ikupdater = this.m_IKUpdater;
			IReadOnlyList<Component> readOnlyList = ((ikupdater != null) ? ikupdater.SortedIKsDeLayer(0) : null);
			if (readOnlyList == null)
			{
				throw new ArgumentNullException("userIK", "userIK null reference.");
			}
			this.m_shoulderEffectors = readOnlyList.Select((Component ik) => ik.GetComponent<ShoulderRotatorV2>()).ToArray<ShoulderRotatorV2>();
			if (this.m_shoulderEffectors == null)
			{
				throw new ArgumentNullException("m_shoulderEffector", "m_shoulderEffector null reference.");
			}
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0003060C File Offset: 0x0002E80C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			for (int i = 0; i < this.m_shoulderEffectors.Length; i++)
			{
				this.m_shoulderEffectors[i].updating += this.M_shoulderEffector_updating;
			}
			this.m_IKUpdater.onAllIKsUpdating += this.M_IKUpdater_onAllIKsUpdating;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x00030664 File Offset: 0x0002E864
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			for (int i = 0; i < this.m_shoulderEffectors.Length; i++)
			{
				this.m_shoulderEffectors[i].updating -= this.M_shoulderEffector_updating;
			}
			if (this.m_IKUpdater != null)
			{
				this.m_IKUpdater.onAllIKsUpdating -= this.M_IKUpdater_onAllIKsUpdating;
			}
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x000306C4 File Offset: 0x0002E8C4
		private void GetRotators(out ShoulderRotatorV2 main, out ShoulderRotatorV2 off)
		{
			IReadOnlyList<Component> readOnlyList = this.m_IKUpdater.SortedIKsDeLayer(0);
			if (readOnlyList[0] == this.m_shoulderEffectors[0].fullBodyBipedIK)
			{
				main = this.m_shoulderEffectors[0];
				off = this.m_shoulderEffectors[1];
				return;
			}
			if (readOnlyList[0] == this.m_shoulderEffectors[1].fullBodyBipedIK)
			{
				main = this.m_shoulderEffectors[1];
				off = this.m_shoulderEffectors[0];
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00030744 File Offset: 0x0002E944
		private void M_IKUpdater_onAllIKsUpdating(IIKUpdater obj)
		{
			ShoulderRotatorV2 shoulderRotatorV;
			ShoulderRotatorV2 shoulderRotatorV2;
			this.GetRotators(out shoulderRotatorV, out shoulderRotatorV2);
			this.m_shoulderRotatorMainChanged = shoulderRotatorV != this.m_main;
			this.m_main = shoulderRotatorV;
			this.m_off = shoulderRotatorV2;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0003077B File Offset: 0x0002E97B
		private void M_shoulderEffector_updating(ShoulderRotatorV2 obj)
		{
			if (obj == this.m_main)
			{
				base.ActualizarControlladorManualmente(false);
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00030794 File Offset: 0x0002E994
		public bool GestuarConPausa(TipoDeGestoDeHombro tipo, float amplitudMod, float duracion, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConHombros.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(tipo);
			if (configDeTipo == null)
			{
				return false;
			}
			float num = configDeTipo.x.l.amplitudEnGrados;
			float num2 = configDeTipo.y.l.amplitudEnGrados;
			float num3 = configDeTipo.z.l.amplitudEnGrados;
			float num4 = configDeTipo.x.r.amplitudEnGrados;
			float num5 = configDeTipo.y.r.amplitudEnGrados;
			float num6 = configDeTipo.z.r.amplitudEnGrados;
			if (configDeTipo.x.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num *= -1f;
				num4 *= -1f;
			}
			if (configDeTipo.y.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num2 *= -1f;
				num5 *= -1f;
			}
			if (configDeTipo.z.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num3 *= -1f;
				num6 *= -1f;
			}
			num *= amplitudMod;
			num2 *= amplitudMod;
			num3 *= amplitudMod;
			num4 *= amplitudMod;
			num5 *= amplitudMod;
			num6 *= amplitudMod;
			AnimationCurve animationCurve = configDeTipo.x.l.curva;
			AnimationCurve animationCurve2 = configDeTipo.y.l.curva;
			AnimationCurve animationCurve3 = configDeTipo.z.l.curva;
			AnimationCurve animationCurve4 = configDeTipo.x.r.curva;
			AnimationCurve animationCurve5 = configDeTipo.y.r.curva;
			AnimationCurve animationCurve6 = configDeTipo.z.r.curva;
			if (configDeTipo.x.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve = configDeTipo.x.r.curva;
				animationCurve4 = configDeTipo.x.l.curva;
				float num7 = num4;
				num4 = num;
				num = num7;
			}
			if (configDeTipo.y.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve2 = configDeTipo.y.r.curva;
				animationCurve5 = configDeTipo.y.l.curva;
				float num8 = num5;
				num5 = num2;
				num2 = num8;
			}
			if (configDeTipo.z.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve3 = configDeTipo.z.r.curva;
				animationCurve6 = configDeTipo.z.l.curva;
				float num9 = num6;
				num6 = num3;
				num3 = num9;
			}
			num = (configDeTipo.x.l.mirror ? (-num) : num);
			num2 = (configDeTipo.y.l.mirror ? (-num2) : num2);
			num3 = (configDeTipo.z.l.mirror ? (-num3) : num3);
			num4 = (configDeTipo.x.r.mirror ? (-num4) : num4);
			num5 = (configDeTipo.y.r.mirror ? (-num5) : num5);
			num6 = (configDeTipo.z.r.mirror ? (-num6) : num6);
			return this.Gestuar(animationCurve, num, animationCurve2, num2, animationCurve3, num3, animationCurve4, num4, animationCurve5, num5, animationCurve6, num6, configDeTipo.loops, configDeTipo.duracionPorCiclo, duracion, configDeTipo.middleToPause, 0, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00030ADC File Offset: 0x0002ECDC
		public bool GestuarOverridingDuracion(TipoDeGestoDeHombro tipo, float amplitudMod, float duracion, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConHombros.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(tipo);
			if (configDeTipo == null)
			{
				return false;
			}
			float num = configDeTipo.x.l.amplitudEnGrados;
			float num2 = configDeTipo.y.l.amplitudEnGrados;
			float num3 = configDeTipo.z.l.amplitudEnGrados;
			float num4 = configDeTipo.x.r.amplitudEnGrados;
			float num5 = configDeTipo.y.r.amplitudEnGrados;
			float num6 = configDeTipo.z.r.amplitudEnGrados;
			if (configDeTipo.x.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num *= -1f;
				num4 *= -1f;
			}
			if (configDeTipo.y.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num2 *= -1f;
				num5 *= -1f;
			}
			if (configDeTipo.z.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num3 *= -1f;
				num6 *= -1f;
			}
			num *= amplitudMod;
			num2 *= amplitudMod;
			num3 *= amplitudMod;
			num4 *= amplitudMod;
			num5 *= amplitudMod;
			num6 *= amplitudMod;
			AnimationCurve animationCurve = configDeTipo.x.l.curva;
			AnimationCurve animationCurve2 = configDeTipo.y.l.curva;
			AnimationCurve animationCurve3 = configDeTipo.z.l.curva;
			AnimationCurve animationCurve4 = configDeTipo.x.r.curva;
			AnimationCurve animationCurve5 = configDeTipo.y.r.curva;
			AnimationCurve animationCurve6 = configDeTipo.z.r.curva;
			if (configDeTipo.x.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve = configDeTipo.x.r.curva;
				animationCurve4 = configDeTipo.x.l.curva;
				float num7 = num4;
				num4 = num;
				num = num7;
			}
			if (configDeTipo.y.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve2 = configDeTipo.y.r.curva;
				animationCurve5 = configDeTipo.y.l.curva;
				float num8 = num5;
				num5 = num2;
				num2 = num8;
			}
			if (configDeTipo.z.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve3 = configDeTipo.z.r.curva;
				animationCurve6 = configDeTipo.z.l.curva;
				float num9 = num6;
				num6 = num3;
				num3 = num9;
			}
			num = (configDeTipo.x.l.mirror ? (-num) : num);
			num2 = (configDeTipo.y.l.mirror ? (-num2) : num2);
			num3 = (configDeTipo.z.l.mirror ? (-num3) : num3);
			num4 = (configDeTipo.x.r.mirror ? (-num4) : num4);
			num5 = (configDeTipo.y.r.mirror ? (-num5) : num5);
			num6 = (configDeTipo.z.r.mirror ? (-num6) : num6);
			return this.Gestuar(animationCurve, num, animationCurve2, num2, animationCurve3, num3, animationCurve4, num4, animationCurve5, num5, animationCurve6, num6, configDeTipo.loops, duracion, duracion, configDeTipo.middleToPause, 0, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00030E1C File Offset: 0x0002F01C
		public bool Gestuar(TipoDeGestoDeHombro tipo, float amplitudMod, float duracionMod, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConHombros.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(tipo);
			return configDeTipo != null && this.GestuarOverridingDuracion(tipo, amplitudMod, configDeTipo.duracionPorCiclo * duracionMod, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00030E50 File Offset: 0x0002F050
		public bool Gestuar(TipoDeGestoDeHombro tipo, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			CurvasDeGestosConHombros.ConfigDeTipo configDeTipo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(tipo);
			if (configDeTipo == null)
			{
				return false;
			}
			float num = configDeTipo.x.l.amplitudEnGrados;
			float num2 = configDeTipo.y.l.amplitudEnGrados;
			float num3 = configDeTipo.z.l.amplitudEnGrados;
			float num4 = configDeTipo.x.r.amplitudEnGrados;
			float num5 = configDeTipo.y.r.amplitudEnGrados;
			float num6 = configDeTipo.z.r.amplitudEnGrados;
			if (configDeTipo.x.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num *= -1f;
				num4 *= -1f;
			}
			if (configDeTipo.y.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num2 *= -1f;
				num5 *= -1f;
			}
			if (configDeTipo.z.puedeInvertirseAmplitud && 0.333f.ProcMod(1f))
			{
				num3 *= -1f;
				num6 *= -1f;
			}
			AnimationCurve animationCurve = configDeTipo.x.l.curva;
			AnimationCurve animationCurve2 = configDeTipo.y.l.curva;
			AnimationCurve animationCurve3 = configDeTipo.z.l.curva;
			AnimationCurve animationCurve4 = configDeTipo.x.r.curva;
			AnimationCurve animationCurve5 = configDeTipo.y.r.curva;
			AnimationCurve animationCurve6 = configDeTipo.z.r.curva;
			if (configDeTipo.x.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve = configDeTipo.x.r.curva;
				animationCurve4 = configDeTipo.x.l.curva;
				float num7 = num4;
				num4 = num;
				num = num7;
			}
			if (configDeTipo.y.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve2 = configDeTipo.y.r.curva;
				animationCurve5 = configDeTipo.y.l.curva;
				float num8 = num5;
				num5 = num2;
				num2 = num8;
			}
			if (configDeTipo.z.puedeInvertirseLados && 0.333f.ProcMod(1f))
			{
				animationCurve3 = configDeTipo.z.r.curva;
				animationCurve6 = configDeTipo.z.l.curva;
				float num9 = num6;
				num6 = num3;
				num3 = num9;
			}
			num = (configDeTipo.x.l.mirror ? (-num) : num);
			num2 = (configDeTipo.y.l.mirror ? (-num2) : num2);
			num3 = (configDeTipo.z.l.mirror ? (-num3) : num3);
			num4 = (configDeTipo.x.r.mirror ? (-num4) : num4);
			num5 = (configDeTipo.y.r.mirror ? (-num5) : num5);
			num6 = (configDeTipo.z.r.mirror ? (-num6) : num6);
			return this.Gestuar(animationCurve, num, animationCurve2, num2, animationCurve3, num3, animationCurve4, num4, animationCurve5, num5, animationCurve6, num6, configDeTipo.loops, configDeTipo.duracionPorCiclo, configDeTipo.duracionPorCiclo, configDeTipo.middleToPause, 0, priConfig, puedePonerEnCola);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0003117C File Offset: 0x0002F37C
		public bool Gestuar(AnimationCurve xL, float amplitudXL, AnimationCurve yL, float amplitudYL, AnimationCurve zL, float amplitudZL, AnimationCurve xR, float amplitudXR, AnimationCurve yR, float amplitudYR, AnimationCurve zR, float amplitudZR, int loops, float duracionPorCiclo, float duracionTotal, float middleTimeCicloMod, int tipoId, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			if (!xL.ContieneData() && !yL.ContieneData() && !zL.ContieneData() && !xR.ContieneData() && !yR.ContieneData() && !zR.ContieneData())
			{
				return false;
			}
			ControladorDeGestosConHombros.Orden orden;
			bool flag;
			bool flag2;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag, tipoId, 0, priConfig, out flag2, ref puedePonerEnCola, false))
			{
				return false;
			}
			loops = Mathf.Clamp(loops, 1, int.MaxValue);
			duracionPorCiclo = Mathf.Clamp(duracionPorCiclo, 0.001f, 1200f);
			ControladorDeGestosConHombros.Orden orden2 = new ControladorDeGestosConHombros.Orden(xL, amplitudXL, yL, amplitudYL, zL, amplitudZL, xR, amplitudXR, yR, amplitudYR, zR, amplitudZR, loops, duracionPorCiclo, duracionTotal, middleTimeCicloMod, tipoId, 0, priConfig);
			base.Procesar(orden == null, flag, priConfig, orden2, false, false);
			return true;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000118D7 File Offset: 0x0000FAD7
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0003011F File Offset: 0x0002E31F
		protected override ControladorDeGestosConHombros ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00030122 File Offset: 0x0002E322
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Gestuar DebugearTipo"
			};
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00031232 File Offset: 0x0002F432
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Gestuar(this.m_DebugearTipo, this.m_amplitudMod, this.m_duracionMod, ControllerPrioridadConfig.interrumpir, false);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0003015E File Offset: 0x0002E35E
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Gestuar Con Pausa DebugearTipo"
			};
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00031255 File Offset: 0x0002F455
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.GestuarConPausa(this.m_DebugearTipo, this.m_amplitudMod, this.m_duracionMod, ControllerPrioridadConfig.interrumpir, false);
		}

		// Token: 0x04000754 RID: 1876
		public const float probToInvert = 0.333f;

		// Token: 0x04000755 RID: 1877
		private ShoulderRotatorV2[] m_shoulderEffectors;

		// Token: 0x04000756 RID: 1878
		[SerializeField]
		[ReadOnlyUI]
		private ShoulderRotatorV2 m_main;

		// Token: 0x04000757 RID: 1879
		[SerializeField]
		[ReadOnlyUI]
		private ShoulderRotatorV2 m_off;

		// Token: 0x04000758 RID: 1880
		[SerializeField]
		[ReadOnlyUI]
		private bool m_shoulderRotatorMainChanged;

		// Token: 0x04000759 RID: 1881
		private IIKUpdater m_IKUpdater;

		// Token: 0x0400075A RID: 1882
		private int m_lastFrame;

		// Token: 0x0400075B RID: 1883
		[Header("***Debbuging")]
		[SerializeField]
		private TipoDeGestoDeHombro m_DebugearTipo;

		// Token: 0x0400075C RID: 1884
		[SerializeField]
		private float m_amplitudMod = 1f;

		// Token: 0x0400075D RID: 1885
		[SerializeField]
		private float m_duracionMod = 1f;

		// Token: 0x020001A0 RID: 416
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControladorDeGestosConHombros.Stado, ControladorDeGestosConHombros.Orden, ControladorDeGestosConHombros.Colas, ControladorDeGestosConHombros, int>.OrdenBaseDeControllador
		{
			// Token: 0x060009DC RID: 2524 RVA: 0x00031298 File Offset: 0x0002F498
			public Orden(AnimationCurve xL, float amplitudXL, AnimationCurve yL, float amplitudYL, AnimationCurve zL, float amplitudZL, AnimationCurve xR, float amplitudXR, AnimationCurve yR, float amplitudYR, AnimationCurve zR, float amplitudZR, int loops, float duracionPorCiclo, float duracionTotal, float middleTimeCicloMod, int tipoId, int prioridad, ControllerPrioridadConfig priConfig)
				: base(tipoId, prioridad, duracionTotal * (float)loops + 0.01f, priConfig, false)
			{
				amplitudXL = Mathf.Clamp(amplitudXL, -180f, 180f);
				amplitudYL = Mathf.Clamp(amplitudYL, -180f, 180f);
				amplitudZL = Mathf.Clamp(amplitudZL, -180f, 180f);
				amplitudXR = Mathf.Clamp(amplitudXR, -180f, 180f);
				amplitudYR = Mathf.Clamp(amplitudYR, -180f, 180f);
				amplitudZR = Mathf.Clamp(amplitudZR, -180f, 180f);
				this.m_xL = xL;
				this.m_amplitudXL = amplitudXL;
				this.m_yL = yL;
				this.m_amplitudYL = amplitudYL;
				this.m_zL = zL;
				this.m_amplitudZL = amplitudZL;
				this.m_xR = xR;
				this.m_amplitudXR = amplitudXR;
				this.m_yR = yR;
				this.m_amplitudYR = amplitudYR;
				this.m_zR = zR;
				this.m_amplitudZR = amplitudZR;
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

			// Token: 0x060009DD RID: 2525 RVA: 0x000313CA File Offset: 0x0002F5CA
			protected override void OnStart(ControladorDeGestosConHombros dataUpdate)
			{
				this.m_currentFramesToWaitToEnd = 0;
			}

			// Token: 0x060009DE RID: 2526 RVA: 0x000313D4 File Offset: 0x0002F5D4
			protected override bool UpdateOrden(ControladorDeGestosConHombros dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
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
				if (esPrimerUpdate || dataUpdate.m_shoulderRotatorMainChanged)
				{
					this.SmoothReset(dataUpdate.m_off);
				}
				this.UpdateHombro(num3, dataUpdate.m_main.lEffector, dataUpdate.m_main.fullBodyBipedIK.solver.IKPositionWeight, this.m_xL, this.m_amplitudXL, this.m_yL, this.m_amplitudYL, this.m_zL, this.m_amplitudZL, -20f, 20f, -20f, 15f, -35f, 10f, ref this.m_lastTargetL);
				this.UpdateHombro(num3, dataUpdate.m_main.rEffector, dataUpdate.m_main.fullBodyBipedIK.solver.IKPositionWeight, this.m_xR, this.m_amplitudXR, this.m_yR, this.m_amplitudYR, this.m_zR, this.m_amplitudZR, -20f, 20f, -15f, 20f, -10f, 35f, ref this.m_lastTargetR);
				return true;
			}

			// Token: 0x060009DF RID: 2527 RVA: 0x00031594 File Offset: 0x0002F794
			private void UpdateHombro(float modDeCiclo, ShoulderRotatorV2.HombroIKEffector effector, float w, AnimationCurve x, float amplitudX, AnimationCurve y, float amplitudY, AnimationCurve z, float amplitudZ, float maxAngleNegativoX, float maxAnglePositivoX, float maxAngleNegativoY, float maxAnglePositivoY, float maxAngleNegativoZ, float maxAnglePositivoZ, ref Vector3 lastTarget)
			{
				Vector3 currentAnglesFromRoot = effector.currentAnglesFromRoot;
				float angle = this.GetAngle(x, amplitudX * w, modDeCiclo, maxAngleNegativoX, maxAnglePositivoX, currentAnglesFromRoot.x);
				float angle2 = this.GetAngle(y, amplitudY * w, modDeCiclo, maxAngleNegativoY, maxAnglePositivoY, currentAnglesFromRoot.y);
				float angle3 = this.GetAngle(z, amplitudZ * w, modDeCiclo, maxAngleNegativoZ, maxAnglePositivoZ, currentAnglesFromRoot.z);
				lastTarget = new Vector3(angle, angle2, angle3);
				if (effector.resetOffsetRotation)
				{
					effector.offsetRotation += lastTarget;
					return;
				}
				effector.offsetRotation = lastTarget;
			}

			// Token: 0x060009E0 RID: 2528 RVA: 0x00031640 File Offset: 0x0002F840
			private float GetAngle(AnimationCurve curva, float amplitud, float modDeCiclo, float maxAngleNegativo, float maxAnglePositivo, float currentAngle)
			{
				if (curva == null || curva.length == 0)
				{
					return 0f;
				}
				float num = curva.Evaluate(modDeCiclo);
				num *= amplitud;
				if (currentAngle + num < maxAngleNegativo)
				{
					float num2 = maxAngleNegativo - currentAngle;
					if (currentAngle < maxAngleNegativo)
					{
						num2 = 0f;
					}
					if (num < num2)
					{
						num = Mathf.Lerp(num, num2, 0.9f);
					}
				}
				if (currentAngle + num > maxAnglePositivo)
				{
					float num3 = maxAnglePositivo - currentAngle;
					if (currentAngle > maxAnglePositivo)
					{
						num3 = 0f;
					}
					if (num > num3)
					{
						num = Mathf.Lerp(num, num3, 0.9f);
					}
				}
				return num;
			}

			// Token: 0x060009E1 RID: 2529 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnDetenidaPorUsuario(ControladorDeGestosConHombros dataUpdate)
			{
			}

			// Token: 0x060009E2 RID: 2530 RVA: 0x000316C4 File Offset: 0x0002F8C4
			protected override bool OnTerminando(ControladorDeGestosConHombros dataUpdate, bool primerUpdate, ControladorDeGestosConHombros.Orden esperandoDetencion)
			{
				bool flag = true;
				for (int i = 0; i < dataUpdate.m_shoulderEffectors.Length; i++)
				{
					ShoulderRotatorV2 shoulderRotatorV = dataUpdate.m_shoulderEffectors[i];
					if (primerUpdate)
					{
						this.SmoothReset(shoulderRotatorV);
					}
					flag = flag && ExtendedMonoBehaviour.AlmostEqual(Vector3.zero, shoulderRotatorV.rEffector.currentSmoothOffsetRotation, 0.01f) && ExtendedMonoBehaviour.AlmostEqual(Vector3.zero, shoulderRotatorV.lEffector.currentSmoothOffsetRotation, 0.01f);
				}
				this.m_currentFramesToWaitToEnd++;
				return this.m_currentFramesToWaitToEnd >= 600 || flag;
			}

			// Token: 0x060009E3 RID: 2531 RVA: 0x00031758 File Offset: 0x0002F958
			private void SmoothReset(ShoulderRotatorV2 m_shoulderEffector)
			{
				if (m_shoulderEffector.rEffector.resetOffsetRotation)
				{
					m_shoulderEffector.rEffector.offsetRotation += this.m_lastTargetR;
				}
				else
				{
					m_shoulderEffector.rEffector.offsetRotation = this.m_lastTargetR;
				}
				if (m_shoulderEffector.lEffector.resetOffsetRotation)
				{
					m_shoulderEffector.lEffector.offsetRotation += this.m_lastTargetL;
				}
				else
				{
					m_shoulderEffector.lEffector.offsetRotation = this.m_lastTargetL;
				}
				m_shoulderEffector.rEffector.ForceSmooth();
				m_shoulderEffector.lEffector.ForceSmooth();
			}

			// Token: 0x060009E4 RID: 2532 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnTerminada(ControladorDeGestosConHombros dataUpdate, bool abruptamente)
			{
			}

			// Token: 0x0400075E RID: 1886
			private const int maxFramesToWaitToEnd = 600;

			// Token: 0x0400075F RID: 1887
			private int m_currentFramesToWaitToEnd;

			// Token: 0x04000760 RID: 1888
			private AnimationCurve m_xL;

			// Token: 0x04000761 RID: 1889
			private float m_amplitudXL;

			// Token: 0x04000762 RID: 1890
			private AnimationCurve m_yL;

			// Token: 0x04000763 RID: 1891
			private float m_amplitudYL;

			// Token: 0x04000764 RID: 1892
			private AnimationCurve m_zL;

			// Token: 0x04000765 RID: 1893
			private float m_amplitudZL;

			// Token: 0x04000766 RID: 1894
			private AnimationCurve m_xR;

			// Token: 0x04000767 RID: 1895
			private float m_amplitudXR;

			// Token: 0x04000768 RID: 1896
			private AnimationCurve m_yR;

			// Token: 0x04000769 RID: 1897
			private float m_amplitudYR;

			// Token: 0x0400076A RID: 1898
			private AnimationCurve m_zR;

			// Token: 0x0400076B RID: 1899
			private float m_amplitudZR;

			// Token: 0x0400076C RID: 1900
			private int m_loops;

			// Token: 0x0400076D RID: 1901
			private float m_middleTimeCicloMod;

			// Token: 0x0400076E RID: 1902
			private float m_duracionPorCiclo;

			// Token: 0x0400076F RID: 1903
			private bool m_pauseAtMiddle;

			// Token: 0x04000770 RID: 1904
			private Vector3 m_lastTargetL;

			// Token: 0x04000771 RID: 1905
			private Vector3 m_lastTargetR;
		}

		// Token: 0x020001A1 RID: 417
		public sealed class Colas : ControllerColaDePrioridadBase<ControladorDeGestosConHombros.Stado, ControladorDeGestosConHombros.Orden, ControladorDeGestosConHombros.Colas, ControladorDeGestosConHombros, int>.ColasBase
		{
		}

		// Token: 0x020001A2 RID: 418
		public sealed class Stado : ControllerColaDePrioridadBase<ControladorDeGestosConHombros.Stado, ControladorDeGestosConHombros.Orden, ControladorDeGestosConHombros.Colas, ControladorDeGestosConHombros, int>.StadoBase
		{
		}
	}
}
