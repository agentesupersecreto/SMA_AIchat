using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones
{
	// Token: 0x02000064 RID: 100
	public class StartConversacionAtDolorMaxValue : StartConversacionAtEmocionMaxValue<Dolor>
	{
		// Token: 0x06000305 RID: 773 RVA: 0x0001021B File Offset: 0x0000E41B
		protected override void OnStartingConversacion(out string conversacion)
		{
			conversacion = this.m_conversationEjecutar;
		}

		// Token: 0x04000140 RID: 320
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;
	}
}
