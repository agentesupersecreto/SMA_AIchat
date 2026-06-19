using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000552 RID: 1362
	[Serializable]
	public class BaseParesIntCualquieraConfig
	{
		// Token: 0x04001587 RID: 5511
		[Header("Si es true, a la hora de calcular el puntaje, se retorna el puntajeParaCualquiera, en lugar del puntaje minimo que tiende a ser igual a zero")]
		public bool cualquieraFlag = true;

		// Token: 0x04001588 RID: 5512
		public float puntajeParaCualquiera = 100f;
	}
}
