using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000502 RID: 1282
	[Serializable]
	public sealed class CalculoDeEstimuloPorPenetracionHoleResultadoSimple : CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase, ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloCoitalHole, ICalculoDeEstimuloCoitalHoleConSubTipoSegundario, ICalculoDeEstimuloCoitalHoleVeloz
	{
		// Token: 0x06001E87 RID: 7815 RVA: 0x00005F51 File Offset: 0x00004151
		public TipoDeEstimuloCoitalSegundaria GetTipoDeEstimuloCoitalSegundariaDeIndex(int estadoIndex)
		{
			return TipoDeEstimuloCoitalSegundaria.velocidad;
		}

		// Token: 0x06001E88 RID: 7816 RVA: 0x00074357 File Offset: 0x00072557
		public void GetEstadoVelocidadReference(out UmbralBasico.Estado velocidad)
		{
			velocidad = this.data.estado;
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06001E89 RID: 7817 RVA: 0x00074312 File Offset: 0x00072512
		public override float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06001E8A RID: 7818 RVA: 0x00005F51 File Offset: 0x00004151
		public override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06001E8B RID: 7819 RVA: 0x00074324 File Offset: 0x00072524
		public override void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06001E8C RID: 7820 RVA: 0x00074341 File Offset: 0x00072541
		public override void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06001E8D RID: 7821 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001E8E RID: 7822 RVA: 0x00074357 File Offset: 0x00072557
		public override void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001E8F RID: 7823 RVA: 0x0007436A File Offset: 0x0007256A
		public override void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06001E90 RID: 7824 RVA: 0x00074878 File Offset: 0x00072A78
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.anchura
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06001E91 RID: 7825 RVA: 0x00074890 File Offset: 0x00072A90
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.apertura
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06001E92 RID: 7826 RVA: 0x000748A8 File Offset: 0x00072AA8
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.movimiento
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06001E93 RID: 7827 RVA: 0x000743DE File Offset: 0x000725DE
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.penetracion
		{
			get
			{
				return this.data.estado;
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06001E94 RID: 7828 RVA: 0x000748C0 File Offset: 0x00072AC0
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.profundidad
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x000748D6 File Offset: 0x00072AD6
		public void GetEstados(out UmbralBasico.Estado penetracion, out UmbralBasico.Estado apertura, out UmbralBasico.Estado movimiento, out UmbralBasico.Estado profundidad, out UmbralBasico.Estado anchura)
		{
			apertura = default(UmbralBasico.Estado);
			movimiento = default(UmbralBasico.Estado);
			profundidad = default(UmbralBasico.Estado);
			anchura = default(UmbralBasico.Estado);
			penetracion = this.data.estado;
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x00074907 File Offset: 0x00072B07
		public void SetEstado(TipoDeEstimuloCoitalSegundaria tipo, ref UmbralBasico.Estado estado)
		{
			if (tipo == TipoDeEstimuloCoitalSegundaria.velocidad)
			{
				this.data.estado = estado;
				return;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x0007436A File Offset: 0x0007256A
		public void SetEstadoAny(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}
	}
}
