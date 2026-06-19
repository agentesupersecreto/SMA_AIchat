using System;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos
{
	// Token: 0x020000CF RID: 207
	[Serializable]
	public class EmailModelLvlIncreased : EmailRecivedEvento
	{
		// Token: 0x060007B6 RID: 1974 RVA: 0x0002C3BD File Offset: 0x0002A5BD
		protected override void GuardarEventoAMemoria(IJsonMemoryNode eventoMem)
		{
			base.GuardarEventoAMemoria(eventoMem);
			eventoMem.AddData("jobID", this.jobID, true);
			eventoMem.AddData("modelID", this.modelID, true);
			eventoMem.AddData("lvl", this.lvl, true);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0002C3FC File Offset: 0x0002A5FC
		protected override void CargarEventoDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			base.CargarEventoDesdeMemoria(eventoMem, eventoID);
			this.jobID = eventoMem.FindData("jobID");
			this.modelID = eventoMem.FindData("modelID");
			this.lvl = eventoMem.FindDataInt("lvl", 0);
		}

		// Token: 0x04000465 RID: 1125
		public string jobID;

		// Token: 0x04000466 RID: 1126
		public string modelID;

		// Token: 0x04000467 RID: 1127
		public int lvl;
	}
}
