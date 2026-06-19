using System;
using UnityEngine.Events;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000DB RID: 219
	[Serializable]
	public class OnClickItemOpcionDeTHSDonaEvent : UnityEvent<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>
	{
	}
}
