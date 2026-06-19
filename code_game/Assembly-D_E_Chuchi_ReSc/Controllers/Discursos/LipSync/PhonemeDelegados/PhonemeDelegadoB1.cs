using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x02000285 RID: 645
	public class PhonemeDelegadoB1 : PhonemeDelegado
	{
		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000E4C RID: 3660 RVA: 0x0004369C File Offset: 0x0004189C
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.B1;
			}
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x000436A0 File Offset: 0x000418A0
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

		// Token: 0x06000E4E RID: 3662 RVA: 0x00043754 File Offset: 0x00041954
		protected override void OnWeightChanded()
		{
			this.tight.valor.valor = this.config.tight * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.m_wide.valor.valor = this.config.wide * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.m_open.valor.valor = this.config.open * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00043854 File Offset: 0x00041A54
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

		// Token: 0x04000C3D RID: 3133
		public PhonemeDelegadoB1.Config config = new PhonemeDelegadoB1.Config();

		// Token: 0x04000C3E RID: 3134
		private ModificadorDeFloat tight;

		// Token: 0x04000C3F RID: 3135
		private ModificadorDeFloat m_wide;

		// Token: 0x04000C40 RID: 3136
		private ModificadorDeFloat m_open;

		// Token: 0x04000C41 RID: 3137
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x02000286 RID: 646
		[Serializable]
		public class Config
		{
			// Token: 0x04000C42 RID: 3138
			public float jawAngle = 3.3f;

			// Token: 0x04000C43 RID: 3139
			public float tight = 20f;

			// Token: 0x04000C44 RID: 3140
			public float wide = 55f;

			// Token: 0x04000C45 RID: 3141
			public float open = 30f;

			// Token: 0x04000C46 RID: 3142
			public float lenguaRaise = 30f;
		}
	}
}
