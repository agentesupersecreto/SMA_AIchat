using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x02000283 RID: 643
	public class PhonemeDelegadoA3 : PhonemeDelegado
	{
		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000E46 RID: 3654 RVA: 0x0000D704 File Offset: 0x0000B904
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.A3;
			}
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x000434C4 File Offset: 0x000416C4
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Affricate__RL_7__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Tight_O__RL_4__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Raise__RL_10__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.afri, this);
			ordenesDeID2.modificable.LoadModificador(ref this.tightO, this);
			ordenesDeID3.modificable.LoadModificador(ref this.lenguaRaise, this);
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x0004354D File Offset: 0x0004174D
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.afri;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.tightO;
			if (modificadorDeFloat2 != null)
			{
				modificadorDeFloat2.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat3 = this.lenguaRaise;
			if (modificadorDeFloat3 == null)
			{
				return;
			}
			modificadorDeFloat3.TryRemoverDeOwner(false);
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00043588 File Offset: 0x00041788
		protected override void OnWeightChanded()
		{
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.afri.valor.valor = this.config.afri * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.tightO.valor.valor = this.config.tightO * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C35 RID: 3125
		public PhonemeDelegadoA3.Config config = new PhonemeDelegadoA3.Config();

		// Token: 0x04000C36 RID: 3126
		private ModificadorDeFloat afri;

		// Token: 0x04000C37 RID: 3127
		private ModificadorDeFloat tightO;

		// Token: 0x04000C38 RID: 3128
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x02000284 RID: 644
		[Serializable]
		public class Config
		{
			// Token: 0x04000C39 RID: 3129
			public float jawAngle = 2f;

			// Token: 0x04000C3A RID: 3130
			public float afri = 70f;

			// Token: 0x04000C3B RID: 3131
			public float tightO = 35f;

			// Token: 0x04000C3C RID: 3132
			public float lenguaRaise = 60f;
		}
	}
}
