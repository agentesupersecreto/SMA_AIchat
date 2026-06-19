using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.LookAt
{
	// Token: 0x020002CC RID: 716
	[Serializable]
	public class DependenciasReactorLookAtBase
	{
		// Token: 0x06001243 RID: 4675 RVA: 0x00056188 File Offset: 0x00054388
		public void Init(MonoBehaviour mono)
		{
			this.controller = mono.GetComponentEnCharacter(out this.character, false);
			this.personalidad = mono.GetComponentEnCharacter(false);
			if (this.controller == null)
			{
				throw new ArgumentNullException("controller", "controller null reference.");
			}
			if (this.personalidad == null)
			{
				throw new ArgumentNullException("personalidad", "personalidad null reference.");
			}
			this.consentForzado = mono.GetComponentEnCharacter(false);
			if (this.consentForzado == null)
			{
				throw new ArgumentNullException("consentForzado", "consentForzado null reference.");
			}
		}

		// Token: 0x04000D50 RID: 3408
		public Personalidad personalidad;

		// Token: 0x04000D51 RID: 3409
		public LookAtControllerV2 controller;

		// Token: 0x04000D52 RID: 3410
		public AnimatorCharacter character;

		// Token: 0x04000D53 RID: 3411
		public ConsentCorrupted consentForzado;
	}
}
