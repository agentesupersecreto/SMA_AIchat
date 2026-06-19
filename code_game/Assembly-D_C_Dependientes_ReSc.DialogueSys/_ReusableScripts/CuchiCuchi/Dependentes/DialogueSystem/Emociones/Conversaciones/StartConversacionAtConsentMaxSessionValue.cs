using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones
{
	// Token: 0x02000062 RID: 98
	public class StartConversacionAtConsentMaxSessionValue : StartConversacionPorBufferOnMax
	{
		// Token: 0x06000300 RID: 768 RVA: 0x000101DF File Offset: 0x0000E3DF
		protected override void OnStartingConversacion(out string conversacion)
		{
			conversacion = this.m_conversationEjecutar;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000101E9 File Offset: 0x0000E3E9
		protected override BufferDeMaxValue InitBuffer()
		{
			ConsentPorInteraciones componentInChildren = this.m_character.GetComponentInChildren<ConsentPorInteraciones>();
			if (componentInChildren == null)
			{
				return null;
			}
			return componentInChildren.maxValueBuffer;
		}

		// Token: 0x0400013E RID: 318
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;
	}
}
