using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos
{
	// Token: 0x02000209 RID: 521
	[CreateAssetMenu(fileName = "CapsulaDummyDeDialogosGenericos", menuName = "Objetos/Dialogos/Genericos/Capsula Dummy De Dialogos Genericos")]
	public class CapsulaDummyDeDialogosGenericos : EnvolturaCondicionalDeGrupoDeDialogos
	{
		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00035638 File Offset: 0x00033838
		public override IReadOnlyList<IHolderDeCollecionDeDialogoInfo> grupos
		{
			get
			{
				return this.m_dummies;
			}
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00035640 File Offset: 0x00033840
		public override bool IsValid()
		{
			for (int i = 0; i < this.m_dummies.Length; i++)
			{
				if (!this.m_dummies[i].IsValid())
				{
					return false;
				}
			}
			return this.m_dummies.Length != 0;
		}

		// Token: 0x040009C0 RID: 2496
		[SerializeField]
		[CoolArrayItem]
		private DummyHoderDeDialogosGenericos[] m_dummies;
	}
}
