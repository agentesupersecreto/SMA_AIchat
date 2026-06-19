using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000506 RID: 1286
	public abstract class CalculoDeEstimuloPorPenetracionResultadoSimpleBase<THoleResult> : ICalculoDeEstimuloCoital, ICalculoDeEstimulo, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, IClearable, ICalculoDeEstimuloBuffeador where THoleResult : CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase, ICalculoDeEstimuloCoitalHole, IClearable, IConvinable, new()
	{
		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06001ECF RID: 7887 RVA: 0x00004252 File Offset: 0x00002452
		public bool esSingleEstado
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06001ED0 RID: 7888 RVA: 0x00074DFC File Offset: 0x00072FFC
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

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06001ED1 RID: 7889 RVA: 0x00074E90 File Offset: 0x00073090
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

		// Token: 0x06001ED2 RID: 7890 RVA: 0x000690F3 File Offset: 0x000672F3
		public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			this.GetEstado(index, out estado);
		}

		// Token: 0x06001ED3 RID: 7891 RVA: 0x000690FD File Offset: 0x000672FD
		public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			this.SetEstado(index, ref estado);
		}

		// Token: 0x06001ED4 RID: 7892 RVA: 0x00005A42 File Offset: 0x00003C42
		public void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001ED5 RID: 7893 RVA: 0x00005A42 File Offset: 0x00003C42
		public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x06001ED6 RID: 7894 RVA: 0x00074F24 File Offset: 0x00073124
		// (set) Token: 0x06001ED7 RID: 7895 RVA: 0x00074FBC File Offset: 0x000731BC
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

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x06001ED8 RID: 7896 RVA: 0x00075023 File Offset: 0x00073223
		// (set) Token: 0x06001ED9 RID: 7897 RVA: 0x0007502B File Offset: 0x0007322B
		public bool canProduceBuff { get; set; } = true;

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x06001EDA RID: 7898 RVA: 0x00075034 File Offset: 0x00073234
		public bool existeEstimulo
		{
			get
			{
				return this.vaginal != null || this.anal != null || this.facial != null;
			}
		}

		// Token: 0x06001EDB RID: 7899 RVA: 0x00075060 File Offset: 0x00073260
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

		// Token: 0x06001EDC RID: 7900 RVA: 0x00075098 File Offset: 0x00073298
		public void PoblarAdd(THoleResult d, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			if (d == null)
			{
				return;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = d.estimulo.PartePrincipalEstimulada(contexto);
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

		// Token: 0x06001EDD RID: 7901 RVA: 0x00075144 File Offset: 0x00073344
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

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x06001EDE RID: 7902 RVA: 0x00075191 File Offset: 0x00073391
		// (set) Token: 0x06001EDF RID: 7903 RVA: 0x0007519E File Offset: 0x0007339E
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

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06001EE0 RID: 7904 RVA: 0x000751AC File Offset: 0x000733AC
		// (set) Token: 0x06001EE1 RID: 7905 RVA: 0x000751B9 File Offset: 0x000733B9
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

		// Token: 0x06001EE2 RID: 7906 RVA: 0x00005A42 File Offset: 0x00003C42
		public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001EE3 RID: 7907 RVA: 0x00005A42 File Offset: 0x00003C42
		UmbralBasico.Estado ICalculoDeEstimuloConEstado.EstadoMasFuerte()
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06001EE4 RID: 7908 RVA: 0x000751C7 File Offset: 0x000733C7
		ICalculoDeEstimuloCoitalHole ICalculoDeEstimuloCoital.vaginal
		{
			get
			{
				return this.vaginal;
			}
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06001EE5 RID: 7909 RVA: 0x000751D4 File Offset: 0x000733D4
		ICalculoDeEstimuloCoitalHole ICalculoDeEstimuloCoital.anal
		{
			get
			{
				return this.anal;
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06001EE6 RID: 7910 RVA: 0x000751E1 File Offset: 0x000733E1
		ICalculoDeEstimuloCoitalHole ICalculoDeEstimuloCoital.facial
		{
			get
			{
				return this.facial;
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06001EE7 RID: 7911 RVA: 0x00006060 File Offset: 0x00004260
		// (set) Token: 0x06001EE8 RID: 7912 RVA: 0x00003B39 File Offset: 0x00001D39
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

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x06001EE9 RID: 7913 RVA: 0x000751EE File Offset: 0x000733EE
		// (set) Token: 0x06001EEA RID: 7914 RVA: 0x000751F6 File Offset: 0x000733F6
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

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x06001EEB RID: 7915 RVA: 0x000751FF File Offset: 0x000733FF
		// (set) Token: 0x06001EEC RID: 7916 RVA: 0x00075207 File Offset: 0x00073407
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

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x06001EED RID: 7917 RVA: 0x00075210 File Offset: 0x00073410
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
					return this.facial.prioridad * 0.6600000262260437;
				}
				return 0.0;
			}
		}

		// Token: 0x04001473 RID: 5235
		public Emocion emocion;

		// Token: 0x04001474 RID: 5236
		public THoleResult vaginal;

		// Token: 0x04001475 RID: 5237
		public THoleResult anal;

		// Token: 0x04001476 RID: 5238
		public THoleResult facial;

		// Token: 0x04001477 RID: 5239
		public TipoDeCalculoDeEstimulo tipo;

		// Token: 0x04001478 RID: 5240
		[SerializeField]
		private MonoBehaviour m_calculador;

		// Token: 0x04001479 RID: 5241
		[SerializeField]
		private MonoBehaviour m_calculadorSec;
	}
}
