using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x0200028B RID: 651
	public class PhonemeDelegadoC1 : PhonemeDelegado
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x00043BCA File Offset: 0x00041DCA
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.C1;
			}
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x00043BD0 File Offset: 0x00041DD0
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Tight__RL_5__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Wide__RL_6__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Lip_Open__RL_8__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID4 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Raise__RL_10__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.tight, this);
			ordenesDeID2.modificable.LoadModificador(ref this.m_wide, this);
			ordenesDeID3.modificable.LoadModificador(ref this.m_open, this);
			ordenesDeID4.modificable.LoadModificador(ref this.lenguaRaise, this);
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x00043C84 File Offset: 0x00041E84
		protected override void OnWeightChanded()
		{
			this.tight.valor.valor = this.config.tight * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.m_wide.valor.valor = this.config.wide * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.m_open.valor.valor = this.config.open * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00043D84 File Offset: 0x00041F84
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.tight;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat wide = this.m_wide;
			if (wide != null)
			{
				wide.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat open = this.m_open;
			if (open != null)
			{
				open.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.lenguaRaise;
			if (modificadorDeFloat2 == null)
			{
				return;
			}
			modificadorDeFloat2.TryRemoverDeOwner(false);
		}

		// Token: 0x04000C53 RID: 3155
		public PhonemeDelegadoC1.Config config = new PhonemeDelegadoC1.Config();

		// Token: 0x04000C54 RID: 3156
		private ModificadorDeFloat tight;

		// Token: 0x04000C55 RID: 3157
		private ModificadorDeFloat m_wide;

		// Token: 0x04000C56 RID: 3158
		private ModificadorDeFloat m_open;

		// Token: 0x04000C57 RID: 3159
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x0200028C RID: 652
		[Serializable]
		public class Config
		{
			// Token: 0x04000C58 RID: 3160
			public float jawAngle = 1.5f;

			// Token: 0x04000C59 RID: 3161
			public float tight = 15f;

			// Token: 0x04000C5A RID: 3162
			public float wide = 90f;

			// Token: 0x04000C5B RID: 3163
			public float open = 40f;

			// Token: 0x04000C5C RID: 3164
			public float lenguaRaise = 40f;
		}
	}
}
