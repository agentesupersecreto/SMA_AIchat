using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004CE RID: 1230
	public class SesionPromCoital : SessionGeneralProm<FearPorDesHielo, SesionPromCoital, SesionPromCoital.Resultado, TipoDeEstimuloCoital>
	{
		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x06001D00 RID: 7424 RVA: 0x00071C1F File Offset: 0x0006FE1F
		public override TipoDeEstimuloCoital tipoDeEstimuloSegundario
		{
			get
			{
				return this.m_paraTipo;
			}
		}

		// Token: 0x06001D01 RID: 7425 RVA: 0x00071B98 File Offset: 0x0006FD98
		protected override double ObtenerPrioridad()
		{
			return 2.0;
		}

		// Token: 0x06001D02 RID: 7426 RVA: 0x00071C27 File Offset: 0x0006FE27
		protected override bool EsAcumulable(ICalculoDeEstimulo calculo)
		{
			return base.EsAcumulable(calculo) && calculo is ICalculoDeEstimuloCoitalHole;
		}

		// Token: 0x06001D03 RID: 7427 RVA: 0x00071C3D File Offset: 0x0006FE3D
		protected override bool CalculoEsDeTipoEnumerable(TipoDeEstimuloCoital tipoDeEstimuloSegundario, ICalculoDeEstimulo calculo)
		{
			return (calculo as ICalculoDeEstimuloCoitalHole).estimulo.tipoDeEstimuloCoital == tipoDeEstimuloSegundario;
		}

		// Token: 0x06001D04 RID: 7428 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionEnded()
		{
		}

		// Token: 0x06001D05 RID: 7429 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStarted()
		{
		}

		// Token: 0x06001D06 RID: 7430 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnSesionStayed()
		{
		}

		// Token: 0x04001404 RID: 5124
		[SerializeField]
		private TipoDeEstimuloCoital m_paraTipo;

		// Token: 0x020004CF RID: 1231
		[Serializable]
		public class Resultado : SessionDeCalculosDeEstimuloPromiscua<FearPorDesHielo, SesionPromCoital, SesionPromCoital.Resultado, TipoDeEstimuloCoital>.ResultadoDeSession
		{
		}
	}
}
