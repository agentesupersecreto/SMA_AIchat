using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000033 RID: 51
	public interface IPene : IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060000F5 RID: 245
		float timeTryingToOpenHoleMod { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060000F6 RID: 246
		bool isDestroyed { get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060000F7 RID: 247
		Renderer mainRenderer { get; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060000F8 RID: 248
		bool isActiveAndEnabled { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060000F9 RID: 249
		bool isVisible { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060000FA RID: 250
		float totalMass { get; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060000FB RID: 251
		GameObject peneObjeto { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060000FC RID: 252
		string name { get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060000FD RID: 253
		[Obsolete("", true)]
		float erection { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060000FE RID: 254
		float currentRealErectionValue { get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060000FF RID: 255
		bool hidden { get; }

		// Token: 0x06000100 RID: 256
		IHole TryGetPenetratingHole();

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000101 RID: 257
		Vector3 rootDefaultForwardWorldDirection { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000102 RID: 258
		Transform tipPhysics { get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000103 RID: 259
		Transform parteBase { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000104 RID: 260
		Transform partePunta { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000105 RID: 261
		Transform lookAtTarget { get; }

		// Token: 0x06000106 RID: 262
		void ShrinkToRoot();

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000107 RID: 263
		int countDePartes { get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000108 RID: 264
		float worldLength { get; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000109 RID: 265
		float worldMaxWidthOrTipLength { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600010A RID: 266
		float worldLengthFromUnderSkin { get; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600010B RID: 267
		float penetratingWorldLength { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600010C RID: 268
		float penetratingLengthMod { get; }

		// Token: 0x0600010D RID: 269
		void GetColliders(List<Collider> todosResult, List<Collider> puntasResult);

		// Token: 0x0600010E RID: 270
		bool EsPuntaOrLastPart(Collider collider);

		// Token: 0x0600010F RID: 271
		Vector3 ProyectTo(Vector3 worldPoint, out IPeneParte proyectedToParte);

		// Token: 0x06000110 RID: 272
		void GetPuntaStartTipWorldPositions(float lengthBonusAPuntaMod, out Vector3 startWorldPosition, out Vector3 tipWorldPosition, out Vector3 tipForward);

		// Token: 0x06000111 RID: 273
		int PuntaPenetration(Vector3 worldPoint, float lengthBonusAPuntaMod, out Vector3 tipEndWorldPosition, out Vector3 tipStartWorldPosition, out Vector3 proyectedWorldPoint, out float t, out IPeneParte puntaParte);
	}
}
