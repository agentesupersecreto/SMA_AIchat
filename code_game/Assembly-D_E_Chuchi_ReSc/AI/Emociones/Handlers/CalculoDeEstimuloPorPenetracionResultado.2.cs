using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000482 RID: 1154
	public abstract class CalculoDeEstimuloPorPenetracionResultado<THoleResult> : ICalculoDeEstimuloCoital, ICalculoDeEstimulo, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, IClearable, ICalculoDeEstimuloBuffeador where THoleResult : CalculoDeEstimuloPorPenetracionHoleResultado, ICalculoDeEstimuloCoitalHole, IClearable, IConvinable, new()
	{
		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x060019E7 RID: 6631 RVA: 0x00004252 File Offset: 0x00002452
		public bool esSingleEstado
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x00005A42 File Offset: 0x00003C42
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x00005A42 File Offset: 0x00003C42
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x060019EA RID: 6634 RVA: 0x00068FCC File Offset: 0x000671CC
		public float estimuloGeneradoEnFrame
		{
			get
			{
				THoleResult tholeResult = this.vaginal;
				float valueOrDefault = ((tholeResult != null) ? new float?(tholeResult.estimuloGeneradoEnFrame) : null).GetValueOrDefault();
				THoleResult tholeResult2 = this.anal;
				float num = valueOrDefault + ((tholeResult2 != null) ? new float?(tholeResult2.estimuloGeneradoEnFrame) : null).GetValueOrDefault();
				THoleResult tholeResult3 = this.facial;
				return num + ((tholeResult3 != null) ? new float?(tholeResult3.estimuloGeneradoEnFrame) : null).GetValueOrDefault();
			}
		}

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x060019EB RID: 6635 RVA: 0x00069060 File Offset: 0x00067260
		public int cantidadDeEstados
		{
			get
			{
				THoleResult tholeResult = this.vaginal;
				int valueOrDefault = ((tholeResult != null) ? new int?(tholeResult.cantidadDeEstados) : null).GetValueOrDefault();
				THoleResult tholeResult2 = this.anal;
				int num = valueOrDefault + ((tholeResult2 != null) ? new int?(tholeResult2.cantidadDeEstados) : null).GetValueOrDefault();
				THoleResult tholeResult3 = this.facial;
				return num + ((tholeResult3 != null) ? new int?(tholeResult3.cantidadDeEstados) : null).GetValueOrDefault();
			}
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x000690F3 File Offset: 0x000672F3
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			this.GetEstado(index, out estado);
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x000690FD File Offset: 0x000672FD
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			this.SetEstado(index, ref estado);
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x060019EE RID: 6638 RVA: 0x00069108 File Offset: 0x00067308
		// (set) Token: 0x060019EF RID: 6639 RVA: 0x000691A0 File Offset: 0x000673A0
		public bool causoMaxValue
		{
			get
			{
				THoleResult tholeResult = this.vaginal;
				if (!((tholeResult != null) ? new bool?(tholeResult.causoMaxValue) : null).GetValueOrDefault())
				{
					THoleResult tholeResult2 = this.anal;
					if (!((tholeResult2 != null) ? new bool?(tholeResult2.causoMaxValue) : null).GetValueOrDefault())
					{
						THoleResult tholeResult3 = this.facial;
						return ((tholeResult3 != null) ? new bool?(tholeResult3.causoMaxValue) : null).GetValueOrDefault();
					}
				}
				return true;
			}
			set
			{
				if (this.vaginal != null)
				{
					this.vaginal.causoMaxValue = value;
				}
				if (this.anal != null)
				{
					this.anal.causoMaxValue = value;
				}
				if (this.facial != null)
				{
					this.facial.causoMaxValue = value;
				}
			}
		}

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x060019F0 RID: 6640 RVA: 0x00069207 File Offset: 0x00067407
		// (set) Token: 0x060019F1 RID: 6641 RVA: 0x0006920F File Offset: 0x0006740F
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x060019F2 RID: 6642 RVA: 0x00069218 File Offset: 0x00067418
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		public bool existeEstimulo
		{
			get
			{
				return this.vaginal != null || this.anal != null || this.facial != null;
			}
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x00069244 File Offset: 0x00067444
		public void Poblar(Emocion emo, ICalculadorDeEstimulo calculador, TipoDeCalculoDeEstimulo tipo)
		{
			if (emo == null)
			{
				throw new ArgumentNullException("emo", "emo null reference.");
			}
			this.emocion = emo;
			this.m_calculador = (MonoBehaviour)calculador;
			this.tipo = tipo;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x0006927C File Offset: 0x0006747C
		public void PoblarAdd(THoleResult d, PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana)
		{
			if (d == null)
			{
				return;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = d.estimulo.PartePrincipalEstimulada(contextoDePrioridadDeParteHumana);
			if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno)
			{
				if (parteDelCuerpoHumano != ParteDelCuerpoHumano.ano)
				{
					if (parteDelCuerpoHumano != ParteDelCuerpoHumano.vag)
					{
						throw new ArgumentOutOfRangeException(parteDelCuerpoHumano.ToString());
					}
					if (this.vaginal != null)
					{
						throw new NotSupportedException("data esta repetida, dos penetraciones por hole no es soportado (VAG)");
					}
					this.vaginal = d;
					return;
				}
				else
				{
					if (this.anal != null)
					{
						throw new NotSupportedException("data esta repetida, dos penetraciones por hole no es soportado (ANA)");
					}
					this.anal = d;
					return;
				}
			}
			else
			{
				if (this.facial != null)
				{
					throw new NotSupportedException("data esta repetida, dos penetraciones por hole no es soportado (FACI)");
				}
				this.facial = d;
				return;
			}
		}

		// Token: 0x060019F5 RID: 6645 RVA: 0x00069328 File Offset: 0x00067528
		public virtual void Clear()
		{
			this.tipo = TipoDeCalculoDeEstimulo.None;
			this.emocion = null;
			this.vaginal = default(THoleResult);
			this.anal = default(THoleResult);
			this.facial = default(THoleResult);
			this.m_calculador = null;
			this.m_calculadorSec = null;
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x060019F6 RID: 6646 RVA: 0x00069375 File Offset: 0x00067575
		// (set) Token: 0x060019F7 RID: 6647 RVA: 0x00069382 File Offset: 0x00067582
		ICalculadorDeEstimulo ICalculoDeEstimulo.producidoPor
		{
			get
			{
				return (ICalculadorDeEstimulo)this.m_calculador;
			}
			set
			{
				this.m_calculador = (MonoBehaviour)value;
			}
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x060019F8 RID: 6648 RVA: 0x00069390 File Offset: 0x00067590
		// (set) Token: 0x060019F9 RID: 6649 RVA: 0x0006939D File Offset: 0x0006759D
		public ICalculadorDeEstimulo producidoPorSegundario
		{
			get
			{
				return (ICalculadorDeEstimulo)this.m_calculadorSec;
			}
			set
			{
				this.m_calculadorSec = (MonoBehaviour)value;
			}
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloConEstado.EstadoMasFuerte()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public void GetEstadoReference(ref UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x060019FD RID: 6653 RVA: 0x000693AB File Offset: 0x000675AB
		ICalculoDeEstimuloCoitalHole ICalculoDeEstimuloCoital.vaginal
		{
			get
			{
				return this.vaginal;
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x060019FE RID: 6654 RVA: 0x000693B8 File Offset: 0x000675B8
		ICalculoDeEstimuloCoitalHole ICalculoDeEstimuloCoital.anal
		{
			get
			{
				return this.anal;
			}
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x060019FF RID: 6655 RVA: 0x000693C5 File Offset: 0x000675C5
		ICalculoDeEstimuloCoitalHole ICalculoDeEstimuloCoital.facial
		{
			get
			{
				return this.facial;
			}
		}

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06001A00 RID: 6656 RVA: 0x00006060 File Offset: 0x00004260
		// (set) Token: 0x06001A01 RID: 6657 RVA: 0x00003B39 File Offset: 0x00001D39
		string ICalculoDeEstimulo.tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x06001A02 RID: 6658 RVA: 0x000693D2 File Offset: 0x000675D2
		// (set) Token: 0x06001A03 RID: 6659 RVA: 0x000693DA File Offset: 0x000675DA
		Emocion ICalculoDeEstimulo.emocion
		{
			get
			{
				return this.emocion;
			}
			set
			{
				this.emocion = value;
			}
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06001A04 RID: 6660 RVA: 0x000693E3 File Offset: 0x000675E3
		// (set) Token: 0x06001A05 RID: 6661 RVA: 0x000693EB File Offset: 0x000675EB
		TipoDeCalculoDeEstimulo ICalculoDeEstimulo.tipo
		{
			get
			{
				return this.tipo;
			}
			set
			{
				this.tipo = value;
			}
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06001A06 RID: 6662 RVA: 0x000693F4 File Offset: 0x000675F4
		double ICalculoDeEstimulo.prioridad
		{
			get
			{
				if (this.anal != null)
				{
					return this.anal.prioridad * 1.5;
				}
				if (this.vaginal != null)
				{
					return this.vaginal.prioridad * 1.0;
				}
				if (this.facial != null)
				{
					return this.facial.prioridad * 0.66;
				}
				return 0.0;
			}
		}

		// Token: 0x04001344 RID: 4932
		public Emocion emocion;

		// Token: 0x04001345 RID: 4933
		public THoleResult vaginal;

		// Token: 0x04001346 RID: 4934
		public THoleResult anal;

		// Token: 0x04001347 RID: 4935
		public THoleResult facial;

		// Token: 0x04001348 RID: 4936
		public TipoDeCalculoDeEstimulo tipo;

		// Token: 0x04001349 RID: 4937
		[SerializeField]
		private MonoBehaviour m_calculador;

		// Token: 0x0400134A RID: 4938
		[SerializeField]
		private MonoBehaviour m_calculadorSec;
	}
}
