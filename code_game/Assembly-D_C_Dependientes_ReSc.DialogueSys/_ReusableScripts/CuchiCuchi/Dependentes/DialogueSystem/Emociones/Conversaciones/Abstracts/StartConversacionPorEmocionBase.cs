using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones.Conversaciones.Abstracts
{
	// Token: 0x02000069 RID: 105
	public abstract class StartConversacionPorEmocionBase : AplicableCustomMonobehaviour
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600031D RID: 797 RVA: 0x000104B0 File Offset: 0x0000E6B0
		protected bool conversando
		{
			get
			{
				if (DialogueManager.IsConversationActive)
				{
					Transform currentActor = DialogueManager.CurrentActor;
					Transform currentConversant = DialogueManager.CurrentConversant;
					if ((currentConversant != null && currentConversant.IsChildOf(this.m_character.transform)) || (currentActor != null && currentActor.IsChildOf(this.m_character.transform)))
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0001050C File Offset: 0x0000E70C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_CharacterPuedeConversar = this.m_character.GetComponentInChildren<ICharacterConversador>();
		}

		// Token: 0x0600031F RID: 799
		protected abstract void OnStartingConversacion(out string conversacion);

		// Token: 0x06000320 RID: 800 RVA: 0x0001055C File Offset: 0x0000E75C
		protected void StartConversacion()
		{
			string text;
			this.OnStartingConversacion(out text);
			if (!string.IsNullOrWhiteSpace(text))
			{
				this.m_character.TrySerConversarzado(MainChar.current, text);
			}
		}

		// Token: 0x04000147 RID: 327
		protected Character m_character;

		// Token: 0x04000148 RID: 328
		protected ICharacterConversador m_CharacterPuedeConversar;
	}
}
