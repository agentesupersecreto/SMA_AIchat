using System;
using System.Collections.Generic;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200004E RID: 78
	[Obsolete("", true)]
	public interface IInterpretacionDeAparienciaFisica
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060003A1 RID: 929
		IReadOnlyCollection<Interpretacion.Size> culo { get; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060003A2 RID: 930
		IReadOnlyCollection<Interpretacion.Size> tetas { get; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060003A3 RID: 931
		IReadOnlyCollection<Interpretacion.Size> estatura { get; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060003A4 RID: 932
		IReadOnlyCollection<Interpretacion.Capacidad> bodyFat { get; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060003A5 RID: 933
		IReadOnlyCollection<Interpretacion.Capacidad> thickness { get; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060003A6 RID: 934
		IReadOnlyCollection<Interpretacion.Tono> tonoPiel { get; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060003A7 RID: 935
		IReadOnlyCollection<Interpretacion.Capacidad> pielTrigena { get; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060003A8 RID: 936
		IReadOnlyCollection<Interpretacion.Tono> tonoCabello { get; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060003A9 RID: 937
		IReadOnlyCollection<Interpretacion.Tono> tonoOjos { get; }
	}
}
