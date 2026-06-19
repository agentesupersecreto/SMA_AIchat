using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Genericos
{
	// Token: 0x02000542 RID: 1346
	[CreateAssetMenu(fileName = "CapsulaConCondicionesParaDialogosGenericos", menuName = "Objetos/Dialogos/Genericos/Capsula Con Condiciones Para Dialogos Genericos")]
	public class CapsulaConCondicionesParaDialogosGenericos : EnvolturaCondicionalDeGrupoDeDialogos, IDialogosDePersonalidadesPuntajeCalculador
	{
		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x06002115 RID: 8469 RVA: 0x0007B62D File Offset: 0x0007982D
		public override IReadOnlyList<IHolderDeCollecionDeDialogoInfo> grupos
		{
			get
			{
				return this.m_dummies;
			}
		}

		// Token: 0x06002116 RID: 8470 RVA: 0x0007B638 File Offset: 0x00079838
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

		// Token: 0x06002117 RID: 8471 RVA: 0x0007B673 File Offset: 0x00079873
		public float Calcular(object arg)
		{
			return this.condiciones.Puntaje(arg as ICalculoDeEstimulo);
		}

		// Token: 0x0400157B RID: 5499
		[SerializeField]
		[CoolArrayItem]
		private DummyHoderDeDialogosGenericos[] m_dummies;

		// Token: 0x0400157C RID: 5500
		public CondicionesDeEvolturaCondicional condiciones = new CondicionesDeEvolturaCondicional();
	}
}
