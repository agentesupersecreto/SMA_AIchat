using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class PersonalidadDinamicaValores
	{
		// Token: 0x04000006 RID: 6
		[Tooltip("pragmatismo / Imaginación")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_abstraccion = 50f;

		// Token: 0x04000007 RID: 7
		[Tooltip("seguro / Preocupación")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_preocupacion = 50f;

		// Token: 0x04000008 RID: 8
		[Tooltip("sumiso / Dominante")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_dominancia = 50f;

		// Token: 0x04000009 RID: 9
		[Tooltip("inestable / Calmado")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_estabilidadEmocional = 50f;

		// Token: 0x0400000A RID: 10
		[Tooltip("contenido / Espontáneo")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_vivacidad = 50f;

		// Token: 0x0400000B RID: 11
		[Tooltip("apegado a lo familiar / Flexible")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_aperturaAlCambio = 50f;

		// Token: 0x0400000C RID: 12
		[Tooltip("indisciplinado / Controlado")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_perfectionismo = 50f;

		// Token: 0x0400000D RID: 13
		[Tooltip("abierto / Discreto")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_privacidad = 50f;

		// Token: 0x0400000E RID: 14
		[Tooltip("concreto /  Abstracto")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_razonamiento = 50f;

		// Token: 0x0400000F RID: 15
		[Tooltip("no conforme / Conforme a las normas")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_concienciaNormativa = 50f;

		// Token: 0x04000010 RID: 16
		[Tooltip("dependencia / Autosuficiencia")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_confianzaEnUnoMismo = 50f;

		// Token: 0x04000011 RID: 17
		[Tooltip("dureza / Calidez")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_sensibilidad = 50f;

		// Token: 0x04000012 RID: 18
		[Tooltip("tímido / Desinhibido")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_atrevimientoSocial = 50f;

		// Token: 0x04000013 RID: 19
		[Tooltip("relajado / Impaciente")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_tension = 50f;

		// Token: 0x04000014 RID: 20
		[Tooltip("confiado / Desconfiado")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_vigilancia = 50f;

		// Token: 0x04000015 RID: 21
		[Tooltip("reservado / Extrovertido")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_calidez = 50f;

		// Token: 0x04000016 RID: 22
		[Tooltip("Sensible / Resistente")]
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_resilianza = 50f;
	}
}
