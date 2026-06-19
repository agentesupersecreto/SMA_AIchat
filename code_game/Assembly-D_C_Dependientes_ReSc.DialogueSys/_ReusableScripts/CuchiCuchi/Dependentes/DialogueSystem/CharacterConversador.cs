using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200000A RID: 10
	public class CharacterConversador : CustomMonobehaviour, ICharacterConversador
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002D24 File Offset: 0x00000F24
		public bool estaConversando
		{
			get
			{
				DialogueSystemCharacterIDVariables instance = Singleton<DialogueSystemCharacterIDVariables>.instance;
				return instance.enConversacion && (instance.actor == this.m_own || instance.conversant == this.m_own);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002D67 File Offset: 0x00000F67
		public bool puedeConversar
		{
			get
			{
				return !this.estaConversando && this.puedeConversarSegunDelegados;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002D7C File Offset: 0x00000F7C
		public bool puedeConversarSegunDelegados
		{
			get
			{
				for (int i = 0; i < this.m_CharacterPuedeConversarDelegados.Count; i++)
				{
					if (!this.m_CharacterPuedeConversarDelegados[i].puedeConversar)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002DB5 File Offset: 0x00000FB5
		public IReadOnlyList<ICharacterPuedeConversar> puedeConversarDelegados
		{
			get
			{
				return this.m_CharacterPuedeConversarDelegados;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002DBD File Offset: 0x00000FBD
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_own = this.GetComponentEnRoot(false);
			this.UpdateDelegados();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002DD8 File Offset: 0x00000FD8
		public void UpdateDelegados()
		{
			this.GetRoot().GetComponentsInChildren<ICharacterPuedeConversar>(this.m_CharacterPuedeConversarDelegados);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002DEC File Offset: 0x00000FEC
		public bool TryConversarCon(string title, ICharacterUnico conversant)
		{
			if (string.IsNullOrWhiteSpace(title))
			{
				return false;
			}
			if (DialogueManager.IsConversationActive)
			{
				return false;
			}
			if (!this.puedeConversar)
			{
				return false;
			}
			if (conversant == this.m_own)
			{
				Debug.LogError("Character: " + this.m_own.nombreCompleto + " esta intentando conversar consigo mismo", this);
			}
			Singleton<DialogueSystemCharacterIDVariables>.instance.ForceToSetActorsVariables(this.m_own, conversant);
			DialogueManager.Instance.StartConversation(title, this.m_own.bodyAnimator.transform, conversant.bodyAnimator.transform);
			return true;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002E78 File Offset: 0x00001078
		public bool TrySerConversarzado(string title, ICharacterUnico actor)
		{
			if (string.IsNullOrWhiteSpace(title))
			{
				return false;
			}
			if (DialogueManager.IsConversationActive)
			{
				return false;
			}
			if (!this.puedeConversar)
			{
				return false;
			}
			if (actor == this.m_own)
			{
				Debug.LogError("Character: " + this.m_own.nombreCompleto + " esta intentando conversar consigo mismo", this);
			}
			Object @object;
			if (actor == null)
			{
				@object = null;
			}
			else
			{
				Animator bodyAnimator = actor.bodyAnimator;
				@object = ((bodyAnimator != null) ? bodyAnimator.transform : null);
			}
			if (@object == null)
			{
				return false;
			}
			Character own = this.m_own;
			Object object2;
			if (own == null)
			{
				object2 = null;
			}
			else
			{
				Animator bodyAnimator2 = own.bodyAnimator;
				object2 = ((bodyAnimator2 != null) ? bodyAnimator2.transform : null);
			}
			if (object2 == null)
			{
				return false;
			}
			Singleton<DialogueSystemCharacterIDVariables>.instance.ForceToSetActorsVariables(actor, this.m_own);
			DialogueManager.Instance.StartConversation(title, actor.bodyAnimator.transform, this.m_own.bodyAnimator.transform);
			return true;
		}

		// Token: 0x04000018 RID: 24
		private Character m_own;

		// Token: 0x04000019 RID: 25
		private List<ICharacterPuedeConversar> m_CharacterPuedeConversarDelegados = new List<ICharacterPuedeConversar>();
	}
}
