using System;
using System.Collections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.Clothing;
using Assets.TValle.Tools.Runtime.Memory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x0200001A RID: 26
	public interface ISMAJobsManager
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000099 RID: 153
		ISceneInteractions interactions { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600009A RID: 154
		ISMAJobsUIManager UI { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600009B RID: 155
		ISMAJobsObjectives objectives { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600009C RID: 156
		ISMAJobsOutfits outfits { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600009D RID: 157
		Language gameLanguage { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600009E RID: 158
		ISMAJob current { get; }

		// Token: 0x0600009F RID: 159
		IContextMemory GetMemory(ISMAJob job);

		// Token: 0x060000A0 RID: 160
		IContextMemory GetMemory(string jobID);

		// Token: 0x060000A1 RID: 161
		IContextMemory GetCharacterInMemory(ISMAJob job, SceneCharacter character);

		// Token: 0x060000A2 RID: 162
		IContextMemory GetCharacterInMemory(string jobID, string characterID);

		// Token: 0x060000A3 RID: 163
		void UpdateCharacterMemory(SceneCharacter character);

		// Token: 0x060000A4 RID: 164
		void AddAdditinalLogicToScene(Scene scene, float phoneAndCameraScreenEmissionModifier);

		// Token: 0x060000A5 RID: 165
		IEnumerator CheckMainCamera();

		// Token: 0x060000A6 RID: 166
		IEnumerator GenerateMaleCharacter(Vector3 feetPosition, Vector3 bodyForwardDirection, IMaleRandomGeneratorOverrider overrider, Action<SceneCharacter> result, Action<SceneCharacter> beforeAwake, string outfitID);

		// Token: 0x060000A7 RID: 167
		IEnumerator LoadMaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<SceneCharacter> result, Action<SceneCharacter> beforeAwake);

		// Token: 0x060000A8 RID: 168
		IEnumerator LoadFemaleCharacter(Guid id, Vector3 feetPosition, Vector3 bodyForwardDirection, Action<SceneCharacter> result, Action<SceneCharacter> onLoading = null);

		// Token: 0x060000A9 RID: 169
		void DestroyCharacter(Guid id);

		// Token: 0x060000AA RID: 170
		void DeleteAndDestroyCharacter(Guid id);

		// Token: 0x060000AB RID: 171
		void SetMainPlayerCharacterInputsActive(bool value);

		// Token: 0x060000AC RID: 172
		void StartJob(string id, int Lvl, Guid male, Guid female, Action<Exception> OnStaredJobRutine = null);

		// Token: 0x060000AD RID: 173
		void EndCurrentJob(Action<Exception> OnEndedJobRutine = null);

		// Token: 0x060000AE RID: 174
		void AbortCurrentJob(Action<Exception> OnAbortedJobRutine = null);

		// Token: 0x060000AF RID: 175
		float AddExpToMainPlayerInCurrentJob(float levels);

		// Token: 0x060000B0 RID: 176
		float AddExpToMainNonPlayerInCurrentJob(float levels);

		// Token: 0x060000B1 RID: 177
		float AddModelingExpToMainNonPlayer(float levels);

		// Token: 0x060000B2 RID: 178
		float AddFatigueToCurrentJob(float percentage);

		// Token: 0x060000B3 RID: 179
		float AddFatigueToMainNonPlayer(float percentage);

		// Token: 0x060000B4 RID: 180
		float AddFatigueToMainNonPlayerInJob(float percentage);

		// Token: 0x060000B5 RID: 181
		float PayMoneyToManager(float paymnentAmountModifier, float paymnentAmountAddBonus);

		// Token: 0x060000B6 RID: 182
		float GetExpToMainPlayerInCurrentJob();

		// Token: 0x060000B7 RID: 183
		float GetExpToMainNonPlayerInCurrentJob();

		// Token: 0x060000B8 RID: 184
		void GetPreferredTreatmentForClientsWeights(Guid characterID, out float nonSexual, out float softCore, out float hardcore);

		// Token: 0x060000B9 RID: 185
		void SetOutfit(Guid characterID, ITValleOutfit outfit);

		// Token: 0x060000BA RID: 186
		IEnumerator SetOutfitAndWait(Guid characterID, ITValleOutfit outfit);
	}
}
