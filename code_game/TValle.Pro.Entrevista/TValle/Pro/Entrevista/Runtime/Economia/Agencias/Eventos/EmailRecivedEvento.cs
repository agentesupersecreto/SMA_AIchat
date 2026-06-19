using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Tiempo;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos
{
	// Token: 0x020000CE RID: 206
	[Serializable]
	public abstract class EmailRecivedEvento : EventoUnicoNoVolatil
	{
		// Token: 0x060007B2 RID: 1970 RVA: 0x0002C338 File Offset: 0x0002A538
		protected override void NoVolatilStared()
		{
			base.NoVolatilStared();
			if (!this.m_wasStarted)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Inbox...", "There is a new message in your inbox.", 2f, true, null, new float?((float)15), null);
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0002C37F File Offset: 0x0002A57F
		protected override void GuardarEventoAMemoria(IJsonMemoryNode eventoMem)
		{
			base.GuardarEventoAMemoria(eventoMem);
			eventoMem.AddData("msg", this.msg, true);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0002C39A File Offset: 0x0002A59A
		protected override void CargarEventoDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			base.CargarEventoDesdeMemoria(eventoMem, eventoID);
			this.msg = eventoMem.FindData("msg");
		}

		// Token: 0x04000463 RID: 1123
		[TextArea(5, 10)]
		public string msg;

		// Token: 0x04000464 RID: 1124
		[Obsolete("reeemplazado por instanciador y serialized type", true)]
		[NonSerialized]
		public int tipoDeEmail;
	}
}
