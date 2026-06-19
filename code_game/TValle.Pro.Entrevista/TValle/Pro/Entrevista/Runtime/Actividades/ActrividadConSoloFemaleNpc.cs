using System;
using System.Collections;
using Assets.Productos.Juegos.Reception;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000115 RID: 277
	public abstract class ActrividadConSoloFemaleNpc : ActividadConSoloFemaleCharacter
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060009BF RID: 2495
		protected abstract bool destruirNpcOnEndAvtivity { get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060009C0 RID: 2496
		protected abstract bool deleteFromMemNpcOnEndAvtivity { get; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060009C1 RID: 2497
		protected abstract bool saveNpcOnEndAvtivity { get; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060009C2 RID: 2498
		protected abstract bool DoLoadNpc { get; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x000385EB File Offset: 0x000367EB
		public int currentFemaleCharacterLvl
		{
			get
			{
				return this.m_femaleCharacterEnScenaLvl;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x000385F3 File Offset: 0x000367F3
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x00038600 File Offset: 0x00036800
		public ISujetoIdentificableNpc npc
		{
			get
			{
				return this.m_npc as ISujetoIdentificableNpc;
			}
			private set
			{
				this.m_npc = value as Object;
			}
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00038610 File Offset: 0x00036810
		protected sealed override void OnScenaAndFemaleCharacterLoaded(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			if (this.DoLoadNpc)
			{
				this.LoadingNPC(characterEnScena, rootForManagerLogicInCharacter);
				this.npc = this.LoadNpc(characterEnScena, rootForManagerLogicInCharacter);
				if (this.npc == null)
				{
					throw new ArgumentNullException("npc", "npc null reference.");
				}
				ISujetoNivel sujetoNivel = this.npc as ISujetoNivel;
				this.m_femaleCharacterEnScenaLvl = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
			}
		}

		// Token: 0x060009C7 RID: 2503
		protected abstract void LoadingNPC(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter);

		// Token: 0x060009C8 RID: 2504
		protected abstract ISujetoIdentificableNpc LoadNpc(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter);

		// Token: 0x060009C9 RID: 2505 RVA: 0x00038685 File Offset: 0x00036885
		protected override IEnumerator OnEnd()
		{
			if (this.saveNpcOnEndAvtivity && this.deleteFromMemNpcOnEndAvtivity)
			{
				Debug.LogError("se quiere borrar y guardar npc al mismo tiempo", this);
			}
			if (this.saveNpcOnEndAvtivity)
			{
				if (base.currentFemaleCharacterAlteradoresApariencia.mapaDeValores != null)
				{
					base.currentFemaleCharacterAlteradoresApariencia.Save();
				}
				if (base.currentFemaleCharacterAlteradoresPersonalidad.mapaDeValores != null)
				{
					base.currentFemaleCharacterAlteradoresPersonalidad.Save();
				}
				LoaderDeNpcFemeninos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, this.npc, base.currentFemaleCharacter, null);
			}
			Guid npcID = this.npc.NpcID;
			if (this.destruirNpcOnEndAvtivity)
			{
				LoaderDeNpcFemeninos.DestroyNPC(npcID.ToString());
				this.m_npc = null;
			}
			if (this.deleteFromMemNpcOnEndAvtivity)
			{
				LoaderDeNpcFemeninos.EraseNPCFromGameMemory(npcID.ToString());
			}
			yield break;
		}

		// Token: 0x04000544 RID: 1348
		[Header("-> Actrividad Con Female Npc <-")]
		[ReadOnlyUI]
		[SerializeField]
		private int m_femaleCharacterEnScenaLvl;

		// Token: 0x04000545 RID: 1349
		[ConstraintType(typeof(ISujetoIdentificableNpc), true)]
		[SerializeField]
		private Object m_npc;
	}
}
