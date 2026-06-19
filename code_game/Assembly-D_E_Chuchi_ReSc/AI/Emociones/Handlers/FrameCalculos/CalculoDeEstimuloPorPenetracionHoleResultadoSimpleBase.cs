using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000503 RID: 1283
	[Serializable]
	public abstract class CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase : ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloBuffeador, IPoolableItem
	{
		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06001E99 RID: 7833 RVA: 0x00074931 File Offset: 0x00072B31
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x06001E9A RID: 7834 RVA: 0x00074939 File Offset: 0x00072B39
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x00074947 File Offset: 0x00072B47
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06001E9C RID: 7836 RVA: 0x0007495A File Offset: 0x00072B5A
		// (set) Token: 0x06001E9D RID: 7837 RVA: 0x00074967 File Offset: 0x00072B67
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

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06001E9E RID: 7838 RVA: 0x00074975 File Offset: 0x00072B75
		// (set) Token: 0x06001E9F RID: 7839 RVA: 0x00074982 File Offset: 0x00072B82
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

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06001EA0 RID: 7840 RVA: 0x0007495A File Offset: 0x00072B5A
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06001EA1 RID: 7841 RVA: 0x00074975 File Offset: 0x00072B75
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return this.data.estimulanteParteInvertido;
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06001EA2 RID: 7842
		public abstract float estimuloGeneradoEnFrame { get; }

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06001EA3 RID: 7843
		public abstract bool esSingleEstado { get; }

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06001EA4 RID: 7844
		public abstract int cantidadDeEstados { get; }

		// Token: 0x06001EA5 RID: 7845
		public abstract void GetEstadoCopia(int index, out UmbralBasico.Estado estado);

		// Token: 0x06001EA6 RID: 7846
		public abstract void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado);

		// Token: 0x06001EA7 RID: 7847
		public abstract void GetSingleEstado(out UmbralBasico.Estado estado);

		// Token: 0x06001EA8 RID: 7848
		public abstract void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado);

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06001EA9 RID: 7849 RVA: 0x00074990 File Offset: 0x00072B90
		// (set) Token: 0x06001EAA RID: 7850 RVA: 0x0007499D File Offset: 0x00072B9D
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

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06001EAB RID: 7851 RVA: 0x000749AB File Offset: 0x00072BAB
		// (set) Token: 0x06001EAC RID: 7852 RVA: 0x000749B3 File Offset: 0x00072BB3
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06001EAD RID: 7853 RVA: 0x000749BC File Offset: 0x00072BBC
		// (set) Token: 0x06001EAE RID: 7854 RVA: 0x000749C4 File Offset: 0x00072BC4
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

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06001EAF RID: 7855 RVA: 0x000749CD File Offset: 0x00072BCD
		public EstimuloPenetrante estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06001EB0 RID: 7856 RVA: 0x000749D5 File Offset: 0x00072BD5
		public EstimuloPenetrante estimuloInvertido
		{
			get
			{
				return this.m_estimuloInverted;
			}
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x06001EB1 RID: 7857 RVA: 0x000749D5 File Offset: 0x00072BD5
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return this.m_estimuloInverted;
			}
		}

		// Token: 0x06001EB2 RID: 7858 RVA: 0x000749DD File Offset: 0x00072BDD
		[Obsolete("", true)]
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.estado = masFuerte;
		}

		// Token: 0x06001EB3 RID: 7859 RVA: 0x00074357 File Offset: 0x00072557
		[Obsolete("", true)]
		public void GetEstadoReference(ref UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001EB4 RID: 7860 RVA: 0x000743DE File Offset: 0x000725DE
		[Obsolete("", true)]
		public UmbralBasico.Estado EstadoMasFuerte()
		{
			return this.data.estado;
		}

		// Token: 0x06001EB5 RID: 7861 RVA: 0x000749EB File Offset: 0x00072BEB
		public void SetEstimuloInstance(EstimuloPenetrante instance, EstimuloPenetrante instanceInveted)
		{
			this.m_estimulo = instance;
			this.m_estimuloInverted = instanceInveted;
		}

		// Token: 0x06001EB6 RID: 7862 RVA: 0x000749FB File Offset: 0x00072BFB
		public void Poblar(Emocion emo, ICalculadorDeEstimulo calculador)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.calculador = (MonoBehaviour)calculador;
		}

		// Token: 0x06001EB7 RID: 7863 RVA: 0x00074A34 File Offset: 0x00072C34
		public virtual void CopiarA(object result)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase = result as CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase;
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase == null)
			{
				return;
			}
			calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.m_estimulo, false);
			if (this.m_estimulo.tieneCopiaInvertida && this.m_estimuloInverted != null && calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.m_estimuloInverted != null)
			{
				this.m_estimuloInverted.CopiarA(calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.m_estimuloInverted, false);
				return;
			}
			EstimuloPenetrante estimuloInverted = calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.m_estimuloInverted;
			if (estimuloInverted == null)
			{
				return;
			}
			estimuloInverted.Clear();
		}

		// Token: 0x06001EB8 RID: 7864 RVA: 0x00074AAA File Offset: 0x00072CAA
		public virtual void Clear()
		{
			this.data = default(CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.Data);
			this.m_estimulo.Clear();
			EstimuloPenetrante estimuloInverted = this.m_estimuloInverted;
			if (estimuloInverted == null)
			{
				return;
			}
			estimuloInverted.Clear();
		}

		// Token: 0x06001EB9 RID: 7865 RVA: 0x00074AD4 File Offset: 0x00072CD4
		public bool Convinable(object other)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase = other as CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase;
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase == null)
			{
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes tags");
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.estimulanteParte != this.data.estimulanteParte)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes estimulanteParte");
				return false;
			}
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.m_estimulo.tipoDeEstimuloCoital != this.m_estimulo.tipoDeEstimuloCoital)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado de diferentes tipoDeEstimuloCoital");
				return false;
			}
			if (!this.m_estimulo.Convinable(calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.m_estimulo))
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloPorPenetracionHoleResultado estimulo no es convinable");
				return false;
			}
			return true;
		}

		// Token: 0x06001EBA RID: 7866 RVA: 0x00074BA8 File Offset: 0x00072DA8
		public void Convinar(object other)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase = other as CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase;
			if (calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.estimulanteParte;
			}
			if (this.data.estimulanteParteInvertido == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParteInvertido = calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.estimulanteParteInvertido;
			}
			this.data.estado.Convinar(ref calculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.data.estado);
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06001EBB RID: 7867 RVA: 0x00074C6D File Offset: 0x00072E6D
		// (set) Token: 0x06001EBC RID: 7868 RVA: 0x00074C7F File Offset: 0x00072E7F
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

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06001EBD RID: 7869 RVA: 0x00074C92 File Offset: 0x00072E92
		// (set) Token: 0x06001EBE RID: 7870 RVA: 0x00074CA4 File Offset: 0x00072EA4
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

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06001EBF RID: 7871 RVA: 0x00074CB7 File Offset: 0x00072EB7
		// (set) Token: 0x06001EC0 RID: 7872 RVA: 0x00074CC4 File Offset: 0x00072EC4
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

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x06001EC1 RID: 7873 RVA: 0x00074CD2 File Offset: 0x00072ED2
		// (set) Token: 0x06001EC2 RID: 7874 RVA: 0x00074CDF File Offset: 0x00072EDF
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

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06001EC3 RID: 7875 RVA: 0x00074CED File Offset: 0x00072EED
		// (set) Token: 0x06001EC4 RID: 7876 RVA: 0x00074CFA File Offset: 0x00072EFA
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

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06001EC5 RID: 7877 RVA: 0x00074D08 File Offset: 0x00072F08
		EstimuloPenetrante ICalculoDeEstimulo<EstimuloPenetrante>.estimulo
		{
			get
			{
				return this.estimulo;
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06001EC6 RID: 7878 RVA: 0x00074D10 File Offset: 0x00072F10
		public double prioridad
		{
			get
			{
				if (this.m_estimulo == null)
				{
					return 0.0;
				}
				Emocion emocion = this.data.emocion;
				return this.Prioridad((emocion != null) ? emocion.owner : null, this.m_estimulo, new UmbralBasico.Estado?(this.data.estado), new ParteQuePuedeEstimular?(this.data.estimulanteParte), (double)this.m_estimulo.tipoDeEstimuloCoital.Prioridad() * this.m_prioridadMod, 0.0);
			}
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06001EC7 RID: 7879 RVA: 0x00074D08 File Offset: 0x00072F08
		InteracionEstimulanteBasica ICalculoDeInteracionEstimulante.estimuloBasico
		{
			get
			{
				return this.estimulo;
			}
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x00074D93 File Offset: 0x00072F93
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloConEstado.EstadoMasFuerte()
		{
			return this.EstadoMasFuerte();
		}

		// Token: 0x04001463 RID: 5219
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x04001465 RID: 5221
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x04001466 RID: 5222
		public CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase.Data data;

		// Token: 0x04001467 RID: 5223
		[SerializeField]
		private EstimuloPenetrante m_estimulo = new EstimuloPenetrante();

		// Token: 0x04001468 RID: 5224
		[SerializeField]
		private EstimuloPenetrante m_estimuloInverted = new EstimuloPenetrante();

		// Token: 0x02000504 RID: 1284
		[Serializable]
		public struct Data
		{
			// Token: 0x17000830 RID: 2096
			// (get) Token: 0x06001ECA RID: 7882 RVA: 0x00074DCF File Offset: 0x00072FCF
			// (set) Token: 0x06001ECB RID: 7883 RVA: 0x00074DD7 File Offset: 0x00072FD7
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

			// Token: 0x17000831 RID: 2097
			// (get) Token: 0x06001ECC RID: 7884 RVA: 0x00074DE0 File Offset: 0x00072FE0
			// (set) Token: 0x06001ECD RID: 7885 RVA: 0x00074DE8 File Offset: 0x00072FE8
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

			// Token: 0x04001469 RID: 5225
			public string tag;

			// Token: 0x0400146A RID: 5226
			public Emocion emocion;

			// Token: 0x0400146B RID: 5227
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x0400146C RID: 5228
			public UmbralBasico.Estado estado;

			// Token: 0x0400146D RID: 5229
			public MonoBehaviour calculador;

			// Token: 0x0400146E RID: 5230
			public MonoBehaviour calculadorSec;

			// Token: 0x0400146F RID: 5231
			public bool causoMaxValue;

			// Token: 0x04001470 RID: 5232
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParte;

			// Token: 0x04001471 RID: 5233
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParteInvertido;
		}
	}
}
