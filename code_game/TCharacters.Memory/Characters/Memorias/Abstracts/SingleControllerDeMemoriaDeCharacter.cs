using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Memorias.Abstracts
{
	// Token: 0x0200000B RID: 11
	[MemoriaRelatedBehaviour]
	public abstract class SingleControllerDeMemoriaDeCharacter : CustomMonobehaviour
	{
		// Token: 0x06000048 RID: 72 RVA: 0x0000375E File Offset: 0x0000195E
		public static IJsonMemoryNode GetMemoria(MemoriaDeCharacterGeneralPermanente m_memoriaPermanente, string nodeID)
		{
			return MemoriaDeCharacterBase.LeerDeep(m_memoriaPermanente, nodeID, true);
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000049 RID: 73
		protected abstract string nodeID { get; }

		// Token: 0x0600004A RID: 74 RVA: 0x00003768 File Offset: 0x00001968
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = base.GetComponentInParent<Character>();
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_memoriaPermanente = this.m_Character.GetComponentEnRoot<MemoriaDeCharacterGeneralPermanente>();
			if (this.m_memoriaPermanente == null)
			{
				throw new ArgumentNullException("memoriaPermanente", "memoriaPermanente null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000037DA File Offset: 0x000019DA
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000037E2 File Offset: 0x000019E2
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!this.m_Character.isMemoryLoaded)
			{
				yield return null;
			}
			this.m_memoria = SingleControllerDeMemoriaDeCharacter.GetMemoria(this.m_memoriaPermanente, this.nodeID);
			this.LoadFromMemory();
			this.Subscribe();
			yield break;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000037F1 File Offset: 0x000019F1
		private void Subscribe()
		{
			this.m_Character.memoryOnSave += this.M_Character_memoryOnSave;
			this.m_Character.memoryOnLoad += this.M_Character_memoryOnLoad;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003821 File Offset: 0x00001A21
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000382C File Offset: 0x00001A2C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_Character)
			{
				this.m_Character.memoryOnSave -= this.M_Character_memoryOnSave;
				this.m_Character.memoryOnLoad -= this.M_Character_memoryOnLoad;
			}
		}

		// Token: 0x06000050 RID: 80
		public abstract void LoadFromMemory();

		// Token: 0x06000051 RID: 81
		public abstract void SaveToMemory();

		// Token: 0x06000052 RID: 82 RVA: 0x0000387B File Offset: 0x00001A7B
		[Obsolete("reemplazar por charater guardable", true)]
		private void Memoria_loaded(IMemoryNode<string, string> obj)
		{
			this.LoadFromMemory();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003883 File Offset: 0x00001A83
		[Obsolete("reemplazar por charater guardable", true)]
		private void Memoria_saving(IMemoryNode<string, string> obj)
		{
			this.SaveToMemory();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000388B File Offset: 0x00001A8B
		private void M_Character_memoryOnSave(object toMemory, ICharacterGuardableToMemory character)
		{
			this.SaveToMemory();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003893 File Offset: 0x00001A93
		private void M_Character_memoryOnLoad(object fromMemory, ICharacterGuardableToMemory character)
		{
			this.LoadFromMemory();
		}

		// Token: 0x04000018 RID: 24
		protected IJsonMemoryNode m_memoria;

		// Token: 0x04000019 RID: 25
		protected Character m_Character;

		// Token: 0x0400001A RID: 26
		protected MemoriaDeCharacterGeneralPermanente m_memoriaPermanente;
	}
}
