using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Clases.Configuraciones;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet.Mapas.Configuraciones
{
	// Token: 0x02000011 RID: 17
	[CreateAssetMenu(fileName = "MusclePinChangePorOffsetsConfig", menuName = "CuChiCuChi/Configuraciones/ConfiguracionDeMusculosPinChangePorOffsets")]
	public class ReusableMusclesPinChangePorOffsetsConfig : ScriptableObject
	{
		// Token: 0x04000049 RID: 73
		public MusclescConfigPinChangeSegunDistanceOffsets configs = new MusclescConfigPinChangeSegunDistanceOffsets();
	}
}
