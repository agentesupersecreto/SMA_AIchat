using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones
{
	// Token: 0x02000060 RID: 96
	public sealed class BlockearActualizacionDeCalculoDeEstimuloEnConversacion : CustomUpdatedMonobehaviourBase, CalculoDeEstimuloEnFrame.IPuedeActualizarse
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000FFAC File Offset: 0x0000E1AC
		public bool blockeando
		{
			get
			{
				return this.m_blockeando;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000FFB4 File Offset: 0x0000E1B4
		bool CalculoDeEstimuloEnFrame.IPuedeActualizarse.puedeActualizarse
		{
			get
			{
				if (DialogueManager.IsConversationActive)
				{
					Transform currentActor = DialogueManager.CurrentActor;
					Transform currentConversant = DialogueManager.CurrentConversant;
					if ((currentConversant != null && currentConversant.IsChildOf(this.m_character.transform)) || (currentActor != null && currentActor.IsChildOf(this.m_character.transform)))
					{
						this.m_blockeando = true;
					}
					else
					{
						this.m_blockeando = false;
					}
				}
				else
				{
					this.m_blockeando = false;
				}
				return !this.m_blockeando;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0001002E File Offset: 0x0000E22E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x04000138 RID: 312
		[ReadOnlyUI]
		[SerializeField]
		private bool m_blockeando;

		// Token: 0x04000139 RID: 313
		private Character m_character;
	}
}
