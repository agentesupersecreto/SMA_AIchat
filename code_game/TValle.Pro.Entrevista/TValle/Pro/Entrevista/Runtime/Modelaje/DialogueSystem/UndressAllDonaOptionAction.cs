using System;
using System.Linq;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x020000A3 RID: 163
	public class UndressAllDonaOptionAction : CustomMonobehaviour
	{
		// Token: 0x0600060B RID: 1547 RVA: 0x00022D9C File Offset: 0x00020F9C
		public void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender, object sender2)
		{
			Character character = ((Actividad.running != null) ? Actividad.running.mainPlayerCharacter : CurrentMainCharacter<CurrentMainChar, MainChar>.current.character);
			foreach (PiezaDeRopaBase piezaDeRopaBase in this.m_ropa.piezasPuestas.ToArray<PiezaDeRopaBase>())
			{
				this.m_ropa.RemovePieza(piezaDeRopaBase.dataDeRopa.stringId, true, character);
			}
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00022E1F File Offset: 0x0002101F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ropa = this.GetComponentEnRoot(false);
			if (this.m_ropa == null)
			{
				throw new ArgumentNullException("m_ropa", "m_ropa null reference.");
			}
		}

		// Token: 0x040003C7 RID: 967
		private IRopaManager m_ropa;
	}
}
