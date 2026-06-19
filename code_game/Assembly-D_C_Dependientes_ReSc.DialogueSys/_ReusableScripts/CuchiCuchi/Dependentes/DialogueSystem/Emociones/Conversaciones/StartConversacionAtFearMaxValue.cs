using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones
{
	// Token: 0x02000065 RID: 101
	public class StartConversacionAtFearMaxValue : StartConversacionAtEmocionMaxValue<Fear>
	{
		// Token: 0x06000307 RID: 775 RVA: 0x0001022D File Offset: 0x0000E42D
		protected override void OnStartingConversacion(out string conversacion)
		{
			conversacion = this.m_conversationEjecutar;
		}

		// Token: 0x04000141 RID: 321
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;
	}
}
