using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x02000289 RID: 649
	public class PhonemeDelegadoB3 : PhonemeDelegado
	{
		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x00043AA1 File Offset: 0x00041CA1
		public override Phoneme phoneme
		{
			get
			{
				return Phoneme.B3;
			}
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x00043AA4 File Offset: 0x00041CA4
		protected override void LoadOrdenesDeShapeController()
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Lip_Open__RL_8__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_controlladorShapes.ObtenerOrdenesDeID(this.m_mapa.Expresion_Mouth_Open__RL_44__, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio);
			ordenesDeID.modificable.LoadModificador(ref this.open, this);
			ordenesDeID2.modificable.LoadModificador(ref this.bocaOpen, this);
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x00043B03 File Offset: 0x00041D03
		protected override void RemoverOrdenesDeShapeController()
		{
			ModificadorDeFloat modificadorDeFloat = this.open;
			if (modificadorDeFloat != null)
			{
				modificadorDeFloat.TryRemoverDeOwner(false);
			}
			ModificadorDeFloat modificadorDeFloat2 = this.bocaOpen;
			if (modificadorDeFloat2 == null)
			{
				return;
			}
			modificadorDeFloat2.TryRemoverDeOwner(false);
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00043B2C File Offset: 0x00041D2C
		protected override void OnWeightChanded()
		{
			this.open.valor.valor = this.config.open * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
			this.bocaOpen.valor.valor = this.config.bocaOpen * this.weight * base.ModPorBocaAbierta() * base.ModPorBocaApretada();
		}

		// Token: 0x04000C4E RID: 3150
		public PhonemeDelegadoB3.Config config = new PhonemeDelegadoB3.Config();

		// Token: 0x04000C4F RID: 3151
		private ModificadorDeFloat open;

		// Token: 0x04000C50 RID: 3152
		private ModificadorDeFloat bocaOpen;

		// Token: 0x0200028A RID: 650
		[Serializable]
		public class Config
		{
			// Token: 0x04000C51 RID: 3153
			public float open = 20f;

			// Token: 0x04000C52 RID: 3154
			public float bocaOpen = 40f;
		}
	}
}
