using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x0200017C RID: 380
	public class InteraccionRootRecorridoLinear : PuntosGuiasRecorridoLinear
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x00028C21 File Offset: 0x00026E21
		public override void UpdateTargetTransform()
		{
			if (this.targetTransform != null)
			{
				this.targetTransform.SetPositionAndRotation(base.currentProyectedPoint, Quaternion.LookRotation(base.currentTangent, base.currentCrossTangent));
			}
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00028C53 File Offset: 0x00026E53
		protected override void OnDrawGizmosSelected()
		{
			base.OnDrawGizmosSelected();
			Gizmos.color = Color.red;
			if (this.targetTransform != null)
			{
				Gizmos.DrawSphere(this.targetTransform.position, 0.005f);
			}
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00028B8E File Offset: 0x00026D8E
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Init TEST"
			};
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00028C88 File Offset: 0x00026E88
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

		// Token: 0x060008F0 RID: 2288 RVA: 0x00028BCB File Offset: 0x00026DCB
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Start TEST"
			};
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00028CAC File Offset: 0x00026EAC
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			base.StartRecorrido();
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00028BF2 File Offset: 0x00026DF2
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Stop TEST"
			};
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00028CBA File Offset: 0x00026EBA
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			base.StopRecorrido();
		}

		// Token: 0x040006E5 RID: 1765
		public Transform targetTransform;
	}
}
