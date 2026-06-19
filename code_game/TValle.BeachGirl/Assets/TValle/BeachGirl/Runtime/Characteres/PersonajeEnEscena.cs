using System;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Characteres
{
	// Token: 0x020000B7 RID: 183
	[RequireComponent(typeof(Character))]
	public sealed class PersonajeEnEscena : SceneCharacter
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x00011DD8 File Offset: 0x0000FFD8
		public override Guid ID
		{
			get
			{
				return this.m_Character.ID_Unico;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x00011DE5 File Offset: 0x0000FFE5
		public override string stringID
		{
			get
			{
				return this.m_Character.ID_UnicoString;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x00011DF2 File Offset: 0x0000FFF2
		public override bool isLoaded
		{
			get
			{
				return this.m_Character.loaded;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x00011DFF File Offset: 0x0000FFFF
		public override string fullName
		{
			get
			{
				return this.m_Character.nombreCompleto;
			}
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00011E0C File Offset: 0x0001000C
		private void Awake()
		{
			this.m_Character = base.GetComponent<Character>();
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00011E1A File Offset: 0x0001001A
		public override void Teleport(Vector3 position, Quaternion rotation)
		{
			this.m_Character.SetPositionAndRotation(position, rotation);
		}

		// Token: 0x0400039C RID: 924
		private Character m_Character;
	}
}
