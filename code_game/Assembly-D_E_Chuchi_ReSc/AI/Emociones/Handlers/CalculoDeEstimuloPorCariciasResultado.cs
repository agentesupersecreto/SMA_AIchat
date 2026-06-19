using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200048B RID: 1163
	[Serializable]
	public class CalculoDeEstimuloPorCariciasResultado : ICalculoDeEstimuloTactil, ICalculoDeEstimulo<EstimuloTactil>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloBuffeador, IPoolableItem
	{
		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x0006C001 File Offset: 0x0006A201
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x0006C009 File Offset: 0x0006A209
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x0006C017 File Offset: 0x0006A217
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06001AC9 RID: 6857 RVA: 0x0006C02A File Offset: 0x0006A22A
		// (set) Token: 0x06001ACA RID: 6858 RVA: 0x0006C037 File Offset: 0x0006A237
		ParteQuePuedeEstimular ICalculoDeEstimuloDeParteEstimulante.estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
			set
			{
				this.data.estimulanteParte = value;
			}
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06001ACB RID: 6859 RVA: 0x0006C045 File Offset: 0x0006A245
		// (set) Token: 0x06001ACC RID: 6860 RVA: 0x0006C052 File Offset: 0x0006A252
		ParteQuePuedeEstimular ICalculoDeEstimuloDeParteEstimulante.estimulanteParteInvertido
		{
			get
			{
				return this.data.estimulanteParteInvertido;
			}
			set
			{
				this.data.estimulanteParteInvertido = value;
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06001ACD RID: 6861 RVA: 0x0006C02A File Offset: 0x0006A22A
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001ACE RID: 6862 RVA: 0x0006C045 File Offset: 0x0006A245
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return this.data.estimulanteParteInvertido;
			}
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06001ACF RID: 6863 RVA: 0x0006C060 File Offset: 0x0006A260
		public float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x00005F51 File Offset: 0x00004151
		public int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06001AD1 RID: 6865 RVA: 0x00005F51 File Offset: 0x00004151
		public bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x0006C072 File Offset: 0x0006A272
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x0006C08F File Offset: 0x0006A28F
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x0006C0A5 File Offset: 0x0006A2A5
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x0006C0B8 File Offset: 0x0006A2B8
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06001AD6 RID: 6870 RVA: 0x0006C0CB File Offset: 0x0006A2CB
		// (set) Token: 0x06001AD7 RID: 6871 RVA: 0x0006C0D8 File Offset: 0x0006A2D8
		public bool causoMaxValue
		{
			get
			{
				return this.data.causoMaxValue;
			}
			set
			{
				this.data.causoMaxValue = value;
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06001AD8 RID: 6872 RVA: 0x0006C0E6 File Offset: 0x0006A2E6
		// (set) Token: 0x06001AD9 RID: 6873 RVA: 0x0006C0EE File Offset: 0x0006A2EE
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06001ADA RID: 6874 RVA: 0x0006C0F7 File Offset: 0x0006A2F7
		// (set) Token: 0x06001ADB RID: 6875 RVA: 0x0006C0FF File Offset: 0x0006A2FF
		double ICalculoDeEstimuloPrioridadModificable.prioridadMod
		{
			get
			{
				return this.m_prioridadMod;
			}
			set
			{
				this.m_prioridadMod = value;
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06001ADC RID: 6876 RVA: 0x0006C108 File Offset: 0x0006A308
		public EstimuloTactil estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x06001ADD RID: 6877 RVA: 0x0006C110 File Offset: 0x0006A310
		public EstimuloTactil estimuloInvertido
		{
			get
			{
				return this.m_estimuloInverted;
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x06001ADE RID: 6878 RVA: 0x0006C110 File Offset: 0x0006A310
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return this.m_estimuloInverted;
			}
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x0006C118 File Offset: 0x0006A318
		public void FixEstimuloInstanceTypes(EstimuloTactil instance, EstimuloTactil instanceInverted)
		{
			this.m_estimulo = instance;
			this.m_estimuloInverted = instanceInverted;
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x0006C118 File Offset: 0x0006A318
		public void SetEstimuloInstance(EstimuloTactil instance, EstimuloTactil instanceInverted)
		{
			this.m_estimulo = instance;
			this.m_estimuloInverted = instanceInverted;
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x0006C128 File Offset: 0x0006A328
		public void Poblar(Emocion emo, ICalculadorDeEstimuloTactil calculador, TipoDeCalculoDeEstimulo tipo)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.tipo = tipo;
			this.data.calculador = calculador as MonoBehaviour;
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x0006C178 File Offset: 0x0006A378
		public virtual void CopiarA(object result)
		{
			CalculoDeEstimuloPorCariciasResultado calculoDeEstimuloPorCariciasResultado = result as CalculoDeEstimuloPorCariciasResultado;
			if (calculoDeEstimuloPorCariciasResultado == null)
			{
				return;
			}
			ICalculadorDeEstimuloTactil calculadorDeEstimuloTactil = this.data.calculador as ICalculadorDeEstimuloTactil;
			if (calculadorDeEstimuloTactil != null)
			{
				calculadorDeEstimuloTactil.FixEstimulosInstancesTypes(this, calculoDeEstimuloPorCariciasResultado);
			}
			ICalculadorDeEstimuloTactil calculadorDeEstimuloTactil2 = this.data.calculadorSec as ICalculadorDeEstimuloTactil;
			if (calculadorDeEstimuloTactil2 != null)
			{
				calculadorDeEstimuloTactil2.FixEstimulosInstancesTypes(this, calculoDeEstimuloPorCariciasResultado);
			}
			calculoDeEstimuloPorCariciasResultado.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEstimuloPorCariciasResultado.m_estimulo, false);
			if (this.m_estimulo.tieneCopiaInvertida && this.m_estimuloInverted != null && calculoDeEstimuloPorCariciasResultado.m_estimuloInverted != null)
			{
				this.m_estimuloInverted.CopiarA(calculoDeEstimuloPorCariciasResultado.m_estimuloInverted, false);
				return;
			}
			EstimuloTactil estimuloInverted = calculoDeEstimuloPorCariciasResultado.m_estimuloInverted;
			if (estimuloInverted == null)
			{
				return;
			}
			estimuloInverted.Clear();
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x0006C228 File Offset: 0x0006A428
		public void Clear()
		{
			this.data = default(CalculoDeEstimuloPorCariciasResultado.Data);
			EstimuloTactil estimulo = this.m_estimulo;
			if (estimulo != null)
			{
				estimulo.Clear();
			}
			EstimuloTactil estimuloInverted = this.m_estimuloInverted;
			if (estimuloInverted == null)
			{
				return;
			}
			estimuloInverted.Clear();
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x0006C258 File Offset: 0x0006A458
		public bool Convinable(object other)
		{
			CalculoDeEstimuloPorCariciasResultado calculoDeEstimuloPorCariciasResultado = other as CalculoDeEstimuloPorCariciasResultado;
			if (calculoDeEstimuloPorCariciasResultado == null)
			{
				return false;
			}
			if (calculoDeEstimuloPorCariciasResultado.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorCariciasResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEstimuloPorCariciasResultado.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorCariciasResultado de diferentes tags");
				return false;
			}
			if (calculoDeEstimuloPorCariciasResultado.data.estimulanteParte != this.data.estimulanteParte)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorCariciasResultado de diferentes estimulanteParte");
				return false;
			}
			if (calculoDeEstimuloPorCariciasResultado.m_estimulo.tipoDeEstimuloTactil != this.m_estimulo.tipoDeEstimuloTactil)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorCariciasResultado de diferentes tipoDeEstimuloTactil");
				return false;
			}
			if (!this.m_estimulo.Convinable(calculoDeEstimuloPorCariciasResultado.m_estimulo))
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado estimulo no es convinable");
				return false;
			}
			return true;
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x0006C32C File Offset: 0x0006A52C
		public void Convinar(object other)
		{
			CalculoDeEstimuloPorCariciasResultado calculoDeEstimuloPorCariciasResultado = other as CalculoDeEstimuloPorCariciasResultado;
			if (calculoDeEstimuloPorCariciasResultado == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEstimuloPorCariciasResultado.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEstimuloPorCariciasResultado.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEstimuloPorCariciasResultado.data.estimulanteParte;
			}
			if (this.data.estimulanteParteInvertido == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParteInvertido = calculoDeEstimuloPorCariciasResultado.data.estimulanteParteInvertido;
			}
			this.data.estado.Convinar(ref calculoDeEstimuloPorCariciasResultado.data.estado);
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x06001AE6 RID: 6886 RVA: 0x0006C3F1 File Offset: 0x0006A5F1
		// (set) Token: 0x06001AE7 RID: 6887 RVA: 0x0006C403 File Offset: 0x0006A603
		ICalculadorDeEstimulo ICalculoDeEstimulo.producidoPor
		{
			get
			{
				return this.data.calculador as ICalculadorDeEstimulo;
			}
			set
			{
				this.data.calculador = value as MonoBehaviour;
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x06001AE8 RID: 6888 RVA: 0x0006C416 File Offset: 0x0006A616
		// (set) Token: 0x06001AE9 RID: 6889 RVA: 0x0006C428 File Offset: 0x0006A628
		public ICalculadorDeEstimulo producidoPorSegundario
		{
			get
			{
				return (ICalculadorDeEstimulo)this.data.calculadorSec;
			}
			set
			{
				this.data.calculadorSec = (MonoBehaviour)value;
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x06001AEA RID: 6890 RVA: 0x0006C43B File Offset: 0x0006A63B
		// (set) Token: 0x06001AEB RID: 6891 RVA: 0x0006C448 File Offset: 0x0006A648
		string ICalculoDeEstimulo.tag
		{
			get
			{
				return this.data.tag;
			}
			set
			{
				this.data.tag = value;
			}
		}

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x06001AEC RID: 6892 RVA: 0x0006C456 File Offset: 0x0006A656
		// (set) Token: 0x06001AED RID: 6893 RVA: 0x0006C463 File Offset: 0x0006A663
		Emocion ICalculoDeEstimulo.emocion
		{
			get
			{
				return this.data.emocion;
			}
			set
			{
				this.data.emocion = value;
			}
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x06001AEE RID: 6894 RVA: 0x0006C471 File Offset: 0x0006A671
		UmbralBasico.Estado ICalculoDeEstimuloTactil.estado
		{
			get
			{
				return this.data.estado;
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x06001AEF RID: 6895 RVA: 0x0006C47E File Offset: 0x0006A67E
		// (set) Token: 0x06001AF0 RID: 6896 RVA: 0x0006C48B File Offset: 0x0006A68B
		TipoDeCalculoDeEstimulo ICalculoDeEstimulo.tipo
		{
			get
			{
				return this.data.tipo;
			}
			set
			{
				this.data.tipo = value;
			}
		}

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x06001AF1 RID: 6897 RVA: 0x0006C499 File Offset: 0x0006A699
		EstimuloTactil ICalculoDeEstimulo<EstimuloTactil>.estimulo
		{
			get
			{
				return this.estimulo;
			}
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06001AF2 RID: 6898 RVA: 0x0006C4A4 File Offset: 0x0006A6A4
		double ICalculoDeEstimulo.prioridad
		{
			get
			{
				if (this.m_estimulo == null)
				{
					return 0.0;
				}
				Emocion emocion = this.data.emocion;
				return this.PrioridadTactil((emocion != null) ? emocion.owner : null, this.m_estimulo, new UmbralBasico.Estado?(this.data.estado), new ParteQuePuedeEstimular?(this.data.estimulanteParte), this.m_prioridadMod, 0.0);
			}
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06001AF3 RID: 6899 RVA: 0x0006C499 File Offset: 0x0006A699
		InteracionEstimulanteBasica ICalculoDeInteracionEstimulante.estimuloBasico
		{
			get
			{
				return this.estimulo;
			}
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x0006C0A5 File Offset: 0x0006A2A5
		public void GetEstadoReference(ref UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x0006C471 File Offset: 0x0006A671
		UmbralBasico.Estado ICalculoDeEstimuloConEstado.EstadoMasFuerte()
		{
			return this.data.estado;
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x0006C515 File Offset: 0x0006A715
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.estado = masFuerte;
		}

		// Token: 0x04001375 RID: 4981
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x04001377 RID: 4983
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x04001378 RID: 4984
		public CalculoDeEstimuloPorCariciasResultado.Data data;

		// Token: 0x04001379 RID: 4985
		[SerializeField]
		private EstimuloTactil m_estimulo = new EstimuloTactil();

		// Token: 0x0400137A RID: 4986
		[SerializeField]
		private EstimuloTactil m_estimuloInverted = new EstimuloTactil();

		// Token: 0x0200048C RID: 1164
		[Serializable]
		public struct Data
		{
			// Token: 0x170006E8 RID: 1768
			// (get) Token: 0x06001AF8 RID: 6904 RVA: 0x0006C557 File Offset: 0x0006A757
			// (set) Token: 0x06001AF9 RID: 6905 RVA: 0x0006C55F File Offset: 0x0006A75F
			public ParteQuePuedeEstimular estimulanteParte
			{
				get
				{
					return this.m_estimulanteParte;
				}
				set
				{
					this.m_estimulanteParte = value;
				}
			}

			// Token: 0x170006E9 RID: 1769
			// (get) Token: 0x06001AFA RID: 6906 RVA: 0x0006C568 File Offset: 0x0006A768
			// (set) Token: 0x06001AFB RID: 6907 RVA: 0x0006C570 File Offset: 0x0006A770
			public ParteQuePuedeEstimular estimulanteParteInvertido
			{
				get
				{
					return this.m_estimulanteParteInvertido;
				}
				set
				{
					this.m_estimulanteParteInvertido = value;
				}
			}

			// Token: 0x0400137B RID: 4987
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x0400137C RID: 4988
			public string tag;

			// Token: 0x0400137D RID: 4989
			public Emocion emocion;

			// Token: 0x0400137E RID: 4990
			public UmbralBasico.Estado estado;

			// Token: 0x0400137F RID: 4991
			public MonoBehaviour calculador;

			// Token: 0x04001380 RID: 4992
			public MonoBehaviour calculadorSec;

			// Token: 0x04001381 RID: 4993
			public bool causoMaxValue;

			// Token: 0x04001382 RID: 4994
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParte;

			// Token: 0x04001383 RID: 4995
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParteInvertido;
		}
	}
}
