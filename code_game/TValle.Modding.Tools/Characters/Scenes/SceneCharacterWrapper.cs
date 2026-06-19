using System;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x0200004C RID: 76
	public class SceneCharacterWrapper
	{
		// Token: 0x060001AB RID: 427 RVA: 0x000038DA File Offset: 0x00001ADA
		public SceneCharacterWrapper(SceneCharacter Character)
		{
			if (Character == null)
			{
				throw new ArgumentNullException("Character", "Character null reference.");
			}
			this.m_reference = new WeakReference<SceneCharacter>(Character);
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00003908 File Offset: 0x00001B08
		public SceneCharacter sceneCharacter
		{
			get
			{
				SceneCharacter sceneCharacter;
				if (!this.m_reference.TryGetTarget(out sceneCharacter))
				{
					return null;
				}
				return sceneCharacter;
			}
		}

		// Token: 0x0400008D RID: 141
		private WeakReference<SceneCharacter> m_reference;
	}
}
