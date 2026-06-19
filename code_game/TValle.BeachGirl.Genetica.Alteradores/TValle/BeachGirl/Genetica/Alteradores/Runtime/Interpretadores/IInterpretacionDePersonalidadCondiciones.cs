using System;
using System.Collections.Generic;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200004D RID: 77
	[Obsolete("", true)]
	public interface IInterpretacionDePersonalidadCondiciones
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000392 RID: 914
		IReadOnlyCollection<Interpretacion.Size> vaginalProfundidadQueen { get; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000393 RID: 915
		IReadOnlyCollection<Interpretacion.Size> analProfundidadQueen { get; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000394 RID: 916
		IReadOnlyCollection<Interpretacion.Size> oralProfundidadQueen { get; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000395 RID: 917
		IReadOnlyCollection<Interpretacion.Size> vaginalAnchuraQueen { get; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000396 RID: 918
		IReadOnlyCollection<Interpretacion.Size> analAnchuraQueen { get; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000397 RID: 919
		IReadOnlyCollection<Interpretacion.Size> oralAnchuraQueen { get; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000398 RID: 920
		IReadOnlyCollection<Interpretacion.Capacidad> vaginalConsent { get; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000399 RID: 921
		IReadOnlyCollection<Interpretacion.Capacidad> analConsent { get; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600039A RID: 922
		IReadOnlyCollection<Interpretacion.Capacidad> oralConsent { get; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600039B RID: 923
		IReadOnlyCollection<Interpretacion.Capacidad> watchedConsent { get; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600039C RID: 924
		IReadOnlyCollection<Interpretacion.Capacidad> watchedPrivatesConsent { get; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600039D RID: 925
		IReadOnlyCollection<Interpretacion.Capacidad> touchedConsent { get; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600039E RID: 926
		IReadOnlyCollection<Interpretacion.Capacidad> touchedPrivatesConsent { get; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600039F RID: 927
		IReadOnlyCollection<Interpretacion.Capacidad> undressedConsent { get; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060003A0 RID: 928
		IReadOnlyCollection<Interpretacion.Capacidad> undressedPrivatesConsent { get; }
	}
}
