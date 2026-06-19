using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004F3 RID: 1267
	[Serializable]
	public class CalculoDeEstimuloVisualResultado : ICalculoDeEstimuloVisual, ICalculoDeEstimulo<EstimuloVisual>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloReaccionable, ICalculoDeEstimuloBuffeador, IPoolableItem
	{
		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06001DC0 RID: 7616 RVA: 0x0007328F File Offset: 0x0007148F
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x00073297 File Offset: 0x00071497
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x000732A5 File Offset: 0x000714A5
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06001DC3 RID: 7619 RVA: 0x000732B8 File Offset: 0x000714B8
		// (set) Token: 0x06001DC4 RID: 7620 RVA: 0x000732C5 File Offset: 0x000714C5
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

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06001DC5 RID: 7621 RVA: 0x00004252 File Offset: 0x00002452
		// (set) Token: 0x06001DC6 RID: 7622 RVA: 0x00005A42 File Offset: 0x00003C42
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

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06001DC7 RID: 7623 RVA: 0x000732B8 File Offset: 0x000714B8
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06001DC8 RID: 7624 RVA: 0x00004252 File Offset: 0x00002452
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return ParteQuePuedeEstimular.None;
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06001DC9 RID: 7625 RVA: 0x000732D3 File Offset: 0x000714D3
		public float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06001DCA RID: 7626 RVA: 0x00005F51 File Offset: 0x00004151
		public int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x06001DCB RID: 7627 RVA: 0x00005F51 File Offset: 0x00004151
		public bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001DCC RID: 7628 RVA: 0x000732E5 File Offset: 0x000714E5
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x00073302 File Offset: 0x00071502
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x06001DCE RID: 7630 RVA: 0x00073318 File Offset: 0x00071518
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001DCF RID: 7631 RVA: 0x0007332B File Offset: 0x0007152B
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06001DD0 RID: 7632 RVA: 0x0007333E File Offset: 0x0007153E
		// (set) Token: 0x06001DD1 RID: 7633 RVA: 0x0007334B File Offset: 0x0007154B
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

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06001DD2 RID: 7634 RVA: 0x0007335C File Offset: 0x0007155C
		// (set) Token: 0x06001DD3 RID: 7635 RVA: 0x0007339D File Offset: 0x0007159D
		public bool reaccionable
		{
			get
			{
				if (this.m_reaccionable)
				{
					EstimuloVisual estimulo = this.m_estimulo;
					return !((estimulo != null) ? new bool?(estimulo.outOfRange) : null).GetValueOrDefault();
				}
				return false;
			}
			set
			{
				this.m_reaccionable = value;
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06001DD4 RID: 7636 RVA: 0x000733A6 File Offset: 0x000715A6
		// (set) Token: 0x06001DD5 RID: 7637 RVA: 0x000733AE File Offset: 0x000715AE
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06001DD6 RID: 7638 RVA: 0x000733B7 File Offset: 0x000715B7
		// (set) Token: 0x06001DD7 RID: 7639 RVA: 0x000733BF File Offset: 0x000715BF
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

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x06001DD8 RID: 7640 RVA: 0x000733C8 File Offset: 0x000715C8
		public EstimuloVisual estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x06001DD9 RID: 7641 RVA: 0x00006060 File Offset: 0x00004260
		public EstimuloVisual estimuloInvertido
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x06001DDA RID: 7642 RVA: 0x00006060 File Offset: 0x00004260
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x000733D0 File Offset: 0x000715D0
		public void Poblar(Emocion emo, ICalculadorDeEstimuloVisual calculador, TipoDeCalculoDeEstimulo tipo)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.tipo = tipo;
			this.data.calculador = (MonoBehaviour)calculador;
		}

		// Token: 0x06001DDC RID: 7644 RVA: 0x0007341F File Offset: 0x0007161F
		public void Clear()
		{
			this.data = default(CalculoDeEstimuloVisualResultado.Data);
			this.m_estimulo.Clear();
		}

		// Token: 0x06001DDD RID: 7645 RVA: 0x00073438 File Offset: 0x00071638
		public void CopiarA(object result)
		{
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado = result as CalculoDeEstimuloVisualResultado;
			if (calculoDeEstimuloVisualResultado == null)
			{
				return;
			}
			calculoDeEstimuloVisualResultado.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEstimuloVisualResultado.m_estimulo, false);
		}

		// Token: 0x06001DDE RID: 7646 RVA: 0x0007346E File Offset: 0x0007166E
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.estado = masFuerte;
		}

		// Token: 0x06001DDF RID: 7647 RVA: 0x0007347C File Offset: 0x0007167C
		public UmbralBasico.Estado EstadoMasFuerte()
		{
			return this.data.estado;
		}

		// Token: 0x06001DE0 RID: 7648 RVA: 0x00073318 File Offset: 0x00071518
		public void GetEstadoReference(ref UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x0007348C File Offset: 0x0007168C
		public bool Convinable(object other)
		{
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado = other as CalculoDeEstimuloVisualResultado;
			if (calculoDeEstimuloVisualResultado == null)
			{
				return false;
			}
			if (calculoDeEstimuloVisualResultado.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloVisualResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEstimuloVisualResultado.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloVisualResultado de diferentes tags");
				return false;
			}
			if (calculoDeEstimuloVisualResultado.m_estimulo.tipoDeEstimuloVisual != this.m_estimulo.tipoDeEstimuloVisual)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloVisualResultado de diferentes tipoDeEstimuloVisual");
				return false;
			}
			if (calculoDeEstimuloVisualResultado.reaccionable != this.reaccionable)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloVisualResultado de diferentes reaccionables");
				return false;
			}
			return this.m_estimulo.Convinable(calculoDeEstimuloVisualResultado.m_estimulo);
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x00073548 File Offset: 0x00071748
		public void Convinar(object other)
		{
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado = other as CalculoDeEstimuloVisualResultado;
			if (calculoDeEstimuloVisualResultado == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEstimuloVisualResultado.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEstimuloVisualResultado.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEstimuloVisualResultado.data.estimulanteParte;
			}
			this.data.estado.Convinar(ref calculoDeEstimuloVisualResultado.data.estado);
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x000735EA File Offset: 0x000717EA
		public void SetEstimuloInstance(EstimuloVisual instance, EstimuloVisual instanceInveted)
		{
			this.m_estimulo = instance;
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x06001DE4 RID: 7652 RVA: 0x000735F3 File Offset: 0x000717F3
		// (set) Token: 0x06001DE5 RID: 7653 RVA: 0x00073600 File Offset: 0x00071800
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

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06001DE6 RID: 7654 RVA: 0x000733C8 File Offset: 0x000715C8
		public InteracionEstimulanteBasica estimuloBasico
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06001DE7 RID: 7655 RVA: 0x00073610 File Offset: 0x00071810
		public double prioridad
		{
			get
			{
				if (this.m_estimulo == null)
				{
					return 0.0;
				}
				Emocion emocion = this.data.emocion;
				return this.PrioridadVisual((emocion != null) ? emocion.owner : null, this.m_estimulo, new UmbralBasico.Estado?(this.data.estado), new ParteQuePuedeEstimular?(this.data.estimulanteParte), this.m_prioridadMod, 0.0);
			}
		}

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06001DE8 RID: 7656 RVA: 0x00073681 File Offset: 0x00071881
		// (set) Token: 0x06001DE9 RID: 7657 RVA: 0x00073693 File Offset: 0x00071893
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

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06001DEA RID: 7658 RVA: 0x000736A6 File Offset: 0x000718A6
		// (set) Token: 0x06001DEB RID: 7659 RVA: 0x000736B8 File Offset: 0x000718B8
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

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x06001DEC RID: 7660 RVA: 0x000736CB File Offset: 0x000718CB
		// (set) Token: 0x06001DED RID: 7661 RVA: 0x000736D8 File Offset: 0x000718D8
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

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06001DEE RID: 7662 RVA: 0x000736E6 File Offset: 0x000718E6
		// (set) Token: 0x06001DEF RID: 7663 RVA: 0x000736F3 File Offset: 0x000718F3
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

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06001DF0 RID: 7664 RVA: 0x000733C8 File Offset: 0x000715C8
		EstimuloVisual ICalculoDeEstimulo<EstimuloVisual>.estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06001DF1 RID: 7665 RVA: 0x00073701 File Offset: 0x00071901
		// (set) Token: 0x06001DF2 RID: 7666 RVA: 0x00073709 File Offset: 0x00071909
		public bool ignorarCoolDown { get; set; }

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06001DF3 RID: 7667 RVA: 0x00073712 File Offset: 0x00071912
		// (set) Token: 0x06001DF4 RID: 7668 RVA: 0x0007371A File Offset: 0x0007191A
		public bool ignorarProbabilidad { get; set; }

		// Token: 0x04001445 RID: 5189
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x04001447 RID: 5191
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x04001448 RID: 5192
		[ReadOnlyUI]
		[SerializeField]
		private bool m_reaccionable = true;

		// Token: 0x04001449 RID: 5193
		public CalculoDeEstimuloVisualResultado.Data data;

		// Token: 0x0400144A RID: 5194
		[SerializeField]
		private EstimuloVisual m_estimulo = new EstimuloVisual();

		// Token: 0x020004F4 RID: 1268
		[Serializable]
		public struct Data
		{
			// Token: 0x0400144D RID: 5197
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x0400144E RID: 5198
			public string tag;

			// Token: 0x0400144F RID: 5199
			public Emocion emocion;

			// Token: 0x04001450 RID: 5200
			public ParteQuePuedeEstimular estimulanteParte;

			// Token: 0x04001451 RID: 5201
			public UmbralBasico.Estado estado;

			// Token: 0x04001452 RID: 5202
			public MonoBehaviour calculador;

			// Token: 0x04001453 RID: 5203
			public MonoBehaviour calculadorSec;

			// Token: 0x04001454 RID: 5204
			public bool causoMaxValue;
		}
	}
}
