using System;
using Assets.TValle.BeachGirl.Runtime.IK;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x02000052 RID: 82
	public interface ISexAt : IComponentStartable
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000160 RID: 352
		// (set) Token: 0x06000161 RID: 353
		TipoDeSexIK tipo { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000162 RID: 354
		Transform mainBone { get; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000163 RID: 355
		float ikWeight { get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000164 RID: 356
		Vector3 ikTarget { get; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000165 RID: 357
		// (set) Token: 0x06000166 RID: 358
		float weight { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000167 RID: 359
		// (set) Token: 0x06000168 RID: 360
		Vector3 target { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000169 RID: 361
		// (set) Token: 0x0600016A RID: 362
		float proyeccionWeight { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600016B RID: 363
		float proyeccionBaseWorldDistance { get; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600016C RID: 364
		// (set) Token: 0x0600016D RID: 365
		Vector3 anglesOffset { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600016E RID: 366
		// (set) Token: 0x0600016F RID: 367
		bool doSmoothTarget { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000170 RID: 368
		// (set) Token: 0x06000171 RID: 369
		float smoothTargetVelocityMod { get; set; }

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000172 RID: 370
		// (remove) Token: 0x06000173 RID: 371
		event Action<ISexAt> updating;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000174 RID: 372
		// (remove) Token: 0x06000175 RID: 373
		event Action<ISexAt> updated;

		// Token: 0x06000176 RID: 374
		void SetIKTarget(Vector3 target);

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000177 RID: 375
		LookAtEstadisticas estadisticasHaciaTarget { get; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000178 RID: 376
		LookAtEstadisticas estadisticasHead { get; }
	}
}
