using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x0200000E RID: 14
	[Flags]
	public enum PersonalidadRasgo
	{
		// Token: 0x04000047 RID: 71
		None = 0,
		// Token: 0x04000048 RID: 72
		[Tooltip("pragmatismo / Imaginación")]
		abstraccion = 1,
		// Token: 0x04000049 RID: 73
		[Tooltip("seguro / Preocupación")]
		preocupacion = 2,
		// Token: 0x0400004A RID: 74
		[Tooltip("sumiso / Dominante")]
		dominancia = 4,
		// Token: 0x0400004B RID: 75
		[Tooltip("inestable / Calmado")]
		estabilidadEmocional = 8,
		// Token: 0x0400004C RID: 76
		[Tooltip("contenido / Espontáneo")]
		vivacidad = 16,
		// Token: 0x0400004D RID: 77
		[Tooltip("apegado a lo familiar / Flexible")]
		aperturaAlCambio = 32,
		// Token: 0x0400004E RID: 78
		[Tooltip("indisciplinado / Controlado")]
		perfectionismo = 64,
		// Token: 0x0400004F RID: 79
		[Tooltip("abierto / Discreto")]
		privacidad = 128,
		// Token: 0x04000050 RID: 80
		[Tooltip("concreto /  Abstracto")]
		razonamiento = 256,
		// Token: 0x04000051 RID: 81
		[Tooltip("no conforme / Conforme a las normas")]
		concienciaNormativa = 512,
		// Token: 0x04000052 RID: 82
		[Tooltip("dependencia / Autosuficiencia")]
		confianzaEnUnoMismo = 1024,
		// Token: 0x04000053 RID: 83
		[Tooltip("dureza / Calidez")]
		sensibilidad = 2048,
		// Token: 0x04000054 RID: 84
		[Tooltip("tímido / Desinhibido")]
		atrevimientoSocial = 4096,
		// Token: 0x04000055 RID: 85
		[Tooltip("relajado / Impaciente")]
		tension = 8192,
		// Token: 0x04000056 RID: 86
		[Tooltip("confiado / Desconfiado")]
		vigilancia = 16384,
		// Token: 0x04000057 RID: 87
		[Tooltip("reservado / Extrovertido")]
		calidez = 32768,
		// Token: 0x04000058 RID: 88
		[Tooltip("Sensible / Resistente")]
		resilianza = 65536
	}
}
