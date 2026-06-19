using System;
using System.Collections;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x02000017 RID: 23
	public interface ISMAJob
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000063 RID: 99
		bool isInit { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000064 RID: 100
		// (set) Token: 0x06000065 RID: 101
		bool isAborted { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000066 RID: 102
		bool nonPlayerCharacterWillRememberPlayerCharacter { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000067 RID: 103
		SceneCharacter mainPlayerCharacter { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000068 RID: 104
		SceneCharacter mainNonPlayerCharacter { get; }

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000069 RID: 105
		// (remove) Token: 0x0600006A RID: 106
		event ISMAJob.CharacterChangedHandler mainPlayerChanged;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600006B RID: 107
		// (remove) Token: 0x0600006C RID: 108
		event ISMAJob.CharacterChangedHandler mainNonPlayerChanged;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600006D RID: 109
		DateTime date { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006E RID: 110
		string ID { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600006F RID: 111
		string Name { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000070 RID: 112
		int lvl { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000071 RID: 113
		Scene mainScene { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000072 RID: 114
		Scene lightingAndGeometricsScene { get; }

		// Token: 0x06000073 RID: 115
		void Init(ISMAJobsManager jobManager, SMAJobMap map, int Lvl, Guid mainPlayerCharacterID, Guid mainNonPlayerCharacterID, DateTime inGameDate);

		// Token: 0x06000074 RID: 116
		IEnumerator Load();

		// Token: 0x06000075 RID: 117
		IEnumerator DoStart();

		// Token: 0x06000076 RID: 118
		IEnumerator Introduce();

		// Token: 0x06000077 RID: 119
		void OnNonPlayerMaxEmotionValue(Emotion emotion);

		// Token: 0x06000078 RID: 120
		bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion);

		// Token: 0x06000079 RID: 121
		void OnPlayerMaxEmotionValue(Emotion emotion);

		// Token: 0x0600007A RID: 122
		bool OnPlayerMaxEmotionValueBuffer(Emotion emotion);

		// Token: 0x0600007B RID: 123
		void BeforeAnimationsUpdate();

		// Token: 0x0600007C RID: 124
		void AfterAnimationsUpdate();

		// Token: 0x0600007D RID: 125
		void BeforePhysicsUpdate();

		// Token: 0x0600007E RID: 126
		void AfterPhysicsUpdate();

		// Token: 0x0600007F RID: 127
		void BeforeAIUpdate();

		// Token: 0x06000080 RID: 128
		void AfterAIUpdate();

		// Token: 0x06000081 RID: 129
		IEnumerator Conclude();

		// Token: 0x06000082 RID: 130
		IEnumerator End();

		// Token: 0x06000083 RID: 131
		IEnumerator UnLoad();

		// Token: 0x02000097 RID: 151
		// (Invoke) Token: 0x0600036E RID: 878
		public delegate void CharacterChangedHandler(SceneCharacter newOne, SceneCharacter oldOne, ISMAJob sender);
	}
}
