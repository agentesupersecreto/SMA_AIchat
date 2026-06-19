using System;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000CA RID: 202
	public class CharacteresExistentesEnScena : CharacteresEnScena<CharacteresExistentesEnScena>, IBuscadorDeCharactersUnicosExistentes
	{
		// Token: 0x0600071C RID: 1820 RVA: 0x00014ED4 File Offset: 0x000130D4
		ICharacterUnico IBuscadorDeCharactersUnicosExistentes.TryFind(Guid ID_Unico)
		{
			return base.Obtener(ID_Unico);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00014EE0 File Offset: 0x000130E0
		protected override void DoAwake()
		{
			base.DoAwake();
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			GlobalSingletonV2<MemoriaJson>.instance.root.saving += this.Root_saving;
			GlobalSingletonV2<MemoriaJson>.instance.root.loaded += this.Root_loaded;
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00014F38 File Offset: 0x00013138
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			if (SingletonV2<MemoriaJson>.IsInScene)
			{
				GlobalSingletonV2<MemoriaJson>.instance.root.saving -= this.Root_saving;
				GlobalSingletonV2<MemoriaJson>.instance.root.loaded -= this.Root_loaded;
			}
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00014F8C File Offset: 0x0001318C
		private void Root_loaded(IMemoryNode<string, string> obj)
		{
			foreach (ICharacterUnico characterUnico in base.characteres)
			{
				ICharacterGuardableToMemory characterGuardableToMemory = characterUnico as ICharacterGuardableToMemory;
				if (characterGuardableToMemory != null)
				{
					if (characterGuardableToMemory.doLoadOnlyWhenActive && !characterUnico.transform.gameObject.activeInHierarchy)
					{
						Debug.LogWarning("Trying to call DoLoadFromMemory on inactive character: " + characterUnico.nombreCompleto + " when is not ok", characterGuardableToMemory as Component);
					}
					else if (characterGuardableToMemory != null)
					{
						characterGuardableToMemory.DoLoadFromMemory(GlobalSingletonV2<MemoriaJson>.instance);
					}
				}
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00015028 File Offset: 0x00013228
		private void Root_saving(IMemoryNode<string, string> obj)
		{
			foreach (ICharacterUnico characterUnico in base.characteres)
			{
				ICharacterGuardableToMemory characterGuardableToMemory = characterUnico as ICharacterGuardableToMemory;
				if (characterGuardableToMemory != null)
				{
					if (characterGuardableToMemory.doSaveOnlyWhenActive && !characterUnico.transform.gameObject.activeInHierarchy)
					{
						Debug.LogWarning("Trying to call DoSaveToMemory on inactive character: " + characterUnico.nombreCompleto + " when is not ok", characterGuardableToMemory as Component);
					}
					else if (characterGuardableToMemory != null)
					{
						characterGuardableToMemory.DoSaveToMemory(GlobalSingletonV2<MemoriaJson>.instance);
					}
				}
			}
		}
	}
}
