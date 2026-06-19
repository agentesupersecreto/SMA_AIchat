using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x0200027F RID: 639
	public sealed class PhonemeDelegadoA1 : PhonemeDelegado
	{
		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00005F51 File Offset: 0x00004151
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.A1;
			}
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x00043008 File Offset: 0x00041208
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Tight__RL_5__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Lip_Open__RL_8__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID3 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.ExpresionTongue_Raise__RL_10__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.tight, this);
			ordenesDeID2.modificable.LoadModificador(ref this.m_open, this);
			ordenesDeID3.modificable.LoadModificador(ref this.lenguaRaise, this);
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00043091 File Offset: 0x00041291
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.tight;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
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

		// Token: 0x06000E3D RID: 3645 RVA: 0x000430CC File Offset: 0x000412CC
		protected override void OnWeightChanded()
		{
			this.tight.valor.valor = this.config.tight * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.jawOpenOrden.valor.valor = this.config.jawAngle * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.m_open.valor.valor = this.config.open * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.lenguaRaise.valor.valor = this.config.lenguaRaise * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C21 RID: 3105
		public PhonemeDelegadoA1.Config config = new PhonemeDelegadoA1.Config();

		// Token: 0x04000C22 RID: 3106
		private ModificadorDeFloat tight;

		// Token: 0x04000C23 RID: 3107
		private ModificadorDeFloat m_open;

		// Token: 0x04000C24 RID: 3108
		private ModificadorDeFloat lenguaRaise;

		// Token: 0x02000280 RID: 640
		[Serializable]
		public class Config
		{
			// Token: 0x04000C25 RID: 3109
			public float jawAngle = 6f;

			// Token: 0x04000C26 RID: 3110
			public float tight = 30f;

			// Token: 0x04000C27 RID: 3111
			public float open = 20f;

			// Token: 0x04000C28 RID: 3112
			public float lenguaRaise = 20f;
		}
	}
}
