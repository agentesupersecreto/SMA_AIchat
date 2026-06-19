using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts
{
	// Token: 0x02000095 RID: 149
	public class ChangeOfficinaLight : MonoBehaviour
	{
		// Token: 0x060002FD RID: 765 RVA: 0x00010C87 File Offset: 0x0000EE87
		private void Start()
		{
			if (Singleton<SceneEntrevistaObjetos>.IsInScene)
			{
				Singleton<SceneEntrevistaObjetos>.instance.luzDeOfficina.isTurnOn = this.turnOn;
			}
		}

		// Token: 0x0400014A RID: 330
		public bool turnOn;
	}
}
