using System;

namespace Assets
{
	// Token: 0x020000A6 RID: 166
	public static class __ICharacterConversador_EXT
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x00016170 File Offset: 0x00014370
		public static bool TryConversarCon(this ICharacter character, ICharacter conversant, string title)
		{
			ICharacterConversador componentEnRoot = character.GetComponentEnRoot<ICharacterConversador>();
			if (componentEnRoot == null)
			{
				return false;
			}
			ICharacterUnico componentEnRoot2 = conversant.GetComponentEnRoot<ICharacterUnico>();
			return componentEnRoot2 != null && componentEnRoot.TryConversarCon(title, componentEnRoot2);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x000161A0 File Offset: 0x000143A0
		public static bool TrySerConversarzado(this ICharacter character, ICharacter actor, string title)
		{
			ICharacterConversador componentEnRoot = character.GetComponentEnRoot<ICharacterConversador>();
			if (componentEnRoot == null)
			{
				return false;
			}
			ICharacterUnico componentEnRoot2 = actor.GetComponentEnRoot<ICharacterUnico>();
			return componentEnRoot2 != null && componentEnRoot.TrySerConversarzado(title, componentEnRoot2);
		}
	}
}
