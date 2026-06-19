using System;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos
{
	// Token: 0x020000D0 RID: 208
	[Serializable]
	public class EmailFromAgenciesRecivedEvento : EmailRecivedEvento
	{
		// Token: 0x060007B9 RID: 1977 RVA: 0x0002C442 File Offset: 0x0002A642
		protected override void GuardarEventoAMemoria(IJsonMemoryNode eventoMem)
		{
			base.GuardarEventoAMemoria(eventoMem);
			eventoMem.AddData("agencyID", this.agencyID, true);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0002C45D File Offset: 0x0002A65D
		protected override void CargarEventoDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			base.CargarEventoDesdeMemoria(eventoMem, eventoID);
			this.agencyID = eventoMem.FindData("agencyID");
		}

		// Token: 0x04000468 RID: 1128
		public string agencyID;
	}
}
