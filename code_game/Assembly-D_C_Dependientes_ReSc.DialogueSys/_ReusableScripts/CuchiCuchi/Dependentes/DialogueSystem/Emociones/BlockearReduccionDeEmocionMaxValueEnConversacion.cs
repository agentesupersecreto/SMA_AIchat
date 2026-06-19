using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones
{
	// Token: 0x02000061 RID: 97
	[RequireComponent(typeof(ReductorDeEmocionValueEnMaxEmocionValue))]
	public class BlockearReduccionDeEmocionMaxValueEnConversacion : CustomMonobehaviour
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00010068 File Offset: 0x0000E268
		private bool conversando
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
				return this.m_blockeando;
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000100E0 File Offset: 0x0000E2E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_reductor = base.GetComponent<ReductorDeEmocionValueEnMaxEmocionValue>();
			if (this.m_reductor == null)
			{
				throw new ArgumentNullException("m_reductor", "m_reductor null reference.");
			}
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00010147 File Offset: 0x0000E347
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_reductor.chekeandoSiPuedeReducir += this.M_reductor_checking;
			this.m_puedeReducir = this.m_reductor.puedeReducirValue.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0001017D File Offset: 0x0000E37D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_reductor)
			{
				this.m_reductor.chekeandoSiPuedeReducir -= this.M_reductor_checking;
			}
			ModificadorDeBool puedeReducir = this.m_puedeReducir;
			if (puedeReducir == null)
			{
				return;
			}
			puedeReducir.TryRemoverDeOwner(true);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000101BC File Offset: 0x0000E3BC
		private void M_reductor_checking(object obj)
		{
			this.m_puedeReducir.valor.valor = !this.conversando;
		}

		// Token: 0x0400013A RID: 314
		[ReadOnlyUI]
		[SerializeField]
		private bool m_blockeando;

		// Token: 0x0400013B RID: 315
		private Character m_character;

		// Token: 0x0400013C RID: 316
		private ReductorDeEmocionValueEnMaxEmocionValue m_reductor;

		// Token: 0x0400013D RID: 317
		private ModificadorDeBool m_puedeReducir;
	}
}
