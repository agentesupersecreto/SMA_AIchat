using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones
{
	// Token: 0x02000063 RID: 99
	public class StartConversacionAtDecepcionMaxValue : StartConversacionAtEmocionMaxValue<Decepcion>
	{
		// Token: 0x06000303 RID: 771 RVA: 0x00010209 File Offset: 0x0000E409
		protected override void OnStartingConversacion(out string conversacion)
		{
			conversacion = this.m_conversationEjecutar;
		}

		// Token: 0x0400013F RID: 319
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;
	}
}
