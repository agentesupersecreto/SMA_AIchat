using System;
using Assets.TValle.Tools.Runtime.Characters.Intections;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x02000045 RID: 69
	// (Invoke) Token: 0x06000170 RID: 368
	public delegate void OnCharactersInteractionHandler(ref Interaction newInteraction, ICharactersSceneInteractions Interactions, SceneCharacter from, SceneCharacter to, ISceneInteractions sender);
}
