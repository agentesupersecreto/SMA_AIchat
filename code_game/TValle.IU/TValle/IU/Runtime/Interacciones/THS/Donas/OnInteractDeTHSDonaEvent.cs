using System;
using UnityEngine.Events;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000DC RID: 220
	[Serializable]
	public class OnInteractDeTHSDonaEvent : UnityEvent<THSDonaController.CurrentUserData, THSDonaController, object>
	{
	}
}
