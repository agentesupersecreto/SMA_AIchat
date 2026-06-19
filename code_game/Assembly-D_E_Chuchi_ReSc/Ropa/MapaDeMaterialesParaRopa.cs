using System;
using Assets._ReusableScripts.Materiales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000109 RID: 265
	[CreateAssetMenu(fileName = "MapaDeMaterialesParaRopa", menuName = "Objetos/Ropa/MapaDeMaterialesParaRopa")]
	public class MapaDeMaterialesParaRopa : MapaDeMaterialesGenerica<MaterialParaRopaData>
	{
		// Token: 0x0200010A RID: 266
		public enum MaterialParaRopaPreSetId
		{
			// Token: 0x04000458 RID: 1112
			None,
			// Token: 0x04000459 RID: 1113
			rallasColores,
			// Token: 0x0400045A RID: 1114
			transparenteFlores,
			// Token: 0x0400045B RID: 1115
			pana,
			// Token: 0x0400045C RID: 1116
			cottonBlanco,
			// Token: 0x0400045D RID: 1117
			drilBlanco,
			// Token: 0x0400045E RID: 1118
			leatherBlanco,
			// Token: 0x0400045F RID: 1119
			spandexBlanco,
			// Token: 0x04000460 RID: 1120
			nylonBlanco,
			// Token: 0x04000461 RID: 1121
			defaultBlanco,
			// Token: 0x04000462 RID: 1122
			customBlanco0 = 1000,
			// Token: 0x04000463 RID: 1123
			customBlanco1,
			// Token: 0x04000464 RID: 1124
			customBlanco2,
			// Token: 0x04000465 RID: 1125
			customBlanco3,
			// Token: 0x04000466 RID: 1126
			customBlanco4,
			// Token: 0x04000467 RID: 1127
			customBlanco5,
			// Token: 0x04000468 RID: 1128
			customBlanco6,
			// Token: 0x04000469 RID: 1129
			customBlanco7,
			// Token: 0x0400046A RID: 1130
			customBlanco8,
			// Token: 0x0400046B RID: 1131
			customBlanco9,
			// Token: 0x0400046C RID: 1132
			customBlancoTransparencia0 = 10000,
			// Token: 0x0400046D RID: 1133
			customBlancoTransparencia1,
			// Token: 0x0400046E RID: 1134
			customBlancoTransparencia2,
			// Token: 0x0400046F RID: 1135
			customBlancoTransparencia3,
			// Token: 0x04000470 RID: 1136
			customBlancoTransparencia4,
			// Token: 0x04000471 RID: 1137
			customBlancoCutOut0,
			// Token: 0x04000472 RID: 1138
			customBlancoCutOut1,
			// Token: 0x04000473 RID: 1139
			customBlancoCutOut2,
			// Token: 0x04000474 RID: 1140
			customBlancoCutOut3,
			// Token: 0x04000475 RID: 1141
			customBlancoCutOut4,
			// Token: 0x04000476 RID: 1142
			custom0 = 100000,
			// Token: 0x04000477 RID: 1143
			custom1,
			// Token: 0x04000478 RID: 1144
			custom2,
			// Token: 0x04000479 RID: 1145
			custom3,
			// Token: 0x0400047A RID: 1146
			custom4,
			// Token: 0x0400047B RID: 1147
			custom5,
			// Token: 0x0400047C RID: 1148
			custom6,
			// Token: 0x0400047D RID: 1149
			custom7,
			// Token: 0x0400047E RID: 1150
			custom8,
			// Token: 0x0400047F RID: 1151
			custom9,
			// Token: 0x04000480 RID: 1152
			plasticBlanco
		}
	}
}
