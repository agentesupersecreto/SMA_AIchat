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
	// Token: 0x020002FB RID: 763
	public class ParaReactorDolorPorEnema : ParaReactor, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x000066D6 File Offset: 0x000048D6
		TipoDeCalculadorDeEstimulo ICalculadorDeEstimulo.tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.frame;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x0600131C RID: 4892 RVA: 0x0005AB67 File Offset: 0x00058D67
		Emocion ICalculadorDeEstimulo.emo
		{
			get
			{
				return this.m_Dolor;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x0600131D RID: 4893 RVA: 0x0005AB6F File Offset: 0x00058D6F
		double ICalculadorDeEstimulo.prioridad
		{
			get
			{
				return 9999.0 * Emocion.APrioridad(this.m_Dolor);
			}
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x0005AB88 File Offset: 0x00058D88
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
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
			this.m_inyectado.Init(this);
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x0005ABFD File Offset: 0x00058DFD
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_MainReactorGenerico.reaccionando += this.M_MainReactorGenerico_reaccionando;
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x0005AC1C File Offset: 0x00058E1C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_MainReactorGenerico != null)
			{
				this.m_MainReactorGenerico.reaccionando -= this.M_MainReactorGenerico_reaccionando;
			}
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x06001322 RID: 4898 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x06001323 RID: 4899 RVA: 0x0005AC4C File Offset: 0x00058E4C
		private void M_MainReactorGenerico_reaccionando(IList<ICalculoDeEstimulo> calculos, IReactorInyectable reactor)
		{
			if (!this.m_flagInyectar)
			{
				return;
			}
			try
			{
				this.m_inyectado.emocion = this.m_Dolor;
				this.m_inyectado.prioridad = 1000000000.0 / ((ICalculadorDeEstimulo)this).prioridad;
				calculos.Insert(0, this.m_inyectado);
			}
			finally
			{
				this.m_flagInyectar = false;
			}
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x0005ACB8 File Offset: 0x00058EB8
		protected override bool ReaccionarArgumento(object arg)
		{
			if (!this.m_semenParaHoleInit)
			{
				this.m_SemenParaAnus = this.GetComponentEnRoot(false);
				if (this.m_SemenParaAnus != null)
				{
					this.m_semenParaHoleInit = true;
				}
				return false;
			}
			float num;
			float num2;
			this.m_SemenParaAnus.MililitrosAcumulados(TipoDeSemen.water, out num, out num2);
			bool flag;
			try
			{
				float num3 = num2 - this.m_lastAcumulado;
				if (num3 <= 0.0001f)
				{
					flag = false;
				}
				else
				{
					float num4 = num3 * 100f;
					this.m_Dolor.IncreaseValueNextUpdate(num4 * 0.25f);
					UmbralBasico.Estado estado = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado.rango = UmbralBasico.RangoEstado.enRango;
					estado.SobreEscribirEstimulacionGeneradaEnFrame(num4, num4, 1f);
					estado.offsetMod = 1f;
					estado.spotScore = SpotScore.enSpot;
					estado.spotRango = UmbralBasico.RangoEstado.enRango;
					this.m_inyectado.estado = estado;
					this.m_flagInyectar = true;
					flag = true;
				}
			}
			finally
			{
				this.m_lastAcumulado = num2;
			}
			return flag;
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x0005ADB7 File Offset: 0x00058FB7
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x0001FA5D File Offset: 0x0001DC5D
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x0001FA65 File Offset: 0x0001DC65
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x0001FA55 File Offset: 0x0001DC55
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x0005ADBF File Offset: 0x00058FBF
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x0005ADC7 File Offset: 0x00058FC7
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04000DEB RID: 3563
		private MainReactorGenerico m_MainReactorGenerico;

		// Token: 0x04000DEC RID: 3564
		private Dolor m_Dolor;

		// Token: 0x04000DED RID: 3565
		[ReadOnlyUI]
		[SerializeField]
		private ParaReactorDolorPorEnema.CalculoInyectado m_inyectado = new ParaReactorDolorPorEnema.CalculoInyectado();

		// Token: 0x04000DEE RID: 3566
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastAcumulado;

		// Token: 0x04000DEF RID: 3567
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagInyectar;

		// Token: 0x04000DF0 RID: 3568
		private SemenParaAnus m_SemenParaAnus;

		// Token: 0x04000DF1 RID: 3569
		private bool m_semenParaHoleInit;

		// Token: 0x020002FC RID: 764
		public class CalculoInyectado : ICalculoDeEstimulo, ICalculoDeEstimuloBuffeador, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando
		{
			// Token: 0x17000491 RID: 1169
			// (get) Token: 0x0600132C RID: 4908 RVA: 0x0005ADCF File Offset: 0x00058FCF
			// (set) Token: 0x0600132D RID: 4909 RVA: 0x0005ADD7 File Offset: 0x00058FD7
			public bool causoMaxValue { get; set; }

			// Token: 0x0600132E RID: 4910 RVA: 0x0005ADE0 File Offset: 0x00058FE0
			public void Init(ICalculadorDeEstimulo Calculador)
			{
				if (Calculador == null)
				{
					throw new ArgumentNullException("Calculador", "Calculador null reference.");
				}
				this.m_calculador = Calculador;
			}

			// Token: 0x17000492 RID: 1170
			// (get) Token: 0x0600132F RID: 4911 RVA: 0x0005ADFC File Offset: 0x00058FFC
			// (set) Token: 0x06001330 RID: 4912 RVA: 0x0005AE04 File Offset: 0x00059004
			public bool canProduceBuff { get; set; }

			// Token: 0x17000493 RID: 1171
			// (get) Token: 0x06001331 RID: 4913 RVA: 0x0005AE0D File Offset: 0x0005900D
			// (set) Token: 0x06001332 RID: 4914 RVA: 0x00023F85 File Offset: 0x00022185
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

			// Token: 0x17000494 RID: 1172
			// (get) Token: 0x06001333 RID: 4915 RVA: 0x0005AE15 File Offset: 0x00059015
			double ICalculoDeEstimulo.prioridad
			{
				get
				{
					return this.prioridad;
				}
			}

			// Token: 0x17000495 RID: 1173
			// (get) Token: 0x06001334 RID: 4916 RVA: 0x0005AE1D File Offset: 0x0005901D
			// (set) Token: 0x06001335 RID: 4917 RVA: 0x00023F85 File Offset: 0x00022185
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

			// Token: 0x17000496 RID: 1174
			// (get) Token: 0x06001336 RID: 4918 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x06001337 RID: 4919 RVA: 0x00023F85 File Offset: 0x00022185
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

			// Token: 0x17000497 RID: 1175
			// (get) Token: 0x06001338 RID: 4920 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x06001339 RID: 4921 RVA: 0x00023F85 File Offset: 0x00022185
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

			// Token: 0x17000498 RID: 1176
			// (get) Token: 0x0600133A RID: 4922 RVA: 0x0005AE25 File Offset: 0x00059025
			// (set) Token: 0x0600133B RID: 4923 RVA: 0x0005AE2D File Offset: 0x0005902D
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

			// Token: 0x17000499 RID: 1177
			// (get) Token: 0x0600133C RID: 4924 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x1700049A RID: 1178
			// (get) Token: 0x0600133D RID: 4925 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x1700049B RID: 1179
			// (get) Token: 0x0600133E RID: 4926 RVA: 0x0005AE36 File Offset: 0x00059036
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x0600133F RID: 4927 RVA: 0x0005AE43 File Offset: 0x00059043
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}

			// Token: 0x06001340 RID: 4928 RVA: 0x0005AE4B File Offset: 0x0005904B
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				if (index == 0)
				{
					estado = this.estado;
					return;
				}
				estado = default(UmbralBasico.Estado);
			}

			// Token: 0x06001341 RID: 4929 RVA: 0x0005AE64 File Offset: 0x00059064
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06001342 RID: 4930 RVA: 0x0005AE72 File Offset: 0x00059072
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
				if (index == 0)
				{
					this.estado = estado;
				}
			}

			// Token: 0x06001343 RID: 4931 RVA: 0x0005AE83 File Offset: 0x00059083
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				this.estado = masFuerte;
			}

			// Token: 0x06001344 RID: 4932 RVA: 0x0005AE8C File Offset: 0x0005908C
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				this.estado = estado;
			}

			// Token: 0x04000DF3 RID: 3571
			private ICalculadorDeEstimulo m_calculador;

			// Token: 0x04000DF4 RID: 3572
			private ICalculadorDeEstimulo m_calculadorSec;

			// Token: 0x04000DF6 RID: 3574
			public Emocion emocion;

			// Token: 0x04000DF7 RID: 3575
			public double prioridad;

			// Token: 0x04000DF8 RID: 3576
			public UmbralBasico.Estado estado;
		}
	}
}
