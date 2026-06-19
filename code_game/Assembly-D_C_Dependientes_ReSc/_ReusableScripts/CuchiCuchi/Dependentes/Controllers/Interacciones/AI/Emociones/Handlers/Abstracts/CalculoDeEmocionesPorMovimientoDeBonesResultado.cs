using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x0200020D RID: 525
	[Serializable]
	public class CalculoDeEmocionesPorMovimientoDeBonesResultado : ICalculoDeEstimuloPorMovimientoDeBones, ICalculoDeEstimulo<EstimuloPorManipulacionDeBone>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloReaccionable, ICalculoDeEstimuloBuffeador, IPoolableItem
	{
		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000D26 RID: 3366 RVA: 0x0003BB07 File Offset: 0x00039D07
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x0003BB0F File Offset: 0x00039D0F
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x0003BB1D File Offset: 0x00039D1D
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x0003BB30 File Offset: 0x00039D30
		// (set) Token: 0x06000D2A RID: 3370 RVA: 0x0003BB3D File Offset: 0x00039D3D
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

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00002BE7 File Offset: 0x00000DE7
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00023F85 File Offset: 0x00022185
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

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x0003BB30 File Offset: 0x00039D30
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return ParteQuePuedeEstimular.None;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x0003BB4B File Offset: 0x00039D4B
		public float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x000066D6 File Offset: 0x000048D6
		public int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000D31 RID: 3377 RVA: 0x000066D6 File Offset: 0x000048D6
		public bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x0003BB5D File Offset: 0x00039D5D
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x0003BB7A File Offset: 0x00039D7A
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x0003BB90 File Offset: 0x00039D90
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x0003BBA3 File Offset: 0x00039DA3
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x0003BBB6 File Offset: 0x00039DB6
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x0003BBC3 File Offset: 0x00039DC3
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

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x0003BBD1 File Offset: 0x00039DD1
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x0003BBD9 File Offset: 0x00039DD9
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

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x0003BBE2 File Offset: 0x00039DE2
		public EstimuloPorManipulacionDeBone estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x00023ABA File Offset: 0x00021CBA
		public EstimuloPorManipulacionDeBone estimuloInvertido
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x00023ABA File Offset: 0x00021CBA
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x0003BBEA File Offset: 0x00039DEA
		public void SetEstimuloInstance(EstimuloPorManipulacionDeBone instance, EstimuloPorManipulacionDeBone instanceInveted)
		{
			this.m_estimulo = instance;
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0003BBF4 File Offset: 0x00039DF4
		public void Poblar(Emocion emo, ICalculadorDeEstimuloDeMovimientoDeBones calculador, TipoDeCalculoDeEstimulo tipo)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.tipo = tipo;
			this.data.calculador = (MonoBehaviour)calculador;
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x0003BC43 File Offset: 0x00039E43
		public void Clear()
		{
			this.data = default(CalculoDeEmocionesPorMovimientoDeBonesResultado.Data);
			this.m_estimulo.Clear();
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x0003BC5C File Offset: 0x00039E5C
		public void CopiarA(object result)
		{
			CalculoDeEmocionesPorMovimientoDeBonesResultado calculoDeEmocionesPorMovimientoDeBonesResultado = result as CalculoDeEmocionesPorMovimientoDeBonesResultado;
			if (calculoDeEmocionesPorMovimientoDeBonesResultado == null)
			{
				return;
			}
			calculoDeEmocionesPorMovimientoDeBonesResultado.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEmocionesPorMovimientoDeBonesResultado.m_estimulo, false);
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0003BC92 File Offset: 0x00039E92
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.estado = masFuerte;
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x0003BCA0 File Offset: 0x00039EA0
		public UmbralBasico.Estado EstadoMasFuerte()
		{
			return this.data.estado;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0003BCB0 File Offset: 0x00039EB0
		public bool Convinable(object other)
		{
			CalculoDeEmocionesPorMovimientoDeBonesResultado calculoDeEmocionesPorMovimientoDeBonesResultado = other as CalculoDeEmocionesPorMovimientoDeBonesResultado;
			if (calculoDeEmocionesPorMovimientoDeBonesResultado == null)
			{
				return false;
			}
			if (calculoDeEmocionesPorMovimientoDeBonesResultado.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEmocionesPorMovimientoDeBonesResultado.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes tags");
				return false;
			}
			if (calculoDeEmocionesPorMovimientoDeBonesResultado.data.estimulanteParte != this.data.estimulanteParte)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes estimulanteParte");
				return false;
			}
			if (calculoDeEmocionesPorMovimientoDeBonesResultado.reaccionable != this.reaccionable)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes reaccionables");
				return false;
			}
			return this.m_estimulo.Convinable(calculoDeEmocionesPorMovimientoDeBonesResultado.m_estimulo);
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0003BD6C File Offset: 0x00039F6C
		public void Convinar(object other)
		{
			CalculoDeEmocionesPorMovimientoDeBonesResultado calculoDeEmocionesPorMovimientoDeBonesResultado = other as CalculoDeEmocionesPorMovimientoDeBonesResultado;
			if (calculoDeEmocionesPorMovimientoDeBonesResultado == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEmocionesPorMovimientoDeBonesResultado.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEmocionesPorMovimientoDeBonesResultado.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEmocionesPorMovimientoDeBonesResultado.data.estimulanteParte;
			}
			this.data.estado.Convinar(ref calculoDeEmocionesPorMovimientoDeBonesResultado.data.estado);
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x0003BE0E File Offset: 0x0003A00E
		// (set) Token: 0x06000D46 RID: 3398 RVA: 0x0003BE1B File Offset: 0x0003A01B
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

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x0003BBE2 File Offset: 0x00039DE2
		public InteracionEstimulanteBasica estimuloBasico
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x0003BE2C File Offset: 0x0003A02C
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

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x0003BEA1 File Offset: 0x0003A0A1
		// (set) Token: 0x06000D4A RID: 3402 RVA: 0x0003BEB3 File Offset: 0x0003A0B3
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

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x0003BEC6 File Offset: 0x0003A0C6
		// (set) Token: 0x06000D4C RID: 3404 RVA: 0x0003BED8 File Offset: 0x0003A0D8
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

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x0003BEEB File Offset: 0x0003A0EB
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x0003BEF8 File Offset: 0x0003A0F8
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

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x0003BF06 File Offset: 0x0003A106
		// (set) Token: 0x06000D50 RID: 3408 RVA: 0x0003BF13 File Offset: 0x0003A113
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

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000D51 RID: 3409 RVA: 0x0003BBE2 File Offset: 0x00039DE2
		EstimuloPorManipulacionDeBone ICalculoDeEstimulo<EstimuloPorManipulacionDeBone>.estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x0003BF21 File Offset: 0x0003A121
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x0003BF29 File Offset: 0x0003A129
		public bool reaccionable { get; set; } = true;

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x0003BF32 File Offset: 0x0003A132
		// (set) Token: 0x06000D55 RID: 3413 RVA: 0x0003BF3A File Offset: 0x0003A13A
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x0003BF43 File Offset: 0x0003A143
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x0003BF4B File Offset: 0x0003A14B
		public bool ignorarCoolDown { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x0003BF54 File Offset: 0x0003A154
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x0003BF5C File Offset: 0x0003A15C
		public bool ignorarProbabilidad { get; set; }

		// Token: 0x04000904 RID: 2308
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x04000905 RID: 2309
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x04000906 RID: 2310
		public CalculoDeEmocionesPorMovimientoDeBonesResultado.Data data;

		// Token: 0x04000907 RID: 2311
		[SerializeField]
		private EstimuloPorManipulacionDeBone m_estimulo = new EstimuloPorManipulacionDeBone();

		// Token: 0x0200020E RID: 526
		[Serializable]
		public struct Data
		{
			// Token: 0x0400090C RID: 2316
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x0400090D RID: 2317
			public ParteQuePuedeEstimular estimulanteParte;

			// Token: 0x0400090E RID: 2318
			public string tag;

			// Token: 0x0400090F RID: 2319
			public Emocion emocion;

			// Token: 0x04000910 RID: 2320
			public UmbralBasico.Estado estado;

			// Token: 0x04000911 RID: 2321
			public MonoBehaviour calculador;

			// Token: 0x04000912 RID: 2322
			public MonoBehaviour calculadorSec;

			// Token: 0x04000913 RID: 2323
			public bool causoMaxValue;
		}
	}
}
