using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x02000281 RID: 641
	public class PhonemeDelegadoA2 : PhonemeDelegado
	{
		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00006318 File Offset: 0x00004518
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.A2;
			}
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x000431E0 File Offset: 0x000413E0
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Tight__RL_5__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Lip_Open__RL_8__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Open__RL_1__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID4 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Raise__RL_10__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID5 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Narrow__RL_12__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.tight, this);
			ordenesDeID2.modificable.LoadModificador(ref this.open, this);
			ordenesDeID3.modificable.LoadModificador(ref this.open2, this);
			ordenesDeID4.modificable.LoadModificador(ref this.lenguaRaise, this);
			ordenesDeID5.modificable.LoadModificador(ref this.lenguaNarrow, this);
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x000432C0 File Offset: 0x000414C0
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.tight;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.open;
			if (modificadorDeFloat2 != null)
			{
				modificadorDeFloat2.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat3 = this.open2;
			if (modificadorDeFloat3 != null)
			{
				modificadorDeFloat3.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat4 = this.lenguaRaise;
			if (modificadorDeFloat4 != null)
			{
				modificadorDeFloat4.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat5 = this.lenguaNarrow;
			if (modificadorDeFloat5 == null)
			{
				return;
			}
			modificadorDeFloat5.TryRemoverDeOwner(false);
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x0004332C File Offset: 0x0004152C
		protected override void OnWeightChanded()
		{
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.tight.valor.valor = this.config.tight * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.open2.valor.valor = this.config.open2 * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.open.valor.valor = this.config.open * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaNarrow.valor.valor = this.config.lenguaNarrow * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C29 RID: 3113
		public PhonemeDelegadoA2.Config config = new PhonemeDelegadoA2.Config();

		// Token: 0x04000C2A RID: 3114
		private ModificadorDeFloat tight;

		// Token: 0x04000C2B RID: 3115
		private ModificadorDeFloat open;

		// Token: 0x04000C2C RID: 3116
		private ModificadorDeFloat open2;

		// Token: 0x04000C2D RID: 3117
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x04000C2E RID: 3118
		private ModificadorDeFloat lenguaNarrow;

		// Token: 0x02000282 RID: 642
		[Serializable]
		public class Config
		{
			// Token: 0x04000C2F RID: 3119
			public float jawAngle = 0.5f;

			// Token: 0x04000C30 RID: 3120
			public float tight = 10f;

			// Token: 0x04000C31 RID: 3121
			public float open = 40f;

			// Token: 0x04000C32 RID: 3122
			public float open2 = 10f;

			// Token: 0x04000C33 RID: 3123
			public float lenguaRaise = 100f;

			// Token: 0x04000C34 RID: 3124
			public float lenguaNarrow = 100f;
		}
	}
}
