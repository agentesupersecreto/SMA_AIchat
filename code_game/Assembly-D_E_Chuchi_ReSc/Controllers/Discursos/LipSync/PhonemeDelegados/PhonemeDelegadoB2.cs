using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x02000287 RID: 647
	public class PhonemeDelegadoB2 : PhonemeDelegado
	{
		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x000438FE File Offset: 0x00041AFE
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.B2;
			}
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00043904 File Offset: 0x00041B04
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Explosive__RL_2__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Dental_Lip__RL_3__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Open__RL_1__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID2.modificable.LoadModificador(ref this.dental, this);
			ordenesDeID.modificable.LoadModificador(ref this.explo, this);
			ordenesDeID3.modificable.LoadModificador(ref this.open2, this);
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x0004398B File Offset: 0x00041B8B
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.dental;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.explo;
			if (modificadorDeFloat2 != null)
			{
				modificadorDeFloat2.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat3 = this.open2;
			if (modificadorDeFloat3 == null)
			{
				return;
			}
			modificadorDeFloat3.TryRemoverDeOwner(false);
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x000439C8 File Offset: 0x00041BC8
		protected override void OnWeightChanded()
		{
			this.dental.valor.valor = this.config.dental * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.explo.valor.valor = this.config.explo * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.open2.valor.valor = this.config.open2 * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C47 RID: 3143
		public PhonemeDelegadoB2.Config config = new PhonemeDelegadoB2.Config();

		// Token: 0x04000C48 RID: 3144
		private ModificadorDeFloat dental;

		// Token: 0x04000C49 RID: 3145
		private ModificadorDeFloat explo;

		// Token: 0x04000C4A RID: 3146
		private ModificadorDeFloat open2;

		// Token: 0x02000288 RID: 648
		[Serializable]
		public class Config
		{
			// Token: 0x04000C4B RID: 3147
			public float dental = 100f;

			// Token: 0x04000C4C RID: 3148
			public float explo = 20f;

			// Token: 0x04000C4D RID: 3149
			public float open2 = 20f;
		}
	}
}
