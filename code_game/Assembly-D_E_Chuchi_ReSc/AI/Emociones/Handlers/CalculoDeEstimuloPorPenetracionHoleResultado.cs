using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000483 RID: 1155
	public class CalculoDeEstimuloPorPenetracionHoleResultado : ICalculoDeEstimuloCoitalHole, ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloCoitalHoleConSubTipoSegundario, ICalculoDeEstimuloCoitalHoleProfundaV2, ICalculoDeEstimuloCoitalHoleAncha, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloBuffeador, ICalculoDeEstimuloCoitalHoleVeloz, IPoolableItem
	{
		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06001A08 RID: 6664 RVA: 0x00069491 File Offset: 0x00067691
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x00069499 File Offset: 0x00067699
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x000694A7 File Offset: 0x000676A7
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06001A0B RID: 6667 RVA: 0x000694BA File Offset: 0x000676BA
		// (set) Token: 0x06001A0C RID: 6668 RVA: 0x000694C7 File Offset: 0x000676C7
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

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06001A0D RID: 6669 RVA: 0x000694D5 File Offset: 0x000676D5
		// (set) Token: 0x06001A0E RID: 6670 RVA: 0x000694E2 File Offset: 0x000676E2
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

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001A0F RID: 6671 RVA: 0x000694BA File Offset: 0x000676BA
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06001A10 RID: 6672 RVA: 0x000694D5 File Offset: 0x000676D5
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return this.data.estimulanteParteInvertido;
			}
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x000694F0 File Offset: 0x000676F0
		public void SetEstado(TipoDeEstimuloCoitalSegundaria tipo, ref UmbralBasico.Estado estado)
		{
			switch (tipo)
			{
			case TipoDeEstimuloCoitalSegundaria.velocidad:
				this.data.penetracion = estado;
				return;
			case TipoDeEstimuloCoitalSegundaria.apertura:
				this.data.apertura = estado;
				return;
			case TipoDeEstimuloCoitalSegundaria.movimientoDeCentro:
				this.data.movimiento = estado;
				return;
			case TipoDeEstimuloCoitalSegundaria.profundidad:
				this.data.profundidad = estado;
				return;
			case TipoDeEstimuloCoitalSegundaria.anchura:
				this.data.anchura = estado;
				return;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x00069587 File Offset: 0x00067787
		public void SetEstadoAny(ref UmbralBasico.Estado estado)
		{
			this.data.penetracion = estado;
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x0006959C File Offset: 0x0006779C
		public void GetEstados(out UmbralBasico.Estado penetracion, out UmbralBasico.Estado apertura, out UmbralBasico.Estado movimiento, out UmbralBasico.Estado profundidad, out UmbralBasico.Estado anchura)
		{
			penetracion = this.data.penetracion;
			apertura = this.data.apertura;
			movimiento = this.data.movimiento;
			profundidad = this.data.profundidad;
			anchura = this.data.anchura;
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x00069600 File Offset: 0x00067800
		public void GetEstadoProfundidadReference(out UmbralBasico.Estado profundidad)
		{
			profundidad = this.data.profundidad;
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x00069613 File Offset: 0x00067813
		public void GetEstadoAnchuraReference(out UmbralBasico.Estado anchura)
		{
			anchura = this.data.anchura;
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x00069626 File Offset: 0x00067826
		public void GetEstadoVelocidadReference(out UmbralBasico.Estado velocidad)
		{
			velocidad = this.data.penetracion;
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06001A17 RID: 6679 RVA: 0x00004252 File Offset: 0x00002452
		public bool esSingleEstado
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x00005A42 File Offset: 0x00003C42
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x00005A42 File Offset: 0x00003C42
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x06001A1A RID: 6682 RVA: 0x0006963C File Offset: 0x0006783C
		public float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.penetracion.estimulacionGeneradaEnFrame + this.data.apertura.estimulacionGeneradaEnFrame + this.data.movimiento.estimulacionGeneradaEnFrame + this.data.profundidad.estimulacionGeneradaEnFrame + this.data.anchura.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x06001A1B RID: 6683 RVA: 0x000438FE File Offset: 0x00041AFE
		public int cantidadDeEstados
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x000696A0 File Offset: 0x000678A0
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			switch (index)
			{
			case 0:
				estado = this.data.penetracion;
				return;
			case 1:
				estado = this.data.apertura;
				return;
			case 2:
				estado = this.data.movimiento;
				return;
			case 3:
				estado = this.data.profundidad;
				return;
			case 4:
				estado = this.data.anchura;
				return;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x00069730 File Offset: 0x00067930
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			switch (index)
			{
			case 0:
				this.data.penetracion = estado;
				return;
			case 1:
				this.data.apertura = estado;
				return;
			case 2:
				this.data.movimiento = estado;
				return;
			case 3:
				this.data.profundidad = estado;
				return;
			case 4:
				this.data.anchura = estado;
				return;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x000697BF File Offset: 0x000679BF
		public TipoDeEstimuloCoitalSegundaria GetTipoDeEstimuloCoitalSegundariaDeIndex(int estadoIndex)
		{
			switch (estadoIndex)
			{
			case 0:
				return TipoDeEstimuloCoitalSegundaria.velocidad;
			case 1:
				return TipoDeEstimuloCoitalSegundaria.apertura;
			case 2:
				return TipoDeEstimuloCoitalSegundaria.movimientoDeCentro;
			case 3:
				return TipoDeEstimuloCoitalSegundaria.profundidad;
			case 4:
				return TipoDeEstimuloCoitalSegundaria.anchura;
			default:
				throw new ArgumentOutOfRangeException(estadoIndex.ToString());
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06001A1F RID: 6687 RVA: 0x000697F3 File Offset: 0x000679F3
		// (set) Token: 0x06001A20 RID: 6688 RVA: 0x00069800 File Offset: 0x00067A00
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

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06001A21 RID: 6689 RVA: 0x0006980E File Offset: 0x00067A0E
		// (set) Token: 0x06001A22 RID: 6690 RVA: 0x00069816 File Offset: 0x00067A16
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06001A23 RID: 6691 RVA: 0x0006981F File Offset: 0x00067A1F
		// (set) Token: 0x06001A24 RID: 6692 RVA: 0x00069827 File Offset: 0x00067A27
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

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06001A25 RID: 6693 RVA: 0x00069830 File Offset: 0x00067A30
		public EstimuloPenetrante estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06001A26 RID: 6694 RVA: 0x00069838 File Offset: 0x00067A38
		public EstimuloPenetrante estimuloInvertido
		{
			get
			{
				return this.m_estimuloInverted;
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06001A27 RID: 6695 RVA: 0x00069838 File Offset: 0x00067A38
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return this.m_estimuloInverted;
			}
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x00069840 File Offset: 0x00067A40
		public void SetEstimuloInstance(EstimuloPenetrante instance, EstimuloPenetrante instanceInverted)
		{
			this.m_estimulo = instance;
			this.m_estimuloInverted = instanceInverted;
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x00069850 File Offset: 0x00067A50
		public void Poblar(Emocion emo, ICalculadorDeEstimulo calculador)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.calculador = (MonoBehaviour)calculador;
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x00069888 File Offset: 0x00067A88
		public virtual void CopiarA(object result)
		{
			CalculoDeEstimuloPorPenetracionHoleResultado calculoDeEstimuloPorPenetracionHoleResultado = result as CalculoDeEstimuloPorPenetracionHoleResultado;
			if (calculoDeEstimuloPorPenetracionHoleResultado == null)
			{
				return;
			}
			calculoDeEstimuloPorPenetracionHoleResultado.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEstimuloPorPenetracionHoleResultado.m_estimulo, false);
			if (this.m_estimulo.tieneCopiaInvertida && this.m_estimuloInverted != null && calculoDeEstimuloPorPenetracionHoleResultado.m_estimuloInverted != null)
			{
				this.m_estimuloInverted.CopiarA(calculoDeEstimuloPorPenetracionHoleResultado.m_estimuloInverted, false);
				return;
			}
			EstimuloPenetrante estimuloInverted = calculoDeEstimuloPorPenetracionHoleResultado.m_estimuloInverted;
			if (estimuloInverted == null)
			{
				return;
			}
			estimuloInverted.Clear();
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x000698FE File Offset: 0x00067AFE
		public virtual void Clear()
		{
			this.data = default(CalculoDeEstimuloPorPenetracionHoleResultado.Data);
			this.m_estimulo.Clear();
			EstimuloPenetrante estimuloInverted = this.m_estimuloInverted;
			if (estimuloInverted == null)
			{
				return;
			}
			estimuloInverted.Clear();
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x00069928 File Offset: 0x00067B28
		public bool Convinable(object other)
		{
			CalculoDeEstimuloPorPenetracionHoleResultado calculoDeEstimuloPorPenetracionHoleResultado = other as CalculoDeEstimuloPorPenetracionHoleResultado;
			if (calculoDeEstimuloPorPenetracionHoleResultado == null)
			{
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultado.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultado.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes tags");
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultado.data.estimulanteParte != this.data.estimulanteParte)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes estimulanteParte");
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultado.m_estimulo.tipoDeEstimuloCoital != this.m_estimulo.tipoDeEstimuloCoital)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes tipoDeEstimuloCoital");
				return false;
			}
			if (!this.m_estimulo.Convinable(calculoDeEstimuloPorPenetracionHoleResultado.m_estimulo))
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado estimulo no es convinable");
				return false;
			}
			return true;
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x00003B39 File Offset: 0x00001D39
		public void ConvinarInterval(object other, float cooldown)
		{
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x000699FC File Offset: 0x00067BFC
		public void Convinar(object other)
		{
			CalculoDeEstimuloPorPenetracionHoleResultado calculoDeEstimuloPorPenetracionHoleResultado = other as CalculoDeEstimuloPorPenetracionHoleResultado;
			if (calculoDeEstimuloPorPenetracionHoleResultado == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEstimuloPorPenetracionHoleResultado.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEstimuloPorPenetracionHoleResultado.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEstimuloPorPenetracionHoleResultado.data.estimulanteParte;
			}
			if (this.data.estimulanteParteInvertido == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParteInvertido = calculoDeEstimuloPorPenetracionHoleResultado.data.estimulanteParteInvertido;
			}
			this.data.penetracion.Convinar(ref calculoDeEstimuloPorPenetracionHoleResultado.data.penetracion);
			this.data.apertura.Convinar(ref calculoDeEstimuloPorPenetracionHoleResultado.data.apertura);
			this.data.movimiento.Convinar(ref calculoDeEstimuloPorPenetracionHoleResultado.data.movimiento);
			this.data.profundidad.Convinar(ref calculoDeEstimuloPorPenetracionHoleResultado.data.profundidad);
			this.data.anchura.Convinar(ref calculoDeEstimuloPorPenetracionHoleResultado.data.anchura);
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x06001A2F RID: 6703 RVA: 0x00069B2D File Offset: 0x00067D2D
		// (set) Token: 0x06001A30 RID: 6704 RVA: 0x00069B3F File Offset: 0x00067D3F
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

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06001A31 RID: 6705 RVA: 0x00069B52 File Offset: 0x00067D52
		// (set) Token: 0x06001A32 RID: 6706 RVA: 0x00069B64 File Offset: 0x00067D64
		ICalculadorDeEstimulo ICalculoDeEstimulo.producidoPor
		{
			get
			{
				return (ICalculadorDeEstimulo)this.data.calculador;
			}
			set
			{
				this.data.calculador = (MonoBehaviour)value;
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x06001A33 RID: 6707 RVA: 0x00069B77 File Offset: 0x00067D77
		// (set) Token: 0x06001A34 RID: 6708 RVA: 0x00069B84 File Offset: 0x00067D84
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

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06001A35 RID: 6709 RVA: 0x00069B92 File Offset: 0x00067D92
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.penetracion
		{
			get
			{
				return this.data.penetracion;
			}
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06001A36 RID: 6710 RVA: 0x00069B9F File Offset: 0x00067D9F
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.apertura
		{
			get
			{
				return this.data.apertura;
			}
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06001A37 RID: 6711 RVA: 0x00069BAC File Offset: 0x00067DAC
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.movimiento
		{
			get
			{
				return this.data.movimiento;
			}
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06001A38 RID: 6712 RVA: 0x00069BB9 File Offset: 0x00067DB9
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.profundidad
		{
			get
			{
				return this.data.profundidad;
			}
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06001A39 RID: 6713 RVA: 0x00069BC6 File Offset: 0x00067DC6
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.anchura
		{
			get
			{
				return this.data.anchura;
			}
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06001A3A RID: 6714 RVA: 0x00069BD3 File Offset: 0x00067DD3
		// (set) Token: 0x06001A3B RID: 6715 RVA: 0x00069BE0 File Offset: 0x00067DE0
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

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06001A3C RID: 6716 RVA: 0x00069BEE File Offset: 0x00067DEE
		// (set) Token: 0x06001A3D RID: 6717 RVA: 0x00069BFB File Offset: 0x00067DFB
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

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06001A3E RID: 6718 RVA: 0x00069C09 File Offset: 0x00067E09
		EstimuloPenetrante ICalculoDeEstimulo<EstimuloPenetrante>.estimulo
		{
			get
			{
				return this.estimulo;
			}
		}

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x06001A3F RID: 6719 RVA: 0x00069C14 File Offset: 0x00067E14
		public double prioridad
		{
			get
			{
				if (this.m_estimulo == null)
				{
					return 0.0;
				}
				Emocion emocion = this.data.emocion;
				return this.PrioridadCoital((emocion != null) ? emocion.owner : null, this.m_estimulo, new UmbralBasico.Estado?(this.data.penetracion), new UmbralBasico.Estado?(this.data.apertura), new UmbralBasico.Estado?(this.data.movimiento), new UmbralBasico.Estado?(this.data.profundidad), new UmbralBasico.Estado?(this.data.anchura), new ParteQuePuedeEstimular?(this.data.estimulanteParte), this.m_prioridadMod, 0.0);
			}
		}

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06001A40 RID: 6720 RVA: 0x00069C09 File Offset: 0x00067E09
		InteracionEstimulanteBasica ICalculoDeInteracionEstimulante.estimuloBasico
		{
			get
			{
				return this.estimulo;
			}
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x00069CC5 File Offset: 0x00067EC5
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.overriden = new UmbralBasico.Estado?(masFuerte);
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x00069CD8 File Offset: 0x00067ED8
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloConEstado.EstadoMasFuerte()
		{
			if (this.data.overriden != null)
			{
				return this.data.overriden.Value;
			}
			return this.GetMasFuerte();
		}

		// Token: 0x0400134B RID: 4939
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x0400134D RID: 4941
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x0400134E RID: 4942
		public CalculoDeEstimuloPorPenetracionHoleResultado.Data data;

		// Token: 0x0400134F RID: 4943
		[SerializeField]
		private EstimuloPenetrante m_estimulo = new EstimuloPenetrante();

		// Token: 0x04001350 RID: 4944
		[SerializeField]
		private EstimuloPenetrante m_estimuloInverted = new EstimuloPenetrante();

		// Token: 0x02000484 RID: 1156
		[Serializable]
		public struct Data
		{
			// Token: 0x170006A4 RID: 1700
			// (get) Token: 0x06001A44 RID: 6724 RVA: 0x00069D37 File Offset: 0x00067F37
			// (set) Token: 0x06001A45 RID: 6725 RVA: 0x00069D3F File Offset: 0x00067F3F
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

			// Token: 0x170006A5 RID: 1701
			// (get) Token: 0x06001A46 RID: 6726 RVA: 0x00069D48 File Offset: 0x00067F48
			// (set) Token: 0x06001A47 RID: 6727 RVA: 0x00069D50 File Offset: 0x00067F50
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

			// Token: 0x04001351 RID: 4945
			public string tag;

			// Token: 0x04001352 RID: 4946
			public Emocion emocion;

			// Token: 0x04001353 RID: 4947
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x04001354 RID: 4948
			public UmbralBasico.Estado penetracion;

			// Token: 0x04001355 RID: 4949
			public UmbralBasico.Estado apertura;

			// Token: 0x04001356 RID: 4950
			public UmbralBasico.Estado movimiento;

			// Token: 0x04001357 RID: 4951
			public UmbralBasico.Estado profundidad;

			// Token: 0x04001358 RID: 4952
			public UmbralBasico.Estado anchura;

			// Token: 0x04001359 RID: 4953
			public UmbralBasico.Estado? overriden;

			// Token: 0x0400135A RID: 4954
			public MonoBehaviour calculador;

			// Token: 0x0400135B RID: 4955
			public MonoBehaviour calculadorSec;

			// Token: 0x0400135C RID: 4956
			public bool causoMaxValue;

			// Token: 0x0400135D RID: 4957
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParte;

			// Token: 0x0400135E RID: 4958
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParteInvertido;
		}
	}
}
