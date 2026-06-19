using System;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Tiempo;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Eventos
{
	// Token: 0x020000C4 RID: 196
	public class CheckGameOverLunesEvento : CustomMonobehaviour
	{
		// Token: 0x06000770 RID: 1904 RVA: 0x0002A05C File Offset: 0x0002825C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Singleton<HorariosNormalesDeEntrevistas>.instance.eventosDeEntrevistas.FirstOrDefault((EventoDiarioHorario e) => e.id == "MondayMorning").stared += this.Evento_stared;
			this.m_playerInputEnabled = Singleton<PlayerInputProxy>.instance.activoModificableOverallAND.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0002A0C4 File Offset: 0x000282C4
		private void Evento_stared(Evento obj)
		{
			if (!this.activado)
			{
				Debug.Log("****Monday Check GameOver Event Not Activated", this);
				return;
			}
			try
			{
				if (CharacterWallet.Leer(Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid().ToString()) < 0f)
				{
					Singleton<GameOverPanel>.instance.ChangeState(true);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x04000441 RID: 1089
		public bool activado = true;

		// Token: 0x04000442 RID: 1090
		[SerializeField]
		private ModificadorDeBool m_playerInputEnabled;
	}
}
