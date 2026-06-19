using System;
using System.Collections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x0200001D RID: 29
	public interface ISMAJobsUIManager
	{
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000CD RID: 205
		// (remove) Token: 0x060000CE RID: 206
		event Action<ISMAJobsUIManager> showMenuKeyReleased;

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000CF RID: 207
		bool floatingMainMenuIsShowing { get; }

		// Token: 0x060000D0 RID: 208
		void DrawFloatingMainMenuPanel(object model, out object previousModel, Action onHidden = null);

		// Token: 0x060000D1 RID: 209
		void DrawMainMenuPanelOnMainCanvas(object model, out object previousModel);

		// Token: 0x060000D2 RID: 210
		void CloseFloatingPanel();

		// Token: 0x060000D3 RID: 211
		void CloseMainCanvasPanel();

		// Token: 0x060000D4 RID: 212
		void ShowMainPlayerCharacterInfo();

		// Token: 0x060000D5 RID: 213
		void ShowMainNonPlayerCharacterInfo();

		// Token: 0x060000D6 RID: 214
		void ShowCurrentJobSessionObjetives(bool show, bool force);

		// Token: 0x060000D7 RID: 215
		IEnumerator ShowDefaultEndSessionPanel(bool aborted, float income, float activityExpGain, float activityExpTotal, float modelFatigueGain, float modelFatigueTotal, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFrom, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnTo);
	}
}
