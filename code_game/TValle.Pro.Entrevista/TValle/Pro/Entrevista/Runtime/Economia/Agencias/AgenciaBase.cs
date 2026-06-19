using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias
{
	// Token: 0x020000C6 RID: 198
	public abstract class AgenciaBase : CustomMonobehaviour
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600077E RID: 1918
		public abstract string id { get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600077F RID: 1919
		public abstract IReadOnlyDictionary<string, string> nombreLocalizado { get; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000780 RID: 1920
		public abstract IReadOnlyDictionary<string, string> descripcionLocalizada { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000781 RID: 1921
		public abstract IReadOnlyList<AgenciaBase.IRequerimiento> requerimientos { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000782 RID: 1922
		public abstract IReadOnlyList<AgenciaBase.IRequerimiento> bonuses { get; }

		// Token: 0x02000255 RID: 597
		public interface IRequerimiento
		{
			// Token: 0x060010F6 RID: 4342
			string DescripcionLocalizada(string localizacion);

			// Token: 0x060010F7 RID: 4343
			bool Cumplido(ref IIntrepretacion postulantePersonalidad, ref IIntrepretacion postulanteApariencia);
		}
	}
}
