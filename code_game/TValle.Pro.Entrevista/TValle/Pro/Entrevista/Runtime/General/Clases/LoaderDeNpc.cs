using System;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.Clases
{
	// Token: 0x020000C0 RID: 192
	public class LoaderDeNpc
	{
		// Token: 0x06000755 RID: 1877 RVA: 0x0002981C File Offset: 0x00027A1C
		public static void SaveToMemory(IMemoria memory, ICharacter character)
		{
			ICharacterGuardableToMemory characterGuardableToMemory = character as ICharacterGuardableToMemory;
			if (characterGuardableToMemory != null)
			{
				characterGuardableToMemory.DoSaveToMemory(memory);
				return;
			}
			Debug.LogError("cant save memory from brain, no character was found");
		}
	}
}
