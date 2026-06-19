using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI.Abstract;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI
{
	// Token: 0x0200004D RID: 77
	public class OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogoNext : OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogo
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0000C4EA File Offset: 0x0000A6EA
		protected override OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo tipo
		{
			get
			{
				return OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo.next;
			}
		}
	}
}
