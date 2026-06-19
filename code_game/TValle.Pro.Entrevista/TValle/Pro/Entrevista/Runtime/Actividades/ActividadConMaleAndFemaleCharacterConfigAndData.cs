using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000121 RID: 289
	public class ActividadConMaleAndFemaleCharacterConfigAndData : CustomMonobehaviour
	{
		// Token: 0x0400055D RID: 1373
		[FormerlySerializedAs("m_opcionesDeInteraccionDeInterface")]
		[SerializeField]
		public ActividadConMaleAndFemaleCharacter.OpcionesDeDona opcionesDeInteraccionDeInterface = new ActividadConMaleAndFemaleCharacter.OpcionesDeDona();

		// Token: 0x0400055E RID: 1374
		[FormerlySerializedAs("m_NoReducirMaxEmocionValueHastaSalirDeConversacion")]
		[SerializeField]
		public ActividadConMaleAndFemaleCharacter.NoReducirMaxEmocionValueHastaSalirDeConversacion noReducirMaxEmocionValueHastaSalirDeConversacion = new ActividadConMaleAndFemaleCharacter.NoReducirMaxEmocionValueHastaSalirDeConversacion();

		// Token: 0x0400055F RID: 1375
		[Tooltip("la razon por la q hay glitches es q algunas penticiones o forzamients se ejecutan justo despues de la conversacion y otros en medio de esta, por eso hay q ignorarlos")]
		[FormerlySerializedAs("m_DeshabilitarCalculadoresDeEstimulosEnConversacion")]
		[SerializeField]
		public ActividadConMaleAndFemaleCharacter.DeshabilitarCalculadoresDeEstimulosEnConversacion deshabilitarCalculadoresDeEstimulosEnConversacion = new ActividadConMaleAndFemaleCharacter.DeshabilitarCalculadoresDeEstimulosEnConversacion();

		// Token: 0x04000560 RID: 1376
		[Tooltip("si esta editando pose, es mejor des activar algunos AI")]
		[FormerlySerializedAs("m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose")]
		[SerializeField]
		public ActividadConMaleAndFemaleCharacter.DeshabilitarCalculadoresDeEstimulosEnEdicionPose deshabilitarCalculadoresDeEstimulosEnEdicionPose = new ActividadConMaleAndFemaleCharacter.DeshabilitarCalculadoresDeEstimulosEnEdicionPose();

		// Token: 0x04000561 RID: 1377
		[Header("Overrides")]
		[FormerlySerializedAs("m_Overrides")]
		[SerializeField]
		public ActividadConMaleAndFemaleCharacter.Overrides overrides = new ActividadConMaleAndFemaleCharacter.Overrides();

		// Token: 0x04000562 RID: 1378
		[Header("Extra Objects")]
		[FormerlySerializedAs("m_extraObjectsPrefabs")]
		[SerializeField]
		public List<GameObject> extraObjectsPrefabs = new List<GameObject>();
	}
}
