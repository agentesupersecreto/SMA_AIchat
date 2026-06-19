using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.IK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000066 RID: 102
	public interface ILookAtIK : ILookAtSolverIK, ILookAt, IComponentStartable
	{
		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0600041A RID: 1050
		// (remove) Token: 0x0600041B RID: 1051
		event ILookAtHandlerHorizontalChange onCambioDeOrientacionHorizontal;

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600041C RID: 1052
		bool estaMirandoIzquierda { get; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600041D RID: 1053
		bool estaMirandoDerecha { get; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600041E RID: 1054
		bool estaMirando { get; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600041F RID: 1055
		float weight { get; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000420 RID: 1056
		ILookAtHeadTargets targets { get; }

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06000421 RID: 1057
		// (remove) Token: 0x06000422 RID: 1058
		event Action<ILookAtIK> updating;

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000423 RID: 1059
		LookAtEstadisticas estadisticasHaciaTarget { get; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000424 RID: 1060
		LookAtEstadisticas estadisticasHead { get; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000425 RID: 1061
		Vector3 preUpdateHeadPosition { get; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000426 RID: 1062
		Quaternion preUpdateHeadRotation { get; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000427 RID: 1063
		Vector3 preUpdateSpinePosition { get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000428 RID: 1064
		Quaternion preUpdateSpineRotation { get; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000429 RID: 1065
		Vector3 postUpdateHeadPosition { get; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600042A RID: 1066
		Quaternion postUpdateHeadRotation { get; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600042B RID: 1067
		Vector3 postUpdateSpinePosition { get; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600042C RID: 1068
		Quaternion postUpdateSpineRotation { get; }
	}
}
