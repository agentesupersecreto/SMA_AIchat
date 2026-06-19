using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x02000291 RID: 657
	public class PhonemeDelegadoD2 : PhonemeDelegado
	{
		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x000442EE File Offset: 0x000424EE
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.D2;
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x000442F2 File Offset: 0x000424F2
		protected override void LoadOrdenesDeShapeController()
		{
			this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Explosive__RL_2__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio).modificable.LoadModificador(ref this.explo, this);
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x0004431C File Offset: 0x0004251C
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.explo;
			if (modificadorDeFloat == null)
			{
				return;
			}
			modificadorDeFloat.TryRemoverDeOwner(false);
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00044330 File Offset: 0x00042530
		protected override void OnWeightChanded()
		{
			this.explo.valor.valor = this.config.explo * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C71 RID: 3185
		public PhonemeDelegadoD2.Config config = new PhonemeDelegadoD2.Config();

		// Token: 0x04000C72 RID: 3186
		private ModificadorDeFloat explo;

		// Token: 0x02000292 RID: 658
		[Serializable]
		public class Config
		{
			// Token: 0x04000C73 RID: 3187
			public float explo = 100f;
		}
	}
}
