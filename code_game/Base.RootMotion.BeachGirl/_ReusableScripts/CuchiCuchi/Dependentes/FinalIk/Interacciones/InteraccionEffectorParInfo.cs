using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x02000099 RID: 153
	[Serializable]
	public class InteraccionEffectorParInfo : IInteractionObjectPar
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x0001DE57 File Offset: 0x0001C057
		public bool isValid
		{
			get
			{
				return this.interactionObject != null;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x0001DE65 File Offset: 0x0001C065
		InteractionObjectV2Base IInteractionObjectPar.interactionObject
		{
			get
			{
				return this.interactionObject;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x0001DE6D File Offset: 0x0001C06D
		FullBodyBipedEffector IInteractionObjectPar.effector
		{
			get
			{
				return this.fullBodyBipedEffector;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x0001DE75 File Offset: 0x0001C075
		bool IInteractionObjectPar.activado
		{
			get
			{
				return this.activado;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x0001DE7D File Offset: 0x0001C07D
		bool IInteractionObjectPar.fijaPorAnimacion
		{
			get
			{
				return this.fijaPorAnimacion;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x0001DE85 File Offset: 0x0001C085
		bool IInteractionObjectPar.puedeTrasladarse
		{
			get
			{
				return this.puedeTrasladarse;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x0001DE8D File Offset: 0x0001C08D
		bool IInteractionObjectPar.puedeApoyarse
		{
			get
			{
				return this.puedeApoyarse;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x0001DE95 File Offset: 0x0001C095
		bool IInteractionObjectPar.puedeApoyarseExtencion
		{
			get
			{
				return this.puedeApoyarseExtencion;
			}
		}

		// Token: 0x04000434 RID: 1076
		public bool activado = true;

		// Token: 0x04000435 RID: 1077
		public InteractionObjectV2Base interactionObject;

		// Token: 0x04000436 RID: 1078
		public FullBodyBipedEffector fullBodyBipedEffector;

		// Token: 0x04000437 RID: 1079
		[Tooltip(" significa que una interaccion segundaria NO puede ejecutarse en este FullBodyBipedEffector")]
		public bool fijaPorAnimacion;

		// Token: 0x04000438 RID: 1080
		[Tooltip("significa q puede ser trasladada por algun Ik effector")]
		public bool puedeTrasladarse = true;

		// Token: 0x04000439 RID: 1081
		[Tooltip("significa q el ai de apoyo dinamico puede apoyar este FullBodyBipedEffector")]
		public bool puedeApoyarse = true;

		// Token: 0x0400043A RID: 1082
		[Tooltip("para codos y ridillas")]
		public bool puedeApoyarseExtencion;
	}
}
