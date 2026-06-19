using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ParaReactores
{
	// Token: 0x020002FD RID: 765
	public class ParaReactorExpresionesPorExpulsionDeEnema : ParaReactor, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06001346 RID: 4934 RVA: 0x000066D6 File Offset: 0x000048D6
		TipoDeCalculadorDeEstimulo ICalculadorDeEstimulo.tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.frame;
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06001347 RID: 4935 RVA: 0x0005AE9A File Offset: 0x0005909A
		Emocion ICalculadorDeEstimulo.emo
		{
			get
			{
				return this.m_Placer;
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06001348 RID: 4936 RVA: 0x0005AEA2 File Offset: 0x000590A2
		double ICalculadorDeEstimulo.prioridad
		{
			get
			{
				return 9999.0 * Emocion.APrioridad(this.m_Placer);
			}
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x0005AEBC File Offset: 0x000590BC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Placer = this.GetComponentEnRoot(false);
			if (this.m_Placer == null)
			{
				throw new ArgumentNullException("Dolor", "Dolor null reference.");
			}
			this.m_Dolor = this.GetComponentEnRoot(false);
			if (this.m_Dolor == null)
			{
				throw new ArgumentNullException("Dolor", "Dolor null reference.");
			}
			this.m_MainReactorGenerico = this.GetComponentEnRoot(false);
			if (this.m_MainReactorGenerico == null)
			{
				throw new ArgumentNullException("MainReactorGenerico", "MainReactorGenerico null reference.");
			}
			this.m_inyectorDeOrgasmReaction = this.GetComponentEnRoot(false);
			if (this.m_MainReactorGenerico == null)
			{
				throw new ArgumentNullException("InyectorDeCalculoDeOrgasmo", "InyectorDeCalculoDeOrgasmo null reference.");
			}
			this.m_inyectado.Init(this);
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x0005AF87 File Offset: 0x00059187
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_MainReactorGenerico.reaccionando += this.M_MainReactorGenerico_reaccionando;
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x0005AFA8 File Offset: 0x000591A8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_MainReactorGenerico != null)
			{
				this.m_MainReactorGenerico.reaccionando -= this.M_MainReactorGenerico_reaccionando;
			}
			if (this.m_SemenParaAnus != null)
			{
				this.m_SemenParaAnus.onExpulsion -= this.M_SemenParaAnus_onExpulsion;
			}
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x0005B008 File Offset: 0x00059208
		private void M_MainReactorGenerico_reaccionando(IList<ICalculoDeEstimulo> calculos, IReactorInyectable reactor)
		{
			if (!this.m_flagInyectar)
			{
				return;
			}
			try
			{
				this.m_inyectado.emocion = this.m_Placer;
				this.m_inyectado.prioridad = 1000000000.0 / ((ICalculadorDeEstimulo)this).prioridad;
				calculos.Insert(0, this.m_inyectado);
			}
			finally
			{
				this.m_flagInyectar = false;
			}
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0005B074 File Offset: 0x00059274
		private void M_SemenParaAnus_onExpulsion(TipoDeSemen tipo, float llenadoW)
		{
			if (tipo == TipoDeSemen.water)
			{
				this.m_lastExpulsoW = llenadoW;
			}
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x0005B084 File Offset: 0x00059284
		protected override bool ReaccionarArgumento(object arg)
		{
			if (!this.m_semenParaHoleInit)
			{
				this.m_SemenParaAnus = this.GetComponentEnRoot(false);
				if (this.m_SemenParaAnus != null)
				{
					this.m_semenParaHoleInit = true;
				}
				this.m_SemenParaAnus.onExpulsion += this.M_SemenParaAnus_onExpulsion;
				return false;
			}
			bool flag;
			try
			{
				if (this.m_lastExpulsoW <= 0f)
				{
					flag = false;
				}
				else
				{
					float num = 100f;
					this.m_Dolor.ReduceValueNextUpdate(num);
					UmbralBasico.Estado estado = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado.rango = UmbralBasico.RangoEstado.enRango;
					estado.SobreEscribirEstimulacionGeneradaEnFrame(num, num, 1f);
					estado.offsetMod = 1f;
					estado.spotScore = SpotScore.enSpot;
					estado.spotRango = UmbralBasico.RangoEstado.enRango;
					this.m_inyectado.estado = estado;
					this.m_flagInyectar = true;
					if (this.m_lastExpulsoW >= 1f)
					{
						this.m_inyectorDeOrgasmReaction.ForzeOrgasmReaction();
					}
					flag = true;
				}
			}
			finally
			{
				this.m_lastExpulsoW = 0f;
			}
			return flag;
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x0005ADB7 File Offset: 0x00058FB7
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x0001FA5D File Offset: 0x0001DC5D
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x0001FA65 File Offset: 0x0001DC65
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x0001FA55 File Offset: 0x0001DC55
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x0005ADBF File Offset: 0x00058FBF
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0005ADC7 File Offset: 0x00058FC7
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04000DF9 RID: 3577
		private MainReactorGenerico m_MainReactorGenerico;

		// Token: 0x04000DFA RID: 3578
		private Placer m_Placer;

		// Token: 0x04000DFB RID: 3579
		private Dolor m_Dolor;

		// Token: 0x04000DFC RID: 3580
		private InyectorDeCalculoDeOrgasmo m_inyectorDeOrgasmReaction;

		// Token: 0x04000DFD RID: 3581
		[ReadOnlyUI]
		[SerializeField]
		private ParaReactorExpresionesPorExpulsionDeEnema.CalculoInyectado m_inyectado = new ParaReactorExpresionesPorExpulsionDeEnema.CalculoInyectado();

		// Token: 0x04000DFE RID: 3582
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagInyectar;

		// Token: 0x04000DFF RID: 3583
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastExpulsoW;

		// Token: 0x04000E00 RID: 3584
		private SemenParaAnus m_SemenParaAnus;

		// Token: 0x04000E01 RID: 3585
		private bool m_semenParaHoleInit;

		// Token: 0x020002FE RID: 766
		public class CalculoInyectado : ICalculoDeEstimulo, ICalculoDeEstimuloBuffeador, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando
		{
			// Token: 0x1700049F RID: 1183
			// (get) Token: 0x06001358 RID: 4952 RVA: 0x0005B19B File Offset: 0x0005939B
			// (set) Token: 0x06001359 RID: 4953 RVA: 0x0005B1A3 File Offset: 0x000593A3
			public bool causoMaxValue { get; set; }

			// Token: 0x0600135A RID: 4954 RVA: 0x0005B1AC File Offset: 0x000593AC
			public void Init(ICalculadorDeEstimulo Calculador)
			{
				if (Calculador == null)
				{
					throw new ArgumentNullException("Calculador", "Calculador null reference.");
				}
				this.m_calculador = Calculador;
			}

			// Token: 0x170004A0 RID: 1184
			// (get) Token: 0x0600135B RID: 4955 RVA: 0x0005B1C8 File Offset: 0x000593C8
			// (set) Token: 0x0600135C RID: 4956 RVA: 0x0005B1D0 File Offset: 0x000593D0
			public bool canProduceBuff { get; set; }

			// Token: 0x170004A1 RID: 1185
			// (get) Token: 0x0600135D RID: 4957 RVA: 0x0005B1D9 File Offset: 0x000593D9
			// (set) Token: 0x0600135E RID: 4958 RVA: 0x00023F85 File Offset: 0x00022185
			Emocion ICalculoDeEstimulo.emocion
			{
				get
				{
					return this.emocion;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170004A2 RID: 1186
			// (get) Token: 0x0600135F RID: 4959 RVA: 0x0005B1E1 File Offset: 0x000593E1
			double ICalculoDeEstimulo.prioridad
			{
				get
				{
					return this.prioridad;
				}
			}

			// Token: 0x170004A3 RID: 1187
			// (get) Token: 0x06001360 RID: 4960 RVA: 0x0005B1E9 File Offset: 0x000593E9
			// (set) Token: 0x06001361 RID: 4961 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return this.m_calculador;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170004A4 RID: 1188
			// (get) Token: 0x06001362 RID: 4962 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x06001363 RID: 4963 RVA: 0x00023F85 File Offset: 0x00022185
			public string tag
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170004A5 RID: 1189
			// (get) Token: 0x06001364 RID: 4964 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x06001365 RID: 4965 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170004A6 RID: 1190
			// (get) Token: 0x06001366 RID: 4966 RVA: 0x0005B1F1 File Offset: 0x000593F1
			// (set) Token: 0x06001367 RID: 4967 RVA: 0x0005B1F9 File Offset: 0x000593F9
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					return this.m_calculadorSec;
				}
				set
				{
					this.m_calculadorSec = value;
				}
			}

			// Token: 0x170004A7 RID: 1191
			// (get) Token: 0x06001368 RID: 4968 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170004A8 RID: 1192
			// (get) Token: 0x06001369 RID: 4969 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x170004A9 RID: 1193
			// (get) Token: 0x0600136A RID: 4970 RVA: 0x0005B202 File Offset: 0x00059402
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x0600136B RID: 4971 RVA: 0x0005B20F File Offset: 0x0005940F
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}

			// Token: 0x0600136C RID: 4972 RVA: 0x0005B217 File Offset: 0x00059417
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				if (index == 0)
				{
					estado = this.estado;
					return;
				}
				estado = default(UmbralBasico.Estado);
			}

			// Token: 0x0600136D RID: 4973 RVA: 0x0005B230 File Offset: 0x00059430
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x0600136E RID: 4974 RVA: 0x0005B23E File Offset: 0x0005943E
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
				if (index == 0)
				{
					this.estado = estado;
				}
			}

			// Token: 0x0600136F RID: 4975 RVA: 0x0005B24F File Offset: 0x0005944F
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				this.estado = masFuerte;
			}

			// Token: 0x06001370 RID: 4976 RVA: 0x0005B258 File Offset: 0x00059458
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				this.estado = estado;
			}

			// Token: 0x04000E03 RID: 3587
			private ICalculadorDeEstimulo m_calculador;

			// Token: 0x04000E04 RID: 3588
			private ICalculadorDeEstimulo m_calculadorSec;

			// Token: 0x04000E06 RID: 3590
			public Emocion emocion;

			// Token: 0x04000E07 RID: 3591
			public double prioridad;

			// Token: 0x04000E08 RID: 3592
			public UmbralBasico.Estado estado;
		}
	}
}
