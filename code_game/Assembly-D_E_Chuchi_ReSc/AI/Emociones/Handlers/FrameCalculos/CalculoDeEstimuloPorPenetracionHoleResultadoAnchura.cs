using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004FF RID: 1279
	[Serializable]
	public class CalculoDeEstimuloPorPenetracionHoleResultadoAnchura : CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase, ICalculoDeEstimuloCoitalHoleAncha, ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloCoitalHole, ICalculoDeEstimuloCoitalHoleConSubTipoSegundario
	{
		// Token: 0x06001E58 RID: 7768 RVA: 0x000438FE File Offset: 0x00041AFE
		public TipoDeEstimuloCoitalSegundaria GetTipoDeEstimuloCoitalSegundariaDeIndex(int estadoIndex)
		{
			return TipoDeEstimuloCoitalSegundaria.anchura;
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06001E59 RID: 7769 RVA: 0x00074312 File Offset: 0x00072512
		public override float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06001E5A RID: 7770 RVA: 0x00005F51 File Offset: 0x00004151
		public override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x00074324 File Offset: 0x00072524
		public override void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06001E5C RID: 7772 RVA: 0x00074341 File Offset: 0x00072541
		public override void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06001E5D RID: 7773 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001E5E RID: 7774 RVA: 0x00074357 File Offset: 0x00072557
		public override void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001E5F RID: 7775 RVA: 0x0007436A File Offset: 0x0007256A
		public override void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06001E60 RID: 7776 RVA: 0x00074380 File Offset: 0x00072580
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.anchura
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06001E61 RID: 7777 RVA: 0x00074398 File Offset: 0x00072598
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.apertura
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06001E62 RID: 7778 RVA: 0x000743B0 File Offset: 0x000725B0
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.movimiento
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06001E63 RID: 7779 RVA: 0x000743C8 File Offset: 0x000725C8
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.penetracion
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06001E64 RID: 7780 RVA: 0x000743DE File Offset: 0x000725DE
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.profundidad
		{
			get
			{
				return this.data.estado;
			}
		}

		// Token: 0x06001E65 RID: 7781 RVA: 0x00074357 File Offset: 0x00072557
		public void GetEstadoAnchuraReference(out UmbralBasico.Estado anchura)
		{
			anchura = this.data.estado;
		}

		// Token: 0x06001E66 RID: 7782 RVA: 0x000743EB File Offset: 0x000725EB
		public void GetEstados(out UmbralBasico.Estado penetracion, out UmbralBasico.Estado apertura, out UmbralBasico.Estado movimiento, out UmbralBasico.Estado profundidad, out UmbralBasico.Estado anchura)
		{
			apertura = default(UmbralBasico.Estado);
			movimiento = default(UmbralBasico.Estado);
			profundidad = default(UmbralBasico.Estado);
			anchura = this.data.estado;
			penetracion = default(UmbralBasico.Estado);
		}

		// Token: 0x06001E67 RID: 7783 RVA: 0x0007441C File Offset: 0x0007261C
		public void SetEstado(TipoDeEstimuloCoitalSegundaria tipo, ref UmbralBasico.Estado estado)
		{
			if (tipo == TipoDeEstimuloCoitalSegundaria.anchura)
			{
				this.data.estado = estado;
				return;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x06001E68 RID: 7784 RVA: 0x0007436A File Offset: 0x0007256A
		public void SetEstadoAny(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}
	}
}
