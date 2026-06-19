using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Funciones
{
	// Token: 0x0200005E RID: 94
	public class CheckRegistroDeFuncionesDeCanEstimular : CheckRegistroDeFunciones<RegistroDeFuncionesDeCanEstimular>
	{
		// Token: 0x060002CF RID: 719 RVA: 0x0000E801 File Offset: 0x0000CA01
		protected override void OnAdded(RegistroDeFuncionesDeCanEstimular registroDeFunciones)
		{
			base.OnAdded(registroDeFunciones);
			registroDeFunciones.conversationDeMultipleCanI = this.m_conversationDeMultipleCanI;
		}

		// Token: 0x0400012F RID: 303
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDeMultipleCanI;
	}
}
