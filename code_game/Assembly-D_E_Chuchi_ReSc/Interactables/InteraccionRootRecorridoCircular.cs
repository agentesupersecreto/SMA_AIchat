using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x0200017B RID: 379
	public class InteraccionRootRecorridoCircular : PuntosGuiasRecorridoCircular
	{
		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060008E1 RID: 2273 RVA: 0x00028A9C File Offset: 0x00026C9C
		// (remove) Token: 0x060008E2 RID: 2274 RVA: 0x00028AD4 File Offset: 0x00026CD4
		public event Action transformUpdated;

		// Token: 0x060008E3 RID: 2275 RVA: 0x00028B0C File Offset: 0x00026D0C
		public override void UpdateTargetTransform()
		{
			if (this.targetTransform != null)
			{
				this.targetTransform.SetPositionAndRotation(base.currentProyectedPoint, Quaternion.LookRotation(base.currentTangent, base.currentCrossTangent));
				Action action = this.transformUpdated;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00028B59 File Offset: 0x00026D59
		protected override void OnDrawGizmosSelected()
		{
			base.OnDrawGizmosSelected();
			Gizmos.color = Color.red;
			if (this.targetTransform != null)
			{
				Gizmos.DrawSphere(this.targetTransform.position, 0.005f);
			}
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00028B8E File Offset: 0x00026D8E
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Init TEST"
			};
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00028BA7 File Offset: 0x00026DA7
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (!base.isStared)
			{
				base.Init(this.config, null);
				return;
			}
			base.ReInitCurvas();
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00028BCB File Offset: 0x00026DCB
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Start TEST"
			};
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00028BE4 File Offset: 0x00026DE4
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			base.StartRecorrido();
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00028BF2 File Offset: 0x00026DF2
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Stop TEST"
			};
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00028C0B File Offset: 0x00026E0B
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			base.StopRecorrido();
		}

		// Token: 0x040006E3 RID: 1763
		public Transform targetTransform;
	}
}
