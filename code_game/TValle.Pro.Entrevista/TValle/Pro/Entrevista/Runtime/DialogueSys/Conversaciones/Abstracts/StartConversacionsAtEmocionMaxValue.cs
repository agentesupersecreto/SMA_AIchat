using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Conversaciones.Abstracts
{
	// Token: 0x02000109 RID: 265
	public abstract class StartConversacionsAtEmocionMaxValue<TEmocion> : StartConversacionAtEmocionMaxValue<TEmocion> where TEmocion : Emocion
	{
		// Token: 0x06000900 RID: 2304 RVA: 0x00034BB1 File Offset: 0x00032DB1
		protected override void OnStartingConversacion(out string conversacion)
		{
			if (Singleton<SMAGameplayController>.instance.IsHired(this.m_character.ID_UnicoString))
			{
				conversacion = this.m_conversationEjecutarHired;
				return;
			}
			conversacion = this.m_conversationEjecutarNoHired;
		}

		// Token: 0x040004C7 RID: 1223
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutarNoHired;

		// Token: 0x040004C8 RID: 1224
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutarHired;
	}
}
