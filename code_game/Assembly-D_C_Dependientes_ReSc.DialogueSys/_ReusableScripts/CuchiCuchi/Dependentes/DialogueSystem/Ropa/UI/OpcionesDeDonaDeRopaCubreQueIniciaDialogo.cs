using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI
{
	// Token: 0x02000036 RID: 54
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDeRopaCubreQueIniciaDialogo : OpcionesDeDonaDeRopaCubreConTextoMutado
	{
		// Token: 0x06000188 RID: 392 RVA: 0x00007C1D File Offset: 0x00005E1D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00007C50 File Offset: 0x00005E50
		protected override void OnOpccionCliked(int index, RopaCubre enumerable, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, enumerable, button, dona);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x040000CA RID: 202
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000CB RID: 203
		private Character m_owner;
	}
}
