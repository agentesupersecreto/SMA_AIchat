using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000508 RID: 1288
	[Serializable]
	public class CalculoDeEstimuloPorPenetracionHoleResultadoProfunda : CalculoDeEstimuloPorPenetracionHoleResultadoSimpleBase, ICalculoDeEstimuloCoitalHoleProfundaV2, ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloCoitalHole, ICalculoDeEstimuloCoitalHoleConSubTipoSegundario
	{
		// Token: 0x06001F09 RID: 7945 RVA: 0x0004369C File Offset: 0x0004189C
		public TipoDeEstimuloCoitalSegundaria GetTipoDeEstimuloCoitalSegundariaDeIndex(int estadoIndex)
		{
			return TipoDeEstimuloCoitalSegundaria.profundidad;
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06001F0A RID: 7946 RVA: 0x00074312 File Offset: 0x00072512
		public override float estimuloGeneradoEnFrame
		{
			get
			{
				return this.data.estado.estimulacionGeneradaEnFrame;
			}
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06001F0B RID: 7947 RVA: 0x00005F51 File Offset: 0x00004151
		public override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06001F0C RID: 7948 RVA: 0x00074324 File Offset: 0x00072524
		public override void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
		{
			estado = default(UmbralBasico.Estado);
			if (index == 0)
			{
				estado = this.data.estado;
			}
		}

		// Token: 0x06001F0D RID: 7949 RVA: 0x00074341 File Offset: 0x00072541
		public override void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
		{
			if (index == 0)
			{
				this.data.estado = estado;
			}
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06001F0E RID: 7950 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool esSingleEstado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001F0F RID: 7951 RVA: 0x00074357 File Offset: 0x00072557
		public override void GetSingleEstado(out UmbralBasico.Estado estado)
		{
			estado = this.data.estado;
		}

		// Token: 0x06001F10 RID: 7952 RVA: 0x0007436A File Offset: 0x0007256A
		public override void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06001F11 RID: 7953 RVA: 0x000755E0 File Offset: 0x000737E0
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.anchura
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06001F12 RID: 7954 RVA: 0x000755F8 File Offset: 0x000737F8
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.apertura
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06001F13 RID: 7955 RVA: 0x00075610 File Offset: 0x00073810
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.movimiento
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x06001F14 RID: 7956 RVA: 0x00075628 File Offset: 0x00073828
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.penetracion
		{
			get
			{
				return default(UmbralBasico.Estado);
			}
		}

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x06001F15 RID: 7957 RVA: 0x000743DE File Offset: 0x000725DE
		[Obsolete("", true)]
		UmbralBasico.Estado ICalculoDeEstimuloCoitalHole.profundidad
		{
			get
			{
				return this.data.estado;
			}
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x00074357 File Offset: 0x00072557
		public void GetEstadoProfundidadReference(out UmbralBasico.Estado profundidad)
		{
			profundidad = this.data.estado;
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x0007563E File Offset: 0x0007383E
		public void GetEstados(out UmbralBasico.Estado penetracion, out UmbralBasico.Estado apertura, out UmbralBasico.Estado movimiento, out UmbralBasico.Estado profundidad, out UmbralBasico.Estado anchura)
		{
			apertura = default(UmbralBasico.Estado);
			movimiento = default(UmbralBasico.Estado);
			profundidad = this.data.estado;
			anchura = default(UmbralBasico.Estado);
			penetracion = default(UmbralBasico.Estado);
		}

		// Token: 0x06001F18 RID: 7960 RVA: 0x0007566F File Offset: 0x0007386F
		public void SetEstado(TipoDeEstimuloCoitalSegundaria tipo, ref UmbralBasico.Estado estado)
		{
			if (tipo == TipoDeEstimuloCoitalSegundaria.profundidad)
			{
				this.data.estado = estado;
				return;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x06001F19 RID: 7961 RVA: 0x0007436A File Offset: 0x0007256A
		public void SetEstadoAny(ref UmbralBasico.Estado estado)
		{
			this.data.estado = estado;
		}
	}
}
