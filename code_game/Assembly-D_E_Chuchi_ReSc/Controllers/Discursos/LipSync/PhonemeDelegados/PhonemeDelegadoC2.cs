using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x0200028D RID: 653
	public class PhonemeDelegadoC2 : PhonemeDelegado
	{
		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.C2;
			}
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00043E30 File Offset: 0x00042030
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Lip_Open__RL_8__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Open__RL_1__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Raise__RL_10__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID4 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Out__RL_11__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.open, this);
			ordenesDeID2.modificable.LoadModificador(ref this.open2, this);
			ordenesDeID3.modificable.LoadModificador(ref this.lenguaRaise, this);
			ordenesDeID4.modificable.LoadModificador(ref this.lenguaOut, this);
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x00043EE4 File Offset: 0x000420E4
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.open;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.open2;
			if (modificadorDeFloat2 != null)
			{
				modificadorDeFloat2.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat3 = this.lenguaRaise;
			if (modificadorDeFloat3 != null)
			{
				modificadorDeFloat3.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat4 = this.lenguaOut;
			if (modificadorDeFloat4 == null)
			{
				return;
			}
			modificadorDeFloat4.TryRemoverDeOwner(false);
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00043F3C File Offset: 0x0004213C
		protected override void OnWeightChanded()
		{
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.open.valor.valor = this.config.open * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.open2.valor.valor = this.config.open2 * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaOut.valor.valor = this.config.lenguaOut * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C5D RID: 3165
		public PhonemeDelegadoC2.Config config = new PhonemeDelegadoC2.Config();

		// Token: 0x04000C5E RID: 3166
		private ModificadorDeFloat open;

		// Token: 0x04000C5F RID: 3167
		private ModificadorDeFloat open2;

		// Token: 0x04000C60 RID: 3168
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x04000C61 RID: 3169
		private ModificadorDeFloat lenguaOut;

		// Token: 0x0200028E RID: 654
		[Serializable]
		public class Config
		{
			// Token: 0x04000C62 RID: 3170
			public float jawAngle = 3f;

			// Token: 0x04000C63 RID: 3171
			public float open = 40f;

			// Token: 0x04000C64 RID: 3172
			public float open2 = 40f;

			// Token: 0x04000C65 RID: 3173
			public float lenguaRaise = 20f;

			// Token: 0x04000C66 RID: 3174
			public float lenguaOut = 100f;
		}
	}
}
