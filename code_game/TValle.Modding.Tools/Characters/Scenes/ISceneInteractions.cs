using System;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x02000042 RID: 66
	public interface ISceneInteractions
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000157 RID: 343
		// (remove) Token: 0x06000158 RID: 344
		event OnCharactersInteractionHandler onInteraction;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000159 RID: 345
		// (remove) Token: 0x0600015A RID: 346
		event OnRegisterChangedHandler onRegister;

		// Token: 0x0600015B RID: 347
		void StartRecording();

		// Token: 0x0600015C RID: 348
		ICharactersSceneInteractions GetTakingPlaceInteractions(SceneCharacter from, SceneCharacter to);

		// Token: 0x0600015D RID: 349
		ICharactersSceneInteractions GetTakingPlaceInteractionsNotNull(SceneCharacter from, SceneCharacter to);

		// Token: 0x0600015E RID: 350
		ICharactersSceneInteractionsArchived GetMainArchivedInteractions(Guid from, Guid to);

		// Token: 0x0600015F RID: 351
		ICharactersSceneInteractionsArchived GetSecondaryArchivedInteractions(Guid from, Guid to);

		// Token: 0x06000160 RID: 352
		ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractions(Guid from, Guid to);

		// Token: 0x06000161 RID: 353
		ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractionsNotNull(SceneCharacter from, SceneCharacter to);

		// Token: 0x06000162 RID: 354
		void EndRecordign();

		// Token: 0x06000163 RID: 355
		void Clear();

		// Token: 0x06000164 RID: 356
		void DefaultBuffAndDebuffGenerate(SceneCharacter male, SceneCharacter female, bool sceneAborted, DateTime now, out SceneCharacterFromToBuffAndDebuff maleBuffByInteractions, out SceneCharacterFromToBuffAndDebuff femaleBuffByInteractions);

		// Token: 0x06000165 RID: 357
		void DefaultBuffAndDebuffGenerate(SceneCharacter male, Guid female, bool sceneAborted, DateTime now, out SceneCharacterFromToBuffAndDebuff maleBuffByInteractions);

		// Token: 0x06000166 RID: 358
		void DefaultBuffAndDebuffGenerate(Guid male, SceneCharacter female, bool sceneAborted, DateTime now, out SceneCharacterFromToBuffAndDebuff femaleBuffByInteractions);
	}
}
