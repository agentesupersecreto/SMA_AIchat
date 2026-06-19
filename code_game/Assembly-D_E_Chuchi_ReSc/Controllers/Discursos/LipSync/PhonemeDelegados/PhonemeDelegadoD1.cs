using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x0200028F RID: 655
	public class PhonemeDelegadoD1 : PhonemeDelegado
	{
		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x0004408B File Offset: 0x0004228B
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.D1;
			}
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00044090 File Offset: 0x00042290
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Tight__RL_5__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Tight_O__RL_4__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Affricate__RL_7__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID4 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Raise__RL_10__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.tight, this);
			ordenesDeID2.modificable.LoadModificador(ref this.tightO, this);
			ordenesDeID3.modificable.LoadModificador(ref this.affri, this);
			ordenesDeID4.modificable.LoadModificador(ref this.lenguaRaise, this);
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x00044144 File Offset: 0x00042344
		protected override void OnWeightChanded()
		{
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.tight.valor.valor = this.config.tight * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.tightO.valor.valor = this.config.tightO * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.affri.valor.valor = this.config.affri * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x00044244 File Offset: 0x00042444
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.tight;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.tightO;
			if (modificadorDeFloat2 != null)
			{
				modificadorDeFloat2.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat3 = this.affri;
			if (modificadorDeFloat3 != null)
			{
				modificadorDeFloat3.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat4 = this.lenguaRaise;
			if (modificadorDeFloat4 == null)
			{
				return;
			}
			modificadorDeFloat4.TryRemoverDeOwner(false);
		}

		// Token: 0x04000C67 RID: 3175
		public PhonemeDelegadoD1.Config config = new PhonemeDelegadoD1.Config();

		// Token: 0x04000C68 RID: 3176
		private ModificadorDeFloat tight;

		// Token: 0x04000C69 RID: 3177
		private ModificadorDeFloat tightO;

		// Token: 0x04000C6A RID: 3178
		private ModificadorDeFloat affri;

		// Token: 0x04000C6B RID: 3179
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x02000290 RID: 656
		[Serializable]
		public class Config
		{
			// Token: 0x04000C6C RID: 3180
			public float jawAngle = 6f;

			// Token: 0x04000C6D RID: 3181
			public float tight = 20f;

			// Token: 0x04000C6E RID: 3182
			public float tightO = 50f;

			// Token: 0x04000C6F RID: 3183
			public float affri = 20f;

			// Token: 0x04000C70 RID: 3184
			public float lenguaRaise = 20f;
		}
	}
}
