using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003EF RID: 1007
	[RequireComponent(typeof(Character))]
	public class GenericAgarranteCharacter : CustomMonobehaviour, IAgarranteCharacter
	{
		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06001600 RID: 5632 RVA: 0x0005BF76 File Offset: 0x0005A176
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06001601 RID: 5633 RVA: 0x0005BF7E File Offset: 0x0005A17E
		public IReadOnlyList<AgarranteObjeto> agarrantes
		{
			get
			{
				return this.m_agarrantes;
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06001602 RID: 5634 RVA: 0x0005BF86 File Offset: 0x0005A186
		public bool listoParaAgarrar
		{
			get
			{
				return this.m_listoParaAgarrar;
			}
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x0005BF8E File Offset: 0x0005A18E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = base.GetComponent<Character>();
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x0005BFA2 File Offset: 0x0005A1A2
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_agarrantes = base.GetComponentsInChildren<AgarranteObjeto>();
			this.m_agarrantes.ForEach(delegate(AgarranteObjeto a)
			{
				a.Init(this);
			});
			this.m_listoParaAgarrar = this.m_agarrantes.Length != 0;
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x0005BFDD File Offset: 0x0005A1DD
		public bool ListoParaAgarrarCon(AgarranteObjeto agarrante)
		{
			return this.listoParaAgarrar && !agarrante.sosteniendo && this.agarrantes.Contains(agarrante);
		}

		// Token: 0x0400117F RID: 4479
		[ReadOnlyUI]
		[SerializeField]
		private AgarranteObjeto[] m_agarrantes;

		// Token: 0x04001180 RID: 4480
		[ReadOnlyUI]
		[SerializeField]
		private bool m_listoParaAgarrar;

		// Token: 0x04001181 RID: 4481
		private Character m_Character;
	}
}
