using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000356 RID: 854
	public sealed class CollecionDeMapasDePersonalidad : Singleton<CollecionDeMapasDePersonalidad>
	{
		// Token: 0x0600126C RID: 4716 RVA: 0x0004FD10 File Offset: 0x0004DF10
		protected override void InitData(bool esEditorTime)
		{
			if (this.@default == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			if (this.@default.personalidad == null)
			{
				throw new ArgumentNullException("@default.personalidad", "@default.personalidad null reference.");
			}
			if (this.@default.emociones == null)
			{
				throw new ArgumentNullException("@default.emociones", "@default.emociones null reference.");
			}
		}

		// Token: 0x04000F7F RID: 3967
		public CollecionDeMapasDePersonalidad.PersonalidadCompleta @default;

		// Token: 0x02000357 RID: 855
		[Serializable]
		public class PersonalidadCompleta
		{
			// Token: 0x04000F80 RID: 3968
			public MapaDePersonalidad personalidad;

			// Token: 0x04000F81 RID: 3969
			public MapaDeEmociones emociones;

			// Token: 0x04000F82 RID: 3970
			public MapaDeDeseos deseos;
		}
	}
}
