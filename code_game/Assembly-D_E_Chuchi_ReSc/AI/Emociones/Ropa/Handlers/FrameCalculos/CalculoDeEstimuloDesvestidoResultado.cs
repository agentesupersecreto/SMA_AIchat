using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x02000424 RID: 1060
	[Serializable]
	public class CalculoDeEstimuloDesvestidoResultado : ICalculoDeEstimuloPorDesvestir, ICalculoDeEstimulo<EstimuloPorDesvestir>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloReaccionable, ICalculoDeEstimuloBuffeador, IPoolableItem
	{
		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x0600175A RID: 5978 RVA: 0x0005F433 File Offset: 0x0005D633
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0005F43B File Offset: 0x0005D63B
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x0005F449 File Offset: 0x0005D649
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x0005F45C File Offset: 0x0005D65C
		// (set) Token: 0x0600175E RID: 5982 RVA: 0x0005F469 File Offset: 0x0005D669
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

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x00004252 File Offset: 0x00002452
		// (set) Token: 0x06001760 RID: 5984 RVA: 0x00005A42 File Offset: 0x00003C42
		ParteQuePuedeEstimular ICalculoDeEstimuloDeParteEstimulante.estimulanteParteInvertido
		{
			get
			{
				return ParteQuePuedeEstimular.None;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06001761 RID: 5985 RVA: 0x0005F45C File Offset: 0x0005D65C
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x00004252 File Offset: 0x00002452
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return ParteQuePuedeEstimular.None;
			}
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06001763 RID: 5987 RVA: 0x0005F477 File Offset: 0x0005D677
		public float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x00005F51 File Offset: 0x00004151
		public int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001765 RID: 5989 RVA: 0x00005F51 File Offset: 0x00004151
		public bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0005F489 File Offset: 0x0005D689
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0005F4A6 File Offset: 0x0005D6A6
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x0005F4BC File Offset: 0x0005D6BC
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x0005F4CF File Offset: 0x0005D6CF
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x0005F4E2 File Offset: 0x0005D6E2
		// (set) Token: 0x0600176B RID: 5995 RVA: 0x0005F4EF File Offset: 0x0005D6EF
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

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x0005F4FD File Offset: 0x0005D6FD
		// (set) Token: 0x0600176D RID: 5997 RVA: 0x0005F505 File Offset: 0x0005D705
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

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x0005F50E File Offset: 0x0005D70E
		public EstimuloPorDesvestir estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x0600176F RID: 5999 RVA: 0x00006060 File Offset: 0x00004260
		public EstimuloPorDesvestir estimuloInvertido
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x00006060 File Offset: 0x00004260
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x0005F518 File Offset: 0x0005D718
		public void Poblar(Emocion emo, ICalculadorDeEstimuloPorDesvestir calculador, TipoDeCalculoDeEstimulo tipo)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.tipo = tipo;
			this.data.calculador = (MonoBehaviour)calculador;
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x0005F567 File Offset: 0x0005D767
		public void Clear()
		{
			this.data = default(CalculoDeEstimuloDesvestidoResultado.Data);
			this.m_estimulo.Clear();
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x0005F580 File Offset: 0x0005D780
		public void SetEstimuloInstance(EstimuloPorDesvestir instance, EstimuloPorDesvestir instanceInveted)
		{
			this.m_estimulo = instance;
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x0005F58C File Offset: 0x0005D78C
		public void CopiarA(object result)
		{
			CalculoDeEstimuloDesvestidoResultado calculoDeEstimuloDesvestidoResultado = result as CalculoDeEstimuloDesvestidoResultado;
			if (calculoDeEstimuloDesvestidoResultado == null)
			{
				return;
			}
			calculoDeEstimuloDesvestidoResultado.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEstimuloDesvestidoResultado.m_estimulo, false);
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x0005F5C2 File Offset: 0x0005D7C2
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.estado = masFuerte;
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x0005F5D0 File Offset: 0x0005D7D0
		public UmbralBasico.Estado EstadoMasFuerte()
		{
			return this.data.estado;
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x0005F4BC File Offset: 0x0005D6BC
		public void GetEstadoReference(ref UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x0005F5E0 File Offset: 0x0005D7E0
		public bool Convinable(object other)
		{
			CalculoDeEstimuloDesvestidoResultado calculoDeEstimuloDesvestidoResultado = other as CalculoDeEstimuloDesvestidoResultado;
			if (calculoDeEstimuloDesvestidoResultado == null)
			{
				return false;
			}
			if (calculoDeEstimuloDesvestidoResultado.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEstimuloDesvestidoResultado.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes tags");
				return false;
			}
			if (calculoDeEstimuloDesvestidoResultado.data.estimulanteParte != this.data.estimulanteParte)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes estimulanteParte");
				return false;
			}
			if (calculoDeEstimuloDesvestidoResultado.reaccionable != this.reaccionable)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes reaccionables");
				return false;
			}
			return this.m_estimulo.Convinable(calculoDeEstimuloDesvestidoResultado.m_estimulo);
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x0005F69C File Offset: 0x0005D89C
		public void Convinar(object other)
		{
			CalculoDeEstimuloDesvestidoResultado calculoDeEstimuloDesvestidoResultado = other as CalculoDeEstimuloDesvestidoResultado;
			if (calculoDeEstimuloDesvestidoResultado == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEstimuloDesvestidoResultado.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEstimuloDesvestidoResultado.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEstimuloDesvestidoResultado.data.estimulanteParte;
			}
			this.data.estado.Convinar(ref calculoDeEstimuloDesvestidoResultado.data.estado);
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x0005F73E File Offset: 0x0005D93E
		// (set) Token: 0x0600177B RID: 6011 RVA: 0x0005F74B File Offset: 0x0005D94B
		public Emocion emocion
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

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x0005F50E File Offset: 0x0005D70E
		public InteracionEstimulanteBasica estimuloBasico
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x0600177D RID: 6013 RVA: 0x0005F75C File Offset: 0x0005D95C
		public double prioridad
		{
			get
			{
				if (this.m_estimulo == null)
				{
					return 0.0;
				}
				Emocion emocion = this.data.emocion;
				return this.Prioridad((emocion != null) ? emocion.owner : null, this.m_estimulo, new UmbralBasico.Estado?(this.data.estado), new ParteQuePuedeEstimular?(ParteQuePuedeEstimular.ojos), 2.0 * this.m_prioridadMod, 0.0);
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x0005F7D1 File Offset: 0x0005D9D1
		// (set) Token: 0x0600177F RID: 6015 RVA: 0x0005F7E3 File Offset: 0x0005D9E3
		public ICalculadorDeEstimulo producidoPor
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

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0005F7F6 File Offset: 0x0005D9F6
		// (set) Token: 0x06001781 RID: 6017 RVA: 0x0005F808 File Offset: 0x0005DA08
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

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0005F81B File Offset: 0x0005DA1B
		// (set) Token: 0x06001783 RID: 6019 RVA: 0x0005F828 File Offset: 0x0005DA28
		public string tag
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

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x0005F836 File Offset: 0x0005DA36
		// (set) Token: 0x06001785 RID: 6021 RVA: 0x0005F843 File Offset: 0x0005DA43
		public TipoDeCalculoDeEstimulo tipo
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

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0005F50E File Offset: 0x0005D70E
		EstimuloPorDesvestir ICalculoDeEstimulo<EstimuloPorDesvestir>.estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06001787 RID: 6023 RVA: 0x0005F851 File Offset: 0x0005DA51
		// (set) Token: 0x06001788 RID: 6024 RVA: 0x0005F859 File Offset: 0x0005DA59
		public bool reaccionable { get; set; } = true;

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06001789 RID: 6025 RVA: 0x0005F862 File Offset: 0x0005DA62
		// (set) Token: 0x0600178A RID: 6026 RVA: 0x0005F86A File Offset: 0x0005DA6A
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x0600178B RID: 6027 RVA: 0x0005F873 File Offset: 0x0005DA73
		// (set) Token: 0x0600178C RID: 6028 RVA: 0x0005F87B File Offset: 0x0005DA7B
		public bool ignorarCoolDown { get; set; }

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x0600178D RID: 6029 RVA: 0x0005F884 File Offset: 0x0005DA84
		// (set) Token: 0x0600178E RID: 6030 RVA: 0x0005F88C File Offset: 0x0005DA8C
		public bool ignorarProbabilidad { get; set; }

		// Token: 0x0400120A RID: 4618
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x0400120B RID: 4619
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x0400120C RID: 4620
		public CalculoDeEstimuloDesvestidoResultado.Data data;

		// Token: 0x0400120D RID: 4621
		[SerializeField]
		private EstimuloPorDesvestir m_estimulo = new EstimuloPorDesvestir();

		// Token: 0x02000425 RID: 1061
		[Serializable]
		public struct Data
		{
			// Token: 0x04001212 RID: 4626
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x04001213 RID: 4627
			public ParteQuePuedeEstimular estimulanteParte;

			// Token: 0x04001214 RID: 4628
			public string tag;

			// Token: 0x04001215 RID: 4629
			public Emocion emocion;

			// Token: 0x04001216 RID: 4630
			public UmbralBasico.Estado estado;

			// Token: 0x04001217 RID: 4631
			public MonoBehaviour calculador;

			// Token: 0x04001218 RID: 4632
			public MonoBehaviour calculadorSec;

			// Token: 0x04001219 RID: 4633
			public bool causoMaxValue;
		}
	}
}
