using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x02000206 RID: 518
	[Serializable]
	public class CalculoDeEstimuloCambioDePoseResultado : ICalculoDeEstimuloPorCambioDePose, ICalculoDeEstimulo<EstimuloPorCambiarPose>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICopiableA, IConvinable, IEsConvinable, ICalculoDeEstimuloPrioridadModificable, ICalculoDeEstimuloReaccionable, ICalculoDeEstimuloBuffeador, IPoolableItem
	{
		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0003B15B File Offset: 0x0003935B
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x0003B163 File Offset: 0x00039363
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0003B171 File Offset: 0x00039371
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x0003B184 File Offset: 0x00039384
		// (set) Token: 0x06000CCB RID: 3275 RVA: 0x0003B191 File Offset: 0x00039391
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

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000CCC RID: 3276 RVA: 0x00002BE7 File Offset: 0x00000DE7
		// (set) Token: 0x06000CCD RID: 3277 RVA: 0x00023F85 File Offset: 0x00022185
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

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000CCE RID: 3278 RVA: 0x0003B184 File Offset: 0x00039384
		public ParteQuePuedeEstimular estimulanteParte
		{
			get
			{
				return this.data.estimulanteParte;
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public ParteQuePuedeEstimular estimulanteParteInvertido
		{
			get
			{
				return ParteQuePuedeEstimular.None;
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x0003B19F File Offset: 0x0003939F
		public float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x000066D6 File Offset: 0x000048D6
		public int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x000066D6 File Offset: 0x000048D6
		public bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x0003B1B1 File Offset: 0x000393B1
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x0003B1CE File Offset: 0x000393CE
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x0003B1E4 File Offset: 0x000393E4
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x0003B1F7 File Offset: 0x000393F7
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x0003B20A File Offset: 0x0003940A
		// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x0003B217 File Offset: 0x00039417
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

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x0003B225 File Offset: 0x00039425
		// (set) Token: 0x06000CDA RID: 3290 RVA: 0x0003B22D File Offset: 0x0003942D
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

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0003B236 File Offset: 0x00039436
		public EstimuloPorCambiarPose estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x00023ABA File Offset: 0x00021CBA
		public EstimuloPorCambiarPose estimuloInvertido
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x00023ABA File Offset: 0x00021CBA
		public InteracionEstimulanteBasica estimuloInvertidoBasico
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0003B23E File Offset: 0x0003943E
		public void SetEstimuloInstance(EstimuloPorCambiarPose instance, EstimuloPorCambiarPose instanceInveted)
		{
			this.m_estimulo = instance;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0003B248 File Offset: 0x00039448
		public void Poblar(Emocion emo, ICalculadorDeEstimuloDeCambioDePose calculador, TipoDeCalculoDeEstimulo tipo)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.data.emocion = emo;
			this.data.tipo = tipo;
			this.data.calculador = (MonoBehaviour)calculador;
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0003B297 File Offset: 0x00039497
		public void Clear()
		{
			this.data = default(CalculoDeEstimuloCambioDePoseResultado.Data);
			this.m_estimulo.Clear();
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0003B2B0 File Offset: 0x000394B0
		public void CopiarA(object result)
		{
			CalculoDeEstimuloCambioDePoseResultado calculoDeEstimuloCambioDePoseResultado = result as CalculoDeEstimuloCambioDePoseResultado;
			if (calculoDeEstimuloCambioDePoseResultado == null)
			{
				return;
			}
			calculoDeEstimuloCambioDePoseResultado.data = this.data;
			this.m_estimulo.CopiarA(calculoDeEstimuloCambioDePoseResultado.m_estimulo, false);
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x0003B2E6 File Offset: 0x000394E6
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			this.data.estado = masFuerte;
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0003B2F4 File Offset: 0x000394F4
		public UmbralBasico.Estado EstadoMasFuerte()
		{
			return this.data.estado;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0003B304 File Offset: 0x00039504
		public bool Convinable(object other)
		{
			CalculoDeEstimuloCambioDePoseResultado calculoDeEstimuloCambioDePoseResultado = other as CalculoDeEstimuloCambioDePoseResultado;
			if (calculoDeEstimuloCambioDePoseResultado == null)
			{
				return false;
			}
			if (calculoDeEstimuloCambioDePoseResultado.data.emocion != this.data.emocion)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes emociones");
				return false;
			}
			if (calculoDeEstimuloCambioDePoseResultado.data.tag != this.data.tag)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes tags");
				return false;
			}
			if (calculoDeEstimuloCambioDePoseResultado.data.estimulanteParte != this.data.estimulanteParte)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes estimulanteParte");
				return false;
			}
			if (calculoDeEstimuloCambioDePoseResultado.reaccionable != this.reaccionable)
			{
				Debug.LogWarning("intentando convinar CalculoDeEstimuloDesvestidoResultado de diferentes reaccionables");
				return false;
			}
			return this.m_estimulo.Convinable(calculoDeEstimuloCambioDePoseResultado.m_estimulo);
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0003B3C0 File Offset: 0x000395C0
		public void Convinar(object other)
		{
			CalculoDeEstimuloCambioDePoseResultado calculoDeEstimuloCambioDePoseResultado = other as CalculoDeEstimuloCambioDePoseResultado;
			if (calculoDeEstimuloCambioDePoseResultado == null)
			{
				return;
			}
			if (this.data.emocion == null)
			{
				this.data.emocion = calculoDeEstimuloCambioDePoseResultado.data.emocion;
			}
			if (this.data.tag == null)
			{
				this.data.tag = calculoDeEstimuloCambioDePoseResultado.data.tag;
			}
			if (this.data.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				this.data.estimulanteParte = calculoDeEstimuloCambioDePoseResultado.data.estimulanteParte;
			}
			this.data.estado.Convinar(ref calculoDeEstimuloCambioDePoseResultado.data.estado);
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000CE6 RID: 3302 RVA: 0x0003B462 File Offset: 0x00039662
		// (set) Token: 0x06000CE7 RID: 3303 RVA: 0x0003B46F File Offset: 0x0003966F
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

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x0003B236 File Offset: 0x00039436
		public InteracionEstimulanteBasica estimuloBasico
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0003B480 File Offset: 0x00039680
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

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x0003B4F5 File Offset: 0x000396F5
		// (set) Token: 0x06000CEB RID: 3307 RVA: 0x0003B507 File Offset: 0x00039707
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

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000CEC RID: 3308 RVA: 0x0003B51A File Offset: 0x0003971A
		// (set) Token: 0x06000CED RID: 3309 RVA: 0x0003B52C File Offset: 0x0003972C
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

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000CEE RID: 3310 RVA: 0x0003B53F File Offset: 0x0003973F
		// (set) Token: 0x06000CEF RID: 3311 RVA: 0x0003B54C File Offset: 0x0003974C
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

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x0003B55A File Offset: 0x0003975A
		// (set) Token: 0x06000CF1 RID: 3313 RVA: 0x0003B567 File Offset: 0x00039767
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

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x0003B236 File Offset: 0x00039436
		EstimuloPorCambiarPose ICalculoDeEstimulo<EstimuloPorCambiarPose>.estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x0003B575 File Offset: 0x00039775
		// (set) Token: 0x06000CF4 RID: 3316 RVA: 0x0003B57D File Offset: 0x0003977D
		public bool reaccionable { get; set; } = true;

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x0003B586 File Offset: 0x00039786
		// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x0003B58E File Offset: 0x0003978E
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x0003B597 File Offset: 0x00039797
		// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x0003B59F File Offset: 0x0003979F
		public bool ignorarCoolDown { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x0003B5A8 File Offset: 0x000397A8
		// (set) Token: 0x06000CFA RID: 3322 RVA: 0x0003B5B0 File Offset: 0x000397B0
		public bool ignorarProbabilidad { get; set; }

		// Token: 0x040008EF RID: 2287
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x040008F0 RID: 2288
		[ReadOnlyUI]
		[SerializeField]
		private double m_prioridadMod = 1.0;

		// Token: 0x040008F1 RID: 2289
		public CalculoDeEstimuloCambioDePoseResultado.Data data;

		// Token: 0x040008F2 RID: 2290
		[SerializeField]
		private EstimuloPorCambiarPose m_estimulo = new EstimuloPorCambiarPose();

		// Token: 0x02000207 RID: 519
		[Serializable]
		public struct Data
		{
			// Token: 0x040008F7 RID: 2295
			public TipoDeCalculoDeEstimulo tipo;

			// Token: 0x040008F8 RID: 2296
			public ParteQuePuedeEstimular estimulanteParte;

			// Token: 0x040008F9 RID: 2297
			public string tag;

			// Token: 0x040008FA RID: 2298
			public Emocion emocion;

			// Token: 0x040008FB RID: 2299
			public UmbralBasico.Estado estado;

			// Token: 0x040008FC RID: 2300
			public MonoBehaviour calculador;

			// Token: 0x040008FD RID: 2301
			public MonoBehaviour calculadorSec;

			// Token: 0x040008FE RID: 2302
			public bool causoMaxValue;
		}
	}
}
