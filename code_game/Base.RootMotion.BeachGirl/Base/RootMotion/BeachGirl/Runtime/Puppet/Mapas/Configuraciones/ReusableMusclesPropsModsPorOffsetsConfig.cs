using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Mapas.Configuraciones
{
	// Token: 0x02000012 RID: 18
	[CreateAssetMenu(fileName = "MusclePropsModsPorOffsetsConfig", menuName = "CuChiCuChi/Configuraciones/ConfiguracionDeMusculosPropsModsPorOffsets")]
	public class ReusableMusclesPropsModsPorOffsetsConfig : ScriptableObject
	{
		// Token: 0x0400004A RID: 74
		public MusclesConfigPropModsSegunRotationOffsets configs = new MusclesConfigPropModsSegunRotationOffsets();
	}
}
