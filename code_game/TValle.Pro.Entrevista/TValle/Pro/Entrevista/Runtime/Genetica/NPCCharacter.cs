using System;
using Assets._ReusableScripts.Genetica.NPCs;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Genetica
{
	// Token: 0x020000AF RID: 175
	public class NPCCharacter : MonoBehaviour, INpcCharacter
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0002598E File Offset: 0x00023B8E
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x0002599B File Offset: 0x00023B9B
		public ISujetoNpc npcMap
		{
			get
			{
				return this.m_npcMap as ISujetoNpc;
			}
			private set
			{
				this.m_npcMap = value as Object;
			}
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x000259A9 File Offset: 0x00023BA9
		public void Init(ISujetoNpc sujetoNPC)
		{
			if (sujetoNPC == null)
			{
				throw new ArgumentNullException("sujetoNPC", "sujetoNPC null reference.");
			}
			this.npcMap = sujetoNPC;
		}

		// Token: 0x040003F1 RID: 1009
		[ConstraintType(typeof(ISujetoNpc), true)]
		[SerializeField]
		private Object m_npcMap;
	}
}
