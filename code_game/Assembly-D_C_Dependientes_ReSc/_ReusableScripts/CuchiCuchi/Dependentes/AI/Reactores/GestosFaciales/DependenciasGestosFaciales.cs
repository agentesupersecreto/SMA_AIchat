using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.GestosFaciales
{
	// Token: 0x0200031B RID: 795
	[Serializable]
	public class DependenciasGestosFaciales
	{
		// Token: 0x06001430 RID: 5168 RVA: 0x0005E934 File Offset: 0x0005CB34
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

		// Token: 0x04000E7D RID: 3709
		public Personalidad personalidad;

		// Token: 0x04000E7E RID: 3710
		public ControlladorDeGestosFacialesEmocionales controller;

		// Token: 0x04000E7F RID: 3711
		public AnimatorCharacter character;

		// Token: 0x04000E80 RID: 3712
		public ConsentCorrupted consentForzado;
	}
}
