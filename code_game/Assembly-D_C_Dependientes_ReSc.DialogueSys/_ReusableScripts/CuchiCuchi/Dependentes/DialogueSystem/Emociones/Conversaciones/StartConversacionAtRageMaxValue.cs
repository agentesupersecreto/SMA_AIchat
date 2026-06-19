using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones
{
	// Token: 0x02000066 RID: 102
	public class StartConversacionAtRageMaxValue : StartConversacionAtEmocionMaxValue<Rage>
	{
		// Token: 0x06000309 RID: 777 RVA: 0x0001023F File Offset: 0x0000E43F
		protected override void OnStartingConversacion(out string conversacion)
		{
			conversacion = this.m_conversationEjecutar;
		}

		// Token: 0x04000142 RID: 322
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;
	}
}
